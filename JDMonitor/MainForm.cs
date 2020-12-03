using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HtmlAgilityPack;
using JDMonitor.Entity;
using MoreLinq;
using PuppeteerSharp;
using ScrapySharp.Extensions;
using ServiceStack.OrmLite;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using Timer = System.Threading.Timer;

namespace JDMonitor
{
    public partial class MainForm : XtraForm
    {
        private readonly Timer _backupTimer;

        private readonly List<string> _userAgents = new List<string>()
        {
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.163 Safari/535.1",
            "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:6.0) Gecko/20100101 Firefox/6.0",
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/534.50 (KHTML, like Gecko) Version/5.1 Safari/534.50",
            "Opera/9.80 (Windows NT 6.1; U; zh-cn) Presto/2.9.168 Version/11.50",
            // "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Win64; x64; Trident/5.0; .NET CLR 2.0.50727; SLCC2; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; InfoPath.3; .NET4.0C; Tablet PC 2.0; .NET4.0E)",
            // "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; InfoPath.3)",
            // "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; GTB7.0)",
            // "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)",
            // "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1)",
            "Mozilla/5.0 (Windows; U; Windows NT 6.1; ) AppleWebKit/534.12 (KHTML, like Gecko) Maxthon/3.0 Safari/534.12",
           // "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; InfoPath.3; .NET4.0C; .NET4.0E)",
           // "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.102 Safari/537.36"
        };

        private readonly Options _options;
        private readonly Timer _timer;
        private Browser _browser;
        private readonly object _locker = new object();
        public MainForm()
        {
            InitializeComponent();
            _options = Options.Reload();
            _timer = new Timer(DispatchTask, null, Timeout.Infinite, Timeout.Infinite);
            _backupTimer = new Timer(BackupDatabase, null, TimeSpan.FromSeconds(60), TimeSpan.FromDays(1));
        }

        private void BackupDatabase(object state)
        {
            _options.BackupDatabase();
        }

        private void DispatchTask(object state)
        {
            try
            {
                _timer.Change(Timeout.Infinite, Timeout.Infinite);

                using var db = _options.GetDbConnection();
                var records = db.Select<Record>(r => r.IsEnable&&!r.IsDeleted);
                if (!records.Any())
                {
                    UpdateLog($"当前没有任何任务，{DateTime.Now}");
                    return;
                }

                if (_options.MaxDegreeOfParallelism > 1)

                {
                    Parallel.ForEach(records, new ParallelOptions()
                    {
                        MaxDegreeOfParallelism = _options.MaxDegreeOfParallelism
                    }, async record => await Handle(record));
                }

                else
                {
                    foreach (var record in records)
                    {
                        Handle(record).GetAwaiter().GetResult();
                    }
                }
            }
            finally
            {
                _timer.Change(_options.PeriodMilliseconds, _options.PeriodMilliseconds);
            }
        }

        private new async Task Handle(Record record, bool ignoreSyncPeriod = false)
        {
            try
            {
                if (record == null) return;
                if (!ignoreSyncPeriod && DateTime.Now - record.LastSyncAt < TimeSpan.FromSeconds(_options.Period))
                {
                    UpdateLog($"{record} 不满足同步周期，跳过此次同步，下次同步时间={record.LastSyncAt.AddSeconds(_options.Period)}");
                    return;
                }
                UpdateLog($"开始同步 {record}");
                var sw = Stopwatch.StartNew();
                using var tdb = _options.GetDbConnection();
                var content = await DownloadHtml3(record.Url);
                if (string.IsNullOrEmpty(content))
                {
                    sw.Stop();
                    var msg = $"{record} 未能请求到网页数据，耗时={sw.Elapsed}";
                    record.Remark = msg;
                    tdb.Insert<Log>(new Log() { Message = msg });
                    UpdateLog(msg);
                    RefreshGridData();
                }
                else
                {
                    UpdateLog($"{record.Title} 页面读取完成");
                    var doc = new HtmlDocument();
                    //doc.OptionFixNestedTags = true;
                    doc.LoadHtml(content);
                    HtmlNode priceNode = null;
                    foreach (var priceXPath in record.PriceXPathArray())
                    {
                        if (string.IsNullOrEmpty(priceXPath)) continue;
                        priceNode = QueryNode(doc, priceXPath,_options.UseCssSelector);
                        if (priceNode != null) break;
                    }
                    if (priceNode == null)
                    {
                        UpdateLog($"{record.Title} 价格读取失败");
                        sw.Stop();
                        tdb.Insert<Log>(new Log()
                        {
                            Message = $"{record} 解析网页数据失败，耗时={sw.Elapsed}"
                        });
                        record.Remark = "价格读取失败";
                        SendEmail($"[价格读取失败] - {record.Title}", $"链接={record.Url} {Environment.NewLine}当前价格XPath={record.PriceXPath}");
                        RefreshGridData();
                        return;
                    }

                    if (!float.TryParse(priceNode.InnerText, out var parsedPrice))
                    {
                        sw.Stop();
                        tdb.Insert<Log>(new Log()
                        {
                            Message = $"{record} 解析价格失败，耗时={sw.Elapsed}",
                            Tag = priceNode.InnerText
                        });
                        record.Remark = "解析价格失败";
                        RefreshGridData();
                        return;
                    }

                    UpdateLog($"{record.Title} 价格={parsedPrice}");
                    var price = new Price()
                    {
                        RecordId = record.Id,
                        Value = parsedPrice,
                        Date = DateTime.Now.ToString("yyyy-MM-dd")
                    };

                    if (!string.IsNullOrEmpty(record.CouponXPath))//采集优惠券信息
                    {
                        var couponNode = QueryNode(doc, record.CouponXPath, _options.UseCssSelector); 
                        if (couponNode != null) price.Coupon = couponNode.InnerText?.Trim().Replace(Environment.NewLine,"/");
                    }

                    if (!string.IsNullOrEmpty(record.ImageXPath))//采集预览图
                    {
                        var imgNode = QueryNode(doc, record.ImageXPath, _options.UseCssSelector); 
                        if (imgNode != null)
                        {
                            var src = imgNode.GetAttributeValue("src", "");
                            if (!string.IsNullOrEmpty(src))
                            {
                                if (src.StartsWith("//"))//如果未明确指明地址协议，则使用商品页相同的协议
                                {
                                    var uri = new Uri(record.Url);
                                    src = uri.Scheme + ":" + src;
                                }

                                record.ImageUrl = src;
                                //record.Image.ToString();
                            }
                        }
                    }


                    var priceStatView = tdb.Single<PriceStatView>(tdb
                        .From<Price>()
                        .Where(p => p.RecordId == record.Id)
                        .Select<Price>(x => new
                        {
                            Min = Sql.Min(x.Value),
                            Max = Sql.Max(x.Value),
                            Avg = Sql.Avg(x.Value)
                        }));
                    if (price.Value < priceStatView.Min)//历史最低
                    {
                        priceStatView.Min = price.Value;//更新最低价
                        SendEmail("历史最低", record, price, priceStatView);
                    }

                    var yesterdayDate = DateTime.Now.AddDays(-1).Date;
                    var yesterdayStatView = tdb.Single<PriceStatView>(tdb
                        .From<Price>()
                        .Where(p => p.RecordId == record.Id && p.CreateAt >= yesterdayDate)
                        .Select<Price>(x => new
                        {
                            Min = Sql.Min(x.Value),
                            Max = Sql.Max(x.Value),
                            Avg = Sql.Avg(x.Value)
                        }));
                    if (price.Value < yesterdayStatView.Min)//昨天到现在的价格情况
                    {
                        yesterdayStatView.Min = price.Value;//更新最低价
                        SendEmail("昨天距今", record, price, priceStatView);
                    }

                    tdb.Insert(price);
                    UpdateRecord(record, price);
                }
            }
            catch (Exception ex)
            {
                UpdateLog($"{record?.Title} 任务执行异常，详情={ex.Message}，堆栈={ex.StackTrace}");
            }
        }

        private void UpdateRecord(Record record, Price price)
        {
            for (int i = 0; i < gridView.RowCount; i++)
            {
                var row = gridView.GetRow(i) as Record;
                if (row == null || row.Id != record.Id) continue;
                row.LastSyncAt = DateTime.Now;
                row.NewestPrice = price.Value;
                row.NewestCoupon = price.Coupon;
                UpdateLog($"{record} 已在 { row.LastSyncAt} 完成同步");
            }
            RefreshGridData();
        }

        private HtmlNode QueryNode(HtmlDocument doc, string selector, bool isCssSelector = true)
        {
            if (doc == null) return null;
          
            if (!isCssSelector) return doc.DocumentNode.SelectSingleNode(selector);
            else return doc.DocumentNode.CssSelect(selector).FirstOrDefault();
        }

        private void RefreshGridData()
        {
            gridView.RefreshData();
            gridControl.RefreshDataSource();
        }


        private void SendEmail(string subject, string content)
        {
            var result = _options.SendEmail(subject, content,UpdateLog);
            using var db = _options.GetDbConnection();
            db.Insert<Mail>(new Mail()
            {
                Content = content,
                Subject = subject,
                Success = result,
                RecordId = -1
            });
        }

        private void SendEmail(string prefix, Record record, Price price, PriceStatView priceStatView)
        {
            var subject = $"价格下降- {prefix} - [{price.CreateAt.Date:yyyy-MM-dd}] [{record.Title}]";
            var content = $@"
商品地址={record.Url}
当前价格={price.Value}，最新优惠={record.NewestCoupon}
历史最高={priceStatView.Max},
历史最低={priceStatView.Min}
历史平均={priceStatView.Avg}
";
            var result = _options.SendEmail(subject, content,UpdateLog);
            if (!result) UpdateLog("发送邮件失败，请检查配置");
            using var db = _options.GetDbConnection();
            db.Insert<Mail>(new Mail()
            {
                Content = content,
                Subject = subject,
                Success = result,
                RecordId = record.Id
            });
        }

        private string DownloadHtml(string url)
        {
            var wc = new WebClient()
            {
                Encoding = Encoding.UTF8
            };
            return wc.DownloadString(url);
        }

        private string DownloadHtml2(string url)
        {
            var wb = new WebBrowser();
            wb.Navigate(url);
            var mre = new ManualResetEvent(false);
            wb.DocumentCompleted += (s, e) =>
            {
                // ReSharper disable once AccessToDisposedClosure
                mre.Set();
            };
            mre.WaitOne();
            mre.Dispose();
            return wb.Document?.Body?.InnerHtml;
        }

        private async Task<string> DownloadHtml3(string url)
        {
            try
            {
                if (_browser.IsClosed || !_browser.IsConnected)
                {
                    var b = _browser;
                    BuildBrowser();
                    await b.DisposeAsync();
                }
                //UpdateLog($"开始下载 {url}");
                //  var userAgent = await browser.GetUserAgentAsync();
                var page = await _browser.NewPageAsync();
                var index = Enumerable.Range(0, _userAgents.Count - 1).Shuffle().Shuffle().First();
                await page.SetUserAgentAsync(_userAgents[index]);
                page.RequestFailed += (s, e) =>
                {
                    UpdateLog($"{url} RequestFailed，{e.Request?.Response?.StatusText}");
                };
                page.PageError += (s, e) =>
                {
                    UpdateLog($"{url} PageError，{e.Message}");
                };
                var options = new NavigationOptions { Timeout = _options.PageLoadTimeout };
                await page.GoToAsync(url, options);

                //UpdateLog($"下载完成 {url}");
                var result = await page.GetContentAsync();
                await page.DisposeAsync();
                return result;
            }
            catch (Exception ex)
            {
                UpdateLog($"{url} 内容下载异常，详情={ex.Message}");
                return String.Empty;
            }
        }

        private void UpdateLog(string text)
        {
            if (!InvokeRequired)
            {
                if (medLog.Lines.Length >= _options.MaxLogLine) medLog.ResetText();
                // ReSharper disable once LocalizableElement
                medLog.Text += $"[{DateTime.Now}] {text} {Environment.NewLine}";
                medLog.SelectionStart = medLog.Text.Length;
                medLog.ScrollToCaret();
            }
            else this.Invoke(new Action(() => UpdateLog(text)));
        }

        private void UpdateStatus(string text)
        {
            if (!InvokeRequired)
                toolStripStatusLabel.Text = text;
            else this.Invoke(new Action(() => UpdateStatus(text)));
        }

        private void MainForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            _options.Save();
            SaveGridToDatabase();
            _timer.Dispose();
            _browser.Dispose();
        }

        private void RefreshGrid()
        {
            using var db = _options.GetDbConnection();
            gridControl.DataSource = db.Select<Record>(db.From<Record>().Where(r => r.IsDeleted == false).OrderBy(r => r.CreateAt));
            gridControl.Invalidate();
            gridView.RefreshData();
        }

        private void sbtnAdd_Click(object sender, System.EventArgs e)
        {
            var addForm = new AddForm();
            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                var record = addForm.GetRecord();
                if (record == null) return;
                using var db = _options.GetDbConnection();
                if (db.Exists<Record>(r => r.Url.Equals(record.Url, StringComparison.OrdinalIgnoreCase)))
                {
                    XtraMessageBox.Show(this, $"数据库已存在地址为{record.Url}的记录，请勿重复添加");
                    return;
                }
                else
                {
                    var id = db.Insert(record, true);
                    record.Id = (int)id;
                    RefreshGrid();
                    SynchronizationContext.Current.Post(async (d) =>
                    {
                        await Handle(record);
                    }, null);//新增后立即同步一次
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateLog("配置项" + Environment.NewLine + _options.ToJson());
            UpdateLog(Environment.NewLine);

            InitializeEnvironment();
            InitializeDatabase();
            RefreshGrid();
            _timer.Change(0, Timeout.Infinite);
        }

        private void InitializeEnvironment()
        {
            // var executablePath = PuppeteerSharp.Launcher.GetExecutablePath();
            UpdateLog($"正在检测浏览器环境");
            try
            {
                var bf = new BrowserFetcher()
                {
                    //WebProxy = new WebProxy("http://127.0.0.1:10809")
                };
                bf.DownloadProgressChanged += (s, e) =>
                {
                    UpdateLog($"正在下载 {BrowserFetcher.DefaultRevision},已完成 {e.ProgressPercentage} %");
                };
                var revisionInfo = bf.DownloadAsync(BrowserFetcher.DefaultRevision).GetAwaiter().GetResult();
                BuildBrowser();
                //var page = _browser.NewPageAsync().GetAwaiter().GetResult();
                UpdateLog($"环境初始化完成，Downloaded={revisionInfo.Downloaded} ExecutablePath={revisionInfo.ExecutablePath} FolderPath={revisionInfo.FolderPath} {revisionInfo.Local} Platform={revisionInfo.Platform} Revision={revisionInfo.Revision}");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, $"初始化环境出错，{ex.Message}");
                Environment.Exit(-1);
            }
        }

        private void BuildBrowser()
        {
            lock (_locker)
            {
                if (_browser != null && _browser.IsConnected) return;
                _browser = Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = _options.Headless,
                    IgnoreHTTPSErrors = true
                }).GetAwaiter().GetResult();
            }
        }

        private void InitializeDatabase()
        {
            using var db = _options.GetDbConnection();
            db.CreateTableIfNotExists<Record>();
            db.CreateTableIfNotExists<Price>();
            db.CreateTableIfNotExists<Log>();
            db.CreateTableIfNotExists<Mail>();

            //update 2020年9月12日
            db.CreateColumnIfNotExists<Price>(p => p.Date);
            db.CreateColumnIfNotExists<Record>(r => r.ImageXPath);
            db.CreateColumnIfNotExists<Record>(r => r.ImageUrl);

            db.CreateColumnIfNotExists<Record>(i => i.IsDeleted);
            db.CreateColumnIfNotExists<Price>(i => i.IsDeleted);
            db.CreateColumnIfNotExists<Log>(i => i.IsDeleted);

            db.CreateColumnIfNotExists<Record>(i => i.Remark);
        }

        private void sbtnSave_Click(object sender, EventArgs e)
        {
            SaveGridToDatabase();
            UpdateStatus("修改已存储，将在下次同步时自动生效");
        }

        private void SaveGridToDatabase()
        {
            using var db = _options.GetDbConnection();
            for (int i = 0; i < gridView.RowCount; i++)
            {
                var row = gridView.GetRow(i) as Record;
                if (row == null) continue;
                db.Update(row, r => r.Id == row.Id);
            }
        }

        private void sbtnChart_Click(object sender, EventArgs e)
        {
            var row = gridView.GetFocusedRow() as Record;
            if (row == null) return;
            new PriceTrendForm(_options, row.Id)
            {
                StartPosition = FormStartPosition.CenterParent
            }.ShowDialog(this);
        }

        private void sbtnGoto_Click(object sender, EventArgs e)
        {
            var row = gridView.GetFocusedRow() as Record;
            if (row == null) return;
            Process.Start(row.Url);
        }

        private void sbtnSyncNow_Click(object sender, EventArgs e)
        {
            var row = gridView.GetFocusedRow() as Record;
            if (row == null) return;
            Task.Run(async () => { await Handle(row, true); });
        }

        private void sbtnClearLog_Click(object sender, EventArgs e)
        {
            medLog.ResetText();
        }

        private void sbtnShinkDatabase_Click(object sender, EventArgs e)
        {
            _options.SinkDatabase();
            UpdateStatus("压缩数据库完成");
        }

        private void sbtnDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(this, "确认删除？", "警告") == DialogResult.OK)
            {
                var row = gridView.GetFocusedRow() as Record;
                if (row == null) return;
                row.IsDeleted = true;
                using var db = _options.GetDbConnection();
                db.Update(row, r => r.Id == row.Id);
                RefreshGrid();
            }
        }

        private void sbtnRefresh_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(this, "确认重新从数据库加载数据？", "警告") == DialogResult.OK)
            {
                RefreshGrid();
            }
        }
    }
}

using System;
using System.Data;
using System.IO;
using System.Text;
using MailKit.Net.Smtp;
using MimeKit;
using Newtonsoft.Json;
using ServiceStack.OrmLite;
#pragma warning disable 618

namespace JDMonitor
{
    public class Options
    {
        internal const string DbFile = "data.db";
        private Options(){}
        private const string ConfigFileName = "options.json";
        private static readonly OrmLiteConnectionFactory Factory = new OrmLiteConnectionFactory(DbFile, SqliteDialect.Instance);
        public MailOptions MailOptions { get; set; }=new MailOptions();

        /// <summary>
        /// 检测周期，单位 秒 默认4小时
        /// </summary>
        public int Period { get; set; } = (int)TimeSpan.FromHours(4).TotalSeconds;

        [JsonIgnore]
        public int PeriodMilliseconds => Period * 1000;
        public int MaxLogLine { get; set; } = 1024;
        public bool Headless { get; set; } = true;
        public int MaxDegreeOfParallelism { get; set; } = Environment.ProcessorCount;
        /// <summary>
        /// 页面加载超时时间，默认=60s
        /// </summary>
        public int? PageLoadTimeout { get; set; } = 60*1000;

        /// <summary>
        /// 是否使用UseCssSelector定位Html节点，如果为false则表示使用XPath
        /// </summary>
        public bool UseCssSelector { get; set; } = true;

        public IDbConnection GetDbConnection()
        {
            return Factory.OpenDbConnection();
        }

        internal void SinkDatabase()
        {
            if (Factory.DialectProvider == SqliteDialect.Instance)
            {
                using var db = GetDbConnection();
                db.ExecuteNonQuery("VACUUM");
            }
        }

        internal void BackupDatabase()
        {
            try
            {
                var directory = $@"Backup\{DateTime.Now:yyyyMMddHHmmssfff}";
                if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
                var bakPath = Path.Combine(directory, DbFile);
                File.Copy(DbFile, bakPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"备份数据库失败，详情={ex.Message}");
            }
        }

        public static Options Reload()
        {
            if (File.Exists(ConfigFileName)) return File.ReadAllText(ConfigFileName, Encoding.UTF8).FromJson<Options>();
            return new Options();
        }

        public bool SendEmail(string subject,string content,Action<string> logger)
        {
            if (!MailOptions.IsValid())
            {
                logger?.Invoke("邮件配置无效");
                return false;
            }
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(MailOptions.Sender));
                message.To.Add(new MailboxAddress(MailOptions.Receiver));

                message.Subject = subject;

                message.Body = new TextPart("plain")
                {
                    Text = content
                };
                using var client = new SmtpClient();
                client.Connect(MailOptions.MailHost, MailOptions.MailPort, true);
                client.Authenticate(MailOptions.Sender, MailOptions.MailCode);
                client.Send(message);
                client.Disconnect(true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Save()
        {
            File.WriteAllText(ConfigFileName,this.ToJson());
        }
    }

    public class MailOptions
    {
        public string Sender { get; set; } = "";
        public string Receiver { get; set; } = "";
        public string MailHost { get; set; } = "smtp.qq.com";
        public int MailPort { get; set; } = 465;
        public string MailCode { get; set; } = "";

        public bool IsValid()
        {
            return
                !string.IsNullOrEmpty(Sender)
                && !string.IsNullOrEmpty(Receiver)
                && !string.IsNullOrEmpty(MailHost)
                && !string.IsNullOrEmpty(MailCode);
        }
    }
}

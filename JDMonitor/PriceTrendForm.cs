using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using JDMonitor.Entity;
using ServiceStack.OrmLite;

namespace JDMonitor
{
    public partial class PriceTrendForm : XtraForm
    {
        private readonly int _recordId;
        private readonly Options _options;
        private readonly ChartControl _chartControl;
        private bool _loadDayPoints = true;

        public PriceTrendForm()
        {
            InitializeComponent();
        }

        public PriceTrendForm(Options options, int recordId) : this()
        {
            _recordId = recordId;
            _options = options;
            _chartControl=   new ChartControl()
            {
                Dock = DockStyle.Fill
            };
            splitContainerControl1.Panel1.Controls.Add(_chartControl);
            LoadPoints();
        }

        private void LoadPoints()
        {
            if (_loadDayPoints) LoadDayPoints();
            else LoadRawPoints();
        }

        private void LoadRawPoints()
        {
            _chartControl.Series.Clear();

            using var db = _options.GetDbConnection();
            var record = db.Single<Record>(r => r.Id == _recordId);
            if (record == null) return;
            var prices = db.Select<Price>(db.From<Price>().Where(p => p.RecordId == record.Id).OrderBy(p => p.CreateAt));
            Text = record.Title;
            var series = new Series("价格历史", ViewType.Line);
            series.ArgumentScaleType = ScaleType.Qualitative;
            if(prices.Count<=64) series.LabelsVisibility = DefaultBoolean.True;
            foreach (var price in prices)
            {
                series.Points.Add(new SeriesPoint(price.CreateAt, price.Value));
            }
            _chartControl.Series.Add(series);
        }

        private void LoadDayPoints()
        {
            _chartControl.Series.Clear();

            using var db = _options.GetDbConnection();
            var record = db.Single<Record>(r => r.Id == _recordId);
            if (record == null) return;
            var prices = db.Select<Price>(db
                .From<Price>()
                .Where(p => p.RecordId == record.Id)
                .GroupBy(p=>p.Date)
                .OrderBy(p => p.CreateAt)
                .Take(1024));
            Text = record.Title;
            var series = new Series("价格历史", ViewType.Line);
            series.LabelsVisibility = DefaultBoolean.True;
            series.ArgumentScaleType = ScaleType.Qualitative;
            foreach (var price in prices)
            {
                series.Points.Add(new SeriesPoint(price.Date, price.Value));
            }
            _chartControl.Series.Add(series);
        }

        private void sbtnDay_Click(object sender, System.EventArgs e)
        {
            _loadDayPoints = true;
            LoadPoints();
        }

        private void sbtnRaw_Click(object sender, System.EventArgs e)
        {
            _loadDayPoints = false;
            LoadPoints();
        }

        private void sbtnAddPricePoint_Click(object sender, System.EventArgs e)
        {
            if (new AddPricePointForm(_options, _recordId).ShowDialog(this) == DialogResult.OK)
            {
                LoadPoints();
            }
        }
    }
}

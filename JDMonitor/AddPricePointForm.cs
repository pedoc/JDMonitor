using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using JDMonitor.Entity;
using ServiceStack.OrmLite;

namespace JDMonitor
{
    public partial class AddPricePointForm : XtraForm
    {
        private readonly Options _options;
        private readonly int _recordId;

        public AddPricePointForm()
        {
            InitializeComponent();
        }

        public AddPricePointForm(Options options, int recordId):this()
        {
            _options = options;
            _recordId = recordId;
        }

        private void sbtnOk_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTime.Text))return;
            using var db = _options.GetDbConnection();
            var time = (DateTime)txtTime.EditValue;
            if (time == DateTime.MinValue || time == DateTime.MaxValue) return;
            var price=new Price()
            {
                Date = time.Date.ToString("yyyy-MM-dd"),
                CreateAt = time,
                RecordId = _recordId,
                Value = float.Parse(txtPrice.Text)
            };
            db.Insert<Price>(price);
            DialogResult = DialogResult.OK;
        }

        private void sbtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddPricePointForm_Load(object sender, EventArgs e)
        {
            txtTime.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            txtTime.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
        }
    }
}

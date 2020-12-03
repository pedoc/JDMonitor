using System;
using System.Windows.Forms;
using DevExpress.Utils.Layout;
using DevExpress.XtraEditors;
using JDMonitor.Entity;

namespace JDMonitor
{
    public class AddForm:XtraForm
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private Record _record;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private TextEdit txtTitle;
        private LabelControl labelControl2;
        private StackPanel stackPanel1;
        private SimpleButton sbtnOk;
        private SimpleButton sbtnCancel;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private MemoEdit medXPath;
        private TextEdit txtUrl;
        private CheckEdit cbnCheck;
        private LabelControl labelControl5;
        private MemoEdit medCoupon;
        private LabelControl labelControl6;
        private MemoEdit medImageXPath;
        private LabelControl labelControl1;

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtTitle = new DevExpress.XtraEditors.TextEdit();
            this.stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
            this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.medXPath = new DevExpress.XtraEditors.MemoEdit();
            this.txtUrl = new DevExpress.XtraEditors.TextEdit();
            this.cbnCheck = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.medCoupon = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.medImageXPath = new DevExpress.XtraEditors.MemoEdit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).BeginInit();
            this.stackPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medXPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbnCheck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medCoupon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medImageXPath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.stackPanel1, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.medXPath, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtUrl, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbnCheck, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.medCoupon, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelControl6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.medImageXPath, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(441, 396);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(3, 29);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "地址";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "标题";
            // 
            // txtTitle
            // 
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitle.Location = new System.Drawing.Point(57, 3);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(381, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // stackPanel1
            // 
            this.stackPanel1.AutoSize = true;
            this.stackPanel1.Controls.Add(this.sbtnOk);
            this.stackPanel1.Controls.Add(this.sbtnCancel);
            this.stackPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackPanel1.Location = new System.Drawing.Point(57, 343);
            this.stackPanel1.Name = "stackPanel1";
            this.stackPanel1.Size = new System.Drawing.Size(381, 50);
            this.stackPanel1.TabIndex = 2;
            // 
            // sbtnOk
            // 
            this.sbtnOk.Location = new System.Drawing.Point(3, 13);
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.Size = new System.Drawing.Size(75, 23);
            this.sbtnOk.TabIndex = 0;
            this.sbtnOk.Text = "确定(&O)";
            this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Location = new System.Drawing.Point(84, 13);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 1;
            this.sbtnCancel.Text = "取消(&C)";
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(3, 55);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "是否启用";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(3, 81);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 14);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "价格";
            // 
            // medXPath
            // 
            this.medXPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medXPath.EditValue = "span.p-price>span.price";
            this.medXPath.Location = new System.Drawing.Point(57, 81);
            this.medXPath.Name = "medXPath";
            this.medXPath.Size = new System.Drawing.Size(381, 70);
            this.medXPath.TabIndex = 6;
            // 
            // txtUrl
            // 
            this.txtUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUrl.Location = new System.Drawing.Point(57, 29);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(381, 20);
            this.txtUrl.TabIndex = 7;
            // 
            // cbnCheck
            // 
            this.cbnCheck.EditValue = true;
            this.cbnCheck.Location = new System.Drawing.Point(57, 55);
            this.cbnCheck.Name = "cbnCheck";
            this.cbnCheck.Properties.Caption = "";
            this.cbnCheck.Size = new System.Drawing.Size(75, 20);
            this.cbnCheck.TabIndex = 8;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(3, 259);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "优惠券";
            // 
            // medCoupon
            // 
            this.medCoupon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medCoupon.EditValue = "a.J-open-tb";
            this.medCoupon.Location = new System.Drawing.Point(57, 259);
            this.medCoupon.Name = "medCoupon";
            this.medCoupon.Size = new System.Drawing.Size(381, 78);
            this.medCoupon.TabIndex = 10;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(3, 157);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(24, 14);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "图片";
            // 
            // medImageXPath
            // 
            this.medImageXPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medImageXPath.EditValue = "#spec-img";
            this.medImageXPath.Location = new System.Drawing.Point(57, 157);
            this.medImageXPath.Name = "medImageXPath";
            this.medImageXPath.Size = new System.Drawing.Size(381, 96);
            this.medImageXPath.TabIndex = 12;
            // 
            // AddForm
            // 
            this.ClientSize = new System.Drawing.Size(441, 396);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).EndInit();
            this.stackPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.medXPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbnCheck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medCoupon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medImageXPath.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void sbtnOk_Click(object sender, EventArgs e)
        {
            if(!Check())return;
            _record=new Record()
            {
                Title = txtTitle.Text,
                IsEnable = cbnCheck.Checked,
                PriceXPath = medXPath.Text,
                CouponXPath = medCoupon.Text,
                Url = txtUrl.Text,
                ImageXPath = medImageXPath.Text
            };
            DialogResult = DialogResult.OK;
        }

        private bool Check()
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                XtraMessageBox.Show(this, "标题不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtUrl.Text))
            {
                XtraMessageBox.Show(this, "地址不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(medXPath.Text))
            {
                XtraMessageBox.Show(this, "XPath不能为空");
                return false;
            }

            return true;
        }

        public Record GetRecord() => _record;

        private void sbtnCancel_Click(object sender, EventArgs e)
        {
            _record = null;
            DialogResult = DialogResult.Cancel;
        }
    }
}

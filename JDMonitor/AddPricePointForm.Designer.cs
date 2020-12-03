
namespace JDMonitor
{
    partial class AddPricePointForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
            this.stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
            this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtTime = new DevExpress.XtraEditors.DateEdit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).BeginInit();
            this.stackPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.87302F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.12698F));
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPrice, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.stackPanel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTime, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(441, 92);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "时间";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(3, 29);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "价格";
            // 
            // txtPrice
            // 
            this.txtPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrice.Location = new System.Drawing.Point(73, 29);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.Mask.EditMask = "f";
            this.txtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrice.Size = new System.Drawing.Size(365, 20);
            this.txtPrice.TabIndex = 3;
            // 
            // sbtnOk
            // 
            this.sbtnOk.Location = new System.Drawing.Point(3, 3);
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.Size = new System.Drawing.Size(75, 23);
            this.sbtnOk.TabIndex = 4;
            this.sbtnOk.Text = "确定(&O)";
            this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
            // 
            // stackPanel1
            // 
            this.stackPanel1.AutoSize = true;
            this.stackPanel1.Controls.Add(this.sbtnOk);
            this.stackPanel1.Controls.Add(this.sbtnCancel);
            this.stackPanel1.Location = new System.Drawing.Point(73, 55);
            this.stackPanel1.Name = "stackPanel1";
            this.stackPanel1.Size = new System.Drawing.Size(162, 29);
            this.stackPanel1.TabIndex = 5;
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Location = new System.Drawing.Point(84, 3);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 5;
            this.sbtnCancel.Text = "取消(&C)";
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // txtTime
            // 
            this.txtTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTime.EditValue = null;
            this.txtTime.Location = new System.Drawing.Point(73, 3);
            this.txtTime.Name = "txtTime";
            this.txtTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTime.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.txtTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.txtTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.txtTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTime.Properties.Mask.EditMask = "G";
            this.txtTime.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.txtTime.Size = new System.Drawing.Size(365, 20);
            this.txtTime.TabIndex = 1;
            // 
            // AddPricePointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 92);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddPricePointForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加数据点";
            this.Load += new System.EventHandler(this.AddPricePointForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).EndInit();
            this.stackPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraEditors.SimpleButton sbtnOk;
        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraEditors.SimpleButton sbtnCancel;
        private DevExpress.XtraEditors.DateEdit txtTime;
    }
}
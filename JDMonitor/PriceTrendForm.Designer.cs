namespace JDMonitor
{
    partial class PriceTrendForm
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.sbtnDay = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnRaw = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnAddPricePoint = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.sbtnAddPricePoint);
            this.splitContainerControl1.Panel2.Controls.Add(this.sbtnDay);
            this.splitContainerControl1.Panel2.Controls.Add(this.sbtnRaw);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1026, 508);
            this.splitContainerControl1.SplitterPosition = 888;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // sbtnDay
            // 
            this.sbtnDay.Location = new System.Drawing.Point(24, 76);
            this.sbtnDay.Name = "sbtnDay";
            this.sbtnDay.Size = new System.Drawing.Size(92, 23);
            this.sbtnDay.TabIndex = 1;
            this.sbtnDay.Text = "按天采样(&D)";
            this.sbtnDay.Click += new System.EventHandler(this.sbtnDay_Click);
            // 
            // sbtnRaw
            // 
            this.sbtnRaw.Location = new System.Drawing.Point(24, 28);
            this.sbtnRaw.Name = "sbtnRaw";
            this.sbtnRaw.Size = new System.Drawing.Size(92, 23);
            this.sbtnRaw.TabIndex = 0;
            this.sbtnRaw.Text = "原始采样(&R)";
            this.sbtnRaw.Click += new System.EventHandler(this.sbtnRaw_Click);
            // 
            // sbtnAddPricePoint
            // 
            this.sbtnAddPricePoint.Location = new System.Drawing.Point(24, 151);
            this.sbtnAddPricePoint.Name = "sbtnAddPricePoint";
            this.sbtnAddPricePoint.Size = new System.Drawing.Size(92, 23);
            this.sbtnAddPricePoint.TabIndex = 2;
            this.sbtnAddPricePoint.Text = "添加数据点(&A)";
            this.sbtnAddPricePoint.Click += new System.EventHandler(this.sbtnAddPricePoint_Click);
            // 
            // PriceTrendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 508);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "PriceTrendForm";
            this.Text = "PriceTrendForm";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton sbtnRaw;
        private DevExpress.XtraEditors.SimpleButton sbtnDay;
        private DevExpress.XtraEditors.SimpleButton sbtnAddPricePoint;
    }
}
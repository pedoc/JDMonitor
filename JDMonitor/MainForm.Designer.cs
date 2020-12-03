namespace JDMonitor
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.medLog = new DevExpress.XtraEditors.MemoEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sbtnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnShinkDatabase = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnClearLog = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnSyncNow = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnGoto = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnChart = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbtnRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medLog.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.medLog);
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.sbtnRefresh);
            this.splitContainerControl1.Panel2.Controls.Add(this.sbtnDelete);
            this.splitContainerControl1.Panel2.Controls.Add(this.sbtnShinkDatabase);
            this.splitContainerControl1.Panel2.Controls.Add(this.sbtnClearLog);
            this.splitContainerControl1.Panel2.Controls.Add(this.sbtnSyncNow);
            this.splitContainerControl1.Panel2.Controls.Add(this.sbtnGoto);
            this.splitContainerControl1.Panel2.Controls.Add(this.sbtnChart);
            this.splitContainerControl1.Panel2.Controls.Add(this.sbtnSave);
            this.splitContainerControl1.Panel2.Controls.Add(this.sbtnAdd);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1265, 525);
            this.splitContainerControl1.SplitterPosition = 1138;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // medLog
            // 
            this.medLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.medLog.Location = new System.Drawing.Point(3, 342);
            this.medLog.Name = "medLog";
            this.medLog.Size = new System.Drawing.Size(1135, 158);
            this.medLog.TabIndex = 1;
            // 
            // gridControl
            // 
            this.gridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit1});
            this.gridControl.Size = new System.Drawing.Size(1138, 336);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn11,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn10,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn12,
            this.gridColumn13});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "编号";
            this.gridColumn5.FieldName = "Id";
            this.gridColumn5.MinWidth = 10;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 45;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "图片";
            this.gridColumn11.ColumnEdit = this.repositoryItemImageEdit1;
            this.gridColumn11.FieldName = "Image";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            this.repositoryItemImageEdit1.ReadOnly = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "标题";
            this.gridColumn1.FieldName = "Title";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 132;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "地址";
            this.gridColumn2.FieldName = "Url";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 132;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "是否启用";
            this.gridColumn3.FieldName = "IsEnable";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 132;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "XPath";
            this.gridColumn4.FieldName = "PriceXPath";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 132;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "CouponXPath";
            this.gridColumn10.FieldName = "CouponXPath";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 6;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "添加时间";
            this.gridColumn6.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "CreateAt";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            this.gridColumn6.Width = 132;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "上次同步";
            this.gridColumn7.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn7.FieldName = "LastSyncAt";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 9;
            this.gridColumn7.Width = 132;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "最新价格";
            this.gridColumn8.FieldName = "NewestPrice";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 10;
            this.gridColumn8.Width = 132;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "最新优惠";
            this.gridColumn9.FieldName = "NewestCoupon";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 11;
            this.gridColumn9.Width = 144;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "ImageXPath";
            this.gridColumn12.FieldName = "ImageXPath";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 7;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "备注";
            this.gridColumn13.FieldName = "Remark";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 12;
            // 
            // sbtnDelete
            // 
            this.sbtnDelete.Location = new System.Drawing.Point(27, 64);
            this.sbtnDelete.Name = "sbtnDelete";
            this.sbtnDelete.Size = new System.Drawing.Size(75, 23);
            this.sbtnDelete.TabIndex = 7;
            this.sbtnDelete.Text = "删除(&D)";
            this.sbtnDelete.Click += new System.EventHandler(this.sbtnDelete_Click);
            // 
            // sbtnShinkDatabase
            // 
            this.sbtnShinkDatabase.Location = new System.Drawing.Point(12, 312);
            this.sbtnShinkDatabase.Name = "sbtnShinkDatabase";
            this.sbtnShinkDatabase.Size = new System.Drawing.Size(90, 23);
            this.sbtnShinkDatabase.TabIndex = 6;
            this.sbtnShinkDatabase.Text = "压缩数据库(&D)";
            this.sbtnShinkDatabase.Click += new System.EventHandler(this.sbtnShinkDatabase_Click);
            // 
            // sbtnClearLog
            // 
            this.sbtnClearLog.Location = new System.Drawing.Point(12, 272);
            this.sbtnClearLog.Name = "sbtnClearLog";
            this.sbtnClearLog.Size = new System.Drawing.Size(90, 23);
            this.sbtnClearLog.TabIndex = 5;
            this.sbtnClearLog.Text = "清空日志(&P)";
            this.sbtnClearLog.Click += new System.EventHandler(this.sbtnClearLog_Click);
            // 
            // sbtnSyncNow
            // 
            this.sbtnSyncNow.Location = new System.Drawing.Point(27, 136);
            this.sbtnSyncNow.Name = "sbtnSyncNow";
            this.sbtnSyncNow.Size = new System.Drawing.Size(75, 23);
            this.sbtnSyncNow.TabIndex = 4;
            this.sbtnSyncNow.Text = "立即同步(&I)";
            this.sbtnSyncNow.Click += new System.EventHandler(this.sbtnSyncNow_Click);
            // 
            // sbtnGoto
            // 
            this.sbtnGoto.Location = new System.Drawing.Point(12, 352);
            this.sbtnGoto.Name = "sbtnGoto";
            this.sbtnGoto.Size = new System.Drawing.Size(90, 23);
            this.sbtnGoto.TabIndex = 3;
            this.sbtnGoto.Text = "打开详情页(&O)";
            this.sbtnGoto.Click += new System.EventHandler(this.sbtnGoto_Click);
            // 
            // sbtnChart
            // 
            this.sbtnChart.Location = new System.Drawing.Point(12, 232);
            this.sbtnChart.Name = "sbtnChart";
            this.sbtnChart.Size = new System.Drawing.Size(90, 23);
            this.sbtnChart.TabIndex = 2;
            this.sbtnChart.Text = "查看趋势图(&C)";
            this.sbtnChart.Click += new System.EventHandler(this.sbtnChart_Click);
            // 
            // sbtnSave
            // 
            this.sbtnSave.Location = new System.Drawing.Point(27, 100);
            this.sbtnSave.Name = "sbtnSave";
            this.sbtnSave.Size = new System.Drawing.Size(75, 23);
            this.sbtnSave.TabIndex = 1;
            this.sbtnSave.Text = "保存(&S)";
            this.sbtnSave.Click += new System.EventHandler(this.sbtnSave_Click);
            // 
            // sbtnAdd
            // 
            this.sbtnAdd.Location = new System.Drawing.Point(27, 28);
            this.sbtnAdd.Name = "sbtnAdd";
            this.sbtnAdd.Size = new System.Drawing.Size(75, 23);
            this.sbtnAdd.TabIndex = 0;
            this.sbtnAdd.Text = "添加(&A)";
            this.sbtnAdd.Click += new System.EventHandler(this.sbtnAdd_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 503);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1265, 22);
            this.statusStrip.TabIndex = 1;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // sbtnRefresh
            // 
            this.sbtnRefresh.Location = new System.Drawing.Point(27, 174);
            this.sbtnRefresh.Name = "sbtnRefresh";
            this.sbtnRefresh.Size = new System.Drawing.Size(75, 23);
            this.sbtnRefresh.TabIndex = 8;
            this.sbtnRefresh.Text = "刷新(&R)";
            this.sbtnRefresh.Click += new System.EventHandler(this.sbtnRefresh_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 525);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "MainForm";
            this.Text = "JDMonitor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.medLog.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.SimpleButton sbtnAdd;
        private System.Windows.Forms.StatusStrip statusStrip;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.SimpleButton sbtnSave;
        private DevExpress.XtraEditors.MemoEdit medLog;
        private DevExpress.XtraEditors.SimpleButton sbtnChart;
        private DevExpress.XtraEditors.SimpleButton sbtnGoto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.SimpleButton sbtnSyncNow;
        private DevExpress.XtraEditors.SimpleButton sbtnClearLog;
        private DevExpress.XtraEditors.SimpleButton sbtnShinkDatabase;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraEditors.SimpleButton sbtnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.SimpleButton sbtnRefresh;
    }
}


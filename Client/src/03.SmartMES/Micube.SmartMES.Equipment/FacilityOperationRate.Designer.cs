namespace Micube.SmartMES.Equipment
{
	partial class FacilityOperationRate
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
            this.components = new System.ComponentModel.Container();
            this.tabStateInfo = new Micube.Framework.SmartControls.SmartTabControl();
            this.pageToday = new DevExpress.XtraTab.XtraTabPage();
            this.chartToday = new Micube.Framework.SmartControls.SmartChart();
            this.spcToday = new Micube.Framework.SmartControls.SmartSpliterControl();
            this.grdToday = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.pageByCondition = new DevExpress.XtraTab.XtraTabPage();
            this.chartCondition = new Micube.Framework.SmartControls.SmartChart();
            this.spcCondition = new Micube.Framework.SmartControls.SmartSpliterControl();
            this.grdCondition = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.pageRowData = new DevExpress.XtraTab.XtraTabPage();
            this.grdRowData = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.spcRowData = new Micube.Framework.SmartControls.SmartSpliterControl();
            this.grdRowDataDetail = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabStateInfo)).BeginInit();
            this.tabStateInfo.SuspendLayout();
            this.pageToday.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartToday)).BeginInit();
            this.pageByCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCondition)).BeginInit();
            this.pageRowData.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(2, 31);
            this.pnlCondition.Size = new System.Drawing.Size(296, 751);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(763, 24);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.tabStateInfo);
            this.pnlContent.Size = new System.Drawing.Size(763, 755);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(1068, 784);
            // 
            // tabStateInfo
            // 
            this.tabStateInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabStateInfo.Location = new System.Drawing.Point(0, 0);
            this.tabStateInfo.Name = "tabStateInfo";
            this.tabStateInfo.SelectedTabPage = this.pageToday;
            this.tabStateInfo.Size = new System.Drawing.Size(763, 755);
            this.tabStateInfo.TabIndex = 0;
            this.tabStateInfo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageToday,
            this.pageByCondition,
            this.pageRowData});
            // 
            // pageToday
            // 
            this.pageToday.Controls.Add(this.chartToday);
            this.pageToday.Controls.Add(this.spcToday);
            this.pageToday.Controls.Add(this.grdToday);
            this.tabStateInfo.SetLanguageKey(this.pageToday, "BYTODAY");
            this.pageToday.Name = "pageToday";
            this.pageToday.Size = new System.Drawing.Size(757, 726);
            this.pageToday.Text = "xtraTabPage1";
            // 
            // chartToday
            // 
            this.chartToday.AutoLayout = false;
            this.chartToday.CacheToMemory = true;
            this.chartToday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartToday.IndicatorsPaletteName = "Concourse";
            this.chartToday.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.chartToday.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside;
            this.chartToday.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartToday.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartToday.Legend.Name = "Default Legend";
            this.chartToday.Legend.Title.Visible = true;
            this.chartToday.Location = new System.Drawing.Point(0, 0);
            this.chartToday.Name = "chartToday";
            this.chartToday.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartToday.Size = new System.Drawing.Size(757, 371);
            this.chartToday.TabIndex = 3;
            // 
            // spcToday
            // 
            this.spcToday.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.spcToday.Location = new System.Drawing.Point(0, 371);
            this.spcToday.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.spcToday.Name = "spcToday";
            this.spcToday.Size = new System.Drawing.Size(757, 5);
            this.spcToday.TabIndex = 1;
            this.spcToday.TabStop = false;
            // 
            // grdToday
            // 
            this.grdToday.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdToday.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdToday.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdToday.IsUsePaging = false;
            this.grdToday.LanguageKey = "RUNTIMEINFO";
            this.grdToday.Location = new System.Drawing.Point(0, 376);
            this.grdToday.Margin = new System.Windows.Forms.Padding(0);
            this.grdToday.Name = "grdToday";
            this.grdToday.ShowBorder = true;
            this.grdToday.ShowStatusBar = false;
            this.grdToday.Size = new System.Drawing.Size(757, 350);
            this.grdToday.TabIndex = 2;
            this.grdToday.UseAutoBestFitColumns = false;
            // 
            // pageByCondition
            // 
            this.pageByCondition.Controls.Add(this.chartCondition);
            this.pageByCondition.Controls.Add(this.spcCondition);
            this.pageByCondition.Controls.Add(this.grdCondition);
            this.tabStateInfo.SetLanguageKey(this.pageByCondition, "BYCONDITION");
            this.pageByCondition.Name = "pageByCondition";
            this.pageByCondition.Size = new System.Drawing.Size(757, 726);
            this.pageByCondition.Text = "xtraTabPage2";
            // 
            // chartCondition
            // 
            this.chartCondition.AutoLayout = false;
            this.chartCondition.CacheToMemory = true;
            this.chartCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCondition.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.chartCondition.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside;
            this.chartCondition.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartCondition.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartCondition.Legend.Name = "Default Legend";
            this.chartCondition.Location = new System.Drawing.Point(0, 0);
            this.chartCondition.Name = "chartCondition";
            this.chartCondition.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartCondition.Size = new System.Drawing.Size(757, 371);
            this.chartCondition.TabIndex = 2;
            // 
            // spcCondition
            // 
            this.spcCondition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.spcCondition.Location = new System.Drawing.Point(0, 371);
            this.spcCondition.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.spcCondition.Name = "spcCondition";
            this.spcCondition.Size = new System.Drawing.Size(757, 5);
            this.spcCondition.TabIndex = 1;
            this.spcCondition.TabStop = false;
            // 
            // grdCondition
            // 
            this.grdCondition.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdCondition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdCondition.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdCondition.IsUsePaging = false;
            this.grdCondition.LanguageKey = "RUNTIMEINFO";
            this.grdCondition.Location = new System.Drawing.Point(0, 376);
            this.grdCondition.Margin = new System.Windows.Forms.Padding(0);
            this.grdCondition.Name = "grdCondition";
            this.grdCondition.ShowBorder = true;
            this.grdCondition.ShowStatusBar = false;
            this.grdCondition.Size = new System.Drawing.Size(757, 350);
            this.grdCondition.TabIndex = 0;
            this.grdCondition.UseAutoBestFitColumns = false;
            // 
            // pageRowData
            // 
            this.pageRowData.Controls.Add(this.grdRowData);
            this.pageRowData.Controls.Add(this.spcRowData);
            this.pageRowData.Controls.Add(this.grdRowDataDetail);
            this.tabStateInfo.SetLanguageKey(this.pageRowData, "BYROWDATA");
            this.pageRowData.Name = "pageRowData";
            this.pageRowData.Size = new System.Drawing.Size(757, 726);
            this.pageRowData.Text = "xtraTabPage3";
            // 
            // grdRowData
            // 
            this.grdRowData.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdRowData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRowData.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdRowData.IsUsePaging = false;
            this.grdRowData.LanguageKey = "EQUIPMENTRUNTIMERATEROWDATA";
            this.grdRowData.Location = new System.Drawing.Point(0, 0);
            this.grdRowData.Margin = new System.Windows.Forms.Padding(0);
            this.grdRowData.Name = "grdRowData";
            this.grdRowData.ShowBorder = true;
            this.grdRowData.ShowStatusBar = false;
            this.grdRowData.Size = new System.Drawing.Size(202, 726);
            this.grdRowData.TabIndex = 1;
            this.grdRowData.UseAutoBestFitColumns = false;
            // 
            // spcRowData
            // 
            this.spcRowData.Dock = System.Windows.Forms.DockStyle.Right;
            this.spcRowData.Location = new System.Drawing.Point(202, 0);
            this.spcRowData.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.spcRowData.Name = "spcRowData";
            this.spcRowData.Size = new System.Drawing.Size(5, 726);
            this.spcRowData.TabIndex = 2;
            this.spcRowData.TabStop = false;
            // 
            // grdRowDataDetail
            // 
            this.grdRowDataDetail.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdRowDataDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.grdRowDataDetail.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdRowDataDetail.IsUsePaging = false;
            this.grdRowDataDetail.LanguageKey = "EQUIPMENTRUNSTOPSTATE";
            this.grdRowDataDetail.Location = new System.Drawing.Point(207, 0);
            this.grdRowDataDetail.Margin = new System.Windows.Forms.Padding(0);
            this.grdRowDataDetail.Name = "grdRowDataDetail";
            this.grdRowDataDetail.ShowBorder = true;
            this.grdRowDataDetail.ShowStatusBar = false;
            this.grdRowDataDetail.Size = new System.Drawing.Size(550, 726);
            this.grdRowDataDetail.TabIndex = 0;
            this.grdRowDataDetail.UseAutoBestFitColumns = false;
            // 
            // FacilityOperationRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 804);
            this.Name = "FacilityOperationRate";
            this.Text = "SmartConditionBaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabStateInfo)).EndInit();
            this.tabStateInfo.ResumeLayout(false);
            this.pageToday.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartToday)).EndInit();
            this.pageByCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCondition)).EndInit();
            this.pageRowData.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Framework.SmartControls.SmartTabControl tabStateInfo;
		private DevExpress.XtraTab.XtraTabPage pageToday;
		private DevExpress.XtraTab.XtraTabPage pageByCondition;
		private DevExpress.XtraTab.XtraTabPage pageRowData;
		private Framework.SmartControls.SmartSpliterControl spcRowData;
		private Framework.SmartControls.SmartBandedGrid grdRowData;
		private Framework.SmartControls.SmartBandedGrid grdRowDataDetail;
		private Framework.SmartControls.SmartSpliterControl spcToday;
		private Framework.SmartControls.SmartBandedGrid grdToday;
		private Framework.SmartControls.SmartChart chartCondition;
		private Framework.SmartControls.SmartSpliterControl spcCondition;
		private Framework.SmartControls.SmartBandedGrid grdCondition;
		private Framework.SmartControls.SmartChart chartToday;
	}
}
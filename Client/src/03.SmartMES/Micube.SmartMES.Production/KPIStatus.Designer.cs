namespace Micube.SmartMES.Production
{
    partial class KPIStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KPIStatus));
            this.lblExportReverse = new Micube.Framework.SmartControls.SmartLabel();
            this.MainTab = new Micube.Framework.SmartControls.SmartTabControl();
            this.allSelectTab = new DevExpress.XtraTab.XtraTabPage();
            this.smartSpliterContainer1 = new Micube.Framework.SmartControls.SmartSpliterContainer();
            this.AllChart = new Micube.Framework.SmartControls.SmartChart();
            this.teamSelectTab = new DevExpress.XtraTab.XtraTabPage();
            this.smartSpliterContainer2 = new Micube.Framework.SmartControls.SmartSpliterContainer();
            this.TeamChart = new Micube.Framework.SmartControls.SmartChart();
            this.grdAll = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.grdTeam = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlToolbar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainTab)).BeginInit();
            this.MainTab.SuspendLayout();
            this.allSelectTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).BeginInit();
            this.smartSpliterContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllChart)).BeginInit();
            this.teamSelectTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer2)).BeginInit();
            this.smartSpliterContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TeamChart)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(2, 31);
            this.pnlCondition.Size = new System.Drawing.Size(296, 729);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Controls.Add(this.lblExportReverse);
            this.pnlToolbar.Size = new System.Drawing.Size(975, 24);
            this.pnlToolbar.Controls.SetChildIndex(this.lblExportReverse, 0);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.MainTab);
            this.pnlContent.Size = new System.Drawing.Size(975, 733);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(1280, 762);
            // 
            // lblExportReverse
            // 
            this.lblExportReverse.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblExportReverse.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblExportReverse.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblExportReverse.ImageOptions.Image")));
            this.lblExportReverse.Location = new System.Drawing.Point(941, 0);
            this.lblExportReverse.Name = "lblExportReverse";
            this.lblExportReverse.Size = new System.Drawing.Size(34, 24);
            this.lblExportReverse.TabIndex = 16;
            this.lblExportReverse.Click += new System.EventHandler(this.lblExportReverse_Click);
            // 
            // MainTab
            // 
            this.MainTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTab.Location = new System.Drawing.Point(0, 0);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedTabPage = this.allSelectTab;
            this.MainTab.Size = new System.Drawing.Size(975, 733);
            this.MainTab.TabIndex = 0;
            this.MainTab.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.allSelectTab,
            this.teamSelectTab});
            // 
            // allSelectTab
            // 
            this.allSelectTab.Controls.Add(this.smartSpliterContainer1);
            this.allSelectTab.Name = "allSelectTab";
            this.allSelectTab.Size = new System.Drawing.Size(969, 704);
            this.allSelectTab.Text = "ALL";
            // 
            // smartSpliterContainer1
            // 
            this.smartSpliterContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSpliterContainer1.Horizontal = false;
            this.smartSpliterContainer1.Location = new System.Drawing.Point(0, 0);
            this.smartSpliterContainer1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterContainer1.Name = "smartSpliterContainer1";
            this.smartSpliterContainer1.Panel1.Controls.Add(this.AllChart);
            this.smartSpliterContainer1.Panel1.Text = "Panel1";
            this.smartSpliterContainer1.Panel2.Controls.Add(this.grdAll);
            this.smartSpliterContainer1.Panel2.Text = "Panel2";
            this.smartSpliterContainer1.Size = new System.Drawing.Size(969, 704);
            this.smartSpliterContainer1.SplitterPosition = 477;
            this.smartSpliterContainer1.TabIndex = 1;
            this.smartSpliterContainer1.Text = "smartSpliterContainer1";
            // 
            // AllChart
            // 
            this.AllChart.AutoLayout = false;
            this.AllChart.BackColor = System.Drawing.Color.White;
            this.AllChart.CacheToMemory = true;
            this.AllChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllChart.Legend.Name = "Default Legend";
            this.AllChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.AllChart.Location = new System.Drawing.Point(0, 0);
            this.AllChart.Name = "AllChart";
            this.AllChart.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.AllChart.Size = new System.Drawing.Size(969, 477);
            this.AllChart.TabIndex = 0;
            // 
            // teamSelectTab
            // 
            this.teamSelectTab.Controls.Add(this.smartSpliterContainer2);
            this.teamSelectTab.Name = "teamSelectTab";
            this.teamSelectTab.Size = new System.Drawing.Size(969, 704);
            this.teamSelectTab.Text = "Team";
            // 
            // smartSpliterContainer2
            // 
            this.smartSpliterContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSpliterContainer2.Horizontal = false;
            this.smartSpliterContainer2.Location = new System.Drawing.Point(0, 0);
            this.smartSpliterContainer2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterContainer2.Name = "smartSpliterContainer2";
            this.smartSpliterContainer2.Panel1.Controls.Add(this.TeamChart);
            this.smartSpliterContainer2.Panel1.Text = "Panel1";
            this.smartSpliterContainer2.Panel2.Controls.Add(this.grdTeam);
            this.smartSpliterContainer2.Panel2.Text = "Panel2";
            this.smartSpliterContainer2.Size = new System.Drawing.Size(969, 704);
            this.smartSpliterContainer2.SplitterPosition = 477;
            this.smartSpliterContainer2.TabIndex = 1;
            this.smartSpliterContainer2.Text = "smartSpliterContainer2";
            // 
            // TeamChart
            // 
            this.TeamChart.AutoLayout = false;
            this.TeamChart.BackColor = System.Drawing.Color.White;
            this.TeamChart.CacheToMemory = true;
            this.TeamChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeamChart.Legend.Name = "Default Legend";
            this.TeamChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.TeamChart.Location = new System.Drawing.Point(0, 0);
            this.TeamChart.Name = "TeamChart";
            this.TeamChart.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.TeamChart.Size = new System.Drawing.Size(969, 477);
            this.TeamChart.TabIndex = 0;
            // 
            // grdAll
            // 
            this.grdAll.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAll.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdAll.IsUsePaging = false;
            this.grdAll.LanguageKey = "MONTHWORKPRODUCTION";
            this.grdAll.Location = new System.Drawing.Point(0, 0);
            this.grdAll.Margin = new System.Windows.Forms.Padding(0);
            this.grdAll.Name = "grdAll";
            this.grdAll.ShowBorder = true;
            this.grdAll.ShowStatusBar = false;
            this.grdAll.Size = new System.Drawing.Size(969, 222);
            this.grdAll.TabIndex = 0;
            this.grdAll.UseAutoBestFitColumns = false;
            // 
            // grdTeam
            // 
            this.grdTeam.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdTeam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTeam.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdTeam.IsUsePaging = false;
            this.grdTeam.LanguageKey = "MONTHWORKPRODUCTION";
            this.grdTeam.Location = new System.Drawing.Point(0, 0);
            this.grdTeam.Margin = new System.Windows.Forms.Padding(0);
            this.grdTeam.Name = "grdTeam";
            this.grdTeam.ShowBorder = true;
            this.grdTeam.Size = new System.Drawing.Size(969, 222);
            this.grdTeam.TabIndex = 1;
            this.grdTeam.UseAutoBestFitColumns = false;
            // 
            // KPIStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 800);
            this.Name = "KPIStatus";
            this.Padding = new System.Windows.Forms.Padding(19);
            this.Text = "SmartConditionBaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainTab)).EndInit();
            this.MainTab.ResumeLayout(false);
            this.allSelectTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).EndInit();
            this.smartSpliterContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AllChart)).EndInit();
            this.teamSelectTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer2)).EndInit();
            this.smartSpliterContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TeamChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Framework.SmartControls.SmartLabel lblExportReverse;
        private Framework.SmartControls.SmartTabControl MainTab;
        private DevExpress.XtraTab.XtraTabPage allSelectTab;
        private DevExpress.XtraTab.XtraTabPage teamSelectTab;
        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer1;
        private Framework.SmartControls.SmartChart AllChart;
        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer2;
        private Framework.SmartControls.SmartChart TeamChart;
        private Framework.SmartControls.SmartBandedGrid grdAll;
        private Framework.SmartControls.SmartBandedGrid grdTeam;
    }
}
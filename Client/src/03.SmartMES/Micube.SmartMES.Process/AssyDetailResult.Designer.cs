namespace Micube.SmartMES.Process
{
    partial class AssyDetailResult
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
            this.spcContainter = new Micube.Framework.SmartControls.SmartSpliterContainer();
            this.grdMain = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.tabResult = new Micube.Framework.SmartControls.SmartTabControl();
            this.pageProcessResult = new DevExpress.XtraTab.XtraTabPage();
            this.grdProceeResult = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.pageWorkResult = new DevExpress.XtraTab.XtraTabPage();
            this.grdWorkResult = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.pageInspResult = new DevExpress.XtraTab.XtraTabPage();
            this.grdInspResult = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.pageInputMaterialHist = new DevExpress.XtraTab.XtraTabPage();
            this.grdMatInputHist = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcContainter)).BeginInit();
            this.spcContainter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabResult)).BeginInit();
            this.tabResult.SuspendLayout();
            this.pageProcessResult.SuspendLayout();
            this.pageWorkResult.SuspendLayout();
            this.pageInspResult.SuspendLayout();
            this.pageInputMaterialHist.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(2, 31);
            this.pnlCondition.Size = new System.Drawing.Size(296, 429);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(509, 24);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.spcContainter);
            this.pnlContent.Size = new System.Drawing.Size(509, 433);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(814, 462);
            // 
            // spcContainter
            // 
            this.spcContainter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcContainter.Horizontal = false;
            this.spcContainter.Location = new System.Drawing.Point(0, 0);
            this.spcContainter.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.spcContainter.Name = "spcContainter";
            this.spcContainter.Panel1.Controls.Add(this.grdMain);
            this.spcContainter.Panel1.Text = "Panel1";
            this.spcContainter.Panel2.Controls.Add(this.tabResult);
            this.spcContainter.Panel2.Text = "Panel2";
            this.spcContainter.Size = new System.Drawing.Size(509, 433);
            this.spcContainter.SplitterPosition = 271;
            this.spcContainter.TabIndex = 0;
            this.spcContainter.Text = "smartSpliterContainer1";
            // 
            // grdMain
            // 
            this.grdMain.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMain.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdMain.IsUsePaging = false;
            this.grdMain.LanguageKey = "GRIDLOTLIST";
            this.grdMain.Location = new System.Drawing.Point(0, 0);
            this.grdMain.Margin = new System.Windows.Forms.Padding(0);
            this.grdMain.Name = "grdMain";
            this.grdMain.ShowBorder = true;
            this.grdMain.Size = new System.Drawing.Size(509, 271);
            this.grdMain.TabIndex = 0;
            this.grdMain.UseAutoBestFitColumns = false;
            // 
            // tabResult
            // 
            this.tabResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResult.Location = new System.Drawing.Point(0, 0);
            this.tabResult.Name = "tabResult";
            this.tabResult.SelectedTabPage = this.pageProcessResult;
            this.tabResult.Size = new System.Drawing.Size(509, 157);
            this.tabResult.TabIndex = 0;
            this.tabResult.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageProcessResult,
            this.pageWorkResult,
            this.pageInspResult,
            this.pageInputMaterialHist});
            // 
            // pageProcessResult
            // 
            this.pageProcessResult.Controls.Add(this.grdProceeResult);
            this.tabResult.SetLanguageKey(this.pageProcessResult, "PROCESSRESULT");
            this.pageProcessResult.Name = "pageProcessResult";
            this.pageProcessResult.Size = new System.Drawing.Size(503, 128);
            this.pageProcessResult.Text = "xtraTabPage1";
            // 
            // grdProceeResult
            // 
            this.grdProceeResult.Caption = "";
            this.grdProceeResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProceeResult.GridButtonItem = Micube.Framework.SmartControls.GridButtonItem.Export;
            this.grdProceeResult.IsUsePaging = false;
            this.grdProceeResult.LanguageKey = null;
            this.grdProceeResult.Location = new System.Drawing.Point(0, 0);
            this.grdProceeResult.Margin = new System.Windows.Forms.Padding(0);
            this.grdProceeResult.Name = "grdProceeResult";
            this.grdProceeResult.ShowBorder = true;
            this.grdProceeResult.ShowStatusBar = false;
            this.grdProceeResult.Size = new System.Drawing.Size(503, 128);
            this.grdProceeResult.TabIndex = 0;
            this.grdProceeResult.UseAutoBestFitColumns = false;
            // 
            // pageWorkResult
            // 
            this.pageWorkResult.Controls.Add(this.grdWorkResult);
            this.tabResult.SetLanguageKey(this.pageWorkResult, "WORKRESULT");
            this.pageWorkResult.Name = "pageWorkResult";
            this.pageWorkResult.Size = new System.Drawing.Size(469, 96);
            this.pageWorkResult.Text = "xtraTabPage2";
            // 
            // grdWorkResult
            // 
            this.grdWorkResult.Caption = "";
            this.grdWorkResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWorkResult.GridButtonItem = Micube.Framework.SmartControls.GridButtonItem.Export;
            this.grdWorkResult.IsUsePaging = false;
            this.grdWorkResult.LanguageKey = null;
            this.grdWorkResult.Location = new System.Drawing.Point(0, 0);
            this.grdWorkResult.Margin = new System.Windows.Forms.Padding(0);
            this.grdWorkResult.Name = "grdWorkResult";
            this.grdWorkResult.ShowBorder = true;
            this.grdWorkResult.ShowStatusBar = false;
            this.grdWorkResult.Size = new System.Drawing.Size(469, 96);
            this.grdWorkResult.TabIndex = 1;
            this.grdWorkResult.UseAutoBestFitColumns = false;
            // 
            // pageInspResult
            // 
            this.pageInspResult.Controls.Add(this.grdInspResult);
            this.tabResult.SetLanguageKey(this.pageInspResult, "INSPRESULT");
            this.pageInspResult.Name = "pageInspResult";
            this.pageInspResult.Size = new System.Drawing.Size(469, 96);
            this.pageInspResult.Text = "xtraTabPage3";
            // 
            // grdInspResult
            // 
            this.grdInspResult.Caption = "";
            this.grdInspResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInspResult.GridButtonItem = Micube.Framework.SmartControls.GridButtonItem.Export;
            this.grdInspResult.IsUsePaging = false;
            this.grdInspResult.LanguageKey = null;
            this.grdInspResult.Location = new System.Drawing.Point(0, 0);
            this.grdInspResult.Margin = new System.Windows.Forms.Padding(0);
            this.grdInspResult.Name = "grdInspResult";
            this.grdInspResult.ShowBorder = true;
            this.grdInspResult.ShowStatusBar = false;
            this.grdInspResult.Size = new System.Drawing.Size(469, 96);
            this.grdInspResult.TabIndex = 1;
            this.grdInspResult.UseAutoBestFitColumns = false;
            // 
            // pageInputMaterialHist
            // 
            this.pageInputMaterialHist.Controls.Add(this.grdMatInputHist);
            this.tabResult.SetLanguageKey(this.pageInputMaterialHist, "MATINPUTHIST");
            this.pageInputMaterialHist.Name = "pageInputMaterialHist";
            this.pageInputMaterialHist.Size = new System.Drawing.Size(469, 96);
            this.pageInputMaterialHist.Text = "xtraTabPage4";
            // 
            // grdMatInputHist
            // 
            this.grdMatInputHist.Caption = "";
            this.grdMatInputHist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMatInputHist.GridButtonItem = Micube.Framework.SmartControls.GridButtonItem.Export;
            this.grdMatInputHist.IsUsePaging = false;
            this.grdMatInputHist.LanguageKey = null;
            this.grdMatInputHist.Location = new System.Drawing.Point(0, 0);
            this.grdMatInputHist.Margin = new System.Windows.Forms.Padding(0);
            this.grdMatInputHist.Name = "grdMatInputHist";
            this.grdMatInputHist.ShowBorder = true;
            this.grdMatInputHist.ShowStatusBar = false;
            this.grdMatInputHist.Size = new System.Drawing.Size(469, 96);
            this.grdMatInputHist.TabIndex = 1;
            this.grdMatInputHist.UseAutoBestFitColumns = false;
            // 
            // AssyDetailResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 482);
            this.Name = "AssyDetailResult";
            this.Text = "SmartConditionBaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcContainter)).EndInit();
            this.spcContainter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabResult)).EndInit();
            this.tabResult.ResumeLayout(false);
            this.pageProcessResult.ResumeLayout(false);
            this.pageWorkResult.ResumeLayout(false);
            this.pageInspResult.ResumeLayout(false);
            this.pageInputMaterialHist.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartSpliterContainer spcContainter;
        private Framework.SmartControls.SmartBandedGrid grdMain;
        private Framework.SmartControls.SmartTabControl tabResult;
        private DevExpress.XtraTab.XtraTabPage pageProcessResult;
        private DevExpress.XtraTab.XtraTabPage pageWorkResult;
        private DevExpress.XtraTab.XtraTabPage pageInspResult;
        private DevExpress.XtraTab.XtraTabPage pageInputMaterialHist;
        private Framework.SmartControls.SmartBandedGrid grdProceeResult;
        private Framework.SmartControls.SmartBandedGrid grdWorkResult;
        private Framework.SmartControls.SmartBandedGrid grdInspResult;
        private Framework.SmartControls.SmartBandedGrid grdMatInputHist;
    }
}
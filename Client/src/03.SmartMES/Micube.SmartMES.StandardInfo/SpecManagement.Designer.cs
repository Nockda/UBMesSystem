namespace Micube.SmartMES.StandardInfo
{
    partial class SpecManagement
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
            this.smartTabControl1 = new Micube.Framework.SmartControls.SmartTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grdMainSpec = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.grdSubSpec = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.grdSpecDetail = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.grdSpecSearch = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartTabControl1)).BeginInit();
            this.smartTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(2, 31);
            this.pnlCondition.Size = new System.Drawing.Size(296, 567);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(981, 24);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.smartTabControl1);
            this.pnlContent.Size = new System.Drawing.Size(981, 571);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(1286, 600);
            // 
            // smartTabControl1
            // 
            this.smartTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartTabControl1.Location = new System.Drawing.Point(0, 0);
            this.smartTabControl1.Name = "smartTabControl1";
            this.smartTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.smartTabControl1.Size = new System.Drawing.Size(981, 571);
            this.smartTabControl1.TabIndex = 3;
            this.smartTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.splitContainer2);
            this.smartTabControl1.SetLanguageKey(this.xtraTabPage1, "SPECINFO");
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(975, 542);
            this.xtraTabPage1.Text = "스펙등록";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.grdSpecSearch);
            this.smartTabControl1.SetLanguageKey(this.xtraTabPage2, "SPECSEARCH");
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(975, 542);
            this.xtraTabPage2.Text = "스펙조회";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.grdMainSpec);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(975, 542);
            this.splitContainer2.SplitterDistance = 164;
            this.splitContainer2.TabIndex = 5;
            // 
            // grdMainSpec
            // 
            this.grdMainSpec.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdMainSpec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMainSpec.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdMainSpec.IsUsePaging = false;
            this.grdMainSpec.LanguageKey = "SPECINFO";
            this.grdMainSpec.Location = new System.Drawing.Point(0, 0);
            this.grdMainSpec.Margin = new System.Windows.Forms.Padding(0);
            this.grdMainSpec.Name = "grdMainSpec";
            this.grdMainSpec.ShowBorder = true;
            this.grdMainSpec.Size = new System.Drawing.Size(975, 164);
            this.grdMainSpec.TabIndex = 3;
            this.grdMainSpec.UseAutoBestFitColumns = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.grdSubSpec);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.grdSpecDetail);
            this.splitContainer3.Size = new System.Drawing.Size(975, 374);
            this.splitContainer3.SplitterDistance = 325;
            this.splitContainer3.TabIndex = 0;
            // 
            // grdSubSpec
            // 
            this.grdSubSpec.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdSubSpec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSubSpec.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdSubSpec.IsUsePaging = false;
            this.grdSubSpec.LanguageKey = "SPECSUBSEGMENTINFO";
            this.grdSubSpec.Location = new System.Drawing.Point(0, 0);
            this.grdSubSpec.Margin = new System.Windows.Forms.Padding(0);
            this.grdSubSpec.Name = "grdSubSpec";
            this.grdSubSpec.ShowBorder = true;
            this.grdSubSpec.Size = new System.Drawing.Size(325, 374);
            this.grdSubSpec.TabIndex = 2;
            this.grdSubSpec.UseAutoBestFitColumns = false;
            // 
            // grdSpecDetail
            // 
            this.grdSpecDetail.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdSpecDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSpecDetail.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdSpecDetail.IsUsePaging = false;
            this.grdSpecDetail.LanguageKey = "ITEMINFO";
            this.grdSpecDetail.Location = new System.Drawing.Point(0, 0);
            this.grdSpecDetail.Margin = new System.Windows.Forms.Padding(0);
            this.grdSpecDetail.Name = "grdSpecDetail";
            this.grdSpecDetail.ShowBorder = true;
            this.grdSpecDetail.Size = new System.Drawing.Size(646, 374);
            this.grdSpecDetail.TabIndex = 1;
            this.grdSpecDetail.UseAutoBestFitColumns = false;
            // 
            // grdSpecSearch
            // 
            this.grdSpecSearch.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdSpecSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSpecSearch.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdSpecSearch.IsUsePaging = false;
            this.grdSpecSearch.LanguageKey = "SPECSEARCH";
            this.grdSpecSearch.Location = new System.Drawing.Point(0, 0);
            this.grdSpecSearch.Margin = new System.Windows.Forms.Padding(0);
            this.grdSpecSearch.Name = "grdSpecSearch";
            this.grdSpecSearch.ShowBorder = true;
            this.grdSpecSearch.ShowStatusBar = false;
            this.grdSpecSearch.Size = new System.Drawing.Size(975, 542);
            this.grdSpecSearch.TabIndex = 4;
            this.grdSpecSearch.UseAutoBestFitColumns = false;
            // 
            // SpecManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 620);
            this.Name = "SpecManagement";
            this.Text = "SmartConditionBaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartTabControl1)).EndInit();
            this.smartTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartTabControl smartTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Framework.SmartControls.SmartBandedGrid grdMainSpec;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private Framework.SmartControls.SmartBandedGrid grdSubSpec;
        private Framework.SmartControls.SmartBandedGrid grdSpecDetail;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private Framework.SmartControls.SmartBandedGrid grdSpecSearch;
    }
}
namespace Micube.SmartMES.StandardInfo
{
    partial class LabelReissue
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
            this.LotTab = new DevExpress.XtraTab.XtraTabPage();
            this.grdLot = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.spnCopy = new Micube.Framework.SmartControls.SmartLabelSpinEdit();
            this.MaterialTab = new DevExpress.XtraTab.XtraTabPage();
            this.grdConsumable = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            this.spnCopy2 = new Micube.Framework.SmartControls.SmartLabelSpinEdit();
            this.webService1 = new Micube.SmartMES.SystemManagement.SmartDeployService.WebService();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartTabControl1)).BeginInit();
            this.smartTabControl1.SuspendLayout();
            this.LotTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnCopy.Properties)).BeginInit();
            this.MaterialTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            this.smartPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnCopy2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Size = new System.Drawing.Size(371, 672);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(1267, 30);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.smartTabControl1);
            this.pnlContent.Size = new System.Drawing.Size(1267, 675);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(1648, 711);
            // 
            // smartTabControl1
            // 
            this.smartTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartTabControl1.Location = new System.Drawing.Point(0, 0);
            this.smartTabControl1.Name = "smartTabControl1";
            this.smartTabControl1.SelectedTabPage = this.LotTab;
            this.smartTabControl1.Size = new System.Drawing.Size(1267, 675);
            this.smartTabControl1.TabIndex = 0;
            this.smartTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.LotTab,
            this.MaterialTab});
            // 
            // LotTab
            // 
            this.LotTab.Controls.Add(this.grdLot);
            this.LotTab.Controls.Add(this.smartPanel1);
            this.smartTabControl1.SetLanguageKey(this.LotTab, "LOTLABEL");
            this.LotTab.Name = "LotTab";
            this.LotTab.Size = new System.Drawing.Size(1260, 639);
            this.LotTab.Text = "xtraTabPage1";
            // 
            // grdLot
            // 
            this.grdLot.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLot.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdLot.IsUsePaging = false;
            this.grdLot.LanguageKey = "GRIDLOTLIST";
            this.grdLot.Location = new System.Drawing.Point(0, 31);
            this.grdLot.Margin = new System.Windows.Forms.Padding(0);
            this.grdLot.Name = "grdLot";
            this.grdLot.ShowBorder = true;
            this.grdLot.ShowStatusBar = false;
            this.grdLot.Size = new System.Drawing.Size(1260, 608);
            this.grdLot.TabIndex = 0;
            this.grdLot.UseAutoBestFitColumns = false;
            // 
            // smartPanel1
            // 
            this.smartPanel1.Controls.Add(this.spnCopy);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(1260, 31);
            this.smartPanel1.TabIndex = 1;
            // 
            // spnCopy
            // 
            this.spnCopy.LabelText = "발행 매수";
            this.spnCopy.LanguageKey = "PRINTCOPIES";
            this.spnCopy.Location = new System.Drawing.Point(5, 5);
            this.spnCopy.Name = "spnCopy";
            this.spnCopy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnCopy.Size = new System.Drawing.Size(220, 24);
            this.spnCopy.TabIndex = 1;
            // 
            // MaterialTab
            // 
            this.MaterialTab.Controls.Add(this.grdConsumable);
            this.MaterialTab.Controls.Add(this.smartPanel2);
            this.smartTabControl1.SetLanguageKey(this.MaterialTab, "CONSUMABLELABEL");
            this.MaterialTab.Name = "MaterialTab";
            this.MaterialTab.Size = new System.Drawing.Size(1260, 639);
            this.MaterialTab.Text = "xtraTabPage2";
            // 
            // grdConsumable
            // 
            this.grdConsumable.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdConsumable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdConsumable.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdConsumable.IsUsePaging = false;
            this.grdConsumable.LanguageKey = "CONSUMABLELOTLIST";
            this.grdConsumable.Location = new System.Drawing.Point(0, 31);
            this.grdConsumable.Margin = new System.Windows.Forms.Padding(0);
            this.grdConsumable.Name = "grdConsumable";
            this.grdConsumable.ShowBorder = true;
            this.grdConsumable.ShowStatusBar = false;
            this.grdConsumable.Size = new System.Drawing.Size(1260, 608);
            this.grdConsumable.TabIndex = 1;
            this.grdConsumable.UseAutoBestFitColumns = false;
            // 
            // smartPanel2
            // 
            this.smartPanel2.Controls.Add(this.spnCopy2);
            this.smartPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel2.Location = new System.Drawing.Point(0, 0);
            this.smartPanel2.Name = "smartPanel2";
            this.smartPanel2.Size = new System.Drawing.Size(1260, 31);
            this.smartPanel2.TabIndex = 2;
            // 
            // spnCopy2
            // 
            this.spnCopy2.LabelText = "발행 매수";
            this.spnCopy2.LanguageKey = "PRINTCOPIES";
            this.spnCopy2.Location = new System.Drawing.Point(5, 5);
            this.spnCopy2.Name = "spnCopy2";
            this.spnCopy2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnCopy2.Size = new System.Drawing.Size(220, 24);
            this.spnCopy2.TabIndex = 1;
            // 
            // webService1
            // 
            this.webService1.Url = "http://localhost:8080/WebService.asmx";
            this.webService1.UseDefaultCredentials = true;
            // 
            // LabelReissue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1686, 749);
            this.Name = "LabelReissue";
            this.Padding = new System.Windows.Forms.Padding(19, 19, 19, 19);
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartTabControl1)).EndInit();
            this.smartTabControl1.ResumeLayout(false);
            this.LotTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spnCopy.Properties)).EndInit();
            this.MaterialTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            this.smartPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spnCopy2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartTabControl smartTabControl1;
        private DevExpress.XtraTab.XtraTabPage LotTab;
        private DevExpress.XtraTab.XtraTabPage MaterialTab;
        private Framework.SmartControls.SmartBandedGrid grdLot;
        private Framework.SmartControls.SmartBandedGrid grdConsumable;
        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartLabelSpinEdit spnCopy;
        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartLabelSpinEdit spnCopy2;
        private SystemManagement.SmartDeployService.WebService webService1;
    }
}
namespace Micube.SmartMES.Material
{
    partial class MaterialIn
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
            this.smartSpliterContainer1 = new Micube.Framework.SmartControls.SmartSpliterContainer();
            this.grdMaster = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartSpliterContainer2 = new Micube.Framework.SmartControls.SmartSpliterContainer();
            this.grdItem = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnScan = new Micube.Framework.SmartControls.SmartButton();
            this.smartPanel3 = new Micube.Framework.SmartControls.SmartPanel();
            this.grdLot = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnSaveLot = new Micube.Framework.SmartControls.SmartButton();
            this.smartPanel6 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnPrintLabel = new Micube.Framework.SmartControls.SmartButton();
            this.smartPanel4 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnLotCreate = new Micube.Framework.SmartControls.SmartButton();
            this.smartPanel8 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnConfirm = new Micube.Framework.SmartControls.SmartButton();
            this.btnConfirmCancel = new Micube.Framework.SmartControls.SmartButton();
            this.smartPanel5 = new Micube.Framework.SmartControls.SmartPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlToolbar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).BeginInit();
            this.smartSpliterContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer2)).BeginInit();
            this.smartSpliterContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            this.smartPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel5)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(2, 31);
            this.pnlCondition.Size = new System.Drawing.Size(296, 527);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Controls.Add(this.btnLotCreate);
            this.pnlToolbar.Controls.Add(this.smartPanel8);
            this.pnlToolbar.Controls.Add(this.btnConfirm);
            this.pnlToolbar.Controls.Add(this.smartPanel5);
            this.pnlToolbar.Controls.Add(this.btnConfirmCancel);
            this.pnlToolbar.Size = new System.Drawing.Size(1176, 24);
            this.pnlToolbar.Controls.SetChildIndex(this.btnConfirmCancel, 0);
            this.pnlToolbar.Controls.SetChildIndex(this.smartPanel5, 0);
            this.pnlToolbar.Controls.SetChildIndex(this.btnConfirm, 0);
            this.pnlToolbar.Controls.SetChildIndex(this.smartPanel8, 0);
            this.pnlToolbar.Controls.SetChildIndex(this.btnLotCreate, 0);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.smartSpliterContainer1);
            this.pnlContent.Size = new System.Drawing.Size(1176, 531);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(1481, 560);
            // 
            // smartSpliterContainer1
            // 
            this.smartSpliterContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSpliterContainer1.Horizontal = false;
            this.smartSpliterContainer1.Location = new System.Drawing.Point(0, 0);
            this.smartSpliterContainer1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterContainer1.Name = "smartSpliterContainer1";
            this.smartSpliterContainer1.Panel1.Controls.Add(this.grdMaster);
            this.smartSpliterContainer1.Panel1.Text = "Panel1";
            this.smartSpliterContainer1.Panel2.Controls.Add(this.smartSpliterContainer2);
            this.smartSpliterContainer1.Panel2.Text = "Panel2";
            this.smartSpliterContainer1.Size = new System.Drawing.Size(1176, 531);
            this.smartSpliterContainer1.SplitterPosition = 396;
            this.smartSpliterContainer1.TabIndex = 0;
            this.smartSpliterContainer1.Text = "smartSpliterContainer1";
            // 
            // grdMaster
            // 
            this.grdMaster.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMaster.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdMaster.IsUsePaging = false;
            this.grdMaster.LanguageKey = "PODELV";
            this.grdMaster.Location = new System.Drawing.Point(0, 0);
            this.grdMaster.Margin = new System.Windows.Forms.Padding(0);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ShowBorder = true;
            this.grdMaster.Size = new System.Drawing.Size(1176, 396);
            this.grdMaster.TabIndex = 0;
            this.grdMaster.UseAutoBestFitColumns = false;
            // 
            // smartSpliterContainer2
            // 
            this.smartSpliterContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSpliterContainer2.Location = new System.Drawing.Point(0, 0);
            this.smartSpliterContainer2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterContainer2.Name = "smartSpliterContainer2";
            this.smartSpliterContainer2.Panel1.Controls.Add(this.grdItem);
            this.smartSpliterContainer2.Panel1.Controls.Add(this.smartPanel1);
            this.smartSpliterContainer2.Panel1.Text = "Panel1";
            this.smartSpliterContainer2.Panel2.Controls.Add(this.grdLot);
            this.smartSpliterContainer2.Panel2.Controls.Add(this.smartPanel2);
            this.smartSpliterContainer2.Panel2.Text = "Panel2";
            this.smartSpliterContainer2.Size = new System.Drawing.Size(1176, 130);
            this.smartSpliterContainer2.SplitterPosition = 759;
            this.smartSpliterContainer2.TabIndex = 0;
            this.smartSpliterContainer2.Text = "smartSpliterContainer2";
            // 
            // grdItem
            // 
            this.grdItem.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItem.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdItem.IsUsePaging = false;
            this.grdItem.LanguageKey = "IPGOLIST";
            this.grdItem.Location = new System.Drawing.Point(0, 35);
            this.grdItem.Margin = new System.Windows.Forms.Padding(0);
            this.grdItem.Name = "grdItem";
            this.grdItem.ShowBorder = true;
            this.grdItem.Size = new System.Drawing.Size(759, 95);
            this.grdItem.TabIndex = 2;
            this.grdItem.UseAutoBestFitColumns = false;
            // 
            // smartPanel1
            // 
            this.smartPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel1.Controls.Add(this.btnScan);
            this.smartPanel1.Controls.Add(this.smartPanel3);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(759, 35);
            this.smartPanel1.TabIndex = 1;
            // 
            // btnScan
            // 
            this.btnScan.AllowFocus = false;
            this.btnScan.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnScan.IsBusy = false;
            this.btnScan.IsWrite = false;
            this.btnScan.LanguageKey = "SCAN";
            this.btnScan.Location = new System.Drawing.Point(680, 0);
            this.btnScan.Margin = new System.Windows.Forms.Padding(0);
            this.btnScan.Name = "btnScan";
            this.btnScan.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnScan.Size = new System.Drawing.Size(79, 25);
            this.btnScan.TabIndex = 7;
            this.btnScan.Text = "btnScan";
            this.btnScan.TooltipLanguageKey = "";
            // 
            // smartPanel3
            // 
            this.smartPanel3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel3.Location = new System.Drawing.Point(0, 25);
            this.smartPanel3.Name = "smartPanel3";
            this.smartPanel3.Size = new System.Drawing.Size(759, 10);
            this.smartPanel3.TabIndex = 0;
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
            this.grdLot.Location = new System.Drawing.Point(0, 35);
            this.grdLot.Margin = new System.Windows.Forms.Padding(0);
            this.grdLot.Name = "grdLot";
            this.grdLot.ShowBorder = true;
            this.grdLot.Size = new System.Drawing.Size(412, 95);
            this.grdLot.TabIndex = 2;
            this.grdLot.UseAutoBestFitColumns = false;
            // 
            // smartPanel2
            // 
            this.smartPanel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel2.Controls.Add(this.btnSaveLot);
            this.smartPanel2.Controls.Add(this.smartPanel6);
            this.smartPanel2.Controls.Add(this.btnPrintLabel);
            this.smartPanel2.Controls.Add(this.smartPanel4);
            this.smartPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel2.Location = new System.Drawing.Point(0, 0);
            this.smartPanel2.Name = "smartPanel2";
            this.smartPanel2.Size = new System.Drawing.Size(412, 35);
            this.smartPanel2.TabIndex = 1;
            // 
            // btnSaveLot
            // 
            this.btnSaveLot.AllowFocus = false;
            this.btnSaveLot.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSaveLot.IsBusy = false;
            this.btnSaveLot.IsWrite = false;
            this.btnSaveLot.LanguageKey = "CHANGECELL";
            this.btnSaveLot.Location = new System.Drawing.Point(244, 0);
            this.btnSaveLot.Margin = new System.Windows.Forms.Padding(0);
            this.btnSaveLot.Name = "btnSaveLot";
            this.btnSaveLot.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSaveLot.Size = new System.Drawing.Size(79, 25);
            this.btnSaveLot.TabIndex = 5;
            this.btnSaveLot.Text = "btnSaveLot";
            this.btnSaveLot.TooltipLanguageKey = "";
            // 
            // smartPanel6
            // 
            this.smartPanel6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.smartPanel6.Location = new System.Drawing.Point(323, 0);
            this.smartPanel6.Name = "smartPanel6";
            this.smartPanel6.Size = new System.Drawing.Size(10, 25);
            this.smartPanel6.TabIndex = 4;
            // 
            // btnPrintLabel
            // 
            this.btnPrintLabel.AllowFocus = false;
            this.btnPrintLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrintLabel.IsBusy = false;
            this.btnPrintLabel.IsWrite = false;
            this.btnPrintLabel.LanguageKey = "PRINTLABEL";
            this.btnPrintLabel.Location = new System.Drawing.Point(333, 0);
            this.btnPrintLabel.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrintLabel.Name = "btnPrintLabel";
            this.btnPrintLabel.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnPrintLabel.Size = new System.Drawing.Size(79, 25);
            this.btnPrintLabel.TabIndex = 2;
            this.btnPrintLabel.Text = "btnPrintLabel";
            this.btnPrintLabel.TooltipLanguageKey = "";
            // 
            // smartPanel4
            // 
            this.smartPanel4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel4.Location = new System.Drawing.Point(0, 25);
            this.smartPanel4.Name = "smartPanel4";
            this.smartPanel4.Size = new System.Drawing.Size(412, 10);
            this.smartPanel4.TabIndex = 0;
            // 
            // btnLotCreate
            // 
            this.btnLotCreate.AllowFocus = false;
            this.btnLotCreate.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLotCreate.IsBusy = false;
            this.btnLotCreate.IsWrite = false;
            this.btnLotCreate.LanguageKey = "IPGO";
            this.btnLotCreate.Location = new System.Drawing.Point(919, 0);
            this.btnLotCreate.Margin = new System.Windows.Forms.Padding(0);
            this.btnLotCreate.Name = "btnLotCreate";
            this.btnLotCreate.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnLotCreate.Size = new System.Drawing.Size(79, 24);
            this.btnLotCreate.TabIndex = 5;
            this.btnLotCreate.Text = "btnLotCreate";
            this.btnLotCreate.TooltipLanguageKey = "";
            // 
            // smartPanel8
            // 
            this.smartPanel8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.smartPanel8.Location = new System.Drawing.Point(998, 0);
            this.smartPanel8.Name = "smartPanel8";
            this.smartPanel8.Size = new System.Drawing.Size(10, 24);
            this.smartPanel8.TabIndex = 10;
            // 
            // btnConfirm
            // 
            this.btnConfirm.AllowFocus = false;
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnConfirm.IsBusy = false;
            this.btnConfirm.IsWrite = false;
            this.btnConfirm.LanguageKey = "IPGOCONFIRM";
            this.btnConfirm.Location = new System.Drawing.Point(1008, 0);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnConfirm.Size = new System.Drawing.Size(79, 24);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "btnConfirm";
            this.btnConfirm.TooltipLanguageKey = "";
            // 
            // btnConfirmCancel
            // 
            this.btnConfirmCancel.AllowFocus = false;
            this.btnConfirmCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnConfirmCancel.IsBusy = false;
            this.btnConfirmCancel.IsWrite = false;
            this.btnConfirmCancel.LanguageKey = "IPGOCONFIRMCANCEL";
            this.btnConfirmCancel.Location = new System.Drawing.Point(1097, 0);
            this.btnConfirmCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirmCancel.Name = "btnConfirmCancel";
            this.btnConfirmCancel.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnConfirmCancel.Size = new System.Drawing.Size(79, 24);
            this.btnConfirmCancel.TabIndex = 11;
            this.btnConfirmCancel.Text = "btnConfirmCancel";
            this.btnConfirmCancel.TooltipLanguageKey = "";
            // 
            // smartPanel5
            // 
            this.smartPanel5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.smartPanel5.Location = new System.Drawing.Point(1087, 0);
            this.smartPanel5.Name = "smartPanel5";
            this.smartPanel5.Size = new System.Drawing.Size(10, 24);
            this.smartPanel5.TabIndex = 12;
            // 
            // MaterialIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1501, 580);
            this.Name = "MaterialIn";
            this.Text = "MaterialIn";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).EndInit();
            this.smartSpliterContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer2)).EndInit();
            this.smartSpliterContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            this.smartPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer1;
        private Framework.SmartControls.SmartBandedGrid grdMaster;
        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer2;
        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartPanel smartPanel3;
        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartButton btnPrintLabel;
        private Framework.SmartControls.SmartPanel smartPanel4;
        private Framework.SmartControls.SmartBandedGrid grdItem;
        private Framework.SmartControls.SmartBandedGrid grdLot;
        private Framework.SmartControls.SmartButton btnLotCreate;
        private Framework.SmartControls.SmartButton btnSaveLot;
        private Framework.SmartControls.SmartPanel smartPanel6;
        private Framework.SmartControls.SmartButton btnScan;
        private Framework.SmartControls.SmartPanel smartPanel8;
        private Framework.SmartControls.SmartButton btnConfirm;
        private Framework.SmartControls.SmartPanel smartPanel5;
        private Framework.SmartControls.SmartButton btnConfirmCancel;
    }
}
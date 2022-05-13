namespace Micube.SmartMES.Material
{
    partial class MaterialOut
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
            this.grdItem = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnConfirm = new Micube.Framework.SmartControls.SmartButton();
            this.smartPanel3 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnScan = new Micube.Framework.SmartControls.SmartButton();
            this.smartPanel8 = new Micube.Framework.SmartControls.SmartPanel();
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnCancel = new Micube.Framework.SmartControls.SmartButton();
            this.btnReady = new Micube.Framework.SmartControls.SmartButton();
            this.btnPrint = new Micube.Framework.SmartControls.SmartButton();
            this.smartPanel4 = new Micube.Framework.SmartControls.SmartPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlToolbar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).BeginInit();
            this.smartSpliterContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel4)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(2, 31);
            this.pnlCondition.Size = new System.Drawing.Size(296, 561);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Controls.Add(this.btnReady);
            this.pnlToolbar.Controls.Add(this.smartPanel2);
            this.pnlToolbar.Controls.Add(this.btnCancel);
            this.pnlToolbar.Controls.Add(this.smartPanel8);
            this.pnlToolbar.Controls.Add(this.btnScan);
            this.pnlToolbar.Size = new System.Drawing.Size(982, 24);
            this.pnlToolbar.Controls.SetChildIndex(this.btnScan, 0);
            this.pnlToolbar.Controls.SetChildIndex(this.smartPanel8, 0);
            this.pnlToolbar.Controls.SetChildIndex(this.btnCancel, 0);
            this.pnlToolbar.Controls.SetChildIndex(this.smartPanel2, 0);
            this.pnlToolbar.Controls.SetChildIndex(this.btnReady, 0);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.smartSpliterContainer1);
            this.pnlContent.Size = new System.Drawing.Size(982, 565);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(1287, 594);
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
            this.smartSpliterContainer1.Panel2.Controls.Add(this.grdItem);
            this.smartSpliterContainer1.Panel2.Controls.Add(this.smartPanel1);
            this.smartSpliterContainer1.Panel2.Text = "Panel2";
            this.smartSpliterContainer1.Size = new System.Drawing.Size(982, 565);
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
            this.grdMaster.LanguageKey = "DELIVERYREQUEST";
            this.grdMaster.Location = new System.Drawing.Point(0, 0);
            this.grdMaster.Margin = new System.Windows.Forms.Padding(0);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ShowBorder = true;
            this.grdMaster.Size = new System.Drawing.Size(982, 396);
            this.grdMaster.TabIndex = 0;
            this.grdMaster.UseAutoBestFitColumns = false;
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
            this.grdItem.LanguageKey = "DELIVERYREADYINFO";
            this.grdItem.Location = new System.Drawing.Point(0, 35);
            this.grdItem.Margin = new System.Windows.Forms.Padding(0);
            this.grdItem.Name = "grdItem";
            this.grdItem.ShowBorder = true;
            this.grdItem.Size = new System.Drawing.Size(982, 129);
            this.grdItem.TabIndex = 6;
            this.grdItem.UseAutoBestFitColumns = false;
            // 
            // smartPanel1
            // 
            this.smartPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel1.Controls.Add(this.btnPrint);
            this.smartPanel1.Controls.Add(this.smartPanel4);
            this.smartPanel1.Controls.Add(this.btnConfirm);
            this.smartPanel1.Controls.Add(this.smartPanel3);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(982, 35);
            this.smartPanel1.TabIndex = 5;
            // 
            // btnConfirm
            // 
            this.btnConfirm.AllowFocus = false;
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnConfirm.IsBusy = false;
            this.btnConfirm.IsWrite = false;
            this.btnConfirm.LanguageKey = "DELIVERYCONFIRM";
            this.btnConfirm.Location = new System.Drawing.Point(903, 0);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnConfirm.Size = new System.Drawing.Size(79, 25);
            this.btnConfirm.TabIndex = 7;
            this.btnConfirm.Text = "btnConfirm";
            this.btnConfirm.TooltipLanguageKey = "";
            // 
            // smartPanel3
            // 
            this.smartPanel3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel3.Location = new System.Drawing.Point(0, 25);
            this.smartPanel3.Name = "smartPanel3";
            this.smartPanel3.Size = new System.Drawing.Size(982, 10);
            this.smartPanel3.TabIndex = 0;
            // 
            // btnScan
            // 
            this.btnScan.AllowFocus = false;
            this.btnScan.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnScan.IsBusy = false;
            this.btnScan.IsWrite = false;
            this.btnScan.LanguageKey = "DELIVERYREADY";
            this.btnScan.Location = new System.Drawing.Point(903, 0);
            this.btnScan.Margin = new System.Windows.Forms.Padding(0);
            this.btnScan.Name = "btnScan";
            this.btnScan.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnScan.Size = new System.Drawing.Size(79, 24);
            this.btnScan.TabIndex = 10;
            this.btnScan.Text = "btnScan";
            this.btnScan.TooltipLanguageKey = "";
            // 
            // smartPanel8
            // 
            this.smartPanel8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.smartPanel8.Location = new System.Drawing.Point(893, 0);
            this.smartPanel8.Name = "smartPanel8";
            this.smartPanel8.Size = new System.Drawing.Size(10, 24);
            this.smartPanel8.TabIndex = 11;
            // 
            // smartPanel2
            // 
            this.smartPanel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.smartPanel2.Location = new System.Drawing.Point(804, 0);
            this.smartPanel2.Name = "smartPanel2";
            this.smartPanel2.Size = new System.Drawing.Size(10, 24);
            this.smartPanel2.TabIndex = 13;
            // 
            // btnCancel
            // 
            this.btnCancel.AllowFocus = false;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.IsBusy = false;
            this.btnCancel.IsWrite = false;
            this.btnCancel.LanguageKey = "READYCANCEL";
            this.btnCancel.Location = new System.Drawing.Point(814, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnCancel.Size = new System.Drawing.Size(79, 24);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "btnCancel";
            this.btnCancel.TooltipLanguageKey = "";
            // 
            // btnReady
            // 
            this.btnReady.AllowFocus = false;
            this.btnReady.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReady.IsBusy = false;
            this.btnReady.IsWrite = false;
            this.btnReady.LanguageKey = "MATEREADY";
            this.btnReady.Location = new System.Drawing.Point(725, 0);
            this.btnReady.Margin = new System.Windows.Forms.Padding(0);
            this.btnReady.Name = "btnReady";
            this.btnReady.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnReady.Size = new System.Drawing.Size(79, 24);
            this.btnReady.TabIndex = 14;
            this.btnReady.Text = "btnReady";
            this.btnReady.TooltipLanguageKey = "";
            // 
            // btnPrint
            // 
            this.btnPrint.AllowFocus = false;
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrint.IsBusy = false;
            this.btnPrint.IsWrite = false;
            this.btnPrint.LanguageKey = "PRINTLABEL";
            this.btnPrint.Location = new System.Drawing.Point(814, 0);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnPrint.Size = new System.Drawing.Size(79, 25);
            this.btnPrint.TabIndex = 16;
            this.btnPrint.Text = "btnPrintLabel";
            this.btnPrint.TooltipLanguageKey = "";
            // 
            // smartPanel4
            // 
            this.smartPanel4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.smartPanel4.Location = new System.Drawing.Point(893, 0);
            this.smartPanel4.Name = "smartPanel4";
            this.smartPanel4.Size = new System.Drawing.Size(10, 25);
            this.smartPanel4.TabIndex = 15;
            // 
            // MaterialOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 614);
            this.Name = "MaterialOut";
            this.Text = "MaterialOut";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).EndInit();
            this.smartSpliterContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer1;
        private Framework.SmartControls.SmartBandedGrid grdMaster;
        private Framework.SmartControls.SmartButton btnScan;
        private Framework.SmartControls.SmartPanel smartPanel8;
        private Framework.SmartControls.SmartBandedGrid grdItem;
        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartPanel smartPanel3;
        private Framework.SmartControls.SmartButton btnConfirm;
        private Framework.SmartControls.SmartButton btnReady;
        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartButton btnCancel;
        private Framework.SmartControls.SmartButton btnPrint;
        private Framework.SmartControls.SmartPanel smartPanel4;
    }
}
namespace Micube.SmartMES.Material
{
    partial class MaterialOutByScanPopup
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
            this.grdInfo = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartGroupBox1 = new Micube.Framework.SmartControls.SmartGroupBox();
            this.grdLot = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.lblLotNo = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.smartPanel3 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnTempSave = new Micube.Framework.SmartControls.SmartButton();
            this.btnCancel = new Micube.Framework.SmartControls.SmartButton();
            this.btnSave = new Micube.Framework.SmartControls.SmartButton();
            this.chkAutoPrint = new Micube.Framework.SmartControls.SmartCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).BeginInit();
            this.smartSpliterContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartGroupBox1)).BeginInit();
            this.smartGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblLotNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).BeginInit();
            this.smartPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoPrint.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.smartSpliterContainer1);
            this.pnlMain.Size = new System.Drawing.Size(780, 551);
            // 
            // smartSpliterContainer1
            // 
            this.smartSpliterContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSpliterContainer1.Horizontal = false;
            this.smartSpliterContainer1.Location = new System.Drawing.Point(0, 0);
            this.smartSpliterContainer1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterContainer1.Name = "smartSpliterContainer1";
            this.smartSpliterContainer1.Panel1.Controls.Add(this.grdInfo);
            this.smartSpliterContainer1.Panel1.Text = "Panel1";
            this.smartSpliterContainer1.Panel2.Controls.Add(this.smartGroupBox1);
            this.smartSpliterContainer1.Panel2.Controls.Add(this.smartPanel3);
            this.smartSpliterContainer1.Panel2.Text = "Panel2";
            this.smartSpliterContainer1.Size = new System.Drawing.Size(780, 551);
            this.smartSpliterContainer1.SplitterPosition = 185;
            this.smartSpliterContainer1.TabIndex = 0;
            this.smartSpliterContainer1.Text = "smartSpliterContainer1";
            // 
            // grdInfo
            // 
            this.grdInfo.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInfo.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdInfo.IsUsePaging = false;
            this.grdInfo.LanguageKey = "DELIVERYREQUEST";
            this.grdInfo.Location = new System.Drawing.Point(0, 0);
            this.grdInfo.Margin = new System.Windows.Forms.Padding(0);
            this.grdInfo.Name = "grdInfo";
            this.grdInfo.ShowBorder = true;
            this.grdInfo.Size = new System.Drawing.Size(780, 185);
            this.grdInfo.TabIndex = 0;
            this.grdInfo.UseAutoBestFitColumns = false;
            // 
            // smartGroupBox1
            // 
            this.smartGroupBox1.Controls.Add(this.grdLot);
            this.smartGroupBox1.Controls.Add(this.smartPanel1);
            this.smartGroupBox1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.smartGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartGroupBox1.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.smartGroupBox1.LanguageKey = "SELECTLOTNO";
            this.smartGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.smartGroupBox1.Name = "smartGroupBox1";
            this.smartGroupBox1.ShowBorder = true;
            this.smartGroupBox1.Size = new System.Drawing.Size(780, 329);
            this.smartGroupBox1.TabIndex = 7;
            this.smartGroupBox1.Text = "smartGroupBox1";
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
            this.grdLot.LanguageKey = "DELIVERYREADYINFO";
            this.grdLot.Location = new System.Drawing.Point(2, 63);
            this.grdLot.Margin = new System.Windows.Forms.Padding(0);
            this.grdLot.Name = "grdLot";
            this.grdLot.ShowBorder = true;
            this.grdLot.Size = new System.Drawing.Size(776, 264);
            this.grdLot.TabIndex = 1;
            this.grdLot.UseAutoBestFitColumns = false;
            // 
            // smartPanel1
            // 
            this.smartPanel1.Controls.Add(this.chkAutoPrint);
            this.smartPanel1.Controls.Add(this.lblLotNo);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel1.Location = new System.Drawing.Point(2, 31);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(776, 32);
            this.smartPanel1.TabIndex = 0;
            // 
            // lblLotNo
            // 
            this.lblLotNo.LabelText = "LOTNO";
            this.lblLotNo.LabelWidth = "10%";
            this.lblLotNo.LanguageKey = "LOTNO";
            this.lblLotNo.Location = new System.Drawing.Point(5, 5);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(519, 20);
            this.lblLotNo.TabIndex = 3;
            // 
            // smartPanel3
            // 
            this.smartPanel3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel3.Controls.Add(this.btnTempSave);
            this.smartPanel3.Controls.Add(this.btnCancel);
            this.smartPanel3.Controls.Add(this.btnSave);
            this.smartPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel3.Location = new System.Drawing.Point(0, 329);
            this.smartPanel3.Name = "smartPanel3";
            this.smartPanel3.Size = new System.Drawing.Size(780, 32);
            this.smartPanel3.TabIndex = 6;
            // 
            // btnTempSave
            // 
            this.btnTempSave.AllowFocus = false;
            this.btnTempSave.IsBusy = false;
            this.btnTempSave.IsWrite = false;
            this.btnTempSave.LanguageKey = "TEMPSAVE";
            this.btnTempSave.Location = new System.Drawing.Point(528, 7);
            this.btnTempSave.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnTempSave.Name = "btnTempSave";
            this.btnTempSave.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnTempSave.Size = new System.Drawing.Size(80, 25);
            this.btnTempSave.TabIndex = 2;
            this.btnTempSave.Text = "btnTempSave";
            this.btnTempSave.TooltipLanguageKey = "";
            // 
            // btnCancel
            // 
            this.btnCancel.AllowFocus = false;
            this.btnCancel.IsBusy = false;
            this.btnCancel.IsWrite = false;
            this.btnCancel.LanguageKey = "CANCEL";
            this.btnCancel.Location = new System.Drawing.Point(700, 7);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "btnCancel";
            this.btnCancel.TooltipLanguageKey = "";
            // 
            // btnSave
            // 
            this.btnSave.AllowFocus = false;
            this.btnSave.IsBusy = false;
            this.btnSave.IsWrite = false;
            this.btnSave.LanguageKey = "SAVE";
            this.btnSave.Location = new System.Drawing.Point(614, 7);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "btnSave";
            this.btnSave.TooltipLanguageKey = "";
            // 
            // chkAutoPrint
            // 
            this.chkAutoPrint.LanguageKey = "SPLITLOTAUTOPRINT";
            this.chkAutoPrint.Location = new System.Drawing.Point(582, 6);
            this.chkAutoPrint.Name = "chkAutoPrint";
            this.chkAutoPrint.Properties.Caption = "smartCheckBox1";
            this.chkAutoPrint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkAutoPrint.Size = new System.Drawing.Size(189, 19);
            this.chkAutoPrint.TabIndex = 4;
            // 
            // MaterialOutByScanPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 571);
            this.LanguageKey = "MATERIALDELVREADY";
            this.Name = "MaterialOutByScanPopup";
            this.Text = "MaterialOutByScanPopup";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).EndInit();
            this.smartSpliterContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartGroupBox1)).EndInit();
            this.smartGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblLotNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).EndInit();
            this.smartPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoPrint.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer1;
        private Framework.SmartControls.SmartBandedGrid grdInfo;
        private Framework.SmartControls.SmartGroupBox smartGroupBox1;
        private Framework.SmartControls.SmartPanel smartPanel3;
        private Framework.SmartControls.SmartButton btnTempSave;
        private Framework.SmartControls.SmartButton btnCancel;
        private Framework.SmartControls.SmartButton btnSave;
        private Framework.SmartControls.SmartBandedGrid grdLot;
        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartLabelTextBox lblLotNo;
        private Framework.SmartControls.SmartCheckBox chkAutoPrint;
    }
}
namespace Micube.SmartMES.Process
{
    partial class CheckMeasureYPopup
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
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            this.smartLabel1 = new Micube.Framework.SmartControls.SmartLabel();
            this.smartLabel2 = new Micube.Framework.SmartControls.SmartLabel();
            this.txtLotNum = new Micube.Framework.SmartControls.SmartTextBox();
            this.txtProductName = new Micube.Framework.SmartControls.SmartTextBox();
            this.smartLabel3 = new Micube.Framework.SmartControls.SmartLabel();
            this.txtSubProcess = new Micube.Framework.SmartControls.SmartTextBox();
            this.smartLabel4 = new Micube.Framework.SmartControls.SmartLabel();
            this.txtModel = new Micube.Framework.SmartControls.SmartTextBox();
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnClose = new Micube.Framework.SmartControls.SmartButton();
            this.btnSave = new Micube.Framework.SmartControls.SmartButton();
            this.grdResult = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            this.smartPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubProcess.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grdResult);
            this.pnlMain.Controls.Add(this.smartPanel1);
            this.pnlMain.Controls.Add(this.smartPanel2);
            this.pnlMain.Size = new System.Drawing.Size(1238, 603);
            // 
            // smartPanel2
            // 
            this.smartPanel2.Controls.Add(this.smartLabel1);
            this.smartPanel2.Controls.Add(this.smartLabel2);
            this.smartPanel2.Controls.Add(this.txtLotNum);
            this.smartPanel2.Controls.Add(this.txtProductName);
            this.smartPanel2.Controls.Add(this.smartLabel3);
            this.smartPanel2.Controls.Add(this.txtSubProcess);
            this.smartPanel2.Controls.Add(this.smartLabel4);
            this.smartPanel2.Controls.Add(this.txtModel);
            this.smartPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel2.Location = new System.Drawing.Point(0, 0);
            this.smartPanel2.Name = "smartPanel2";
            this.smartPanel2.Size = new System.Drawing.Size(1238, 41);
            this.smartPanel2.TabIndex = 2;
            // 
            // smartLabel1
            // 
            this.smartLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.smartLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.smartLabel1.Appearance.Options.UseFont = true;
            this.smartLabel1.LanguageKey = "LOTID";
            this.smartLabel1.Location = new System.Drawing.Point(12, 11);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Size = new System.Drawing.Size(58, 19);
            this.smartLabel1.TabIndex = 8;
            this.smartLabel1.Text = "LOT번호";
            // 
            // smartLabel2
            // 
            this.smartLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.smartLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.smartLabel2.Appearance.Options.UseFont = true;
            this.smartLabel2.LanguageKey = "PRODUCTDEFNAME";
            this.smartLabel2.Location = new System.Drawing.Point(309, 11);
            this.smartLabel2.Name = "smartLabel2";
            this.smartLabel2.Size = new System.Drawing.Size(42, 19);
            this.smartLabel2.TabIndex = 9;
            this.smartLabel2.Text = "품목명";
            // 
            // txtLotNum
            // 
            this.txtLotNum.LabelText = null;
            this.txtLotNum.LanguageKey = null;
            this.txtLotNum.Location = new System.Drawing.Point(105, 9);
            this.txtLotNum.Name = "txtLotNum";
            this.txtLotNum.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtLotNum.Properties.Appearance.Options.UseFont = true;
            this.txtLotNum.Properties.ReadOnly = true;
            this.txtLotNum.Properties.UseReadOnlyAppearance = false;
            this.txtLotNum.Size = new System.Drawing.Size(169, 24);
            this.txtLotNum.TabIndex = 10;
            // 
            // txtProductName
            // 
            this.txtProductName.LabelText = null;
            this.txtProductName.LanguageKey = null;
            this.txtProductName.Location = new System.Drawing.Point(390, 9);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtProductName.Properties.Appearance.Options.UseFont = true;
            this.txtProductName.Properties.ReadOnly = true;
            this.txtProductName.Properties.UseReadOnlyAppearance = false;
            this.txtProductName.Size = new System.Drawing.Size(250, 24);
            this.txtProductName.TabIndex = 11;
            // 
            // smartLabel3
            // 
            this.smartLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.smartLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.smartLabel3.Appearance.Options.UseFont = true;
            this.smartLabel3.LanguageKey = "SUBPROCESSSEGMENTNAME";
            this.smartLabel3.Location = new System.Drawing.Point(681, 11);
            this.smartLabel3.Name = "smartLabel3";
            this.smartLabel3.Size = new System.Drawing.Size(57, 19);
            this.smartLabel3.TabIndex = 12;
            this.smartLabel3.Text = "SUB공정";
            // 
            // txtSubProcess
            // 
            this.txtSubProcess.LabelText = null;
            this.txtSubProcess.LanguageKey = null;
            this.txtSubProcess.Location = new System.Drawing.Point(767, 9);
            this.txtSubProcess.Name = "txtSubProcess";
            this.txtSubProcess.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtSubProcess.Properties.Appearance.Options.UseFont = true;
            this.txtSubProcess.Properties.ReadOnly = true;
            this.txtSubProcess.Properties.UseReadOnlyAppearance = false;
            this.txtSubProcess.Size = new System.Drawing.Size(207, 24);
            this.txtSubProcess.TabIndex = 13;
            // 
            // smartLabel4
            // 
            this.smartLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.smartLabel4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.smartLabel4.Appearance.Options.UseFont = true;
            this.smartLabel4.LanguageKey = "MODEL";
            this.smartLabel4.Location = new System.Drawing.Point(1018, 11);
            this.smartLabel4.Name = "smartLabel4";
            this.smartLabel4.Size = new System.Drawing.Size(28, 19);
            this.smartLabel4.TabIndex = 14;
            this.smartLabel4.Text = "기종";
            // 
            // txtModel
            // 
            this.txtModel.LabelText = null;
            this.txtModel.LanguageKey = null;
            this.txtModel.Location = new System.Drawing.Point(1085, 9);
            this.txtModel.Name = "txtModel";
            this.txtModel.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtModel.Properties.Appearance.Options.UseFont = true;
            this.txtModel.Properties.ReadOnly = true;
            this.txtModel.Properties.UseReadOnlyAppearance = false;
            this.txtModel.Size = new System.Drawing.Size(125, 24);
            this.txtModel.TabIndex = 15;
            // 
            // smartPanel1
            // 
            this.smartPanel1.Controls.Add(this.btnClose);
            this.smartPanel1.Controls.Add(this.btnSave);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel1.Location = new System.Drawing.Point(0, 546);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(1238, 57);
            this.smartPanel1.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.AllowFocus = false;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.IsBusy = false;
            this.btnClose.IsWrite = false;
            this.btnClose.LanguageKey = "CLOSE";
            this.btnClose.Location = new System.Drawing.Point(1068, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnClose.Size = new System.Drawing.Size(160, 39);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TooltipLanguageKey = "";
            // 
            // btnSave
            // 
            this.btnSave.AllowFocus = false;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.IsBusy = false;
            this.btnSave.IsWrite = false;
            this.btnSave.LanguageKey = "SAVE";
            this.btnSave.Location = new System.Drawing.Point(902, 9);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSave.Size = new System.Drawing.Size(160, 39);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "SAVE";
            this.btnSave.TooltipLanguageKey = "";
            // 
            // grdResult
            // 
            this.grdResult.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResult.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdResult.IsUsePaging = false;
            this.grdResult.LanguageKey = "SUBPROCESSCHECKRESULT";
            this.grdResult.Location = new System.Drawing.Point(0, 41);
            this.grdResult.Margin = new System.Windows.Forms.Padding(0);
            this.grdResult.Name = "grdResult";
            this.grdResult.ShowBorder = true;
            this.grdResult.Size = new System.Drawing.Size(1238, 505);
            this.grdResult.TabIndex = 4;
            this.grdResult.UseAutoBestFitColumns = false;
            // 
            // CheckMeasureYPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 623);
            this.DoubleBuffered = true;
            this.LanguageKey = "SUBPROCESSCHECKRESULT";
            this.Name = "CheckMeasureYPopup";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            this.smartPanel2.ResumeLayout(false);
            this.smartPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubProcess.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartButton btnClose;
        private Framework.SmartControls.SmartButton btnSave;
        private Framework.SmartControls.SmartBandedGrid grdResult;
        private Framework.SmartControls.SmartLabel smartLabel1;
        private Framework.SmartControls.SmartLabel smartLabel2;
        private Framework.SmartControls.SmartTextBox txtLotNum;
        private Framework.SmartControls.SmartTextBox txtProductName;
        private Framework.SmartControls.SmartLabel smartLabel3;
        private Framework.SmartControls.SmartTextBox txtSubProcess;
        private Framework.SmartControls.SmartLabel smartLabel4;
        private Framework.SmartControls.SmartTextBox txtModel;
    }
}
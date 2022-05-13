namespace Micube.SmartMES.Process
{
    partial class CheckMeasureNPopup
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
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnClose = new Micube.Framework.SmartControls.SmartButton();
            this.btnSave = new Micube.Framework.SmartControls.SmartButton();
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            this.smartLabel1 = new Micube.Framework.SmartControls.SmartLabel();
            this.smartLabel2 = new Micube.Framework.SmartControls.SmartLabel();
            this.txtSpecName = new Micube.Framework.SmartControls.SmartTextBox();
            this.txtSubProcessName = new Micube.Framework.SmartControls.SmartTextBox();
            this.grdResult = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            this.smartPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpecName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubProcessName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grdResult);
            this.pnlMain.Controls.Add(this.smartPanel2);
            this.pnlMain.Controls.Add(this.smartPanel1);
            // 
            // smartPanel1
            // 
            this.smartPanel1.Controls.Add(this.btnClose);
            this.smartPanel1.Controls.Add(this.btnSave);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel1.Location = new System.Drawing.Point(0, 376);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(780, 54);
            this.smartPanel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.AllowFocus = false;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.IsBusy = false;
            this.btnClose.IsWrite = false;
            this.btnClose.LanguageKey = "CLOSE";
            this.btnClose.Location = new System.Drawing.Point(609, 7);
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
            this.btnSave.Location = new System.Drawing.Point(443, 7);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSave.Size = new System.Drawing.Size(160, 39);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "SAVE";
            this.btnSave.TooltipLanguageKey = "";
            // 
            // smartPanel2
            // 
            this.smartPanel2.Controls.Add(this.smartLabel1);
            this.smartPanel2.Controls.Add(this.smartLabel2);
            this.smartPanel2.Controls.Add(this.txtSpecName);
            this.smartPanel2.Controls.Add(this.txtSubProcessName);
            this.smartPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel2.Location = new System.Drawing.Point(0, 0);
            this.smartPanel2.Name = "smartPanel2";
            this.smartPanel2.Size = new System.Drawing.Size(780, 34);
            this.smartPanel2.TabIndex = 1;
            // 
            // smartLabel1
            // 
            this.smartLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.smartLabel1.Appearance.Options.UseFont = true;
            this.smartLabel1.LanguageKey = "SPECDEFNAME";
            this.smartLabel1.Location = new System.Drawing.Point(15, 7);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Size = new System.Drawing.Size(28, 19);
            this.smartLabel1.TabIndex = 4;
            this.smartLabel1.Text = "스펙";
            // 
            // smartLabel2
            // 
            this.smartLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.smartLabel2.Appearance.Options.UseFont = true;
            this.smartLabel2.LanguageKey = "SUBPROCESSSEGMENTNAME";
            this.smartLabel2.Location = new System.Drawing.Point(365, 8);
            this.smartLabel2.Name = "smartLabel2";
            this.smartLabel2.Size = new System.Drawing.Size(52, 18);
            this.smartLabel2.TabIndex = 5;
            this.smartLabel2.Text = "세부공정";
            // 
            // txtSpecName
            // 
            this.txtSpecName.LabelText = null;
            this.txtSpecName.LanguageKey = null;
            this.txtSpecName.Location = new System.Drawing.Point(105, 5);
            this.txtSpecName.Name = "txtSpecName";
            this.txtSpecName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtSpecName.Properties.Appearance.Options.UseFont = true;
            this.txtSpecName.Properties.ReadOnly = true;
            this.txtSpecName.Properties.UseReadOnlyAppearance = false;
            this.txtSpecName.Size = new System.Drawing.Size(207, 24);
            this.txtSpecName.TabIndex = 6;
            // 
            // txtSubProcessName
            // 
            this.txtSubProcessName.LabelText = null;
            this.txtSubProcessName.LanguageKey = null;
            this.txtSubProcessName.Location = new System.Drawing.Point(455, 5);
            this.txtSubProcessName.Name = "txtSubProcessName";
            this.txtSubProcessName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtSubProcessName.Properties.Appearance.Options.UseFont = true;
            this.txtSubProcessName.Properties.ReadOnly = true;
            this.txtSubProcessName.Properties.UseReadOnlyAppearance = false;
            this.txtSubProcessName.Size = new System.Drawing.Size(207, 24);
            this.txtSubProcessName.TabIndex = 7;
            // 
            // grdResult
            // 
            this.grdResult.Caption = "공정실적";
            this.grdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResult.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdResult.IsUsePaging = false;
            this.grdResult.LanguageKey = "SUBPROCESSRESULT";
            this.grdResult.Location = new System.Drawing.Point(0, 34);
            this.grdResult.Margin = new System.Windows.Forms.Padding(0);
            this.grdResult.Name = "grdResult";
            this.grdResult.ShowBorder = true;
            this.grdResult.Size = new System.Drawing.Size(780, 342);
            this.grdResult.TabIndex = 2;
            this.grdResult.UseAutoBestFitColumns = false;
            // 
            // CheckMeasureNPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.DoubleBuffered = true;
            this.LanguageKey = "SUBPROCESSRESULT";
            this.Name = "CheckMeasureNPopup";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            this.smartPanel2.ResumeLayout(false);
            this.smartPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpecName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubProcessName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartBandedGrid grdResult;
        private Framework.SmartControls.SmartButton btnClose;
        private Framework.SmartControls.SmartButton btnSave;
        private Framework.SmartControls.SmartLabel smartLabel1;
        private Framework.SmartControls.SmartLabel smartLabel2;
        private Framework.SmartControls.SmartTextBox txtSpecName;
        private Framework.SmartControls.SmartTextBox txtSubProcessName;
    }
}
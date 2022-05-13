namespace Micube.SmartMES.Process
{
    partial class DryerResult_Popup
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
            this.grdInputLot = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnSave = new Micube.Framework.SmartControls.SmartButton();
            this.btnClose = new Micube.Framework.SmartControls.SmartButton();
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            this.txtEquipmentName = new Micube.Framework.SmartControls.SmartTextBox();
            this.txtEquipmentId = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.txtInputLot = new Micube.Framework.SmartControls.SmartLabelTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            this.smartPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEquipmentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEquipmentId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInputLot.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grdInputLot);
            this.pnlMain.Controls.Add(this.smartPanel2);
            this.pnlMain.Controls.Add(this.smartPanel1);
            this.pnlMain.Size = new System.Drawing.Size(747, 430);
            // 
            // grdInputLot
            // 
            this.grdInputLot.Caption = "투입 품목 LOT";
            this.grdInputLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInputLot.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdInputLot.IsUsePaging = false;
            this.grdInputLot.LanguageKey = "INPUTLOTINFO";
            this.grdInputLot.Location = new System.Drawing.Point(0, 57);
            this.grdInputLot.Margin = new System.Windows.Forms.Padding(0);
            this.grdInputLot.Name = "grdInputLot";
            this.grdInputLot.ShowBorder = true;
            this.grdInputLot.Size = new System.Drawing.Size(747, 335);
            this.grdInputLot.TabIndex = 9;
            this.grdInputLot.UseAutoBestFitColumns = false;
            // 
            // smartPanel1
            // 
            this.smartPanel1.Controls.Add(this.btnSave);
            this.smartPanel1.Controls.Add(this.btnClose);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel1.Location = new System.Drawing.Point(0, 392);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(747, 38);
            this.smartPanel1.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.AllowFocus = false;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.IsBusy = false;
            this.btnSave.IsWrite = false;
            this.btnSave.LanguageKey = "SAVE";
            this.btnSave.Location = new System.Drawing.Point(576, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "저장";
            this.btnSave.TooltipLanguageKey = "";
            // 
            // btnClose
            // 
            this.btnClose.AllowFocus = false;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.IsBusy = false;
            this.btnClose.IsWrite = false;
            this.btnClose.LanguageKey = "CLOSE";
            this.btnClose.Location = new System.Drawing.Point(662, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "닫기";
            this.btnClose.TooltipLanguageKey = "";
            // 
            // smartPanel2
            // 
            this.smartPanel2.Controls.Add(this.txtEquipmentName);
            this.smartPanel2.Controls.Add(this.txtEquipmentId);
            this.smartPanel2.Controls.Add(this.txtInputLot);
            this.smartPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel2.Location = new System.Drawing.Point(0, 0);
            this.smartPanel2.Name = "smartPanel2";
            this.smartPanel2.Size = new System.Drawing.Size(747, 57);
            this.smartPanel2.TabIndex = 11;
            // 
            // txtEquipmentName
            // 
            this.txtEquipmentName.LabelText = null;
            this.txtEquipmentName.LanguageKey = null;
            this.txtEquipmentName.Location = new System.Drawing.Point(260, 5);
            this.txtEquipmentName.Name = "txtEquipmentName";
            this.txtEquipmentName.Properties.ReadOnly = true;
            this.txtEquipmentName.Size = new System.Drawing.Size(221, 20);
            this.txtEquipmentName.TabIndex = 2;
            // 
            // txtEquipmentId
            // 
            this.txtEquipmentId.LabelText = "건조기";
            this.txtEquipmentId.LabelWidth = "20%";
            this.txtEquipmentId.LanguageKey = "DRYER";
            this.txtEquipmentId.Location = new System.Drawing.Point(5, 5);
            this.txtEquipmentId.Name = "txtEquipmentId";
            this.txtEquipmentId.Properties.ReadOnly = true;
            this.txtEquipmentId.Size = new System.Drawing.Size(249, 20);
            this.txtEquipmentId.TabIndex = 1;
            // 
            // txtInputLot
            // 
            this.txtInputLot.LabelText = "투입LOT";
            this.txtInputLot.LabelWidth = "20%";
            this.txtInputLot.LanguageKey = "INPUTLOT";
            this.txtInputLot.Location = new System.Drawing.Point(5, 31);
            this.txtInputLot.Name = "txtInputLot";
            this.txtInputLot.Size = new System.Drawing.Size(249, 20);
            this.txtInputLot.TabIndex = 0;
            // 
            // DryerResult_Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 450);
            this.Name = "DryerResult_Popup";
            this.Text = "자재투입";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            this.smartPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEquipmentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEquipmentId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInputLot.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Framework.SmartControls.SmartBandedGrid grdInputLot;
        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartButton btnSave;
        private Framework.SmartControls.SmartButton btnClose;
        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartLabelTextBox txtInputLot;
        private Framework.SmartControls.SmartTextBox txtEquipmentName;
        private Framework.SmartControls.SmartLabelTextBox txtEquipmentId;
    }
}

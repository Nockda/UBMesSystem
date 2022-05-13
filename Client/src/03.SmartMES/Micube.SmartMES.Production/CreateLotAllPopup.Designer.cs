namespace Micube.SmartMES.Production
{
    partial class CreateLotAllPopup
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
            this.lblRealorderQty = new Micube.Framework.SmartControls.SmartLabelSpinEdit();
            this.btnCancel = new Micube.Framework.SmartControls.SmartButton();
            this.btnSave = new Micube.Framework.SmartControls.SmartButton();
            this.lblItemId = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.lblItemName = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.lblLotSize = new Micube.Framework.SmartControls.SmartLabelSpinEdit();
            this.lblWorkorderQty = new Micube.Framework.SmartControls.SmartLabelSpinEdit();
            this.lblCreateQty = new Micube.Framework.SmartControls.SmartLabelSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblRealorderQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLotSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWorkorderQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCreateQty.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblCreateQty);
            this.pnlMain.Controls.Add(this.lblWorkorderQty);
            this.pnlMain.Controls.Add(this.lblLotSize);
            this.pnlMain.Controls.Add(this.lblItemName);
            this.pnlMain.Controls.Add(this.lblItemId);
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.lblRealorderQty);
            this.pnlMain.Size = new System.Drawing.Size(316, 238);
            // 
            // lblRealorderQty
            // 
            this.lblRealorderQty.LabelText = "REALORDERQTY";
            this.lblRealorderQty.LanguageKey = "REALORDERQTY";
            this.lblRealorderQty.Location = new System.Drawing.Point(3, 102);
            this.lblRealorderQty.Name = "lblRealorderQty";
            this.lblRealorderQty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lblRealorderQty.Size = new System.Drawing.Size(305, 20);
            this.lblRealorderQty.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.AllowFocus = false;
            this.btnCancel.IsBusy = false;
            this.btnCancel.IsWrite = false;
            this.btnCancel.LanguageKey = "CANCEL";
            this.btnCancel.Location = new System.Drawing.Point(161, 197);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "btnCancel";
            this.btnCancel.TooltipLanguageKey = "";
            // 
            // btnSave
            // 
            this.btnSave.AllowFocus = false;
            this.btnSave.IsBusy = false;
            this.btnSave.IsWrite = false;
            this.btnSave.LanguageKey = "SAVE";
            this.btnSave.Location = new System.Drawing.Point(75, 197);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "btnSave";
            this.btnSave.TooltipLanguageKey = "";
            // 
            // lblItemId
            // 
            this.lblItemId.LabelText = "ITEMID";
            this.lblItemId.LanguageKey = "ITEMID";
            this.lblItemId.Location = new System.Drawing.Point(3, 3);
            this.lblItemId.Name = "lblItemId";
            this.lblItemId.Size = new System.Drawing.Size(305, 20);
            this.lblItemId.TabIndex = 10;
            // 
            // lblItemName
            // 
            this.lblItemName.LabelText = "ITEMNAME";
            this.lblItemName.LanguageKey = "ITEMNAME";
            this.lblItemName.Location = new System.Drawing.Point(3, 29);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(305, 20);
            this.lblItemName.TabIndex = 11;
            // 
            // lblLotSize
            // 
            this.lblLotSize.LabelText = "LOTSIZE";
            this.lblLotSize.LanguageKey = "LOTSIZE";
            this.lblLotSize.Location = new System.Drawing.Point(3, 128);
            this.lblLotSize.Name = "lblLotSize";
            this.lblLotSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lblLotSize.Size = new System.Drawing.Size(305, 20);
            this.lblLotSize.TabIndex = 12;
            // 
            // lblWorkorderQty
            // 
            this.lblWorkorderQty.LabelText = "WORKORDERQTY";
            this.lblWorkorderQty.LanguageKey = "WORKORDERQTY";
            this.lblWorkorderQty.Location = new System.Drawing.Point(3, 75);
            this.lblWorkorderQty.Name = "lblWorkorderQty";
            this.lblWorkorderQty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lblWorkorderQty.Size = new System.Drawing.Size(305, 20);
            this.lblWorkorderQty.TabIndex = 13;
            // 
            // lblCreateQty
            // 
            this.lblCreateQty.LabelText = "CREATEQTY";
            this.lblCreateQty.LanguageKey = "CREATEQTY";
            this.lblCreateQty.Location = new System.Drawing.Point(3, 154);
            this.lblCreateQty.Name = "lblCreateQty";
            this.lblCreateQty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lblCreateQty.Size = new System.Drawing.Size(305, 20);
            this.lblCreateQty.TabIndex = 14;
            // 
            // CreateLotAllPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 258);
            this.Name = "CreateLotAllPopup";
            this.Text = "CreateLotAllPopup";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblRealorderQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLotSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWorkorderQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCreateQty.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.SmartControls.SmartLabelSpinEdit lblRealorderQty;
        private Framework.SmartControls.SmartButton btnCancel;
        private Framework.SmartControls.SmartButton btnSave;
        private Framework.SmartControls.SmartLabelSpinEdit lblCreateQty;
        private Framework.SmartControls.SmartLabelSpinEdit lblWorkorderQty;
        private Framework.SmartControls.SmartLabelSpinEdit lblLotSize;
        private Framework.SmartControls.SmartLabelTextBox lblItemName;
        private Framework.SmartControls.SmartLabelTextBox lblItemId;
    }
}
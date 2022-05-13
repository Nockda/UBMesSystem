namespace Micube.SmartMES.Material
{
    partial class EtcInPopup
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
            this.lblType = new Micube.Framework.SmartControls.SmartLabelComboBox();
            this.lblWarehouseId = new Micube.Framework.SmartControls.SmartLabelComboBox();
            this.lblLocationId = new Micube.Framework.SmartControls.SmartLabelComboBox();
            this.lblQty = new Micube.Framework.SmartControls.SmartLabelSpinEdit();
            this.smartLabel1 = new Micube.Framework.SmartControls.SmartLabel();
            this.smartPanel3 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnCancel = new Micube.Framework.SmartControls.SmartButton();
            this.btnSave = new Micube.Framework.SmartControls.SmartButton();
            this.lblItemId = new Micube.Framework.SmartControls.SmartLabelSelectPopupEdit();
            this.lblItemName = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.lblDescription = new Micube.Framework.SmartControls.SmartMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWarehouseId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLocationId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).BeginInit();
            this.smartPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblDescription);
            this.pnlMain.Controls.Add(this.lblItemName);
            this.pnlMain.Controls.Add(this.lblItemId);
            this.pnlMain.Controls.Add(this.smartPanel3);
            this.pnlMain.Controls.Add(this.smartLabel1);
            this.pnlMain.Controls.Add(this.lblQty);
            this.pnlMain.Controls.Add(this.lblLocationId);
            this.pnlMain.Controls.Add(this.lblWarehouseId);
            this.pnlMain.Controls.Add(this.lblType);
            this.pnlMain.Size = new System.Drawing.Size(305, 304);
            // 
            // lblType
            // 
            this.lblType.LabelText = "INTYPE";
            this.lblType.LanguageKey = "INTYPE";
            this.lblType.Location = new System.Drawing.Point(0, 59);
            this.lblType.Name = "lblType";
            this.lblType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lblType.Properties.NullText = "";
            this.lblType.Size = new System.Drawing.Size(305, 20);
            this.lblType.TabIndex = 3;
            // 
            // lblWarehouseId
            // 
            this.lblWarehouseId.LabelText = "WAREHOUSEID";
            this.lblWarehouseId.LanguageKey = "WAREHOUSENAME";
            this.lblWarehouseId.Location = new System.Drawing.Point(0, 85);
            this.lblWarehouseId.Name = "lblWarehouseId";
            this.lblWarehouseId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lblWarehouseId.Properties.NullText = "";
            this.lblWarehouseId.Size = new System.Drawing.Size(305, 20);
            this.lblWarehouseId.TabIndex = 4;
            // 
            // lblLocationId
            // 
            this.lblLocationId.LabelText = "LOCATIONID";
            this.lblLocationId.LanguageKey = "CELLNAME";
            this.lblLocationId.Location = new System.Drawing.Point(0, 112);
            this.lblLocationId.Name = "lblLocationId";
            this.lblLocationId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lblLocationId.Properties.NullText = "";
            this.lblLocationId.Size = new System.Drawing.Size(305, 20);
            this.lblLocationId.TabIndex = 5;
            // 
            // lblQty
            // 
            this.lblQty.LabelText = "QTY";
            this.lblQty.LanguageKey = "QTY";
            this.lblQty.Location = new System.Drawing.Point(0, 139);
            this.lblQty.Name = "lblQty";
            this.lblQty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lblQty.Size = new System.Drawing.Size(305, 20);
            this.lblQty.TabIndex = 6;
            // 
            // smartLabel1
            // 
            this.smartLabel1.LanguageKey = "DESCRIPTION";
            this.smartLabel1.Location = new System.Drawing.Point(3, 179);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Size = new System.Drawing.Size(76, 14);
            this.smartLabel1.TabIndex = 6;
            this.smartLabel1.Text = "DESCRIPTION";
            // 
            // smartPanel3
            // 
            this.smartPanel3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel3.Controls.Add(this.btnCancel);
            this.smartPanel3.Controls.Add(this.btnSave);
            this.smartPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel3.Location = new System.Drawing.Point(0, 272);
            this.smartPanel3.Name = "smartPanel3";
            this.smartPanel3.Size = new System.Drawing.Size(305, 32);
            this.smartPanel3.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.AllowFocus = false;
            this.btnCancel.IsBusy = false;
            this.btnCancel.IsWrite = false;
            this.btnCancel.LanguageKey = "CANCEL";
            this.btnCancel.Location = new System.Drawing.Point(161, 7);
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
            this.btnSave.Location = new System.Drawing.Point(75, 7);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "btnSave";
            this.btnSave.TooltipLanguageKey = "";
            // 
            // lblItemId
            // 
            this.lblItemId.LabelText = "ITEMID";
            this.lblItemId.LanguageKey = "ITEMID";
            this.lblItemId.Location = new System.Drawing.Point(0, 6);
            this.lblItemId.Name = "lblItemId";
            this.lblItemId.Size = new System.Drawing.Size(305, 20);
            this.lblItemId.TabIndex = 1;
            // 
            // lblItemName
            // 
            this.lblItemName.LabelText = "ITEMNAME";
            this.lblItemName.LanguageKey = "ITEMNAME";
            this.lblItemName.Location = new System.Drawing.Point(0, 33);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(305, 20);
            this.lblItemName.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(0, 199);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(305, 67);
            this.lblDescription.TabIndex = 7;
            // 
            // EtcInPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 324);
            this.LanguageKey = "IPGO";
            this.Name = "EtcInPopup";
            this.Text = "EtcInPopup";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWarehouseId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLocationId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).EndInit();
            this.smartPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblItemId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Framework.SmartControls.SmartLabel smartLabel1;
        private Framework.SmartControls.SmartLabelSpinEdit lblQty;
        private Framework.SmartControls.SmartLabelComboBox lblLocationId;
        private Framework.SmartControls.SmartLabelComboBox lblWarehouseId;
        private Framework.SmartControls.SmartLabelComboBox lblType;
        private Framework.SmartControls.SmartPanel smartPanel3;
        private Framework.SmartControls.SmartButton btnCancel;
        private Framework.SmartControls.SmartButton btnSave;
        private Framework.SmartControls.SmartLabelSelectPopupEdit lblItemId;
        private Framework.SmartControls.SmartLabelTextBox lblItemName;
        private Framework.SmartControls.SmartMemoEdit lblDescription;
    }
}
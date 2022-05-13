namespace Micube.SmartMES.Material
{
    partial class EtcOutPopup
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
            this.smartPanel3 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnCancel = new Micube.Framework.SmartControls.SmartButton();
            this.btnSave = new Micube.Framework.SmartControls.SmartButton();
            this.smartLabel1 = new Micube.Framework.SmartControls.SmartLabel();
            this.lblLotId = new Micube.Framework.SmartControls.SmartLabelSelectPopupEdit();
            this.lblQty = new Micube.Framework.SmartControls.SmartLabelSpinEdit();
            this.lblLocationId = new Micube.Framework.SmartControls.SmartLabelComboBox();
            this.lblWarehouseId = new Micube.Framework.SmartControls.SmartLabelComboBox();
            this.lblType = new Micube.Framework.SmartControls.SmartLabelComboBox();
            this.txtLotQty = new Micube.Framework.SmartControls.SmartTextBox();
            this.smartLabel2 = new Micube.Framework.SmartControls.SmartLabel();
            this.lblItemId = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.lblItemName = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.lblDescription = new Micube.Framework.SmartControls.SmartMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).BeginInit();
            this.smartPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblLotId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLocationId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWarehouseId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotQty.Properties)).BeginInit();
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
            this.pnlMain.Controls.Add(this.smartLabel2);
            this.pnlMain.Controls.Add(this.txtLotQty);
            this.pnlMain.Controls.Add(this.lblLotId);
            this.pnlMain.Controls.Add(this.lblQty);
            this.pnlMain.Controls.Add(this.lblLocationId);
            this.pnlMain.Controls.Add(this.lblWarehouseId);
            this.pnlMain.Controls.Add(this.lblType);
            this.pnlMain.Controls.Add(this.smartLabel1);
            this.pnlMain.Controls.Add(this.smartPanel3);
            this.pnlMain.Size = new System.Drawing.Size(305, 325);
            // 
            // smartPanel3
            // 
            this.smartPanel3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel3.Controls.Add(this.btnCancel);
            this.smartPanel3.Controls.Add(this.btnSave);
            this.smartPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel3.Location = new System.Drawing.Point(0, 293);
            this.smartPanel3.Name = "smartPanel3";
            this.smartPanel3.Size = new System.Drawing.Size(305, 32);
            this.smartPanel3.TabIndex = 8;
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
            // smartLabel1
            // 
            this.smartLabel1.LanguageKey = "DESCRIPTION";
            this.smartLabel1.Location = new System.Drawing.Point(3, 202);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Size = new System.Drawing.Size(76, 14);
            this.smartLabel1.TabIndex = 10;
            this.smartLabel1.Text = "DESCRIPTION";
            // 
            // lblLotId
            // 
            this.lblLotId.LabelText = "LOTID";
            this.lblLotId.LanguageKey = "LOTID";
            this.lblLotId.Location = new System.Drawing.Point(0, 6);
            this.lblLotId.Name = "lblLotId";
            this.lblLotId.Size = new System.Drawing.Size(305, 20);
            this.lblLotId.TabIndex = 1;
            // 
            // lblQty
            // 
            this.lblQty.LabelText = "OUTQTY";
            this.lblQty.LabelWidth = "77%";
            this.lblQty.LanguageKey = "OUTQTY";
            this.lblQty.Location = new System.Drawing.Point(0, 165);
            this.lblQty.Name = "lblQty";
            this.lblQty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lblQty.Size = new System.Drawing.Size(220, 20);
            this.lblQty.TabIndex = 7;
            // 
            // lblLocationId
            // 
            this.lblLocationId.LabelText = "LOCATIONID";
            this.lblLocationId.LanguageKey = "CELLNAME";
            this.lblLocationId.Location = new System.Drawing.Point(0, 138);
            this.lblLocationId.Name = "lblLocationId";
            this.lblLocationId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lblLocationId.Properties.NullText = "";
            this.lblLocationId.Size = new System.Drawing.Size(305, 20);
            this.lblLocationId.TabIndex = 6;
            // 
            // lblWarehouseId
            // 
            this.lblWarehouseId.LabelText = "WAREHOUSEID";
            this.lblWarehouseId.LanguageKey = "WAREHOUSENAME";
            this.lblWarehouseId.Location = new System.Drawing.Point(0, 111);
            this.lblWarehouseId.Name = "lblWarehouseId";
            this.lblWarehouseId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lblWarehouseId.Properties.NullText = "";
            this.lblWarehouseId.Size = new System.Drawing.Size(305, 20);
            this.lblWarehouseId.TabIndex = 5;
            // 
            // lblType
            // 
            this.lblType.LabelText = "OUTTYPE";
            this.lblType.LanguageKey = "OUTTYPE";
            this.lblType.Location = new System.Drawing.Point(0, 85);
            this.lblType.Name = "lblType";
            this.lblType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lblType.Properties.NullText = "";
            this.lblType.Size = new System.Drawing.Size(305, 20);
            this.lblType.TabIndex = 4;
            // 
            // txtLotQty
            // 
            this.txtLotQty.LabelText = null;
            this.txtLotQty.LanguageKey = null;
            this.txtLotQty.Location = new System.Drawing.Point(240, 165);
            this.txtLotQty.Name = "txtLotQty";
            this.txtLotQty.Size = new System.Drawing.Size(65, 20);
            this.txtLotQty.TabIndex = 8;
            // 
            // smartLabel2
            // 
            this.smartLabel2.Location = new System.Drawing.Point(226, 168);
            this.smartLabel2.Name = "smartLabel2";
            this.smartLabel2.Size = new System.Drawing.Size(5, 14);
            this.smartLabel2.TabIndex = 17;
            this.smartLabel2.Text = "/";
            // 
            // lblItemId
            // 
            this.lblItemId.LabelText = "ITEMID";
            this.lblItemId.LanguageKey = "ITEMID";
            this.lblItemId.Location = new System.Drawing.Point(0, 33);
            this.lblItemId.Name = "lblItemId";
            this.lblItemId.Size = new System.Drawing.Size(305, 20);
            this.lblItemId.TabIndex = 2;
            // 
            // lblItemName
            // 
            this.lblItemName.LabelText = "ITEMNAME";
            this.lblItemName.LanguageKey = "ITEMNAME";
            this.lblItemName.Location = new System.Drawing.Point(0, 59);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(305, 20);
            this.lblItemName.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(0, 222);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(305, 67);
            this.lblDescription.TabIndex = 9;
            // 
            // EtcOutPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 345);
            this.LanguageKey = "DELIVERY";
            this.Name = "EtcOutPopup";
            this.Text = "EtcOutPopup";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).EndInit();
            this.smartPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblLotId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLocationId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWarehouseId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.SmartControls.SmartPanel smartPanel3;
        private Framework.SmartControls.SmartButton btnCancel;
        private Framework.SmartControls.SmartButton btnSave;
        private Framework.SmartControls.SmartLabel smartLabel1;
        private Framework.SmartControls.SmartLabelSelectPopupEdit lblLotId;
        private Framework.SmartControls.SmartLabelSpinEdit lblQty;
        private Framework.SmartControls.SmartLabelComboBox lblLocationId;
        private Framework.SmartControls.SmartLabelComboBox lblWarehouseId;
        private Framework.SmartControls.SmartLabelComboBox lblType;
        private Framework.SmartControls.SmartLabel smartLabel2;
        private Framework.SmartControls.SmartTextBox txtLotQty;
        private Framework.SmartControls.SmartLabelTextBox lblItemId;
        private Framework.SmartControls.SmartLabelTextBox lblItemName;
        private Framework.SmartControls.SmartMemoEdit lblDescription;
    }
}
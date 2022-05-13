namespace Micube.SmartMES.Material
{
    partial class WarehouseMovePopup
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
            this.lblFromWarehouseId = new Micube.Framework.SmartControls.SmartLabelComboBox();
            this.lblToCellId = new Micube.Framework.SmartControls.SmartLabelComboBox();
            this.lblToWarehouseId = new Micube.Framework.SmartControls.SmartLabelComboBox();
            this.lblType = new Micube.Framework.SmartControls.SmartLabelComboBox();
            this.lblDescription = new Micube.Framework.SmartControls.SmartMemoEdit();
            this.smartLabel1 = new Micube.Framework.SmartControls.SmartLabel();
            this.lblLotNo = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.grdLot = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).BeginInit();
            this.smartPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFromWarehouseId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToCellId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToWarehouseId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLotNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grdLot);
            this.pnlMain.Controls.Add(this.lblLotNo);
            this.pnlMain.Controls.Add(this.lblDescription);
            this.pnlMain.Controls.Add(this.smartLabel1);
            this.pnlMain.Controls.Add(this.lblType);
            this.pnlMain.Controls.Add(this.lblToCellId);
            this.pnlMain.Controls.Add(this.lblToWarehouseId);
            this.pnlMain.Controls.Add(this.lblFromWarehouseId);
            this.pnlMain.Controls.Add(this.smartPanel3);
            this.pnlMain.Size = new System.Drawing.Size(757, 520);
            // 
            // smartPanel3
            // 
            this.smartPanel3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel3.Controls.Add(this.btnCancel);
            this.smartPanel3.Controls.Add(this.btnSave);
            this.smartPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel3.Location = new System.Drawing.Point(0, 488);
            this.smartPanel3.Name = "smartPanel3";
            this.smartPanel3.Size = new System.Drawing.Size(757, 32);
            this.smartPanel3.TabIndex = 17;
            // 
            // btnCancel
            // 
            this.btnCancel.AllowFocus = false;
            this.btnCancel.IsBusy = false;
            this.btnCancel.IsWrite = false;
            this.btnCancel.LanguageKey = "CANCEL";
            this.btnCancel.Location = new System.Drawing.Point(395, 7);
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
            this.btnSave.Location = new System.Drawing.Point(309, 7);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "btnSave";
            this.btnSave.TooltipLanguageKey = "";
            // 
            // lblFromWarehouseId
            // 
            this.lblFromWarehouseId.LabelText = "FROMWAREHOUSEID";
            this.lblFromWarehouseId.LabelWidth = "90%";
            this.lblFromWarehouseId.LanguageKey = "FROMWAREHOUSEID";
            this.lblFromWarehouseId.Location = new System.Drawing.Point(0, 0);
            this.lblFromWarehouseId.Name = "lblFromWarehouseId";
            this.lblFromWarehouseId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lblFromWarehouseId.Properties.NullText = "";
            this.lblFromWarehouseId.Size = new System.Drawing.Size(757, 24);
            this.lblFromWarehouseId.TabIndex = 1;
            // 
            // lblToCellId
            // 
            this.lblToCellId.LabelText = "TOCELLID";
            this.lblToCellId.LabelWidth = "90%";
            this.lblToCellId.LanguageKey = "TOCELLID";
            this.lblToCellId.Location = new System.Drawing.Point(0, 342);
            this.lblToCellId.Name = "lblToCellId";
            this.lblToCellId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lblToCellId.Properties.NullText = "";
            this.lblToCellId.Size = new System.Drawing.Size(757, 24);
            this.lblToCellId.TabIndex = 25;
            // 
            // lblToWarehouseId
            // 
            this.lblToWarehouseId.LabelText = "TOWAREHOUSEID";
            this.lblToWarehouseId.LabelWidth = "90%";
            this.lblToWarehouseId.LanguageKey = "TOWAREHOUSEID";
            this.lblToWarehouseId.Location = new System.Drawing.Point(0, 315);
            this.lblToWarehouseId.Name = "lblToWarehouseId";
            this.lblToWarehouseId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lblToWarehouseId.Properties.NullText = "";
            this.lblToWarehouseId.Size = new System.Drawing.Size(757, 24);
            this.lblToWarehouseId.TabIndex = 24;
            // 
            // lblType
            // 
            this.lblType.LabelText = "MOVETYPE";
            this.lblType.LabelWidth = "90%";
            this.lblType.LanguageKey = "MOVETYPE";
            this.lblType.Location = new System.Drawing.Point(0, 368);
            this.lblType.Name = "lblType";
            this.lblType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lblType.Properties.NullText = "";
            this.lblType.Size = new System.Drawing.Size(757, 24);
            this.lblType.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(0, 416);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(757, 67);
            this.lblDescription.TabIndex = 5;
            // 
            // smartLabel1
            // 
            this.smartLabel1.LanguageKey = "DESCRIPTION";
            this.smartLabel1.Location = new System.Drawing.Point(3, 396);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Size = new System.Drawing.Size(95, 18);
            this.smartLabel1.TabIndex = 27;
            this.smartLabel1.Text = "DESCRIPTION";
            // 
            // lblLotNo
            // 
            this.lblLotNo.LabelText = "LOTNO";
            this.lblLotNo.LabelWidth = "90%";
            this.lblLotNo.LanguageKey = "LOTNO";
            this.lblLotNo.Location = new System.Drawing.Point(0, 26);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(757, 24);
            this.lblLotNo.TabIndex = 2;
            // 
            // grdLot
            // 
            this.grdLot.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdLot.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdLot.IsUsePaging = false;
            this.grdLot.LanguageKey = "MOVETARGET";
            this.grdLot.Location = new System.Drawing.Point(0, 68);
            this.grdLot.Margin = new System.Windows.Forms.Padding(0);
            this.grdLot.Name = "grdLot";
            this.grdLot.ShowBorder = true;
            this.grdLot.Size = new System.Drawing.Size(757, 232);
            this.grdLot.TabIndex = 3;
            this.grdLot.UseAutoBestFitColumns = false;
            // 
            // WarehouseMovePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 540);
            this.LanguageKey = "WAREHOUSEMOVE";
            this.Name = "WarehouseMovePopup";
            this.Text = "WarehouseMovePopup";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).EndInit();
            this.smartPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblFromWarehouseId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToCellId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToWarehouseId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLotNo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Framework.SmartControls.SmartPanel smartPanel3;
        private Framework.SmartControls.SmartButton btnCancel;
        private Framework.SmartControls.SmartButton btnSave;
        private Framework.SmartControls.SmartLabelComboBox lblToCellId;
        private Framework.SmartControls.SmartLabelComboBox lblToWarehouseId;
        private Framework.SmartControls.SmartLabelComboBox lblFromWarehouseId;
        private Framework.SmartControls.SmartLabelComboBox lblType;
        private Framework.SmartControls.SmartMemoEdit lblDescription;
        private Framework.SmartControls.SmartLabel smartLabel1;
        private Framework.SmartControls.SmartBandedGrid grdLot;
        private Framework.SmartControls.SmartLabelTextBox lblLotNo;
    }
}
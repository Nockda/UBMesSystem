namespace Micube.SmartMES.Equipment
{
    partial class EquipDailyCheckPopup
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
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            this.lblEquipmentCode = new Micube.Framework.SmartControls.SmartLabelComboBox();
            this.lblCheckDate = new Micube.Framework.SmartControls.SmartLabelDateEdit();
            this.grdList = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).BeginInit();
            this.smartPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            this.smartPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblEquipmentCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCheckDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCheckDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grdList);
            this.pnlMain.Controls.Add(this.smartPanel2);
            this.pnlMain.Controls.Add(this.smartPanel3);
            this.pnlMain.Size = new System.Drawing.Size(927, 430);
            // 
            // smartPanel3
            // 
            this.smartPanel3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel3.Controls.Add(this.btnCancel);
            this.smartPanel3.Controls.Add(this.btnSave);
            this.smartPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel3.Location = new System.Drawing.Point(0, 398);
            this.smartPanel3.Name = "smartPanel3";
            this.smartPanel3.Size = new System.Drawing.Size(927, 32);
            this.smartPanel3.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.AllowFocus = false;
            this.btnCancel.IsBusy = false;
            this.btnCancel.IsWrite = false;
            this.btnCancel.LanguageKey = "CANCEL";
            this.btnCancel.Location = new System.Drawing.Point(478, 7);
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
            this.btnSave.Location = new System.Drawing.Point(392, 7);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "btnSave";
            this.btnSave.TooltipLanguageKey = "";
            // 
            // smartPanel2
            // 
            this.smartPanel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel2.Controls.Add(this.lblEquipmentCode);
            this.smartPanel2.Controls.Add(this.lblCheckDate);
            this.smartPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel2.Location = new System.Drawing.Point(0, 0);
            this.smartPanel2.Name = "smartPanel2";
            this.smartPanel2.Size = new System.Drawing.Size(927, 25);
            this.smartPanel2.TabIndex = 10;
            // 
            // lblEquipmentCode
            // 
            this.lblEquipmentCode.LabelText = "EQUIPMENTNAME";
            this.lblEquipmentCode.LabelWidth = "20%";
            this.lblEquipmentCode.LanguageKey = "EQUIPMENTNAME";
            this.lblEquipmentCode.Location = new System.Drawing.Point(289, 0);
            this.lblEquipmentCode.Name = "lblEquipmentCode";
            this.lblEquipmentCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lblEquipmentCode.Properties.NullText = "";
            this.lblEquipmentCode.Size = new System.Drawing.Size(495, 20);
            this.lblEquipmentCode.TabIndex = 1;
            // 
            // lblCheckDate
            // 
            this.lblCheckDate.LabelText = "CHECKDATE";
            this.lblCheckDate.LanguageKey = "CHECKDATE";
            this.lblCheckDate.Location = new System.Drawing.Point(0, 0);
            this.lblCheckDate.Name = "lblCheckDate";
            this.lblCheckDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lblCheckDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lblCheckDate.Size = new System.Drawing.Size(241, 20);
            this.lblCheckDate.TabIndex = 0;
            // 
            // grdList
            // 
            this.grdList.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdList.IsUsePaging = false;
            this.grdList.LanguageKey = "EQUIPMENTCHECKINFO";
            this.grdList.Location = new System.Drawing.Point(0, 25);
            this.grdList.Margin = new System.Windows.Forms.Padding(0);
            this.grdList.Name = "grdList";
            this.grdList.ShowBorder = true;
            this.grdList.Size = new System.Drawing.Size(927, 373);
            this.grdList.TabIndex = 11;
            this.grdList.UseAutoBestFitColumns = false;
            // 
            // EquipDailyCheckPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 450);
            this.LanguageKey = "EQUIPMENTCHECKREG";
            this.Name = "EquipDailyCheckPopup";
            this.Text = "EquipDailyCheckPopup";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).EndInit();
            this.smartPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            this.smartPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblEquipmentCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCheckDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCheckDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.SmartControls.SmartPanel smartPanel3;
        private Framework.SmartControls.SmartButton btnCancel;
        private Framework.SmartControls.SmartButton btnSave;
        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartLabelDateEdit lblCheckDate;
        private Framework.SmartControls.SmartLabelComboBox lblEquipmentCode;
        private Framework.SmartControls.SmartBandedGrid grdList;
    }
}
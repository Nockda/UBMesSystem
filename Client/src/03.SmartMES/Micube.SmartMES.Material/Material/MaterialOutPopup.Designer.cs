namespace Micube.SmartMES.Material
{
    partial class MaterialOutPopup
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
            this.lblWareHouseId = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.lblReqQty = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.lblItemName = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.lblItemId = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.lblReqNo = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.lblReqDepartment = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            this.lblLotNo = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.smartPanel3 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnCancel = new Micube.Framework.SmartControls.SmartButton();
            this.btnSave = new Micube.Framework.SmartControls.SmartButton();
            this.smartSplitTableLayoutPanel1 = new Micube.Framework.SmartControls.SmartSplitTableLayoutPanel();
            this.grdTarget = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.grdSource = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.ucDataLeftRightBtnCtrl = new Micube.SmartMES.Commons.Controls.ucDataLeftRightBtn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblWareHouseId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReqQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReqNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReqDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            this.smartPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblLotNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).BeginInit();
            this.smartPanel3.SuspendLayout();
            this.smartSplitTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.smartSplitTableLayoutPanel1);
            this.pnlMain.Controls.Add(this.smartPanel3);
            this.pnlMain.Controls.Add(this.smartPanel2);
            this.pnlMain.Controls.Add(this.smartPanel1);
            this.pnlMain.Size = new System.Drawing.Size(788, 404);
            // 
            // smartPanel1
            // 
            this.smartPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel1.Controls.Add(this.lblWareHouseId);
            this.smartPanel1.Controls.Add(this.lblReqQty);
            this.smartPanel1.Controls.Add(this.lblItemName);
            this.smartPanel1.Controls.Add(this.lblItemId);
            this.smartPanel1.Controls.Add(this.lblReqNo);
            this.smartPanel1.Controls.Add(this.lblReqDepartment);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(788, 58);
            this.smartPanel1.TabIndex = 0;
            // 
            // lblWareHouseId
            // 
            //this.lblWareHouseId.CenterMargin = 10F;
            this.lblWareHouseId.Appearance.BorderColor = System.Drawing.Color.Empty;
            this.lblWareHouseId.Label.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.lblWareHouseId.LabelText = "WAREHOUSEID";
            this.lblWareHouseId.LabelWidth = "30%";
            this.lblWareHouseId.LanguageKey = "WAREHOUSEID";
            this.lblWareHouseId.Location = new System.Drawing.Point(466, 6);
            this.lblWareHouseId.Name = "lblWareHouseId";
            this.lblWareHouseId.Size = new System.Drawing.Size(186, 20);
            this.lblWareHouseId.TabIndex = 7;
            // 
            // lblReqQty
            // 
            //this.lblReqQty.CenterMargin = 10F;
            this.lblReqQty.Appearance.BorderColor = System.Drawing.Color.Empty;
            this.lblReqQty.Label.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.lblReqQty.LabelText = "REQQTY";
            this.lblReqQty.LabelWidth = "30%";
            this.lblReqQty.LanguageKey = "REQQTY";
            this.lblReqQty.Location = new System.Drawing.Point(466, 32);
            this.lblReqQty.Name = "lblReqQty";
            this.lblReqQty.Size = new System.Drawing.Size(186, 20);
            this.lblReqQty.TabIndex = 6;
            // 
            // lblItemName
            // 
            //this.lblItemName.CenterMargin = 10F;
            this.lblItemName.Appearance.BorderColor = System.Drawing.Color.Empty;
            this.lblItemName.Label.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.lblItemName.LabelText = "ITEMNAME";
            this.lblItemName.LabelWidth = "25%";
            this.lblItemName.LanguageKey = "ITEMNAME";
            this.lblItemName.Location = new System.Drawing.Point(240, 31);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(220, 20);
            this.lblItemName.TabIndex = 5;
            // 
            // lblItemId
            // 
            //this.lblItemId.CenterMargin = 10F;
            this.lblItemId.Appearance.BorderColor = System.Drawing.Color.Empty;
            this.lblItemId.Label.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.lblItemId.LabelText = "ITEMID";
            this.lblItemId.LabelWidth = "26%";
            this.lblItemId.LanguageKey = "ITEMID";
            this.lblItemId.Location = new System.Drawing.Point(5, 31);
            this.lblItemId.Name = "lblItemId";
            this.lblItemId.Size = new System.Drawing.Size(220, 20);
            this.lblItemId.TabIndex = 4;
            // 
            // lblReqNo
            // 
            //this.lblReqNo.CenterMargin = 10F;
            this.lblReqNo.Appearance.BorderColor = System.Drawing.Color.Empty;
            this.lblReqNo.Label.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.lblReqNo.LabelText = "REQNO";
            this.lblReqNo.LabelWidth = "25%";
            this.lblReqNo.LanguageKey = "REQNO";
            this.lblReqNo.Location = new System.Drawing.Point(240, 5);
            this.lblReqNo.Name = "lblReqNo";
            this.lblReqNo.Size = new System.Drawing.Size(220, 20);
            this.lblReqNo.TabIndex = 3;
            // 
            // lblReqDepartment
            // 
            //this.lblReqDepartment.CenterMargin = 10F;
            this.lblReqDepartment.Appearance.BorderColor = System.Drawing.Color.Empty;
            this.lblReqDepartment.Label.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.lblReqDepartment.LabelText = "REQDEPARTMENT";
            this.lblReqDepartment.LanguageKey = "REQDEPARTMENT";
            this.lblReqDepartment.Location = new System.Drawing.Point(5, 5);
            this.lblReqDepartment.Name = "lblReqDepartment";
            this.lblReqDepartment.Size = new System.Drawing.Size(220, 20);
            this.lblReqDepartment.TabIndex = 2;
            // 
            // smartPanel2
            // 
            this.smartPanel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel2.Controls.Add(this.lblLotNo);
            this.smartPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel2.Location = new System.Drawing.Point(0, 58);
            this.smartPanel2.Name = "smartPanel2";
            this.smartPanel2.Size = new System.Drawing.Size(788, 32);
            this.smartPanel2.TabIndex = 2;
            // 
            // lblLotNo
            // 
            //this.lblLotNo.CenterMargin = 10F;
            this.lblLotNo.Appearance.BorderColor = System.Drawing.Color.Empty;
            this.lblLotNo.Label.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.lblLotNo.LabelText = "LOTNO";
            this.lblLotNo.LabelWidth = "10%";
            this.lblLotNo.LanguageKey = "LOTNO";
            this.lblLotNo.Location = new System.Drawing.Point(5, 5);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(455, 20);
            this.lblLotNo.TabIndex = 2;
            // 
            // smartPanel3
            // 
            this.smartPanel3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel3.Controls.Add(this.btnCancel);
            this.smartPanel3.Controls.Add(this.btnSave);
            this.smartPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel3.Location = new System.Drawing.Point(0, 372);
            this.smartPanel3.Name = "smartPanel3";
            this.smartPanel3.Size = new System.Drawing.Size(788, 32);
            this.smartPanel3.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.AllowFocus = false;
            this.btnCancel.IsBusy = false;
            this.btnCancel.IsWrite = false;
            this.btnCancel.LanguageKey = "CANCEL";
            this.btnCancel.Location = new System.Drawing.Point(708, 7);
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
            this.btnSave.Location = new System.Drawing.Point(622, 7);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "btnSave";
            this.btnSave.TooltipLanguageKey = "";
            // 
            // smartSplitTableLayoutPanel1
            // 
            this.smartSplitTableLayoutPanel1.ColumnCount = 3;
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.smartSplitTableLayoutPanel1.Controls.Add(this.grdTarget, 2, 0);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.grdSource, 0, 0);
            this.smartSplitTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSplitTableLayoutPanel1.Location = new System.Drawing.Point(0, 90);
            this.smartSplitTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSplitTableLayoutPanel1.Name = "smartSplitTableLayoutPanel1";
            this.smartSplitTableLayoutPanel1.RowCount = 1;
            this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.smartSplitTableLayoutPanel1.Size = new System.Drawing.Size(788, 282);
            this.smartSplitTableLayoutPanel1.TabIndex = 6;
            // 
            // grdTarget
            // 
            this.grdTarget.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTarget.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy)
            | Micube.Framework.SmartControls.GridButtonItem.Delete)
            | Micube.Framework.SmartControls.GridButtonItem.Preview)
            | Micube.Framework.SmartControls.GridButtonItem.Import)
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdTarget.IsUsePaging = false;
            this.grdTarget.LanguageKey = null;
            this.grdTarget.Location = new System.Drawing.Point(511, 0);
            this.grdTarget.Margin = new System.Windows.Forms.Padding(0);
            this.grdTarget.Name = "grdTarget";
            this.grdTarget.ShowBorder = true;
            this.grdTarget.Size = new System.Drawing.Size(277, 282);
            this.grdTarget.TabIndex = 2;
            // 
            // grdSource
            // 
            this.grdSource.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSource.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy)
            | Micube.Framework.SmartControls.GridButtonItem.Delete)
            | Micube.Framework.SmartControls.GridButtonItem.Preview)
            | Micube.Framework.SmartControls.GridButtonItem.Import)
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdSource.IsUsePaging = false;
            this.grdSource.LanguageKey = null;
            this.grdSource.Location = new System.Drawing.Point(0, 0);
            this.grdSource.Margin = new System.Windows.Forms.Padding(0);
            this.grdSource.Name = "grdSource";
            this.grdSource.ShowBorder = true;
            this.grdSource.Size = new System.Drawing.Size(433, 282);
            this.grdSource.TabIndex = 1;
            // 
            // ucDataLeftRightBtnCtrl
            // 
            this.ucDataLeftRightBtnCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDataLeftRightBtnCtrl.Location = new System.Drawing.Point(436, 3);
            this.ucDataLeftRightBtnCtrl.Name = "ucDataLeftRightBtnCtrl";
            this.ucDataLeftRightBtnCtrl.Size = new System.Drawing.Size(72, 276);
            this.ucDataLeftRightBtnCtrl.SourceGrid = null;
            this.ucDataLeftRightBtnCtrl.TabIndex = 0;
            this.ucDataLeftRightBtnCtrl.TargetGrid = null;
            // 
            // MaterialOutPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 424);
            this.Name = "MaterialOutPopup";
            this.Text = "MaterialOutPopup";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblWareHouseId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReqQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReqNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReqDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            this.smartPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblLotNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).EndInit();
            this.smartPanel3.ResumeLayout(false);
            this.smartSplitTableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartLabelTextBox lblLotNo;
        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartLabelTextBox lblReqNo;
        private Framework.SmartControls.SmartLabelTextBox lblReqDepartment;
        private Framework.SmartControls.SmartSplitTableLayoutPanel smartSplitTableLayoutPanel1;
        private Framework.SmartControls.SmartBandedGrid grdTarget;
        private Commons.Controls.ucDataLeftRightBtn ucDataLeftRightBtnCtrl;
        private Framework.SmartControls.SmartBandedGrid grdSource;
        private Framework.SmartControls.SmartPanel smartPanel3;
        private Framework.SmartControls.SmartButton btnCancel;
        private Framework.SmartControls.SmartButton btnSave;
        private Framework.SmartControls.SmartLabelTextBox lblItemId;
        private Framework.SmartControls.SmartLabelTextBox lblItemName;
        private Framework.SmartControls.SmartLabelTextBox lblReqQty;
        private Framework.SmartControls.SmartLabelTextBox lblWareHouseId;
    }
}
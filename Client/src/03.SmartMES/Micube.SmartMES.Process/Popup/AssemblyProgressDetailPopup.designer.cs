namespace Micube.SmartMES.Process
{
    partial class AssemblyProgressDetailPopup
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new Micube.Framework.SmartControls.SmartButton();
            this.grdProgressDetail = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartLayoutControl1 = new Micube.Framework.SmartControls.SmartLayoutControl();
            this.txtQty = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.txtLotNo = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.txtModel = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.txtProductDefName = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.txtProductDefId = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.txtProductionOrderId = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.smartLayoutControlGroup1 = new Micube.Framework.SmartControls.SmartLayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartLayoutControl1)).BeginInit();
            this.smartLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductDefName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductDefId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductionOrderId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartLayoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tableLayoutPanel1);
            this.pnlMain.Size = new System.Drawing.Size(811, 474);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.grdProgressDetail, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.smartLayoutControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(811, 474);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 448);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(811, 26);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.AllowFocus = false;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClose.IsBusy = false;
            this.btnClose.IsWrite = false;
            this.btnClose.Location = new System.Drawing.Point(731, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "닫기";
            this.btnClose.TooltipLanguageKey = "";
            // 
            // grdProgressDetail
            // 
            this.grdProgressDetail.Caption = "세부공정 진척정보";
            this.grdProgressDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProgressDetail.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdProgressDetail.IsUsePaging = false;
            this.grdProgressDetail.LanguageKey = null;
            this.grdProgressDetail.Location = new System.Drawing.Point(0, 74);
            this.grdProgressDetail.Margin = new System.Windows.Forms.Padding(0);
            this.grdProgressDetail.Name = "grdProgressDetail";
            this.grdProgressDetail.ShowBorder = true;
            this.grdProgressDetail.Size = new System.Drawing.Size(811, 364);
            this.grdProgressDetail.TabIndex = 2;
            this.grdProgressDetail.UseAutoBestFitColumns = false;
            // 
            // smartLayoutControl1
            // 
            this.smartLayoutControl1.Controls.Add(this.txtQty);
            this.smartLayoutControl1.Controls.Add(this.txtLotNo);
            this.smartLayoutControl1.Controls.Add(this.txtModel);
            this.smartLayoutControl1.Controls.Add(this.txtProductDefName);
            this.smartLayoutControl1.Controls.Add(this.txtProductDefId);
            this.smartLayoutControl1.Controls.Add(this.txtProductionOrderId);
            this.smartLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartLayoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6});
            this.smartLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.smartLayoutControl1.Margin = new System.Windows.Forms.Padding(0);
            this.smartLayoutControl1.Name = "smartLayoutControl1";
            this.smartLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1270, 0, 650, 400);
            this.smartLayoutControl1.Root = this.smartLayoutControlGroup1;
            this.smartLayoutControl1.Size = new System.Drawing.Size(811, 64);
            this.smartLayoutControl1.TabIndex = 3;
            this.smartLayoutControl1.Text = "smartLayoutControl1";
            // 
            // txtQty
            // 
            this.txtQty.Appearance.Options.UseTextOptions = true;
            this.txtQty.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtQty.LabelText = "수량";
            this.txtQty.LanguageKey = null;
            this.txtQty.Location = new System.Drawing.Point(204, 34);
            this.txtQty.Name = "txtQty";
            this.txtQty.Properties.ReadOnly = true;
            this.txtQty.Size = new System.Drawing.Size(200, 20);
            this.txtQty.TabIndex = 9;
            // 
            // txtLotNo
            // 
            this.txtLotNo.LabelText = "생산 Lot No";
            this.txtLotNo.LanguageKey = null;
            this.txtLotNo.Location = new System.Drawing.Point(2, 34);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Properties.ReadOnly = true;
            this.txtLotNo.Size = new System.Drawing.Size(198, 20);
            this.txtLotNo.TabIndex = 8;
            // 
            // txtModel
            // 
            this.txtModel.LabelText = "기종";
            this.txtModel.LanguageKey = null;
            this.txtModel.Location = new System.Drawing.Point(673, 2);
            this.txtModel.Name = "txtModel";
            this.txtModel.Properties.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(136, 20);
            this.txtModel.TabIndex = 7;
            // 
            // txtProductDefName
            // 
            this.txtProductDefName.LabelText = "품목명";
            this.txtProductDefName.LabelWidth = "25%";
            this.txtProductDefName.LanguageKey = null;
            this.txtProductDefName.Location = new System.Drawing.Point(408, 2);
            this.txtProductDefName.Name = "txtProductDefName";
            this.txtProductDefName.Properties.ReadOnly = true;
            this.txtProductDefName.Size = new System.Drawing.Size(261, 20);
            this.txtProductDefName.TabIndex = 6;
            // 
            // txtProductDefId
            // 
            this.txtProductDefId.LabelText = "품목코드";
            this.txtProductDefId.LanguageKey = null;
            this.txtProductDefId.Location = new System.Drawing.Point(204, 2);
            this.txtProductDefId.Name = "txtProductDefId";
            this.txtProductDefId.Properties.ReadOnly = true;
            this.txtProductDefId.Size = new System.Drawing.Size(200, 20);
            this.txtProductDefId.TabIndex = 5;
            // 
            // txtProductionOrderId
            // 
            this.txtProductionOrderId.LabelText = "생산지시번호";
            this.txtProductionOrderId.LanguageKey = null;
            this.txtProductionOrderId.Location = new System.Drawing.Point(2, 2);
            this.txtProductionOrderId.Name = "txtProductionOrderId";
            this.txtProductionOrderId.Properties.ReadOnly = true;
            this.txtProductionOrderId.Size = new System.Drawing.Size(198, 20);
            this.txtProductionOrderId.TabIndex = 4;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Location = new System.Drawing.Point(161, 43);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(181, 43);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // smartLayoutControlGroup1
            // 
            this.smartLayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.smartLayoutControlGroup1.GroupBordersVisible = false;
            this.smartLayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem7});
            this.smartLayoutControlGroup1.Name = "Root";
            this.smartLayoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.smartLayoutControlGroup1.Size = new System.Drawing.Size(811, 64);
            this.smartLayoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtProductionOrderId;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(202, 32);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtProductDefId;
            this.layoutControlItem2.Location = new System.Drawing.Point(202, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(204, 32);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtProductDefName;
            this.layoutControlItem3.Location = new System.Drawing.Point(406, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(265, 64);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtModel;
            this.layoutControlItem4.Location = new System.Drawing.Point(671, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(140, 64);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtLotNo;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 32);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(202, 32);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtQty;
            this.layoutControlItem7.Location = new System.Drawing.Point(202, 32);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(204, 32);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // AssemblyProgressDetailPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 494);
            this.Name = "AssemblyProgressDetailPopup";
            this.Text = "조립진척 상세현황";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartLayoutControl1)).EndInit();
            this.smartLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductDefName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductDefId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductionOrderId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartLayoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Framework.SmartControls.SmartButton btnClose;
        private Framework.SmartControls.SmartBandedGrid grdProgressDetail;
        private Framework.SmartControls.SmartLayoutControl smartLayoutControl1;
        private Framework.SmartControls.SmartLayoutControlGroup smartLayoutControlGroup1;
        private Framework.SmartControls.SmartLabelTextBox txtProductionOrderId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private Framework.SmartControls.SmartLabelTextBox txtModel;
        private Framework.SmartControls.SmartLabelTextBox txtProductDefName;
        private Framework.SmartControls.SmartLabelTextBox txtProductDefId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private Framework.SmartControls.SmartLabelTextBox txtQty;
        private Framework.SmartControls.SmartLabelTextBox txtLotNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}
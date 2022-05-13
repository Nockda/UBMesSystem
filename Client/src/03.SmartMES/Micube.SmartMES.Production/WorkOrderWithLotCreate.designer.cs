namespace Micube.SmartMES.Production
{
    partial class WorkOrderWithLotCreate
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
            this.grdPoPlanList = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartGroupBox1 = new Micube.Framework.SmartControls.SmartGroupBox();
            this.txtUserDefine = new Micube.Framework.SmartControls.SmartLabelSpinEdit();
            this.txtInputQty = new Micube.Framework.SmartControls.SmartLabelSpinEdit();
            this.chkLabel = new Micube.Framework.SmartControls.SmartCheckBox();
            this.txtProcessQty = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.txtOrderQty = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.txtProduct = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.txtWorkOrder = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.grdLotList = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartSpliterControl1 = new Micube.Framework.SmartControls.SmartSpliterControl();
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.smartPanel3 = new Micube.Framework.SmartControls.SmartPanel();
            this.smartSpliterControl2 = new Micube.Framework.SmartControls.SmartSpliterControl();
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartGroupBox1)).BeginInit();
            this.smartGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDefine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInputQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).BeginInit();
            this.smartPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            this.smartPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(2, 31);
            this.pnlCondition.Size = new System.Drawing.Size(296, 990);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(819, 24);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.smartPanel1);
            this.pnlContent.Controls.Add(this.smartSpliterControl1);
            this.pnlContent.Controls.Add(this.grdPoPlanList);
            this.pnlContent.Size = new System.Drawing.Size(819, 994);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(1124, 1023);
            // 
            // grdPoPlanList
            // 
            this.grdPoPlanList.BackColor = System.Drawing.Color.Blue;
            this.grdPoPlanList.Caption = "작업지시 리스트";
            this.grdPoPlanList.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdPoPlanList.GridButtonItem = Micube.Framework.SmartControls.GridButtonItem.Export;
            this.grdPoPlanList.IsUsePaging = false;
            this.grdPoPlanList.LanguageKey = "";
            this.grdPoPlanList.Location = new System.Drawing.Point(0, 0);
            this.grdPoPlanList.Margin = new System.Windows.Forms.Padding(0);
            this.grdPoPlanList.Name = "grdPoPlanList";
            this.grdPoPlanList.ShowBorder = true;
            this.grdPoPlanList.Size = new System.Drawing.Size(819, 769);
            this.grdPoPlanList.TabIndex = 6;
            this.grdPoPlanList.UseAutoBestFitColumns = false;
            // 
            // smartGroupBox1
            // 
            this.smartGroupBox1.Controls.Add(this.txtUserDefine);
            this.smartGroupBox1.Controls.Add(this.txtInputQty);
            this.smartGroupBox1.Controls.Add(this.chkLabel);
            this.smartGroupBox1.Controls.Add(this.txtProcessQty);
            this.smartGroupBox1.Controls.Add(this.txtOrderQty);
            this.smartGroupBox1.Controls.Add(this.txtProduct);
            this.smartGroupBox1.Controls.Add(this.txtWorkOrder);
            this.smartGroupBox1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.smartGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartGroupBox1.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.smartGroupBox1.LanguageKey = "CREATELOT";
            this.smartGroupBox1.Location = new System.Drawing.Point(2, 2);
            this.smartGroupBox1.Name = "smartGroupBox1";
            this.smartGroupBox1.ShowBorder = true;
            this.smartGroupBox1.Size = new System.Drawing.Size(440, 212);
            this.smartGroupBox1.TabIndex = 7;
            this.smartGroupBox1.Text = "LOT 생성";
            // 
            // txtUserDefine
            // 
            this.txtUserDefine.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtUserDefine.Appearance.Options.UseForeColor = true;
            this.txtUserDefine.EditorWidth = "100%";
            this.txtUserDefine.LabelText = "사용자 Lot";
            this.txtUserDefine.LanguageKey = "USERLOT";
            this.txtUserDefine.Location = new System.Drawing.Point(10, 220);
            this.txtUserDefine.Name = "txtUserDefine";
            this.txtUserDefine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtUserDefine.Size = new System.Drawing.Size(306, 20);
            this.txtUserDefine.TabIndex = 3;
            // 
            // txtInputQty
            // 
            this.txtInputQty.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtInputQty.Appearance.Options.UseForeColor = true;
            this.txtInputQty.EditorWidth = "100%";
            this.txtInputQty.LabelText = "투입수량";
            this.txtInputQty.LanguageKey = "LOTSIZE";
            this.txtInputQty.Location = new System.Drawing.Point(10, 189);
            this.txtInputQty.Name = "txtInputQty";
            this.txtInputQty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtInputQty.Size = new System.Drawing.Size(306, 20);
            this.txtInputQty.TabIndex = 2;
            // 
            // chkLabel
            // 
            this.chkLabel.LanguageKey = "PRINTLABEL";
            this.chkLabel.Location = new System.Drawing.Point(323, 42);
            this.chkLabel.Name = "chkLabel";
            this.chkLabel.Properties.Caption = "라벨출력";
            this.chkLabel.Size = new System.Drawing.Size(113, 19);
            this.chkLabel.TabIndex = 1;
            // 
            // txtProcessQty
            // 
            this.txtProcessQty.EditorWidth = "50%";
            this.txtProcessQty.LabelText = "진행수량";
            this.txtProcessQty.LabelWidth = "20%";
            this.txtProcessQty.LanguageKey = "PROCESSQTY";
            this.txtProcessQty.Location = new System.Drawing.Point(10, 154);
            this.txtProcessQty.Name = "txtProcessQty";
            this.txtProcessQty.Properties.Appearance.Options.UseTextOptions = true;
            this.txtProcessQty.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtProcessQty.Properties.ReadOnly = true;
            this.txtProcessQty.Size = new System.Drawing.Size(306, 20);
            this.txtProcessQty.TabIndex = 0;
            // 
            // txtOrderQty
            // 
            this.txtOrderQty.EditorWidth = "50%";
            this.txtOrderQty.LabelText = "지시수량";
            this.txtOrderQty.LabelWidth = "20%";
            this.txtOrderQty.LanguageKey = "ORDERQTY";
            this.txtOrderQty.Location = new System.Drawing.Point(10, 116);
            this.txtOrderQty.Name = "txtOrderQty";
            this.txtOrderQty.Properties.Appearance.Options.UseTextOptions = true;
            this.txtOrderQty.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtOrderQty.Properties.ReadOnly = true;
            this.txtOrderQty.Size = new System.Drawing.Size(306, 20);
            this.txtOrderQty.TabIndex = 0;
            // 
            // txtProduct
            // 
            this.txtProduct.EditorWidth = "50%";
            this.txtProduct.LabelText = "품목";
            this.txtProduct.LabelWidth = "20%";
            this.txtProduct.LanguageKey = "ITEMNAME";
            this.txtProduct.Location = new System.Drawing.Point(10, 81);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Properties.ReadOnly = true;
            this.txtProduct.Size = new System.Drawing.Size(306, 20);
            this.txtProduct.TabIndex = 0;
            // 
            // txtWorkOrder
            // 
            this.txtWorkOrder.EditorWidth = "50%";
            this.txtWorkOrder.LabelText = "작업지시번호";
            this.txtWorkOrder.LabelWidth = "20%";
            this.txtWorkOrder.LanguageKey = "ORDERNUMBER";
            this.txtWorkOrder.Location = new System.Drawing.Point(10, 44);
            this.txtWorkOrder.Name = "txtWorkOrder";
            this.txtWorkOrder.Properties.ReadOnly = true;
            this.txtWorkOrder.Size = new System.Drawing.Size(306, 20);
            this.txtWorkOrder.TabIndex = 0;
            // 
            // grdLotList
            // 
            this.grdLotList.Caption = "LOT 생성 List";
            this.grdLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLotList.GridButtonItem = Micube.Framework.SmartControls.GridButtonItem.Export;
            this.grdLotList.IsUsePaging = false;
            this.grdLotList.LanguageKey = "LOTCREATELIST";
            this.grdLotList.Location = new System.Drawing.Point(2, 2);
            this.grdLotList.Margin = new System.Windows.Forms.Padding(0);
            this.grdLotList.Name = "grdLotList";
            this.grdLotList.ShowBorder = true;
            this.grdLotList.Size = new System.Drawing.Size(362, 212);
            this.grdLotList.TabIndex = 8;
            this.grdLotList.UseAutoBestFitColumns = false;
            // 
            // smartSpliterControl1
            // 
            this.smartSpliterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartSpliterControl1.Location = new System.Drawing.Point(0, 769);
            this.smartSpliterControl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterControl1.Name = "smartSpliterControl1";
            this.smartSpliterControl1.Size = new System.Drawing.Size(819, 5);
            this.smartSpliterControl1.TabIndex = 9;
            this.smartSpliterControl1.TabStop = false;
            // 
            // smartPanel1
            // 
            this.smartPanel1.Controls.Add(this.smartPanel3);
            this.smartPanel1.Controls.Add(this.smartSpliterControl2);
            this.smartPanel1.Controls.Add(this.smartPanel2);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartPanel1.Location = new System.Drawing.Point(0, 774);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(819, 220);
            this.smartPanel1.TabIndex = 10;
            // 
            // smartPanel3
            // 
            this.smartPanel3.Controls.Add(this.grdLotList);
            this.smartPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartPanel3.Location = new System.Drawing.Point(451, 2);
            this.smartPanel3.Name = "smartPanel3";
            this.smartPanel3.Size = new System.Drawing.Size(366, 216);
            this.smartPanel3.TabIndex = 11;
            // 
            // smartSpliterControl2
            // 
            this.smartSpliterControl2.Location = new System.Drawing.Point(446, 2);
            this.smartSpliterControl2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterControl2.Name = "smartSpliterControl2";
            this.smartSpliterControl2.Size = new System.Drawing.Size(5, 216);
            this.smartSpliterControl2.TabIndex = 10;
            this.smartSpliterControl2.TabStop = false;
            // 
            // smartPanel2
            // 
            this.smartPanel2.Controls.Add(this.smartGroupBox1);
            this.smartPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.smartPanel2.Location = new System.Drawing.Point(2, 2);
            this.smartPanel2.Name = "smartPanel2";
            this.smartPanel2.Size = new System.Drawing.Size(444, 216);
            this.smartPanel2.TabIndex = 9;
            // 
            // WorkOrderWithLotCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 1061);
            this.Name = "WorkOrderWithLotCreate";
            this.Padding = new System.Windows.Forms.Padding(19);
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartGroupBox1)).EndInit();
            this.smartGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDefine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInputQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).EndInit();
            this.smartPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            this.smartPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartBandedGrid grdPoPlanList;
        private Framework.SmartControls.SmartGroupBox smartGroupBox1;
        private Framework.SmartControls.SmartCheckBox chkLabel;
        private Framework.SmartControls.SmartLabelTextBox txtProcessQty;
        private Framework.SmartControls.SmartLabelTextBox txtOrderQty;
        private Framework.SmartControls.SmartLabelTextBox txtProduct;
        private Framework.SmartControls.SmartLabelTextBox txtWorkOrder;
        private Framework.SmartControls.SmartBandedGrid grdLotList;
        private Framework.SmartControls.SmartLabelSpinEdit txtInputQty;
        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartSpliterControl smartSpliterControl1;
        private Framework.SmartControls.SmartPanel smartPanel3;
        private Framework.SmartControls.SmartSpliterControl smartSpliterControl2;
        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartLabelSpinEdit txtUserDefine;
    }
}
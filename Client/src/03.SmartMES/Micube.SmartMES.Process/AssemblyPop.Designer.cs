namespace Micube.SmartMES.Material.Kanban
{
    partial class AssemblyPop
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
            this.smartSpliterContainer1 = new Micube.Framework.SmartControls.SmartSpliterContainer();
            this.grdMaterialLot = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.btnClose = new Micube.Framework.SmartControls.SmartButton();
            this.btnSave = new Micube.Framework.SmartControls.SmartButton();
            this.smartSpliterControl1 = new Micube.Framework.SmartControls.SmartSpliterControl();
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.smartSplitTableLayoutPanel1 = new Micube.Framework.SmartControls.SmartSplitTableLayoutPanel();
            this.smartLabel5 = new Micube.Framework.SmartControls.SmartLabel();
            this.txtLotCode = new Micube.Framework.SmartControls.SmartTextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).BeginInit();
            this.smartSpliterContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            this.smartSplitTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.smartSpliterContainer1);
            this.pnlMain.Controls.Add(this.smartSpliterControl1);
            this.pnlMain.Controls.Add(this.smartPanel1);
            this.pnlMain.Size = new System.Drawing.Size(804, 430);
            // 
            // smartSpliterContainer1
            // 
            this.smartSpliterContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSpliterContainer1.Horizontal = false;
            this.smartSpliterContainer1.Location = new System.Drawing.Point(0, 50);
            this.smartSpliterContainer1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterContainer1.Name = "smartSpliterContainer1";
            this.smartSpliterContainer1.Panel1.Controls.Add(this.grdMaterialLot);
            this.smartSpliterContainer1.Panel1.Text = "Panel1";
            this.smartSpliterContainer1.Panel2.Controls.Add(this.btnClose);
            this.smartSpliterContainer1.Panel2.Controls.Add(this.btnSave);
            this.smartSpliterContainer1.Panel2.Text = "Panel2";
            this.smartSpliterContainer1.Size = new System.Drawing.Size(804, 380);
            this.smartSpliterContainer1.SplitterPosition = 306;
            this.smartSpliterContainer1.TabIndex = 5;
            this.smartSpliterContainer1.Text = "smartSpliterContainer1";
            // 
            // grdMaterialLot
            // 
            this.grdMaterialLot.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdMaterialLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMaterialLot.GridButtonItem = Micube.Framework.SmartControls.GridButtonItem.Refresh;
            this.grdMaterialLot.IsUsePaging = false;
            this.grdMaterialLot.LanguageKey = null;
            this.grdMaterialLot.Location = new System.Drawing.Point(0, 0);
            this.grdMaterialLot.Margin = new System.Windows.Forms.Padding(0);
            this.grdMaterialLot.Name = "grdMaterialLot";
            this.grdMaterialLot.ShowBorder = true;
            this.grdMaterialLot.Size = new System.Drawing.Size(804, 306);
            this.grdMaterialLot.TabIndex = 2;
            this.grdMaterialLot.UseAutoBestFitColumns = false;
            // 
            // btnClose
            // 
            this.btnClose.AllowFocus = false;
            this.btnClose.IsBusy = false;
            this.btnClose.IsWrite = false;
            this.btnClose.Location = new System.Drawing.Point(446, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnClose.Size = new System.Drawing.Size(138, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "닫기";
            this.btnClose.TooltipLanguageKey = "";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.AllowFocus = false;
            this.btnSave.IsBusy = false;
            this.btnSave.IsWrite = false;
            this.btnSave.Location = new System.Drawing.Point(246, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSave.Size = new System.Drawing.Size(138, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "저장";
            this.btnSave.TooltipLanguageKey = "";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // smartSpliterControl1
            // 
            this.smartSpliterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartSpliterControl1.Location = new System.Drawing.Point(0, 45);
            this.smartSpliterControl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterControl1.Name = "smartSpliterControl1";
            this.smartSpliterControl1.Size = new System.Drawing.Size(804, 5);
            this.smartSpliterControl1.TabIndex = 4;
            this.smartSpliterControl1.TabStop = false;
            // 
            // smartPanel1
            // 
            this.smartPanel1.Controls.Add(this.smartSplitTableLayoutPanel1);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(804, 45);
            this.smartPanel1.TabIndex = 3;
            // 
            // smartSplitTableLayoutPanel1
            // 
            this.smartSplitTableLayoutPanel1.ColumnCount = 3;
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.2835F));
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.smartSplitTableLayoutPanel1.Controls.Add(this.smartLabel5, 0, 0);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.txtLotCode, 1, 0);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.button1, 2, 0);
            this.smartSplitTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSplitTableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.smartSplitTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSplitTableLayoutPanel1.Name = "smartSplitTableLayoutPanel1";
            this.smartSplitTableLayoutPanel1.RowCount = 1;
            this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.smartSplitTableLayoutPanel1.Size = new System.Drawing.Size(800, 41);
            this.smartSplitTableLayoutPanel1.TabIndex = 6;
            // 
            // smartLabel5
            // 
            this.smartLabel5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.smartLabel5.Appearance.Options.UseFont = true;
            this.smartLabel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartLabel5.Location = new System.Drawing.Point(3, 3);
            this.smartLabel5.Name = "smartLabel5";
            this.smartLabel5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.smartLabel5.Size = new System.Drawing.Size(52, 16);
            this.smartLabel5.TabIndex = 9;
            this.smartLabel5.Text = "LOT No";
            // 
            // txtLotCode
            // 
            this.txtLotCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLotCode.LabelText = null;
            this.txtLotCode.LanguageKey = null;
            this.txtLotCode.Location = new System.Drawing.Point(265, 3);
            this.txtLotCode.Name = "txtLotCode";
            this.txtLotCode.Size = new System.Drawing.Size(391, 20);
            this.txtLotCode.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(662, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 35);
            this.button1.TabIndex = 11;
            this.button1.Text = "검색";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_Search);
            // 
            // AssemblyPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 450);
            this.Name = "AssemblyPop";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).EndInit();
            this.smartSpliterContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            this.smartSplitTableLayoutPanel1.ResumeLayout(false);
            this.smartSplitTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer1;
        private Framework.SmartControls.SmartButton btnClose;
        private Framework.SmartControls.SmartButton btnSave;
        private Framework.SmartControls.SmartSpliterControl smartSpliterControl1;
        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartSplitTableLayoutPanel smartSplitTableLayoutPanel1;
        private Framework.SmartControls.SmartLabel smartLabel5;
        private Framework.SmartControls.SmartBandedGrid grdMaterialLot;
        private Framework.SmartControls.SmartTextBox txtLotCode;
        private System.Windows.Forms.Button button1;
    }
}
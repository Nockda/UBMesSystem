namespace Micube.SmartMES.StandardInfo
{
    partial class ItemScopeMgt
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
            this.components = new System.ComponentModel.Container();
            Micube.Framework.SmartControls.ConditionCollection conditionCollection2 = new Micube.Framework.SmartControls.ConditionCollection();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition4 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            this.smartSpliterContainer1 = new Micube.Framework.SmartControls.SmartSpliterContainer();
            this.grdItemInfo = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.grdSubInfo = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartSplitTableLayoutPanel2 = new Micube.Framework.SmartControls.SmartSplitTableLayoutPanel();
            this.smartLabel6 = new Micube.Framework.SmartControls.SmartLabel();
            this.smartTextBox4 = new Micube.Framework.SmartControls.SmartTextBox();
            this.smartLabelTextBox1 = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.smartSplitTableLayoutPanel1 = new Micube.Framework.SmartControls.SmartSplitTableLayoutPanel();
            this.smartLabel2 = new Micube.Framework.SmartControls.SmartLabel();
            this.smartLabel1 = new Micube.Framework.SmartControls.SmartLabel();
            this.smartLabel3 = new Micube.Framework.SmartControls.SmartLabel();
            this.smartTextBox1 = new Micube.Framework.SmartControls.SmartTextBox();
            this.smartTextBox2 = new Micube.Framework.SmartControls.SmartTextBox();
            this.smartLayout1 = new Micube.Framework.SmartControls.SmartLayout();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.smartBandedGrid1 = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).BeginInit();
            this.smartSpliterContainer1.SuspendLayout();
            this.smartSplitTableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartTextBox4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelTextBox1.Properties)).BeginInit();
            this.smartSplitTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartTextBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartTextBox2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartLayout1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Size = new System.Drawing.Size(371, 535);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(1488, 30);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.smartSpliterContainer1);
            this.pnlContent.Size = new System.Drawing.Size(1488, 538);
            this.pnlContent.Click += new System.EventHandler(this.pnlContent_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(1869, 574);
            // 
            // smartSpliterContainer1
            // 
            this.smartSpliterContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSpliterContainer1.Location = new System.Drawing.Point(0, 0);
            this.smartSpliterContainer1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterContainer1.Name = "smartSpliterContainer1";
            this.smartSpliterContainer1.Panel1.Controls.Add(this.smartBandedGrid1);
            this.smartSpliterContainer1.Panel1.Controls.Add(this.grdItemInfo);
            this.smartSpliterContainer1.Panel1.Text = "Panel1";
            this.smartSpliterContainer1.Panel2.Controls.Add(this.grdSubInfo);
            this.smartSpliterContainer1.Panel2.Controls.Add(this.smartSplitTableLayoutPanel2);
            this.smartSpliterContainer1.Panel2.Controls.Add(this.smartSplitTableLayoutPanel1);
            this.smartSpliterContainer1.Panel2.Text = "Panel2";
            this.smartSpliterContainer1.Size = new System.Drawing.Size(1488, 538);
            this.smartSpliterContainer1.SplitterPosition = 1020;
            this.smartSpliterContainer1.TabIndex = 0;
            this.smartSpliterContainer1.Text = "smartSpliterContainer1";
            // 
            // grdItemInfo
            // 
            this.grdItemInfo.Caption = "품목 기본 정보";
            this.grdItemInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItemInfo.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdItemInfo.IsUsePaging = false;
            this.grdItemInfo.LanguageKey = "";
            this.grdItemInfo.Location = new System.Drawing.Point(0, 0);
            this.grdItemInfo.Margin = new System.Windows.Forms.Padding(0);
            this.grdItemInfo.Name = "grdItemInfo";
            this.grdItemInfo.ShowBorder = true;
            this.grdItemInfo.Size = new System.Drawing.Size(1020, 538);
            this.grdItemInfo.TabIndex = 1;
            // 
            // grdSubInfo
            // 
            this.grdSubInfo.Caption = "SUB 공정 표준공수 정보";
            this.grdSubInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSubInfo.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdSubInfo.IsUsePaging = false;
            this.grdSubInfo.LanguageKey = "";
            this.grdSubInfo.Location = new System.Drawing.Point(0, 121);
            this.grdSubInfo.Margin = new System.Windows.Forms.Padding(0);
            this.grdSubInfo.Name = "grdSubInfo";
            this.grdSubInfo.ShowBorder = true;
            this.grdSubInfo.Size = new System.Drawing.Size(462, 417);
            this.grdSubInfo.TabIndex = 2;
            this.grdSubInfo.Load += new System.EventHandler(this.grdSubInfo_Load_1);
            // 
            // smartSplitTableLayoutPanel2
            // 
            this.smartSplitTableLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.smartSplitTableLayoutPanel2.ColumnCount = 5;
            this.smartSplitTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.smartSplitTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.smartSplitTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.76464F));
            this.smartSplitTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.smartSplitTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.23536F));
            this.smartSplitTableLayoutPanel2.Controls.Add(this.smartLabel6, 1, 0);
            this.smartSplitTableLayoutPanel2.Controls.Add(this.smartTextBox4, 2, 0);
            this.smartSplitTableLayoutPanel2.Controls.Add(this.smartLabelTextBox1, 4, 0);
            this.smartSplitTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartSplitTableLayoutPanel2.Location = new System.Drawing.Point(0, 80);
            this.smartSplitTableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSplitTableLayoutPanel2.Name = "smartSplitTableLayoutPanel2";
            this.smartSplitTableLayoutPanel2.RowCount = 1;
            this.smartSplitTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.smartSplitTableLayoutPanel2.Size = new System.Drawing.Size(462, 41);
            this.smartSplitTableLayoutPanel2.TabIndex = 1;
            this.smartSplitTableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.smartSplitTableLayoutPanel2_Paint);
            // 
            // smartLabel6
            // 
            this.smartLabel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.smartLabel6.Location = new System.Drawing.Point(65, 3);
            this.smartLabel6.Name = "smartLabel6";
            this.smartLabel6.Size = new System.Drawing.Size(39, 18);
            this.smartLabel6.TabIndex = 0;
            this.smartLabel6.Text = "공정명";
            // 
            // smartTextBox4
            // 
            this.smartTextBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartTextBox4.LabelText = null;
            this.smartTextBox4.LanguageKey = null;
            this.smartTextBox4.Location = new System.Drawing.Point(110, 3);
            this.smartTextBox4.Name = "smartTextBox4";
            this.smartTextBox4.Size = new System.Drawing.Size(121, 24);
            this.smartTextBox4.TabIndex = 1;
            // 
            // smartLabelTextBox1
            // 
      //      this.smartLabelTextBox1.CenterMargin = 5F;
            this.smartLabelTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartLabelTextBox1.EditorWidth = "50%";
            this.smartLabelTextBox1.Label.Appearance.BorderColor = System.Drawing.Color.Empty;
            this.smartLabelTextBox1.Label.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.smartLabelTextBox1.LabelText = "표준공수";
            this.smartLabelTextBox1.LabelWidth = "20%";
            this.smartLabelTextBox1.LanguageKey = null;
            this.smartLabelTextBox1.Location = new System.Drawing.Point(280, 3);
            this.smartLabelTextBox1.Name = "smartLabelTextBox1";
            this.smartLabelTextBox1.Size = new System.Drawing.Size(179, 24);
            this.smartLabelTextBox1.TabIndex = 2;
            // 
            // smartSplitTableLayoutPanel1
            // 
            this.smartSplitTableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.smartSplitTableLayoutPanel1.ColumnCount = 5;
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.79232F));
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.20768F));
            this.smartSplitTableLayoutPanel1.Controls.Add(this.smartLabel2, 1, 0);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.smartLabel1, 0, 0);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.smartLabel3, 1, 1);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.smartTextBox1, 2, 1);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.smartTextBox2, 4, 1);
            this.smartSplitTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartSplitTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartSplitTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSplitTableLayoutPanel1.Name = "smartSplitTableLayoutPanel1";
            this.smartSplitTableLayoutPanel1.RowCount = 2;
            this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.31461F));
            this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.68539F));
            this.smartSplitTableLayoutPanel1.Size = new System.Drawing.Size(462, 80);
            this.smartSplitTableLayoutPanel1.TabIndex = 0;
            this.smartSplitTableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.smartSplitTableLayoutPanel1_Paint);
            // 
            // smartLabel2
            // 
            this.smartLabel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.smartLabel2.Location = new System.Drawing.Point(23, 3);
            this.smartLabel2.Name = "smartLabel2";
            this.smartLabel2.Size = new System.Drawing.Size(83, 18);
            this.smartLabel2.TabIndex = 1;
            this.smartLabel2.Text = "표준공수 정보";
            // 
            // smartLabel1
            // 
            this.smartLabel1.Location = new System.Drawing.Point(3, 3);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Size = new System.Drawing.Size(15, 18);
            this.smartLabel1.TabIndex = 5;
            this.smartLabel1.Text = "▶";
            this.smartLabel1.Click += new System.EventHandler(this.smartLabel1_Click_1);
            // 
            // smartLabel3
            // 
            this.smartLabel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.smartLabel3.Location = new System.Drawing.Point(49, 41);
            this.smartLabel3.Name = "smartLabel3";
            this.smartLabel3.Size = new System.Drawing.Size(55, 18);
            this.smartLabel3.TabIndex = 6;
            this.smartLabel3.Text = "라우터ID";
            this.smartLabel3.Click += new System.EventHandler(this.smartLabel3_Click);
            // 
            // smartTextBox1
            // 
            this.smartTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartTextBox1.LabelText = null;
            this.smartTextBox1.LanguageKey = null;
            this.smartTextBox1.Location = new System.Drawing.Point(110, 41);
            this.smartTextBox1.Name = "smartTextBox1";
            this.smartTextBox1.Size = new System.Drawing.Size(121, 24);
            this.smartTextBox1.TabIndex = 7;
            // 
            // smartTextBox2
            // 
            this.smartTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartTextBox2.LabelText = null;
            this.smartTextBox2.LanguageKey = null;
            this.smartTextBox2.Location = new System.Drawing.Point(280, 41);
            this.smartTextBox2.Name = "smartTextBox2";
            this.smartTextBox2.Size = new System.Drawing.Size(179, 24);
            this.smartTextBox2.TabIndex = 8;
            // 
            // smartLayout1
            // 
            this.smartLayout1.Conditions = conditionCollection2;
            this.smartLayout1.IsBusy = false;
            this.smartLayout1.LayoutType = DevExpress.XtraLayout.Utils.LayoutType.Vertical;
            this.smartLayout1.Location = new System.Drawing.Point(1888, 346);
            this.smartLayout1.Name = "smartLayout1";
            this.smartLayout1.Root = this.layoutControlGroup1;
            this.smartLayout1.Size = new System.Drawing.Size(8, 8);
            this.smartLayout1.TabIndex = 5;
            this.smartLayout1.Text = "smartLayout1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            columnDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition3.Width = 50D;
            columnDefinition4.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition4.Width = 50D;
            this.layoutControlGroup1.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition3,
            columnDefinition4});
            rowDefinition3.Height = 50D;
            rowDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition4.Height = 50D;
            rowDefinition4.SizeType = System.Windows.Forms.SizeType.Percent;
            this.layoutControlGroup1.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition3,
            rowDefinition4});
            this.layoutControlGroup1.Size = new System.Drawing.Size(22, 22);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // smartBandedGrid1
            // 
            this.smartBandedGrid1.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.smartBandedGrid1.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.smartBandedGrid1.IsUsePaging = false;
            this.smartBandedGrid1.LanguageKey = null;
            this.smartBandedGrid1.Location = new System.Drawing.Point(912, 193);
            this.smartBandedGrid1.Margin = new System.Windows.Forms.Padding(0);
            this.smartBandedGrid1.Name = "smartBandedGrid1";
            this.smartBandedGrid1.ShowBorder = true;
            this.smartBandedGrid1.Size = new System.Drawing.Size(8, 37);
            this.smartBandedGrid1.TabIndex = 2;
            // 
            // ItemScopeMgt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1907, 612);
            this.Controls.Add(this.smartLayout1);
            this.Name = "ItemScopeMgt";
            this.Padding = new System.Windows.Forms.Padding(19, 19, 19, 19);
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.smartLayout1, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).EndInit();
            this.smartSpliterContainer1.ResumeLayout(false);
            this.smartSplitTableLayoutPanel2.ResumeLayout(false);
            this.smartSplitTableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartTextBox4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartLabelTextBox1.Properties)).EndInit();
            this.smartSplitTableLayoutPanel1.ResumeLayout(false);
            this.smartSplitTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartTextBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartTextBox2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartLayout1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer1;
        private Framework.SmartControls.SmartBandedGrid grdItemInfo;
        private Framework.SmartControls.SmartSplitTableLayoutPanel smartSplitTableLayoutPanel1;
        private Framework.SmartControls.SmartLabel smartLabel2;
        private Framework.SmartControls.SmartLabel smartLabel1;
        private Framework.SmartControls.SmartLabel smartLabel3;
        private Framework.SmartControls.SmartTextBox smartTextBox1;
        private Framework.SmartControls.SmartLayout smartLayout1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private Framework.SmartControls.SmartTextBox smartTextBox2;
        private Framework.SmartControls.SmartBandedGrid grdSubInfo;
        private Framework.SmartControls.SmartSplitTableLayoutPanel smartSplitTableLayoutPanel2;
        private Framework.SmartControls.SmartLabel smartLabel6;
        private Framework.SmartControls.SmartTextBox smartTextBox4;
        private Framework.SmartControls.SmartLabelTextBox smartLabelTextBox1;
        private Framework.SmartControls.SmartBandedGrid smartBandedGrid1;
    }
}
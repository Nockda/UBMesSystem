namespace Micube.SmartMES.DashBoard
{
    partial class DashConsumablePop
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDate = new Micube.Framework.SmartControls.SmartLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMainTitle = new Micube.Framework.SmartControls.SmartLabel();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pnlStatusRight = new System.Windows.Forms.Panel();
            this.lblEndCnt = new Micube.Framework.SmartControls.SmartLabel();
            this.pnlStatusRightTop = new System.Windows.Forms.Panel();
            this.lblStatusRight = new Micube.Framework.SmartControls.SmartLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlStatusCenter = new System.Windows.Forms.Panel();
            this.lblProcessCnt = new Micube.Framework.SmartControls.SmartLabel();
            this.pnlStatusCenterTop = new System.Windows.Forms.Panel();
            this.lblStatusCenter = new Micube.Framework.SmartControls.SmartLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlStatusLeft = new System.Windows.Forms.Panel();
            this.lblWaitCnt = new Micube.Framework.SmartControls.SmartLabel();
            this.pnlStatusLeftTop = new System.Windows.Forms.Panel();
            this.lblStatusLeft = new Micube.Framework.SmartControls.SmartLabel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.grdConsumable = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.pnlStatusRight.SuspendLayout();
            this.pnlStatusRightTop.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlStatusCenter.SuspendLayout();
            this.pnlStatusCenterTop.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlStatusLeft.SuspendLayout();
            this.pnlStatusLeftTop.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlGrid);
            this.pnlMain.Controls.Add(this.pnlCenter);
            this.pnlMain.Controls.Add(this.tableLayoutPanel1);
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Size = new System.Drawing.Size(1254, 778);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pictureBox1);
            this.pnlTop.Controls.Add(this.lblDate);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1254, 67);
            this.pnlTop.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::Micube.SmartMES.DashBoard.Properties.Resources.ULVAC_Logo_03;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pictureBox1.Size = new System.Drawing.Size(315, 67);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblDate
            // 
            this.lblDate.Appearance.Font = new System.Drawing.Font("Tahoma", 32F, System.Drawing.FontStyle.Bold);
            this.lblDate.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblDate.Appearance.Options.UseFont = true;
            this.lblDate.Appearance.Options.UseForeColor = true;
            this.lblDate.Appearance.Options.UseTextOptions = true;
            this.lblDate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Location = new System.Drawing.Point(913, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(341, 67);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "2020-06-17";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblMainTitle, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 67);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1254, 145);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 70F, System.Drawing.FontStyle.Bold);
            this.lblMainTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblMainTitle.Appearance.Options.UseFont = true;
            this.lblMainTitle.Appearance.Options.UseForeColor = true;
            this.lblMainTitle.Appearance.Options.UseTextOptions = true;
            this.lblMainTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblMainTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblMainTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMainTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMainTitle.LanguageKey = "DashTitleConsumeIn";
            this.lblMainTitle.Location = new System.Drawing.Point(253, 3);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(746, 139);
            this.lblMainTitle.TabIndex = 1;
            this.lblMainTitle.Text = "자재 입고 현황";
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.tableLayoutPanel2);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCenter.Location = new System.Drawing.Point(0, 212);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(1254, 308);
            this.pnlCenter.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.Controls.Add(this.panel6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1254, 308);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.pnlStatusRight);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(839, 23);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panel6.Size = new System.Drawing.Size(402, 272);
            this.panel6.TabIndex = 2;
            // 
            // pnlStatusRight
            // 
            this.pnlStatusRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatusRight.Controls.Add(this.lblEndCnt);
            this.pnlStatusRight.Controls.Add(this.pnlStatusRightTop);
            this.pnlStatusRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatusRight.Location = new System.Drawing.Point(10, 0);
            this.pnlStatusRight.Name = "pnlStatusRight";
            this.pnlStatusRight.Size = new System.Drawing.Size(392, 272);
            this.pnlStatusRight.TabIndex = 0;
            // 
            // lblEndCnt
            // 
            this.lblEndCnt.Appearance.Font = new System.Drawing.Font("Tahoma", 70F, System.Drawing.FontStyle.Bold);
            this.lblEndCnt.Appearance.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblEndCnt.Appearance.Options.UseFont = true;
            this.lblEndCnt.Appearance.Options.UseForeColor = true;
            this.lblEndCnt.Appearance.Options.UseTextOptions = true;
            this.lblEndCnt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblEndCnt.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblEndCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEndCnt.Location = new System.Drawing.Point(0, 88);
            this.lblEndCnt.Name = "lblEndCnt";
            this.lblEndCnt.Size = new System.Drawing.Size(390, 182);
            this.lblEndCnt.TabIndex = 6;
            this.lblEndCnt.Text = "0";
            // 
            // pnlStatusRightTop
            // 
            this.pnlStatusRightTop.BackColor = System.Drawing.Color.LawnGreen;
            this.pnlStatusRightTop.Controls.Add(this.lblStatusRight);
            this.pnlStatusRightTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatusRightTop.Location = new System.Drawing.Point(0, 0);
            this.pnlStatusRightTop.Name = "pnlStatusRightTop";
            this.pnlStatusRightTop.Padding = new System.Windows.Forms.Padding(3);
            this.pnlStatusRightTop.Size = new System.Drawing.Size(390, 88);
            this.pnlStatusRightTop.TabIndex = 5;
            // 
            // lblStatusRight
            // 
            this.lblStatusRight.Appearance.Font = new System.Drawing.Font("Tahoma", 40F, System.Drawing.FontStyle.Bold);
            this.lblStatusRight.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblStatusRight.Appearance.Options.UseFont = true;
            this.lblStatusRight.Appearance.Options.UseForeColor = true;
            this.lblStatusRight.Appearance.Options.UseTextOptions = true;
            this.lblStatusRight.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatusRight.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatusRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusRight.LanguageKey = "DashFinished";
            this.lblStatusRight.Location = new System.Drawing.Point(3, 3);
            this.lblStatusRight.Name = "lblStatusRight";
            this.lblStatusRight.Size = new System.Drawing.Size(384, 82);
            this.lblStatusRight.TabIndex = 5;
            this.lblStatusRight.Text = "완   료";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pnlStatusCenter);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(420, 23);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel5.Size = new System.Drawing.Size(413, 272);
            this.panel5.TabIndex = 1;
            // 
            // pnlStatusCenter
            // 
            this.pnlStatusCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatusCenter.Controls.Add(this.lblProcessCnt);
            this.pnlStatusCenter.Controls.Add(this.pnlStatusCenterTop);
            this.pnlStatusCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatusCenter.Location = new System.Drawing.Point(10, 0);
            this.pnlStatusCenter.Name = "pnlStatusCenter";
            this.pnlStatusCenter.Size = new System.Drawing.Size(393, 272);
            this.pnlStatusCenter.TabIndex = 0;
            // 
            // lblProcessCnt
            // 
            this.lblProcessCnt.Appearance.Font = new System.Drawing.Font("Tahoma", 70F, System.Drawing.FontStyle.Bold);
            this.lblProcessCnt.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.lblProcessCnt.Appearance.Options.UseFont = true;
            this.lblProcessCnt.Appearance.Options.UseForeColor = true;
            this.lblProcessCnt.Appearance.Options.UseTextOptions = true;
            this.lblProcessCnt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblProcessCnt.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblProcessCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProcessCnt.Location = new System.Drawing.Point(0, 87);
            this.lblProcessCnt.Name = "lblProcessCnt";
            this.lblProcessCnt.Size = new System.Drawing.Size(391, 183);
            this.lblProcessCnt.TabIndex = 5;
            this.lblProcessCnt.Text = "0";
            // 
            // pnlStatusCenterTop
            // 
            this.pnlStatusCenterTop.BackColor = System.Drawing.Color.Yellow;
            this.pnlStatusCenterTop.Controls.Add(this.lblStatusCenter);
            this.pnlStatusCenterTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatusCenterTop.Location = new System.Drawing.Point(0, 0);
            this.pnlStatusCenterTop.Name = "pnlStatusCenterTop";
            this.pnlStatusCenterTop.Padding = new System.Windows.Forms.Padding(3);
            this.pnlStatusCenterTop.Size = new System.Drawing.Size(391, 87);
            this.pnlStatusCenterTop.TabIndex = 4;
            // 
            // lblStatusCenter
            // 
            this.lblStatusCenter.Appearance.Font = new System.Drawing.Font("Tahoma", 40F, System.Drawing.FontStyle.Bold);
            this.lblStatusCenter.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblStatusCenter.Appearance.Options.UseFont = true;
            this.lblStatusCenter.Appearance.Options.UseForeColor = true;
            this.lblStatusCenter.Appearance.Options.UseTextOptions = true;
            this.lblStatusCenter.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatusCenter.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatusCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusCenter.LanguageKey = "DashInProcess";
            this.lblStatusCenter.Location = new System.Drawing.Point(3, 3);
            this.lblStatusCenter.Name = "lblStatusCenter";
            this.lblStatusCenter.Size = new System.Drawing.Size(385, 81);
            this.lblStatusCenter.TabIndex = 4;
            this.lblStatusCenter.Text = "진 행 중";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pnlStatusLeft);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(13, 23);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.panel4.Size = new System.Drawing.Size(401, 272);
            this.panel4.TabIndex = 0;
            // 
            // pnlStatusLeft
            // 
            this.pnlStatusLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatusLeft.Controls.Add(this.lblWaitCnt);
            this.pnlStatusLeft.Controls.Add(this.pnlStatusLeftTop);
            this.pnlStatusLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatusLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlStatusLeft.Name = "pnlStatusLeft";
            this.pnlStatusLeft.Padding = new System.Windows.Forms.Padding(3);
            this.pnlStatusLeft.Size = new System.Drawing.Size(381, 272);
            this.pnlStatusLeft.TabIndex = 0;
            // 
            // lblWaitCnt
            // 
            this.lblWaitCnt.Appearance.Font = new System.Drawing.Font("Tahoma", 70F, System.Drawing.FontStyle.Bold);
            this.lblWaitCnt.Appearance.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblWaitCnt.Appearance.Options.UseFont = true;
            this.lblWaitCnt.Appearance.Options.UseForeColor = true;
            this.lblWaitCnt.Appearance.Options.UseTextOptions = true;
            this.lblWaitCnt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblWaitCnt.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblWaitCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWaitCnt.Location = new System.Drawing.Point(3, 87);
            this.lblWaitCnt.Name = "lblWaitCnt";
            this.lblWaitCnt.Size = new System.Drawing.Size(373, 180);
            this.lblWaitCnt.TabIndex = 4;
            this.lblWaitCnt.Text = "0";
            // 
            // pnlStatusLeftTop
            // 
            this.pnlStatusLeftTop.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlStatusLeftTop.Controls.Add(this.lblStatusLeft);
            this.pnlStatusLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatusLeftTop.Location = new System.Drawing.Point(3, 3);
            this.pnlStatusLeftTop.Name = "pnlStatusLeftTop";
            this.pnlStatusLeftTop.Size = new System.Drawing.Size(373, 84);
            this.pnlStatusLeftTop.TabIndex = 3;
            // 
            // lblStatusLeft
            // 
            this.lblStatusLeft.Appearance.Font = new System.Drawing.Font("Tahoma", 40F, System.Drawing.FontStyle.Bold);
            this.lblStatusLeft.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblStatusLeft.Appearance.Options.UseFont = true;
            this.lblStatusLeft.Appearance.Options.UseForeColor = true;
            this.lblStatusLeft.Appearance.Options.UseTextOptions = true;
            this.lblStatusLeft.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatusLeft.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatusLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusLeft.LanguageKey = "DashWait";
            this.lblStatusLeft.Location = new System.Drawing.Point(0, 0);
            this.lblStatusLeft.Name = "lblStatusLeft";
            this.lblStatusLeft.Size = new System.Drawing.Size(373, 84);
            this.lblStatusLeft.TabIndex = 3;
            this.lblStatusLeft.Text = "대  기";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.grdConsumable);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 520);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(10);
            this.pnlGrid.Size = new System.Drawing.Size(1254, 258);
            this.pnlGrid.TabIndex = 4;
            // 
            // grdConsumable
            // 
            this.grdConsumable.Caption = "";
            this.grdConsumable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdConsumable.Font = new System.Drawing.Font("Tahoma", 40F);
            this.grdConsumable.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdConsumable.IsUsePaging = false;
            this.grdConsumable.LanguageKey = "WORKSTATUSBYDRYER";
            this.grdConsumable.Location = new System.Drawing.Point(10, 10);
            this.grdConsumable.Margin = new System.Windows.Forms.Padding(0);
            this.grdConsumable.Name = "grdConsumable";
            this.grdConsumable.Padding = new System.Windows.Forms.Padding(3);
            this.grdConsumable.ShowBorder = true;
            this.grdConsumable.ShowButtonBar = false;
            this.grdConsumable.ShowStatusBar = false;
            this.grdConsumable.Size = new System.Drawing.Size(1234, 238);
            this.grdConsumable.TabIndex = 2;
            this.grdConsumable.UseAutoBestFitColumns = false;
            // 
            // DashConsumablePop
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1274, 798);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashConsumablePop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashBoard";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.pnlStatusRight.ResumeLayout(false);
            this.pnlStatusRightTop.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.pnlStatusCenter.ResumeLayout(false);
            this.pnlStatusCenterTop.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnlStatusLeft.ResumeLayout(false);
            this.pnlStatusLeftTop.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Framework.SmartControls.SmartLabel lblDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Framework.SmartControls.SmartLabel lblMainTitle;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel pnlStatusRight;
        private System.Windows.Forms.Panel pnlStatusRightTop;
        private Framework.SmartControls.SmartLabel lblStatusRight;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel pnlStatusCenter;
        private System.Windows.Forms.Panel pnlStatusCenterTop;
        private Framework.SmartControls.SmartLabel lblStatusCenter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pnlStatusLeft;
        private System.Windows.Forms.Panel pnlStatusLeftTop;
        private Framework.SmartControls.SmartLabel lblStatusLeft;
        private System.Windows.Forms.Panel pnlGrid;
        private Framework.SmartControls.SmartBandedGrid grdConsumable;
        private Framework.SmartControls.SmartLabel lblEndCnt;
        private Framework.SmartControls.SmartLabel lblProcessCnt;
        private Framework.SmartControls.SmartLabel lblWaitCnt;
    }
}
namespace Micube.SmartMES.Process
{
    partial class Repair
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
            this.grdWorkorder = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartSpliterContainer2 = new Micube.Framework.SmartControls.SmartSpliterContainer();
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            this.memDescription = new Micube.Framework.SmartControls.SmartMemoEdit();
            this.smartPanel3 = new Micube.Framework.SmartControls.SmartPanel();
            this.spnWorkTime = new DevExpress.XtraEditors.SpinEdit();
            this.smartLabel5 = new Micube.Framework.SmartControls.SmartLabel();
            this.spnLeadTime = new DevExpress.XtraEditors.SpinEdit();
            this.smartLabel4 = new Micube.Framework.SmartControls.SmartLabel();
            this.smartLabel3 = new Micube.Framework.SmartControls.SmartLabel();
            this.smartLabel2 = new Micube.Framework.SmartControls.SmartLabel();
            this.dtpTrackOutTime = new System.Windows.Forms.DateTimePicker();
            this.smartLabel1 = new Micube.Framework.SmartControls.SmartLabel();
            this.dtpTrackInTime = new System.Windows.Forms.DateTimePicker();
            this.smartPanel4 = new Micube.Framework.SmartControls.SmartPanel();
            this.grdUser = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.grdMaterial = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.chkLabel = new Micube.Framework.SmartControls.SmartCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).BeginInit();
            this.smartSpliterContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer2)).BeginInit();
            this.smartSpliterContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            this.smartPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).BeginInit();
            this.smartPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnWorkTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnLeadTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel4)).BeginInit();
            this.smartPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLabel.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Size = new System.Drawing.Size(371, 839);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(1219, 30);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.smartSpliterContainer1);
            this.pnlContent.Size = new System.Drawing.Size(1219, 842);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(1600, 878);
            // 
            // smartSpliterContainer1
            // 
            this.smartSpliterContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSpliterContainer1.Horizontal = false;
            this.smartSpliterContainer1.Location = new System.Drawing.Point(0, 0);
            this.smartSpliterContainer1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterContainer1.Name = "smartSpliterContainer1";
            this.smartSpliterContainer1.Panel1.Controls.Add(this.chkLabel);
            this.smartSpliterContainer1.Panel1.Controls.Add(this.grdWorkorder);
            this.smartSpliterContainer1.Panel1.Text = "Panel1";
            this.smartSpliterContainer1.Panel2.Controls.Add(this.smartSpliterContainer2);
            this.smartSpliterContainer1.Panel2.Text = "Panel2";
            this.smartSpliterContainer1.Size = new System.Drawing.Size(1219, 842);
            this.smartSpliterContainer1.SplitterPosition = 298;
            this.smartSpliterContainer1.TabIndex = 1;
            this.smartSpliterContainer1.Text = "smartSpliterContainer1";
            // 
            // grdWorkorder
            // 
            this.grdWorkorder.Caption = "작업지시 리스트";
            this.grdWorkorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWorkorder.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdWorkorder.IsUsePaging = false;
            this.grdWorkorder.LanguageKey = "WORKORDERINFO";
            this.grdWorkorder.Location = new System.Drawing.Point(0, 0);
            this.grdWorkorder.Margin = new System.Windows.Forms.Padding(0);
            this.grdWorkorder.Name = "grdWorkorder";
            this.grdWorkorder.ShowBorder = true;
            this.grdWorkorder.Size = new System.Drawing.Size(1219, 298);
            this.grdWorkorder.TabIndex = 0;
            this.grdWorkorder.UseAutoBestFitColumns = false;
            // 
            // smartSpliterContainer2
            // 
            this.smartSpliterContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSpliterContainer2.Location = new System.Drawing.Point(0, 0);
            this.smartSpliterContainer2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterContainer2.Name = "smartSpliterContainer2";
            this.smartSpliterContainer2.Panel1.Controls.Add(this.smartPanel1);
            this.smartSpliterContainer2.Panel1.Controls.Add(this.smartPanel4);
            this.smartSpliterContainer2.Panel1.Text = "Panel1";
            this.smartSpliterContainer2.Panel2.Controls.Add(this.grdMaterial);
            this.smartSpliterContainer2.Panel2.Text = "Panel2";
            this.smartSpliterContainer2.Size = new System.Drawing.Size(1219, 538);
            this.smartSpliterContainer2.SplitterPosition = 559;
            this.smartSpliterContainer2.TabIndex = 0;
            this.smartSpliterContainer2.Text = "smartSpliterContainer2";
            // 
            // smartPanel1
            // 
            this.smartPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.smartPanel1.Appearance.Options.UseBackColor = true;
            this.smartPanel1.Controls.Add(this.smartPanel2);
            this.smartPanel1.Controls.Add(this.smartPanel3);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(257, 538);
            this.smartPanel1.TabIndex = 8;
            // 
            // smartPanel2
            // 
            this.smartPanel2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.smartPanel2.Appearance.Options.UseBackColor = true;
            this.smartPanel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel2.Controls.Add(this.memDescription);
            this.smartPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartPanel2.Location = new System.Drawing.Point(2, 135);
            this.smartPanel2.Name = "smartPanel2";
            this.smartPanel2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.smartPanel2.Size = new System.Drawing.Size(253, 401);
            this.smartPanel2.TabIndex = 1;
            // 
            // memDescription
            // 
            this.memDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memDescription.Location = new System.Drawing.Point(5, 0);
            this.memDescription.Margin = new System.Windows.Forms.Padding(0);
            this.memDescription.Name = "memDescription";
            this.memDescription.Size = new System.Drawing.Size(243, 396);
            this.memDescription.TabIndex = 10;
            // 
            // smartPanel3
            // 
            this.smartPanel3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel3.Controls.Add(this.spnWorkTime);
            this.smartPanel3.Controls.Add(this.smartLabel5);
            this.smartPanel3.Controls.Add(this.spnLeadTime);
            this.smartPanel3.Controls.Add(this.smartLabel4);
            this.smartPanel3.Controls.Add(this.smartLabel3);
            this.smartPanel3.Controls.Add(this.smartLabel2);
            this.smartPanel3.Controls.Add(this.dtpTrackOutTime);
            this.smartPanel3.Controls.Add(this.smartLabel1);
            this.smartPanel3.Controls.Add(this.dtpTrackInTime);
            this.smartPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel3.Location = new System.Drawing.Point(2, 2);
            this.smartPanel3.Name = "smartPanel3";
            this.smartPanel3.Size = new System.Drawing.Size(253, 133);
            this.smartPanel3.TabIndex = 2;
            // 
            // spnWorkTime
            // 
            this.spnWorkTime.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnWorkTime.Location = new System.Drawing.Point(86, 85);
            this.spnWorkTime.Name = "spnWorkTime";
            this.spnWorkTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnWorkTime.Size = new System.Drawing.Size(160, 24);
            this.spnWorkTime.TabIndex = 21;
            // 
            // smartLabel5
            // 
            this.smartLabel5.LanguageKey = "WORKTIMEHOUR";
            this.smartLabel5.Location = new System.Drawing.Point(8, 88);
            this.smartLabel5.Name = "smartLabel5";
            this.smartLabel5.Size = new System.Drawing.Size(52, 18);
            this.smartLabel5.TabIndex = 20;
            this.smartLabel5.Text = "작업시간";
            // 
            // spnLeadTime
            // 
            this.spnLeadTime.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnLeadTime.Location = new System.Drawing.Point(86, 59);
            this.spnLeadTime.Name = "spnLeadTime";
            this.spnLeadTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnLeadTime.Properties.ReadOnly = true;
            this.spnLeadTime.Size = new System.Drawing.Size(160, 24);
            this.spnLeadTime.TabIndex = 19;
            // 
            // smartLabel4
            // 
            this.smartLabel4.LanguageKey = "COMMENT";
            this.smartLabel4.Location = new System.Drawing.Point(8, 114);
            this.smartLabel4.Name = "smartLabel4";
            this.smartLabel4.Size = new System.Drawing.Size(52, 18);
            this.smartLabel4.TabIndex = 16;
            this.smartLabel4.Text = "특이사항";
            // 
            // smartLabel3
            // 
            this.smartLabel3.LanguageKey = "LEADTIMEBYHOUR";
            this.smartLabel3.Location = new System.Drawing.Point(8, 62);
            this.smartLabel3.Name = "smartLabel3";
            this.smartLabel3.Size = new System.Drawing.Size(52, 18);
            this.smartLabel3.TabIndex = 17;
            this.smartLabel3.Text = "리드타임";
            // 
            // smartLabel2
            // 
            this.smartLabel2.LanguageKey = "TRACKOUTTIME";
            this.smartLabel2.Location = new System.Drawing.Point(8, 36);
            this.smartLabel2.Name = "smartLabel2";
            this.smartLabel2.Size = new System.Drawing.Size(52, 18);
            this.smartLabel2.TabIndex = 18;
            this.smartLabel2.Text = "완료일시";
            // 
            // dtpTrackOutTime
            // 
            this.dtpTrackOutTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpTrackOutTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTrackOutTime.Location = new System.Drawing.Point(86, 33);
            this.dtpTrackOutTime.Name = "dtpTrackOutTime";
            this.dtpTrackOutTime.Size = new System.Drawing.Size(160, 26);
            this.dtpTrackOutTime.TabIndex = 15;
            // 
            // smartLabel1
            // 
            this.smartLabel1.LanguageKey = "TRACKINTIME";
            this.smartLabel1.Location = new System.Drawing.Point(8, 8);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Size = new System.Drawing.Size(52, 18);
            this.smartLabel1.TabIndex = 14;
            this.smartLabel1.Text = "시작일시";
            // 
            // dtpTrackInTime
            // 
            this.dtpTrackInTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpTrackInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTrackInTime.Location = new System.Drawing.Point(86, 5);
            this.dtpTrackInTime.Name = "dtpTrackInTime";
            this.dtpTrackInTime.Size = new System.Drawing.Size(160, 26);
            this.dtpTrackInTime.TabIndex = 13;
            // 
            // smartPanel4
            // 
            this.smartPanel4.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.smartPanel4.Appearance.Options.UseBackColor = true;
            this.smartPanel4.Controls.Add(this.grdUser);
            this.smartPanel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.smartPanel4.Location = new System.Drawing.Point(257, 0);
            this.smartPanel4.Name = "smartPanel4";
            this.smartPanel4.Padding = new System.Windows.Forms.Padding(5);
            this.smartPanel4.Size = new System.Drawing.Size(302, 538);
            this.smartPanel4.TabIndex = 10;
            // 
            // grdUser
            // 
            this.grdUser.Caption = "사용자 선택";
            this.grdUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUser.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdUser.IsUsePaging = false;
            this.grdUser.LanguageKey = "SELECTUSER";
            this.grdUser.Location = new System.Drawing.Point(7, 7);
            this.grdUser.Margin = new System.Windows.Forms.Padding(0);
            this.grdUser.Name = "grdUser";
            this.grdUser.ShowBorder = true;
            this.grdUser.Size = new System.Drawing.Size(288, 524);
            this.grdUser.TabIndex = 10;
            this.grdUser.UseAutoBestFitColumns = false;
            // 
            // grdMaterial
            // 
            this.grdMaterial.Caption = "자재 LOT 리스트";
            this.grdMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMaterial.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdMaterial.IsUsePaging = false;
            this.grdMaterial.LanguageKey = "CONSUMABLELOTLIST";
            this.grdMaterial.Location = new System.Drawing.Point(0, 0);
            this.grdMaterial.Margin = new System.Windows.Forms.Padding(0);
            this.grdMaterial.Name = "grdMaterial";
            this.grdMaterial.ShowBorder = true;
            this.grdMaterial.Size = new System.Drawing.Size(654, 538);
            this.grdMaterial.TabIndex = 2;
            this.grdMaterial.UseAutoBestFitColumns = false;
            // 
            // chkLabel
            // 
            this.chkLabel.LanguageKey = "PRINTLABEL";
            this.chkLabel.Location = new System.Drawing.Point(10, 276);
            this.chkLabel.Name = "chkLabel";
            this.chkLabel.Properties.Caption = "라벨출력";
            this.chkLabel.Size = new System.Drawing.Size(113, 22);
            this.chkLabel.TabIndex = 2;
            // 
            // Repair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1638, 916);
            this.Name = "Repair";
            this.Padding = new System.Windows.Forms.Padding(19, 19, 19, 19);
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).EndInit();
            this.smartSpliterContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer2)).EndInit();
            this.smartSpliterContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            this.smartPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).EndInit();
            this.smartPanel3.ResumeLayout(false);
            this.smartPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnWorkTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnLeadTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel4)).EndInit();
            this.smartPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkLabel.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer1;
        private Framework.SmartControls.SmartBandedGrid grdWorkorder;
        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer2;
        private Framework.SmartControls.SmartBandedGrid grdMaterial;
        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartMemoEdit memDescription;
        private Framework.SmartControls.SmartPanel smartPanel3;
        private Framework.SmartControls.SmartLabel smartLabel4;
        private Framework.SmartControls.SmartLabel smartLabel3;
        private Framework.SmartControls.SmartLabel smartLabel2;
        private System.Windows.Forms.DateTimePicker dtpTrackOutTime;
        private Framework.SmartControls.SmartLabel smartLabel1;
        private System.Windows.Forms.DateTimePicker dtpTrackInTime;
        private Framework.SmartControls.SmartPanel smartPanel4;
        private Framework.SmartControls.SmartBandedGrid grdUser;
        private DevExpress.XtraEditors.SpinEdit spnLeadTime;
        private DevExpress.XtraEditors.SpinEdit spnWorkTime;
        private Framework.SmartControls.SmartLabel smartLabel5;
        private Framework.SmartControls.SmartCheckBox chkLabel;
    }
}
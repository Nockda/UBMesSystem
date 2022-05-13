namespace Micube.SmartMES.DashBoard
{
    partial class DashBoardMain
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
            this.btnConsumable = new Micube.Framework.SmartControls.SmartButton();
            this.btnWorkResult = new Micube.Framework.SmartControls.SmartButton();
            this.lblMainTitle = new Micube.Framework.SmartControls.SmartLabel();
            this.cboArea = new Micube.Framework.SmartControls.SmartComboBox();
            this.btnAllWorkStatus = new Micube.Framework.SmartControls.SmartButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtTimer = new Micube.Framework.SmartControls.SmartLabelTextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnTotalStatus_eng = new Micube.Framework.SmartControls.SmartButton();
            this.btnTotalStatus_kor = new Micube.Framework.SmartControls.SmartButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboArea.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimer.Properties)).BeginInit();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(0, 36);
            this.pnlCondition.Size = new System.Drawing.Size(0, 0);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(1502, 30);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Appearance.Options.UseImage = true;
            this.pnlContent.Controls.Add(this.panel6);
            this.pnlContent.Controls.Add(this.tableLayoutPanel1);
            this.pnlContent.Size = new System.Drawing.Size(1502, 778);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(1502, 814);
            // 
            // btnConsumable
            // 
            this.btnConsumable.AllowFocus = false;
            this.btnConsumable.Appearance.Font = new System.Drawing.Font("Tahoma", 42F);
            this.btnConsumable.Appearance.Options.UseFont = true;
            this.btnConsumable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConsumable.IsBusy = false;
            this.btnConsumable.IsWrite = false;
            this.btnConsumable.Location = new System.Drawing.Point(0, 40);
            this.btnConsumable.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnConsumable.Name = "btnConsumable";
            this.btnConsumable.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnConsumable.Size = new System.Drawing.Size(456, 286);
            this.btnConsumable.TabIndex = 0;
            this.btnConsumable.Text = "자재 입/출고 현황";
            this.btnConsumable.TooltipLanguageKey = "";
            // 
            // btnWorkResult
            // 
            this.btnWorkResult.AllowFocus = false;
            this.btnWorkResult.Appearance.Font = new System.Drawing.Font("Tahoma", 42F);
            this.btnWorkResult.Appearance.Options.UseFont = true;
            this.btnWorkResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnWorkResult.IsBusy = false;
            this.btnWorkResult.IsWrite = false;
            this.btnWorkResult.Location = new System.Drawing.Point(0, 18);
            this.btnWorkResult.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnWorkResult.Name = "btnWorkResult";
            this.btnWorkResult.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnWorkResult.Size = new System.Drawing.Size(476, 284);
            this.btnWorkResult.TabIndex = 0;
            this.btnWorkResult.Text = "생산 현황";
            this.btnWorkResult.TooltipLanguageKey = "";
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 38F, System.Drawing.FontStyle.Bold);
            this.lblMainTitle.Appearance.ForeColor = System.Drawing.Color.PapayaWhip;
            this.lblMainTitle.Appearance.Options.UseFont = true;
            this.lblMainTitle.Appearance.Options.UseForeColor = true;
            this.lblMainTitle.Appearance.Options.UseTextOptions = true;
            this.lblMainTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblMainTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tableLayoutPanel1.SetColumnSpan(this.lblMainTitle, 2);
            this.lblMainTitle.Location = new System.Drawing.Point(23, 23);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(958, 77);
            this.lblMainTitle.TabIndex = 2;
            this.lblMainTitle.Text = "DashBoard";
            // 
            // cboArea
            // 
            this.cboArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboArea.LabelText = null;
            this.cboArea.LanguageKey = null;
            this.cboArea.Location = new System.Drawing.Point(0, 0);
            this.cboArea.Name = "cboArea";
            this.cboArea.PopupWidth = 0;
            this.cboArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboArea.Properties.NullText = "";
            this.cboArea.ShowHeader = true;
            this.cboArea.Size = new System.Drawing.Size(476, 24);
            this.cboArea.TabIndex = 3;
            this.cboArea.VisibleColumns = null;
            this.cboArea.VisibleColumnsWidth = null;
            // 
            // btnAllWorkStatus
            // 
            this.btnAllWorkStatus.AllowFocus = false;
            this.btnAllWorkStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 42F);
            this.btnAllWorkStatus.Appearance.Options.UseFont = true;
            this.btnAllWorkStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAllWorkStatus.IsBusy = false;
            this.btnAllWorkStatus.IsWrite = false;
            this.btnAllWorkStatus.Location = new System.Drawing.Point(20, 40);
            this.btnAllWorkStatus.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnAllWorkStatus.Name = "btnAllWorkStatus";
            this.btnAllWorkStatus.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnAllWorkStatus.Size = new System.Drawing.Size(472, 286);
            this.btnAllWorkStatus.TabIndex = 4;
            this.btnAllWorkStatus.Text = "전체 생산 현황";
            this.btnAllWorkStatus.TooltipLanguageKey = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMainTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1502, 455);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnConsumable);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(23, 106);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 40, 20, 0);
            this.panel2.Size = new System.Drawing.Size(476, 326);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.cboArea);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(505, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 326);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnWorkResult);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 24);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 18, 0, 0);
            this.panel4.Size = new System.Drawing.Size(476, 302);
            this.panel4.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAllWorkStatus);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(987, 106);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(20, 40, 0, 0);
            this.panel3.Size = new System.Drawing.Size(492, 326);
            this.panel3.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtTimer);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(987, 23);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(492, 77);
            this.panel5.TabIndex = 4;
            // 
            // txtTimer
            // 
            this.txtTimer.Appearance.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.txtTimer.Appearance.Options.UseForeColor = true;
            this.txtTimer.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtTimer.LabelText = "화면 갱신주기(초)";
            this.txtTimer.LanguageKey = null;
            this.txtTimer.Location = new System.Drawing.Point(209, 0);
            this.txtTimer.Name = "txtTimer";
            this.txtTimer.Properties.NullText = "5";
            this.txtTimer.Size = new System.Drawing.Size(283, 24);
            this.txtTimer.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tableLayoutPanel2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 455);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1502, 255);
            this.panel6.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnTotalStatus_eng, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnTotalStatus_kor, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 235F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1502, 255);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnTotalStatus_eng
            // 
            this.btnTotalStatus_eng.AllowFocus = false;
            this.btnTotalStatus_eng.Appearance.Font = new System.Drawing.Font("Tahoma", 42F);
            this.btnTotalStatus_eng.Appearance.Options.UseFont = true;
            this.btnTotalStatus_eng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTotalStatus_eng.IsBusy = false;
            this.btnTotalStatus_eng.IsWrite = false;
            this.btnTotalStatus_eng.Location = new System.Drawing.Point(754, 0);
            this.btnTotalStatus_eng.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnTotalStatus_eng.Name = "btnTotalStatus_eng";
            this.btnTotalStatus_eng.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnTotalStatus_eng.Size = new System.Drawing.Size(725, 235);
            this.btnTotalStatus_eng.TabIndex = 2;
            this.btnTotalStatus_eng.Text = "제조 종합 현황(ENG)";
            this.btnTotalStatus_eng.TooltipLanguageKey = "";
            // 
            // btnTotalStatus_kor
            // 
            this.btnTotalStatus_kor.AllowFocus = false;
            this.btnTotalStatus_kor.Appearance.Font = new System.Drawing.Font("Tahoma", 42F);
            this.btnTotalStatus_kor.Appearance.Options.UseFont = true;
            this.btnTotalStatus_kor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTotalStatus_kor.IsBusy = false;
            this.btnTotalStatus_kor.IsWrite = false;
            this.btnTotalStatus_kor.Location = new System.Drawing.Point(23, 0);
            this.btnTotalStatus_kor.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnTotalStatus_kor.Name = "btnTotalStatus_kor";
            this.btnTotalStatus_kor.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnTotalStatus_kor.Size = new System.Drawing.Size(725, 235);
            this.btnTotalStatus_kor.TabIndex = 1;
            this.btnTotalStatus_kor.Text = "제조 종합 현황(KOR)";
            this.btnTotalStatus_kor.TooltipLanguageKey = "";
            // 
            // DashBoardMain
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1540, 852);
            this.ConditionsVisible = false;
            this.Name = "DashBoardMain";
            this.Padding = new System.Windows.Forms.Padding(19, 19, 19, 19);
            this.Text = "DashBoard";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboArea.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTimer.Properties)).EndInit();
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartButton btnWorkResult;
        private Framework.SmartControls.SmartButton btnConsumable;
        private Framework.SmartControls.SmartLabel lblMainTitle;
        private Framework.SmartControls.SmartComboBox cboArea;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private Framework.SmartControls.SmartButton btnAllWorkStatus;
        private System.Windows.Forms.Panel panel5;
        private Framework.SmartControls.SmartLabelTextBox txtTimer;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Framework.SmartControls.SmartButton btnTotalStatus_kor;
        private Framework.SmartControls.SmartButton btnTotalStatus_eng;
    }
}
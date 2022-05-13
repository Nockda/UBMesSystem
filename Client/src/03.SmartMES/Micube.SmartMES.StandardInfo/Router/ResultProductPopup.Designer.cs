namespace Micube.SmartMES.StandardInfo
{
    partial class ResultProductPopup
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
            this.smartButton4 = new Micube.Framework.SmartControls.SmartButton();
            this.smartButton5 = new Micube.Framework.SmartControls.SmartButton();
            this.smartSplitTableLayoutPanel1 = new Micube.Framework.SmartControls.SmartSplitTableLayoutPanel();
            this.smartLabel1 = new Micube.Framework.SmartControls.SmartLabel();
            this.smartTextBox1 = new Micube.Framework.SmartControls.SmartTextBox();
            this.grdInfo = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).BeginInit();
            this.smartPanel3.SuspendLayout();
            this.smartSplitTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartTextBox1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grdInfo);
            this.pnlMain.Controls.Add(this.smartSplitTableLayoutPanel1);
            this.pnlMain.Controls.Add(this.smartPanel3);
            // 
            // smartPanel3
            // 
            this.smartPanel3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel3.Controls.Add(this.smartButton4);
            this.smartPanel3.Controls.Add(this.smartButton5);
            this.smartPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel3.Location = new System.Drawing.Point(0, 390);
            this.smartPanel3.Name = "smartPanel3";
            this.smartPanel3.Size = new System.Drawing.Size(780, 40);
            this.smartPanel3.TabIndex = 5;
            // 
            // smartButton4
            // 
            this.smartButton4.AllowFocus = false;
            this.smartButton4.IsBusy = false;
            this.smartButton4.IsWrite = false;
            this.smartButton4.Location = new System.Drawing.Point(611, 9);
            this.smartButton4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.smartButton4.Name = "smartButton4";
            this.smartButton4.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.smartButton4.Size = new System.Drawing.Size(80, 25);
            this.smartButton4.TabIndex = 2;
            this.smartButton4.Text = "저장";
            this.smartButton4.TooltipLanguageKey = "";
            // 
            // smartButton5
            // 
            this.smartButton5.AllowFocus = false;
            this.smartButton5.IsBusy = false;
            this.smartButton5.IsWrite = false;
            this.smartButton5.Location = new System.Drawing.Point(697, 9);
            this.smartButton5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.smartButton5.Name = "smartButton5";
            this.smartButton5.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.smartButton5.Size = new System.Drawing.Size(80, 25);
            this.smartButton5.TabIndex = 1;
            this.smartButton5.Text = "취소";
            this.smartButton5.TooltipLanguageKey = "";
            // 
            // smartSplitTableLayoutPanel1
            // 
            this.smartSplitTableLayoutPanel1.ColumnCount = 3;
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.smartSplitTableLayoutPanel1.Controls.Add(this.smartLabel1, 0, 0);
            this.smartSplitTableLayoutPanel1.Controls.Add(this.smartTextBox1, 1, 0);
            this.smartSplitTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartSplitTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartSplitTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSplitTableLayoutPanel1.Name = "smartSplitTableLayoutPanel1";
            this.smartSplitTableLayoutPanel1.RowCount = 1;
            this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.smartSplitTableLayoutPanel1.Size = new System.Drawing.Size(780, 30);
            this.smartSplitTableLayoutPanel1.TabIndex = 6;
            // 
            // smartLabel1
            // 
            this.smartLabel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.smartLabel1.Location = new System.Drawing.Point(33, 3);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Size = new System.Drawing.Size(42, 14);
            this.smartLabel1.TabIndex = 0;
            this.smartLabel1.Text = "SUB공정";
            // 
            // smartTextBox1
            // 
            this.smartTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartTextBox1.LabelText = null;
            this.smartTextBox1.LanguageKey = null;
            this.smartTextBox1.Location = new System.Drawing.Point(81, 3);
            this.smartTextBox1.Name = "smartTextBox1";
            this.smartTextBox1.Size = new System.Drawing.Size(189, 20);
            this.smartTextBox1.TabIndex = 2;
            // 
            // grdInfo
            // 
            this.grdInfo.Caption = "실적 입력항목 관리";
            this.grdInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInfo.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdInfo.IsUsePaging = false;
            this.grdInfo.LanguageKey = null;
            this.grdInfo.Location = new System.Drawing.Point(0, 30);
            this.grdInfo.Margin = new System.Windows.Forms.Padding(0);
            this.grdInfo.Name = "grdInfo";
            this.grdInfo.ShowBorder = true;
            this.grdInfo.Size = new System.Drawing.Size(780, 360);
            this.grdInfo.TabIndex = 7;
            // 
            // ResultProductPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "ResultProductPopup";
            this.Text = "ResultProductPopup";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).EndInit();
            this.smartPanel3.ResumeLayout(false);
            this.smartSplitTableLayoutPanel1.ResumeLayout(false);
            this.smartSplitTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartTextBox1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.SmartControls.SmartPanel smartPanel3;
        private Framework.SmartControls.SmartButton smartButton4;
        private Framework.SmartControls.SmartButton smartButton5;
        private Framework.SmartControls.SmartSplitTableLayoutPanel smartSplitTableLayoutPanel1;
        private Framework.SmartControls.SmartLabel smartLabel1;
        private Framework.SmartControls.SmartTextBox smartTextBox1;
        private Framework.SmartControls.SmartBandedGrid grdInfo;
    }
}
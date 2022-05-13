namespace Micube.SmartMES.StandardInfo
{
    partial class RouterProcessing
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
            this.grdMaster = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartSpliterContainer2 = new Micube.Framework.SmartControls.SmartSpliterContainer();
            this.grdItem = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnSaveItem = new Micube.Framework.SmartControls.SmartButton();
            this.smartPanel3 = new Micube.Framework.SmartControls.SmartPanel();
            this.grdResult = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnSaveResult = new Micube.Framework.SmartControls.SmartButton();
            this.smartPanel4 = new Micube.Framework.SmartControls.SmartPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).BeginInit();
            this.smartSpliterContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer2)).BeginInit();
            this.smartSpliterContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            this.smartPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel4)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(2, 31);
            this.pnlCondition.Size = new System.Drawing.Size(296, 491);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(939, 24);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.smartSpliterContainer1);
            this.pnlContent.Size = new System.Drawing.Size(939, 495);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(1244, 524);
            // 
            // smartSpliterContainer1
            // 
            this.smartSpliterContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSpliterContainer1.Horizontal = false;
            this.smartSpliterContainer1.Location = new System.Drawing.Point(0, 0);
            this.smartSpliterContainer1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterContainer1.Name = "smartSpliterContainer1";
            this.smartSpliterContainer1.Panel1.Controls.Add(this.grdMaster);
            this.smartSpliterContainer1.Panel1.Text = "Panel1";
            this.smartSpliterContainer1.Panel2.Controls.Add(this.smartSpliterContainer2);
            this.smartSpliterContainer1.Panel2.Text = "Panel2";
            this.smartSpliterContainer1.Size = new System.Drawing.Size(939, 495);
            this.smartSpliterContainer1.SplitterPosition = 300;
            this.smartSpliterContainer1.TabIndex = 0;
            this.smartSpliterContainer1.Text = "smartSpliterContainer1";
            // 
            // grdMaster
            // 
            this.grdMaster.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMaster.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdMaster.IsUsePaging = false;
            this.grdMaster.LanguageKey = null;
            this.grdMaster.Location = new System.Drawing.Point(0, 0);
            this.grdMaster.Margin = new System.Windows.Forms.Padding(0);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ShowBorder = true;
            this.grdMaster.Size = new System.Drawing.Size(939, 300);
            this.grdMaster.TabIndex = 0;
            // 
            // smartSpliterContainer2
            // 
            this.smartSpliterContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartSpliterContainer2.Location = new System.Drawing.Point(0, 0);
            this.smartSpliterContainer2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterContainer2.Name = "smartSpliterContainer2";
            this.smartSpliterContainer2.Panel1.Controls.Add(this.grdItem);
            this.smartSpliterContainer2.Panel1.Controls.Add(this.smartPanel1);
            this.smartSpliterContainer2.Panel1.Text = "Panel1";
            this.smartSpliterContainer2.Panel2.Controls.Add(this.grdResult);
            this.smartSpliterContainer2.Panel2.Controls.Add(this.smartPanel2);
            this.smartSpliterContainer2.Panel2.Text = "Panel2";
            this.smartSpliterContainer2.Size = new System.Drawing.Size(939, 190);
            this.smartSpliterContainer2.SplitterPosition = 650;
            this.smartSpliterContainer2.TabIndex = 0;
            this.smartSpliterContainer2.Text = "smartSpliterContainer2";
            // 
            // grdItem
            // 
            this.grdItem.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItem.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdItem.IsUsePaging = false;
            this.grdItem.LanguageKey = null;
            this.grdItem.Location = new System.Drawing.Point(0, 35);
            this.grdItem.Margin = new System.Windows.Forms.Padding(0);
            this.grdItem.Name = "grdItem";
            this.grdItem.ShowBorder = true;
            this.grdItem.Size = new System.Drawing.Size(650, 155);
            this.grdItem.TabIndex = 1;
            // 
            // smartPanel1
            // 
            this.smartPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel1.Controls.Add(this.btnSaveItem);
            this.smartPanel1.Controls.Add(this.smartPanel3);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(650, 35);
            this.smartPanel1.TabIndex = 0;
            // 
            // btnSaveItem
            // 
            this.btnSaveItem.AllowFocus = false;
            this.btnSaveItem.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSaveItem.IsBusy = false;
            this.btnSaveItem.IsWrite = false;
            this.btnSaveItem.LanguageKey = "SAVE";
            this.btnSaveItem.Location = new System.Drawing.Point(571, 0);
            this.btnSaveItem.Margin = new System.Windows.Forms.Padding(0);
            this.btnSaveItem.Name = "btnSaveItem";
            this.btnSaveItem.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSaveItem.Size = new System.Drawing.Size(79, 25);
            this.btnSaveItem.TabIndex = 2;
            this.btnSaveItem.Text = "smartButton1";
            this.btnSaveItem.TooltipLanguageKey = "";
            // 
            // smartPanel3
            // 
            this.smartPanel3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel3.Location = new System.Drawing.Point(0, 25);
            this.smartPanel3.Name = "smartPanel3";
            this.smartPanel3.Size = new System.Drawing.Size(650, 10);
            this.smartPanel3.TabIndex = 0;
            // 
            // grdResult
            // 
            this.grdResult.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResult.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdResult.IsUsePaging = false;
            this.grdResult.LanguageKey = null;
            this.grdResult.Location = new System.Drawing.Point(0, 35);
            this.grdResult.Margin = new System.Windows.Forms.Padding(0);
            this.grdResult.Name = "grdResult";
            this.grdResult.ShowBorder = true;
            this.grdResult.Size = new System.Drawing.Size(284, 155);
            this.grdResult.TabIndex = 2;
            // 
            // smartPanel2
            // 
            this.smartPanel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel2.Controls.Add(this.btnSaveResult);
            this.smartPanel2.Controls.Add(this.smartPanel4);
            this.smartPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel2.Location = new System.Drawing.Point(0, 0);
            this.smartPanel2.Name = "smartPanel2";
            this.smartPanel2.Size = new System.Drawing.Size(284, 35);
            this.smartPanel2.TabIndex = 1;
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.AllowFocus = false;
            this.btnSaveResult.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSaveResult.IsBusy = false;
            this.btnSaveResult.IsWrite = false;
            this.btnSaveResult.LanguageKey = "SAVE";
            this.btnSaveResult.Location = new System.Drawing.Point(205, 0);
            this.btnSaveResult.Margin = new System.Windows.Forms.Padding(0);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSaveResult.Size = new System.Drawing.Size(79, 25);
            this.btnSaveResult.TabIndex = 2;
            this.btnSaveResult.Text = "smartButton1";
            this.btnSaveResult.TooltipLanguageKey = "";
            // 
            // smartPanel4
            // 
            this.smartPanel4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel4.Location = new System.Drawing.Point(0, 25);
            this.smartPanel4.Name = "smartPanel4";
            this.smartPanel4.Size = new System.Drawing.Size(284, 10);
            this.smartPanel4.TabIndex = 1;
            // 
            // RouterProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 544);
            this.Name = "RouterProcessing";
            this.Text = "RouterProcessing";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).EndInit();
            this.smartSpliterContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer2)).EndInit();
            this.smartSpliterContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            this.smartPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer1;
        private Framework.SmartControls.SmartBandedGrid grdMaster;
        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer2;
        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartPanel smartPanel3;
        private Framework.SmartControls.SmartPanel smartPanel4;
        private Framework.SmartControls.SmartBandedGrid grdItem;
        private Framework.SmartControls.SmartButton btnSaveItem;
        private Framework.SmartControls.SmartBandedGrid grdResult;
        private Framework.SmartControls.SmartButton btnSaveResult;
    }
}
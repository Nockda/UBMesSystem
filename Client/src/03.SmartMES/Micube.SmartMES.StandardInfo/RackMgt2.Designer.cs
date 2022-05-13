namespace Micube.SmartMES.StandardInfo
{
    partial class RackMgt2
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
            this.smartSpliterContainer1 = new Micube.Framework.SmartControls.SmartSpliterContainer();
            this.grdItem = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnSaveItem = new Micube.Framework.SmartControls.SmartButton();
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            this.grdMaster = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).BeginInit();
            this.smartSpliterContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Size = new System.Drawing.Size(371, 373);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(381, 30);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.smartSpliterContainer1);
            this.pnlContent.Size = new System.Drawing.Size(381, 376);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(762, 412);
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
            this.smartSpliterContainer1.Panel2.Controls.Add(this.grdItem);
            this.smartSpliterContainer1.Panel2.Controls.Add(this.smartPanel1);
            this.smartSpliterContainer1.Panel2.Text = "Panel2";
            this.smartSpliterContainer1.Size = new System.Drawing.Size(381, 376);
            this.smartSpliterContainer1.SplitterPosition = 300;
            this.smartSpliterContainer1.TabIndex = 1;
            this.smartSpliterContainer1.Text = "smartSpliterContainer1";
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
            this.grdItem.Size = new System.Drawing.Size(381, 35);
            this.grdItem.TabIndex = 1;
            // 
            // smartPanel1
            // 
            this.smartPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel1.Controls.Add(this.btnSaveItem);
            this.smartPanel1.Controls.Add(this.smartPanel2);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(381, 35);
            this.smartPanel1.TabIndex = 0;
            // 
            // btnSaveItem
            // 
            this.btnSaveItem.AllowFocus = false;
            this.btnSaveItem.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSaveItem.IsBusy = false;
            this.btnSaveItem.IsWrite = false;
            this.btnSaveItem.LanguageKey = "SAVE";
            this.btnSaveItem.Location = new System.Drawing.Point(302, 0);
            this.btnSaveItem.Margin = new System.Windows.Forms.Padding(0);
            this.btnSaveItem.Name = "btnSaveItem";
            this.btnSaveItem.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSaveItem.Size = new System.Drawing.Size(79, 25);
            this.btnSaveItem.TabIndex = 1;
            this.btnSaveItem.Text = "smartButton1";
            this.btnSaveItem.TooltipLanguageKey = "";
            // 
            // smartPanel2
            // 
            this.smartPanel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel2.Location = new System.Drawing.Point(0, 25);
            this.smartPanel2.Name = "smartPanel2";
            this.smartPanel2.Size = new System.Drawing.Size(381, 10);
            this.smartPanel2.TabIndex = 0;
            // 
            // grdMaster
            // 
            this.grdMaster.Caption = "자재창고 RACK 정보";
            this.grdMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMaster.GridButtonItem = Micube.Framework.SmartControls.GridButtonItem.Export;
            this.grdMaster.IsUsePaging = false;
            this.grdMaster.LanguageKey = "";
            this.grdMaster.Location = new System.Drawing.Point(0, 0);
            this.grdMaster.Margin = new System.Windows.Forms.Padding(0);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ShowBorder = true;
            this.grdMaster.Size = new System.Drawing.Size(381, 300);
            this.grdMaster.TabIndex = 7;
            // 
            // RackMgt2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "RackMgt2";
            this.Padding = new System.Windows.Forms.Padding(19, 19, 19, 19);
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).EndInit();
            this.smartSpliterContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer1;
        private Framework.SmartControls.SmartBandedGrid grdItem;
        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartButton btnSaveItem;
        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartBandedGrid grdMaster;
    }
}
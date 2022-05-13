namespace Micube.SmartMES.StandardInfo
{
    partial class CellMgt
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
            this.grdMaster = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.grdItem = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnPrintCellLabel = new Micube.Framework.SmartControls.SmartButton();
            this.smartPanel3 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnSaveItem = new Micube.Framework.SmartControls.SmartButton();
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            this.smartPanel4 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnPrintKanbanLabel = new Micube.Framework.SmartControls.SmartButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).BeginInit();
            this.smartSpliterContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel4)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(2, 31);
            this.pnlCondition.Size = new System.Drawing.Size(296, 522);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(825, 24);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.smartSpliterContainer1);
            this.pnlContent.Size = new System.Drawing.Size(825, 526);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(1130, 555);
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
            this.smartSpliterContainer1.Size = new System.Drawing.Size(825, 526);
            this.smartSpliterContainer1.SplitterPosition = 393;
            this.smartSpliterContainer1.TabIndex = 1;
            this.smartSpliterContainer1.Text = "smartSpliterContainer1";
            // 
            // grdMaster
            // 
            this.grdMaster.Caption = "CELL그룹정보";
            this.grdMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMaster.GridButtonItem = Micube.Framework.SmartControls.GridButtonItem.Export;
            this.grdMaster.IsUsePaging = false;
            this.grdMaster.LanguageKey = "";
            this.grdMaster.Location = new System.Drawing.Point(0, 0);
            this.grdMaster.Margin = new System.Windows.Forms.Padding(0);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ShowBorder = true;
            this.grdMaster.Size = new System.Drawing.Size(825, 393);
            this.grdMaster.TabIndex = 7;
            this.grdMaster.UseAutoBestFitColumns = false;
            // 
            // grdItem
            // 
            this.grdItem.Caption = "CELL정보";
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
            this.grdItem.Size = new System.Drawing.Size(825, 93);
            this.grdItem.TabIndex = 1;
            this.grdItem.UseAutoBestFitColumns = false;
            // 
            // smartPanel1
            // 
            this.smartPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel1.Controls.Add(this.btnPrintKanbanLabel);
            this.smartPanel1.Controls.Add(this.smartPanel4);
            this.smartPanel1.Controls.Add(this.btnPrintCellLabel);
            this.smartPanel1.Controls.Add(this.smartPanel3);
            this.smartPanel1.Controls.Add(this.btnSaveItem);
            this.smartPanel1.Controls.Add(this.smartPanel2);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(825, 35);
            this.smartPanel1.TabIndex = 0;
            // 
            // btnPrintCellLabel
            // 
            this.btnPrintCellLabel.AllowFocus = false;
            this.btnPrintCellLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrintCellLabel.IsBusy = false;
            this.btnPrintCellLabel.IsWrite = false;
            this.btnPrintCellLabel.LanguageKey = "PRINTCELLLABEL";
            this.btnPrintCellLabel.Location = new System.Drawing.Point(657, 0);
            this.btnPrintCellLabel.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrintCellLabel.Name = "btnPrintCellLabel";
            this.btnPrintCellLabel.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnPrintCellLabel.Size = new System.Drawing.Size(79, 25);
            this.btnPrintCellLabel.TabIndex = 2;
            this.btnPrintCellLabel.Text = "CELL라벨";
            this.btnPrintCellLabel.TooltipLanguageKey = "";
            // 
            // smartPanel3
            // 
            this.smartPanel3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.smartPanel3.Appearance.Options.UseBackColor = true;
            this.smartPanel3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.smartPanel3.Location = new System.Drawing.Point(736, 0);
            this.smartPanel3.Name = "smartPanel3";
            this.smartPanel3.Size = new System.Drawing.Size(10, 25);
            this.smartPanel3.TabIndex = 3;
            // 
            // btnSaveItem
            // 
            this.btnSaveItem.AllowFocus = false;
            this.btnSaveItem.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSaveItem.IsBusy = false;
            this.btnSaveItem.IsWrite = false;
            this.btnSaveItem.LanguageKey = "SAVE";
            this.btnSaveItem.Location = new System.Drawing.Point(746, 0);
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
            this.smartPanel2.Size = new System.Drawing.Size(825, 10);
            this.smartPanel2.TabIndex = 0;
            // 
            // smartPanel4
            // 
            this.smartPanel4.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.smartPanel4.Appearance.Options.UseBackColor = true;
            this.smartPanel4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.smartPanel4.Location = new System.Drawing.Point(647, 0);
            this.smartPanel4.Name = "smartPanel4";
            this.smartPanel4.Size = new System.Drawing.Size(10, 25);
            this.smartPanel4.TabIndex = 4;
            // 
            // btnPrintKanbanLabel
            // 
            this.btnPrintKanbanLabel.AllowFocus = false;
            this.btnPrintKanbanLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrintKanbanLabel.IsBusy = false;
            this.btnPrintKanbanLabel.IsWrite = false;
            this.btnPrintKanbanLabel.LanguageKey = "PRINTKANBANLABEL";
            this.btnPrintKanbanLabel.Location = new System.Drawing.Point(568, 0);
            this.btnPrintKanbanLabel.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrintKanbanLabel.Name = "btnPrintKanbanLabel";
            this.btnPrintKanbanLabel.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnPrintKanbanLabel.Size = new System.Drawing.Size(79, 25);
            this.btnPrintKanbanLabel.TabIndex = 5;
            this.btnPrintKanbanLabel.Text = "간반라벨";
            this.btnPrintKanbanLabel.TooltipLanguageKey = "";
            // 
            // CellMgt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 593);
            this.Name = "CellMgt";
            this.Padding = new System.Windows.Forms.Padding(19);
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartSpliterContainer1)).EndInit();
            this.smartSpliterContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartSpliterContainer smartSpliterContainer1;
        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartButton btnSaveItem;
        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartBandedGrid grdMaster;
        private Framework.SmartControls.SmartBandedGrid grdItem;
        private Framework.SmartControls.SmartButton btnPrintCellLabel;
        private Framework.SmartControls.SmartPanel smartPanel3;
        private Framework.SmartControls.SmartButton btnPrintKanbanLabel;
        private Framework.SmartControls.SmartPanel smartPanel4;
    }
}
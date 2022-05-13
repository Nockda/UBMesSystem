namespace Micube.SmartMES.Material
{
    partial class CellStatus
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
            this.grdCellGroup = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartSpliterControl1 = new Micube.Framework.SmartControls.SmartSpliterControl();
            this.grdCellStatus = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(2, 31);
            this.pnlCondition.Size = new System.Drawing.Size(296, 526);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(869, 24);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.grdCellStatus);
            this.pnlContent.Controls.Add(this.smartSpliterControl1);
            this.pnlContent.Controls.Add(this.grdCellGroup);
            this.pnlContent.Size = new System.Drawing.Size(869, 530);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(1174, 559);
            // 
            // grdCellGroup
            // 
            this.grdCellGroup.Caption = "";
            this.grdCellGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdCellGroup.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdCellGroup.IsUsePaging = false;
            this.grdCellGroup.LanguageKey = "";
            this.grdCellGroup.Location = new System.Drawing.Point(0, 0);
            this.grdCellGroup.Margin = new System.Windows.Forms.Padding(0);
            this.grdCellGroup.Name = "grdCellGroup";
            this.grdCellGroup.ShowBorder = true;
            this.grdCellGroup.Size = new System.Drawing.Size(434, 530);
            this.grdCellGroup.TabIndex = 3;
            this.grdCellGroup.UseAutoBestFitColumns = false;
            // 
            // smartSpliterControl1
            // 
            this.smartSpliterControl1.Location = new System.Drawing.Point(434, 0);
            this.smartSpliterControl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterControl1.Name = "smartSpliterControl1";
            this.smartSpliterControl1.Size = new System.Drawing.Size(5, 530);
            this.smartSpliterControl1.TabIndex = 7;
            this.smartSpliterControl1.TabStop = false;
            // 
            // grdCellStatus
            // 
            this.grdCellStatus.Caption = "";
            this.grdCellStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCellStatus.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdCellStatus.IsUsePaging = false;
            this.grdCellStatus.LanguageKey = "";
            this.grdCellStatus.Location = new System.Drawing.Point(439, 0);
            this.grdCellStatus.Margin = new System.Windows.Forms.Padding(0);
            this.grdCellStatus.Name = "grdCellStatus";
            this.grdCellStatus.ShowBorder = true;
            this.grdCellStatus.Size = new System.Drawing.Size(430, 530);
            this.grdCellStatus.TabIndex = 8;
            this.grdCellStatus.UseAutoBestFitColumns = false;
            // 
            // CellStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 597);
            this.Name = "CellStatus";
            this.Padding = new System.Windows.Forms.Padding(19);
            this.Text = "Cell Status";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartBandedGrid grdCellGroup;
        private Framework.SmartControls.SmartBandedGrid grdCellStatus;
        private Framework.SmartControls.SmartSpliterControl smartSpliterControl1;
    }
}
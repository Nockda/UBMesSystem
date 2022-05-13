namespace Micube.SmartMES.Material
{
    partial class ConsumableLotSplit
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
            this.grdTargetSplitConsumableLot = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdSplitConsumableLot = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.spcSpliter = new Micube.Framework.SmartControls.SmartSpliterControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(2, 31);
            this.pnlCondition.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(441, 278, 650, 400);
            this.pnlCondition.Size = new System.Drawing.Size(296, 546);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(756, 24);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.panel1);
            this.pnlContent.Controls.Add(this.spcSpliter);
            this.pnlContent.Controls.Add(this.grdTargetSplitConsumableLot);
            this.pnlContent.Size = new System.Drawing.Size(756, 550);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(1061, 579);
            // 
            // grdTargetSplitConsumableLot
            // 
            this.grdTargetSplitConsumableLot.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdTargetSplitConsumableLot.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdTargetSplitConsumableLot.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdTargetSplitConsumableLot.IsUsePaging = false;
            this.grdTargetSplitConsumableLot.LanguageKey = "TARGETSPLITCONSUMABLELOTLIST";
            this.grdTargetSplitConsumableLot.Location = new System.Drawing.Point(0, 0);
            this.grdTargetSplitConsumableLot.Margin = new System.Windows.Forms.Padding(0);
            this.grdTargetSplitConsumableLot.Name = "grdTargetSplitConsumableLot";
            this.grdTargetSplitConsumableLot.ShowBorder = true;
            this.grdTargetSplitConsumableLot.Size = new System.Drawing.Size(756, 294);
            this.grdTargetSplitConsumableLot.TabIndex = 1;
            this.grdTargetSplitConsumableLot.UseAutoBestFitColumns = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdSplitConsumableLot);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 299);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 251);
            this.panel1.TabIndex = 4;
            // 
            // grdSplitConsumableLot
            // 
            this.grdSplitConsumableLot.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdSplitConsumableLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSplitConsumableLot.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdSplitConsumableLot.IsUsePaging = false;
            this.grdSplitConsumableLot.LanguageKey = "SPLITCONSUMABLELOTLIST";
            this.grdSplitConsumableLot.Location = new System.Drawing.Point(0, 0);
            this.grdSplitConsumableLot.Margin = new System.Windows.Forms.Padding(0);
            this.grdSplitConsumableLot.Name = "grdSplitConsumableLot";
            this.grdSplitConsumableLot.ShowBorder = true;
            this.grdSplitConsumableLot.ShowStatusBar = false;
            this.grdSplitConsumableLot.Size = new System.Drawing.Size(756, 251);
            this.grdSplitConsumableLot.TabIndex = 2;
            this.grdSplitConsumableLot.UseAutoBestFitColumns = false;
            // 
            // spcSpliter
            // 
            this.spcSpliter.Dock = System.Windows.Forms.DockStyle.Top;
            this.spcSpliter.Location = new System.Drawing.Point(0, 294);
            this.spcSpliter.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.spcSpliter.Name = "spcSpliter";
            this.spcSpliter.Size = new System.Drawing.Size(756, 5);
            this.spcSpliter.TabIndex = 7;
            this.spcSpliter.TabStop = false;
            // 
            // ConsumableLotSplit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 599);
            this.LanguageKey = "";
            this.Name = "ConsumableLotSplit";
            this.Text = "Lot Split";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartBandedGrid grdTargetSplitConsumableLot;
        private System.Windows.Forms.Panel panel1;
        private Framework.SmartControls.SmartBandedGrid grdSplitConsumableLot;
        private Framework.SmartControls.SmartSpliterControl spcSpliter;
    }
}
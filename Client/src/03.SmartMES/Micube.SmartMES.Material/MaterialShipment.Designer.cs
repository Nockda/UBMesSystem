namespace Micube.SmartMES.Material
{
    partial class MaterialShipment
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
            this.smartTabControl1 = new Micube.Framework.SmartControls.SmartTabControl();
            this.TabShip = new DevExpress.XtraTab.XtraTabPage();
            this.grdShip = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.txtConsumableLotId = new Micube.Framework.SmartControls.SmartTextBox();
            this.smartLabel1 = new Micube.Framework.SmartControls.SmartLabel();
            this.TabHistory = new DevExpress.XtraTab.XtraTabPage();
            this.grdHistory = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartTabControl1)).BeginInit();
            this.smartTabControl1.SuspendLayout();
            this.TabShip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConsumableLotId.Properties)).BeginInit();
            this.TabHistory.SuspendLayout();
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
            this.pnlContent.Controls.Add(this.smartTabControl1);
            this.pnlContent.Size = new System.Drawing.Size(381, 376);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(762, 412);
            // 
            // smartTabControl1
            // 
            this.smartTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartTabControl1.Location = new System.Drawing.Point(0, 0);
            this.smartTabControl1.Name = "smartTabControl1";
            this.smartTabControl1.SelectedTabPage = this.TabShip;
            this.smartTabControl1.Size = new System.Drawing.Size(381, 376);
            this.smartTabControl1.TabIndex = 0;
            this.smartTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.TabShip,
            this.TabHistory});
            // 
            // TabShip
            // 
            this.TabShip.Controls.Add(this.grdShip);
            this.TabShip.Controls.Add(this.smartPanel1);
            this.TabShip.Name = "TabShip";
            this.TabShip.Size = new System.Drawing.Size(374, 340);
            this.TabShip.Text = "부품출하";
            // 
            // grdShip
            // 
            this.grdShip.Caption = "";
            this.grdShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdShip.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdShip.IsUsePaging = false;
            this.grdShip.LanguageKey = null;
            this.grdShip.Location = new System.Drawing.Point(0, 36);
            this.grdShip.Margin = new System.Windows.Forms.Padding(0);
            this.grdShip.Name = "grdShip";
            this.grdShip.ShowBorder = true;
            this.grdShip.ShowStatusBar = false;
            this.grdShip.Size = new System.Drawing.Size(374, 304);
            this.grdShip.TabIndex = 3;
            this.grdShip.UseAutoBestFitColumns = false;
            // 
            // smartPanel1
            // 
            this.smartPanel1.Controls.Add(this.txtConsumableLotId);
            this.smartPanel1.Controls.Add(this.smartLabel1);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smartPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(374, 36);
            this.smartPanel1.TabIndex = 2;
            // 
            // txtConsumableLotId
            // 
            this.txtConsumableLotId.LabelText = null;
            this.txtConsumableLotId.LanguageKey = null;
            this.txtConsumableLotId.Location = new System.Drawing.Point(110, 5);
            this.txtConsumableLotId.Name = "txtConsumableLotId";
            this.txtConsumableLotId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtConsumableLotId.Properties.Appearance.Options.UseFont = true;
            this.txtConsumableLotId.Properties.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.txtConsumableLotId.Size = new System.Drawing.Size(192, 31);
            this.txtConsumableLotId.TabIndex = 14;
            // 
            // smartLabel1
            // 
            this.smartLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.smartLabel1.Appearance.Options.UseFont = true;
            this.smartLabel1.Location = new System.Drawing.Point(9, 7);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.smartLabel1.Size = new System.Drawing.Size(82, 23);
            this.smartLabel1.TabIndex = 11;
            this.smartLabel1.Text = "자재 LOT ID";
            // 
            // TabHistory
            // 
            this.TabHistory.Controls.Add(this.grdHistory);
            this.TabHistory.Name = "TabHistory";
            this.TabHistory.Size = new System.Drawing.Size(374, 340);
            this.TabHistory.Text = "출하이력";
            // 
            // grdHistory
            // 
            this.grdHistory.Caption = "";
            this.grdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHistory.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdHistory.IsUsePaging = false;
            this.grdHistory.LanguageKey = null;
            this.grdHistory.Location = new System.Drawing.Point(0, 0);
            this.grdHistory.Margin = new System.Windows.Forms.Padding(0);
            this.grdHistory.Name = "grdHistory";
            this.grdHistory.ShowBorder = true;
            this.grdHistory.Size = new System.Drawing.Size(374, 340);
            this.grdHistory.TabIndex = 4;
            this.grdHistory.UseAutoBestFitColumns = false;
            // 
            // MaterialShipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "MaterialShipment";
            this.Padding = new System.Windows.Forms.Padding(19, 19, 19, 19);
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartTabControl1)).EndInit();
            this.smartTabControl1.ResumeLayout(false);
            this.TabShip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            this.smartPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConsumableLotId.Properties)).EndInit();
            this.TabHistory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartTabControl smartTabControl1;
        private DevExpress.XtraTab.XtraTabPage TabShip;
        private DevExpress.XtraTab.XtraTabPage TabHistory;
        private Framework.SmartControls.SmartBandedGrid grdShip;
        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartTextBox txtConsumableLotId;
        private Framework.SmartControls.SmartLabel smartLabel1;
        private Framework.SmartControls.SmartBandedGrid grdHistory;
    }
}
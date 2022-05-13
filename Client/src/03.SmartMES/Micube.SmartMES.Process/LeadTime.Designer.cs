namespace Micube.SmartMES.Process
{
    partial class LeadTime
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
            this.grdLotLeadTime = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartTabControl1 = new Micube.Framework.SmartControls.SmartTabControl();
            this.tpgLTModel = new DevExpress.XtraTab.XtraTabPage();
            this.grdModelLeadTime = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.tpgLTProduct = new DevExpress.XtraTab.XtraTabPage();
            this.grdProductLeadTime = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartSpliterControl1 = new Micube.Framework.SmartControls.SmartSpliterControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartTabControl1)).BeginInit();
            this.smartTabControl1.SuspendLayout();
            this.tpgLTModel.SuspendLayout();
            this.tpgLTProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Size = new System.Drawing.Size(296, 464);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(854, 24);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.grdLotLeadTime);
            this.pnlContent.Controls.Add(this.smartSpliterControl1);
            this.pnlContent.Controls.Add(this.smartTabControl1);
            this.pnlContent.Size = new System.Drawing.Size(854, 459);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(1164, 493);
            // 
            // grdLotLeadTime
            // 
            this.grdLotLeadTime.Caption = "Lot별 LeadTime";
            this.grdLotLeadTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLotLeadTime.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdLotLeadTime.IsUsePaging = false;
            this.grdLotLeadTime.LanguageKey = "LEADTIMEPERLOT";
            this.grdLotLeadTime.Location = new System.Drawing.Point(0, 0);
            this.grdLotLeadTime.Margin = new System.Windows.Forms.Padding(0);
            this.grdLotLeadTime.Name = "grdLotLeadTime";
            this.grdLotLeadTime.ShowBorder = true;
            this.grdLotLeadTime.Size = new System.Drawing.Size(854, 149);
            this.grdLotLeadTime.TabIndex = 1;
            this.grdLotLeadTime.UseAutoBestFitColumns = false;
            // 
            // smartTabControl1
            // 
            this.smartTabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartTabControl1.Location = new System.Drawing.Point(0, 159);
            this.smartTabControl1.Name = "smartTabControl1";
            this.smartTabControl1.SelectedTabPage = this.tpgLTModel;
            this.smartTabControl1.Size = new System.Drawing.Size(854, 300);
            this.smartTabControl1.TabIndex = 2;
            this.smartTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpgLTModel,
            this.tpgLTProduct});
            // 
            // tpgLTModel
            // 
            this.tpgLTModel.Controls.Add(this.grdModelLeadTime);
            this.smartTabControl1.SetLanguageKey(this.tpgLTModel, "AVGLEADTIME");
            this.tpgLTModel.Name = "tpgLTModel";
            this.tpgLTModel.Padding = new System.Windows.Forms.Padding(3);
            this.tpgLTModel.Size = new System.Drawing.Size(852, 280);
            // 
            // grdModelLeadTime
            // 
            this.grdModelLeadTime.Caption = "기종별 LeadTime";
            this.grdModelLeadTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdModelLeadTime.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdModelLeadTime.IsUsePaging = false;
            this.grdModelLeadTime.LanguageKey = "LEADTIMEPERMODEL";
            this.grdModelLeadTime.Location = new System.Drawing.Point(3, 3);
            this.grdModelLeadTime.Margin = new System.Windows.Forms.Padding(0);
            this.grdModelLeadTime.Name = "grdModelLeadTime";
            this.grdModelLeadTime.ShowBorder = true;
            this.grdModelLeadTime.ShowStatusBar = false;
            this.grdModelLeadTime.Size = new System.Drawing.Size(846, 274);
            this.grdModelLeadTime.TabIndex = 2;
            this.grdModelLeadTime.UseAutoBestFitColumns = false;
            // 
            // tpgLTProduct
            // 
            this.tpgLTProduct.Controls.Add(this.grdProductLeadTime);
            this.smartTabControl1.SetLanguageKey(this.tpgLTProduct, "LEADTIMEPERPRODUCT");
            this.tpgLTProduct.Name = "tpgLTProduct";
            this.tpgLTProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tpgLTProduct.Size = new System.Drawing.Size(852, 280);
            // 
            // grdProductLeadTime
            // 
            this.grdProductLeadTime.Caption = "제품별 LeadTime";
            this.grdProductLeadTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProductLeadTime.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdProductLeadTime.IsUsePaging = false;
            this.grdProductLeadTime.LanguageKey = "LEADTIMEPERPRODUCT";
            this.grdProductLeadTime.Location = new System.Drawing.Point(3, 3);
            this.grdProductLeadTime.Margin = new System.Windows.Forms.Padding(0);
            this.grdProductLeadTime.Name = "grdProductLeadTime";
            this.grdProductLeadTime.ShowBorder = true;
            this.grdProductLeadTime.ShowStatusBar = false;
            this.grdProductLeadTime.Size = new System.Drawing.Size(846, 274);
            this.grdProductLeadTime.TabIndex = 3;
            this.grdProductLeadTime.UseAutoBestFitColumns = false;
            // 
            // smartSpliterControl1
            // 
            this.smartSpliterControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartSpliterControl1.Location = new System.Drawing.Point(0, 149);
            this.smartSpliterControl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterControl1.Name = "smartSpliterControl1";
            this.smartSpliterControl1.Size = new System.Drawing.Size(854, 10);
            this.smartSpliterControl1.TabIndex = 3;
            this.smartSpliterControl1.TabStop = false;
            // 
            // LeadTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 531);
            this.Name = "LeadTime";
            this.Padding = new System.Windows.Forms.Padding(19);
            this.Text = "LeadTime";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartTabControl1)).EndInit();
            this.smartTabControl1.ResumeLayout(false);
            this.tpgLTModel.ResumeLayout(false);
            this.tpgLTProduct.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartBandedGrid grdLotLeadTime;
        private Framework.SmartControls.SmartSpliterControl smartSpliterControl1;
        private Framework.SmartControls.SmartTabControl smartTabControl1;
        private DevExpress.XtraTab.XtraTabPage tpgLTModel;
        private Framework.SmartControls.SmartBandedGrid grdModelLeadTime;
        private DevExpress.XtraTab.XtraTabPage tpgLTProduct;
        private Framework.SmartControls.SmartBandedGrid grdProductLeadTime;
    }
}

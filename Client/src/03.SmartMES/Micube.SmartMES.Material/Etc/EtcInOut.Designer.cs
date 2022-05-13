namespace Micube.SmartMES.Material
{
    partial class EtcInOut
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
            this.grdList = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.btnIn = new Micube.Framework.SmartControls.SmartButton();
            this.smartPanel8 = new Micube.Framework.SmartControls.SmartPanel();
            this.btnOut = new Micube.Framework.SmartControls.SmartButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlToolbar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel8)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(2, 31);
            this.pnlCondition.Size = new System.Drawing.Size(296, 379);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Controls.Add(this.btnIn);
            this.pnlToolbar.Controls.Add(this.smartPanel8);
            this.pnlToolbar.Controls.Add(this.btnOut);
            this.pnlToolbar.Size = new System.Drawing.Size(457, 24);
            this.pnlToolbar.Controls.SetChildIndex(this.btnOut, 0);
            this.pnlToolbar.Controls.SetChildIndex(this.smartPanel8, 0);
            this.pnlToolbar.Controls.SetChildIndex(this.btnIn, 0);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.grdList);
            this.pnlContent.Size = new System.Drawing.Size(457, 383);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(762, 412);
            // 
            // grdList
            // 
            this.grdList.Caption = "기타 입출고 내역 정보";
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdList.IsUsePaging = false;
            this.grdList.LanguageKey = null;
            this.grdList.Location = new System.Drawing.Point(0, 0);
            this.grdList.Margin = new System.Windows.Forms.Padding(0);
            this.grdList.Name = "grdList";
            this.grdList.ShowBorder = true;
            this.grdList.Size = new System.Drawing.Size(457, 383);
            this.grdList.TabIndex = 1;
            this.grdList.UseAutoBestFitColumns = false;
            // 
            // btnIn
            // 
            this.btnIn.AllowFocus = false;
            this.btnIn.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnIn.IsBusy = false;
            this.btnIn.IsWrite = false;
            this.btnIn.LanguageKey = "IPGO";
            this.btnIn.Location = new System.Drawing.Point(289, 0);
            this.btnIn.Margin = new System.Windows.Forms.Padding(0);
            this.btnIn.Name = "btnIn";
            this.btnIn.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnIn.Size = new System.Drawing.Size(79, 24);
            this.btnIn.TabIndex = 11;
            this.btnIn.Text = "btnIn";
            this.btnIn.TooltipLanguageKey = "";
            // 
            // smartPanel8
            // 
            this.smartPanel8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.smartPanel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.smartPanel8.Location = new System.Drawing.Point(368, 0);
            this.smartPanel8.Name = "smartPanel8";
            this.smartPanel8.Size = new System.Drawing.Size(10, 24);
            this.smartPanel8.TabIndex = 12;
            // 
            // btnOut
            // 
            this.btnOut.AllowFocus = false;
            this.btnOut.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOut.IsBusy = false;
            this.btnOut.IsWrite = false;
            this.btnOut.LanguageKey = "DELIVERY";
            this.btnOut.Location = new System.Drawing.Point(378, 0);
            this.btnOut.Margin = new System.Windows.Forms.Padding(0);
            this.btnOut.Name = "btnOut";
            this.btnOut.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnOut.Size = new System.Drawing.Size(79, 24);
            this.btnOut.TabIndex = 10;
            this.btnOut.Text = "btnOut";
            this.btnOut.TooltipLanguageKey = "";
            // 
            // EtcInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "EtcInOut";
            this.Padding = new System.Windows.Forms.Padding(19);
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartBandedGrid grdList;
        private Framework.SmartControls.SmartButton btnIn;
        private Framework.SmartControls.SmartPanel smartPanel8;
        private Framework.SmartControls.SmartButton btnOut;
    }
}
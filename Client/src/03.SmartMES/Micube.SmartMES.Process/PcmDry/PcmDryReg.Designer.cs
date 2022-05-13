namespace Micube.SmartMES.Process
{
    partial class PcmDryReg
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
            this.smartPanel1 = new Micube.Framework.SmartControls.SmartPanel();
            this.grdLotResult = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.smartSpliterControl2 = new Micube.Framework.SmartControls.SmartSpliterControl();
            this.smartPanel2 = new Micube.Framework.SmartControls.SmartPanel();
            this.smartButton4 = new Micube.Framework.SmartControls.SmartButton();
            this.smartButton3 = new Micube.Framework.SmartControls.SmartButton();
            this.smartButton2 = new Micube.Framework.SmartControls.SmartButton();
            this.smartButton1 = new Micube.Framework.SmartControls.SmartButton();
            this.smartSpliterControl1 = new Micube.Framework.SmartControls.SmartSpliterControl();
            this.grdWorkOrder = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).BeginInit();
            this.smartPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(2, 31);
            this.pnlCondition.Size = new System.Drawing.Size(296, 397);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.grdWorkOrder);
            this.pnlContent.Controls.Add(this.smartSpliterControl1);
            this.pnlContent.Controls.Add(this.smartPanel1);
            // 
            // smartPanel1
            // 
            this.smartPanel1.Controls.Add(this.grdLotResult);
            this.smartPanel1.Controls.Add(this.smartSpliterControl2);
            this.smartPanel1.Controls.Add(this.smartPanel2);
            this.smartPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartPanel1.Location = new System.Drawing.Point(0, 141);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.Size = new System.Drawing.Size(475, 260);
            this.smartPanel1.TabIndex = 0;
            // 
            // grdLotResult
            // 
            this.grdLotResult.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdLotResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLotResult.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdLotResult.IsUsePaging = false;
            this.grdLotResult.LanguageKey = "";
            this.grdLotResult.Location = new System.Drawing.Point(2, 2);
            this.grdLotResult.Margin = new System.Windows.Forms.Padding(0);
            this.grdLotResult.Name = "grdLotResult";
            this.grdLotResult.ShowBorder = true;
            this.grdLotResult.Size = new System.Drawing.Size(290, 256);
            this.grdLotResult.TabIndex = 2;
            // 
            // smartSpliterControl2
            // 
            this.smartSpliterControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.smartSpliterControl2.Location = new System.Drawing.Point(292, 2);
            this.smartSpliterControl2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterControl2.Name = "smartSpliterControl2";
            this.smartSpliterControl2.Size = new System.Drawing.Size(5, 256);
            this.smartSpliterControl2.TabIndex = 1;
            this.smartSpliterControl2.TabStop = false;
            // 
            // smartPanel2
            // 
            this.smartPanel2.Controls.Add(this.smartButton4);
            this.smartPanel2.Controls.Add(this.smartButton3);
            this.smartPanel2.Controls.Add(this.smartButton2);
            this.smartPanel2.Controls.Add(this.smartButton1);
            this.smartPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.smartPanel2.Location = new System.Drawing.Point(297, 2);
            this.smartPanel2.Name = "smartPanel2";
            this.smartPanel2.Size = new System.Drawing.Size(176, 256);
            this.smartPanel2.TabIndex = 0;
            // 
            // smartButton4
            // 
            this.smartButton4.AllowFocus = false;
            this.smartButton4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartButton4.IsBusy = false;
            this.smartButton4.IsWrite = false;
            this.smartButton4.LanguageKey = "WORKSTART";
            this.smartButton4.Location = new System.Drawing.Point(2, 154);
            this.smartButton4.Margin = new System.Windows.Forms.Padding(3, 50, 3, 50);
            this.smartButton4.Name = "smartButton4";
            this.smartButton4.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.smartButton4.Size = new System.Drawing.Size(172, 25);
            this.smartButton4.TabIndex = 3;
            this.smartButton4.Text = "smartButton4";
            this.smartButton4.TooltipLanguageKey = "";
            // 
            // smartButton3
            // 
            this.smartButton3.AllowFocus = false;
            this.smartButton3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartButton3.IsBusy = false;
            this.smartButton3.IsWrite = false;
            this.smartButton3.LanguageKey = "WORKEND";
            this.smartButton3.Location = new System.Drawing.Point(2, 179);
            this.smartButton3.Margin = new System.Windows.Forms.Padding(3, 50, 3, 50);
            this.smartButton3.Name = "smartButton3";
            this.smartButton3.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.smartButton3.Size = new System.Drawing.Size(172, 25);
            this.smartButton3.TabIndex = 2;
            this.smartButton3.Text = "smartButton3";
            this.smartButton3.TooltipLanguageKey = "";
            // 
            // smartButton2
            // 
            this.smartButton2.AllowFocus = false;
            this.smartButton2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartButton2.IsBusy = false;
            this.smartButton2.IsWrite = false;
            this.smartButton2.LanguageKey = "WORKSAVE";
            this.smartButton2.Location = new System.Drawing.Point(2, 204);
            this.smartButton2.Margin = new System.Windows.Forms.Padding(3, 50, 3, 50);
            this.smartButton2.Name = "smartButton2";
            this.smartButton2.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.smartButton2.Size = new System.Drawing.Size(172, 25);
            this.smartButton2.TabIndex = 1;
            this.smartButton2.Text = "smartButton2";
            this.smartButton2.TooltipLanguageKey = "";
            // 
            // smartButton1
            // 
            this.smartButton1.AllowFocus = false;
            this.smartButton1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartButton1.IsBusy = false;
            this.smartButton1.IsWrite = false;
            this.smartButton1.LanguageKey = "PRINTLABEL";
            this.smartButton1.Location = new System.Drawing.Point(2, 229);
            this.smartButton1.Margin = new System.Windows.Forms.Padding(3, 50, 3, 50);
            this.smartButton1.Name = "smartButton1";
            this.smartButton1.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.smartButton1.Size = new System.Drawing.Size(172, 25);
            this.smartButton1.TabIndex = 0;
            this.smartButton1.Text = "smartButton1";
            this.smartButton1.TooltipLanguageKey = "";
            // 
            // smartSpliterControl1
            // 
            this.smartSpliterControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartSpliterControl1.Location = new System.Drawing.Point(0, 136);
            this.smartSpliterControl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterControl1.Name = "smartSpliterControl1";
            this.smartSpliterControl1.Size = new System.Drawing.Size(475, 5);
            this.smartSpliterControl1.TabIndex = 1;
            this.smartSpliterControl1.TabStop = false;
            // 
            // grdWorkOrder
            // 
            this.grdWorkOrder.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdWorkOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWorkOrder.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdWorkOrder.IsUsePaging = false;
            this.grdWorkOrder.LanguageKey = null;
            this.grdWorkOrder.Location = new System.Drawing.Point(0, 0);
            this.grdWorkOrder.Margin = new System.Windows.Forms.Padding(0);
            this.grdWorkOrder.Name = "grdWorkOrder";
            this.grdWorkOrder.ShowBorder = true;
            this.grdWorkOrder.Size = new System.Drawing.Size(475, 136);
            this.grdWorkOrder.TabIndex = 2;
            // 
            // PcmDryReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "PcmDryReg";
            this.Text = "PcmDryReg";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.smartPanel2)).EndInit();
            this.smartPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartBandedGrid grdWorkOrder;
        private Framework.SmartControls.SmartSpliterControl smartSpliterControl1;
        private Framework.SmartControls.SmartPanel smartPanel1;
        private Framework.SmartControls.SmartBandedGrid grdLotResult;
        private Framework.SmartControls.SmartSpliterControl smartSpliterControl2;
        private Framework.SmartControls.SmartPanel smartPanel2;
        private Framework.SmartControls.SmartButton smartButton4;
        private Framework.SmartControls.SmartButton smartButton3;
        private Framework.SmartControls.SmartButton smartButton2;
        private Framework.SmartControls.SmartButton smartButton1;
    }
}
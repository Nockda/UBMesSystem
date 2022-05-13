namespace Micube.SmartMES.Quality
{
    partial class SearchProductOQC
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
			this.grdResultList = new Micube.Framework.SmartControls.SmartBandedGrid();
			this.pnlButton = new System.Windows.Forms.FlowLayoutPanel();
			this.btnConfirm = new Micube.Framework.SmartControls.SmartButton();
			((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
			this.pnlToolbar.SuspendLayout();
			this.pnlContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
			this.pnlButton.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlCondition
			// 
			this.pnlCondition.Location = new System.Drawing.Point(2, 31);
			this.pnlCondition.Size = new System.Drawing.Size(296, 397);
			// 
			// pnlToolbar
			// 
			this.pnlToolbar.Controls.Add(this.pnlButton);
			this.pnlToolbar.Controls.SetChildIndex(this.pnlButton, 0);
			// 
			// pnlContent
			// 
			this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			this.pnlContent.Appearance.Options.UseBackColor = true;
			this.pnlContent.Controls.Add(this.grdResultList);
			// 
			// grdResultList
			// 
			this.grdResultList.Caption = "그리드제목( LanguageKey를 입력하세요)";
			this.grdResultList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdResultList.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
			this.grdResultList.IsUsePaging = false;
			this.grdResultList.LanguageKey = "SELECTOUTGOINGLOTLIST";
			this.grdResultList.Location = new System.Drawing.Point(0, 0);
			this.grdResultList.Margin = new System.Windows.Forms.Padding(0);
			this.grdResultList.Name = "grdResultList";
			this.grdResultList.ShowBorder = true;
			this.grdResultList.Size = new System.Drawing.Size(475, 401);
			this.grdResultList.TabIndex = 0;
			this.grdResultList.UseAutoBestFitColumns = false;
			// 
			// pnlButton
			// 
			this.pnlButton.Controls.Add(this.btnConfirm);
			this.pnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlButton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.pnlButton.Location = new System.Drawing.Point(47, 0);
			this.pnlButton.Name = "pnlButton";
			this.pnlButton.Size = new System.Drawing.Size(428, 24);
			this.pnlButton.TabIndex = 5;
			// 
			// btnConfirm
			// 
			this.btnConfirm.AllowFocus = false;
			this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConfirm.IsBusy = false;
			this.btnConfirm.IsWrite = false;
			this.btnConfirm.LanguageKey = "CONFIRM2";
			this.btnConfirm.Location = new System.Drawing.Point(350, 0);
			this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
			this.btnConfirm.Size = new System.Drawing.Size(75, 23);
			this.btnConfirm.TabIndex = 1;
			this.btnConfirm.Text = "확정";
			this.btnConfirm.TooltipLanguageKey = "";
			// 
			// SearchProductOQC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Name = "SearchProductOQC";
			this.Text = "SmartConditionBaseForm";
			((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
			this.pnlToolbar.ResumeLayout(false);
			this.pnlToolbar.PerformLayout();
			this.pnlContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
			this.pnlButton.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private Framework.SmartControls.SmartBandedGrid grdResultList;
		private System.Windows.Forms.FlowLayoutPanel pnlButton;
		private Framework.SmartControls.SmartButton btnConfirm;
	}
}
namespace Micube.SmartMES.SystemManagement
{
    partial class DeployHistoryListPopup
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
            this.grdHistoryList = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grdHistoryList);
            // 
            // grdHistoryList
            // 
            this.grdHistoryList.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdHistoryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHistoryList.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy)
            | Micube.Framework.SmartControls.GridButtonItem.Delete)
            | Micube.Framework.SmartControls.GridButtonItem.Preview)
            | Micube.Framework.SmartControls.GridButtonItem.Import)
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdHistoryList.IsUsePaging = false;
            this.grdHistoryList.LanguageKey = null;
            this.grdHistoryList.Location = new System.Drawing.Point(0, 0);
            this.grdHistoryList.Margin = new System.Windows.Forms.Padding(0);
            this.grdHistoryList.Name = "grdHistoryList";
            this.grdHistoryList.ShowBorder = true;
            this.grdHistoryList.Size = new System.Drawing.Size(780, 430);
            this.grdHistoryList.TabIndex = 0;
            // 
            // DeployHistoryListPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "DeployHistoryListPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Deploy History List";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.SmartControls.SmartBandedGrid grdHistoryList;
    }
}
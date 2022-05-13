namespace Micube.SmartMES.Quality
{
    partial class IqcInspManage
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
            this.smartBandedGrid1 = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.grdInfo = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
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
            this.pnlContent.Controls.Add(this.grdInfo);
            this.pnlContent.Controls.Add(this.smartBandedGrid1);
            // 
            // smartBandedGrid1
            // 
            this.smartBandedGrid1.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.smartBandedGrid1.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.smartBandedGrid1.IsUsePaging = false;
            this.smartBandedGrid1.LanguageKey = null;
            this.smartBandedGrid1.Location = new System.Drawing.Point(-338, -85);
            this.smartBandedGrid1.Margin = new System.Windows.Forms.Padding(0);
            this.smartBandedGrid1.Name = "smartBandedGrid1";
            this.smartBandedGrid1.ShowBorder = true;
            this.smartBandedGrid1.Size = new System.Drawing.Size(700, 400);
            this.smartBandedGrid1.TabIndex = 0;
            // 
            // grdInfo
            // 
            this.grdInfo.Caption = "수입검사 관리 정보";
            this.grdInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInfo.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdInfo.IsUsePaging = false;
            this.grdInfo.LanguageKey = null;
            this.grdInfo.Location = new System.Drawing.Point(0, 0);
            this.grdInfo.Margin = new System.Windows.Forms.Padding(0);
            this.grdInfo.Name = "grdInfo";
            this.grdInfo.ShowBorder = true;
            this.grdInfo.Size = new System.Drawing.Size(475, 401);
            this.grdInfo.TabIndex = 1;
            // 
            // IqcInspManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "IqcInspManage";
            this.Text = "IqcInspManage";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartBandedGrid smartBandedGrid1;
        private Framework.SmartControls.SmartBandedGrid grdInfo;
    }
}
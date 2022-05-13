namespace Micube.SmartMES.Process
{
    partial class InputLaborMgt
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
            this.grd = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
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
            this.pnlContent.Controls.Add(this.grd);
            this.pnlContent.Controls.Add(this.smartBandedGrid1);
            this.pnlContent.Size = new System.Drawing.Size(381, 376);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(762, 412);
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
            this.smartBandedGrid1.Location = new System.Drawing.Point(-428, -134);
            this.smartBandedGrid1.Margin = new System.Windows.Forms.Padding(0);
            this.smartBandedGrid1.Name = "smartBandedGrid1";
            this.smartBandedGrid1.ShowBorder = true;
            this.smartBandedGrid1.Size = new System.Drawing.Size(800, 600);
            this.smartBandedGrid1.TabIndex = 0;
            // 
            // grd
            // 
            this.grd.Caption = "투입공수";
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grd.IsUsePaging = false;
            this.grd.LanguageKey = null;
            this.grd.Location = new System.Drawing.Point(0, 0);
            this.grd.Margin = new System.Windows.Forms.Padding(0);
            this.grd.Name = "grd";
            this.grd.ShowBorder = true;
            this.grd.Size = new System.Drawing.Size(381, 376);
            this.grd.TabIndex = 1;
            // 
            // InputLaborMgt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "InputLaborMgt";
            this.Padding = new System.Windows.Forms.Padding(19, 19, 19, 19);
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.SmartControls.SmartBandedGrid grd;
        private Framework.SmartControls.SmartBandedGrid smartBandedGrid1;
    }
}
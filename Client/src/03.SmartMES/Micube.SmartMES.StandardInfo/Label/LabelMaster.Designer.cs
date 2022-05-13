namespace Micube.SmartMES.StandardInfo
{
	partial class LabelMaster
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
            this.labelDesigner1 = new Micube.SmartMES.Commons.Controls.LabelDesigner();
            this.grdLabelDefList = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Location = new System.Drawing.Point(2, 31);
            this.pnlCondition.Size = new System.Drawing.Size(296, 691);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(818, 24);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.labelDesigner1);
            this.pnlContent.Controls.Add(this.grdLabelDefList);
            this.pnlContent.Size = new System.Drawing.Size(818, 695);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(1123, 724);
            // 
            // labelDesigner1
            // 
            this.labelDesigner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDesigner1.IsOpenButtonEnable = false;
            this.labelDesigner1.LabelInfoTable = null;
            this.labelDesigner1.Location = new System.Drawing.Point(0, 293);
            this.labelDesigner1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.labelDesigner1.Name = "labelDesigner1";
            this.labelDesigner1.PrevFocusedRowHandle = 0;
            this.labelDesigner1.Size = new System.Drawing.Size(818, 402);
            this.labelDesigner1.TabIndex = 4;
            // 
            // grdLabelDefList
            // 
            this.grdLabelDefList.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdLabelDefList.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdLabelDefList.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdLabelDefList.IsUsePaging = true;
            this.grdLabelDefList.LanguageKey = "LABELDEFINITIONLIST";
            this.grdLabelDefList.Location = new System.Drawing.Point(0, 0);
            this.grdLabelDefList.Margin = new System.Windows.Forms.Padding(0);
            this.grdLabelDefList.Name = "grdLabelDefList";
            this.grdLabelDefList.ShowBorder = true;
            this.grdLabelDefList.Size = new System.Drawing.Size(818, 293);
            this.grdLabelDefList.TabIndex = 3;
            // 
            // LabelMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 762);
            this.Name = "LabelMaster";
            this.Padding = new System.Windows.Forms.Padding(19);
            this.Text = "SmartConditionBaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private Commons.Controls.LabelDesigner labelDesigner1;
        private Framework.SmartControls.SmartBandedGrid grdLabelDefList;
    }
}
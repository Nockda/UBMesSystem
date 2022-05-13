namespace Micube.SmartMES.StandardInfo
{
	partial class InspImageManagement
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
            this.grdInspList = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.picImage = new Micube.Framework.SmartControls.SmartPictureEdit();
            this.tlpImage = new Micube.Framework.SmartControls.SmartSplitTableLayoutPanel();
            this.pnlButton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSelectImage = new Micube.Framework.SmartControls.SmartButton();
            this.smartSpliterControl1 = new Micube.Framework.SmartControls.SmartSpliterControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).BeginInit();
            this.tlpImage.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCondition
            // 
            this.pnlCondition.Size = new System.Drawing.Size(371, 754);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Size = new System.Drawing.Size(833, 30);
            // 
            // pnlContent
            // 
            this.pnlContent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.Controls.Add(this.grdInspList);
            this.pnlContent.Controls.Add(this.smartSpliterControl1);
            this.pnlContent.Controls.Add(this.tlpImage);
            this.pnlContent.Size = new System.Drawing.Size(833, 757);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(19, 19);
            this.pnlMain.Size = new System.Drawing.Size(1214, 793);
            // 
            // grdInspList
            // 
            this.grdInspList.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdInspList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInspList.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdInspList.IsUsePaging = false;
            this.grdInspList.LanguageKey = "INSPECTIONIMAGELIST";
            this.grdInspList.Location = new System.Drawing.Point(0, 0);
            this.grdInspList.Margin = new System.Windows.Forms.Padding(0);
            this.grdInspList.Name = "grdInspList";
            this.grdInspList.ShowBorder = true;
            this.grdInspList.Size = new System.Drawing.Size(833, 101);
            this.grdInspList.TabIndex = 0;
            this.grdInspList.UseAutoBestFitColumns = false;
            // 
            // picImage
            // 
            this.picImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImage.Location = new System.Drawing.Point(3, 33);
            this.picImage.Name = "picImage";
            this.picImage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picImage.Properties.ShowScrollBars = true;
            this.picImage.Properties.ZoomingOperationMode = DevExpress.XtraEditors.Repository.ZoomingOperationMode.ControlMouseWheel;
            this.picImage.Size = new System.Drawing.Size(827, 614);
            this.picImage.TabIndex = 1;
            // 
            // tlpImage
            // 
            this.tlpImage.ColumnCount = 1;
            this.tlpImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpImage.Controls.Add(this.picImage, 0, 1);
            this.tlpImage.Controls.Add(this.pnlButton, 0, 0);
            this.tlpImage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpImage.Location = new System.Drawing.Point(0, 107);
            this.tlpImage.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.tlpImage.Name = "tlpImage";
            this.tlpImage.RowCount = 2;
            this.tlpImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImage.Size = new System.Drawing.Size(833, 650);
            this.tlpImage.TabIndex = 2;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnSelectImage);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlButton.Location = new System.Drawing.Point(3, 3);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(827, 24);
            this.pnlButton.TabIndex = 2;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.AllowFocus = false;
            this.btnSelectImage.IsBusy = false;
            this.btnSelectImage.IsWrite = false;
            this.btnSelectImage.LanguageKey = "SELECTIMAGE";
            this.btnSelectImage.Location = new System.Drawing.Point(739, 0);
            this.btnSelectImage.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSelectImage.Size = new System.Drawing.Size(85, 23);
            this.btnSelectImage.TabIndex = 0;
            this.btnSelectImage.Text = "이미지 선택";
            this.btnSelectImage.TooltipLanguageKey = "";
            // 
            // smartSpliterControl1
            // 
            this.smartSpliterControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.smartSpliterControl1.Location = new System.Drawing.Point(0, 101);
            this.smartSpliterControl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.smartSpliterControl1.Name = "smartSpliterControl1";
            this.smartSpliterControl1.Size = new System.Drawing.Size(833, 6);
            this.smartSpliterControl1.TabIndex = 3;
            this.smartSpliterControl1.TabStop = false;
            // 
            // InspImageManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 831);
            this.Name = "InspImageManagement";
            this.Padding = new System.Windows.Forms.Padding(19, 19, 19, 19);
            this.Text = "SmartConditionBaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).EndInit();
            this.tlpImage.ResumeLayout(false);
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Framework.SmartControls.SmartBandedGrid grdInspList;
		private Framework.SmartControls.SmartSpliterControl smartSpliterControl1;
		private Framework.SmartControls.SmartSplitTableLayoutPanel tlpImage;
		private Framework.SmartControls.SmartPictureEdit picImage;
		private System.Windows.Forms.FlowLayoutPanel pnlButton;
		private Framework.SmartControls.SmartButton btnSelectImage;
	}
}
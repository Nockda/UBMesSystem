namespace Micube.SmartMES.StandardInfo
{
	partial class InspectionStdImagePopup
	{
		/// <summary> 
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 구성 요소 디자이너에서 생성한 코드

		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.tlpInspStdImage = new System.Windows.Forms.TableLayoutPanel();
			this.pnlImage = new Micube.Framework.SmartControls.SmartPanel();
			this.picImage = new Micube.Framework.SmartControls.SmartPictureEdit();
			this.smartSpliterControl1 = new Micube.Framework.SmartControls.SmartSpliterControl();
			this.grdImageList = new Micube.Framework.SmartControls.SmartBandedGrid();
			this.pnlCondition = new Micube.Framework.SmartControls.SmartPanel();
			this.btnSearch = new Micube.Framework.SmartControls.SmartButton();
			this.txtFileName = new Micube.Framework.SmartControls.SmartLabelTextBox();
			this.cboInspectionType = new Micube.Framework.SmartControls.SmartLabelComboBox();
			this.pnlButton = new Micube.Framework.SmartControls.SmartPanel();
			this.btnConfirm = new Micube.Framework.SmartControls.SmartButton();
			this.btnClose = new Micube.Framework.SmartControls.SmartButton();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
			this.pnlMain.SuspendLayout();
			this.tlpInspStdImage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlImage)).BeginInit();
			this.pnlImage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
			this.pnlCondition.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cboInspectionType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlButton)).BeginInit();
			this.pnlButton.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.tlpInspStdImage);
			this.pnlMain.Size = new System.Drawing.Size(996, 603);
			// 
			// tlpInspStdImage
			// 
			this.tlpInspStdImage.ColumnCount = 1;
			this.tlpInspStdImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpInspStdImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpInspStdImage.Controls.Add(this.pnlImage, 0, 2);
			this.tlpInspStdImage.Controls.Add(this.pnlCondition, 0, 0);
			this.tlpInspStdImage.Controls.Add(this.pnlButton, 0, 4);
			this.tlpInspStdImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpInspStdImage.Location = new System.Drawing.Point(0, 0);
			this.tlpInspStdImage.Name = "tlpInspStdImage";
			this.tlpInspStdImage.RowCount = 5;
			this.tlpInspStdImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tlpInspStdImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpInspStdImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpInspStdImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpInspStdImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tlpInspStdImage.Size = new System.Drawing.Size(996, 603);
			this.tlpInspStdImage.TabIndex = 0;
			// 
			// pnlImage
			// 
			this.pnlImage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlImage.Controls.Add(this.picImage);
			this.pnlImage.Controls.Add(this.smartSpliterControl1);
			this.pnlImage.Controls.Add(this.grdImageList);
			this.pnlImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlImage.Location = new System.Drawing.Point(3, 43);
			this.pnlImage.Name = "pnlImage";
			this.pnlImage.Size = new System.Drawing.Size(990, 517);
			this.pnlImage.TabIndex = 0;
			// 
			// picImage
			// 
			this.picImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picImage.Location = new System.Drawing.Point(305, 0);
			this.picImage.Name = "picImage";
			this.picImage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
			this.picImage.Properties.ShowScrollBars = true;
			this.picImage.Properties.ZoomingOperationMode = DevExpress.XtraEditors.Repository.ZoomingOperationMode.ControlMouseWheel;
			this.picImage.Size = new System.Drawing.Size(685, 517);
			this.picImage.TabIndex = 1;
			// 
			// smartSpliterControl1
			// 
			this.smartSpliterControl1.Location = new System.Drawing.Point(300, 0);
			this.smartSpliterControl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.smartSpliterControl1.Name = "smartSpliterControl1";
			this.smartSpliterControl1.Size = new System.Drawing.Size(5, 517);
			this.smartSpliterControl1.TabIndex = 2;
			this.smartSpliterControl1.TabStop = false;
			// 
			// grdImageList
			// 
			this.grdImageList.Caption = "";
			this.grdImageList.Dock = System.Windows.Forms.DockStyle.Left;
			this.grdImageList.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
			this.grdImageList.IsUsePaging = false;
			this.grdImageList.LanguageKey = null;
			this.grdImageList.Location = new System.Drawing.Point(0, 0);
			this.grdImageList.Margin = new System.Windows.Forms.Padding(0);
			this.grdImageList.Name = "grdImageList";
			this.grdImageList.ShowBorder = true;
			this.grdImageList.Size = new System.Drawing.Size(300, 517);
			this.grdImageList.TabIndex = 0;
			this.grdImageList.UseAutoBestFitColumns = false;
			// 
			// pnlCondition
			// 
			this.pnlCondition.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlCondition.Controls.Add(this.btnSearch);
			this.pnlCondition.Controls.Add(this.txtFileName);
			this.pnlCondition.Controls.Add(this.cboInspectionType);
			this.pnlCondition.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlCondition.Location = new System.Drawing.Point(3, 3);
			this.pnlCondition.Name = "pnlCondition";
			this.pnlCondition.Size = new System.Drawing.Size(990, 24);
			this.pnlCondition.TabIndex = 1;
			// 
			// btnSearch
			// 
			this.btnSearch.AllowFocus = false;
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSearch.IsBusy = false;
			this.btnSearch.IsWrite = false;
			this.btnSearch.LanguageKey = "SEARCH";
			this.btnSearch.Location = new System.Drawing.Point(912, 0);
			this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "조회";
			this.btnSearch.TooltipLanguageKey = "";
			// 
			// txtFileName
			// 
			this.txtFileName.LabelText = "파일명";
			this.txtFileName.LanguageKey = "FILENAME";
			this.txtFileName.Location = new System.Drawing.Point(257, 2);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.Size = new System.Drawing.Size(220, 20);
			this.txtFileName.TabIndex = 1;
			// 
			// cboInspectionType
			// 
			this.cboInspectionType.LabelText = "검사 종류";
			this.cboInspectionType.LanguageKey = null;
			this.cboInspectionType.Location = new System.Drawing.Point(3, 2);
			this.cboInspectionType.Name = "cboInspectionType";
			this.cboInspectionType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cboInspectionType.Properties.NullText = "";
			this.cboInspectionType.Size = new System.Drawing.Size(220, 20);
			this.cboInspectionType.TabIndex = 0;
			// 
			// pnlButton
			// 
			this.pnlButton.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlButton.Controls.Add(this.btnConfirm);
			this.pnlButton.Controls.Add(this.btnClose);
			this.pnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlButton.Location = new System.Drawing.Point(3, 576);
			this.pnlButton.Name = "pnlButton";
			this.pnlButton.Size = new System.Drawing.Size(990, 24);
			this.pnlButton.TabIndex = 2;
			// 
			// btnConfirm
			// 
			this.btnConfirm.AllowFocus = false;
			this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConfirm.IsBusy = false;
			this.btnConfirm.IsWrite = false;
			this.btnConfirm.LanguageKey = "CONFIRM";
			this.btnConfirm.Location = new System.Drawing.Point(831, 0);
			this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
			this.btnConfirm.Size = new System.Drawing.Size(75, 23);
			this.btnConfirm.TabIndex = 4;
			this.btnConfirm.Text = "확인";
			this.btnConfirm.TooltipLanguageKey = "";
			// 
			// btnClose
			// 
			this.btnClose.AllowFocus = false;
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.IsBusy = false;
			this.btnClose.IsWrite = false;
			this.btnClose.LanguageKey = "CLOSE";
			this.btnClose.Location = new System.Drawing.Point(912, 0);
			this.btnClose.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "닫기";
			this.btnClose.TooltipLanguageKey = "";
			// 
			// InspectionStdImagePopup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1016, 623);
			this.Name = "InspectionStdImagePopup";
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
			this.pnlMain.ResumeLayout(false);
			this.tlpInspStdImage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlImage)).EndInit();
			this.pnlImage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
			this.pnlCondition.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cboInspectionType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlButton)).EndInit();
			this.pnlButton.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpInspStdImage;
		private Framework.SmartControls.SmartPanel pnlImage;
		private Framework.SmartControls.SmartBandedGrid grdImageList;
		private Framework.SmartControls.SmartSpliterControl smartSpliterControl1;
		private Framework.SmartControls.SmartPictureEdit picImage;
		private Framework.SmartControls.SmartPanel pnlCondition;
		private Framework.SmartControls.SmartButton btnSearch;
		private Framework.SmartControls.SmartLabelTextBox txtFileName;
		private Framework.SmartControls.SmartLabelComboBox cboInspectionType;
		private Framework.SmartControls.SmartPanel pnlButton;
		private Framework.SmartControls.SmartButton btnConfirm;
		private Framework.SmartControls.SmartButton btnClose;
	}
}

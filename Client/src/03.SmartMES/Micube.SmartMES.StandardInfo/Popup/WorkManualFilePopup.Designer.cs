namespace Micube.SmartMES.StandardInfo
{
	partial class WorkManualFilePopup
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
			this.smartSplitTableLayoutPanel1 = new Micube.Framework.SmartControls.SmartSplitTableLayoutPanel();
			this.pnlButton = new System.Windows.Forms.FlowLayoutPanel();
			this.btnClose = new Micube.Framework.SmartControls.SmartButton();
			this.btnSave = new Micube.Framework.SmartControls.SmartButton();
			this.grdFileList = new Micube.Framework.SmartControls.SmartBandedGrid();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
			this.pnlMain.SuspendLayout();
			this.smartSplitTableLayoutPanel1.SuspendLayout();
			this.pnlButton.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.smartSplitTableLayoutPanel1);
			this.pnlMain.Size = new System.Drawing.Size(700, 430);
			// 
			// smartSplitTableLayoutPanel1
			// 
			this.smartSplitTableLayoutPanel1.ColumnCount = 1;
			this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.smartSplitTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.smartSplitTableLayoutPanel1.Controls.Add(this.pnlButton, 0, 2);
			this.smartSplitTableLayoutPanel1.Controls.Add(this.grdFileList, 0, 0);
			this.smartSplitTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.smartSplitTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.smartSplitTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.smartSplitTableLayoutPanel1.Name = "smartSplitTableLayoutPanel1";
			this.smartSplitTableLayoutPanel1.RowCount = 3;
			this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.smartSplitTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.smartSplitTableLayoutPanel1.Size = new System.Drawing.Size(700, 430);
			this.smartSplitTableLayoutPanel1.TabIndex = 0;
			// 
			// pnlButton
			// 
			this.pnlButton.Controls.Add(this.btnClose);
			this.pnlButton.Controls.Add(this.btnSave);
			this.pnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlButton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.pnlButton.Location = new System.Drawing.Point(3, 403);
			this.pnlButton.Name = "pnlButton";
			this.pnlButton.Size = new System.Drawing.Size(694, 24);
			this.pnlButton.TabIndex = 0;
			// 
			// btnClose
			// 
			this.btnClose.AllowFocus = false;
			this.btnClose.IsBusy = false;
			this.btnClose.IsWrite = false;
			this.btnClose.LanguageKey = "CLOSE";
			this.btnClose.Location = new System.Drawing.Point(616, 0);
			this.btnClose.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "닫기";
			this.btnClose.TooltipLanguageKey = "";
			// 
			// btnSave
			// 
			this.btnSave.AllowFocus = false;
			this.btnSave.IsBusy = false;
			this.btnSave.IsWrite = false;
			this.btnSave.LanguageKey = "SAVE";
			this.btnSave.Location = new System.Drawing.Point(535, 0);
			this.btnSave.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.btnSave.Name = "btnSave";
			this.btnSave.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "저장";
			this.btnSave.TooltipLanguageKey = "";
			// 
			// grdFileList
			// 
			this.grdFileList.Caption = "";
			this.grdFileList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdFileList.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
			this.grdFileList.IsUsePaging = false;
			this.grdFileList.LanguageKey = null;
			this.grdFileList.Location = new System.Drawing.Point(0, 0);
			this.grdFileList.Margin = new System.Windows.Forms.Padding(0);
			this.grdFileList.Name = "grdFileList";
			this.grdFileList.ShowBorder = true;
			this.grdFileList.Size = new System.Drawing.Size(700, 390);
			this.grdFileList.TabIndex = 1;
			this.grdFileList.UseAutoBestFitColumns = false;
			// 
			// WorkManualFilePopup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(720, 450);
			this.LanguageKey = "GRIDFILELIST";
			this.Name = "WorkManualFilePopup";
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
			this.pnlMain.ResumeLayout(false);
			this.smartSplitTableLayoutPanel1.ResumeLayout(false);
			this.pnlButton.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Framework.SmartControls.SmartSplitTableLayoutPanel smartSplitTableLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel pnlButton;
		private Framework.SmartControls.SmartButton btnClose;
		private Framework.SmartControls.SmartButton btnSave;
		private Framework.SmartControls.SmartBandedGrid grdFileList;
	}
}

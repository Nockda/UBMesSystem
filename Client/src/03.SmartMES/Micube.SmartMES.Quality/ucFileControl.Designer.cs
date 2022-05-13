namespace Micube.SmartMES.Quality
{
	partial class ucFileControl
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
            this.tblFileControl = new Micube.Framework.SmartControls.SmartSplitTableLayoutPanel();
            this.grdFileInfo = new Micube.Framework.SmartControls.SmartBandedGrid();
            this.pnlButton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDownload = new Micube.Framework.SmartControls.SmartButton();
            this.btnAddFile = new Micube.Framework.SmartControls.SmartButton();
            this.tblFileControl.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblFileControl
            // 
            this.tblFileControl.ColumnCount = 1;
            this.tblFileControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFileControl.Controls.Add(this.grdFileInfo, 0, 0);
            this.tblFileControl.Controls.Add(this.pnlButton, 0, 2);
            this.tblFileControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblFileControl.Location = new System.Drawing.Point(0, 0);
            this.tblFileControl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.tblFileControl.Name = "tblFileControl";
            this.tblFileControl.RowCount = 3;
            this.tblFileControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFileControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tblFileControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblFileControl.Size = new System.Drawing.Size(541, 347);
            this.tblFileControl.TabIndex = 0;
            // 
            // grdFileInfo
            // 
            this.grdFileInfo.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdFileInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFileInfo.GridButtonItem = ((Micube.Framework.SmartControls.GridButtonItem)((((((Micube.Framework.SmartControls.GridButtonItem.Add | Micube.Framework.SmartControls.GridButtonItem.Copy) 
            | Micube.Framework.SmartControls.GridButtonItem.Delete) 
            | Micube.Framework.SmartControls.GridButtonItem.Preview) 
            | Micube.Framework.SmartControls.GridButtonItem.Import) 
            | Micube.Framework.SmartControls.GridButtonItem.Export)));
            this.grdFileInfo.IsUsePaging = false;
            this.grdFileInfo.LanguageKey = "ATTACHFILEINFO";
            this.grdFileInfo.Location = new System.Drawing.Point(0, 0);
            this.grdFileInfo.Margin = new System.Windows.Forms.Padding(0);
            this.grdFileInfo.Name = "grdFileInfo";
            this.grdFileInfo.ShowBorder = true;
            this.grdFileInfo.Size = new System.Drawing.Size(541, 312);
            this.grdFileInfo.TabIndex = 1;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnDownload);
            this.pnlButton.Controls.Add(this.btnAddFile);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlButton.Location = new System.Drawing.Point(3, 320);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(535, 24);
            this.pnlButton.TabIndex = 0;
            // 
            // btnDownload
            // 
            this.btnDownload.AllowFocus = false;
            this.btnDownload.IsBusy = false;
            this.btnDownload.IsWrite = false;
            this.btnDownload.LanguageKey = "FILEDOWNLOAD";
            this.btnDownload.Location = new System.Drawing.Point(457, 0);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.Text = "다운로드";
            this.btnDownload.TooltipLanguageKey = "";
            // 
            // btnAddFile
            // 
            this.btnAddFile.AllowFocus = false;
            this.btnAddFile.IsBusy = false;
            this.btnAddFile.IsWrite = false;
            this.btnAddFile.LanguageKey = "FILEADD";
            this.btnAddFile.Location = new System.Drawing.Point(376, 0);
            this.btnAddFile.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnAddFile.Size = new System.Drawing.Size(75, 23);
            this.btnAddFile.TabIndex = 1;
            this.btnAddFile.Text = "파일첨부";
            this.btnAddFile.TooltipLanguageKey = "";
            // 
            // ucFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblFileControl);
            this.Name = "ucFileControl";
            this.Size = new System.Drawing.Size(541, 347);
            this.tblFileControl.ResumeLayout(false);
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private Framework.SmartControls.SmartSplitTableLayoutPanel tblFileControl;
		private System.Windows.Forms.FlowLayoutPanel pnlButton;
		private Framework.SmartControls.SmartButton btnDownload;
		private Framework.SmartControls.SmartButton btnAddFile;
		private Framework.SmartControls.SmartBandedGrid grdFileInfo;
	}
}

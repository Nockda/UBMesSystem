namespace Micube.SmartMES.Commons.Controls
{
    partial class SmartFileProcessingControl
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
            this.pnlFileUploadButton = new Micube.Framework.SmartControls.SmartPanel();
            this.btnFileDownload = new Micube.Framework.SmartControls.SmartButton();
            this.btnFileDelete = new Micube.Framework.SmartControls.SmartButton();
            this.btnFileAdd = new Micube.Framework.SmartControls.SmartButton();
            this.grdFileList = new Micube.Framework.SmartControls.SmartBandedGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFileUploadButton)).BeginInit();
            this.pnlFileUploadButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFileUploadButton
            // 
            this.pnlFileUploadButton.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlFileUploadButton.Controls.Add(this.btnFileDownload);
            this.pnlFileUploadButton.Controls.Add(this.btnFileDelete);
            this.pnlFileUploadButton.Controls.Add(this.btnFileAdd);
            this.pnlFileUploadButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFileUploadButton.Location = new System.Drawing.Point(0, 0);
            this.pnlFileUploadButton.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFileUploadButton.Name = "pnlFileUploadButton";
            this.pnlFileUploadButton.Size = new System.Drawing.Size(457, 41);
            this.pnlFileUploadButton.TabIndex = 0;
            // 
            // btnFileDownload
            // 
            this.btnFileDownload.AllowFocus = false;
            this.btnFileDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileDownload.IsBusy = false;
            this.btnFileDownload.IsWrite = false;
            this.btnFileDownload.LanguageKey = "FILEDOWNLOAD";
            this.btnFileDownload.Location = new System.Drawing.Point(371, 0);
            this.btnFileDownload.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnFileDownload.Name = "btnFileDownload";
            this.btnFileDownload.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnFileDownload.Size = new System.Drawing.Size(86, 29);
            this.btnFileDownload.TabIndex = 2;
            this.btnFileDownload.Text = "다운로드";
            this.btnFileDownload.TooltipLanguageKey = "";
            // 
            // btnFileDelete
            // 
            this.btnFileDelete.AllowFocus = false;
            this.btnFileDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileDelete.IsBusy = false;
            this.btnFileDelete.IsWrite = false;
            this.btnFileDelete.LanguageKey = "FILEDELETE";
            this.btnFileDelete.Location = new System.Drawing.Point(274, 0);
            this.btnFileDelete.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnFileDelete.Name = "btnFileDelete";
            this.btnFileDelete.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnFileDelete.Size = new System.Drawing.Size(86, 29);
            this.btnFileDelete.TabIndex = 1;
            this.btnFileDelete.Text = "파일삭제";
            this.btnFileDelete.TooltipLanguageKey = "";
            // 
            // btnFileAdd
            // 
            this.btnFileAdd.AllowFocus = false;
            this.btnFileAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileAdd.IsBusy = false;
            this.btnFileAdd.IsWrite = false;
            this.btnFileAdd.LanguageKey = "FILEADD";
            this.btnFileAdd.Location = new System.Drawing.Point(177, 0);
            this.btnFileAdd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnFileAdd.Name = "btnFileAdd";
            this.btnFileAdd.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnFileAdd.Size = new System.Drawing.Size(86, 29);
            this.btnFileAdd.TabIndex = 0;
            this.btnFileAdd.Text = "파일추가";
            this.btnFileAdd.TooltipLanguageKey = "";
            // 
            // grdFileList
            // 
            this.grdFileList.Caption = "그리드제목( LanguageKey를 입력하세요)";
            this.grdFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFileList.IsUsePaging = false;
            this.grdFileList.LanguageKey = "";
            this.grdFileList.Location = new System.Drawing.Point(0, 41);
            this.grdFileList.Margin = new System.Windows.Forms.Padding(0);
            this.grdFileList.Name = "grdFileList";
            this.grdFileList.ShowBorder = true;
            this.grdFileList.Size = new System.Drawing.Size(457, 334);
            this.grdFileList.TabIndex = 1;
            // 
            // SmartFileProcessingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdFileList);
            this.Controls.Add(this.pnlFileUploadButton);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SmartFileProcessingControl";
            this.Size = new System.Drawing.Size(457, 375);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFileUploadButton)).EndInit();
            this.pnlFileUploadButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Framework.SmartControls.SmartPanel pnlFileUploadButton;
        public Framework.SmartControls.SmartButton btnFileDelete;
        public Framework.SmartControls.SmartButton btnFileAdd;
        public Framework.SmartControls.SmartBandedGrid grdFileList;
        public Framework.SmartControls.SmartButton btnFileDownload;
    }
}

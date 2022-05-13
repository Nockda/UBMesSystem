#region using

using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;

using SmartDeploy.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

#endregion

namespace Micube.SmartMES.Commons.Controls
{
    public partial class SmartFileProcessingControl : UserControl, ISupportMultiLanguage
    {
        public SmartFileProcessingControl()
        {
            InitializeComponent();
            InitializeEvent();

            InitializeGrid();
        }

        /// <summary>
        /// SmartFileUploadControl 컨트롤 내에서 사용하는 이벤트를 초기화한다.
        /// </summary>
        private void InitializeEvent()
        {
            btnFileAdd.Click += BtnFileAdd_Click;
            btnFileDelete.Click += BtnFileDelete_Click;
            btnFileDownload.Click += BtnFileDownload_Click;

            grdFileList.View.DoubleClick += View_DoubleClick;
        }

        /// <summary>
        /// 파일추가 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFileAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 0;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] fullFileName = openFileDialog.FileNames;
                string[] safeFileName = openFileDialog.SafeFileNames;

                DataTable dataSource = grdFileList.DataSource as DataTable;

                int rowCount = grdFileList.View.RowCount + 1;

                foreach (string fileName in fullFileName)
                {
                    FileInfo fileInfo = new FileInfo(fileName);


                    DataRow[] rows = dataSource.Select("SAFEFILENAME = '" + fileInfo.Name + "'");
                    string addedFileName = "";

                    if (rows.Count() > 0)
                        addedFileName = "(1)";

                    DataRow newRow = dataSource.NewRow();

                    newRow["FILEID"] = "";
                    newRow["FILENAME"] = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length) + addedFileName;
                    newRow["FILEEXT"] = fileInfo.Extension.Replace(".", "");
                    newRow["FILEPATH"] = UploadPath;
                    newRow["SAFEFILENAME"] = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length) + addedFileName + fileInfo.Extension;
                    newRow["FILESIZE"] = fileInfo.Length;
                    newRow["SEQUENCE"] = rowCount;
                    newRow["LOCALFILEPATH"] = fileInfo.FullName;
                    newRow["RESOURCETYPE"] = Resource.Type;
                    newRow["RESOURCEID"] = Resource.Id;
                    newRow["RESOURCEVERSION"] = Resource.Version;

                    dataSource.Rows.Add(newRow);

                    rowCount++;
                }
            }
        }

        /// <summary>
        /// 파일삭제 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFileDelete_Click(object sender, EventArgs e)
        {
            ValidationCheckFile();

            grdFileList.View.DeleteCheckedRows();


            //FileDelete();
        }

        /// <summary>
        /// 다운로드 버튼 클릭 이벤트 (복수 파일 다운로드)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFileDownload_Click(object sender, EventArgs e)
        {
            ValidationCheckFile();

            DataTable selectedFiles = grdFileList.View.GetCheckedRows();


            FileDownload(selectedFiles, DownloadType.Multi);
        }

        /// <summary>
        /// 파일 리스트 더블클릭 이벤트 (단일 파일 다운로드)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_DoubleClick(object sender, EventArgs e)
        {
            if (grdFileList.View.FocusedRowHandle < 0)
                return;

            DXMouseEventArgs args = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(args.Location);

            if (info.InRowCell && info.Column.FieldName == "COMMENTS")
                return;

            if (info.InRow)
            {
                DataTable selectedFiles = (DataSource as DataTable).Clone();
                DataRow selectedRow = view.GetDataRow(info.RowHandle);

                selectedFiles.Rows.Add(selectedRow.ItemArray.Clone() as object[]);


                FileDownload(selectedFiles, DownloadType.Single);
            }
        }

        /// <summary>
        /// File List 그리드 정보를 초기화한다.
        /// </summary>
        private void InitializeGrid()
        {
            grdFileList.GridButtonItem = GridButtonItem.None;
            grdFileList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdFileList.View.SetSortOrder("SEQUENCE");

            grdFileList.View.AddTextBoxColumn("FILEID", 100)
                .SetIsHidden()
                .SetIsReadOnly();
            grdFileList.View.AddTextBoxColumn("FILENAME", 300)
                .SetIsReadOnly();
            grdFileList.View.AddTextBoxColumn("FILEEXT", 100)
                .SetIsReadOnly();
            grdFileList.View.AddTextBoxColumn("FILEPATH", 200)
                .SetIsHidden()
                .SetIsReadOnly();
            grdFileList.View.AddTextBoxColumn("SAFEFILENAME", 200)
                .SetIsHidden()
                .SetIsReadOnly();
            grdFileList.View.AddSpinEditColumn("FILESIZE", 100)
                .SetDisplayFormat()
                .SetIsReadOnly();
            grdFileList.View.AddSpinEditColumn("SEQUENCE", 70)
                .SetIsHidden()
                .SetIsReadOnly();
            grdFileList.View.AddTextBoxColumn("LOCALFILEPATH", 200)
                .SetIsHidden()
                .SetIsReadOnly();
            grdFileList.View.AddTextBoxColumn("RESOURCETYPE", 100)
                .SetIsHidden()
                .SetIsReadOnly();
            grdFileList.View.AddTextBoxColumn("RESOURCEID", 100)
                .SetIsHidden()
                .SetIsReadOnly();
            grdFileList.View.AddTextBoxColumn("RESOURCEVERSION", 100)
                .SetIsHidden()
                .SetIsReadOnly();
            grdFileList.View.AddTextBoxColumn("COMMENTS", 300);

            grdFileList.View.PopulateColumns();
        }

        /// <summary>
        /// 체크한 항목이 있는지 확인
        /// </summary>
        private void ValidationCheckFile()
        {
            DataTable selectedFiles = grdFileList.View.GetCheckedRows();

            if (selectedFiles.Rows.Count < 1)
            {
                throw MessageException.Create("GridNoChecked");
            }
        }

        /// <summary>
        /// 체크한 파일들을 선택한 폴더에 다운로드
        /// </summary>
        /// <param name="files">체크한 파일 목록</param>
        /// <param name="type">다운로드 구분 (단일, 복수)</param>
        private void FileDownload(DataTable files, DownloadType type)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = Application.StartupPath;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                switch (type)
                {
                    case DownloadType.Single:
                        try
                        {
                            using (WebClient client = new WebClient())
                            {
                                string ftpServerPath = AppConfiguration.GetString("Application.Ftp.Url");
                                string ftpServerUserId = AppConfiguration.GetString("Application.Ftp.Id");
                                string ftpServerPassword = AppConfiguration.GetString("Application.Ftp.Password");

                                string serverPath = ftpServerPath + Format.GetString(files.Rows[0]["FILEPATH"]);
                                serverPath = serverPath + ((serverPath.EndsWith("/")) ? "" : "/") + Format.GetString(files.Rows[0]["SAFEFILENAME"]);

                                client.Credentials = new NetworkCredential(ftpServerUserId, ftpServerPassword);

                                client.DownloadFile(serverPath, string.Join("\\", folderBrowserDialog.SelectedPath, Format.GetString(files.Rows[0]["SAFEFILENAME"])));
                            }
                            //string serverPath = AppConfiguration.GetString("Application.Ftp.Url") + Format.GetString(files.Rows[0]["FILEPATH"]);
                            //serverPath = serverPath + ((serverPath.EndsWith("/")) ? "" : "/");
                            //DeployCommonFunction.DownLoadFile(serverPath, folderBrowserDialog.SelectedPath, Format.GetString(files.Rows[0]["SAFEFILENAME"]));
                        }
                        catch (Exception ex)
                        {
                            throw MessageException.Create(ex.Message);
                        }

                        break;
                    case DownloadType.Multi:
                        //throw new NotImplementedException();
                        files.Columns.Add("PROCESSINGSTATUS", typeof(string));

                        int totalFileSize = 0;

                        foreach (DataRow row in files.Rows)
                        {
                            row["PROCESSINGSTATUS"] = "Wait";

                            totalFileSize += Format.GetInteger(row["FILESIZE"]);
                        }

                        FileProgressDialog fileProgressDialog = new FileProgressDialog(files, UpDownType.Download, folderBrowserDialog.SelectedPath, totalFileSize);
                        fileProgressDialog.ShowDialog();

                        if (fileProgressDialog.DialogResult == DialogResult.Cancel)
                            throw MessageException.Create("파일 다운로드를 취소하였습니다.");


                        ProgressingResult result = fileProgressDialog.Result;

                        int resultCount = 0;

                        if (result.IsSuccess)
                            resultCount = result.SuccessFileCount;

                        grdFileList.View.CheckedAll(false);
                        //MSGBox.Show(MessageBoxType.Information, string.Format("{0} 건의 파일을 다운로드 하였습니다.", resultCount));

                        break;
                }
            }
        }

        /// <summary>
        /// 추가된 파일들을 서버에 업로드
        /// </summary>
        private int FileUpload()
        {
            DataTable addFiles = grdFileList.GetChangesAdded();
            addFiles.Columns.Add("PROCESSINGSTATUS", typeof(string));

            int totalFileSize = 0;

            foreach (DataRow row in addFiles.Rows)
            {
                row["PROCESSINGSTATUS"] = "Wait";

                totalFileSize += Format.GetInteger(row["FILESIZE"]);
            }

            addFiles.AcceptChanges();


            FileProgressDialog fileProgressDialog = new FileProgressDialog(addFiles, UpDownType.Upload, "", totalFileSize);
            fileProgressDialog.ShowDialog(this);

            if (fileProgressDialog.DialogResult == DialogResult.Cancel)
                throw MessageException.Create("파일 업로드를 취소하였습니다.");


            ProgressingResult result = fileProgressDialog.Result;

            if (result.IsSuccess)
                return result.SuccessFileCount;
            else
                return 0;

            //if (result.IsSuccess)
            //{
            //    MSGBox.Show(MessageBoxType.Information, "파일 업로드를 완료하였습니다." + Environment.NewLine + string.Format("성공 : {0}, 실패 : {1}", result.SuccessFileCount, result.FailFileCount));
            //}
            //else
            //{
            //    MSGBox.Show(MessageBoxType.Information, "파일 업로드를 실패하였습니다.");
            //}

            //try
            //{
            //    foreach (DataRow row in addFiles.Rows)
            //    {
            //        string fileName = Format.GetString(row["FILEPATH"]);
            //        string safeFileName = Format.GetString(row["FILENAME"]) + "." + Format.GetString(row["FILEEXT"]);

            //        if (!File.Exists(fileName))
            //            throw new Exception("File Not Exists.");

            //        byte[] byteFile;

            //        using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            //        {
            //            byteFile = new byte[fileStream.Length];
            //            fileStream.Read(byteFile, 0, byteFile.Length);
            //        }

            //        SmartDeployService.WebService webService = new SmartDeployService.WebService();
            //        string uploadResult = webService.UploadFile(byteFile, "UploadFile/", safeFileName);

            //        if (!uploadResult.Equals("SUCCESS"))
            //            throw new Exception("File Upload Fail.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw MessageException.Create(ex.Message);
            //}
        }
        /// <summary>
        /// 2019-11-16 강유라
        /// 품질 이상발생 저장시 임시저장한 파일 데이터테이블을 저장하는 함수
        /// 추가된 파일들을 서버에 업로드
        /// </summary>
        private int AddedFileUpload()
        {
            DataTable addFiles = grdFileList.DataSource as DataTable;
            addFiles.Columns.Add("PROCESSINGSTATUS", typeof(string));

            int totalFileSize = 0;

            foreach (DataRow row in addFiles.Rows)
            {
                row["PROCESSINGSTATUS"] = "Wait";

                totalFileSize += Format.GetInteger(row["FILESIZE"]);
            }

            addFiles.AcceptChanges();


            FileProgressDialog fileProgressDialog = new FileProgressDialog(addFiles, UpDownType.Upload, "", totalFileSize);
            fileProgressDialog.ShowDialog(this);

            if (fileProgressDialog.DialogResult == DialogResult.Cancel)
                throw MessageException.Create("파일 업로드를 취소하였습니다.");


            ProgressingResult result = fileProgressDialog.Result;

            if (result.IsSuccess)
                return result.SuccessFileCount;
            else
                return 0;
        }

        /// <summary>
        /// 체크한 파일들을 서버, DB 상에서 삭제
        /// </summary>
        private int FileDelete()
        {
            DataTable files = grdFileList.GetChangesDeleted();

            int deleteSuccessCount = 0;
            int deleteFailCount = 0;

            foreach (DataRow row in files.Rows)
            {
                if (DeployCommonFunction.RemoveFile(UploadPath, Format.GetString(row["SAFEFILENAME"])))
                    deleteFailCount++;
                else
                    deleteSuccessCount++;
            }

            return deleteSuccessCount;

            //grdFileList.View.DeleteCheckedRows();

            //MSGBox.Show(MessageBoxType.Information, "선택한 파일이 삭제되었습니다." + Environment.NewLine + string.Format("성공 : {0}, 실패 : {1}", deleteSuccessCount, deleteFailCount));
        }

        public void SaveChangedFiles()
        {
            int uploadFileCount = FileUpload();
            int deleteFileCount = FileDelete();

            //MSGBox.Show(MessageBoxType.Information, string.Format("{0} 건의 파일을 업로드 하였습니다.", uploadFileCount) + Environment.NewLine + string.Format("{0} 건의 파일을 삭제 하였습니다.", deleteFileCount));
        }

        /// <summary>
        /// 2019-11-16 강유라
        /// 품질이상 발생 임시저장한 파일 데이터 테이블 저장
        /// 임시저장 되었던 테이블을 grdFileList에 바인딩 시켜 업로드하기위해 사용
        /// 업로드만 가능
        /// </summary>
        public void SaveAddedFiles()
        {
            int uploadFileCount = AddedFileUpload();
            //MSGBox.Show(MessageBoxType.Information, string.Format("{0} 건의 파일을 업로드 하였습니다.", uploadFileCount) + Environment.NewLine + string.Format("{0} 건의 파일을 삭제 하였습니다.", deleteFileCount));
        }

        public DataTable GetChangedRows()
        {
            return grdFileList.GetChangedRows();
        }

        public void ClearData()
        {
            if (grdFileList.DataSource == null) return;
            grdFileList.View.ClearDatas();
        }

        #region Properties

        [DefaultValue(null)]
        public object DataSource
        {
            get
            {
                return grdFileList.DataSource;
            }
            set
            {
                grdFileList.DataSource = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ResourceInfo Resource { get; set; } = new ResourceInfo();

        public string UploadPath { get; set; } = "";

        [DefaultValue(false)]
        public bool UseCommentsColumn
        {
            get
            {
                return grdFileList.View.Columns["COMMENTS"].Visible;
            }
            set
            {
                grdFileList.View.Columns["COMMENTS"].Visible = value;
            }
        }

        [DefaultValue("GRIDFILELIST")]
        public string LanguageKey
        {
            get
            {
                return grdFileList.LanguageKey;
            }
            set
            {
                grdFileList.LanguageKey = value;
            }
        }

        [DefaultValue(true)]
        public bool ButtonVisible
        {
            get
            {
                return pnlFileUploadButton.Visible;
            }
            set
            {
                pnlFileUploadButton.Visible = value;
            }
        }

        #endregion

        #region ISupportMulitLanguage

        public void ChangeLanguage()
        {
            var languageControls = Controls.Find<ISupportMultiLanguage>(true).ToList();

            languageControls.ForEach(c => c.ChangeLanguage());
        }

        #endregion
    }

    public class ResourceInfo
    {
        public string Type { get; set; } = "";
        public string Id { get; set; } = "*";
        public string Version { get; set; } = "";
    }

    public class ProgressingResult
    {
        public bool IsSuccess { get; set; } = true;
        public int SuccessFileCount { get; set; } = 0;
        public int FailFileCount { get; set; } = 0;
    }
}
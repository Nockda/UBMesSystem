using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using SmartDeploy.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Micube.SmartMES.SystemManagement
{
    /// <summary>
    /// - 설      명 : 배포 파일 리스트 팝업창
    ///                DeployManagement에서 선택한 배포할 파일LIst
    ///                파일별 배포파일구분, 파일등록형식, 등록파일구분을 선택하고 배포예정일과 배포사유를 기입후 배포함.
    /// - 작  성  자 : 장선미
    /// - 최초작성일 : 2020.03.06
    /// - 주요변경로그  
    /// </summary>
    public partial class DeployFileListPopup : SmartPopupBaseForm
    {
        #region *** Member 변수 ***
        /// <summary>
        /// 배포대상 FileList
        /// </summary>
        private DataTable _dtFileList = null;
        /// <summary>
        /// 배포대상 Local 경로
        /// </summary>
        private string _strLocalPath = string.Empty;
        /// <summary>
        /// SmartDeployService Upload할 경로
        /// </summary>
        private string _strDeployUploadURL = string.Empty;
        /// <summary>
        /// xml 파일 Download할 경로
        /// </summary>
        private string _strDownloadTempPath = string.Empty;

        /// <summary>
        /// Deploy Server에 Upload할 폴더 경로 - Config에서 설정
        /// </summary>
        private static string _strUploadPath = AppConfiguration.GetString("Application.SmartDeploy.UploadPath");
        private static string _strServiceUrl = AppConfiguration.GetString("Application.SmartDeploy.Url");

        #endregion *** Member 변수 ***

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="dt">배포대상 File 정보</param>
        /// <param name="strLocalPath">배포 대상 File local 경로</param>
        /// <param name="strDeployUploadURL">SmartDeployService Upload할 경로</param>
        public DeployFileListPopup(DataTable dt, string strLocalPath, string strDeployUploadURL)
        {
            InitializeComponent();

            this._dtFileList = dt;
            this._strLocalPath = strLocalPath;
            this._strDeployUploadURL = strDeployUploadURL;
            this._strDownloadTempPath = Path.Combine(Application.StartupPath, "SmartDeploy", "DownloadTemp");

            this._dtFileList.Columns.Remove("BUILDCONFIGURATION");

            this._dtFileList.Columns.Add("UPDATEFILETYPE".ToUpper());
            this._dtFileList.Columns.Add("UPDATETYPE".ToUpper());
            this._dtFileList.Columns.Add("REGISTER".ToUpper());
            this._dtFileList.AcceptChanges();

            //foreach (DataRow dr in this._dtFileList.Rows)
            //{
            //    dr["UPDATEFILETYPE"] = UpdateFileType.Normal;
            //    dr["UPDATETYPE"] = UpdateType.FileRegister;
            //    dr["REGISTER"] = UpdateFileRegisterType.None;
            //}

            InitializeEvent();
        }

        #region *** 이벤트 ***

        private void InitializeEvent()
        {
            this.Load += DeployFileListPopup_Load;

            this.btnDefault.Click += BtnDefault_Click;
            this.btnDeploy.Click += BtnDeploy_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }

        /// <summary>
        /// 배포 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeploy_Click(object sender, EventArgs e)
        {
            DialogManager.ShowWaitDialog();
            try
            {
                DataTable dtDeployList = grdFileList.View.GetCheckedRows();

                if (dtDeployList == null || dtDeployList.Rows.Count < 1)
                {
                    //배포할 파일을 선택해주세요.
                    MSGBox.Show(MessageBoxType.Information, "14020");
                    return;
                }

                var files = from data in dtDeployList.AsEnumerable()
                            where data["UPDATETYPE"].ToString() == string.Empty
                            || data["UPDATEFILETYPE"].ToString() == string.Empty
                            || data["REGISTER"].ToString() == string.Empty
                            select data;

                if (files != null && files.Count() > 0)
                {
                    //배포파일의 상세옵션(파일구분, 등록형식, 등록파일형식)을 선택하세요.
                    MSGBox.Show(MessageBoxType.Information, "14021");
                    return;
                }

                if (string.IsNullOrWhiteSpace(this.txtDeployNote.Text))
                {
                    //배포사유를 입력하세요.
                    MSGBox.Show(MessageBoxType.Information, "14022");
                    this.txtDeployNote.Select();
                    this.txtDeployNote.Focus();
                    return;
                }

                //선택한 파일이 배포등록됩니다. 계속하시겠습니까?
                if (MSGBox.Show(MessageBoxType.Information, "14023", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                    return;

                string strDeployDate = dateDeployPlan.DateTime.ToString("yyyy-MM-dd HHmmss");
                string strUploadDatePath = _strUploadPath + strDeployDate + "/";
                string strUploadFilePath = string.Empty;

                bool chk = false;
                foreach (DataRow dr in dtDeployList.Rows)
                {
                    string strParentPath = DeployCommonFunction.GetSubPath(dr["PARENTPATH"].ToString());
                    strUploadFilePath = strUploadDatePath + strParentPath + "/";


                    foreach (string dir in dr["DIRPATH"].ToString().Split('\\'))
                    {
                        if (dir.Trim().Equals(string.Empty))
                            continue;

                        strUploadFilePath += dir + "/";
                    }

                    // 1. File Upload
                    chk = UploadFile(_strLocalPath, strUploadFilePath, dr["FILENAME"].ToString());
                    if (!chk)
                    {
                        // {0} 파일 Upload를 실패하였습니다.
                        MSGBox.Show(MessageBoxType.Warning, "14024", Path.Combine(_strLocalPath, dr["FILENAME"].ToString()));
                        return;
                    }
                }

                // 2. Fileinfo.xml 파일 생성 및 upload
                DeployCommonFunction.DownLoadFile(this._strDeployUploadURL + strDeployDate + "/", this._strDownloadTempPath, "FileInfo.xml");
                DeployCommonFunction.CreateFileInfoXMLFile(dtDeployList, dateDeployPlan.DateTime, UserInfo.Current.IdWithName, Path.Combine(this._strDownloadTempPath, "FileInfo.xml"));
                chk = UploadFile(this._strDownloadTempPath, strUploadDatePath, "FileInfo.xml");
                if (!chk)
                {
                    // {0} 파일 Upload를 실패하였습니다.
                    MSGBox.Show(MessageBoxType.Warning, "FileInfo.xml", "14024");
                    return;
                }

                // 4. PlanDeployFileInfo.xml 파일 생성 및 upload
                DeployCommonFunction.DownLoadFile(this._strDeployUploadURL, this._strDownloadTempPath, "PlanDeployFileInfo.xml");
                DeployCommonFunction.CreatePlanDeployFileInfoXMLFile(dtDeployList, dateDeployPlan.DateTime, UserInfo.Current.IdWithName, Path.Combine(this._strDownloadTempPath, "PlanDeployFileInfo.xml"));
                chk = UploadFile(this._strDownloadTempPath, _strUploadPath, "PlanDeployFileInfo.xml");
                if (!chk)
                {
                    // {0} 파일 Upload를 실패하였습니다.
                    MSGBox.Show(MessageBoxType.Warning, "PlanDeployFileInfo.xml", "14024");
                }

                // 5. DeployHistory.xml 파일 생성 및 upload
                DeployCommonFunction.DownLoadFile(this._strDeployUploadURL, this._strDownloadTempPath, "DeployHistory.xml");
                DeployCommonFunction.CreateDeployHistoryXMLFile(dateDeployPlan.DateTime, UserInfo.Current.IdWithName, txtDeployNote.Text, chkDeployDirect.EditValue.ToString(), Path.Combine(this._strDownloadTempPath, "DeployHistory.xml"));
                chk = UploadFile(this._strDownloadTempPath, _strUploadPath, "DeployHistory.xml");
                if (!chk)
                {
                    // {0} 파일 Upload를 실패하였습니다.
                    MSGBox.Show(MessageBoxType.Warning, "DeployHistory.xml", "14024");
                    return;
                }

                // return
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MSGBox.Show(MessageBoxType.Error, ex.ToString());
            }
            finally
            {
                DialogManager.Close();//.CloseDialog();
            }
        }

        /// <summary>
        /// SetDefault 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDefault_Click(object sender, EventArgs e)
        {
            DataTable temp = (grdFileList.DataSource as DataTable);
            foreach (DataRow item in temp.Rows)
            {
                item["UpdateFileType"] = "Normal";
                item["UpdateType"] = "Register";
                item["Register"] = "None";
            }
        }


        /// <summary>
        /// 취소 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        private void DeployFileListPopup_Load(object sender, EventArgs e)
        {
            InitializeGird();

            this.dateDeployPlan.EditValue = DateTime.Now.AddMinutes(10).ToString("yyyy-MM-dd HH:mm:00");
            this.dateDeployPlan.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.dateDeployPlan.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.dateDeployPlan.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm";
            this.dateDeployPlan.Properties.MinValue = DateTime.Now;
            this.dateDeployPlan.Properties.MaxValue = DateTime.Now.AddMonths(3);

        }

        #endregion

        private void InitializeGird()
        {
            grdFileList.ShowButtonBar = false;
            grdFileList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            //grdFileList.View.SetIsReadOnly();
            grdFileList.View.SetSortOrder("FILENAME");

            this.grdFileList.View.AddTextBoxColumn("FILENAME", 200)
              .SetTextAlignment(TextAlignment.Left)
              .SetIsReadOnly(true);

            this.grdFileList.View.AddTextBoxColumn("FILEEXTENSION", 120)
              .SetIsReadOnly(true);

            this.grdFileList.View.AddTextBoxColumn("FILESIZE", 100)
                .SetIsReadOnly(true)
                .SetTextAlignment(TextAlignment.Left);

            this.grdFileList.View.AddTextBoxColumn("PARENTPATH").SetIsHidden();


            this.grdFileList.View.AddTextBoxColumn("DIRPATH").SetIsHidden();


            this.grdFileList.View.AddTextBoxColumn("FILEFULLPATH").SetIsHidden();


            this.grdFileList.View.AddTextBoxColumn("FILEVERSION", 100)
                .SetIsReadOnly(true);


            this.grdFileList.View.AddTextBoxColumn("FILEMODIFYTIME", 120)
                .SetIsReadOnly(true);


            SqlQueryAdapter sqaUpdateFileType = GetSqlQueryAdapter(UpdateFileType.GetDTUpdateFileType, true);
            SqlQueryAdapter sqaUpdateType = GetSqlQueryAdapter(UpdateType.GetDTUpdateType, true);
            SqlQueryAdapter sqaUpdateFileRegisterType = GetSqlQueryAdapter(UpdateFileRegisterType.GetDTUpdateFileRegisterType, true);

            this.grdFileList.View.AddComboBoxColumn("UPDATEFILETYPE", 100, sqaUpdateFileType)
                .SetValidationIsRequired();
            this.grdFileList.View.AddComboBoxColumn("UPDATETYPE", 100, sqaUpdateType)
                .SetValidationIsRequired();
            this.grdFileList.View.AddComboBoxColumn("REGISTER", 100, sqaUpdateFileRegisterType)
                .SetValidationIsRequired();


            this.grdFileList.View.PopulateColumns();

            grdFileList.DataSource = this._dtFileList;

            grdFileList.View.SetNotAllowNullColumn("FILENAME", "UPDATEFILETYPE", "UPDATETYPE", "REGISTER");
            //grdFileList.SetKeyColumn("FileName", "UpdateFileType", "UpdateType", "Register");
            grdFileList.View.BestFitColumns();//.SetColumnBestFit();
            grdFileList.View.CheckedAll();
        }


        private SqlQueryAdapter GetSqlQueryAdapter(Dictionary<string, string> dic, bool valueIsDisplayMember = false)
        {
            try
            {
                SqlQueryAdapter sqaUpdateFileType = new SqlQueryAdapter();
                foreach (KeyValuePair<string, string> kvp in dic)
                {
                    if (valueIsDisplayMember)
                        sqaUpdateFileType.AddData(kvp.Value, kvp.Key);
                    else
                        sqaUpdateFileType.AddData(kvp.Key, kvp.Value);
                }

                return sqaUpdateFileType;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 파일 업로드 - Webservice 참조
        /// </summary>
        /// <param name="strLocalPath">Upload할 파일 Local 경로</param>
        /// <param name="strServerPath">Upload할 파일 Server 경로</param>
        /// <param name="strFileName">Upload할 파일명</param>
        /// <returns></returns>
        private bool UploadFile(string strLocalPath, string strServerPath, string strFileName)
        {
            bool bret = false;

            try
            {
                string filePath = Path.Combine(strLocalPath, strFileName);
                if (!File.Exists(filePath))
                    return false;

                byte[] fileBytes;
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    fileBytes = new byte[fileStream.Length];
                    fileStream.Read(fileBytes, 0, fileBytes.Length);
                }

                SmartDeployService.WebService deployService = new SmartDeployService.WebService();
                deployService.Url = _strServiceUrl;
                string strUpload = deployService.UploadFile(fileBytes, strServerPath, strFileName);

                if (strUpload.Equals("SUCCESS"))
                {
                    bret = true;
                }
                else
                {
                    bret = false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return bret;
        }

    }
}

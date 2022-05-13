#region using

using DevExpress.Utils.Menu;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Menu;
using DevExpress.XtraTreeList.Nodes;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid.BandedGrid;
using SmartDeploy.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Micube.SmartMES.SystemManagement
{
    /// <summary>
    /// 프 로 그 램 명  : 시스템 관리 > 배포 관리 > 파일 업데이트 관리
    /// 업  무  설  명  : 배포파일을 업로드한다.
    /// - 설      명 : 배포 관리 화면
    ///                1. 배포 서버의 서비스 실행 유무 확인. (배포파일 리스트 상단 라벨에서 확인가능)
    ///                2. 배포 서버의 최신 배포 파일 List 확인.
    ///                3. 로컬 파일을 선택하여 배포.
    ///                4. 배포 이력 확인
    /// 생    성    자  : 장선미
    /// 생    성    일  : 2020-03-06
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class DeployFileUpload : SmartConditionBaseForm
    {
        #region Local Variables

        /// <summary>
        /// Deploy Service에서 받아온 배포파일 리스트 조회
        /// </summary>
        private DataTable _dtServerFileList = null;

        /// <summary>
        /// Deploy Service Server 경로 (Config 파일에서 읽어옴.)
        /// </summary>
        private static string _strDeployServiceURL = AppConfiguration.GetString("Application.SmartDeploy.ServiceUrl");
        /// <summary>
        /// Deploy Service Upload 경로 (Config 파일에서 읽어옴.)
        /// </summary>
        private static string _strDeployUploadURL = AppConfiguration.GetString("Application.SmartDeploy.UploadUrl");

        #endregion

        #region 생성자

        public DeployFileUpload()
        {
            InitializeComponent();
        }

        #endregion

        #region 컨텐츠 영역 초기화

        /// <summary>
        /// 화면의 컨텐츠 영역을 초기화한다.
        /// </summary>
        protected override void InitializeContent()
        {
            base.InitializeContent();

            this.ConditionsVisible = false;

            // 컨트롤 초기화 로직 구성
            InitializeInfo();

            InitializeTree();

            InitializeGridLocalFileList();
            InitializeGridServerFileList();

            InitializeEvent();
        }

        private void InitializeInfo()
        {
            string serviceVersion = DeployCommonFunction.GetServerLastUpdateDate(_strDeployServiceURL + "Version.xml");
            if (string.IsNullOrEmpty(serviceVersion))
            {
                //Deploy Service Server 연결 실패
                this.lbService.Text = Language.GetMessage("14025").Message;
            }
            else
            {
                SmartDeployService.WebService webService = new SmartDeployService.WebService();
                if (webService.CallService())
                {
                    //SmartDeployService 실행 중...
                    this.lbService.Text = Language.GetMessage("14026").Message;
                }
                else
                {
                    if (webService.CallService())
                    {
                        //SmartDeployService 실행 중...
                        this.lbService.Text = Language.GetMessage("14026").Message;
                    }
                    else
                    {
                        //SmartDeployService 확인 요망
                        this.lbService.Text = Language.GetMessage("14027").Message;
                        this.lbService.ForeColor = Color.Red;
                    }
                }
                GetServerFileInfo();
            }
        }


        /// <summary>
        /// Tree 컨트롤 초기화
        /// </summary>
        private void InitializeTree()
        {
            this.treeFolder.SetShowSearchPanel(false);

            string[] strParentFolderKey = { "A", "P", "R", "S" };
            string[] strParentFolderValue = { "Application Path", "Program Files", "System Root", "System32" };

            DataTable dtTreeData = new DataTable();
            dtTreeData.Columns.Add("PARENTNODE");
            dtTreeData.Columns.Add("PARENTPATH");
            dtTreeData.Columns.Add("DIRPATH");
            dtTreeData.Columns.Add("VALUE");

            for (int i = 0; i < strParentFolderKey.Length; i++)
            {
                DataRow drNew = dtTreeData.NewRow();
                drNew["PARENTNODE"] = string.Empty;
                drNew["PARENTPATH"] = strParentFolderKey[i];
                drNew["DIRPATH"] = string.Empty;
                drNew["VALUE"] = strParentFolderValue[i];

                dtTreeData.Rows.Add(drNew);
            }

            if (this._dtServerFileList != null && this._dtServerFileList.Rows.Count > 0)
            {
                var lstFolder = (from files in this._dtServerFileList.AsEnumerable()
                                 select new
                                 {
                                     ParentPath = files["PARENTPATH"],
                                     DirPath = files["DIRPATH"]
                                 }).Distinct();

                if (lstFolder != null)
                {
                    foreach (var folder in lstFolder)
                    {
                        if (!folder.DirPath.ToString().Trim().Equals(string.Empty))
                        {
                            string[] strTemp = folder.DirPath.ToString().Split(new char[1] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                            for (int idx = 0; idx < strTemp.Length; idx++)
                            {
                                string dir = string.Empty;
                                for (int i = 0; i <= idx; i++)
                                    dir += "\\" + strTemp[i];

                                var node = (from nodes in dtTreeData.AsEnumerable()
                                            where nodes["PARENTPATH"].ToString() == folder.ParentPath.ToString()
                                            && nodes["DIRPATH"].ToString() == dir
                                            && nodes["VALUE"].ToString() == strTemp[idx]
                                            select nodes).FirstOrDefault();
                                if (node != null) continue;

                                DataRow drNew = dtTreeData.NewRow();
                                drNew["PARENTPATH"] = folder.ParentPath;
                                drNew["VALUE"] = strTemp[idx];
                                drNew["DIRPATH"] = dir;

                                if (idx < 1)
                                {
                                    for (int i = 0; i < strParentFolderKey.Length; i++)
                                    {
                                        if (folder.ParentPath.ToString().Equals(strParentFolderKey[i]))
                                        {
                                            drNew["PARENTNODE"] = strParentFolderValue[i];
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    drNew["PARENTNODE"] = strTemp[idx - 1];
                                }

                                dtTreeData.Rows.Add(drNew);
                            }
                        }
                    }
                }
            }

            //2017-04-25
            //this.treeFolder.SetTree(dtTreeData, "ParentNode", "Value", null);
            this.treeFolder.ParentFieldName = "PARENTNODE";
            this.treeFolder.KeyFieldName = "VALUE";
            this.treeFolder.RootValue = null;
            this.treeFolder.DataSource = dtTreeData;

            //this.treeFolder.SetTreeVisibleColumn(new List<string> { "Value" });
            this.treeFolder.Columns.AddVisible("VALUE");
            this.treeFolder.SelectImageList = this.trImageCollection;
            this.treeFolder.GetSelectImage += (o, e) =>
            {
                e.NodeImageIndex = 0;
            };
            //this.treeFolder.SetTreeView = true;

            //2019.04.09 박윤신 수정중
            #region
            //this.treeFolder.SetProperties();
            //this.treeFolder.ContextMenuStrip.Enabled = true;//.UseContextMenu = true;
            //this.treeFolder.ContextMenuStrip.Visible = true;//.UseContextMenu = true;
            //this.treeFolder.View.OptionsBehavior.Editable = true;
            //this.treeFolder.ContextMenuEditable = true;
            //this.treeFolder.EditableColumns = new List<string>() { "Value" };
            this.treeFolder.OptionsBehavior.ImmediateEditor = false;

            #endregion

        }



        /// <summary>        
        /// 코드그룹 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeGridLocalFileList()
        {
            // 그리드 초기화
            //grdLocalFileList.GridButtonItem = GridButtonItem.All;
            grdLocalFileList.ShowButtonBar = false;
            grdLocalFileList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdLocalFileList.View.SetIsReadOnly();
            grdLocalFileList.View.SetSortOrder("FILENAME");

            //grdObject.View.SetAutoFillColumn("OBJECTNAME");

            //파일명
            grdLocalFileList.View.AddTextBoxColumn("FILENAME", 200);

            //파일 확장자
            grdLocalFileList.View.AddTextBoxColumn("FILEEXTENSION", 120);

            //파일 크기
            grdLocalFileList.View.AddTextBoxColumn("FILESIZE", 100)
                .SetTextAlignment(TextAlignment.Left);

            //파일 버전
            grdLocalFileList.View.AddTextBoxColumn("FILEVERSION", 100);

            //파일 수정일
            grdLocalFileList.View.AddTextBoxColumn("FILEMODIFYTIME", 130);

            //파일 전체 경로
            grdLocalFileList.View.AddTextBoxColumn("FILEFULLPATH", 100)
                .SetIsHidden();

            //파일 빌드Type - Debug로 빌드된 파일일 경우 Bold 처리
            grdLocalFileList.View.AddTextBoxColumn("BUILDCONFIGURATION", 100)
                .SetIsHidden();

            grdLocalFileList.View.PopulateColumns();

            grdLocalFileList.View.OptionsCustomization.AllowFilter = false;
            grdLocalFileList.View.OptionsCustomization.AllowSort = false;
        }

        /// <summary>        
        /// 코드 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeGridServerFileList()
        {
            // 그리드 초기화
            grdServerFileList.ShowButtonBar = false;
            grdServerFileList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdServerFileList.View.SetIsReadOnly();
            grdServerFileList.View.SetSortOrder("FILENAME");

            //파일명
            grdServerFileList.View.AddTextBoxColumn("FILENAME", 200);

            //파일 확장자
            grdServerFileList.View.AddTextBoxColumn("FILEEXTENSION", 120);

            //파일 크기
            grdServerFileList.View.AddTextBoxColumn("FILESIZE", 100)
                .SetTextAlignment(TextAlignment.Left);

            //파일 버전
            grdServerFileList.View.AddTextBoxColumn("FILEVERSION", 100);

            //파일 수정일
            grdServerFileList.View.AddTextBoxColumn("FILEMODIFYTIME", 130);

            //파일 배포일
            grdServerFileList.View.AddTextBoxColumn("DEPLOYDATE", 130);

            //파일 배포자
            grdServerFileList.View.AddTextBoxColumn("DEPLOYER", 80);

            SqlQueryAdapter sqaUpdateFileType = GetSqlQueryAdapter(UpdateFileType.GetDTUpdateFileType, true);
            SqlQueryAdapter sqaUpdateType = GetSqlQueryAdapter(UpdateType.GetDTUpdateType, true);
            SqlQueryAdapter sqaUpdateFileRegisterType = GetSqlQueryAdapter(UpdateFileRegisterType.GetDTUpdateFileRegisterType, true);

            grdServerFileList.View.AddComboBoxColumn("UPDATEFILETYPE", 100, sqaUpdateFileType);
            grdServerFileList.View.AddComboBoxColumn("UPDATETYPE", 100, sqaUpdateType);
            grdServerFileList.View.AddComboBoxColumn("REGISTER", 100, sqaUpdateFileRegisterType);

            grdServerFileList.View.PopulateColumns();
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            this.btnPathChange.Click += btnPathChange_Click;
            this.btnDeploy.Click += btnDeploy_Click;
            this.btnDeployHistory.Click += btnDeployHistory_Click;

            this.txtLocalPath.EnterKeyDown += TxtLocalPath_EnterKeyDown;

            this.treeFolder.FocusedNodeChanged += treeFolder_FocusedNodeChanged;
            this.treeFolder.CellValueChanged += treeFolder_CellValueChanged;

            this.grdLocalFileList.View.RowStyle += Grid_RowStyle;
            this.grdServerFileList.View.RowStyle += Grid_RowStyle;


            treeFolder.MouseDown += TreeFolder_MouseDown;
        }

        /// <summary>
        /// Local Path text 에 직접 입력 후 enter key 입력시 입력 경로의 파일목록을 읽어오는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtLocalPath_EnterKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                SetLocalFolderFileList(txtLocalPath.Text);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Grid RowStyle - Local File List 와 Server File List 에서 파일 크기, 버전, 수정일자가 다를 경우 Row BackColor 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            SmartBandedGridView sgvChange = sender as SmartBandedGridView;
            SmartBandedGridView sgvTarget = null;
            if (sgvChange.GridControl.Name == "grdLocalFileList")
                sgvTarget = this.grdServerFileList.View;
            else
                sgvTarget = this.grdLocalFileList.View;

            for (int i = 0; i < sgvTarget.RowCount; i++)
            {
                if (sgvTarget.GetRowCellValue(i, "FILENAME").Equals(sgvChange.GetRowCellValue(e.RowHandle, "FILENAME")))
                {
                    if (!sgvTarget.GetRowCellDisplayText(i, "FILESIZE").Equals(sgvChange.GetRowCellDisplayText(e.RowHandle, "FILESIZE")) ||
                        !sgvTarget.GetRowCellDisplayText(i, "FILEVERSION").Equals(sgvChange.GetRowCellDisplayText(e.RowHandle, "FILEVERSION")) ||
                        !sgvTarget.GetRowCellDisplayText(i, "FILEMODIFYTIME").Equals(sgvChange.GetRowCellDisplayText(e.RowHandle, "FILEMODIFYTIME")))
                    {
                        e.Appearance.BackColor = Color.Orange;
                    }

                    break;
                }
            }
        }


        #region Button Event
        /// <summary>
        /// 경로 변경 버튼 클릭 이벤트 - Local 파일 경로를 지정하여 배포할 파일을 선택할수 있도록 함.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPathChange_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                folderDlg.SelectedPath = this.txtLocalPath.Text;

                if (folderDlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                this.txtLocalPath.Text = folderDlg.SelectedPath;
                SetLocalFolderFileList(folderDlg.SelectedPath);
            }
            catch (Exception)
            {
            }
            finally
            {
            }
        }

        /// <summary>
        /// 배포 버튼 클릭 이벤트 - Local File List 에서 선택된 파일목록으로 배포화면 Popup 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeploy_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtFileList = grdLocalFileList.View.GetCheckedRows();

                if (dtFileList == null || dtFileList.Rows.Count < 1)
                {
                    MSGBox.Show(MessageBoxType.Information, "배포할 파일을 선택해주세요.");
                    return;
                }

                dtFileList.Columns.Add("PARENTPATH");
                dtFileList.Columns.Add("DIRPATH");
                foreach (DataRow dr in dtFileList.Rows)
                {
                    dr["PARENTPATH"] = this.treeFolder.FocusedNode["PARENTPATH"];
                    dr["DIRPATH"] = this.treeFolder.FocusedNode["DIRPATH"];
                }
                dtFileList.AcceptChanges();

                DeployFileListPopup popFileUploader = new DeployFileListPopup(dtFileList, txtLocalPath.Text, _strDeployUploadURL);
                if (popFileUploader.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Server File List
                    GetServerFileInfo();
                    SetServerFolderFileList(this.treeFolder.FocusedNode["PARENTPATH"].ToString(), this.treeFolder.FocusedNode["DIRPATH"].ToString());
                }

                grdLocalFileList.View.UncheckedAll();
                grdLocalFileList.Update();

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// 배포 이력 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeployHistory_Click(object sender, EventArgs e)
        {
            DeployHistoryListPopup deployHist = new DeployHistoryListPopup(_strDeployUploadURL);
            deployHist.ShowDialog();

        }

        #endregion

        #region Folder 구조 추가 / 삭제 기능

        /// <summary>
        /// Tree Focuse Node Chanage - Tree 내 폴더 선택시 해당 폴더 File List 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeFolder_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            // 선택된 폴더 파일 리스트 조회
            SetFileList();
        }

        /// <summary>
        /// Tree 노드 추가시 노트명 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeFolder_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            e.Node["PARENTPATH"] = e.Node.ParentNode["PARENTPATH"].ToString();
            e.Node["DIRPATH"] = e.Node.ParentNode["DIRPATH"].ToString() + "\\" + e.Value;

            ChildrenNodeCellValueChange(e.Node);
        }


        private void TreeFolder_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button.Equals(System.Windows.Forms.MouseButtons.Right) && this.treeFolder.FocusedNode.GetValue(this.treeFolder.KeyFieldName) != null)
            {
                TreeListHitInfo hitInfo = (sender as TreeList).CalcHitInfo(e.Location);
                TreeListNode node = hitInfo.Node;
                if (node == null) return;
                TreeListMenu menu = new TreeListMenu(sender as TreeList);
                DXMenuItem DeleteMenu = new DXMenuItem("노드삭제", new EventHandler(deleteNodeMenuItemClick));
                DXMenuItem AppendMenu = new DXMenuItem("노드추가", new EventHandler(appendNodeMenuItemClick));
                menu.Items.Add(DeleteMenu);
                menu.Items.Add(AppendMenu);
                menu.Show(e.Location);
            }
        }
        /// <summary>
        /// 노드 삭제할 때 함수입니다.
        /// </summary>
        private void deleteNodeMenuItemClick(object sender, EventArgs e)
        {
            //string selectedNodeValue = this.SelectedNode.GetValue(KeyFieldName).ToString();
            this.treeFolder.DeleteSelectedNodes();
        }

        /// <summary>
        /// 노드 추가할 때 함수입니다.
        /// </summary>
        private void appendNodeMenuItemClick(object sender, EventArgs e)
        {
            if (this.treeFolder.DataSource != null)
            {
                DataTable dt = this.treeFolder.DataSource as DataTable;
                DataRow appendNode = dt.NewRow();

                this.treeFolder.AppendNode(appendNode, this.treeFolder.FocusedNode);
                this.treeFolder.FocusedNode.Expanded = true;
                this.Refresh();
            }
        }

        #endregion

        #endregion

        #region 툴바

        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable dtObject = grdLocalFileList.GetChangedRows();
            DataTable dtObjectAttribute = grdServerFileList.GetChangedRows();

            MessageWorker worker = new MessageWorker("SaveObject");
            worker.SetBody(new MessageBody()
            {
                { "object", dtObject },
                { "objectAttribute", dtObjectAttribute}
            });
            worker.Execute();
        }

        #endregion

        #region 검색

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            int beforeHandle = grdLocalFileList.View.FocusedRowHandle;
            grdLocalFileList.View.FocusedRowHandle = -1;

            var values = Conditions.GetValues();
            values.Add("p_CODECLASSID", "");
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtObject = await QueryAsync("SelectObject", "00001", values);

            if (dtObject.Rows.Count < 1)
            {
                // 조회할 데이터가 없습니다.
                ShowMessage("NoSelectData");
                dtObject.Clear();
            }

            grdLocalFileList.DataSource = dtObject;
            //focusedRowChanged();

            //if (beforeHandle >= 0)
            //{
            //    if (dtObject.Rows.Count <= beforeHandle)
            //    {
            //        grdObject.View.FocusedRowHandle = 0;
            //    }
            //    else
            //    {
            //        grdObject.View.FocusedRowHandle = beforeHandle;
            //    }
            //}
        }

        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

        }

        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터를 저장 할 때 컨텐츠 영역의 유효성을 검사한다.
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();

            grdLocalFileList.View.CheckValidation();
            grdServerFileList.View.CheckValidation();

            DataTable dtObject = grdLocalFileList.GetChangedRows();
            DataTable dtObjectAttribute = grdServerFileList.GetChangedRows();

            if (dtObject.Rows.Count == 0 && dtObjectAttribute.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function

        /// <summary>
        /// GetServerFileInfo - Deploy Server에 있는 FileInfo.xml 와 PlanDeployFileInfo.xml 로 배포파일 리스트 조회
        /// </summary>
        private void GetServerFileInfo()
        {
            try
            {
                DataTable dtFileInfo = DeployCommonFunction.GetServerFileInfoList(_strDeployServiceURL + "FileInfo.xml");
                DataTable dtPlanDeployFileInfo = DeployCommonFunction.GetServerFileInfoList(_strDeployUploadURL + "PlanDeployFileInfo.xml");

                if (dtPlanDeployFileInfo != null && dtPlanDeployFileInfo.Rows.Count > 0)
                {
                    var planMaxFileInfo = (from row in dtPlanDeployFileInfo.AsEnumerable()
                                           group row by new { ParentPath = row["PARENTPATH"], DirPath = row["DIRPATH"], FileName = row["FILENAME"] } into data
                                           select new
                                           {
                                               ParentPath = data.Key.ParentPath,
                                               DirPath = data.Key.DirPath,
                                               FileName = data.Key.FileName,
                                               DeployDate = data.Max(file => file["DEPLOYDATE"])
                                           });

                    DataTable dtData = dtPlanDeployFileInfo.Clone();

                    foreach (var file in planMaxFileInfo)
                    {
                        DataRow drFile = (from files in dtPlanDeployFileInfo.AsEnumerable()
                                          where files["PARENTPATH"].ToString() == file.ParentPath.ToString()
                                                 && files["DIRPATH"].ToString() == file.DirPath.ToString()
                                                 && files["FILENAME"].ToString() == file.FileName.ToString()
                                                 && files["DEPLOYDATE"].ToString() == file.DeployDate.ToString()
                                          select files).FirstOrDefault();


                        DataRow drNew = dtData.NewRow();
                        foreach (DataColumn dc in dtData.Columns)
                        {
                            drNew[dc.ColumnName] = drFile[dc.ColumnName];
                        }

                        dtData.Rows.Add(drNew);
                    }
                    dtPlanDeployFileInfo = dtData;
                }

                if (dtFileInfo != null)
                    this._dtServerFileList = dtFileInfo.Copy();

                if (this._dtServerFileList != null && this._dtServerFileList.Rows.Count > 0)
                {
                    if (dtPlanDeployFileInfo != null && dtPlanDeployFileInfo.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtPlanDeployFileInfo.Rows)
                        {
                            DataRow drFile = (from files in this._dtServerFileList.AsEnumerable()
                                              where files["PARENTPATH"].ToString() == dr["PARENTPATH"].ToString()
                                                     && files["DIRPATH"].ToString() == dr["DIRPATH"].ToString()
                                                     && files["FILENAME"].ToString() == dr["FILENAME"].ToString()
                                              select files).FirstOrDefault();

                            if (drFile != null)
                            {
                                foreach (DataColumn dc in this._dtServerFileList.Columns)
                                {
                                    drFile[dc.ColumnName] = dr[dc.ColumnName];
                                }
                                this._dtServerFileList.AcceptChanges();
                            }
                            else
                            {
                                DataRow drNew = this._dtServerFileList.NewRow();
                                foreach (DataColumn dc in this._dtServerFileList.Columns)
                                {
                                    drNew[dc.ColumnName] = dr[dc.ColumnName];
                                }
                                this._dtServerFileList.Rows.Add(drNew);
                            }
                        }
                    }
                }
                else
                {
                    if (dtPlanDeployFileInfo != null)
                        this._dtServerFileList = dtPlanDeployFileInfo.Copy();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// 선택한 로컬 경로의 하위 파일 리스트 조회
        /// </summary>
        private void SetLocalFolderFileList(string strPath)
        {
            if (System.IO.Directory.Exists(strPath))
            {
                SortedSet<string> sorteFileList = new SortedSet<string>();

                try
                {
                    string[] strFiles = System.IO.Directory.GetFiles(strPath, "*", SearchOption.TopDirectoryOnly);

                    foreach (var file in strFiles)
                    {
                        if (!Path.GetExtension(file).Equals(".pdb", StringComparison.CurrentCultureIgnoreCase))
                            sorteFileList.Add(file);
                    }
                }
                catch   // 에러발생(접근 불가 디렉토리)이면 return;
                {
                    this.txtLocalPath.Text = string.Empty;
                    this.grdLocalFileList.DataSource = null;
                    MSGBox.Show(MessageBoxType.Error, "오류", "해당 디렉토리 조회 중 오류 발생", MessageBoxButtons.OK);
                    return;
                }

                if (sorteFileList.Count > 2000)
                {
                    DialogResult result = MSGBox.Show(MessageBoxType.Information, "조회 과정이 오래 걸릴 수 있습니다. 계속하시겠습니까?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        this.txtLocalPath.Text = string.Empty;
                        this.grdLocalFileList.DataSource = null;
                        return;
                    }
                }

                DialogManager.ShowWaitDialog();

                DataTable localFileList = new DataTable();
                localFileList.Columns.Add("FILENAME");
                localFileList.Columns.Add("FILEEXTENSION");
                localFileList.Columns.Add("FILESIZE");
                localFileList.Columns.Add("FILEVERSION");
                localFileList.Columns.Add("FILEMODIFYTIME");
                localFileList.Columns.Add("FILEFULLPATH");
                localFileList.Columns.Add("BUILDCONFIGURATION");

                // 선택된 디렉토리의 모든 파일을 출력합니다.
                Parallel.ForEach(sorteFileList,
                        fileFullPath =>
                        {
                            string version = System.Diagnostics.FileVersionInfo.GetVersionInfo(fileFullPath).FileVersion;
                            System.IO.FileInfo fileInfo = new FileInfo(fileFullPath);
                            string strDebugMode = string.Empty;

                            #region DebugMode 판단
                            try
                            {
                                //// 어셈블리 파일이 디버그 빌드 모드로 빌드되었는지 검사
                                if (fileInfo.Extension == ".exe" || fileInfo.Extension == ".dll")
                                {
                                    Assembly asmName = Assembly.LoadFrom(fileFullPath);

                                    object[] debugAttribute = asmName.GetCustomAttributes(typeof(DebuggableAttribute), false);

                                    // DebuggableAttribute를 가지지 않는 어셈블리는 Release 빌드된 것
                                    if (debugAttribute.Length > 0)
                                    {
                                        DebuggableAttribute debuggableAttribute = debugAttribute[0] as DebuggableAttribute;

                                        if (debuggableAttribute != null)
                                        {
                                            // 디버그 빌드된 어셈블리는 JIT 컴파일러 코드 최적화 작동불가
                                            if (debuggableAttribute.IsJITOptimizerDisabled == true)
                                            {
                                                lock (localFileList)
                                                {
                                                    strDebugMode = "DEBUGBUILD";
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            catch
                            {

                            }
                            #endregion

                            DataRow newRow = null;
                            lock (localFileList)
                            {
                                newRow = localFileList.Rows.Add(
                                    fileInfo.Name,
                                    fileInfo.Extension,
                                    fileInfo.Length,
                                    version,
                                    fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                    fileFullPath,
                                    strDebugMode
                                    );
                            }
                        }
                    );

                localFileList.DefaultView.Sort = "FILENAME";
                DataTable sortFileList = localFileList.DefaultView.ToTable();
                this.grdLocalFileList.DataSource = sortFileList;
                this.grdLocalFileList.View.BestFitColumns();//.SetColumnBestFit();

                // File 이 Debug빌드 된 경우 Bold 폰트로 강조 표시
                this.grdLocalFileList.View.FormatConditions.Clear();
                DevExpress.XtraGrid.StyleFormatCondition cn = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal);
                cn.ColumnName = "BUILDCONFIGURATION";
                cn.Value1 = "DEBUGBUILD";
                cn.ApplyToRow = true;
                cn.Appearance.Font = new Font(cn.Appearance.Font, FontStyle.Bold);
                this.grdLocalFileList.View.FormatConditions.Add(cn);

                DialogManager.Close();
            }
            else
            {
                this.txtLocalPath.Text = string.Empty;
                this.grdLocalFileList.DataSource = null;
            }

        }

        /// <summary>
        /// Server에 배포된 파일을 폴더별로 리스트 조회
        /// </summary>
        /// <param name="strParentKey"></param>
        /// <param name="strDirPath"></param>
        private void SetServerFolderFileList(string strParentKey, string strDirPath)
        {
            try
            {
                if (this._dtServerFileList == null || this._dtServerFileList.Rows.Count < 1)
                {
                    this.grdServerFileList.DataSource = null;
                    return;
                }

                var fileInfo = (from files in this._dtServerFileList.AsEnumerable()
                                where files["PARENTPATH"].ToString() == strParentKey
                                     && files["DIRPATH"].ToString() == strDirPath
                                select files);

                if (fileInfo == null || fileInfo.Count() < 1)
                {
                    this.grdServerFileList.DataSource = null;
                    this.grdServerFileList.View.BestFitColumns();//.SetColumnBestFit();
                }
                else
                {
                    this.grdServerFileList.DataSource = fileInfo.CopyToDataTable();
                    this.grdServerFileList.View.BestFitColumns();//.SetColumnBestFit();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// InitFileList - Gird에 보여질 File 목록 조회
        /// </summary>
        private void SetFileList()
        {
            try
            {
                string strParentKey = this.treeFolder.FocusedNode["PARENTPATH"].ToString();
                string strPath = DeployCommonFunction.GetLocalFolderPath(strParentKey);
                string strDirPath = this.treeFolder.FocusedNode["DIRPATH"].ToString();
                string strNewPath = string.Empty;
                if (strParentKey != strDirPath)
                {
                    strNewPath = Path.Combine(strPath, strDirPath.TrimStart('\\'));
                }

                // Local File List
                this.txtLocalPath.Text = strNewPath;
                SetLocalFolderFileList(strNewPath);

                // Server File List
                SetServerFolderFileList(strParentKey, strDirPath);

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// Tree 노드 명 변경시 하위 노드까지 DirPath 변경
        /// </summary>
        /// <param name="node"></param>
        private void ChildrenNodeCellValueChange(DevExpress.XtraTreeList.Nodes.TreeListNode node)
        {
            if (node.HasChildren)
            {
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode childNode in node.Nodes)
                {
                    childNode["PARENTNODE"] = childNode.ParentNode["VALUE"];
                    childNode["PARENTPATH"] = childNode.ParentNode["PARENTPATH"];
                    childNode["DIRPATH"] = childNode.ParentNode["DIRPATH"] + "\\" + childNode["VALUE"];

                    ChildrenNodeCellValueChange(childNode);
                }
            }
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

        #endregion   
    }
}

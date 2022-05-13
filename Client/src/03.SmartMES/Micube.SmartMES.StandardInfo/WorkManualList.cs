#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;

using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

using DevExpress.Utils;

#endregion

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 항목관리 > 작업메뉴얼
    /// 업  무  설  명  : 작업메뉴얼을 확인 및 관리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-04-08
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class WorkManualList : SmartConditionBaseForm
    {
        public WorkManualList()
        {
            InitializeComponent();
        }

        #region 컨텐츠 영역 초기화

        /// <summary>
        /// 화면의 컨텐츠 영역을 초기화한다.
        /// </summary>
        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeEvent();

            // 컨트롤 초기화 로직 구성
            InitializeMaster();
            InitializeItem();
        }

        private void InitializeMaster()
        {
            grdMaster.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdMaster.GridButtonItem = GridButtonItem.All;

            grdMaster.View.SetSortOrder("WORKMANUALID");
            grdMaster.View.SetAutoFillColumn("DESCRIPTION");

            grdMaster.View.AddTextBoxColumn("WORKMANUALID",80)
                .SetValidationKeyColumn()
                .SetValidationIsRequired();
            grdMaster.View.AddTextBoxColumn("WORKMANUALNAME", 100);
            CheckListPopup();
            if (UserInfo.Current.LanguageType == Commons.Constants.LanguageType_KO_KR)
            {
                grdMaster.View.AddTextBoxColumn("PROCESSNAMEKOR", 100)
                    .SetIsReadOnly();
            }
            if (UserInfo.Current.LanguageType == Commons.Constants.LanguageType_EN_US)
            {
                grdMaster.View.AddTextBoxColumn("PROCESSNAMEENG", 100)
                    .SetIsReadOnly();
            }
            if (UserInfo.Current.LanguageType == Commons.Constants.LanguageType_zh_CN)
            {
                grdMaster.View.AddTextBoxColumn("PROCESSNAMEJPN", 100)
                    .SetIsReadOnly();
            }
            grdMaster.View.AddComboBoxColumn("AREAID", 150, new SqlQuery("GetCodeList", "00001", "CODECLASSID=AreaCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddComboBoxColumn("WORKGROUPID", 150, new SqlQuery("GetCodeList", "00001", "CODECLASSID=TeamCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("DESCRIPTION", 150);
            grdMaster.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.PopulateColumns();
        }

        private void CheckListPopup()
        {
            var popupColumn = grdMaster.View.AddSelectPopupColumn("PROCESSID", new SqlQuery("GetProcessCode", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("SELECTPARENTCODECLASSID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupResultMapping("PROCESSID", "PROCESSID")
                .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                .SetPopupAutoFillColumns("ITEMNAME")
                //.SetValidationKeyColumn()
                //.SetValidationIsRequired()
                .SetPopupApplySelection((selectedRows, dataGridRow) =>
                {
                    DataRow classRow = grdMaster.View.GetFocusedDataRow();

                    foreach (DataRow row in selectedRows)
                    {
                        classRow["PROCESSNAMEKOR"] = row["PROCESSNAMEKOR"];
                        classRow["PROCESSNAMEENG"] = row["PROCESSNAMEENG"];
                        classRow["PROCESSNAMEJPN"] = row["PROCESSNAMEJPN"];
                    }
                });

            popupColumn.GridColumns.AddTextBoxColumn("PROCESSID", 80);
            if (UserInfo.Current.LanguageType == Commons.Constants.LanguageType_KO_KR)
            {
                popupColumn.GridColumns.AddTextBoxColumn("PROCESSNAMEKOR", 150);
            }
            if (UserInfo.Current.LanguageType == Commons.Constants.LanguageType_EN_US)
            {
                popupColumn.GridColumns.AddTextBoxColumn("PROCESSNAMEENG", 150);
            }
            if (UserInfo.Current.LanguageType == Commons.Constants.LanguageType_zh_CN)
            {
                popupColumn.GridColumns.AddTextBoxColumn("PROCESSNAMEJPN", 150);
            }
            popupColumn.GridColumns.AddTextBoxColumn("PARENTPROCESSID", 80);
        }


        /// <summary>        
        /// 관리 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeItem()
        {
            grdItem.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;

            // 그리드 초기화
            grdItem.GridButtonItem = GridButtonItem.All;

            grdItem.View.SetSortOrder("REVISIONID");
            grdItem.View.SetAutoFillColumn("DESCRIPTION");

            grdItem.View.AddTextBoxColumn("WORKMANUALID", 80)
                .SetIsReadOnly()
                .SetValidationKeyColumn()
                .SetValidationIsRequired();
            grdItem.View.AddTextBoxColumn("REVISIONID", 80)
                .SetValidationKeyColumn()
                .SetValidationIsRequired();
            grdItem.View.AddTextBoxColumn("REVISIONNAME", 150);
            grdItem.View.AddTextBoxColumn("DESCRIPTION", 150);
            grdItem.View.AddTextBoxColumn("FILESTATE", 50)
                .SetDefault("No")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdItem.View.AddTextBoxColumn("FILENAME", 150)
                .SetIsReadOnly();
            grdItem.View.AddTextBoxColumn("FILEDATA", 120)
                .SetIsHidden();
            grdItem.View.AddButtonColumn("FILESELECT", 50);
            grdItem.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdItem.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdItem.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdItem.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdItem.View.PopulateColumns();

        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            grdMaster.View.AddingNewRow += View_AddingNewRow;
            grdMaster.View.FocusedRowChanged += View_FocusedRowChanged;

            grdItem.View.AddingNewRow += View_AddingNewRowForItem;
            grdItem.View.GridCellButtonClickEvent += View_GridCellButtonClickEvent;
            grdItem.View.CellValueChanged += View_CellValueChanged;
            grdItem.View.DoubleClick += View_DoubleClick;
            btnSaveItem.Click += BtnSaveItem_Click;
 
        }

        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            DataRow focusRow = grdMaster.View.GetFocusedDataRow();
        }

        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            focusedRowChanged();
        }

        private void View_AddingNewRowForItem(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            DataRow focusRow = grdMaster.View.GetFocusedDataRow();
            string masterId = focusRow["WORKMANUALID"].ToString();
            args.NewRow["WORKMANUALID"] = masterId;
        }

        private void View_GridCellButtonClickEvent(SmartBandedGridView sender, GridCellButtonClickEventArgs args)
        {
            if (!args.FieldName.Equals("FILESELECT"))
                return;

            using (OpenFileDialog openfileDialog = new OpenFileDialog())
            {
                openfileDialog.RestoreDirectory = true;
                openfileDialog.Filter = "PDF|*.pdf";


                if (openfileDialog.ShowDialog() == DialogResult.OK)
                {
                    string file = openfileDialog.FileName;

                    string fileName = Path.GetFileName(file);
                    byte[] fileBytes = getFileBytes(file);

                    string base64FileData = Convert.ToBase64String(fileBytes);

                    grdItem.View.SetRowCellValue(grdItem.View.FocusedRowHandle, "FILEDATA", base64FileData);
                    grdItem.View.SetRowCellValue(grdItem.View.FocusedRowHandle, "FILENAME", fileName);
                }
            }
        }

        private void View_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals("FILEDATA"))
            {
                DataRow row = (sender as SmartBandedGridView).GetFocusedDataRow();
                string fileData = row["FILEDATA"].ToString();

                if(fileData.Length > 0)
                {
                    grdItem.View.SetFocusedRowCellValue("FILESTATE", "Yes");
                }
            }

        }

        private void View_DoubleClick(object sender, EventArgs e)
        {
            if (grdItem.View.FocusedRowHandle < 0)
                return;

            DataRow row = (sender as SmartBandedGridView).GetFocusedDataRow();

            if (row["FILEDATA"].ToString() == "")
            {
                ShowMessage("NoSelectData");
                return;
            }

            byte[] fileBytes = Convert.FromBase64String(row["FILEDATA"].ToString());


            System.IO.Directory.CreateDirectory(@"C:\WorkStandardFiles");

            string strDownloadPath = @"C:\WorkStandardFiles\" + row["FILENAME"].ToString();

            File.WriteAllBytes(strDownloadPath, fileBytes);

            System.Diagnostics.Process.Start(strDownloadPath);



        }

        private void BtnSaveItem_Click(object sender, EventArgs e)
        {
            grdItem.View.CheckValidation();

            try
            {
                this.ShowWaitArea();
                btnSaveItem.Focus();
                btnSaveItem.Enabled = false;

                DataTable changed = grdItem.GetChangedRows();//변경된 row
                if (changed.Rows.Count == 0)
                {
                    throw MessageException.Create("NoSaveData");
                }

                ExecuteRule("SaveWorkManualDetail", changed);

                ShowMessage("SuccessSave");
            }
            catch(Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.CloseWaitArea();
                btnSaveItem.Enabled = true;
            }
        } 

        #endregion

        #region ToolBar
        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdMaster.GetChangedRows();

            ExecuteRule("SaveWorkManualMaster", changed);
        }
        #endregion

        #region Search

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtMaster = await QueryAsync("GetWorkManualMaster", "00001", values);

            if (dtMaster.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdMaster.DataSource = dtMaster;
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
        /// 데이터 저장할때 컨텐츠 영역의 유효성 검사
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();
            grdMaster.View.CheckValidation();

            DataTable changed = grdMaster.GetChangedRows();//변경된 row

            if (changed.Rows.Count == 0)
            {
                throw MessageException.Create("NoSaveData");
            }
        }
        #endregion

        #region Private Function

        /// <summary>
        /// 작업메뉴얼 마스터 그리드의 포커스 행 변경 로직을 처리한다.
        /// </summary>
        private void focusedRowChanged()
        {
            var row = grdMaster.View.GetDataRow(grdMaster.View.FocusedRowHandle);

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_WORKMANUALID", row["WORKMANUALID"].ToString());

            if (string.IsNullOrEmpty(row["WORKMANUALID"].ToString()))
            {
                ShowMessage("NoSelectData");
                grdItem.View.ClearDatas();

                return;
            }

            grdItem.DataSource = SqlExecuter.Query("GetWorkManualDetail", "00001", param);

        }


        private byte[] getFileBytes(string fileFullPath)
        {
            byte[] bytes;
            using (FileStream fs = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read))
            {
                bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                fs.Close();

                return bytes;
            }
        }
        #endregion
    }
}

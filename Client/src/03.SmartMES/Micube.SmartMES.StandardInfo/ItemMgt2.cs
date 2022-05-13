using DevExpress.XtraGrid.Views.Grid;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.SmartMES.Commons;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 조회 > 품목조회
    /// 업  무  설  명  : 기준정보 품목정보를 조회
    /// 생    성    자  : jylee
    /// 생    성    일  : 2019-04-06
    /// 수  정  이  력  : 2020-05-06 | scmo | ERP연동에 따른 쿼리 및 컬럼변경
    ///                   2020-05-12 | jylee | 원자재 개별화면 구성, 맵핑기능 추가
    ///                   2020-05-28 | jylee | 조회쿼리수정, 품목명 AutoFill삭제
    /// 
    /// </summary>
    public partial class ItemMgt2 : SmartConditionBaseForm
    {
        public ItemMgt2()
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
            InitializeItemGrid();
            InitializeGridMask();
            InitializeEvent();
        }

        protected override void InitializeCondition()
        {
            base.InitializeCondition();
            CommonFunction.AddConditionProductPopup("P_PRODUCTDEFID", 1.1, false, Conditions, "PARTNUMBER");
        }

        /// <summary>
        /// 정규식 적용 - 숫자만 입력
        /// </summary>
        private void InitializeGridMask()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repository = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

            repository = grdItem.View.Columns["LOTSIZE"].ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemTextEdit;
            repository.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            repository.Mask.EditMask = @"\d*";
            repository.Mask.UseMaskAsDisplayFormat = true;

            //repository = grdItem.View.Columns["STANDARDTIME"].ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemTextEdit;
            //repository.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            //repository.Mask.EditMask = @"\d*";
            //repository.Mask.UseMaskAsDisplayFormat = true;
        }

        /// <summary>        
        /// 그리드를 초기화한다.
        /// </summary>
        private void InitializeItemGrid()
        {
            grdItem.GridButtonItem = GridButtonItem.Refresh | GridButtonItem.Export;

            grdItem.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdItem.View.SetSortOrder("ITEMID");

            //품목코드
            grdItem.View.AddTextBoxColumn("PRODUCTDEFID", 120).SetIsReadOnly().SetIsHidden();
            //PATTNUMBER
            grdItem.View.AddTextBoxColumn("ITEMID", 120).SetIsReadOnly();
            //품목명
            grdItem.View.AddTextBoxColumn("ITEMNAME", 200).SetIsReadOnly();
            //짧은 품목명
            grdItem.View.AddTextBoxColumn("PRODUCTDEFSHORTNAME", 100);
            //버전(HIDDEN)
            grdItem.View.AddTextBoxColumn("PRODUCTDEFVERSION", 100).SetIsHidden().SetIsReadOnly();
            //규격
            grdItem.View.AddTextBoxColumn("ITEMSTANDARD", 100).SetIsReadOnly().SetLabel("STANDARD");
            //품목자산분류
            grdItem.View.AddTextBoxColumn("ITEMASSETCATEGORY", 80).SetIsReadOnly();
            //TEAM
            grdItem.View.AddComboBoxColumn("TEAM", 100, new SqlQuery("GetTeamList", "00001", "CODECLASSID=TeamCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));
            //공정
            grdItem.View.AddComboBoxColumn("PROCESSSEGMENTID", new SqlQuery("GetProcessSegment", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("PROCESSSEGMENT").SetIsReadOnly();
            //작업장명
            InitializePopup_AreaId();            
            //작업장ID
            grdItem.View.AddTextBoxColumn("AREAID", 120)
                .SetIsReadOnly()
                .SetIsHidden();
            //기종
            grdItem.View.AddTextBoxColumn("MODELID").SetIsHidden();
            InitializePopup_ModelId();
            //스팩ID
            InitializePopup_SpecdefId();
            //작업장ID
            grdItem.View.AddTextBoxColumn("SPECDEFID", 120)
                .SetIsReadOnly()
                .SetIsHidden();
            //검사기준이미지
            //grdItem.View.AddTextBoxColumn("SHIPPINGINSPSTDFILEID").SetIsHidden();
            //grdItem.View.AddTextBoxColumn("INSPECTIONTYPE").SetIsHidden();
            //InitializePopup_InspectionStdImage();
            //LOTSIZE
            grdItem.View.AddTextBoxColumn("LOTSIZE", 80).SetTextAlignment(TextAlignment.Right);
            //단위
            grdItem.View.AddTextBoxColumn("UNIT", 60).SetIsReadOnly();
            //대분류
            grdItem.View.AddTextBoxColumn("LARGECATEGORY", 80).SetIsReadOnly().SetIsHidden();
            //중분류
            grdItem.View.AddTextBoxColumn("MEDIUMCATEGORY", 80).SetIsReadOnly().SetIsHidden();
            //표준작업시간
            grdItem.View.AddSpinEditColumn("STANDARDTIME", 80)
                .SetIsReadOnly()
                .SetDisplayFormat("#,###,##0.#0", MaskTypes.Numeric, true);
            //유효상태
            grdItem.View.AddComboBoxColumn("VALIDSTATE", 60, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                   .SetTextAlignment(TextAlignment.Center)
                   .SetDefault("Valid")
                   .SetValidationIsRequired();
            //생성자
            grdItem.View.AddTextBoxColumn("CREATOR", 80).SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
            //생성시간
            grdItem.View.AddTextBoxColumn("CREATEDTIME", 130).SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
            //수정자
            grdItem.View.AddTextBoxColumn("MODIFIER", 80).SetIsReadOnly().SetTextAlignment(TextAlignment.Center);
            //수정시간
            grdItem.View.AddTextBoxColumn("MODIFIEDTIME", 130).SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetIsReadOnly().SetTextAlignment(TextAlignment.Center);

            grdItem.View.PopulateColumns();
        }

        /// <summary>
        /// 팝업형 컬럼 초기화 - 검사기준 이미지
        /// </summary>
        private void InitializePopup_InspectionStdImage()
        {
            var image = grdItem.View.AddSelectPopupColumn("FILENAME", 120, new InspectionStdImagePopup())
                .SetPopupCustomParameter(
                (ISmartCustomPopup sender, DataRow currentRow) => //초기화 작업
                {
                    InspectionStdImagePopup popup = sender as InspectionStdImagePopup;
                    popup._fileId = Format.GetFullTrimString(currentRow["SHIPPINGINSPSTDFILEID"]);
                    popup._inspectionType = "OutGoingInsp";//Format.GetFullTrimString(currentRow["INSPECTIONTYPE"]);
                },
                (ISmartCustomPopup sender, DataRow currentRow) => //결과 리턴 작업
                {
                    InspectionStdImagePopup popup = sender as InspectionStdImagePopup;
                    currentRow["SHIPPINGINSPSTDFILEID"] = popup.CurrentDataRow["FILEID"];
                    currentRow["INSPECTIONTYPE"] = popup.CurrentDataRow["INSPECTIONTYPE"];
                })
                .SetClearButtonInvisible(false);
        }

        /// <summary>
        /// 팝업형 컬럼 초기화 - 작업장
        /// </summary>
        private void InitializePopup_AreaId()
        {
            var areaId = grdItem.View.AddSelectPopupColumn("AREANAME", new SqlQuery("GetAreaList", "00002", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("AREAID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupLayoutForm(600, 400)
                .SetPopupAutoFillColumns("AREANMAE")
                .SetLabel("AREANAME")
                .SetPopupApplySelection((selectedRows, dataGridRow) =>
                {
                    foreach (DataRow row in selectedRows)
                        dataGridRow["AREAID"] = row["AREAID"];
                });


            areaId.Conditions.AddTextBox("TXTAREA");

            areaId.GridColumns.AddTextBoxColumn("AREAID", 150);
            areaId.GridColumns.AddTextBoxColumn("AREANAME", 200);
        }

        /// <summary>
        /// 팝업형 컬럼 초기화 - SPEC ID
        /// </summary>
        private void InitializePopup_SpecdefId()
        {
            var specId = grdItem.View.AddSelectPopupColumn("SPECDEFNAME", new SqlQuery("GetSpecList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("SPECDEFNAME", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                .SetPopupAutoFillColumns("SPECDEFNAME")
                .SetLabel("SPEC")
                .SetPopupApplySelection((selectedRows, dataGridRow) =>
                {
                    foreach (DataRow row in selectedRows)
                        dataGridRow["SPECDEFID"] = row["SPECDEFID"];
                });

            specId.Conditions.AddTextBox("TXTSPECDEF");

            specId.GridColumns.AddTextBoxColumn("SPECDEFID", 150);
            specId.GridColumns.AddTextBoxColumn("SPECDEFNAME", 200);
        }

        /// <summary>
        /// 팝업형 컬럼 초기화 - 기종
        /// </summary>
        private void InitializePopup_ModelId()
        {
            var popupColumn = grdItem.View.AddSelectPopupColumn("MODELNAME", 100, new SqlQuery("GetModelPopup", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("SELECTMODEL", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupResultMapping("MODELNAME", "CODENAME")
                .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                .SetPopupAutoFillColumns("CODENAME")

                .SetTextAlignment(TextAlignment.Center)
                .SetPopupApplySelection((selectedRows, dataGridRow) =>
                {
                    DataRow row = selectedRows.FirstOrDefault();
                    if (row == null)
                    {
                        dataGridRow["MODELID"] = string.Empty;
                        return;
                    }
                    else
                    {
                        dataGridRow["MODELID"] = row["CODEID"];
                    }
                })
                .SetLabel("MODELID");

            //검색조건
            popupColumn.Conditions.AddTextBox("TXTMODELID");

            popupColumn.GridColumns.AddComboBoxColumn("PROCESSSEGMENTID", 100, new SqlQuery("GetProcessSegment", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("PROCESSSEGMENT");
            popupColumn.GridColumns.AddTextBoxColumn("CODEID", 80).SetLabel("MODELID");
            popupColumn.GridColumns.AddTextBoxColumn("CODENAME", 100).SetLabel("MODELNAME");
        }
        #endregion
        #region Event
        private void InitializeEvent()
        {
            grdItem.View.CellValueChanged += View_CellValueChanged;
            grdItem.View.RowCellStyle += View_RowCellStyle;
        }

        // 입력 가능컬럼 배경색상 다르게 표시
        private void View_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "VALIDSTATE"
                || e.Column.FieldName == "LOTSIZE"
                || e.Column.FieldName == "FILENAME"
                || e.Column.FieldName == "SPECDEFNAME"
                || e.Column.FieldName == "MODELNAME"
                || e.Column.FieldName == "AREANAME"
                || e.Column.FieldName == "TEAM"
                || e.Column.FieldName == "PRODUCTDEFSHORTNAME")
            {
                e.Appearance.BackColor = System.Drawing.Color.LightYellow;
                e.Appearance.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// CELL 값 변경 시 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e == null) return;

            if (e.Column.FieldName.Equals("FILENAME"))
            {
                if (string.IsNullOrWhiteSpace(Format.GetFullTrimString(e.Value)))
                {
                    grdItem.View.SetRowCellValue(e.RowHandle, "SHIPPINGINSPSTDFILEID", string.Empty);
                }
            }
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
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtItem = new DataTable();
            dtItem = await QueryAsync("GetProductItem", "00001", values);

            if (dtItem.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdItem.DataSource = dtItem;
        }

        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터 저장할때 컨텐츠 영역의 유효성 검사
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();
            grdItem.View.CheckValidation();

            DataTable changed = grdItem.GetChangedRows();//변경된 row

            if (changed.Rows.Count == 0)
            {
                throw MessageException.Create("NoSaveData");
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

            DataTable changed = grdItem.GetChangedRows();

            ExecuteRule("MappingProductInfo", changed);
        }
        #endregion
    }
}
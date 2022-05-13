#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;

using System;
using System.Data;
using System.Threading.Tasks;

#endregion

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 코드관리 > 설비코드
    /// 업  무  설  명  : 설비코드 정보를 관리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-02
    /// 수  정  이  력  : 2020-06-05 유태근 / 다국어 변경 및 설비그룹 추가에 따른 코드변경
    ///                     2020-06-10 scmo / 점검유무 체크필드 추가.
    /// 
    /// 
    /// </summary>
    public partial class EquipmentCode : SmartConditionBaseForm
    {
        #region Local Variables

        #endregion

        #region 생성자

        public EquipmentCode()
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

            InitializeEvent();

            // 컨트롤 초기화 로직 구성
            InitializeManageGrid();
            //InitializeViewGrid();

            //LoadDataManageGrid();
            //LoadDataViewGrid();
        }

        /// <summary>        
        /// 설비 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeManageGrid()
        {
            // 그리드 초기화
            grdEquipCode.GridButtonItem = GridButtonItem.All;
            grdEquipCode.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdEquipCode.View.SetSortOrder("EQUIPMENTID");
      

            //설비코드
            grdEquipCode.View.AddTextBoxColumn("EQUIPMENTID", 120)
                .SetIsReadOnly();
            //설비명(다국어)
            grdEquipCode.View.AddLanguageColumn("EQUIPMENTNAME", 150);
            //설비구분
            grdEquipCode.View.AddComboBoxColumn("EQUIPMENTTYPE", 100, new SqlQuery("GetCodeList", "00001", "CODECLASSID=EquipmentType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center);
            //설비그룹
            grdEquipCode.View.AddComboBoxColumn("EQUIPMENTCLASSID", 120, new SqlQuery("GetEquipmentClassList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "EQUIPMENTCLASSNAME", "EQUIPMENTCLASSID")
               .SetTextAlignment(TextAlignment.Center)
               .SetValidationIsRequired();
            //TEAM
            grdEquipCode.View.AddComboBoxColumn("DEPARTMENT", 100, new SqlQuery("GetTeamList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("THISTEAM");
            //작업장명
            InitializePopup_AreaId();
            //작업장ID
            grdEquipCode.View.AddTextBoxColumn("AREAID", 120)
                .SetIsReadOnly()
                .SetIsHidden();
            //자산번호
            grdEquipCode.View.AddTextBoxColumn("ASSETNO", 150);
            //설비상태
            grdEquipCode.View.AddComboBoxColumn("STATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=EquipmentState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetDefault("Idle")
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("EQUIPMENTSTATE");
            //비고사항
            grdEquipCode.View.AddTextBoxColumn("DESCRIPTION", 200);
            //Interface여부
            grdEquipCode.View.AddComboBoxColumn("IFSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YESNO", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Valid")
               .SetValidationIsRequired();
            //일상점검여부
            grdEquipCode.View.AddComboBoxColumn("ISDAILYCHECK", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YESNO", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Invalid")
               .SetValidationIsRequired();
            //사용여부
            grdEquipCode.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Valid")
               .SetValidationIsRequired();
            //생성자
            grdEquipCode.View.AddTextBoxColumn("CREATOR", 150)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            //생성일시
            grdEquipCode.View.AddTextBoxColumn("CREATEDTIME", 150)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            //수정자
            grdEquipCode.View.AddTextBoxColumn("MODIFIER", 150)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            //수정일시
            grdEquipCode.View.AddTextBoxColumn("MODIFIEDTIME", 150)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();

            grdEquipCode.View.PopulateColumns();

   
            grdEquipCode.View.OptionsCustomization.AllowSort = false;
            grdEquipCode.View.OptionsNavigation.AutoMoveRowFocus = false;
        }

        /// <summary>
        /// 팝업형 컬럼 초기화 - 작업장
        /// </summary>
        private void InitializePopup_AreaId()
        {
            var areaId = grdEquipCode.View.AddSelectPopupColumn("AREANAME", new SqlQuery("GetAreaList", "00002", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("AREAID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupLayoutForm(600, 400)
                .SetPopupAutoFillColumns("AREANMAE")
                .SetLabel("AREANAME")
                .SetPopupApplySelection((selectedRows, dataGridRow) =>
                {
                    foreach(DataRow row in selectedRows)  
                    dataGridRow["AREAID"] = row["AREAID"];
                });


            areaId.Conditions.AddTextBox("TXTAREA");

            areaId.GridColumns.AddTextBoxColumn("AREAID", 150);
            areaId.GridColumns.AddTextBoxColumn("AREANAME", 200);
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            grdEquipCode.View.AddingNewRow += View_AddingNewRow;
        }

        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            args.NewRow["ENTERPRISEID"] = UserInfo.Current.Enterprise;
            args.NewRow["PLANTID"] = UserInfo.Current.Plant;
        }

        #endregion

        #region ToolBar

        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdEquipCode.GetChangedRows();

            ExecuteRule("SaveEquipment", changed);
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

            DataTable dtEquipCode = await QueryAsync("GetEquipCode", "00001", values);

            if(dtEquipCode.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdEquipCode.DataSource = dtEquipCode;
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
            grdEquipCode.View.CheckValidation();

            DataTable changed = grdEquipCode.GetChangedRows();//변경된 row

            if (changed.Rows.Count == 0)
            {
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function

        private void LoadDataManageGrid()
        {
            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);
      
            grdEquipCode.DataSource = SqlExecuter.Query("GetEquipCode", "00001", values);
        }

        #endregion
        
    }
}

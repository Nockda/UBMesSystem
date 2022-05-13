#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;

using System.Data;
using System.Threading.Tasks;

#endregion

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 코드관리 > 작업장별설비코드관리
    /// 업  무  설  명  : 작업장별 설비코드를 관리한다.
    /// 생    성    자  : 모세찬
    /// 생    성    일  : 2020-04-03
    /// 수  정  이  력  : Save단 생성 하지 않음. 필요없는 화면으로 판단.
    /// 
    /// 
    /// </summary>
    public partial class EquipmentByArea : SmartConditionBaseForm
    {
        public EquipmentByArea()
        {
            InitializeComponent();
        }

        #region 컨텐츠 영역 초기화

        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeEvent();

            InitializeGrid();
        }

        /// <summary>        
        /// 그리드 초기화
        /// </summary>
        private void InitializeGrid()
        {

            grdInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdInfo.View.SetSortOrder("AREAEQUIPMENTID");
            grdInfo.View.SetAutoFillColumn("DESCRIPTION");

            grdInfo.View.AddTextBoxColumn("AREAEQUIPMENTID", 80)
                            .SetValidationKeyColumn()
                            .SetValidationIsRequired();
            grdInfo.View.AddTextBoxColumn("AREAID", 80);
            grdInfo.View.AddTextBoxColumn("AREANAME", 100);
            grdInfo.View.AddTextBoxColumn("AREAGROUPID", 80);
            grdInfo.View.AddTextBoxColumn("AREAGROUPNAME", 100);
            grdInfo.View.AddTextBoxColumn("EQUIPMENTID", 80)
                .SetValidationKeyColumn()
                .SetValidationIsRequired();
            if (UserInfo.Current.LanguageType == Commons.Constants.LanguageType_KO_KR)
            {
                grdInfo.View.AddTextBoxColumn("EQUIPMENTNAMEKOR", 120);
            }
            else if (UserInfo.Current.LanguageType == Commons.Constants.LanguageType_EN_US)
            {
                grdInfo.View.AddTextBoxColumn("EQUIPMENTNAMEENG", 120);
            }
            else if (UserInfo.Current.LanguageType == Commons.Constants.LanguageType_zh_CN)
            {
                grdInfo.View.AddTextBoxColumn("EQUIPMENTNAMEJPN", 120);
            }
            grdInfo.View.AddTextBoxColumn("DESCRIPTION", 150);
            grdInfo.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Valid")
               .SetValidationIsRequired();
            grdInfo.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("CREATEDTIME", 120)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("MODIFIEDTIME", 120)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);

            grdInfo.View.PopulateColumns();
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            grdInfo.View.AddingNewRow += View_AddingNewRow;
        }

        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            DataRow focusRow = grdInfo.View.GetFocusedDataRow();

        }

        #endregion

        #region 툴바
        /// <summary>
        /// 저장버튼 클릭
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdInfo.GetChangedRows();

            //ExecuteRule("SaveEquipCheckList", changed);
        }

        #endregion

        #region 검색
        //// <summary>
        /// 비동기 override 모델
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtInfo = await QueryAsync("GetEquipByArea", "00001", values);

            if (dtInfo.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdInfo.DataSource = dtInfo;
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

            grdInfo.View.CheckValidation();

            DataTable changed = grdInfo.GetChangedRows();

            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion
    }
}

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
    /// 프 로 그 램 명  : 기준정보 > 코드관리 > 코드자동채번규칙
    /// 업  무  설  명  : 코드자동채번규칙을 관리한다.
    /// 생    성    자  : 모세찬
    /// 생    성    일  : 2020-04-10
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class AutoCodeNumbering : SmartConditionBaseForm
    {
        public AutoCodeNumbering()
        {
            InitializeComponent();
        }

        #region 컨텐츠 영역 초기화

        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeGrid();
        }

        /// <summary>        
        /// 그리드 초기화
        /// </summary>
        private void InitializeGrid()
        {

            grdInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdInfo.View.SetSortOrder("SEQID");
            grdInfo.View.SetAutoFillColumn("DESCRIPTION");

            grdInfo.View.AddTextBoxColumn("SEQID", 80)
                .SetValidationKeyColumn()
                .SetValidationIsRequired();
            grdInfo.View.AddTextBoxColumn("SEQNAMEKOR", 120);
            grdInfo.View.AddTextBoxColumn("SEQNAMEENG", 120);
            grdInfo.View.AddTextBoxColumn("SEQNAMEJPN", 120);
            grdInfo.View.AddTextBoxColumn("SEQRULE", 250);
            grdInfo.View.AddSpinEditColumn("SEQCOUNT", 80)
                .SetValidationIsRequired();
            //로직으로 구현시 최종 SEQID 저장용도.
            grdInfo.View.AddTextBoxColumn("LASTSEQID", 80)
                .SetIsReadOnly()
                .SetIsHidden();
            grdInfo.View.AddTextBoxColumn("DESCRIPTION", 200);
            grdInfo.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);

            grdInfo.View.PopulateColumns();
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

            ExecuteRule("SaveSeqIdRule", changed);
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

            DataTable dtInfo = await QueryAsync("GetSeqIdRule", "00001", values);

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

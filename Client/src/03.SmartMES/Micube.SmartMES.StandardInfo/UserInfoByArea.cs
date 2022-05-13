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
    /// 프 로 그 램 명  : 기준정보 > 코드관리 > 작업장(공정)별 작업자 정보
    /// 업  무  설  명  : 작업장(공정)별 작업자 Mapping
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-04
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class UserInfoByArea : SmartConditionBaseForm
    {
        public UserInfoByArea()
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

            InitializeArea();
            InitializeWorker();

            LoadDataArea();
        }

        /// <summary>        
        /// 작업장 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeArea()
        {
            grdArea.GridButtonItem = GridButtonItem.Refresh;

            grdArea.View.SetIsReadOnly();
            grdArea.View.SetAutoFillColumn("AREANAME");
            grdArea.View.SetSortOrder("AREACODE");

            grdArea.View.AddTextBoxColumn("AREACODE", 150);
            grdArea.View.AddTextBoxColumn("AREANAME", 200);
            grdArea.View.AddTextBoxColumn("PERSONNEL", 100);
            grdArea.View.PopulateColumns();
        }

        /// <summary>        
        /// 작업자 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeWorker()
        {
            grdWorker.GridButtonItem = GridButtonItem.All;
            grdWorker.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            grdWorker.View.SetAutoFillColumn("USERNAME");
            grdWorker.View.SetSortOrder("USERNAME");

            //작업장코드
            grdWorker.View.AddTextBoxColumn("AREACODE", 100);
                //.SetIsHidden();
            //작업자코드
            grdWorker.View.AddTextBoxColumn("USERCODE", 100);
            //작업자명
            grdWorker.View.AddTextBoxColumn("USERNAME", 100);
            //유효상태
            grdWorker.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Valid")
               .SetValidationIsRequired();
            //생성자
            grdWorker.View.AddTextBoxColumn("CREATOR", 80)  
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            //생성일시
            grdWorker.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss");
            //수정자
            grdWorker.View.AddTextBoxColumn("MODIFIER", 80)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            //수정일시
            grdWorker.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss");

            grdWorker.View.SetKeyColumn("AREACODE");
            grdWorker.View.PopulateColumns();
        }

        #endregion

        #region Event

        /// <summary>        
        /// 이벤트 초기화
        /// </summary>
        private void InitializeEvent()
        {
            grdArea.View.FocusedRowChanged += View_FocusedRowChanged;
            grdArea.ToolbarRefresh += GrdArea_ToolbarRefresh;

            grdWorker.View.AddingNewRow += View_AddingNewRow;
        }

        /// <summary>
        /// 작업장 리스트 그리드 Refresh 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdArea_ToolbarRefresh(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 작업장 리스트 그리드 Focused Row 변경 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            focusedRowChanged();
        }

        /// <summary>
        /// 작업자 리스트 그리드 행 추가 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void View_AddingNewRow(SmartBandedGridView sender, AddNewRowArgs args)
        {

        }

        #endregion


        #region 검색

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            if (grdArea.View.DataRowCount <= 0)
                return;

            int beforeHandle = grdArea.View.FocusedRowHandle;

            DataRow row = grdArea.View.GetFocusedDataRow();
            string bfAreaCode = row["AREACODE"].ToString();

            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtArea = await QueryAsync("GetListArea", "00001", values);

            if (dtArea.Rows.Count < 1)
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
                dtArea.Clear();
            }
            else if (dtArea.Rows.Count <= beforeHandle)
            {
                grdArea.DataSource = dtArea;
            }
            else
            {
                grdArea.DataSource = dtArea;
            }
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


        #region Private Function

        /// <summary>
        /// 작업장정보 리스트를 조회한다.
        /// </summary>
        private void LoadDataArea()
        {
            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            int iBeforeRowHandle = grdArea.View.FocusedRowHandle;

            grdArea.DataSource = SqlExecuter.Query("GetListArea", "00001", values);

            grdArea.View.FocusedRowHandle = 0;
            grdArea.View.SelectRow(0);

            /*
            if (iBeforeRowHandle == 0 && grdArea.View.FocusedRowHandle == 0)
                focusedRowChanged();
            */
        }

        /// <summary>
        /// 작업장정보 리스트의 Focused Row 변경 시 작업자 정보를 조회한다.
        /// </summary>
        private void focusedRowChanged()
        {
            var row = grdArea.View.GetDataRow(grdArea.View.FocusedRowHandle);
            var cond = Conditions.GetValues();
            cond.Add("P_AREACODE", row["AREACODE"].ToString());

            if (string.IsNullOrEmpty(row["AREACODE"].ToString()))
            {
                ShowMessage("NoSelectData");
            }

            //grdWorker.DataSource = SqlExecuter.Query("SelectDictionary", "10001", cond);
        }

        #endregion
    }
}

#region using

using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Micube.SmartMES.Production
{
    /// <summary>
    /// 프 로 그 램 명  : 생산관리 > 생산계획 > 생산계획대비실적
    /// 업  무  설  명  : 생산계획대비실적을 조회한다.
    /// 생    성    자  : 강유라
    /// 생    성    일  : 2020-06-18
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class WorkOrderPerformance : SmartConditionBaseForm
    {
        #region Local Variables

        // TODO : 화면에서 사용할 내부 변수 추가
  

        #endregion

        #region 생성자

        public WorkOrderPerformance()
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

            // TODO : 컨트롤 초기화 로직 구성
            InitializeGrid();
        }

        /// <summary>        
        /// 코드그룹 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeGrid()
        {
            // TODO : 그리드 초기화 로직 추가
            grdPlanPerformance.GridButtonItem = GridButtonItem.Export;
            grdPlanPerformance.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            grdPlanPerformance.View.SetIsReadOnly();

            grdPlanPerformance.View.AddTextBoxColumn("WORKORDERID", 150);//작업지시번호
            grdPlanPerformance.View.AddTextBoxColumn("TEAMNAME", 100).SetLabel("THISTEAM");//작업팀
            grdPlanPerformance.View.AddTextBoxColumn("AREANAME", 100);//작업장
            grdPlanPerformance.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 100);//공정

            grdPlanPerformance.View.AddTextBoxColumn("PRODUCTDEFID", 150);//품목코드
            grdPlanPerformance.View.AddTextBoxColumn("PRODUCTDEFNAME", 300);//품목명
            grdPlanPerformance.View.AddTextBoxColumn("PRODUCTDEFTYPENAME", 80).SetLabel("PRODUCTTYPE");//품목구분

            grdPlanPerformance.View.AddTextBoxColumn("PLANENDTIME", 100)
                .SetLabel("WORKPLANENDTIME")
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd");//완료요청일

            grdPlanPerformance.View.AddTextBoxColumn("PLANQTY", 80)
                .SetDisplayFormat("#,##0.#####", MaskTypes.Numeric);//계획수량 

            grdPlanPerformance.View.AddTextBoxColumn("LOTQTY", 80)
                .SetLabel("PERFORMQTY")
                .SetDisplayFormat("#,##0.#####", MaskTypes.Numeric);//실적수량 

            grdPlanPerformance.View.AddTextBoxColumn("COMPLETERATE", 100)
                .SetDisplayFormat("{0:n2}%", MaskTypes.Numeric);//완료율

            grdPlanPerformance.View.PopulateColumns();

            //합계 ROW 추가
            grdPlanPerformance.View.Columns["PLANENDTIME"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdPlanPerformance.View.Columns["PLANENDTIME"].SummaryItem.DisplayFormat = string.Format("{0}", Language.Get("SUM"));

            grdPlanPerformance.View.Columns["PLANQTY"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdPlanPerformance.View.Columns["PLANQTY"].SummaryItem.DisplayFormat = "{0}";

            grdPlanPerformance.View.Columns["LOTQTY"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdPlanPerformance.View.Columns["LOTQTY"].SummaryItem.DisplayFormat = "{0}"; ;

            grdPlanPerformance.View.Columns["COMPLETERATE"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;//***불량율 합계는 100넘을 수있음 다시계산?***
            grdPlanPerformance.View.Columns["COMPLETERATE"].SummaryItem.DisplayFormat = "{0:f2} %";

            grdPlanPerformance.View.OptionsView.ShowFooter = true;
            grdPlanPerformance.ShowStatusBar = false;
        }
        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // TODO : 화면에서 사용할 이벤트 추가
            //grdPlanPerformance 완료율 Custom 계산 이벤트 (Footer)
            grdPlanPerformance.View.CustomSummaryCalculate += GrdPlanPerformance_CustomSummaryCalculate;
        }

        private void GrdPlanPerformance_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            if (e.IsTotalSummary)
            {
                GridSummaryItem item = e.Item as GridSummaryItem;
                if (item.FieldName == "COMPLETERATE")
                {
                    if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                    {
                        GridView view = sender as GridView;
                        decimal planQty = Convert.ToDecimal(view.Columns["PLANQTY"].SummaryItem.SummaryValue);
                        decimal lotQty = Convert.ToDecimal(view.Columns["LOTQTY"].SummaryItem.SummaryValue);

                        decimal completeRate = 0;

                        if (planQty > 0)
                        {
                            completeRate = Math.Round(lotQty / planQty * 100, 2);
                        }

                        e.TotalValue = completeRate;
                    }
                }
            }
        }



        #endregion

        #region 툴바

        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            // TODO : 저장 Rule 변경
            //DataTable changed = grdPlanPerformance.GetChangedRows();

            //ExecuteRule("SaveCodeClass", changed);
        }

        #endregion

        #region 검색

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            // TODO : 조회 SP 변경
            var values = Conditions.GetValues();

            DataTable dt = await SqlExecuter.QueryAsync("SelectWorkOrderPerformanceList", "00001", values);

            if (dt.Rows.Count < 1) // 검색 조건에 해당하는 코드를 포함한 코드클래스가 없는 경우
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }

            grdPlanPerformance.DataSource = dt;
        }

        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

            // TODO : 조회조건 추가 구성이 필요한 경우 사용
        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

            // TODO : 조회조건의 컨트롤에 기능 추가가 필요한 경우 사용
        }

        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터를 저장 할 때 컨텐츠 영역의 유효성을 검사한다.
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();

            // TODO : 유효성 로직 변경
            grdPlanPerformance.View.CheckValidation();

            DataTable changed = grdPlanPerformance.GetChangedRows();

            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function

        // TODO : 화면에서 사용할 내부 함수 추가
     

        #endregion
    }
}
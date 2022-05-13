#region using

using DevExpress.Spreadsheet;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSpreadsheet.Commands.Internal;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Micube.SmartMES.Production
{
    /// <summary>
    /// 프 로 그 램 명  : 생산관리 > 생산계획 > 작업지시표 현황
    /// 업  무  설  명  : 작업지시표 현황 정보를 조회한다.
    /// 생    성    자  : 강유라
    /// 생    성    일  : 2020-06-12
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class WorkOrderStatus : SmartConditionBaseForm
    {
        #region Local Variables

        // TODO : 화면에서 사용할 내부 변수 추가
        DataTable dayWeekCodeDt;
        private int lastDay = 0;//조회하는 월의 마지막 날
        private int nFirstDay = 0;//조회하는 월의 첫째날 요일
        List<DataRow> dayList;
        #endregion

        #region 생성자

        public WorkOrderStatus()
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
        }

        /// <summary>        
        /// 코드그룹 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeGrid(int lastDay, int nFirstDayWeek)
        {
            // TODO : 그리드 초기화 로직 추가

            grdWorkOrderStatus.GridButtonItem = GridButtonItem.Export;
            grdWorkOrderStatus.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            grdWorkOrderStatus.View.OptionsView.AllowCellMerge = true;
            grdWorkOrderStatus.View.SetIsReadOnly();

            grdWorkOrderStatus.View.ClearColumns();
    
            //아이템 그룹 
            var itemInfo = grdWorkOrderStatus.View.AddGroupColumn("");

            itemInfo.AddTextBoxColumn("PROCESSSEGMENTNAME", 150);//공정명
            itemInfo.AddTextBoxColumn("PROCESSSEGMENTID", 150).SetIsHidden();//공정
            itemInfo.AddTextBoxColumn("AREANAME",150);//작업장
            itemInfo.AddTextBoxColumn("AREAID", 150).SetIsHidden();//작업장
            itemInfo.AddTextBoxColumn("PRODUCTDEFTYPENAME", 80).SetLabel("PRODUCTTYPE");//품목구분
            itemInfo.AddTextBoxColumn("PRODUCTTYPE", 80).SetIsHidden();//품목구분
            itemInfo.AddTextBoxColumn("PRODUCTDEFID", 150);//품목코드
            itemInfo.AddTextBoxColumn("PRODUCTDEFNAME", 320);//품목명
            itemInfo.AddTextBoxColumn("MODELNAME", 150);//기종
            itemInfo.AddTextBoxColumn("STANDARD", 150).SetLabel("DRAWINGNUMBER");//도면번호
            itemInfo.AddTextBoxColumn("STOCKQTY", 100).SetLabel("LASTMONTHSTOCK");//전월재고
            itemInfo.AddTextBoxColumn("QTY", 100).SetLabel("PRODUCTIONCOUNT");//생산대수


            for (int i =1; i <= lastDay; i++)
            {
                string dayCode =  Format.GetString(dayList[nFirstDayWeek % 7]["CODEID"]).ToUpper();
                grdWorkOrderStatus.View.AddTextBoxColumn(Format.GetString(i), 40)
                    .SetLabel(dayCode).SetDisplayFormat("#,##0.#####", MaskTypes.Numeric);//요일 / dataCol
                nFirstDayWeek++;
            }
            grdWorkOrderStatus.View.PopulateColumns();
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // TODO : 화면에서 사용할 이벤트 추가
            Load += (s, e) =>
              {
                  lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                  DateTime monthFirst = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                  nFirstDay = Int32.Parse(monthFirst.DayOfWeek.ToString("d"));//일 = 0 ,월 =1 ,..

                  Dictionary<string, object> values = new Dictionary<string, object>()
                  {
                      { "CODECLASSID" , "DayCode" }
                  };
                  DataTable dayDt = SqlExecuter.Query("GetCodeList", "00001", values);
                  dayList = dayDt.AsEnumerable().ToList();

                  InitializeGrid(lastDay, nFirstDay);
              };

            grdWorkOrderStatus.View.CellMerge += (s, e) =>
             {
                 GridView view = s as GridView;

                 if (view == null) return;
                 
                 if (e.Column.FieldName == "PROCESSSEGMENTNAME")
                 {
                     string sum1 = Format.GetString(view.GetRowCellValue(e.RowHandle1, "PROCESSSEGMENTID"));
                     string sum2 = Format.GetString(view.GetRowCellValue(e.RowHandle2, "PROCESSSEGMENTID")); 
                     if (!(sum1.Equals("SUM") || sum2.Equals("SUM")))
                     {
                         string str1 = view.GetRowCellDisplayText(e.RowHandle1, e.Column);
                         string str2 = view.GetRowCellDisplayText(e.RowHandle2, e.Column);
                         e.Merge = (str1 == str2);
                     }

                 }   
                 else
                 {
                     e.Merge = false;
                 }

                 e.Handled = true;
             };

            grdWorkOrderStatus.View.RowCellStyle += View_RowCellStyle;
        }

        private void View_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0)
            {
                return;
            }

            ////8일마다 컬럼 색변경
            //for (int i = 1; i < 25; i++)
            //{
            //    if (i < 9 || (16 < i && i < 25))
            //    {
            //        if (e.Column.FieldName.Equals(Format.GetString(i)))
            //            e.Appearance.BackColor = Color.Lavender;
            //    }
            //}

            //컬럼색상 변경 - by.scmo
            var values = Conditions.GetValues();
            DateTime date = Convert.ToDateTime(values["P_YEARMONTH"].ToString());
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            int iYear = date.Year;
            int iMonth = date.Month;
            int iTotalDay = lastDayOfMonth.Day;

            CultureInfo ciCurr = CultureInfo.CurrentCulture;

            for (int i = 1; i <= iTotalDay; i++)
            {
                if (e.Column.FieldName.Equals(Format.GetString(i)))
                {
                    DateTime tmpDate = new DateTime(iYear, iMonth, i);

                    int weekNum = ciCurr.Calendar.GetWeekOfYear(tmpDate, CalendarWeekRule.FirstFullWeek, DayOfWeek.Friday);

                    if(weekNum%2 == 0)
                    {
                        e.Appearance.BackColor = Color.Lavender;
                    }
                }
            }

            //합계 row 컬럼 색 변경
            //공정별 합계 row
            if (string.IsNullOrWhiteSpace(Format.GetString(grdWorkOrderStatus.View.GetRowCellValue(e.RowHandle, "AREAID"))))
            {
                e.Appearance.BackColor = Color.Beige;
            }
            //전체 합계 row
            else if (Format.GetString(grdWorkOrderStatus.View.GetRowCellValue(e.RowHandle, "AREAID")).Equals("SUM"))
            {
                e.Appearance.BackColor = Color.Khaki;
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
            //DataTable changed = grdWorkOrderStatus.GetChangedRows();

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
            values.Add("P_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtCodeClass = await ProcedureAsync("USP_PRD_SELECTWORKORDERSTATUS", values);

            //조회 년월에 따른 그리드 변경
            //마지막 일자 
            DateTime condDate = Convert.ToDateTime(Conditions.GetValue("P_YEARMONTH"));
            lastDay = DateTime.DaysInMonth(condDate.Year, condDate.Month);

            //첫번째 요일
            DateTime monthFirst = new DateTime(condDate.Year, condDate.Month, 1);
            nFirstDay = Int32.Parse(monthFirst.DayOfWeek.ToString("d"));//일 = 0 ,월 =1 ,..

            InitializeGrid(lastDay, nFirstDay);

            if (dtCodeClass.Rows.Count < 1) // 검색 조건에 해당하는 코드를 포함한 코드클래스가 없는 경우
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }
            
            grdWorkOrderStatus.DataSource = dtCodeClass; 

        }

        #region 조회조건
        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

            // TODO : 조회조건 추가 구성이 필요한 경우 사용
            InitializeConditionPopup_ProductDefId();
        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

            // TODO : 조회조건의 컨트롤에 기능 추가가 필요한 경우 사용
        }


        #region 품목 조회조건 팝업 초기화
        /// <summary>
        /// ProductDefId 선택하는 팝업
        /// </summary>
        private void InitializeConditionPopup_ProductDefId()
        {
            var productPopup = Conditions.AddSelectPopup("P_PRODUCTDEFID", new SqlQuery("GetProductDefByProductType", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "PRODUCTDEFNAME", "PRODUCTDEFID")
              .SetPopupLayout("PRODUCTDEFLIST", PopupButtonStyles.Ok_Cancel, true, true)
              .SetPopupResultCount(1)
              .SetPosition(4.5)
              .SetPopupLayoutForm(800, 600, FormBorderStyle.FixedToolWindow)
              .SetLabel("PRODUCTDEFID");

            // 팝업의 검색조건 항목 추가 (품목타입)
            productPopup.Conditions.AddComboBox("P_PRODUCTDEFTYPE", new SqlQuery("GetCodeList", "00001", "CODECLASSID=ProductDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetEmptyItem().SetLabel("PRODUCTDEFTYPE");

            productPopup.Conditions.AddTextBox("P_PRODUCTDEFTXT").SetLabel("PRODUCTDEFIDNAME");

            productPopup.GridColumns.AddTextBoxColumn("PRODUCTDEFID", 150).SetIsHidden()
                .SetIsReadOnly();
            productPopup.GridColumns.AddTextBoxColumn("PARTNUMBER", 150).SetLabel("PRODUCTDEFID")
                .SetIsReadOnly();
            productPopup.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 200)
                .SetIsReadOnly();
            productPopup.GridColumns.AddTextBoxColumn("PRODUCTDEFVERSION", 200)
                .SetIsReadOnly();
            productPopup.GridColumns.AddTextBoxColumn("PRODUCTMODEL", 200).SetLabel("PRODUCTCLASSNAME")
                .SetIsReadOnly();
            productPopup.GridColumns.AddTextBoxColumn("PRODUCTDEFTYPE", 200).SetLabel("PRODUCTDEFTYPENAME")
                .SetIsReadOnly();
            productPopup.GridColumns.AddTextBoxColumn("LOTSIZE", 200)
                .SetIsReadOnly();
            productPopup.GridColumns.AddTextBoxColumn("DESCRIPTION", 200)
                .SetIsReadOnly();
        }
        #endregion

        #endregion

        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터를 저장 할 때 컨텐츠 영역의 유효성을 검사한다.
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();

            // TODO : 유효성 로직 변경
            grdWorkOrderStatus.View.CheckValidation();

            DataTable changed = grdWorkOrderStatus.GetChangedRows();

            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function

        // TODO : 화면에서 사용할 내부 함수 추가
      

        /// <summary>
        /// 그리드 컬럼 생성 함수
        /// </summary>
        private void AddDayColDynamically()
        {
            //grdWorkOrderStatus.View.BeginUpdate();
            //grid.Columns.Add(new GridColumn() { EditSettings = new TextEditSettings() { DisplayFormat = "..." } });

            /*
            var f = grdWorkOrderStatus.View.AddGroupColumn("1");//일
            f.AddTextBoxColumn("1", 20).SetLabel("MON");//요일 / dataCol

            var f1 = grdWorkOrderStatus.View.AddGroupColumn("2");//일
            f.AddTextBoxColumn("2", 20).SetLabel("THU");//요일 / dataCol

            grdWorkOrderStatus.View.AddTextBoxColumn("3");
            */

           // grdWorkOrderStatus.View.Columns.Clear();
            grdWorkOrderStatus.View.Columns.AddField("4");
            grdWorkOrderStatus.View.Columns["4"].Visible = true;

            /* DataTable table = ((DataView)gridView1.DataSource).Table;
             for (int i = 0; i < table.Columns.Count; i++)
             {
                 gridView1.Columns.AddField(table.Columns[i].ColumnName);
                 gridView1.Columns[i].Visible = true;
                 //grdWorkOrderStatus.View.EndUpdate();
                 //grdWorkOrderStatus.View.BeginInit();
             }*/
        }
        #endregion
    }
}
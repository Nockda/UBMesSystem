#region using

using DevExpress.Utils;
using DevExpress.XtraCharts;
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

namespace Micube.SmartMES.Quality
{
    /// <summary>
    /// 프 로 그 램 명  : 품질관리 > 출하 > 펌프 성능검사 조회
    /// 업  무  설  명  : 냉동기의 성능을 조회한다
    /// 생    성    자  : 한주석
    /// 생    성    일  : 2020-06-30
    /// 수  정  이  력  : 2020-07-20 | 이준용 | 날짜포맷, 컬럼(간격, 정렬) 수정
    /// 
    /// 
    /// </summary>
    public partial class PumpOPC : SmartConditionBaseForm
    {
        #region Local Variables

        private string[] pumpChartCol = new string[] { "TCVALUE", "TWOTEMPVALUE","VACVALUE", "FIRSTSTAGE_TEMPERATURE_VT" , "SECONDSTAGE_TEMPERATURE_VT" 
                                                      ,"FIRSTSTAGE_TEMPERATURE_HO" ,"SECONDSTAGE_TEMPERATURE_HO","FIRSTSTAGE_TEMPERATURE_FINAL"
                                                      , "SECONDSTAGE_TEMPERATURE_FINAL","COMPRESSOR_SUP","COMPRESSOR_RET","CHAMBER_PRESSURE"
                                                      , "MOTORSTALL_POWER","WEIGHTTEST","REGISTERAB","REGISTERBC","DISCON","BEFORDRYWEIGHT","AFTERDRYWEIGHT"
                                                      , "WEIGHTDIFF","ADDMACHININGWT","D1MIN","D1MAX","D2MIN","D3MIN","D3MAX","SECOND_BEFORDRYWEIGHT"
                                                      , "SECOND_AFTERDRYWEIGHT","SECOND_WEIGHTDIFF","SECONDD1MIN","SECONDD1MAX","SECONDD2MIN"
                                                     , "SECONDD2MAX"};


        #endregion

        #region 생성자

        public PumpOPC()
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
            grdipti.GridButtonItem = GridButtonItem.Export;
           
            grdipti.View.SetIsReadOnly();
            var grdinfo = grdipti.View.AddGroupColumn("");
            // 성능검사일
            grdinfo.AddTextBoxColumn("INSPECTIONDATE", 100)
                .SetTextAlignment(TextAlignment.Center);
            // 품목코드
            grdinfo.AddTextBoxColumn("PRODUCTDEFID", 150).SetIsHidden();
            grdinfo.AddTextBoxColumn("PARTNUMBER", 100).SetLabel("PRODUCTDEFID");
            // 품목명
            grdinfo.AddTextBoxColumn("PRODUCTDEFNAME", 200);
            // 기종
            grdinfo.AddTextBoxColumn("MODELNAME", 100).SetLabel("MODELID");
            // 도면번호
            grdinfo.AddTextBoxColumn("STANDARD", 150).SetLabel("DRAWINGNUMBER");
            // LOTID
            grdinfo.AddTextBoxColumn("LOTID", 100);
            var grdpump = grdipti.View.AddGroupColumn("PUMPPI");
            // 검사라인
            grdpump.AddTextBoxColumn("COMPRESSORSERIALNO", 80)
                .SetTextAlignment(TextAlignment.Right);
            // 1단 Final 온도
            grdpump.AddTextBoxColumn("TCVALUE", 100)
                .SetTextAlignment(TextAlignment.Right);
            // 2단 Final 온도
            grdpump.AddTextBoxColumn("TWOTEMPVALUE", 100)
                .SetTextAlignment(TextAlignment.Right);
            // 도달압력(Pa)
            grdpump.AddTextBoxColumn("VACVALUE", 100)
                 .SetTextAlignment(TextAlignment.Center);
            // 20k 도달시간
            grdpump.AddTextBoxColumn("TIME_20K", 120)
                 .SetTextAlignment(TextAlignment.Center);
            // 15k 도달시간
            grdpump.AddTextBoxColumn("TIME_15K", 120)
                 .SetTextAlignment(TextAlignment.Center);
            // 온도
            grdpump.AddTextBoxColumn("TEMPERATURE", 80)
                 .SetTextAlignment(TextAlignment.Right);
            // 습도
            grdpump.AddTextBoxColumn("HUMIDITY", 80)
                 .SetTextAlignment(TextAlignment.Right);
            // 외관온도
            grdpump.AddTextBoxColumn("EXTERIOR_TEMPERATURE", 80)
                 .SetTextAlignment(TextAlignment.Right);
            // 이상음
            grdpump.AddTextBoxColumn("NOISE", 100)
                 .SetTextAlignment(TextAlignment.Center);
            var grdchiller = grdipti.View.AddGroupColumn("CHILLERPI");
            // 냉동기 S/N
            grdchiller.AddTextBoxColumn("REP_LOTID", 100).SetLabel("REP_LOTID");
            // 실린더 S/N
            grdchiller.AddTextBoxColumn("CYLINDER_LOTID", 100).SetLabel("CYLINDERLOTID");
            // 검사일자
            grdchiller.AddTextBoxColumn("INSPECTDATE", 100)
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("INSPECTIONDATE");
            // 검사라인
            grdchiller.AddTextBoxColumn("TESTNO", 80)
                .SetTextAlignment(TextAlignment.Right);
            // 20K 냉각시간(분)
            grdchiller.AddTextBoxColumn("COOLINGTIME", 120)
                .SetTextAlignment(TextAlignment.Right);
            // 1단 열부하 수직방향온도
            grdchiller.AddTextBoxColumn("FIRSTSTAGE_TEMPERATURE_VT", 150)
                .SetTextAlignment(TextAlignment.Right);
            // 2단 열부하 수직방향온도
            grdchiller.AddTextBoxColumn("SECONDSTAGE_TEMPERATURE_VT", 150)
                .SetTextAlignment(TextAlignment.Right);
            // 1단 열부하 수평방향온도
            grdchiller.AddTextBoxColumn("FIRSTSTAGE_TEMPERATURE_HO", 150)
                .SetTextAlignment(TextAlignment.Right);
            // 2단 열부하 수평방향온도
            grdchiller.AddTextBoxColumn("SECONDSTAGE_TEMPERATURE_HO", 150)
                .SetTextAlignment(TextAlignment.Right);
            // 1단 열부하 Final 온도
            grdchiller.AddTextBoxColumn("FIRSTSTAGE_TEMPERATURE_FINAL", 150)
                .SetTextAlignment(TextAlignment.Right);
            // 2단 열부하 Final 온도
            grdchiller.AddTextBoxColumn("SECONDSTAGE_TEMPERATURE_FINAL", 150)
                .SetTextAlignment(TextAlignment.Right);
            // Supply 고압
            grdchiller.AddTextBoxColumn("COMPRESSOR_SUP", 130)
                .SetTextAlignment(TextAlignment.Right);
            // Return 저압
            grdchiller.AddTextBoxColumn("COMPRESSOR_RET", 130)
                .SetTextAlignment(TextAlignment.Right);
            // 진공도
            grdchiller.AddTextBoxColumn("CHAMBER_PRESSURE", 80)
                .SetTextAlignment(TextAlignment.Center);
            // 모터 sTALL 전압
            grdchiller.AddTextBoxColumn("MOTORSTALL_POWER", 100)
                .SetTextAlignment(TextAlignment.Right);

            var grdxhead = grdipti.View.AddGroupColumn("XHEADAP");
            // 생산일자
            grdxhead.AddTextBoxColumn("XHEAD_TRACKOUTTIME", 100)
                .SetTextAlignment(TextAlignment.Center);
            // DISP. S/N
            grdxhead.AddTextBoxColumn("XHEAD_LOTID", 100)
                .SetTextAlignment(TextAlignment.Center);
            // 하중Test(N)
            grdxhead.AddTextBoxColumn("WEIGHTTEST", 100)
                .SetTextAlignment(TextAlignment.Right);
            // 저항A-B(Ω)
            grdxhead.AddTextBoxColumn("REGISTERAB", 100)
                .SetTextAlignment(TextAlignment.Right);
            // 저항B-C(Ω)
            grdxhead.AddTextBoxColumn("REGISTERBC", 100)
                .SetTextAlignment(TextAlignment.Right);
            // Motor회전방향
            grdxhead.AddTextBoxColumn("MOTORROTATION", 100)
                .SetTextAlignment(TextAlignment.Center);
            // 절연(MΩ)	
            grdxhead.AddTextBoxColumn("DISCON", 100)
                .SetTextAlignment(TextAlignment.Right);

            var grddisp1 = grdipti.View.AddGroupColumn("DISP1AP");
            // 생산일자
            grddisp1.AddTextBoxColumn("FIRSTDISP_TRACKOUTTIME", 100)
                .SetTextAlignment(TextAlignment.Center);
            // DISP. S/N	
            grddisp1.AddTextBoxColumn("FIRSTDISP_LOTID", 80)
                .SetTextAlignment(TextAlignment.Center);
            // 건조시작일
            grddisp1.AddTextBoxColumn("DRYSTARTTIME", 150)
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss");
            // 건조전 중량(g)
            grddisp1.AddTextBoxColumn("BEFORDRYWEIGHT", 100)
                .SetTextAlignment(TextAlignment.Right);
            // 건조완료일
            grddisp1.AddTextBoxColumn("DRYENDTIME", 150)
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetLabel("DISP1DRYCOMPLETEDATE");
            // 건조후 중량(g)
            grddisp1.AddTextBoxColumn("AFTERDRYWEIGHT", 100)
                .SetTextAlignment(TextAlignment.Right);
            // 중량 차이(g)
            grddisp1.AddTextBoxColumn("WEIGHTDIFF", 100)
                .SetTextAlignment(TextAlignment.Right);

            var grdchi1 = grdipti.View.AddGroupColumn("CHILLER1AP");
            // 생산일자
            grdchi1.AddTextBoxColumn("REP_TRACKOUTTIME", 100)
                .SetTextAlignment(TextAlignment.Center);
            // 추가가공후 중량(g)
            grdchi1.AddTextBoxColumn("ADDMACHININGWT", 130)
                .SetTextAlignment(TextAlignment.Right);
            // D1 MIN(mm)
            grdchi1.AddTextBoxColumn("D1MIN", 100)
                .SetTextAlignment(TextAlignment.Right);
            // D1 MAX(mm)
            grdchi1.AddTextBoxColumn("D1MAX", 100)
                .SetTextAlignment(TextAlignment.Right);
            //D2 MIN(mm)
            grdchi1.AddTextBoxColumn("D2MIN", 100)
                .SetTextAlignment(TextAlignment.Right);
            // D2 MAX(mm)
            grdchi1.AddTextBoxColumn("D2MAX", 100)
                .SetTextAlignment(TextAlignment.Right);
            // D3 MIN(mm)
            grdchi1.AddTextBoxColumn("D3MIN", 100)
                .SetTextAlignment(TextAlignment.Right);
            // D3 MAX(mm)	
            grdchi1.AddTextBoxColumn("D3MAX", 100)
                .SetTextAlignment(TextAlignment.Right);
            var grddisp2 = grdipti.View.AddGroupColumn("DISP2AP");
            // 생산일자
            grddisp2.AddTextBoxColumn("SECONDDISP_TRACKOUTTIME", 100)
                .SetTextAlignment(TextAlignment.Center);
            //DISP. S/N	
            grddisp2.AddTextBoxColumn("SECONDDISP_LOTID", 100)
                .SetTextAlignment(TextAlignment.Center);
            // 건조시작일
            grddisp2.AddTextBoxColumn("SECOND_DRYSTARTTIME", 150)
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss");
            // 건조전 중량(g)
            grddisp2.AddTextBoxColumn("SECOND_BEFORDRYWEIGHT", 100)
                .SetTextAlignment(TextAlignment.Right);
            // 건조완료일
            grddisp2.AddTextBoxColumn("SECOND_DRYENDTIME", 150)
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetLabel("DISP2DRYCOMPLETEDATE");
            //건조후 중량(g)	
            grddisp2.AddTextBoxColumn("SECOND_AFTERDRYWEIGHT", 100)
                .SetTextAlignment(TextAlignment.Right);
            // 중량 차이(g)	
            grddisp2.AddTextBoxColumn("SECOND_WEIGHTDIFF", 100)
                .SetTextAlignment(TextAlignment.Right);

            var grdchi2 = grdipti.View.AddGroupColumn("CHILLER2AP");
            //D1 MIN(mm)
            grdchi2.AddTextBoxColumn("SECONDD1MIN", 100)
                .SetTextAlignment(TextAlignment.Right);
            // D1 MAX(mm)
            grdchi2.AddTextBoxColumn("SECONDD1MAX", 100)
                .SetTextAlignment(TextAlignment.Right);
            // D2 MIN(mm)	
            grdchi2.AddTextBoxColumn("SECONDD2MIN", 100)
                .SetTextAlignment(TextAlignment.Right);
            // D2 MAX(mm)
            grdchi2.AddTextBoxColumn("SECONDD2MAX", 100)
                .SetTextAlignment(TextAlignment.Right);

            grdipti.View.PopulateColumns();

            
               // TODO : 그리드 초기화 로직 추가
            grdpimi.GridButtonItem =GridButtonItem.Export;
            grdpimi.View.SetIsReadOnly();
            // 측정시간
            grdpimi.View.AddTextBoxColumn("MEASURETIME", 100).SetLabel("MSMTIME")
                .SetTextAlignment(TextAlignment.Right);
            // Supply(MPA)
            grdpimi.View.AddTextBoxColumn("SUPPLYVALUE", 100).SetLabel("SUPPLYMPA")
                .SetTextAlignment(TextAlignment.Right);
            // Return(Mpa)
            grdpimi.View.AddTextBoxColumn("RETURNVALUE", 100).SetLabel("RETURNMPA")
                .SetTextAlignment(TextAlignment.Right);
            // 2단 온도(K)
            grdpimi.View.AddTextBoxColumn("TWOTEMPVALUE", 100).SetLabel("TWOSTAGETEMPERATURE")
                .SetTextAlignment(TextAlignment.Right);
            // T.C(K)
            grdpimi.View.AddTextBoxColumn("TCVALUE", 100).SetLabel("TCK")
                .SetTextAlignment(TextAlignment.Right);
            // VAC(Pa)
            grdpimi.View.AddTextBoxColumn("VACVALUE", 100).SetLabel("VACPA")
                .SetTextAlignment(TextAlignment.Center);

            grdpimi.View.PopulateColumns();

            grdChart.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            grdChart.GridButtonItem = GridButtonItem.None;
            grdChart.View.AddTextBoxColumn("GOUPCOLNAME",100).SetLabel("TYPE").SetIsReadOnly(); ;
            grdChart.View.AddTextBoxColumn("COLID").SetLabel("COLID").SetIsHidden(); ;
            grdChart.View.AddTextBoxColumn("COLNAME",150).SetLabel("ITEM");
            grdChart.View.PopulateColumns();
            grdChart.View.OptionsView.AllowCellMerge = true;
            grdChart.View.Columns["COLID"].OptionsColumn.AllowMerge = DefaultBoolean.False;
            grdChart.View.Columns["COLNAME"].OptionsColumn.AllowMerge = DefaultBoolean.False;
            setChartGridData();
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // TODO : 화면에서 사용할 이벤트 추가
            grdipti.View.FocusedRowChanged += View_FocusedRowChanged;
            btnApply.Click += BtnApply_Click;

        }

        private void BtnApply_Click(object sender, EventArgs e)
        {

            List<string> listselectCol = grdChart.View.GetCheckedRows().AsEnumerable().Select(c => c.Field<string>("COLID")).ToList<string>();
            listselectCol.Add("LOTID");

            string[] selectCol = listselectCol.AsEnumerable().ToArray<string>();


            DataTable dtChart = null;
            DataTable dt = grdipti.DataSource as DataTable;

            if (dt == null) return;

            if (dt.Rows.Count == 0) return;

            if (selectCol.Length == 1) return;

            dtChart = dt.DefaultView.ToTable(false, selectCol);



            if (dtChart.Rows.Count < 1) // 검색 조건에 해당하는 코드를 포함한 코드클래스가 없는 경우
            {
                this.pumpchart.Series.Clear();
                this.pumpchart.Controls.Clear();
                this.pumpchart.Legends.Clear();


            }


            else
            {
                

                this.pumpchart.Series.Clear();
                this.pumpchart.Controls.Clear();
                this.pumpchart.Legends.Clear();
                this.pumpchart.Titles.Clear();

                DataTable dtcolumns = new DataTable();
                dtcolumns.Columns.Add("COLUMNS");
                
                for (int i = 0; i < dtChart.Columns.Count - 1; i++)
                {
                    DataRow dr = dtcolumns.NewRow();
                    dr["COLUMNS"] = Language.Get(dtChart.Columns[i].ToString());
                    dtcolumns.Rows.Add(dr);
                }



                    ChartTitle title = new ChartTitle();
                title.Text = Language.Get("PUMPCHART");
                title.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;

                title.Font = new Font("Tahoma", 20, FontStyle.Bold);
                title.TextColor = Color.FromArgb(0, 91, 150);
                title.Indent = 10;

                pumpchart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
                pumpchart.Titles.Add(title);

                Font f;
                int count = 0;
                int index = 0;
                Dictionary<string, Series> seriesList = new Dictionary<string, Series>();

                for (int i = 0; i < dtChart.Columns.Count-1; i++)
                {

                    foreach (DataRow row in dtChart.Rows)
                    {
                        double value;
                        string parameterID = dtcolumns.Rows[i]["COLUMNS"].ToString();
                        string lotid = row["LOTID"].ToString();
                        if (string.IsNullOrEmpty(row[dtChart.Columns[i]].ToString()))
                        {
                            value = 0;
                        }
                        else
                        { 
                            value = Format.GetDouble(row[dtChart.Columns[i]],0);
                        }
                        Series series;
                        if (seriesList.TryGetValue(parameterID, out series) == false)
                        {
                            seriesList.Add(parameterID, series = new Series(parameterID, ViewType.Line));

                            ((LineSeriesView)series.View).LineStyle.Thickness = 1;

                            //라인위에 Point 표시
                  //          (series.View as LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;

                            pumpchart.Series.Add(series);
                            count++;
                        }

                        SeriesPoint point = new SeriesPoint(lotid, value);

                        series.Points.Add(point);
                        
                    }

                }




            string name = Language.Get("VALUE"); 

            f = new Font("Verdana", 15, FontStyle.Bold);
            ((XYDiagram)pumpchart.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            ((XYDiagram)pumpchart.Diagram).AxisY.Title.Text = name;
            ((XYDiagram)pumpchart.Diagram).AxisY.Title.TextColor = Color.Black;
            ((XYDiagram)pumpchart.Diagram).AxisY.Title.Font = f;

            name = Language.Get("LOTID");

            ((XYDiagram)pumpchart.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            ((XYDiagram)pumpchart.Diagram).AxisX.Title.Text = name;
            ((XYDiagram)pumpchart.Diagram).AxisX.Title.TextColor = Color.Black;
            ((XYDiagram)pumpchart.Diagram).AxisX.Title.Font = f;


            f = new Font("Verdana", 10, FontStyle.Bold);

            ((XYDiagram)pumpchart.Diagram).AxisX.Label.TextColor = Color.Black;
            ((XYDiagram)pumpchart.Diagram).AxisX.Label.Font = f;
            ((XYDiagram)pumpchart.Diagram).AxisY.Label.TextColor = Color.Black;
            ((XYDiagram)pumpchart.Diagram).AxisY.Label.Font = f;


            pumpchart.Dock = DockStyle.Fill;

            pumpchart.Size = new Size(1000, 1000);

                      
            }





        }

        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int rowHandle = e.FocusedRowHandle;

            if (rowHandle < 0) return;

            string Lotid = Format.GetTrimString(grdipti.View.GetRowCellValue(rowHandle, "LOTID"));

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("LOTID", Lotid);
            DataTable dt = SqlExecuter.Query("SearchPumpTimeData", "00001", param);
            grdpimi.DataSource = dt;

        }

        /// <summary>
        /// 코드그룹 리스트 그리드에서 추가 버튼 클릭 시 호출
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 툴바

        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();


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

            //조회 조건 새로 셋팅

            string from = DateTime.Parse(values["P_DATEPERIOD_PERIODFR"].ToString()).ToString("yyyy-MM-dd");
            string to = DateTime.Parse(values["P_DATEPERIOD_PERIODTO"].ToString()).ToString("yyyy-MM-dd");

            Dictionary<string, object> dic = new Dictionary<string, object>();

            dic.Add("LOTID", values["P_LOTNUM"].ToString());
            dic.Add("FROM", from);
            dic.Add("TO", to);

            DataTable dt = await QueryAsync("SearchPumpInspectionResult", "00001", dic);

            //DataTable dt = await ProcedureAsync("USP_REPINSPECTIONRESULT_BACK", dic);

            if (dt.Rows.Count < 1) // 검색 조건에 해당하는 코드를 포함한 코드클래스가 없는 경우
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }

            grdipti.DataSource = dt;
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


        }

        #endregion

        #region Private Function

        // TODO : 화면에서 사용할 내부 함수 추가
        private void setChartGridData()
        {
            /*
            grdChart.View.AddTextBoxColumn("GOUPCOLNAME").SetLabel("TYPE").SetIsReadOnly(); ;
            grdChart.View.AddTextBoxColumn("COLID").SetLabel("COLID");
            grdChart.View.AddTextBoxColumn("COLNAME").SetLabel("ITEM");
            */
            DataTable dt = new DataTable();

            dt.Columns.Add("GOUPCOLNAME");
            dt.Columns.Add("COLID");
            dt.Columns.Add("COLNAME");

            //pumpChartCol
            for (int i =0; i< pumpChartCol.Length; i++ )
            {
                string ColID = pumpChartCol[i];
                string ColName = grdipti.View.Columns[ColID].GetCaption();
                string GrpColName = grdipti.View.Columns[ColID].OwnerBand.Caption;
                dt.Rows.Add(GrpColName, ColID, ColName);
            }

            grdChart.DataSource = dt;
        }
        /// <summary>
        /// 마스터 정보를 조회한다.
        /// </summary>
        private void LoadData()
        {

        }

        #endregion
    }
}
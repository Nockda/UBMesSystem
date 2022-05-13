#region using

using DevExpress.Utils;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid.Conditions;
using Micube.SmartMES.Commons;
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

namespace Micube.SmartMES.Process
{
    /// <summary>
    /// 프 로 그 램 명  : 공정관리 > 공정실적 > 조립실적 상세현황
    /// 업  무  설  명  : 조립공정의 실적을 보여준다
    /// 생    성    자  : 배선용
    /// 생    성    일  : 2020-07-17
    /// 수  정  이  력  : 2021-05-14 scmo 자재거래처필드 추가
    /// 
    /// 
    /// </summary>
    public partial class AssyDetailResult : SmartConditionBaseForm
    {
        #region Local Variables

        // TODO : 화면에서 사용할 내부 변수 추가
        private DataTable specForMeasureResult;

        #endregion

        #region 생성자

        public AssyDetailResult()
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

            // TODO : 컨트롤 초기화 로직 구성
            InitializeGrid();

            InitializeEvent();

        }

        #region 그리드 초기화
        /// <summary>        
        /// 품목 라우터 관리 그리드를 초기화한다.
        /// </summary>
        private void InitializeGrid()
        {
            // TODO : 그리드 초기화 로직 추가
            #region Main 조회 그리드 
            grdMain.GridButtonItem = GridButtonItem.Export;
            grdMain.View.SetIsReadOnly();
            grdMain.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;

            grdMain.View.AddTextBoxColumn("WORKDATE", 90).SetTextAlignment(TextAlignment.Center);
            grdMain.View.AddTextBoxColumn("WORKORDERID", 130);
            grdMain.View.AddTextBoxColumn("LOTID", 115);
            grdMain.View.AddTextBoxColumn("PRODUCTDEFID", 130).SetIsHidden();
            grdMain.View.AddTextBoxColumn("PARTNUMBER", 130).SetLabel("PRODUCTDEFID");
            grdMain.View.AddTextBoxColumn("PRODUCTDEFNAME", 170).SetLabel("PRODUCTDEFIDNAME");
            grdMain.View.AddTextBoxColumn("STANDARD", 120);
            grdMain.View.AddTextBoxColumn("MODEL", 120);
            grdMain.View.AddSpinEditColumn("QTY", 65);
            grdMain.View.AddTextBoxColumn("TRACKINTIME", 140).SetLabel("WORKSTARTTIME").SetTextAlignment(TextAlignment.Center);
            grdMain.View.AddTextBoxColumn("TRACKOUTTIME", 140).SetLabel("WORKENDTIME").SetTextAlignment(TextAlignment.Center);
            grdMain.View.AddSpinEditColumn("WORKTIME", 80).SetDisplayFormat("#,##0.#", MaskTypes.Numeric);
            grdMain.View.AddTextBoxColumn("STANDARDTIME", 60).SetLabel("STDTIME");
            grdMain.View.AddTextBoxColumn("AREANAME", 130);
            grdMain.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 130);
            grdMain.View.AddTextBoxColumn("LOTSTATE", 130).SetLabel("STATE");

            grdMain.View.PopulateColumns();
            #endregion

            #region 공정실적 그리드

            grdProceeResult.View.SetIsReadOnly();
            grdProceeResult.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;

            //순서
            grdProceeResult.View.AddTextBoxColumn("USERSEQUENCE", 50).SetLabel("SPECSEQ").SetTextAlignment(TextAlignment.Center);
            //세부공정
            grdProceeResult.View.AddTextBoxColumn("SUBPROCESSSEGMENTNAME", 150);
            //작업자
            grdProceeResult.View.AddTextBoxColumn("WORKER", 100);
            //작업시작일시
            grdProceeResult.View.AddTextBoxColumn("WORKSTARTTIME", 140).SetTextAlignment(TextAlignment.Center);
            //작업종료일시
            grdProceeResult.View.AddTextBoxColumn("WORKENDTIME", 140).SetTextAlignment(TextAlignment.Center);
            //작업시간
            grdProceeResult.View.AddSpinEditColumn("WORKTIME", 90).SetDisplayFormat("#,##0.#", MaskTypes.Numeric);
            //작업설비
            grdProceeResult.View.AddTextBoxColumn("WORKEQUIPMENT", 160);
            grdProceeResult.View.PopulateColumns();
            #endregion

            #region 작업실적
            grdWorkResult.View.SetIsReadOnly();
            grdWorkResult.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            //스펙 ID
            grdWorkResult.View.AddTextBoxColumn("SPECDEFID", 100).SetTextAlignment(TextAlignment.Center);
            //순서
            grdWorkResult.View.AddTextBoxColumn("USERSEQUENCE", 50).SetLabel("SPECSEQ").SetTextAlignment(TextAlignment.Center);
            //세부공정
            grdWorkResult.View.AddTextBoxColumn("SUBPROCESSSEGMENTNAME", 150);
            //실적입력항목 INPUTRESULTITEM
            grdWorkResult.View.AddTextBoxColumn("PARAMETERNAME", 250).SetLabel("INPUTRESULTITEM");
            //실적값 RESULTVALUE
            grdWorkResult.View.AddTextBoxColumn("MEASUREVALUE", 90).SetLabel("RESULTVALUE");
            //단위 UNIT
            grdWorkResult.View.AddTextBoxColumn("UNIT", 50);
            //MIN
            grdWorkResult.View.AddTextBoxColumn("LSL", 80).SetLabel("MIN");
            //MAX
            grdWorkResult.View.AddTextBoxColumn("USL", 80).SetLabel("MAX");
            //생성일시
            grdWorkResult.View.AddTextBoxColumn("CREATEDTIME", 140).SetTextAlignment(TextAlignment.Center).SetLabel("WORKDAY");
            //생성자
            grdWorkResult.View.AddTextBoxColumn("CREATOR", 80).SetTextAlignment(TextAlignment.Center).SetLabel("WORKER");
            grdWorkResult.View.PopulateColumns();

            grdWorkResult.View.OptionsView.AllowCellMerge = true; // CellMerge
            grdWorkResult.View.Columns["PARAMETERNAME"].OptionsColumn.AllowMerge = DefaultBoolean.False;
            grdWorkResult.View.Columns["MEASUREVALUE"].OptionsColumn.AllowMerge = DefaultBoolean.False;
            grdWorkResult.View.Columns["UNIT"].OptionsColumn.AllowMerge = DefaultBoolean.False;
            grdWorkResult.View.Columns["LSL"].OptionsColumn.AllowMerge = DefaultBoolean.False;
            grdWorkResult.View.Columns["USL"].OptionsColumn.AllowMerge = DefaultBoolean.False;
            grdWorkResult.View.Columns["CREATEDTIME"].OptionsColumn.AllowMerge = DefaultBoolean.False;
            grdWorkResult.View.Columns["CREATOR"].OptionsColumn.AllowMerge = DefaultBoolean.False;

            #endregion

            #region
            grdMatInputHist.View.SetIsReadOnly();
            grdMatInputHist.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            //구분 TYPE
            grdMatInputHist.View.AddTextBoxColumn("CONSUMABLETYPE", 60).SetLabel("TYPE");
            //자재코드 CONSUMABLEDEFID
            grdMatInputHist.View.AddTextBoxColumn("CONSUMABLEDEFID", 120).SetLabel("CONSUMABLEDEFID").SetIsHidden();
            grdMatInputHist.View.AddTextBoxColumn("PARTNUMBER", 120).SetLabel("CONSUMABLEDEFID");
            //자재명 CONSUMABLEDEFNAME
            grdMatInputHist.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 200);
            //규격 STANDARD
            grdMatInputHist.View.AddTextBoxColumn("STANDARD", 120);
            //기종 MODEL 
            grdMatInputHist.View.AddTextBoxColumn("MODEL", 100);
            //lot번호 lotid
            grdMatInputHist.View.AddTextBoxColumn("MATERIALLOTID", 120).SetLabel("LOTID");
            //양품 GOODQTY
            grdMatInputHist.View.AddSpinEditColumn("GOODQTY", 60).SetDisplayFormat("#,##0.######");
            //불량 BADQTY
            grdMatInputHist.View.AddSpinEditColumn("BADQTY", 60).SetDisplayFormat("#,##0.######");
            //업체S/N VENDORSERIAL
            grdMatInputHist.View.AddTextBoxColumn("SERIALNO", 100).SetLabel("VENDORSERIAL");
            //특이사항 COMMENT
            grdMatInputHist.View.AddTextBoxColumn("DESCRIPTION", 200).SetLabel("COMMENT");
            //자재거래처
            grdMatInputHist.View.AddTextBoxColumn("CUSTOMERNAME", 120).SetLabel("VENDOR");

            grdMatInputHist.View.PopulateColumns();
            #endregion
        }
        #endregion

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            grdMain.View.FocusedRowChanged += View_FocusedRowChanged;
            tabResult.SelectedPageChanged += TabResult_SelectedPageChanged;
            grdWorkResult.View.RowCellStyle += grdWorkResult_RowCellStyle;
            grdInspResult.View.RowCellStyle += grdInspResult_RowCellStyle;
        }

        private void grdInspResult_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            // todo 불량
            if (e.CellValue.ToString() == "불량")
            {
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.BackColor = Color.Orange;
            }
            else if (e.Column.FieldName != "CNT")
            {
                DataRow spec = FindSpec(e.Column.FieldName);
                if (spec == null)
                {
                    return;
                }
                string inputType = spec["INPUTTYPE"].ToString();
                string specType = spec["SPECTYPE"].ToString();
                decimal min = Format.GetDecimal(spec["LSL"].ToString());
                decimal max = Format.GetDecimal(spec["USL"].ToString());

                if (inputType == "FLOAT" || inputType == "INT")
                {
                    decimal val;
                    if (e.CellValue != DBNull.Value && decimal.TryParse(e.CellValue.ToString(), out val)) // 숫자 파싱 성공
                    {
                        if ((specType == "BOTH" && (min > val || max < val))
                            || (specType == "UPPER" && (max < val))
                            || (specType == "LOWER" && (min > val))) // 스펙 아웃
                        {
                            e.Appearance.ForeColor = System.Drawing.Color.Black;
                            e.Appearance.BackColor = System.Drawing.Color.PaleVioletRed;
                        }
                    }
                }
            }
        }

        private DataRow FindSpec(string columnName)
        {
            if (this.specForMeasureResult == null)
            {
                return null;
            }
            foreach (DataRow each in this.specForMeasureResult.Rows)
            {
                if (each["COLUMNNAME"].ToString() == columnName)
                {
                    return each;
                }
            }
            return null;
        }

        private void grdWorkResult_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "MEASUREVALUE")
            {
                string inputType = grdWorkResult.View.GetRowCellValue(e.RowHandle, "INPUTTYPE").ToString();
                string specType = grdWorkResult.View.GetRowCellValue(e.RowHandle, "SPECTYPE").ToString();
                decimal min = Format.GetDecimal(grdWorkResult.View.GetRowCellValue(e.RowHandle, "LSL").ToString());
                decimal max = Format.GetDecimal(grdWorkResult.View.GetRowCellValue(e.RowHandle, "USL").ToString());

                if (inputType == "FLOAT" || inputType == "INT")
                {
                    decimal val;
                    if (e.CellValue != DBNull.Value && decimal.TryParse(e.CellValue.ToString(), out val)) // 숫자 파싱 성공
                    {
                        if ((specType == "BOTH" && (min > val || max < val))
                            || (specType == "UPPER" && (max < val))
                            || (specType == "LOWER" && (min > val))) // 스펙 아웃
                        {
                            e.Appearance.ForeColor = System.Drawing.Color.Black;
                            e.Appearance.BackColor = System.Drawing.Color.PaleVioletRed;
                        }
                    }
                }
            }
        }

        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string Lotid = Format.GetTrimString(grdMain.View.GetRowCellValue(e.FocusedRowHandle, "LOTID"));
            serachDetailResult(Lotid);
        }

        private void TabResult_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            int rowhandle = grdMain.View.FocusedRowHandle;

            if (rowhandle < 0) return;

            string Lotid = Format.GetTrimString(grdMain.View.GetRowCellValue(rowhandle, "LOTID"));

            serachDetailResult(Lotid);
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
            //DataTable changed = grdProcessDef.GetChangedRows();

            //ExecuteRule("SaveCodeClass", changed);
        }

        /// <summary>
        /// 툴바 버튼 기능
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            SmartButton btn = sender as SmartButton;

            if (btn.Name.ToString().Equals("Save") || btn.Name.ToString().Equals("SaveBehind"))
            {
                Btn_SaveClick(btn.Text);
            }

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
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dt = await SqlExecuter.QueryAsync("SearchAssyResult", "00001", values);

            if (dt.Rows.Count < 1) // 검색 조건에 해당하는 코드를 포함한 코드클래스가 없는 경우
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }

            grdMain.DataSource = dt;


        }

        #region 조회조건
        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

            // TODO : 조회조건 추가 구성이 필요한 경우 사용
            CommonFunction.AddConditionProductPopup("P_PRODUCTDEFID", 4.1, false, Conditions, "PARTNUMBER");
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
        /// <summary>
        /// 저장 함수
        /// </summary>
        /// <param name="strtitle"></param>
        private void Btn_SaveClick(string strtitle)
        {

        }

        private void serachDetailResult(string Lotid)
        {
            switch (tabResult.SelectedTabPage.Name)
            {
                case "pageProcessResult":
                    SearchProcessResult(Lotid);
                    break;
                case "pageWorkResult":
                    SearchWorkResult(Lotid);
                    break;
                case "pageInspResult":
                    SearchMeasureResult(Lotid);
                    break;
                case "pageInputMaterialHist":
                    SearchMaterialInputHist(Lotid);
                    break;
            }
        }
        private void SearchProcessResult(string Lotid)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("LOTID", Lotid);
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            DataTable dt = SqlExecuter.Query("SearchAssyProcessResult", "00001", param);
            grdProceeResult.DataSource = dt;
        }
        private void SearchWorkResult(string Lotid)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("LOTID", Lotid);
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            DataTable dt = SqlExecuter.Query("SearchAssyWorkResult", "00001", param);

            foreach (DataRow row in dt.Rows)
            {
                row["SPECDEFID"] = $"{row["SPECDEFID"]} ({row["SPECDEFIDVERSION"]})";
            }
            grdWorkResult.DataSource = dt;
        }
        private void SearchMaterialInputHist(string Lotid)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("LOTID", Lotid);
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            param.Add("DBLINKNAME", CommonFunction.DbLinkName);
            DataTable dt = SqlExecuter.Query("SearchAssyMaterialInputHist", "00001", param);
            grdMatInputHist.DataSource = dt;
        }
        private void SearchMeasureResult(string Lotid)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("LOTID", Lotid);
            DataTable dt = SqlExecuter.Procedure("USP_GETMEASURERESULT", param);
            this.specForMeasureResult = SqlExecuter.Query("GetSpecForAssyDetailResult", "00001", param);

            // 그리드 컬럼 초기화
            grdInspResult.View.ClearColumns();
            grdInspResult.View.ClearDatas();
            grdInspResult.GridButtonItem = GridButtonItem.Export;
            grdInspResult.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            grdInspResult.View.SetIsReadOnly();
            //SUBPROCESSSEGMENTNAME

            if (dt.Rows.Count == 0) return;

            var grpSubProcess = grdInspResult.View.AddGroupColumn("SUBPROCESSSEGMENTNAME");
            grpSubProcess.AddTextBoxColumn("CNT", 70).SetLabel("INPUTITEM").SetTextAlignment(TextAlignment.Center);

            string prevGrpColName = string.Empty;

            ConditionItemGroup grpCol = null;

            foreach (DataColumn col in dt.Columns)
            {
                string colName = col.ColumnName;

                if (colName.Equals("CNT")) continue;

                string[] colList = colName.Split('_');

                string grpColName = colList[0];

                if (!grpColName.Equals(prevGrpColName))
                {
                    grpCol = grdInspResult.View.AddGroupColumn(grpColName);
                    prevGrpColName = grpColName;
                }

                grpCol.AddTextBoxColumn(colName, 80).SetLabel(colList[1]).SetTextAlignment(TextAlignment.Center);

            }
            grdInspResult.View.PopulateColumns();
            grdInspResult.DataSource = dt;
            grdInspResult.View.BestFitColumns();
        }
        #endregion
    }
}
#region using

using DevExpress.Charts.Native;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.SmartMES.Material.Kanban;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Micube.SmartMES.Material
{
    /// <summary>
    /// 프 로 그 램 명  : 자재관리 > 간반요청출고관리
    /// 업  무  설  명  : 간반요청, 출고처리 화면
    /// 생    성    자  : jylee
    /// 생    성    일  : 2020-04-23
    /// 수  정  이  력  : 2020-06-10 | JYLEE | 컬럼수정(DateFormat), Width조절
    /// </summary>
    public partial class KanbanConduct : SmartConditionBaseForm
    {

        private SmartDateEdit _dateTo;
        SmartDateEdit dateTo { get { return this._dateTo; } set { this._dateTo = value; } }

        private SmartComboBox _combo;
        SmartComboBox combo { get { return this._combo; } set { this._combo = value; } }

        private string _comboDisplayTxt;
        string comboDisplayTxt { get { return this._comboDisplayTxt; } set { this._comboDisplayTxt = value; } }

        private bool _comboChanged;

        bool combochanged { get { return this._comboChanged; } set { this._comboChanged = value; } }

        #region 컨텐츠 초기화

        public KanbanConduct()  
        {
            InitializeComponent();
            //

        }
        /// <summary>
        /// 화면의 컨텐츠 영역을 초기화한다.
        /// </summary>
        protected override void InitializeContent()
        {
            base.InitializeContent();
            InitializeRequestGrid();
            InitializeInsertLotGrid();
            InitializeEvent();
        }
        /// <summary>
        /// 간반요청/ 출고 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeRequestGrid()
        {
            grdKanban.GridButtonItem = GridButtonItem.Export;
            //grdKanban.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdKanban.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdKanban.View.SetIsReadOnly();

            //요청번호
            grdKanban.View.AddTextBoxColumn("REQCODE", 100)
                .SetValidationKeyColumn()
                .SetValidationIsRequired()
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();

            //요청일자
            grdKanban.View.AddTextBoxColumn("REQDATE", 100)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd")
                .SetTextAlignment(TextAlignment.Center);

            //진행상태
            //grdKanban.View.AddTextBoxColumn("STATE", 80)
            //    .SetIsReadOnly()
            //    .SetTextAlignment(TextAlignment.Center);
            grdKanban.View.AddComboBoxColumn("STATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=KanbanState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);

            //처리일자
            grdKanban.View.AddTextBoxColumn("RESDATE", 100)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd")
                .SetTextAlignment(TextAlignment.Center);

            //간반코드
            grdKanban.View.AddTextBoxColumn("CELLID", 80)
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("KANBANID");

            //간반
            grdKanban.View.AddTextBoxColumn("CELLNAME", 100)
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("KANBANNAME");

            //자재코드
            grdKanban.View.AddTextBoxColumn("CONSUMABLEDEFID", 150)
                  .SetTextAlignment(TextAlignment.Center)
                  .SetIsHidden();

            grdKanban.View.AddTextBoxColumn("PARTNUMBER", 150)
                .SetTextAlignment(TextAlignment.Center);

            //자재명
            grdKanban.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 250);

            //자재유형(Hidden)
            grdKanban.View.AddTextBoxColumn("CONSUMABLETYPE", 70)
                .SetIsHidden();

            //자재유형
            grdKanban.View.AddTextBoxColumn("CONSUMABLETYPENAME", 80)
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("CONSUMABLETYPE");
            //요청수량
            grdKanban.View.AddTextBoxColumn("CONSUMABLELOTQTY", 80).SetLabel("REQUESTQTY");

            //투입수량
            grdKanban.View.AddTextBoxColumn("LOTQTY", 80).SetLabel("OUTQTY");

            //단위
            grdKanban.View.AddTextBoxColumn("UNIT", 50)
                .SetTextAlignment(TextAlignment.Center);

            //요청창고ID (TO창고)(Hidden)
            grdKanban.View.AddTextBoxColumn("TOWAREHOUSEID", 140)
                .SetIsHidden();

            //요청창고 (TO창고)
            grdKanban.View.AddTextBoxColumn("TOWAREHOUSENAME", 120)
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("REQUESTWAREHOUSENAME");

            //위치
            grdKanban.View.AddTextBoxColumn("LOCATION", 80)
                .SetTextAlignment(TextAlignment.Center);

            //FROM창고ID(HIDDEN)
            grdKanban.View.AddTextBoxColumn("FROMWAREHOUSEID", 100)
                .SetIsHidden();

            //FROM창고(HIDDEN)
            grdKanban.View.AddTextBoxColumn("FROMWAREHOUSENAME", 100)
                .SetIsHidden();

            //요청부서ID
            grdKanban.View.AddTextBoxColumn("DEPARTMENTID", 100)
                .SetIsHidden();

            //요청부서
            grdKanban.View.AddTextBoxColumn("DEPARTMENT", 100);

            //요청자 사원번호(HIDE)
            grdKanban.View.AddTextBoxColumn("USERID", 80)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsHidden();

            //요청자
            grdKanban.View.AddTextBoxColumn("USERNAME", 80)
                .SetTextAlignment(TextAlignment.Center);

            grdKanban.View.PopulateColumns();
        }

        private void InitializeInsertLotGrid()
        {
            grdLot.GridButtonItem = GridButtonItem.Export;
            grdLot.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdLot.View.SetIsReadOnly();

            grdLot.View.AddTextBoxColumn("LOTID", 150)
                          .SetTextAlignment(TextAlignment.Center);
            grdLot.View.AddTextBoxColumn("QTY", 80);
            grdLot.View.AddTextBoxColumn("UNIT", 60)
                           .SetTextAlignment(TextAlignment.Center);

            grdLot.View.PopulateColumns();
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

            DataTable dtKanban = await QueryAsync("GetKanbanList", "00001", values);

            if (dtKanban.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
                grdKanban.DataSource = null;
                grdLot.DataSource = null;
            }
            else
            {
                grdKanban.DataSource = dtKanban;

                if (dtKanban.Rows[0]["STATE"].ToString() == "Response")
                {
                    Dictionary<string, object> param = new Dictionary<string, object>();
                    param.Add("P_REQCODE", dtKanban.Rows[0]["REQCODE"].ToString());
                    grdLot.DataSource = SqlExecuter.Query("GetKanbanLotList", "00001", param);
                }
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
            
            SmartPeriodEdit pDate = this.Conditions.GetControl<SmartPeriodEdit>("P_DATEPERIOD");
            this.combo = pDate.comboPeriod;
            this.dateTo = pDate.datePeriodTo;

            combo.EditValueChanged += Combo_EditValueChanged;
            combo.EditValueChanging += Combo_EditValueChanging;

            Combo_EditValueChanged(null, null);

        }

        private void Combo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (combochanged == true)
            {
                e.Cancel = true;
            }
        }

        private void Combo_EditValueChanged(object sender, EventArgs e)
        {
            string editValue = this.combo.EditValue.ToString();
            DateTime date = Convert.ToDateTime(this.dateTo.EditValue.ToString()).AddDays(-1);

            if (editValue == "CUSTOM"
                 || combochanged == true) return;

            combochanged = true;
            this.dateTo.EditValue = date;
            combochanged = false;

        }
        #endregion

        #region Event
        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            grdKanban.View.FocusedRowChanged += View_FocusedRowChanged;
            grdKanban.View.RowStyle += View_RowStyle;
        }

        private void focusedRowChanged()
        {
            var row = grdKanban.View.GetDataRow(grdKanban.View.FocusedRowHandle);

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_REQCODE", row["REQCODE"].ToString());

            if (string.IsNullOrEmpty(row["REQCODE"].ToString()))
            {
                /*                ShowMessage("NoSelectData");
                                grdLot.View.ClearDatas();*/

                return;
            }
            grdLot.View.ClearDatas();
            grdLot.DataSource = SqlExecuter.Query("GetKanbanLotList", "00001", param);

        }

        private void View_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (grdKanban.View.GetRowCellValue(e.RowHandle, "STATE") == null) return;
            if (grdKanban.View.GetRowCellValue(e.RowHandle, "STATE").Equals("Ready")) 
            {
                e.HighPriority = true;
                e.Appearance.BackColor = Color.FromArgb(30, 255, 0, 0);
            }
            else
            {
                return;
            }
        }

        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            focusedRowChanged();
        }

        #endregion

        #region Toolbar

        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            SmartButton btn = sender as SmartButton;
            DataTable selectedRows = grdKanban.View.GetCheckedRows();

            if (btn.Name.ToString().Equals("KanbanRequest")) //간반요청 팝업
            {

                KanbanReqPopup2 RequestPopup = new KanbanReqPopup2();
                RequestPopup.ShowDialog(this);
                OnSearchAsync();
            }
            else if (btn.Name.ToString().Equals("KanbanRespond")) //처리완료 팝업
            {
                CheckSelectedData(selectedRows);
                CheckReadyState(selectedRows);
                KanbanResPopup2 ResponsePopup = new KanbanResPopup2(selectedRows);
                ResponsePopup.ShowDialog(this);
                OnSearchAsync();
            }
            else if (btn.Name.ToString().Equals("ReadyMaterial")) //자재준비
            {
                CheckSelectedData(selectedRows);
                CheckedRequestState(selectedRows);
                OnSearchAsync();
            }

        }

        #endregion

        #region 유효성 검사

        //선택된 Row확인
        private void CheckSelectedData(DataTable selected)
        {
            if(selected.Rows.Count == 0)
            {
                throw MessageException.Create("RequestInfoNotSelected");     // 선택된 요청정보가 없습니다.
            }
            else
            {
                return;
            }
        }
        
        private void CheckedRequestState(DataTable selected)
        {
            Boolean result = false;
            foreach (DataRow row in selected.Rows)
            {
                if (row["state"].Equals("Request")){
                    result = true;
                }
                else
                {
                    //요청상태만 자재준비가 가능합니다.
                    throw MessageException.Create("OnlyRequestState");
                }
            }
            if (result)
            {
                ExecuteRule("ChangeKanbanStateReady", selected);
            }
        }

        private void CheckReadyState(DataTable selected)
        {
            Boolean result = false;
            foreach (DataRow row in selected.Rows)
            {
                if (row["state"].Equals("Ready"))
                {
                    result = true;
                }
                else
                {
                    //준비상태만 처리완료가 가능합니다.
                    throw MessageException.Create("OnlyReadyState");
                }
            }
            if (result)
            {
                ExecuteRule("ChangeKanbanStateReady", selected);
            }
        }
        #endregion
    }
}

#region using
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.SmartMES.Commons;
using Micube.Framework.SmartControls.Grid;

using System;
using Micube.SmartMES.Commons.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraGrid.Views.Base;
#endregion

namespace Micube.SmartMES.Material
{
    /// <summary>
    /// 프 로 그 램 명  : 자재관리 > 자재 Lot 관리 > 자재병합
    /// 업  무  설  명  : 기준 자재 Lot에 여러개의 자재 Lot을 병합한다.
    /// 생    성    자  : 유태근
    /// 생    성    일  : 2020-06-10
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class ConsumableLotMerge : SmartConditionBaseForm
    {
        #region Local Variables

        private string _consumableLotId = ""; // 병합대상 자재 Lot No

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        public ConsumableLotMerge()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Form_Load(object sender, EventArgs e)
        {
            InitializeComboBox();
            InitializeGrid();
            InitializeControls();
        }

        #endregion

        #region 컨텐츠 영역 초기화

        /// <summary>
        /// Control 설정
        /// </summary>
        protected override void InitializeContent()
        {
            base.InitializeContent();

            smartGroupBox1.Width = 500;

            smartGroupBox1.Height = 500;
            smartGroupBox2.Height = 500;

            this.ucDataUpDownBtnCtrl.SourceGrid = this.grdTargetMergeConsumableLot;
            this.ucDataUpDownBtnCtrl.TargetGrid = this.grdSelectTargetMergeConsumableLot;

            this.ucDataUpDownBtnCtrl2.SourceGrid = this.grdTargetMergeConsumableLot;
            this.ucDataUpDownBtnCtrl2.TargetGrid = this.grdMergeConsumableLot;

            InitializeEvent();
        }

        #region 조회조건 설정

        /// <summary>
        /// 검색조건 설정
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

            ConditionHelper.AddConditionConsumProductPopup("P_CONSUMABLEDEFIDNAME", 1.2, false, Conditions);
        }

        /// <summary>
        /// 조회조건 설정
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();
        }

        #endregion

        #region ComboBox 초기화

        /// <summary>
        /// 콤보박스를 초기화 하는 함수
        /// </summary>
        private void InitializeComboBox()
        {

        }

        #endregion

        #region Grid 설정

        /// <summary>        
        /// 그리드 초기화
        /// </summary>
        private void InitializeGrid()
        {
            #region 재공 Grid 설정

            grdTargetMergeConsumableLot.GridButtonItem = GridButtonItem.None;

            grdTargetMergeConsumableLot.View.SetIsReadOnly();
            grdTargetMergeConsumableLot.View.SetAutoFillColumn("CONSUMABLEDEFNAME");

            // CheckBox 설정
            this.grdTargetMergeConsumableLot.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            this.grdTargetMergeConsumableLot.View.CheckMarkSelection.MultiSelectCount = 0;

            // 자재 Lot Id
            grdTargetMergeConsumableLot.View.AddTextBoxColumn("CONSUMABLELOTID", 150);
            // 창고 Id
            grdTargetMergeConsumableLot.View.AddTextBoxColumn("WAREHOUSEID", 100)
                .SetIsHidden();
            // 창고명
            grdTargetMergeConsumableLot.View.AddTextBoxColumn("WAREHOUSENAME", 150);
            // 작업장 Id
            grdTargetMergeConsumableLot.View.AddTextBoxColumn("AREAID", 100)
                .SetIsHidden();
            // 작업장명
            grdTargetMergeConsumableLot.View.AddTextBoxColumn("AREANAME", 150);
            // 위치 Id
            grdTargetMergeConsumableLot.View.AddTextBoxColumn("LOCATIONID", 120)
                .SetTextAlignment(TextAlignment.Center);
            // 품번
            grdTargetMergeConsumableLot.View.AddTextBoxColumn("PARTNUMBER", 150);
            // 자재 Id
            grdTargetMergeConsumableLot.View.AddTextBoxColumn("CONSUMABLEDEFID", 150).SetIsHidden();
            // 자재 Version
            grdTargetMergeConsumableLot.View.AddTextBoxColumn("CONSUMABLEDEFVERSION", 80)
                .SetTextAlignment(TextAlignment.Center).SetIsHidden();
            // 자재명
            grdTargetMergeConsumableLot.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 220);
            // 자재생성수량
            grdTargetMergeConsumableLot.View.AddTextBoxColumn("CREATEDQTY", 80)
                .SetTextAlignment(TextAlignment.Right);
            // 자재량
            grdTargetMergeConsumableLot.View.AddTextBoxColumn("CONSUMABLELOTQTY", 80)
                .SetTextAlignment(TextAlignment.Right);
            // 자재상태
            grdTargetMergeConsumableLot.View.AddTextBoxColumn("STATE", 100)
                .SetTextAlignment(TextAlignment.Center);

            grdTargetMergeConsumableLot.View.PopulateColumns();

            grdTargetMergeConsumableLot.View.OptionsNavigation.AutoMoveRowFocus = false;

            #endregion

            #region Target Grid

            grdSelectTargetMergeConsumableLot.GridButtonItem = GridButtonItem.None;
            grdSelectTargetMergeConsumableLot.View.SetIsReadOnly();

            // CheckBox 설정
            this.grdSelectTargetMergeConsumableLot.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            // 병합대상 자재 Lot Id
            grdSelectTargetMergeConsumableLot.View.AddTextBoxColumn("CONSUMABLELOTID", 150);
            // 작업장명
            grdSelectTargetMergeConsumableLot.View.AddTextBoxColumn("AREANAME", 150);
            // 총수량
            grdSelectTargetMergeConsumableLot.View.AddTextBoxColumn("CONSUMABLELOTQTY", 80)
                .SetTextAlignment(TextAlignment.Right);

            // 창고 Id
            grdSelectTargetMergeConsumableLot.View.AddTextBoxColumn("WAREHOUSEID", 100)
                .SetIsHidden();
            // 창고명
            grdSelectTargetMergeConsumableLot.View.AddTextBoxColumn("WAREHOUSENAME", 100)
                .SetIsHidden();
            // 작업장 Id
            grdSelectTargetMergeConsumableLot.View.AddTextBoxColumn("AREAID", 100)
                .SetIsHidden();
            // 위치 Id
            grdSelectTargetMergeConsumableLot.View.AddTextBoxColumn("LOCATIONID", 100)
                .SetIsHidden();
            // 자재 Id
            grdSelectTargetMergeConsumableLot.View.AddTextBoxColumn("CONSUMABLEDEFID", 100)
                .SetIsHidden();
            // 자재 Version
            grdSelectTargetMergeConsumableLot.View.AddTextBoxColumn("CONSUMABLEDEFVERSION", 100)
                .SetIsHidden();
            // 자재명
            grdSelectTargetMergeConsumableLot.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 100)
                .SetIsHidden();
            // 자재생성수량
            grdSelectTargetMergeConsumableLot.View.AddTextBoxColumn("CREATEDQTY", 100)
                .SetIsHidden();
            // 자재상태
            grdSelectTargetMergeConsumableLot.View.AddTextBoxColumn("STATE", 100)
                .SetIsHidden();

            grdSelectTargetMergeConsumableLot.View.PopulateColumns();

            grdSelectTargetMergeConsumableLot.View.OptionsNavigation.AutoMoveRowFocus = false;

            #endregion

            #region Source Grid

            grdMergeConsumableLot.GridButtonItem = GridButtonItem.None;

            // CheckBox 설정
            this.grdMergeConsumableLot.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            // 병합자재 Lot Id
            grdMergeConsumableLot.View.AddTextBoxColumn("CONSUMABLELOTID", 150)
                .SetIsReadOnly();
            // 작업장명
            grdMergeConsumableLot.View.AddTextBoxColumn("AREANAME", 150)
                .SetIsReadOnly();
            // 품번
            grdMergeConsumableLot.View.AddTextBoxColumn("PARTNUMBER", 150)
                .SetIsReadOnly();
            // 자재 Id
            grdMergeConsumableLot.View.AddTextBoxColumn("CONSUMABLEDEFID", 150)
                .SetIsReadOnly().SetIsHidden();
            // 자재 Version
            grdMergeConsumableLot.View.AddTextBoxColumn("CONSUMABLEDEFVERSION", 80)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly().SetIsHidden();
            // 자재명
            grdMergeConsumableLot.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 220)
                .SetIsReadOnly();
            // 자재량
            grdMergeConsumableLot.View.AddTextBoxColumn("CONSUMABLELOTQTY", 80)
                .SetTextAlignment(TextAlignment.Right)
                .SetIsReadOnly();
            // 병합 수량
            grdMergeConsumableLot.View.AddSpinEditColumn("MERGEQTY", 80)
                .SetTextAlignment(TextAlignment.Right)
                .SetDisplayFormat("{0:#,###}")
                .SetValidationIsRequired()
                .MinValue = 1;

            // 창고 Id
            grdMergeConsumableLot.View.AddTextBoxColumn("WAREHOUSEID", 100)
                .SetIsHidden();
            // 창고명
            grdMergeConsumableLot.View.AddTextBoxColumn("WAREHOUSENAME", 100)
                .SetIsHidden();
            // 작업장 Id
            grdMergeConsumableLot.View.AddTextBoxColumn("AREAID", 100)
                .SetIsHidden();
            // 위치 Id
            grdMergeConsumableLot.View.AddTextBoxColumn("LOCATIONID", 100)
                .SetIsHidden();
            // 자재생성수량
            grdMergeConsumableLot.View.AddTextBoxColumn("CREATEDQTY", 100)
                .SetIsHidden();
            // 자재상태
            grdMergeConsumableLot.View.AddTextBoxColumn("STATE", 100)
                .SetIsHidden();

            grdMergeConsumableLot.View.PopulateColumns();

            grdMergeConsumableLot.View.OptionsNavigation.AutoMoveRowFocus = false;

            #endregion
        }

        #endregion

        #region 화면 Control 설정

        /// <summary>
        /// 화면 Control 설정
        /// </summary>
        private void InitializeControls()
        {
            grdTargetMergeConsumableLot.Height = 450;
        } 

        #endregion

        #endregion

        #region Event

        /// <summary>        
        /// 이벤트 초기화
        /// </summary>
        public void InitializeEvent()
        {
            // TODO : 화면에서 사용할 이벤트 추가
            this.Load += Form_Load;

            // Grid Event
            grdTargetMergeConsumableLot.View.DoubleClick += View_DoubleClick;
            grdTargetMergeConsumableLot.View.RowStyle += grdTargetMergeConsumableLot_RowStyle;
            grdTargetMergeConsumableLot.View.CheckStateChanged += grdTargetMergeConsumableLot_CheckStateChanged;

            // Target Grid Event
            grdSelectTargetMergeConsumableLot.View.RowStyle += Target_RowStyle;

            // Soruce Grid Event
            grdMergeConsumableLot.View.CellValueChanged += View_CellValueChanged;

            // Button Event
            this.ucDataUpDownBtnCtrl.buttonClick += UcDataUpDownBtnCtrl_buttonClick;
            this.ucDataUpDownBtnCtrl2.buttonClick += UcDataUpDownBtnCtrl2_buttonClick;
        }

        #region Grid Event

        #region 재공 Grid 더블클릭

        /// <summary>
        /// 재공 Grid 더블클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_DoubleClick(object sender, EventArgs e)
        {
            CommonFunction.SetGridDoubleClickCheck(grdTargetMergeConsumableLot, sender);
        }

        #endregion

        #region 재공 Row Stype Event

        /// <summary>
        /// 재공 Row Stype Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdTargetMergeConsumableLot_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            CommonFunction.SetGridRowStyle(grdTargetMergeConsumableLot, e);
        }

        #endregion

        #region 재공 Grid Check Event

        /// <summary>
        /// 재공 Grid Check Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdTargetMergeConsumableLot_CheckStateChanged(object sender, EventArgs e)
        {
            GridCheckMarksSelection view = (GridCheckMarksSelection)sender;

            DataTable dt = grdTargetMergeConsumableLot.View.GetCheckedRows();

            // 자재 ID 체크
            int consumableCount = dt.AsEnumerable().Select(r => r.Field<string>("CONSUMABLEDEFID")).Distinct().Count();

            if (consumableCount > 1)
            {
                grdTargetMergeConsumableLot.View.CheckRow(grdTargetMergeConsumableLot.View.GetFocusedDataSourceRowIndex(), false);

                // 다른 자재는 선택할 수 없습니다.
                throw MessageException.Create("NoMixSelectConsumable");
            }
        }

        #endregion

        #region Target Grid Row Stype Event

        /// <summary>
        /// Target Grid Row Stype Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Target_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            CommonFunction.SetGridRowStyle(grdSelectTargetMergeConsumableLot, e);
        }

        #endregion

        #region Merge Grid CellValueChange Event

        /// <summary>
        /// 병합하려는 병합 자재 Lot의 총 수량이 기존 자재Lot의 수량을 넘지않게 체크
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            DataTable tdt = grdSelectTargetMergeConsumableLot.DataSource as DataTable;
            DataRow sRow = grdMergeConsumableLot.View.GetFocusedDataRow();

            _consumableLotId = Format.GetString(tdt.Rows[0]["CONSUMABLELOTID"]);

            if (e.Column.FieldName.Equals("MERGEQTY"))
            {
                if (Format.GetInteger(sRow["CONSUMABLELOTQTY"]) < Format.GetInteger(e.Value))
                {
                    this.ShowMessage("MergeQtyExceededTheTotalQtY"); // 병합수량이 전체수량을 초과하였습니다.
                    grdMergeConsumableLot.View.SetRowCellValue(e.RowHandle, "MERGEQTY", null); // 수량 초기화
                }
            }
        }

        #endregion

        #endregion

        #region Up / Down User Control Button Click Event - TargetData

        /// <summary>
        /// Up / Down User Control Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcDataUpDownBtnCtrl_buttonClick(object sender, EventArgs e)
        {
            if (this.ucDataUpDownBtnCtrl.ButtonState.Equals("Down"))
            {
                DataTable dt = grdTargetMergeConsumableLot.View.GetCheckedRows();
                DataTable tdt = grdSelectTargetMergeConsumableLot.DataSource as DataTable;

                if (dt == null || dt.Rows.Count > 1 || tdt.Rows.Count > 0)
                {
                    // 기준 자재 Lot은 하나이상 선택하실 수 없습니다.
                    throw MessageException.Create("CannotSelect1OverTargetConsumableLot");
                }
            }
        }

        #endregion

        #region Up / Down User Control Button Click Event - SourceData

        /// <summary>
        /// Up / Down User Control Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcDataUpDownBtnCtrl2_buttonClick(object sender, EventArgs e)
        {
            if (this.ucDataUpDownBtnCtrl2.ButtonState.Equals("Down"))
            {
                DataTable dt = grdSelectTargetMergeConsumableLot.DataSource as DataTable;

                if (dt == null || dt.Rows.Count == 0)
                {
                    // 기준 자재 Lot을 먼저 선택하여 주십시오.
                    throw MessageException.Create("NeedTargetConsumableLot"); 
                }

                DataTable tdt = grdTargetMergeConsumableLot.View.GetCheckedRows();

                if (tdt == null || tdt.Rows.Count <= 0) return;

                // 자재 Id 체크
                string consumableDefId = dt.AsEnumerable().Select(r => r.Field<string>("CONSUMABLEDEFID")).Distinct().FirstOrDefault().ToString();
                string tgConsumableDefId = tdt.AsEnumerable().Select(r => r.Field<string>("CONSUMABLEDEFID")).Distinct().FirstOrDefault().ToString();

                if (!consumableDefId.Equals(tgConsumableDefId))
                {
                    grdTargetMergeConsumableLot.View.CheckRow(grdTargetMergeConsumableLot.View.GetFocusedDataSourceRowIndex(), false);

                    // 다른 자재는 선택할 수 없습니다.
                    throw MessageException.Create("NoMixSelectConsumable");
                }
            }
        }

        #endregion

        #endregion

        #region 툴바

        /// <summary>
        /// 저장버튼 클릭
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();
        }

        /// <summary>
        /// 툴바버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            SmartButton btn = sender as SmartButton;

            // 병합버튼 클릭
            if (btn.Name.ToString().Equals("Merge"))
            {
                SaveRule();
            }
        }

        #endregion

        #region 검색

        /// <summary>
        /// 비동기 override 모델
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            // 기존 Grid Data 초기화
            ClearControl();

            var values = Conditions.GetValues();
            values.Add("P_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dt = await SqlExecuter.QueryAsync("SelectSplitonsumableLotList", "00001", values);

            if (dt.Rows.Count < 1)
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }

            grdTargetMergeConsumableLot.DataSource = dt;
            grdTargetMergeConsumableLot.View.FocusedRowHandle = -1;
        }

        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터 저장할때 컨텐츠 영역의 유효성 검사
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();
        }

        #endregion

        #region Private Function

        /// <summary>
        /// 병합 Save Rule
        /// </summary>
        private void SaveRule()
        {
            if (grdSelectTargetMergeConsumableLot.DataSource == null || grdMergeConsumableLot.DataSource == null)
            {
                // 저장할 데이터가 존재하지 않습니다.
                this.ShowMessage("NoSaveData");
                return;
            }

            grdMergeConsumableLot.View.CloseEditor();
            grdMergeConsumableLot.View.CheckValidation();

            DataTable mergeDt = grdMergeConsumableLot.DataSource as DataTable;

            // 총 병합 수량
            double totalMergeQty = Format.GetDouble((grdSelectTargetMergeConsumableLot.DataSource as DataTable).Rows[0]["CONSUMABLELOTQTY"], 0);

            foreach (DataRow row in mergeDt.Rows)
            {
                totalMergeQty += Format.GetDouble(row["MERGEQTY"], 0);
            }
                
            try
            {
                this.ShowWaitArea();

                MessageWorker messageWorker = new MessageWorker("SaveConsumableLotMerge");

                messageWorker.SetBody(new MessageBody()
                {
                    { "mergeConsumableLotlist", mergeDt },
                    { "consumableLotId", _consumableLotId },
                    { "totalMergeQty", totalMergeQty }
                });

                messageWorker.Execute();

                this.ShowMessage("SuccessSave");
                SearchMainGrid(); // 재조회 
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.CloseWaitArea();
            }
        }

        /// <summary>
        /// 메인그리드 조회
        /// </summary>
        private async void SearchMainGrid()
        {
            await OnSearchAsync();
        }

        /// <summary>
        /// Control Data 초기화
        /// </summary>
        private void ClearControl()
        {
            // Data 초기화
            this.grdTargetMergeConsumableLot.View.ClearDatas();
            this.grdSelectTargetMergeConsumableLot.View.ClearDatas();
            this.grdMergeConsumableLot.View.ClearDatas();
        }

        #endregion
    }
}

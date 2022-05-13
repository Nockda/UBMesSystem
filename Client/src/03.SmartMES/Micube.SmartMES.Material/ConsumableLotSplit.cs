#region using
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.SmartMES.Commons;
using Micube.Framework.SmartControls.Grid.BandedGrid;
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
    /// 프 로 그 램 명  : 자재관리 > 자재 Lot 관리 > 자재분할
    /// 업  무  설  명  : 한개의 자재 Lot을 여러개의 자재 Lot으로 분할한다.
    /// 생    성    자  : 유태근
    /// 생    성    일  : 2020-06-09
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class ConsumableLotSplit : SmartConditionBaseForm
    {
        #region Local Variables

        private string _consumableLotId = ""; // 분할대상 자재 Lot No
        private int _qty = 0; // 자식 자재 Lot의 분할 총 수량

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        public ConsumableLotSplit()
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

            UseAutoWaitArea = false;

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

        #region Grid 설정

        /// <summary>        
        /// 그리드 초기화
        /// </summary>
        private void InitializeGrid()
        {
            #region 재공 Grid 설정

            grdTargetSplitConsumableLot.GridButtonItem = GridButtonItem.None;

            grdTargetSplitConsumableLot.View.SetIsReadOnly();
            grdTargetSplitConsumableLot.View.SetAutoFillColumn("CONSUMABLEDEFNAME");

            // 자재 Lot Id
            grdTargetSplitConsumableLot.View.AddTextBoxColumn("CONSUMABLELOTID", 150);
            // 창고 Id
            grdTargetSplitConsumableLot.View.AddTextBoxColumn("WAREHOUSEID", 100)
                .SetIsHidden();
            // 창고명
            grdTargetSplitConsumableLot.View.AddTextBoxColumn("WAREHOUSENAME", 150);
            // 작업장 Id
            grdTargetSplitConsumableLot.View.AddTextBoxColumn("AREAID", 100)
                .SetIsHidden();
            // 작업장명
            grdTargetSplitConsumableLot.View.AddTextBoxColumn("AREANAME", 150);
            // 위치 Id
            grdTargetSplitConsumableLot.View.AddTextBoxColumn("LOCATIONID", 120)
                .SetTextAlignment(TextAlignment.Center);
            // 품번
            grdTargetSplitConsumableLot.View.AddTextBoxColumn("PARTNUMBER", 150);
            // 자재 Id
            grdTargetSplitConsumableLot.View.AddTextBoxColumn("CONSUMABLEDEFID", 150).SetIsHidden();
            // 자재 Version
            grdTargetSplitConsumableLot.View.AddTextBoxColumn("CONSUMABLEDEFVERSION", 80)
                .SetTextAlignment(TextAlignment.Center).SetIsHidden();
            // 자재명
            grdTargetSplitConsumableLot.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 220);
            // 자재생성수량
            grdTargetSplitConsumableLot.View.AddTextBoxColumn("CREATEDQTY", 80)
                .SetTextAlignment(TextAlignment.Right);
            // 자재량
            grdTargetSplitConsumableLot.View.AddTextBoxColumn("CONSUMABLELOTQTY", 80)
                .SetTextAlignment(TextAlignment.Right);
            // 자재상태
            grdTargetSplitConsumableLot.View.AddTextBoxColumn("STATE", 100)
                .SetTextAlignment(TextAlignment.Center);

            grdTargetSplitConsumableLot.View.PopulateColumns();

            grdTargetSplitConsumableLot.View.OptionsNavigation.AutoMoveRowFocus = false;

            #endregion

            #region Target Grid

            grdSplitConsumableLot.GridButtonItem = GridButtonItem.Add | GridButtonItem.Delete;

            // CheckBox 설정
            this.grdSplitConsumableLot.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            // 분할 Sequence
            grdSplitConsumableLot.View.AddTextBoxColumn("SPLITSEQUENCE", 100)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            // 분할 수량
            grdSplitConsumableLot.View.AddSpinEditColumn("SPLITQTY", 80)
                .SetTextAlignment(TextAlignment.Right)
                .SetDisplayFormat("{0:#,###}")
                .SetValidationIsRequired()
                .MinValue = 1;
            // 비고
            grdSplitConsumableLot.View.AddTextBoxColumn("DESCRIPTION", 300);

            grdSplitConsumableLot.View.PopulateColumns();

            grdSplitConsumableLot.View.OptionsNavigation.AutoMoveRowFocus = false;

            #endregion
        }
        #endregion

        #region 화면 Control 설정

        /// <summary>
        /// 화면 Control 설정
        /// </summary>
        private void InitializeControls()
        {
            grdTargetSplitConsumableLot.Height = 450;
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
            grdTargetSplitConsumableLot.View.RowStyle += WIP_RowStyle;
            grdTargetSplitConsumableLot.View.FocusedRowChanged += View_FocusedRowChanged;

            // Sub Grid Event
            grdSplitConsumableLot.View.AddingNewRow += View_AddingNewRow;
            grdSplitConsumableLot.View.CellValueChanged += View_CellValueChanged;
        }

        #region - 재공 Row Style Event

        /// <summary>
        /// 재공 Row Stype Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WIP_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            int rowIndex = grdTargetSplitConsumableLot.View.FocusedRowHandle;

            if (rowIndex == e.RowHandle)
            {
                e.Appearance.BackColor = Color.FromArgb(254, 254, 16);
                e.HighPriority = true;
            }
        }
        #endregion

        #region - Split Grid AddRow

        /// <summary>
        /// Split Grid AddRow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void View_AddingNewRow(SmartBandedGridView sender, AddNewRowArgs args)
        {
            string prefixStr = "Split-";
            string serialStr = "";

            if ((grdSplitConsumableLot.DataSource as DataTable).Rows.Count == 1)
            {
                grdSplitConsumableLot.View.SetFocusedRowCellValue("SPLITSEQUENCE", prefixStr + "1");
            }
            else
            {
                int maxSequence = Format.GetInteger(Format.GetString(grdSplitConsumableLot.View.GetRowCellValue(grdSplitConsumableLot.View.FocusedRowHandle - 1, "SPLITSEQUENCE")).Split('-')[1]);
                serialStr = Format.GetString(maxSequence + 1);
                grdSplitConsumableLot.View.SetFocusedRowCellValue("SPLITSEQUENCE", prefixStr + serialStr);
            }
        }

        #endregion

        #region - 재공 분할 대상 Lot No, 갯수 저장

        /// <summary>
        /// Focus가 변할때마다 분할 대상 Lot의 총 갯수 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            grdSplitConsumableLot.View.ClearDatas();
            _consumableLotId = Format.GetString(grdTargetSplitConsumableLot.View.GetRowCellValue(e.FocusedRowHandle, "CONSUMABLELOTID"));
            _qty = Format.GetInteger(grdTargetSplitConsumableLot.View.GetRowCellValue(e.FocusedRowHandle, "CONSUMABLELOTQTY"));
        }

        #endregion

        #region - Split Grid CellValueChange Event

        /// <summary>
        /// 분할하려는 분할 자재 Lot의 총 수량이 기존 자재Lot의 수량을 넘지않게 체크
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            DataTable sumDt = grdSplitConsumableLot.DataSource as DataTable;
            int sumSplitQty = 0;

            foreach (DataRow row in sumDt.Rows)
            {
                sumSplitQty += Format.GetInteger(row["SPLITQTY"]);
            }

            if (_qty < sumSplitQty)
            {
                this.ShowMessage("SplitQtyExceededTheTotalQtY"); // 분할수량이 전체수량을 초과하였습니다.
                grdSplitConsumableLot.View.SetRowCellValue(e.RowHandle, "SPLITQTY", null); // 수량 초기화
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

            // 분할버튼 클릭
            if (btn.Name.ToString().Equals("Split"))
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

            grdTargetSplitConsumableLot.DataSource = dt;

            _consumableLotId = Format.GetString(grdTargetSplitConsumableLot.View.GetFocusedRowCellValue("CONSUMABLELOTID"));
            _qty = Format.GetInteger(grdTargetSplitConsumableLot.View.GetFocusedRowCellValue("CONSUMABLELOTQTY"));
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
        /// 분할 Save Rule
        /// </summary>
        private void SaveRule()
        {
            if (grdSplitConsumableLot.DataSource == null)
            {
                // 저장할 데이터가 존재하지 않습니다.
                this.ShowMessage("NoSaveData");
                return;
            }

            grdSplitConsumableLot.View.CloseEditor();
            grdSplitConsumableLot.View.CheckValidation();

            DataTable splitDt = grdSplitConsumableLot.GetChangedRows();

            // 분할전 수량
            double beforeQty = Format.GetDouble(grdTargetSplitConsumableLot.View.GetFocusedRowCellValue("CONSUMABLELOTQTY"), 0);
            // 총 분할 수량
            double totalSplitQty = 0;

            foreach (DataRow row in splitDt.Rows)
            {
                totalSplitQty += Format.GetDouble(row["SPLITQTY"], 0);
            }

            try
            {
                this.ShowWaitArea();

                MessageWorker messageWorker = new MessageWorker("SaveConsumableLotSplit");

                messageWorker.SetBody(new MessageBody()
                {
                    { "SplitConsumableLotlist", splitDt },
                    { "consumableLotId", _consumableLotId },
                    { "totalSplitQty", totalSplitQty },
                    { "beforeQty", beforeQty }
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
            this.grdTargetSplitConsumableLot.DataSource = null;
            this.grdSplitConsumableLot.DataSource = null;
        }

        #endregion
    }
}

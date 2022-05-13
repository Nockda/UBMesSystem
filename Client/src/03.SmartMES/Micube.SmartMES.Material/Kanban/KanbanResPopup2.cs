
#region using

using DevExpress.CodeParser;
using DevExpress.Utils.DirectXPaint;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;
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

namespace Micube.SmartMES.Material.Kanban
{
    /// <summary>
    /// 프 로 그 램 명  : 자재관리 > 간반요청출고관리 > 처리완료(팝업)
    /// 업  무  설  명  : 재고준비가 된 요청건 LOT투입
    /// 생    성    자  : jylee
    /// 생    성    일  : 2020-06-18
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class KanbanResPopup2 : SmartPopupBaseForm
    {
        DataTable selectedRows;
        string createdNewLotId = null;

        #region 컨텐츠 영역 초기화
        /// <summary>
        /// 화면의 컨텐츠 영역을 초기화한다.
        /// </summary>
        public KanbanResPopup2(DataTable selectedRows)
        {
            this.selectedRows = selectedRows;
            InitializeComponent();
            InitializeEvent();
            InitializeReadyGrid();
            InitializeLotGrid();
            InitializeLoad();
        }

        private void InitializeReadyGrid()
        {
            grdReady.GridButtonItem = GridButtonItem.None;
            grdReady.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdReady.ShowStatusBar = false;
            grdReady.View.SetSortOrder("ITEMID");
            //grdReady.View.SetIsReadOnly();

            
            //요청번호
            grdReady.View.AddTextBoxColumn("REQCODE", 120)
                     .SetTextAlignment(TextAlignment.Center)
                     .SetIsReadOnly();
            
            //요청일자
            grdReady.View.AddTextBoxColumn("REQDATE", 100)
                    .SetIsReadOnly()
                    .SetDisplayFormat("yyyy-MM-dd")
                    .SetTextAlignment(TextAlignment.Center)
                    .SetIsReadOnly();
           
            //간반코드
            grdReady.View.AddTextBoxColumn("CELLID", 100)
                    .SetTextAlignment(TextAlignment.Center)
                    .SetLabel("KANBANID")
                    .SetIsReadOnly();
            
            //간반명
            grdReady.View.AddTextBoxColumn("CELLNAME", 100)
                    .SetLabel("KANBANNAME")
                    .SetIsReadOnly();
            
            //자재코드
            ChangeMaterialPopup();
            //grdReady.View.AddTextBoxColumn("CONSUMABLEDEFID", 120);
            
            //자재명
            grdReady.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 250)
                      .SetIsReadOnly();
            
            //자재타입(Hidden)
            grdReady.View.AddTextBoxColumn("CONSUMABLETYPE", 100)
                      .SetIsReadOnly()
                      .SetIsHidden();
           
            //요청수량
            grdReady.View.AddTextBoxColumn("CONSUMABLELOTQTY", 80)
                    .SetLabel("REQUESTQTY")
                    .SetIsReadOnly();
            
            //출고수량
            grdReady.View.AddTextBoxColumn("LOTQTY", 80)
                .SetLabel("OUTQTY")
                .SetDefault("0")
                .SetIsReadOnly();
            
            //단위
            grdReady.View.AddTextBoxColumn("UNIT", 50)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
           
            //요청창고ID(HIDDEN)
            grdReady.View.AddTextBoxColumn("TOWAREHOUSEID", 50)
                .SetIsHidden();
            
            //요청창고 (TO창고)
            grdReady.View.AddTextBoxColumn("TOWAREHOUSENAME", 120)
                .SetLabel("REQUESTWAREHOUSENAME");
           
            //창고ID(HIDDEN)
            grdReady.View.AddTextBoxColumn("FROMWAREHOUSEID", 50)
                .SetIsHidden();

            //창고 (FROM창고)
            grdReady.View.AddTextBoxColumn("FROMWAREHOUSENAME", 120)
                .SetLabel("FROMWAREHOUSEID");

            //위치
            grdReady.View.AddTextBoxColumn("LOCATION", 70)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();

            grdReady.View.PopulateColumns();
        }

        private void InitializeLotGrid()
        {
            grdLot.GridButtonItem = GridButtonItem.None;

            grdLot.View.SetIsReadOnly();

            //요청번호(Hidden)
            grdLot.View.AddTextBoxColumn("REQCODE", 100)
                    .SetIsHidden();

            //요청수량(Hidden)
            grdLot.View.AddTextBoxColumn("QTY", 100)
                    .SetIsHidden();

            //선택된 Lot Total(Hidden)
            grdLot.View.AddTextBoxColumn("LOTQTY", 100)
                    .SetIsHidden();


            //요청창고ID(Hidden)
            grdLot.View.AddTextBoxColumn("TOWAREHOUSEID", 100)
                    .SetIsHidden();

            //출고창고ID(Hidden)
            grdLot.View.AddTextBoxColumn("FROMWAREHOUSEID", 100)
                    .SetIsHidden();

            //간반ID(Hidden)
            grdLot.View.AddTextBoxColumn("CELLID", 100)
                    .SetIsHidden();

            //자재타입(Hidden)
            grdLot.View.AddTextBoxColumn("CONSUMABLETYPE", 100)
                   .SetIsHidden();

            //자재LOT
            grdLot.View.AddTextBoxColumn("CONSUMABLELOTID", 150);
            //자재코드
            grdLot.View.AddTextBoxColumn("CONSUMABLEDEFID", 150).SetIsHidden();

            grdLot.View.AddTextBoxColumn("PARTNUMBER", 150);

            //자재명
            grdLot.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 250);
            //규격
            grdLot.View.AddTextBoxColumn("STANDARD", 150);
            //수량
            grdLot.View.AddTextBoxColumn("CONSUMABLELOTQTY", 80);
            //단위
            grdLot.View.AddTextBoxColumn("UNITNAME", 80)
                    .SetTextAlignment(TextAlignment.Center)
                    .SetLabel("UNIT");

            grdLot.View.PopulateColumns();
        }

        #endregion

        #region Event
        private void InitializeEvent()
        {
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;
            this.lblLotNo.Editor.KeyDown += Editor_KeyDown;
        }

/*        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            DataRow currentRow = grdReady.View.GetFocusedDataRow();
            string masterId = currentRow["QTY"].ToString();
            string masterName = currentRow["QTY"].ToString();
            args.NewRow["QTY"] = masterId;
            args.NewRow["QTY"] = masterName;

        }*/

         //자재LOT 바코드 스캔
        private void Editor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            string conLotId = this.lblLotNo.Editor.Text.Trim();
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_CONSUMABLELOTID", conLotId);
            DataTable dtResult = SqlExecuter.Query("GetResMaterialLot", "00001", param);

            if (dtResult.Rows.Count < 1)
            {
                ShowMessage("LotNotSelected");
                return;
            }
            else
            {
                DataTable dtReady = grdReady.DataSource as DataTable;
                DataTable dtLot = grdLot.DataSource as DataTable;

                //자재LOT 유효성검사
                ValidationLotId(conLotId, dtLot);

                DataRow readyRow = FindRequestRow(dtResult.Rows[0]["CONSUMABLEDEFID"].ToString()
                    , (decimal)dtResult.Rows[0]["CONSUMABLELOTQTY"]);
                if (readyRow != null)
                {
                    DataRow newRow = dtLot.NewRow();

                    readyRow["LOTQTY"] = (decimal)readyRow["LOTQTY"] + (decimal)dtResult.Rows[0]["CONSUMABLELOTQTY"];

                    newRow["CONSUMABLELOTID"] = dtResult.Rows[0]["CONSUMABLELOTID"];
                    newRow["CONSUMABLEDEFID"] = dtResult.Rows[0]["CONSUMABLEDEFID"];
                    newRow["PARTNUMBER"] = dtResult.Rows[0]["PARTNUMBER"];
                    newRow["CONSUMABLEDEFNAME"] = dtResult.Rows[0]["CONSUMABLEDEFNAME"];
                    newRow["STANDARD"] = dtResult.Rows[0]["STANDARD"];
                    newRow["CONSUMABLELOTQTY"] = dtResult.Rows[0]["CONSUMABLELOTQTY"];
                    newRow["UNITNAME"] = dtResult.Rows[0]["UNITNAME"];
                    newRow["QTY"] = readyRow["CONSUMABLELOTQTY"].ToString();
                    newRow["TOWAREHOUSEID"] = readyRow["TOWAREHOUSEID"].ToString();
                    newRow["REQCODE"] = readyRow["REQCODE"].ToString();
                    newRow["FROMWAREHOUSEID"] = readyRow["FROMWAREHOUSEID"].ToString();
                    newRow["CELLID"] = readyRow["CELLID"].ToString();
                    newRow["CONSUMABLETYPE"] = readyRow["CONSUMABLETYPE"].ToString();
                    newRow["LOTQTY"] = readyRow["LOTQTY"].ToString();

                    dtLot.Rows.Add(newRow);

                }
            }
        }

        //요청수량 LOT투입수량 체크
        private DataRow FindRequestRow(string consumableDefId, decimal qty)
        {
            bool checkdeQty = true;
            foreach(DataRow each in (grdReady.DataSource as DataTable).Rows)
            {
                if(each["CONSUMABLEDEFID"].ToString() == consumableDefId)
                {
                    if ((decimal)each["CONSUMABLELOTQTY"]>(decimal)each["LOTQTY"])
                    {
                        return each;
                    }
                    else if((decimal)each["CONSUMABLELOTQTY"] <= (decimal)each["LOTQTY"])
                    {
                        checkdeQty = false;
                    }
                }
            }

            if (!checkdeQty)
            {
                //요청수량을 초과하였습니다.
                throw MessageException.Create("OverRequestQty");
            }
            return null;
        }

        //자재변경 팝업
        private void ChangeMaterialPopup()
        {
            var popupColumn = grdReady.View.AddSelectPopupColumn("PARTNUMBER", 150, new SqlQuery("selectChangeWarehouse", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("SELECTUSER", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
/*              .SetPopupResultMapping("WAREHOUSEID", "TOWAREHOUSEID")
                .SetPopupResultMapping("WAREHOUSENAME", "TOWAREHOUSENAME")*/
                .SetPopupLayoutForm(800, 800, FormBorderStyle.FixedToolWindow)
              .SetPopupApplySelection((selectedRows, dataGridRow) =>
              {
                DataRow classRow = grdReady.View.GetFocusedDataRow();

                   foreach (DataRow row in selectedRows)
                   {
                        classRow["CONSUMABLEDEFID"] = row["CONSUMABLEDEFID"];
                        classRow["PARTNUMBER"] = row["PARTNUMBER"];
                        classRow["CONSUMABLEDEFNAME"] = row["CONSUMABLEDEFNAME"];
                        classRow["FROMWAREHOUSEID"] = row["WAREHOUSEID"];
                        classRow["FROMWAREHOUSENAME"] = row["WAREHOUSENAME"];
                  }
            });
            popupColumn.GridColumns.AddTextBoxColumn("CONSUMABLEDEFID", 120).SetIsHidden();
            popupColumn.GridColumns.AddTextBoxColumn("PARTNUMBER", 150);
            popupColumn.GridColumns.AddTextBoxColumn("CONSUMABLEDEFNAME", 150);
            popupColumn.GridColumns.AddTextBoxColumn("CELLID", 80);
            popupColumn.GridColumns.AddTextBoxColumn("CELLNAME", 80);
            popupColumn.GridColumns.AddTextBoxColumn("WAREHOUSEID", 100).SetIsHidden();
            popupColumn.GridColumns.AddTextBoxColumn("WAREHOUSENAME", 100);

            popupColumn.Conditions.AddTextBox("P_CONSUMABLEDEFID").SetLabel("PARTNUMBER");
        }

        //저장버튼 클릭
        private void BtnSave_Click(object sender, EventArgs e)
        {
            DataTable dtMaster = grdReady.DataSource as DataTable;
            DataTable dtLot = grdLot.DataSource as DataTable;

            //요청수량 확인
            //checkedRequestQty(dtMaster);

            MessageWorker messageWorker = new MessageWorker("SaveKanbanRequest");
            messageWorker.SetBody(new MessageBody()
            {
                {"GRIDREQ", dtMaster},
                {"GRIDLOT", dtLot }
            });

            var saveResult = messageWorker.Execute<DataTable>();
            DataTable resultTable = saveResult.GetResultSet();

           // DataTable resultTable = ExecuteRule<DataTable>("SplitLotAndLabel", param); //Lot 이동 및 분할
                   
            if (resultTable.Rows.Count > 0)
            {   
                if (MSGBox.Show(MessageBoxType.Question, "SplitLotPrintLabel", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataRow resultRow in resultTable.Rows)
                    {
                        createdNewLotId = resultRow["LOTID"].ToString();
                        CommonFunction.PrintMaterialLabel(createdNewLotId);
                    }
                }
            };

            MessageWorker msgWorker = new MessageWorker("SaveKanbanState");
            msgWorker.SetBody(new MessageBody()
            {
                {"GRIDREQ", dtMaster},
            });
            msgWorker.Execute();

            //처리가 완료되었습니다.
            MSGBox.Show(MessageBoxType.Information, "RequestCompletion", MessageBoxButtons.OK, DialogResult.OK);
            this.Close();
            
        }

        //닫기버튼 클릭
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //보세품목(---(B)) 경우, 출고창고 변경
        private void LoadCheckWarehouse() 
        {
            DataTable dt = grdReady.DataSource as DataTable;

            foreach(DataRow row in dt.Rows)
            {
                String splitDefId = row["PARTNUMBER"].ToString();
                splitDefId = splitDefId.Substring(splitDefId.Length -3, 3);

                if(splitDefId == "(B)")
                {
                    row["FROMWAREHOUSEID"] = 280;
                    row["FROMWAREHOUSENAME"] = "자재창고(B)";
                }

            }
        }

        #endregion

        #region 유효성 검사

        //자재LOT중복체크
        private void insertedMaterialLot(string conLotId, DataTable dtLot)
        {
            foreach (DataRow row in dtLot.Rows)
            {
                if (conLotId == row["CONSUMABLELOTID"].ToString())
                {
                    //LOT번호가 중복됩니다.
                    throw MessageException.Create("OverlapLotId");
                }
            }
        }

        //자재LOT체크
        private void checkedRequestMaterialLot(DataTable dtConsumableLot)
        {
            if (dtConsumableLot.Rows.Count < 1)
            {
                //자재LOT을 확인해주세요
                throw MessageException.Create("CheckMaterialLot");
            }
        }

        //유효성체크
        private void ValidationLotId(string conLotId, DataTable dtLot)
        {
            //자재LOT중복체크
            insertedMaterialLot(conLotId, dtLot);

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("CONSUMABLELOTID", conLotId);

            DataTable dtConsumableLot = SqlExecuter.Query("GetConsumableLotList", "00003", param);

            Boolean result = false;
            foreach (DataRow row in (grdReady.DataSource as DataTable).Rows)
            {
                //요청자재LOT체크
                checkedRequestMaterialLot(dtConsumableLot);
                string consumableDefId = dtConsumableLot.Rows[0]["CONSUMABLEDEFID"].ToString();
                string conwWarehouseId = dtConsumableLot.Rows[0]["WAREHOUSEID"].ToString();

                if ((consumableDefId == row["CONSUMABLEDEFID"].ToString()) && (conwWarehouseId == row["FROMWAREHOUSEID"].ToString()))
                {
                    result = true;
                    this.lblLotNo.Editor.EditValue = null;
                    this.lblLotNo.Editor.Text = "";
                }
            }
            if (!result)
            {
                //요청 자재가 아닙니다.
                throw MessageException.Create("NotRequestMaterial");
            }
        }

        //저장버튼 => 요청수량 확인(사용X)
        private void checkedRequestQty(DataTable dtMaster)
        {
            foreach (DataRow row in dtMaster.Rows)
            {
                if ((decimal)row["LOTQTY"] < (decimal)row["CONSUMABLELOTQTY"])
                {
                    //요청 수량을 확인해 주세요.
                    throw MessageException.Create("CheckRequestQty");
                }
            }
        }

        #endregion

        #region Load
        //FormLoad
        private void InitializeLoad()
        {
            this.Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            grdReady.DataSource = selectedRows;
            this.ActiveControl = this.lblLotNo;
            LoadCheckWarehouse();
        }

        #endregion
    }
}

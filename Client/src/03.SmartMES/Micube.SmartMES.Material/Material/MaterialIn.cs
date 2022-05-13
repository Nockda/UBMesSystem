#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using Micube.SmartMES.Commons;

#endregion

namespace Micube.SmartMES.Material
{
    /// <summary>
    /// 프 로 그 램 명  : 자재관리 > 자재 > 자재 입고 처리
    /// 업  무  설  명  : 자재입고 정보를 등록 및 처리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2020-04-20
    /// 수  정  이  력  : 2020-07-30 | JYLEE | 셀ID 선택팝업 검색조건 추가 
    /// 
    /// 
    /// </summary>
    public partial class MaterialIn : SmartConditionBaseForm
    {
        public MaterialIn()
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

            this.smartSpliterContainer2.SplitterPosition = 1200;

            // 컨트롤 초기화 로직 구성
            InitializeMaster();
            InitializeItem();
            InitializeLot();

            btnScan.Hide();
        }

        /// <summary>        
        /// 마스터 그리드를 초기화한다.
        /// </summary>
        private void InitializeMaster()
        {
            // 그리드 초기화
            grdMaster.GridButtonItem = GridButtonItem.Export;
            grdMaster.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdMaster.View.OptionsView.AllowCellMerge = true;

            grdMaster.View.SetSortOrder("DELVSEQ");

            grdMaster.View.AddTextBoxColumn("POSEQ", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("POSERL", 50)
                .SetIsHidden();
            grdMaster.View.AddDateEditColumn("PODATE", 80)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd")
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("PONO", 110)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("CUSTSEQ", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("CUSTNAME", 100)
                .SetLabel("VENDOR")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("DEPTSEQ", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("DEPTNAME", 100)
                .SetLabel("DEPARTMENT")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("EMPSEQ", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("EMPNAME", 60)
                .SetLabel("CUSTOMERMANAGER")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("DELVDATE",80)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd")
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("DELVSEQ")
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("DELVNO", 100)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("DELVSERL", 70)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("ITEMSEQ", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("ITEMNO", 120)
                .SetLabel("CONSUMABLEDEFID")
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            grdMaster.View.AddTextBoxColumn("ITEMNAME", 180)
                .SetLabel("CONSUMABLEDEFNAME")
                .SetIsReadOnly();
            grdMaster.View.AddSpinEditColumn("DELVQTY", 80)
                .SetDisplayFormat("#,##0.##")
                .SetIsReadOnly();
            grdMaster.View.AddSpinEditColumn("OKQTY", 80)
                .SetDisplayFormat("#,##0.##")
                .SetIsReadOnly();
            grdMaster.View.AddSpinEditColumn("BADQTY", 80)
                .SetDisplayFormat("#,##0.##")
                .SetIsReadOnly();
            grdMaster.View.AddSpinEditColumn("DELVINQTY", 80)
                .SetDisplayFormat("#,##0.##")
                .SetIsReadOnly();
            grdMaster.View.AddSpinEditColumn("RETURNQTY", 80)
                .SetDisplayFormat("#,##0.##")
                .SetIsReadOnly();
            grdMaster.View.AddTextBoxColumn("UNITSEQ", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("UNITNAME", 50)
                .SetLabel("UNIT")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("WHSEQ", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("WAREHOUSENAME", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddSpinEditColumn("LOTSIZE", 80)
                .SetValidationIsRequired();
            grdMaster.View.AddTextBoxColumn("REMARK", 150)
                .SetIsReadOnly();
            grdMaster.View.AddTextBoxColumn("PROGTYPE", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("STATUS", 80)
                .SetLabel("INSTATE")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("SCMYN", 50)
                .SetIsReadOnly()
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("ISINQC", 50)
                .SetIsReadOnly()
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("COMPLETEYN", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("TOSSYN", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("ERP_EMPNO", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("ORDERSEQ", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetTextAlignment(TextAlignment.Center)
                .SetIsHidden();

            grdMaster.View.PopulateColumns();
        }

        /// <summary>        
        /// 아이템 그리드를 초기화한다.
        /// </summary>
        private void InitializeItem()
        {
            // 그리드 초기화
            grdItem.GridButtonItem = GridButtonItem.None;
            grdItem.View.OptionsView.AllowCellMerge = true;
            grdItem.View.SetIsReadOnly();

            grdItem.View.SetSortOrder("SEQ");
            grdItem.View.SetAutoFillColumn("ITEMNAME");

            grdItem.View.AddTextBoxColumn("SEQ", 50)
                .SetIsHidden();
            grdItem.View.AddTextBoxColumn("POSEQ", 50)
                .SetIsHidden();
            grdItem.View.AddTextBoxColumn("POSERL", 50)
                .SetIsHidden();
            grdItem.View.AddTextBoxColumn("PONO", 120)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            grdItem.View.AddTextBoxColumn("DELVDATE", 100)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            grdItem.View.AddTextBoxColumn("DELVSEQ", 50)
                .SetIsHidden();
            grdItem.View.AddTextBoxColumn("DELVSERL", 50)
                .SetIsHidden();
            grdItem.View.AddTextBoxColumn("DELVNO", 100)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            grdItem.View.AddTextBoxColumn("ITEMSEQ", 50)
                .SetIsHidden();
            grdItem.View.AddTextBoxColumn("ITEMNO", 120)
                .SetLabel("CONSUMABLEDEFID")
                .SetIsReadOnly();
            grdItem.View.AddTextBoxColumn("ITEMNAME", 150)
                .SetIsReadOnly();
            grdItem.View.AddComboBoxColumn("WHSEQ", 150, new SqlQuery("GetComboWarehouse", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("WAREHOUSENAME")
                .SetTextAlignment(TextAlignment.Center);
            grdItem.View.AddSpinEditColumn("INQTY", 80)
                .SetDefault(0)
                .SetValidationIsRequired();
            grdItem.View.AddSpinEditColumn("LOTSIZE", 80)
                .SetDefault(0)
                .SetValidationIsRequired();
            //grdItem.View.AddTextBoxColumn("DESCRIPTION", 70);
            //grdItem.View.AddComboBoxColumn("COMPLETEYN", 50, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YesNoState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
            //   .SetTextAlignment(TextAlignment.Center)
            //   .SetIsReadOnly();

            grdItem.View.PopulateColumns();
        }

        /// <summary>        
        /// Lot 그리드를 초기화한다.
        /// </summary>
        private void InitializeLot()
        {
            // 그리드 초기화
            grdLot.GridButtonItem = GridButtonItem.None;
            grdLot.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            //grdLot.View.SetIsReadOnly();

            grdLot.View.SetSortOrder("CONSUMABLELOTID");
            grdLot.View.SetAutoFillColumn("CELLNAME");

            grdLot.View.AddTextBoxColumn("CONSUMABLELOTID", 100)
                .SetIsReadOnly();
            grdLot.View.AddTextBoxColumn("WAREHOUSEID", 80)
                .SetIsReadOnly()
                .SetIsHidden();
            SelectLocationPopup();
            grdLot.View.AddTextBoxColumn("CELLNAME", 80)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            grdLot.View.AddTextBoxColumn("CREATEDQTY", 50)
                .SetDisplayFormat("#,##0.##")
                .SetIsReadOnly();

            grdLot.View.PopulateColumns();
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            btnLotCreate.Click += BtnLotCreate_Click;
            btnConfirm.Click += BtnConfirm_Click;
            btnConfirmCancel.Click += BtnConfirmCancel_Click;
            btnScan.Click += BtnScan_Click;
            btnSaveLot.Click += BtnSaveLot;
            btnPrintLabel.Click += BtnPrintLabel_Click;

            grdMaster.View.FocusedRowChanged += MasterView_FocusedRowChanged;

            grdMaster.View.CellMerge += View_CellMerge;
            grdItem.View.CellMerge += View_CellMerge;

            grdMaster.View.RowStyle += MasterView_RowStyle;
        }

        



        /// <summary>
        /// LOT생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLotCreate_Click(object sender, EventArgs e)
        {
            grdMaster.View.CheckValidation();

            try
            {
                this.ShowWaitArea();
                btnLotCreate.Focus();
                btnLotCreate.Enabled = false;

                DataTable selected = grdMaster.View.GetCheckedRows();
                selected.Columns.Add("_STATE_", typeof(string));

                if (selected.Rows.Count < 1)
                {
                    ShowMessage("NoSaveData");
                    return;
                }

                if (!CheckMasterData(selected))
                {
                    throw MessageException.Create("AlreadyMaterialIn");
                    return;
                }

                if(!validationCheckStandardInfo(selected))
                {
                    throw MessageException.Create("EmptyStdInfo");
                    return;
                }

                if(!validationCheckOkQty(selected))
                {
                    throw MessageException.Create("OkQtyIsNotReady");
                    return;
                }

                if (!validationCheckLotSize(selected))
                {
                    throw MessageException.Create("EmptyLotSize");
                    return;
                }

                DataTable newTable = new DataTable();
                newTable.Columns.Add("POSEQ", typeof(int));
                newTable.Columns.Add("POSERL", typeof(int));
                newTable.Columns.Add("PONO", typeof(string));
                newTable.Columns.Add("DELVDATE", typeof(string));
                newTable.Columns.Add("DELVSEQ", typeof(int));
                newTable.Columns.Add("DELVSERL", typeof(int));
                newTable.Columns.Add("DELVNO", typeof(string));
                newTable.Columns.Add("ITEMSEQ", typeof(int));
                newTable.Columns.Add("CONSUMABLEDEFID", typeof(string));
                newTable.Columns.Add("WHSEQ", typeof(int));
                newTable.Columns.Add("INQTY", typeof(int));
                newTable.Columns.Add("LOTSIZE", typeof(int));
                newTable.Columns.Add("CONSUMABLESTATE", typeof(string));
                newTable.Columns.Add("CREATEDQTY", typeof(double));
                newTable.Columns.Add("CONSUMABLELOTQTY", typeof(double));
                newTable.Columns.Add("STATE", typeof(string));
                newTable.Columns.Add("ENTERPRISEID", typeof(string));
                newTable.Columns.Add("PLANTID", typeof(string));
                newTable.Columns.Add("AREAID", typeof(string));
                newTable.Columns.Add("_STATE_", typeof(string));

                for (int rowIndex = 0; rowIndex < selected.Rows.Count; rowIndex++)
                {
                    int iPoSeq = (int)(selected.Rows[rowIndex]["POSEQ"] == DBNull.Value ? 0 : selected.Rows[rowIndex]["POSEQ"]);
                    int iPoSerl = (int)(selected.Rows[rowIndex]["POSERL"] == DBNull.Value ? 0 :selected.Rows[rowIndex]["POSERL"]);
                    string sPoNo = (string)(selected.Rows[rowIndex]["PONO"] == DBNull.Value ? "" : selected.Rows[rowIndex]["PONO"]);
                    string sDelvDate = (string)selected.Rows[rowIndex]["DELVDATE"];
                    int iDelvSeq = (int)selected.Rows[rowIndex]["DELVSEQ"];
                    int iDelvSerl = (int)selected.Rows[rowIndex]["DELVSERL"];
                    string sDelvNo = (string)selected.Rows[rowIndex]["DELVNO"];
                    int iItemSeq = (int)selected.Rows[rowIndex]["ITEMSEQ"];
                    string sItemId = (string)selected.Rows[rowIndex]["ITEMNO"];
                    int iWhSeq = (int)selected.Rows[rowIndex]["WHSEQ"];
                    int iTotal = Convert.ToInt32(selected.Rows[rowIndex]["OKQTY"]);
                    int iLotSize = Convert.ToInt32(selected.Rows[rowIndex]["LOTSIZE"]);

                    DataRow newRow;

                    while (iTotal > 0)
                    {
                        newRow = newTable.NewRow();

                        newRow["POSEQ"] = iPoSeq;
                        newRow["POSERL"] = iPoSerl;
                        newRow["PONO"] = sPoNo;
                        newRow["DELVDATE"] = sDelvDate;
                        newRow["DELVSEQ"] = iDelvSeq;
                        newRow["DELVSERL"] = iDelvSerl;
                        newRow["DELVNO"] = sDelvNo;
                        newRow["ITEMSEQ"] = iItemSeq;
                        newRow["INQTY"] = iTotal;
                        newRow["LOTSIZE"] = iLotSize;
                        newRow["WHSEQ"] = iWhSeq;
                        newRow["CONSUMABLEDEFID"] = iItemSeq.ToString();
                        newRow["CONSUMABLESTATE"] = "InAvailable";
                        newRow["STATE"] = "InMate";
                        newRow["_STATE_"] = "added";
                        newRow["ENTERPRISEID"] = UserInfo.Current.Enterprise;
                        newRow["PLANTID"] = UserInfo.Current.Plant;
                        newRow["AREAID"] = "*";
                        if (iTotal < iLotSize)
                        {
                            newRow["CREATEDQTY"] = iTotal;
                            newRow["CONSUMABLELOTQTY"] = iTotal;
                        }
                        else
                        {
                            newRow["CREATEDQTY"] = iLotSize;
                            newRow["CONSUMABLELOTQTY"] = iLotSize;
                        }
                            

                        newTable.Rows.Add(newRow);

                        iTotal -= iLotSize;
                    }
                }

                ExecuteRule("SaveOrderDetail", selected);

                ExecuteRule("CreateConsumableLot", newTable);

                ShowMessage("SuccessSave");

            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.CloseWaitArea();
                btnLotCreate.Enabled = true;

                OnSearchAsync();
            }
        }

        /// <summary>
        /// ERP I/F 및 입고확정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            grdMaster.View.CheckValidation();

            try
            {
                this.ShowWaitArea();
                btnConfirm.Focus();
                btnConfirm.Enabled = false;

                DataTable selected = grdMaster.View.GetCheckedRows();

                if (!validationCheckMaster(selected))
                    return;

                DataTable newTable = new DataTable();
                //newTable.Columns.Add("CRTDATETIME", typeof(DateTime));
                newTable.Columns.Add("ORDERSEQ", typeof(int));
                newTable.Columns.Add("RECVYN", typeof(string));
                newTable.Columns.Add("DELVSEQ", typeof(int));
                newTable.Columns.Add("DELVSERL", typeof(int));
                newTable.Columns.Add("DELVNO", typeof(string));
                newTable.Columns.Add("INDATE", typeof(string));
                newTable.Columns.Add("ITEMSEQ", typeof(int));
                newTable.Columns.Add("ITEMNO", typeof(string));
                newTable.Columns.Add("DELVQTY", typeof(double));
                newTable.Columns.Add("OKQTY", typeof(double));
                newTable.Columns.Add("BADQTY", typeof(double));
                newTable.Columns.Add("WHSEQ", typeof(int));
                newTable.Columns.Add("EMPSEQ", typeof(int));
                newTable.Columns.Add("_STATE_", typeof(string));

                for (int rowIndex = 0; rowIndex < selected.Rows.Count; rowIndex++)
                {
                    int iOrderSeq = (int)selected.Rows[rowIndex]["ORDERSEQ"];
                    string sRecvYn = "N";
                    int iDelvSeq = (int)selected.Rows[rowIndex]["DELVSEQ"];
                    int iDelvSerl = (int)selected.Rows[rowIndex]["DELVSERL"];
                    string sDelvNo = (string)selected.Rows[rowIndex]["DELVNO"];
                    string sInDate = DateTime.Now.ToString("yyyyMMdd");
                    int iItemSeq = (int)selected.Rows[rowIndex]["ITEMSEQ"];
                    string sItemId = (string)selected.Rows[rowIndex]["ITEMNO"];
                    double dDelvQty = Convert.ToDouble(selected.Rows[rowIndex]["DELVQTY"]);
                    double dOkQty = Convert.ToDouble(selected.Rows[rowIndex]["OKQTY"]);
                    double dBadQty = Convert.ToDouble(selected.Rows[rowIndex]["BADQTY"]);
                    int iWhSeq = (int)selected.Rows[rowIndex]["WHSEQ"];
                    int iEmpSeq = (int)selected.Rows[rowIndex]["ERP_EMPNO"];

                    DataRow newRow = newTable.NewRow();

                    newRow["ORDERSEQ"] = iOrderSeq;
                    newRow["RECVYN"] = sRecvYn;
                    newRow["DELVSEQ"] = iDelvSeq;
                    newRow["DELVSERL"] = iDelvSerl;
                    newRow["DELVNO"] = sDelvNo;
                    newRow["INDATE"] = sInDate;
                    newRow["ITEMSEQ"] = iItemSeq;
                    newRow["ITEMNO"] = sItemId;
                    newRow["DELVQTY"] = dDelvQty;
                    newRow["OKQTY"] = dOkQty;
                    newRow["BADQTY"] = dBadQty;
                    newRow["WHSEQ"] = iWhSeq;
                    newRow["EMPSEQ"] = iEmpSeq;
                    newRow["_STATE_"] = "added";

                    newTable.Rows.Add(newRow);
                }

                ExecuteRule("ChangeConsumableState", newTable);

                ShowMessage("SuccessSave");

            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.CloseWaitArea();
                btnConfirm.Enabled = true;
                OnSearchAsync();
            }
        }

        /// <summary>
        /// 입고완료 건 취소
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirmCancel_Click(object sender, EventArgs e)
        {
            grdMaster.View.CheckValidation();

            try
            {
                this.ShowWaitArea();
                btnConfirmCancel.Focus();
                btnConfirmCancel.Enabled = false;

                DataTable selected = grdMaster.View.GetCheckedRows();

                if(selected.Rows.Count != 1)
                {
                    //한개만 체크하세요.
                    throw MessageException.Create("GridOneCheck");
                    return;
                }

                if (!CheckCancelEnable(selected))
                {
                    //입고완료된 행이 아닙니다.
                    throw MessageException.Create("IsNotConfirm");
                    return;
                }

                ExecuteRule("CancelOrderConfirm", selected);

                ShowMessage("SuccessSave");
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.CloseWaitArea();
                btnConfirmCancel.Enabled = true;
                OnSearchAsync();
            }
        }

        private void BtnScan_Click(object sender, EventArgs e)
        {
            grdItem.View.CheckValidation();

            try
            {
                this.ShowWaitArea();
                btnScan.Focus();
                btnScan.Enabled = false;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.CloseWaitArea();
                btnScan.Enabled = true;
                OnSearchAsync();
            }
        }



        /// <summary>
        /// 셀변경 이벤트 (입고완료된 후 적용불가)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveLot(object sender, EventArgs e)
        {
            grdLot.View.CheckValidation();

            try
            {
                this.ShowWaitArea();
                btnSaveLot.Focus();
                btnSaveLot.Enabled = false;

                DataTable changed = grdLot.GetChangedRows();

                if (changed.Rows.Count == 0)
                {
                    // 저장할 데이터가 존재하지 않습니다.
                    throw MessageException.Create("NoSaveData");
                }
                else
                {
                    ExecuteRule("CreateConsumableLot", changed);    //Location 변경

                    ShowMessage("SuccessSave");
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.CloseWaitArea();
                btnSaveLot.Enabled = true;

                OnSearchAsync();
            }
        }


        /// <summary>
        /// 라벨발행
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintLabel_Click(object sender, EventArgs e)
        {
            DataTable selectedRows = grdLot.View.GetCheckedRows();

            if(selectedRows.Rows.Count <1)
            {
                ShowMessage("NoPrintData");
                return;
            }

            foreach (DataRow Row in selectedRows.Rows)
            {
                string lot = Row["CONSUMABLELOTID"].ToString();

                CommonFunction.PrintMaterialLabel(lot);
            }
        }


        /// <summary>
        /// 입고상세 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MasterView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grdMaster.View.FocusedRowHandle < 0)
                return;

            DataRow dr = (sender as SmartBandedGridView).GetFocusedDataRow();

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_LANGUAGETYPE", UserInfo.Current.LanguageType);
            param.Add("P_POSEQ", dr["POSEQ"].ToString());
            param.Add("P_POSERL", dr["POSERL"].ToString());
            param.Add("P_DELVSEQ", dr["DELVSEQ"].ToString());
            param.Add("P_DELVSERL", dr["DELVSERL"].ToString());

            DataTable dtItem = SqlExecuter.Query("GetMaterialOrderItem", "00001", param);
            if (dtItem.Rows.Count < 1)
            {
                grdItem.DataSource = null;
                grdLot.DataSource = null;
            }
            else
            {
                //grdItem.Caption = string.Format("{0} / {1} ", dr["ORDERID"], dr["ITEMID"]);

                grdItem.DataSource = dtItem;

                param.Clear();
                param.Add("P_ORDERSEQ", dtItem.Rows[0]["SEQ"].ToString());

                DataTable dtLot = SqlExecuter.Query("GetMaterialLot", "00001", param);

                grdLot.DataSource = dtLot;
            }
        }

        private void View_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;

            if (e.Column.FieldName == "ORDERID" || e.Column.FieldName == "INDATE")
            {
                string str1 = view.GetRowCellDisplayText(e.RowHandle1, e.Column);
                string str2 = view.GetRowCellDisplayText(e.RowHandle2, e.Column);
                e.Merge = (str1 == str2);
            }
            else
            {
                e.Merge = false;
            }

            e.Handled = true;
        }

        private void MasterView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (grdMaster.View.GetRowCellValue(e.RowHandle, "COMPLETEYN") == null) return;
            if (grdMaster.View.GetRowCellValue(e.RowHandle, "COMPLETEYN").Equals("Y"))
            {
                e.Appearance.BackColor = Color.FromArgb(30, 255, 0, 0);
            }
            if (grdMaster.View.GetRowCellValue(e.RowHandle, "TOSSYN").Equals("Y"))
            {
                e.Appearance.BackColor = Color.FromArgb(30, 0, 255, 0);
            }
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

            string dateFrom = Convert.ToDateTime(values["P_DATEPERIOD_PERIODFR"]).ToString("yyyyMMdd");
            string dateTo = Convert.ToDateTime(values["P_DATEPERIOD_PERIODTO"]).ToString("yyyyMMdd");

            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);
            values.Add("DelvDateFr", dateFrom);
            values.Add("DelvDateTo", dateTo);
            values.Add("USERID", UserInfo.Current.Id);
            values.Remove("P_DATEPERIOD_PERIODFR");
            values.Remove("P_DATEPERIOD_PERIODTO");

            DataTable dtMaster = await ProcedureAsync("USP_ERPIF_GETPOLIST", values);

            if (dtMaster.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }
            grdMaster.DataSource = dtMaster;
            grdItem.DataSource = null;
            grdLot.DataSource = null;
        }

        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();
            CommonFunction.AddConditionCustomerPopup("P_COMPANYID", 2.1, false, Conditions);

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

        private bool validationCheckStandardInfo(DataTable selectedData)
        {
            bool bFlag = true;

            foreach (DataRow row in selectedData.Rows)
            {
                if (row["WHSEQ"] == System.DBNull.Value || row["WHSEQ"].ToString() == "")
                    bFlag = false;
            }

            return bFlag;
        }

        private bool validationCheckOkQty(DataTable selectedData)
        {
            bool bFlag = true;

            foreach (DataRow row in selectedData.Rows)
            {
                if (row["OKQTY"] == System.DBNull.Value)
                    bFlag = false;
                else
                {
                    if (Convert.ToInt32(row["OKQTY"]) == 0 || Convert.ToInt32(row["OKQTY"]) < 0 || string.IsNullOrEmpty(row["OKQTY"].ToString()))
                    {
                        bFlag = false;
                    }
                }
            }

            return bFlag;
        }


        private bool validationCheckLotSize(DataTable selectedData)
        {
            bool bFlag = true;

            foreach (DataRow row in selectedData.Rows)
            {
                if (row["LOTSIZE"] == System.DBNull.Value)
                    bFlag = false;
                else
                {
                    if (Convert.ToInt32(row["LOTSIZE"]) == 0 || Convert.ToInt32(row["LOTSIZE"]) < 0 || string.IsNullOrEmpty(row["LOTSIZE"].ToString()))
                    {
                        bFlag = false;
                    }
                } 
            }

            return bFlag;
        }

        private bool validationCheckMaster(DataTable selectedData)
        {
            bool bFlag = true;

            foreach (DataRow row in selectedData.Rows)
            {
                if (row["COMPLETEYN"].ToString() == "N")
                {
                    bFlag = false;
                }
                if (row["TOSSYN"].ToString() == "Y")
                {
                    bFlag = false;
                }
            }

            return bFlag;
        }

        /// <summary>
        /// 마스터그리드에서 Confirm되었는지 확인
        /// </summary>
        /// <param name="curDt"></param>
        /// <returns></returns>
        private bool CheckMasterData(DataTable selectedData)
        {
            bool rValue = true;

            foreach (DataRow row in selectedData.Rows)
            {
                if (row["PROGTYPE"].ToString() == "1")
                    rValue = false;

                if (row["COMPLETEYN"].ToString() == "Y")
                    rValue = false;
            }

            return rValue;
        }

        private bool CheckCancelEnable(DataTable selectedData)
        {
            bool rValue = true;

            foreach (DataRow row in selectedData.Rows)
            {
                if (row["PROGTYPE"].ToString() == "0")
                    rValue = false;

                if (row["COMPLETEYN"].ToString() == "N")
                    rValue = false;
            }

            return rValue;
        }

        private void SelectLocationPopup()
        {
            var popupColumn = grdLot.View.AddSelectPopupColumn("LOCATIONID", new SqlQuery("GetCellId", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("SELECTLOCATIONID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupResultMapping("LOCATIONID", "LOCATIONID")
                .SetPopupLayoutForm(600, 600, System.Windows.Forms.FormBorderStyle.FixedToolWindow)
                .SetPopupAutoFillColumns("CELLNAME")
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("CELLID")
                .SetPopupApplySelection((selectedRows, dataGridRow) =>
                {
                    DataRow classRow = grdLot.View.GetFocusedDataRow();

                    foreach (DataRow row in selectedRows)
                    {
                        classRow["LOCATIONID"] = row["LOCATIONID"];
                        classRow["CELLNAME"] = row["CELLNAME"];
                    }
                });

            popupColumn.GridColumns.AddTextBoxColumn("LOCATIONID", 100);
            popupColumn.GridColumns.AddTextBoxColumn("CELLNAME", 120);
            popupColumn.GridColumns.AddTextBoxColumn("QTY", 80);

            popupColumn.Conditions.AddComboBox("P_TYPE", new SqlQuery("GetCodeList", "00001", "CODECLASSID=RackKeepDivision", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                 .SetDefault("")
                 .SetLabel("TYPE");
        }

        #endregion
    }
}

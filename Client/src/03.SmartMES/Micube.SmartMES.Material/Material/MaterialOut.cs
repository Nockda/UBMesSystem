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
using System.Windows.Forms;
using Micube.SmartMES.Commons;

#endregion

namespace Micube.SmartMES.Material
{
    /// <summary>
    /// 프 로 그 램 명  : 자재관리 > 자재 > 자재 출고 처리
    /// 업  무  설  명  : 자재출고 정보를 등록 및 처리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-04-27
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class MaterialOut : SmartConditionBaseForm
    {
        public MaterialOut()
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

            // 컨트롤 초기화 로직 구성
            InitializeMaster();
            InitializeItem();
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

            grdMaster.View.SetSortOrder("REQDATE");

            grdMaster.View.AddDateEditColumn("REQDATE", 80)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd")
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("REQSEQ", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("REQSERL", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("REQNO", 120)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("REQCODE");
            grdMaster.View.AddTextBoxColumn("ITEMSEQ", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("ITEMNO", 120)
                .SetLabel("CONSUMABLEDEFID")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("ITEMNAME", 180)
                .SetLabel("CONSUMABLEDEFNAME")
                .SetIsReadOnly();
            grdMaster.View.AddTextBoxColumn("UNITSEQ", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("UNITNAME", 50)
                .SetLabel("UNIT")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddSpinEditColumn("REQQTY", 80)
                .SetDisplayFormat("#,###.##")
                .SetLabel("OUTREQQTY")
                .SetIsReadOnly();
            grdMaster.View.AddSpinEditColumn("PROGQTY", 80)
                .SetDisplayFormat("#,###.##")
                .SetLabel("OUTQTY")
                .SetIsReadOnly();
            grdMaster.View.AddSpinEditColumn("LEFTQTY", 80)
                .SetDisplayFormat("#,###.##")
                .SetLabel("OUTLEFTQTY")
                .SetIsReadOnly();
            grdMaster.View.AddSpinEditColumn("STOCKQTY", 80)
                .SetDisplayFormat("#,###.##")
                .SetIsHidden()
                .SetIsReadOnly();
            grdMaster.View.AddTextBoxColumn("OUTWHSEQ", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("OUTWAREHOUSENAME", 80)
                .SetIsReadOnly()
                .SetLabel("FROMWAREHOUSEID")
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("OUTCELLID", 80)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("INWHSEQ", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("INWAREHOUSENAME", 80)
                .SetIsReadOnly()
                .SetLabel("TOWAREHOUSEID")
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("DEPTSEQ", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("DEPTNAME", 100)
                .SetLabel("DEPARTMENT")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("EMPSEQ", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("EMPNAME", 80)
                .SetLabel("CUSTOMERMANAGER")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("REMARK", 150)
                .SetIsReadOnly();
            grdMaster.View.AddTextBoxColumn("STATUSSEQ", 50)
                .SetIsHidden();
            grdMaster.View.AddTextBoxColumn("STATUSNAME", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("DELIVERYSTATE");
            grdMaster.View.AddTextBoxColumn("COMPLETEYN", 50)
                .SetIsReadOnly()
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
            grdItem.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdItem.View.OptionsView.AllowCellMerge = true;
            grdItem.View.SetIsReadOnly();

            grdItem.View.SetSortOrder("SEQ");
            grdItem.View.SetAutoFillColumn("CONSUMABLEDEFNAME");

            grdItem.View.AddTextBoxColumn("SEQ", 50)
                .SetIsHidden();
            grdItem.View.AddTextBoxColumn("REQSEQ", 50)
                .SetIsHidden();
            grdItem.View.AddTextBoxColumn("REQSERL", 50)
                .SetIsHidden();
            grdItem.View.AddTextBoxColumn("REQNO", 100)
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("REQCODE");
            grdItem.View.AddTextBoxColumn("ITEMSEQ", 50)
                .SetIsHidden();
            grdItem.View.AddTextBoxColumn("CONSUMABLEDEFID", 120)
                .SetTextAlignment(TextAlignment.Center);
            grdItem.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 150);
            grdItem.View.AddTextBoxColumn("ITEMSTANDARD", 150)
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("STANDARD");
            grdItem.View.AddTextBoxColumn("UNITSEQ", 50)
                .SetIsHidden();
            grdItem.View.AddTextBoxColumn("UNITNAME", 80)
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("UNIT");
            grdItem.View.AddComboBoxColumn("OUTWHSEQ", 150, new SqlQuery("GetComboWarehouse", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("FROMWAREHOUSEID");
            grdItem.View.AddComboBoxColumn("INWHSEQ", 150, new SqlQuery("GetComboWarehouse", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("TOWAREHOUSEID");
            grdItem.View.AddTextBoxColumn("CONSUMABLELOTID", 120)
                .SetTextAlignment(TextAlignment.Center);
            grdItem.View.AddSpinEditColumn("OUTQTY", 80)
                .SetDisplayFormat("#,###.##");
            grdItem.View.AddComboBoxColumn("COMPLETEYN", 50, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YesNoState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetIsHidden();
            grdItem.View.AddTextBoxColumn("DEPTSEQ", 50)
                .SetIsHidden();

            grdItem.View.PopulateColumns();
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            btnReady.Click += BtnReady_Click;
            btnCancel.Click += BtnCancel_Click;
            btnScan.Click += BtnScan_Click;
            btnConfirm.Click += BtnConfirm_Click;
            btnPrint.Click += BtnPrint_Click;

            grdMaster.View.CellMerge += MasterView_CellMerge;
            grdItem.View.CellMerge += ItemView_CellMerge;

            grdMaster.View.RowStyle += MasterView_RowStyle;
        }

        

        /// <summary>
        /// 출고준비
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReady_Click(object sender, EventArgs e)
        {
            grdMaster.View.CheckValidation();

            try
            {
                this.ShowWaitArea();
                btnReady.Focus();
                btnReady.Enabled = false;

                DataTable selected = grdMaster.View.GetCheckedRows();

                if (selected.Rows.Count == 0)
                {
                    // 저장할 데이터가 존재하지 않습니다.
                    throw MessageException.Create("NoSelected");
                }
                else
                {
                    if(!CheckMasterData(selected))
                    {
                        throw MessageException.Create("AlreadyReadyDone");  //자재준비가 가능하지 않습니다.
                        return;
                    }

                    if(CheckReqData(selected))
                    {
                        return;
                    }

                    if(!CheckAlreadyReqData(selected))
                    {
                        throw MessageException.Create("AlreadyReqData");
                        return;
                    }

                    selected.Columns.Add("_STATE_", typeof(string));
                    foreach(DataRow row in selected.Rows)
                    {
                        row["_STATE_"] = "added";
                    }

                    ExecuteRule("DeliveryRequest", selected);

                    ShowMessage("MaterialReadyOk");
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.CloseWaitArea();
                btnReady.Enabled = true;
                OnSearchAsync();
            }
        }

        /// <summary>
        /// 준비취소
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            grdMaster.View.CheckValidation();

            try
            {
                this.ShowWaitArea();
                btnCancel.Focus();
                btnCancel.Enabled = false;

                DataTable selected = grdMaster.View.GetCheckedRows();

                if (selected.Rows.Count == 0)
                {
                    // 저장할 데이터가 존재하지 않습니다.
                    throw MessageException.Create("NoSelected");
                }
                else
                {
                    if(CheckReqData(selected))
                    {
                        selected.Columns.Add("_STATE_", typeof(string));
                        foreach (DataRow row in selected.Rows)
                        {
                            row["_STATE_"] = "deleted";
                        }

                        ExecuteRule("DeliveryRequest", selected);

                        ShowMessage("MaterialCancelOk");
                    } 
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.CloseWaitArea();
                btnCancel.Enabled = true;
                OnSearchAsync();
            }
        }

        /// <summary>
        /// 출고스캔팝업
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnScan_Click(object sender, EventArgs e)
        {
            grdMaster.View.CheckValidation();

            try
            {
                this.ShowWaitArea();
                btnScan.Focus();
                btnScan.Enabled = false;

                DataTable selected = grdMaster.View.GetCheckedRows();

                if (selected.Rows.Count == 0)
                {
                    // 저장할 데이터가 존재하지 않습니다.
                    throw MessageException.Create("NoSelected");
                }
                else
                {
                    if (!CheckMasterData(selected))
                        return;

                    if (!CheckReqData(selected))
                        return;

                    if (!CheckDistintItem(selected))
                    {
                        throw MessageException.Create("NeedOneMaterial");
                        return;
                    }
                    if (!CheckReqNo(selected))
                    {
                        throw MessageException.Create("NeedOneReqNo");
                        return;
                    }

                    MaterialOutByScanPopup popup = new MaterialOutByScanPopup();
                    //popup.TopMost = true;
                    popup.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                    popup.CurrentDataTable = selected;

                    popup.ShowDialog();
                }
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

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            grdItem.View.CheckValidation();

            try
            {
                this.ShowWaitArea();
                btnConfirm.Focus();
                btnConfirm.Enabled = false;

                DataTable selected = grdItem.View.GetCheckedRows();

                if (selected.Rows.Count == 0)
                {
                    throw MessageException.Create("NoSelected");
                    return;
                }

                if (!CheckWarehouse(selected))
                {
                    throw MessageException.Create("NeedOneWarehouse");
                    return;
                }

                selected.Columns.Add("RECEIVERID", typeof(string));

                ReceiverRegPopup recvPopup = new ReceiverRegPopup();
                recvPopup.StartPosition = FormStartPosition.CenterParent;

                DialogResult result = recvPopup.ShowDialog();
                if(result == DialogResult.OK)
                {
                    string receiverId = recvPopup._ReceiverId;
                    string deptCode = recvPopup._DeptCode;

                    if(receiverId == "" || deptCode == "")
                    {
                        throw MessageException.Create("NeedReceiver");
                        return;
                    }

                    foreach(DataRow row in selected.Rows)
                    {
                        row["DEPTSEQ"] = Convert.ToInt32(deptCode);
                        row["RECEIVERID"] = receiverId;
                    }

                    ExecuteRule("DeliveryMaterialConfirm", selected); //Lot 이동 및 분할
                }
                else
                {
                    ShowMessage("CancelSave");
                }

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

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            grdItem.View.CheckValidation();

            try
            {
                this.ShowWaitArea();
                btnPrint.Focus();
                btnPrint.Enabled = false;

                DataTable selected = grdItem.View.GetCheckedRows();

                if (selected.Rows.Count == 0)
                {
                    throw MessageException.Create("NoSelected");
                    return;
                }

                foreach (DataRow row in selected.Rows)
                {
                    string lotId = row["CONSUMABLELOTID"].ToString();
                    CommonFunction.PrintMaterialLabel(lotId);
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.CloseWaitArea();
                btnPrint.Enabled = true;
            }
        }

        private void MasterView_CellMerge(object sender, CellMergeEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;

            if ( e.Column.FieldName == "REQNO")
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

        private void ItemView_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;

            if (e.Column.FieldName == "REQNO")
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
            if (grdMaster.View.GetRowCellValue(e.RowHandle, "COMPLETEYN").Equals("N"))
            {
                e.Appearance.BackColor = Color.FromArgb(30, 255, 0, 0);
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
            values.Add("PODateFr", dateFrom);
            values.Add("PODateTo", dateTo);
            values.Add("USERID", UserInfo.Current.Id);
            values.Remove("P_DATEPERIOD_PERIODFR");
            values.Remove("P_DATEPERIOD_PERIODTO");

            DataTable dtMaster = await ProcedureAsync("USP_ERPIF_GETDELIVERYLIST", values);

            if (dtMaster.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
                dtMaster.Clear();
            }

            grdMaster.DataSource = dtMaster; 

            DataTable dtItem = await QueryAsync("GetMaterialOutReq", "00001");
            if(dtItem.Rows.Count<1)
            {
                dtItem.Clear();
            }
            grdItem.DataSource = dtItem;
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
        /// 마스터그리드에서 Confirm되었는지 확인
        /// </summary>
        /// <param name="selectedData"></param>
        /// <returns></returns>
        private bool CheckMasterData(DataTable selectedData)
        {
            bool rValue = true;

            foreach (DataRow row in selectedData.Rows)
            {
                //진행중 또는 확정(승인)일대 만 가능
                if (row["STATUSSEQ"].ToString() != "6036003" && row["STATUSSEQ"].ToString() != "6036002")
                    rValue = false;
            }

            return rValue;
        }

        private bool CheckReqData(DataTable selectedData)
        {
            bool rValue = true;

            foreach(DataRow row in selectedData.Rows)
            {
                if (row["COMPLETEYN"].ToString() != "N")
                    rValue = false;
            }

            return rValue;
        }

        private bool CheckAlreadyReqData(DataTable selectedData)
        {
            bool rValue = true;

            foreach(DataRow row in selectedData.Rows)
            {
                if (row["COMPLETEYN"].ToString() == "N")
                    rValue = false;
            }

            return rValue;
        }

        private bool CheckDistintItem(DataTable selectedData)
        {
            bool rValue = true;

            //품목이 중복되는 것이 있는지 체크
            int i = selectedData.DefaultView.ToTable(true, "ITEMNO").Rows.Count;
            int j = selectedData.Rows.Count;

            if (i != j)
                rValue = false;

            return rValue;
        }

        private bool CheckReqNo(DataTable selectedData)
        {
            bool rValue = true;

            //REQNO가 중복되는 것이 있는지 체크
            int i = selectedData.DefaultView.ToTable(true, "REQNO").Rows.Count;
            if (i > 1)
                rValue = false;

            return rValue;
        }

        private bool CheckWarehouse(DataTable selectedData)
        {
            bool rValue = true;

            //입고창고가 같으면 출고완료
            int i = selectedData.DefaultView.ToTable(true, "INWHSEQ").Rows.Count;
            if (i > 1)
                rValue = false;

            return rValue;
        }

        #endregion
    }
}

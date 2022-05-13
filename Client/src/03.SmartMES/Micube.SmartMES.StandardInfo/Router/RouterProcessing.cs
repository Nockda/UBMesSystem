#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;

using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;

#endregion

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 라우팅관리 > 가공
    /// 업  무  설  명  : 라우팅(가공)을 관리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2020-04-14
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class RouterProcessing : SmartConditionBaseForm
    {
        public RouterProcessing()
        {
            InitializeComponent();
        }

        #region 컨텐츠 영역 초기화

        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeEvent();

            InitializeMaster();
            InitializeItem();
            InitializeResult();
        }

        /// <summary>        
        /// 그리드 초기화
        /// </summary>
        private void InitializeMaster()
        {
            grdMaster.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdMaster.GridButtonItem = GridButtonItem.All;
            grdMaster.View.SetSortOrder("ROUTINGID");
            grdMaster.View.SetAutoFillColumn("DESCRIPTION");

            grdMaster.View.AddTextBoxColumn("ROUTINGID", 80)
                            .SetValidationKeyColumn()
                            .SetValidationIsRequired();
            grdMaster.View.AddComboBoxColumn("ORDERTYPE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=OrderType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetIsReadOnly();
            grdMaster.View.AddTextBoxColumn("ROUTINGNAMEKOR", 100);
            grdMaster.View.AddTextBoxColumn("ROUTINGNAMEENG", 100);
            grdMaster.View.AddTextBoxColumn("ROUTINGNAMEJPN", 100);
            grdMaster.View.AddComboBoxColumn("PROCESSID", 80, new SqlQuery("GetComboProcessLargeCategory", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetValidationKeyColumn();
            grdMaster.View.AddTextBoxColumn("MODELID", 100);
            grdMaster.View.AddComboBoxColumn("WORKGROUPID", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=TeamCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("DESCRIPTION", 200);
            grdMaster.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Valid")
               .SetValidationIsRequired();
            grdMaster.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);

            grdMaster.View.PopulateColumns();
        }

        private void InitializeItem()
        {
            //grdItem.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdItem.GridButtonItem = GridButtonItem.All;
            grdItem.View.SetSortOrder("ITEMID");
            grdItem.View.SetAutoFillColumn("PRODUCTDEFNAME");

            grdItem.View.AddTextBoxColumn("ROUTINGID", 80)
                .SetIsHidden()
                .SetIsReadOnly()
                .SetValidationKeyColumn()
                .SetValidationIsRequired();
            ItemPopup();
            grdItem.View.AddTextBoxColumn("PRODUCTDEFNAME", 120)
                .SetIsReadOnly();
            grdItem.View.AddComboBoxColumn("RESULTSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Valid")
               .SetValidationIsRequired();
            grdItem.View.AddComboBoxColumn("OUTSOURCESTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Valid")
               .SetValidationIsRequired();
            grdItem.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Valid")
               .SetValidationIsRequired();
            //세부공정여부
            grdItem.View.AddComboBoxColumn("PROCESSDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Invalid")
               .SetValidationIsRequired();
            grdItem.View.AddSpinEditColumn("STANDWORKTIME", 60)
                .SetTextAlignment(TextAlignment.Right)
                .SetDisplayFormat("#,##0.##", MaskTypes.Numeric, true);
            grdItem.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center)
                .SetIsHidden();
            grdItem.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center)
                .SetIsHidden();
            grdItem.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center)
                .SetIsHidden();
            grdItem.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center)
                .SetIsHidden();

            grdItem.View.PopulateColumns();
        }

        private void ItemPopup()
        {
            var popupColumn = grdItem.View.AddSelectPopupColumn("ITEMID", new SqlQuery("GetItem", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("SELECTPARENTCODECLASSID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupResultMapping("ITEMID", "ITEMID")
                .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                .SetPopupAutoFillColumns("ITEMNAME")
                .SetValidationKeyColumn()
                .SetValidationIsRequired()
                .SetPopupApplySelection((selectedRows, dataGridRow) =>
                {
                    DataRow classRow = grdItem.View.GetFocusedDataRow();

                    foreach (DataRow row in selectedRows)
                    {
                        classRow["ITEMNAME"] = row["ITEMNAME"];
                    }
                });

            popupColumn.GridColumns.AddTextBoxColumn("ITEMID", 80);
            popupColumn.GridColumns.AddTextBoxColumn("ITEMNAME", 150);
        }

        private void InitializeResult()
        {
            //grdResult.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdResult.GridButtonItem = GridButtonItem.All;
            grdResult.View.SetSortOrder("PROCESSID");
            grdResult.View.SetAutoFillColumn("DESCRIPTION");

            grdResult.View.AddTextBoxColumn("PROCESSSEGMENTID", 80)
                            .SetValidationKeyColumn()
                            .SetValidationIsRequired();
            if (UserInfo.Current.LanguageType == Commons.Constants.LanguageType_KO_KR)
            {
                grdResult.View.AddTextBoxColumn("PROCESSSEGMENTNAMEKOR", 100)
                    .SetIsReadOnly();
            }
            if (UserInfo.Current.LanguageType == Commons.Constants.LanguageType_EN_US)
            {
                grdResult.View.AddTextBoxColumn("PROCESSSEGMENTNAMEENG", 100)
                    .SetIsReadOnly();
            }
            if (UserInfo.Current.LanguageType == Commons.Constants.LanguageType_zh_CN)
            {
                grdResult.View.AddTextBoxColumn("PROCESSSEGMENTNAMEJPN", 100)
                    .SetIsReadOnly();
            }
            grdResult.View.AddTextBoxColumn("DESCRIPTION", 120);
            grdResult.View.AddTextBoxColumn("WORKORDER", 100)
                .SetIsReadOnly();
            grdResult.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Valid")
               .SetValidationIsRequired();
            grdResult.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdResult.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdResult.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdResult.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);

            grdResult.View.PopulateColumns();
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            grdMaster.View.AddingNewRow += MasterView_AddingNewRow;
            grdMaster.View.RowClick += MasterView_RowClick;
            //grdMaster.View.FocusedRowChanged += View_FocusedRowChanged;
            grdItem.View.AddingNewRow += ItemView_AddingNewRowForItem;

            btnSaveItem.Click += BtnSaveItem_Click;
            //btnSaveResult.Click += BtnSaveResult_Click;

        }

        private void MasterView_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            var values = Conditions.GetValues();

            string orderType = values["P_ORDERTYPE"].ToString();
            args.NewRow["ORDERTYPE"] = orderType;
        }

        private void MasterView_RowClick(object sender, RowClickEventArgs e)
        {
            focusedRowChanged();
        }

        //private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    focusedRowChanged();
        //}

        /// <summary>
        /// 품목 그리드 행 추가 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ItemView_AddingNewRowForItem(SmartBandedGridView sender, AddNewRowArgs args)
        {
            DataRow dictionaryClass = grdMaster.View.GetFocusedDataRow();
            args.NewRow["ROUTINGID"] = dictionaryClass["ROUTINGID"];
        }

        private void BtnSaveItem_Click(object sender, EventArgs e)
        {
            grdItem.View.CheckValidation();

            try
            {
                this.ShowWaitArea();
                btnSaveItem.Focus();
                btnSaveItem.Enabled = false;

                DataTable changed = grdItem.GetChangedRows();//변경된 row
                if (changed.Rows.Count == 0)
                {
                    throw MessageException.Create("NoSaveData");
                }

                ExecuteRule("SaveRoutingItem", changed);

                ShowMessage("SuccessSave");
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.CloseWaitArea();
                btnSaveItem.Enabled = true;
            }
        }

        private void BtnSaveResult_Click(object sender, EventArgs e)
        {
            grdResult.View.CheckValidation();

            try
            {
                this.ShowWaitArea();
                btnSaveResult.Focus();
                btnSaveResult.Enabled = false;

                DataTable changed = grdResult.GetChangedRows();//변경된 row
                if (changed.Rows.Count == 0)
                {
                    throw MessageException.Create("NoSaveData");
                }

                //ExecuteRule("SaveWorkManualDetail", changed);

                ShowMessage("SuccessSave");
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.CloseWaitArea();
                btnSaveResult.Enabled = true;
            }
        }

        #endregion

        #region ToolBar
        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdMaster.GetChangedRows();

            ExecuteRule("SaveRoutingMaster", changed);
        }
        #endregion

        #region 검색
        //// <summary>
        /// 비동기 override 모델
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            int beforeHandle = grdMaster.View.FocusedRowHandle;
            DataRow row = grdMaster.View.GetFocusedDataRow();

            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtMaster = await QueryAsync("GetRoutingMaster", "00001", values);

            if (dtMaster.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
                dtMaster.Clear();
            }
            else if (dtMaster.Rows.Count <= beforeHandle)
            {
                grdMaster.DataSource = dtMaster;
                grdMaster.View.FocusedRowHandle = 0;

                DataRow currentRow = grdMaster.View.GetFocusedDataRow();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("P_ROUTINGID", currentRow["ROUTINGID"].ToString());

                grdItem.DataSource = SqlExecuter.Query("GetRoutingItem", "00001", param);

                grdMaster.View.FocusedRowHandle = 0;
                grdMaster.View.SelectRow(0);

                focusedRowChanged();
            }
            else
            {
                grdMaster.DataSource = dtMaster;

                int afterHandle = grdMaster.View.FocusedRowHandle;

                if(beforeHandle == 0 && afterHandle == 0)
                {
                    focusedRowChanged();
                }

                if(beforeHandle >0)
                {
                    Dictionary<string, object> param = new Dictionary<string, object>();
                    param.Add("P_ROUTINGID", row["ROUTINGID"].ToString());

                    //grdCode.DataSource = SqlExecuter.Procedure("usp_com_selectCode", param);
                    grdItem.DataSource = SqlExecuter.Query("GetRoutingItem", "00001", param);

                    grdMaster.View.FocusedRowHandle = beforeHandle;
                    grdMaster.View.UnselectRow(afterHandle);
                    grdMaster.View.SelectRow(beforeHandle);

                    focusedRowChanged();
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

        }

        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터 저장할때 컨텐츠 영역의 유효성 검사
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();

            grdMaster.View.CheckValidation();

            DataTable changed = grdMaster.GetChangedRows();

            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function

        /// <summary>
        /// 마스터 그리드의 포커스 행 변경 로직을 처리한다.
        /// </summary>
        private void focusedRowChanged()
        {
            var row = grdMaster.View.GetDataRow(grdMaster.View.FocusedRowHandle);

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_ROUTINGID", row["ROUTINGID"].ToString());

            if (string.IsNullOrEmpty(row["ROUTINGID"].ToString()))
            {
                //ShowMessage("NoSelectData");
                grdItem.View.ClearDatas();
                grdResult.View.ClearDatas();

                return;
            }

            grdItem.DataSource = SqlExecuter.Query("GetRoutingItem", "00001", param);
            grdResult.DataSource = SqlExecuter.Query("GetRoutingResult", "00001", param);

        }

        #endregion
    }
}

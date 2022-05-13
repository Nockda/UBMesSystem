#region using
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

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 창고관리 > 랙관리
    /// 업  무  설  명  : 창고별 랙을 관리한다.
    /// 생    성    자  : jylee
    /// 생    성    일  : 2019-04-14
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class RackMgt2 : SmartConditionBaseForm
    {
        public RackMgt2()
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
        private void InitializeMaster()
        {
            grdMaster.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdMaster.GridButtonItem = GridButtonItem.All;

            grdMaster.View.SetSortOrder("RACKID");
            //RACK ID
            grdMaster.View.AddTextBoxColumn("RACKID",150)
                .SetValidationKeyColumn()
                .SetValidationIsRequired();
            //RACK NAME
            grdMaster.View.AddTextBoxColumn("RACKNAME", 200)
                .SetValidationIsRequired();
            //TEAM
            grdMaster.View.AddComboBoxColumn("TEAM", 150, new SqlQuery("GetCodeList", "00001", "CODECLASSID=TEAMCODE", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));
            //grdMaster.View.AddTextBoxColumn("TEAM", 100);
            //창고ID
            ClickWarehousePopup();
            //grdMaster.View.AddTextBoxColumn("WAREHOUSEID", 100);
            //창고이름
            grdMaster.View.AddTextBoxColumn("WAREHOUSENAME", 150);
            //담당자ID(정)
            //grdMaster.View.AddTextBoxColumn("MAINUSERID", 100);
            //담당자(정)
            ClickMainUserPopup();
            //grdMaster.View.AddTextBoxColumn("MAINUSERNAME", 100);
            //담당자ID(부)
            //grdMaster.View.AddTextBoxColumn("SUBUSERID", 100);
            //담당자(부)
            ClickSubUserPopup();
            //grdMaster.View.AddTextBoxColumn("SUBUSERNAME", 100);
            //유효상태
            grdMaster.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetDefault("Valid")
               .SetValidationIsRequired()
               .SetTextAlignment(TextAlignment.Center);

/*            grdMaster.View.AddTextBoxColumn("CREATOR", 80)
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
                .SetTextAlignment(TextAlignment.Center);*/

            grdMaster.View.PopulateColumns();
        }

        //창고 맵핑
        private void ClickWarehousePopup()
        {
            var popupColumn = grdMaster.View.AddSelectPopupColumn("WAREHOUSEID", 150, new SqlQuery("GetWarehousePopup", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("SELECTWAREHOUSE", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupResultMapping("WAREHOUSEID", "WAREHOUSEID")
                .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                .SetPopupAutoFillColumns("WAREHOUSENAME")
           .SetPopupApplySelection((selectedRows, dataGridRow) =>
            {
            DataRow classRow = grdMaster.View.GetFocusedDataRow();

           foreach (DataRow row in selectedRows)
           {
                    classRow["WAREHOUSENAME"] = row["WAREHOUSENAME"];
           }
            });
            popupColumn.GridColumns.AddTextBoxColumn("WAREHOUSEID", 80);
            popupColumn.GridColumns.AddTextBoxColumn("WAREHOUSENAME", 100);
        }

        //담당자(정) 맵핑
        private void ClickMainUserPopup()
        {
            var popupColumn = grdMaster.View.AddSelectPopupColumn("MAINUSERNAME", 150, new SqlQuery("GetMainUserPopup", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("SELECTUSER", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupResultMapping("MAINUSERNAME", "MAINUSERNAME")
                .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                .SetPopupAutoFillColumns("MAINUSERNAME")
            .SetPopupApplySelection((selectedRows, dataGridRow) =>
            {
            DataRow classRow = grdItem.View.GetFocusedDataRow();

            foreach (DataRow row in selectedRows)
            {
                //classRow["ITEMNAME"] = row["ITEMNAME"];
            }
            });
            popupColumn.GridColumns.AddTextBoxColumn("TEAM", 80);
            popupColumn.GridColumns.AddTextBoxColumn("MAINUSERNAME", 100);

            //검색조건
            //popupColumn.Conditions.AddTextBox("TEAM");
            popupColumn.Conditions.AddComboBox("TEAM", new SqlQuery("GetCodeList", "00001", "CODECLASSID=TeamCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));
        }
        
        //담당자(부) 맵핑
        private void ClickSubUserPopup()
        {
            var popupColumn = grdMaster.View.AddSelectPopupColumn("SUBUSERNAME", 150, new SqlQuery("GetSubUserPopup", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("SELECTUSER", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupResultMapping("SUBUSERNAME", "SUBUSERNAME")
                .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                .SetPopupAutoFillColumns("SUBUSERNAME")
            .SetPopupApplySelection((selectedRows, dataGridRow) =>
            {
                DataRow classRow = grdItem.View.GetFocusedDataRow();

                foreach (DataRow row in selectedRows)
                {
                    //classRow["ITEMNAME"] = row["ITEMNAME"];
                }
            });
            popupColumn.GridColumns.AddTextBoxColumn("TEAM", 80);
            popupColumn.GridColumns.AddTextBoxColumn("SUBUSERNAME", 100);

            //검색조건
            //popupColumn.Conditions.AddTextBox("TEAM");
            popupColumn.Conditions.AddComboBox("TEAM", new SqlQuery("GetCodeList", "00001", "CODECLASSID=TeamCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));
        }

        private void InitializeItem() 
        {
            grdItem.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdItem.GridButtonItem = GridButtonItem.All;
            //CELL
            grdItem.View.SetSortOrder("CELLID");
            grdItem.View.AddTextBoxColumn("CELLID", 150)
                .SetValidationKeyColumn()
                .SetValidationIsRequired();
            //CELL이름
            grdItem.View.AddTextBoxColumn("CELLNAME", 150)
                 .SetValidationIsRequired();
            //RACKID
            grdItem.View.AddTextBoxColumn("RACKID", 150);
            //RACKNAME
            grdItem.View.AddTextBoxColumn("RACKNAME", 150);
            //ITEMID
            CheckItemPopup();
            //ITEMNAME
            grdItem.View.AddTextBoxColumn("ITEMNAME", 150);
            //QTY
            grdItem.View.AddTextBoxColumn("QTY", 150);
            //유효상태
            grdItem.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetDefault("Valid")
                .SetValidationIsRequired()
                .SetTextAlignment(TextAlignment.Center);
 /*           //생성자
            grdItem.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            //생성일
            grdItem.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            //수정자
            grdItem.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            //수정일
            grdItem.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);*/

            grdItem.View.PopulateColumns();

        }

        //품목 맵핑
        private void CheckItemPopup() 
        {
            var popupColumn = grdItem.View.AddSelectPopupColumn("ITEMID", 150, new SqlQuery("GetItemPopup", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("SELECTPARENTCODECLASSID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupResultMapping("ITEMID", "ITEMID")
                .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                .SetPopupAutoFillColumns("ITEMNAME")
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
            popupColumn.GridColumns.AddTextBoxColumn("ITEMNAME", 100);

            //검색조건
            popupColumn.Conditions.AddTextBox("ITEMNAME");
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>

        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            grdMaster.View.AddingNewRow += View_AddingNewRow;
            grdMaster.View.FocusedRowChanged += View_FocusedRowChanged;

            grdItem.View.AddingNewRow += View_AddingNewRowForItem;
            btnSaveItem.Click += BtnSaveItem_Click;

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

                ExecuteRule("SaveRackDetail", changed);

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

        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            DataRow focusRow = grdMaster.View.GetFocusedDataRow();
        }

        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            focusedRowChanged();
        }

        private void View_AddingNewRowForItem(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            DataRow focusRow = grdMaster.View.GetFocusedDataRow();
            string masterId = focusRow["RACKID"].ToString();
            string masterName = focusRow["RACKNAME"].ToString();
            args.NewRow["RACKID"] = masterId;
            args.NewRow["RACKNAME"] = masterName;
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

            ExecuteRule("SaveRack2", changed);
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

            DataTable dtMaster = await QueryAsync("GetRackMasterList", "00001", values);

            if (dtMaster.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdMaster.DataSource = dtMaster;
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
/*        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

            Conditions.GetControl<SmartComboBox>("p_WAREHOUSE").EditValueChanged += WorkGroupCode_EditValueChanged;
        }*/

        #endregion

        #region 유효성 검사
        /// <summary>
        /// 데이터 저장할때 컨텐츠 영역의 유효성 검사
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();

            grdMaster.View.CheckValidation();
            grdItem.View.CheckValidation();


            DataTable changed = grdMaster.GetChangedRows();
                      changed = grdItem.GetChangedRows();
            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }
        private void focusedRowChanged()
        {
            var row = grdMaster.View.GetDataRow(grdMaster.View.FocusedRowHandle);

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_RACKID", row["RACKID"].ToString());

            if (string.IsNullOrEmpty(row["RACKID"].ToString()))
            {
                ShowMessage("NoSelectData");
                grdItem.View.ClearDatas();

                return;
            }

            grdItem.DataSource = SqlExecuter.Query("GetRackDetailList", "00001", param);

        }
        #endregion

        #region Private Function
/*        private void WorkGroupCode_EditValueChanged(object sender, EventArgs e)
        {
            SqlQuery condition = new SqlQuery("GetComboRack", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}", $"P_WORKGROUPCODE={Conditions.GetControl<SmartComboBox>("P_WORKGROUPCODE").EditValue}");
            DataTable conditionTable = condition.Execute();
            this.Conditions.GetControl<SmartComboBox>("p_RACKNAME").ValueMember = "CODEID";
            this.Conditions.GetControl<SmartComboBox>("p_RACKNAME").DisplayMember = "CODENAME";
            this.Conditions.GetControl<SmartComboBox>("p_RACKNAME").EditValue = "*";
            this.Conditions.GetControl<SmartComboBox>("p_RACKNAME").DataSource = conditionTable;
        }*/
        #endregion
    }
}
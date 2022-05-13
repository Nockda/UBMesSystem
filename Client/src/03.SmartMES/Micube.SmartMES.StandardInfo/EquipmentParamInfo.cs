#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 설비 관리 > 설비별 Parameter 관리
    /// 업  무  설  명  : 설비별 Parameter정보를 관리한다.
    /// 생    성    자  : 모세찬
    /// 생    성    일  : 2020-04-06
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class EquipmentParamInfo : SmartConditionBaseForm
    {
        public EquipmentParamInfo()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();
            InitializeEvent();

            InitializeMasterGrid();
            InitializeItemGrid();
        }

        private void InitializeMasterGrid()
        {
            grdMaster.GridButtonItem = GridButtonItem.Refresh;
            grdMaster.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdMaster.View.SetIsReadOnly();
            grdMaster.View.SetSortOrder("EQUIPMENTID");

            grdMaster.View.AddTextBoxColumn("EQUIPMENTID", 80);
            grdMaster.View.AddTextBoxColumn("EQUIPMENTNAME", 80);
            grdMaster.View.SetAutoFillColumn("EQUIPMENTNAME");

            grdMaster.View.AddComboBoxColumn("IFSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Valid")
               .SetValidationIsRequired();

            grdMaster.View.PopulateColumns();

            grdMaster.View.OptionsCustomization.AllowFilter = false;
            grdMaster.View.OptionsCustomization.AllowSort = false;
        }

        private void InitializeItemGrid()
        {
            grdItem.GridButtonItem = GridButtonItem.All;
            grdItem.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdItem.View.SetSortOrder("PARAMETERID");
            grdItem.View.SetAutoFillColumn("DESCRIPTION");

            grdItem.View.AddTextBoxColumn("EQUIPMENTID")
                .SetValidationKeyColumn()
                .SetValidationIsRequired();
            grdItem.View.AddTextBoxColumn("PARAMETERID")
                .SetValidationKeyColumn()
                .SetValidationIsRequired();
            grdItem.View.AddLanguageColumn("PARAMETERNAME", 100);
            grdItem.View.AddTextBoxColumn("PARAMETERLEVEL");
            grdItem.View.AddTextBoxColumn("UNIT");
            grdItem.View.AddTextBoxColumn("DATAFORMAT");
            grdItem.View.AddTextBoxColumn("LOWERSPECLIMIT");
            grdItem.View.AddTextBoxColumn("TARGET");
            grdItem.View.AddTextBoxColumn("UPPERSPECLIMIT");
            grdItem.View.AddTextBoxColumn("GATHERCYCLE");
            grdItem.View.AddTextBoxColumn("LIMITTIME");
            grdItem.View.AddTextBoxColumn("MANAGESTATE");
            grdItem.View.AddTextBoxColumn("LOWERCONTROLLIMIT");
            grdItem.View.AddTextBoxColumn("AVERAGEVALUE");
            grdItem.View.AddTextBoxColumn("UPPERCONTROLLIMIT");
            grdItem.View.AddTextBoxColumn("SVPARAMETERID");
            grdItem.View.AddTextBoxColumn("SVRATE");
            grdItem.View.AddTextBoxColumn("INTERLOCKSTATE");
            grdItem.View.AddTextBoxColumn("DESCRIPTION");
            grdItem.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Valid")
               .SetValidationIsRequired();
            grdItem.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdItem.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);
            grdItem.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdItem.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);

            grdItem.View.PopulateColumns();

        }

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            grdMaster.ToolbarRefresh += GrdMaster_ToolbarRefresh;

            grdMaster.View.FocusedRowChanged += View_FocusedRowChanged;
            grdItem.View.AddingNewRow += View_AddingNewRow;
        }

        /// <summary>
        /// 마스터 리스트 그리드의 새로고침 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdMaster_ToolbarRefresh(object sender, EventArgs e)
        {
            try
            {
                int beforeFocusMaster = grdMaster.View.FocusedRowHandle;

                grdMaster.ShowWaitArea();

                LoadDataMasterGrid();

                grdMaster.View.FocusedRowHandle = 0;
                grdMaster.View.UnselectRow(beforeFocusMaster);
                grdMaster.View.SelectRow(0);

                focusedRowChanged();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            finally
            {
                grdMaster.CloseWaitArea();
            }
        }

        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            focusedRowChanged();
        }

        /// <summary>
        /// 추가 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            DataRow focusRow = grdMaster.View.GetFocusedDataRow();
            string masterId = focusRow["EQUIPMENTID"].ToString();
            args.NewRow["EQUIPMENTID"] = masterId;

        }

        #endregion

        #region 툴바
        /// <summary>
        /// 저장버튼 클릭
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdItem.GetChangedRows();

            ExecuteRule("SaveEquipParameter", changed);
            focusedRowChanged();
        }

        #endregion

        #region 검색
        //// <summary>
        /// 비동기 override 모델
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtMaster = await QueryAsync("GetEquipCode", "00001", values);

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

            grdItem.View.CheckValidation();

            DataTable changed = grdItem.GetChangedRows();

            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion


        #region Private Function

        /// <summary>
        /// 마스터 리스트 그리드의 데이터를 조회한다.
        /// </summary>
        private void LoadDataMasterGrid()
        {
            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            grdMaster.DataSource = SqlExecuter.Query("GetEquipCode", "00001", values);
        }

        /// <summary>
        /// 코드그룹 리스트 그리드의 포커스 행 변경 로직을 처리한다.
        /// </summary>
        private void focusedRowChanged()
        {
            var row = grdMaster.View.GetDataRow(grdMaster.View.FocusedRowHandle);

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_EQUIPMENTID", row["EQUIPMENTID"].ToString());

            if (string.IsNullOrEmpty(row["EQUIPMENTID"].ToString()))
            {
                ShowMessage("NoSelectData");
                grdItem.View.ClearDatas();

                return;
            }

            grdItem.DataSource = SqlExecuter.Query("GetEquipParameter", "00001", param);

        }

        #endregion
    }
}

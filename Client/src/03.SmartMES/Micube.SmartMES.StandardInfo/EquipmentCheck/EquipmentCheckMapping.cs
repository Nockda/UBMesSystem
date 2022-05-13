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
    /// 프 로 그 램 명  : 기준정보 > 설비점검관리 > 설비그룹별점검항목
    /// 업  무  설  명  : 설비그룹별 점검항목을 관리한다.
    /// 생    성    자  : 모세찬
    /// 생    성    일  : 2020-04-03
    /// 수  정  이  력  : 2020-06-16 | scmo | 테이블 및 UI 변경
    /// 
    /// 
    /// </summary>
    public partial class EquipmentCheckMapping : SmartConditionBaseForm
    {
        public EquipmentCheckMapping()
        {
            InitializeComponent();
        }

        #region 컨텐츠 영역 초기화

        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeEvent();

            InitializeClassGrid();
            InitializeListGrid();
        }

        /// <summary>        
        /// 그룹그리드 초기화
        /// </summary>
        private void InitializeClassGrid()
        {
            grdEquipmentClass.GridButtonItem = GridButtonItem.None;
            grdEquipmentClass.View.SetSortOrder("EQUIPMENTCLASSID");
            grdEquipmentClass.View.SetAutoFillColumn("EQUIPMENTCLASSNAME");
            grdEquipmentClass.View.SetIsReadOnly(true);

            grdEquipmentClass.View.AddTextBoxColumn("EQUIPMENTCLASSID", 100)
                .SetTextAlignment(TextAlignment.Center);
            grdEquipmentClass.View.AddTextBoxColumn("EQUIPMENTCLASSNAME", 150)
                .SetTextAlignment(TextAlignment.Center);
            
            grdEquipmentClass.View.PopulateColumns();
        }

        /// <summary>        
        /// 그룹그리드 초기화
        /// </summary>
        private void InitializeListGrid()
        {
            grdList.GridButtonItem = GridButtonItem.All;
            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdList.View.SetSortOrder("MAINTSEQUENCE");

            grdList.View.AddTextBoxColumn("EQUIPMENTCLASSID", 100)
                .SetIsHidden();
            CheckListPopup();
            grdList.View.AddTextBoxColumn("EQUIPCHECKNAME", 200)
                .SetIsReadOnly();
            grdList.View.AddComboBoxColumn("CHECKTYPE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=EquipmentCheckCatecory", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetValidationIsRequired()
                .SetValidationKeyColumn()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("CHECKWAY", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=EquipmentCheckWay", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddSpinEditColumn("CHECKCOUNT", 80)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("CHECKCYCLE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=EquipmentCheckCycle", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("RESULTTYPE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=EquipmentResultWay", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddSpinEditColumn("MAINTSEQUENCE", 50);
            grdList.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetDefault("Valid")
                .SetValidationIsRequired()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);

            grdList.View.PopulateColumns();
        }

        /// <summary>
        /// 점검항목 선택 팝업 컬럼 초기화
        /// </summary>
        private void CheckListPopup()
        {
            var popupColumn = grdList.View.AddSelectPopupColumn("EQUIPCHECKID", new SqlQuery("GetEquipCheckList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}", "P_VALIDSTATE=Valid"))
                .SetPopupLayout("SELECTPARENTCODECLASSID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupResultMapping("EQUIPCHECKID", "EQUIPCHECKID")
                .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                .SetPopupAutoFillColumns("DESCRIPTION")
                .SetValidationKeyColumn()
                .SetValidationIsRequired()
                .SetPopupApplySelection((selectedRows, dataGridRow) =>
                {
                    foreach (DataRow row in selectedRows)
                    {
                        dataGridRow["EQUIPCHECKNAME"] = row["EQUIPCHECKNAME"];
                    }
                });

            popupColumn.GridColumns.AddTextBoxColumn("EQUIPCHECKID", 80);
            popupColumn.GridColumns.AddTextBoxColumn("EQUIPCHECKNAME", 250);
            popupColumn.GridColumns.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
        }

        #endregion

        #region Event
        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            grdEquipmentClass.View.FocusedRowChanged += View_FocusedRowChanged;
            grdList.View.AddingNewRow += View_AddingNewRow;
        }

        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            //  코드 클래스 컬럼에 선택된 코드클래스 ID 자동 세팅
            DataRow focusRow = grdEquipmentClass.View.GetFocusedDataRow();
            string codeClassId = focusRow["EQUIPMENTCLASSID"].ToString();
            args.NewRow["EQUIPMENTCLASSID"] = codeClassId;

            args.NewRow["MAINTSEQUENCE"] = args.NewRow.Table.Rows.Count == 0 ? 1 :
                  args.NewRow.Table.Rows.Cast<DataRow>()
                      .Where(r => r != args.NewRow)
                      .Max(r => decimal.Parse(r["MAINTSEQUENCE"].ToString())) + 1;
        }

        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            grdEquipmentClassFocusedRowChanged();
        }
        #endregion

        #region 툴바
        /// <summary>
        /// 저장버튼 클릭
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable dt = grdList.DataSource as DataTable;
            if(!validContent(dt))
            {
                throw MessageException.Create("AlreadyExistCheckId");
                return;
            }

            DataTable changed = grdList.GetChangedRows();

            ExecuteRule("SaveEquipCheckMapping", changed);
        }

        #endregion


        #region
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtInfo = await QueryAsync("GetEquipmentClassList", "00001", values);

            if (dtInfo.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdEquipmentClass.DataSource = dtInfo;
            grdEquipmentClassFocusedRowChanged();
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

            grdList.View.CheckValidation();

            DataTable changed = grdList.GetChangedRows();

            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function
        private void grdEquipmentClassFocusedRowChanged()
        {
            DataRow dr = grdEquipmentClass.View.GetFocusedDataRow();
            var values = Conditions.GetValues();
            Dictionary<string, object> param = new Dictionary<string, object>();

            param.Add("p_validstate", values["P_VALIDSTATE"]);
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            param.Add("P_EQUIPMENTGROUP", dr["EQUIPMENTCLASSID"]);

            DataTable dtList = SqlExecuter.Query("GetEquipCheckMapp", "00001", param);

            grdList.DataSource = dtList;
        }

        private bool validContent(DataTable dataTable)
        {
            bool bValue = true;

            int i = dataTable.DefaultView.ToTable(true, "EQUIPCHECKID").Rows.Count;
            int j = dataTable.Rows.Count;

            if (i != j)
                bValue = false;

            return bValue;
        }


        #endregion
    }
}

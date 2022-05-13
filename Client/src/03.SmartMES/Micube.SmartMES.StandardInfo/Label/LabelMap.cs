using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using System.Data;
using System.Threading.Tasks;

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 항목관리 > 라벨 맵핑
    /// 업  무  설  명  : 라벨과 품목/팀을 맵핑한다.
    /// 생    성    자  : yshwang
    /// 생    성    일  : 2020-05-21
    /// 수  정  이  력  : 
    /// </summary>
    public partial class LabelMap : SmartConditionBaseForm
    {
        public LabelMap()
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
            InitializeGrid();
            InitializeEvent();
        }

        /// <summary>        
        /// 그리드를 초기화한다.
        /// </summary>
        private void InitializeGrid()
        {
            // 라벨 맵핑
            grdList.GridButtonItem = GridButtonItem.Add | GridButtonItem.Delete | GridButtonItem.Copy | GridButtonItem.Import | GridButtonItem.Export;
            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            grdList.View.AddTextBoxColumn("PRODUCTDEFID", 70).SetIsHidden();
            AddProductDefIdSelectPopup();
            grdList.View.AddTextBoxColumn("PRODUCTDEFVERSION", 70).SetIsHidden();
            grdList.View.AddTextBoxColumn("PRODUCTDEFNAME", 240).SetIsReadOnly();
            grdList.View.AddTextBoxColumn("LABELTYPE", 100).SetIsReadOnly();
            AddLabelIdSelectPopup();
            grdList.View.AddTextBoxColumn("LABELNAME", 280).SetIsReadOnly();
            grdList.View.AddTextBoxColumn("DESCRIPTION", 280);
            grdList.View.AddTextBoxColumn("CREATOR", 90).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            grdList.View.AddTextBoxColumn("CREATEDTIME", 140).SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            grdList.View.AddTextBoxColumn("MODIFIER", 90).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            grdList.View.AddTextBoxColumn("MODIFIEDTIME", 140).SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            grdList.View.PopulateColumns();

            // 라벨 미맵핑 품목
            grdNoLabelProduct.GridButtonItem = GridButtonItem.None;
            grdNoLabelProduct.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            grdNoLabelProduct.View.SetIsReadOnly();
            grdNoLabelProduct.View.AddTextBoxColumn("PARTNUMBER", 150);
            grdNoLabelProduct.View.AddTextBoxColumn("PRODUCTDEFNAME", 260);
            grdNoLabelProduct.View.AddTextBoxColumn("PRODUCTDEFSHORTNAME", 260);
            grdNoLabelProduct.View.AddTextBoxColumn("STANDARD", 130);
            grdNoLabelProduct.View.AddTextBoxColumn("PRODUCTDEFTYPE", 130);
            grdNoLabelProduct.View.AddTextBoxColumn("TEAM", 130);
            grdNoLabelProduct.View.AddTextBoxColumn("MODEL", 130);
            grdNoLabelProduct.View.PopulateColumns();
        }

        /// <summary>
        /// 품목코드 SelectPopup 추가
        /// </summary>
        private void AddProductDefIdSelectPopup()
        {
            var popup = grdList.View.AddSelectPopupColumn("PARTNUMBER", 120,
                new SqlQuery("GetProductDefListPopup", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("SELECTPRODUCTDEF", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetLabel("PRODUCTDEFID")
                .SetPopupLayoutForm(800, 600, System.Windows.Forms.FormBorderStyle.Sizable)
                .SetPopupAutoFillColumns("PRODUCTDEFNAME")
                .SetValidationIsRequired()
                .SetValidationKeyColumn()
                .SetClearButtonInvisible()
                .SetPopupApplySelection((selectedRows, dataGridRow) =>
                {
                    DataRow focusedRow = grdList.View.GetFocusedDataRow();
                    foreach (DataRow row in selectedRows)
                    {
                        focusedRow["PRODUCTDEFID"] = row["PRODUCTDEFID"];
                        focusedRow["PRODUCTDEFVERSION"] = row["PRODUCTDEFVERSION"];
                        focusedRow["PRODUCTDEFNAME"] = row["PRODUCTDEFNAME"];
                    }
                });
            // 조회 컬럼
            popup.GridColumns.AddTextBoxColumn("PRODUCTDEFTYPE", 65);
            popup.GridColumns.AddTextBoxColumn("PRODUCTDEFID", 155).SetIsHidden();
            popup.GridColumns.AddTextBoxColumn("PARTNUMBER", 155).SetLabel("PRODUCTDEFID");
            popup.GridColumns.AddTextBoxColumn("PRODUCTDEFVERSION", 60);
            popup.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 100);
            popup.GridColumns.AddTextBoxColumn("MODEL", 115);

            // 검색조건
            popup.Conditions.AddComboBox("PRODUCTDEFTYPE", new SqlQuery("GetCodeList", "00001"
                , "CODECLASSID=ProductDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetEmptyItem();
            popup.Conditions.AddTextBox("PARTNUMBER");
            popup.Conditions.AddTextBox("PRODUCTDEFNAME");
        }

        /// <summary>
        /// 라벨 ID Select Popup 추가
        /// </summary>
        private void AddLabelIdSelectPopup()
        {
            var popup = grdList.View.AddSelectPopupColumn("LABELID", 280,
                new SqlQuery("GetLabelListPopup", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("SELECTLABEL", PopupButtonStyles.Ok_Cancel, true, true)
                .SetPopupResultCount(1)
                .SetPopupResultMapping("LABELID", "LABELID")
                .SetPopupLayoutForm(800, 600, System.Windows.Forms.FormBorderStyle.Sizable)
                .SetValidationIsRequired()
                .SetValidationKeyColumn()
                .SetClearButtonInvisible()
                .SetPopupApplySelection((selectedRows, dataGridRow) =>
                {
                    DataRow focusedRow = grdList.View.GetFocusedDataRow();
                    foreach (DataRow row in selectedRows)
                    {
                        focusedRow["LABELNAME"] = row["LABELNAME"];
                        focusedRow["LABELTYPE"] = row["LABELTYPE"];
                    }
                });
            // 조회 컬럼
            popup.GridColumns.AddTextBoxColumn("LABELTYPE", 60);
            popup.GridColumns.AddTextBoxColumn("LABELID", 280);
            popup.GridColumns.AddTextBoxColumn("LABELNAME", 280);
            popup.GridColumns.AddTextBoxColumn("DESCRIPTION", 300);

            // 검색조건
            popup.Conditions.AddComboBox("LABELTYPE", new SqlQuery("GetCodeList", "00001"
                , "CODECLASSID=LabelType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetEmptyItem();
            popup.Conditions.AddTextBox("LABELID");
            popup.Conditions.AddTextBox("LABELNAME");
        }

        /// <summary>
        /// 이벤트 등록
        /// </summary>
        private void InitializeEvent()
        {
            grdList.View.AddingNewRow += View_AddingNewRow;
        }

        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            args.NewRow["PRODUCTDEFID"] = "";
            args.NewRow["PRODUCTDEFVERSION"] = "";
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
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            if (smartTabControl1.SelectedTabPageIndex == 0) // 라벨 맵핑
            {
                DataTable dtItem = await QueryAsync("GetLabelMap", "00001", values);
                grdList.DataSource = dtItem;

                if (dtItem.Rows.Count < 1)
                {
                    ShowMessage("NoSelectData");
                }
            }
            else // 라벨 미맵핑 품목 조회
            {
                DataTable dtNoLabel = await QueryAsync("GetProductsWithoutMappedLabel", "00001", values);
                grdNoLabelProduct.DataSource = dtNoLabel;

                if (dtNoLabel.Rows.Count < 1)
                {
                    ShowMessage("NoSelectData");
                }
            }
        }
        #endregion

        #region Tool Bar
        /// <summary>
        /// 툴바의 저장버튼 클릭 이벤트
        /// 변경된 행들을 저장한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            if (smartTabControl1.SelectedTabPageIndex != 0)
            {
                return;
            }
            base.OnToolbarSaveClick();
            DataTable chagnedRows = grdList.GetChangedRows();
            if (chagnedRows.Rows.Count < 1)
            {
                ShowMessage("NoSaveData");
                return;
            }

            ExecuteRule("SaveLabelMap", chagnedRows);
        }
        #endregion

        #region Validation
        /// <summary>
        /// 데이터를 저장 할 때 컨텐츠 영역의 유효성을 검사한다.
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();
            grdList.View.CheckValidation();
        }
        #endregion
    }
}

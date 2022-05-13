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
    public partial class ModelItemMapping : SmartConditionBaseForm
    {
        public ModelItemMapping()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();
            InitializeGrid();
        }

        /// <summary>        
        /// 그리드 초기화
        /// </summary>
        private void InitializeGrid()
        {
            grdMappingList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdMappingList.View.SetSortOrder("MODELID");

            //기종ID
            ClickModelPopup();
            //기종
            grdMappingList.View.AddTextBoxColumn("MODELNAME", 100)
                .SetIsReadOnly();
            //품목ID
            ClickItemPopup();
            //품목
            grdMappingList.View.AddTextBoxColumn("ITEMNAME", 250)
                .SetIsReadOnly();
            //규격
            grdMappingList.View.AddTextBoxColumn("ITEMSTANDARD", 150)
                .SetIsReadOnly();
            //카테고리
            grdMappingList.View.AddTextBoxColumn("ITEMASSETCATEGORY", 100)
                .SetIsReadOnly();
            //내외자구분
            grdMappingList.View.AddTextBoxColumn("DOMESTICFOREIGN", 100)
                .SetIsReadOnly();
            //유효상태
            grdMappingList.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Valid")
               .SetValidationIsRequired();
            //생성자
            grdMappingList.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            //생성일
            grdMappingList.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            //수정자
            grdMappingList.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            //수정일
            grdMappingList.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);

            grdMappingList.View.PopulateColumns();

        }

        #region 검색
        //// <summary>
        /// 비동기 override 모델
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtInfo = await QueryAsync("GetModelItemList", "00001", values);

            if (dtInfo.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdMappingList.DataSource = dtInfo;
        }
        #endregion

        #region ToolBar
        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdMappingList.GetChangedRows();

            ExecuteRule("MappingModelItem", changed);
        }
        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터 저장할때 컨텐츠 영역의 유효성 검사
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();
            grdMappingList.View.CheckValidation();

            DataTable changed = grdMappingList.GetChangedRows();//변경된 row

            if (changed.Rows.Count == 0)
            {
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion


        #region Private Function
        private void ClickModelPopup()
        {
            var popupColumn = grdMappingList.View.AddSelectPopupColumn("MODELID", 150, new SqlQuery("GetModelPopup", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                 .SetPopupLayout("SELECTMODEL", PopupButtonStyles.Ok_Cancel, true, false)
                 .SetPopupResultCount(1)
                 .SetPopupResultMapping("MODELID", "MODELID")
                 .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                 .SetPopupAutoFillColumns("MODELNAME")
                 .SetTextAlignment(TextAlignment.Center)
                 .SetValidationIsRequired()
                 .SetValidationKeyColumn()
            .SetPopupApplySelection((selectedRows, dataGridRow) =>
            {
                DataRow classRow = grdMappingList.View.GetFocusedDataRow();

                foreach (DataRow row in selectedRows)
                {
                    classRow["MODELNAME"] = row["MODELNAME"];
                }
            });
            popupColumn.GridColumns.AddTextBoxColumn("MODELID", 80);
            popupColumn.GridColumns.AddTextBoxColumn("MODELNAME", 100);
        }

        private void ClickItemPopup()
        {
            var popupColumn = grdMappingList.View.AddSelectPopupColumn("ITEMID", 150, new SqlQuery("GetItemPopup", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("SELECTITEM", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupResultMapping("ITEMID", "ITEMID")
                .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                .SetPopupAutoFillColumns("ITEMNAME")
                .SetTextAlignment(TextAlignment.Center)
                .SetValidationIsRequired()
                .SetValidationKeyColumn()

            .SetPopupApplySelection((selectedRows, dataGridRow) =>
            {
                DataRow classRow = grdMappingList.View.GetFocusedDataRow();

                foreach (DataRow row in selectedRows)
                {
                    classRow["ITEMNAME"] = row["ITEMNAME"];
                    classRow["ITEMSTANDARD"] = row["ITEMSTANDARD"];
                    classRow["ITEMASSETCATEGORY"] = row["ITEMASSETCATEGORY"];
                    classRow["DOMESTICFOREIGN"] = row["DOMESTICFOREIGN"];
                }
            });
            popupColumn.GridColumns.AddTextBoxColumn("ITEMID", 100);
            popupColumn.GridColumns.AddTextBoxColumn("ITEMNAME", 150);

            //검색조건
            //popupColumn.Conditions.AddTextBox("TEAM");
            //popupColumn.Conditions.AddComboBox("TEAM", new SqlQuery("GetCodeList", "00001", "CODECLASSID=TeamCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));
        }

        #endregion
    }
}

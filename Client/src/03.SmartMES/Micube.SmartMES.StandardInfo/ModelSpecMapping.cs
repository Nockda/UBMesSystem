#region using

using DevExpress.Xpo.DB.Helpers;
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
    /// 프 로 그 램 명  : 기준정보 > 코드관리 > 기종스펙맵핑
    /// 업  무  설  명  : 기종정보에 스펙정보를 맵핑
    /// 생    성    자  : jylee    
    /// 생    성    일  : 2020-05-04
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class ModelSpecMapping : SmartConditionBaseForm
    {
        public ModelSpecMapping()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeList();
        }
        /// <summary>
        /// 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeList()
        {
            grdMoSpec.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdMoSpec.View.SetSortOrder("MODELID");
            grdMoSpec.View.SetAutoFillColumn("DESCRIPTION");
            //기종ID
            ClickModelPopup();
            //기종
            grdMoSpec.View.AddTextBoxColumn("MODELNAME", 100)
                .SetIsReadOnly();
            //SpecID
            ClickSpecPopup();
            //SpecName
            grdMoSpec.View.AddTextBoxColumn("SPECNAME", 150)
                .SetIsReadOnly();
            //DESCRIPTION
            grdMoSpec.View.AddTextBoxColumn("DESCRIPTION", 100);
            grdMoSpec.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                   .SetTextAlignment(TextAlignment.Center)
                   .SetDefault("Valid")
                   .SetValidationIsRequired();
            grdMoSpec.View.AddTextBoxColumn("CREATOR", 80)
                   .SetIsReadOnly()
                   .SetTextAlignment(TextAlignment.Center);
            grdMoSpec.View.AddTextBoxColumn("CREATEDTIME", 130)
                    .SetIsReadOnly()
                    .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                    .SetTextAlignment(TextAlignment.Center);
            grdMoSpec.View.AddTextBoxColumn("MODIFIER", 80)
                    .SetIsReadOnly()
                    .SetTextAlignment(TextAlignment.Center);
            grdMoSpec.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                    .SetIsReadOnly()
                    .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                    .SetTextAlignment(TextAlignment.Center);

            grdMoSpec.View.PopulateColumns();
        }

        #region Search

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtGrid = await QueryAsync("GetModelSpecList", "00001", values);

            if (dtGrid.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdMoSpec.DataSource = dtGrid;
        }

        #endregion

        #region ToolBar
        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdMoSpec.GetChangedRows();

            ExecuteRule("MappingModelSpec", changed);
        }
        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터 저장할때 컨텐츠 영역의 유효성 검사
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();
            grdMoSpec.View.CheckValidation();

            DataTable changed = grdMoSpec.GetChangedRows();//변경된 row

            if (changed.Rows.Count == 0)
            {
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function
        private void ClickModelPopup()
        {
            var popupColumn = grdMoSpec.View.AddSelectPopupColumn("MODELID", 150, new SqlQuery("GetModelPopup", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
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
                DataRow classRow = grdMoSpec.View.GetFocusedDataRow();

                foreach (DataRow row in selectedRows)
                {
                    classRow["MODELNAME"] = row["MODELNAME"];
                }
            });
            popupColumn.GridColumns.AddTextBoxColumn("MODELID", 80);
            popupColumn.GridColumns.AddTextBoxColumn("MODELNAME", 100);
        }

        private void ClickSpecPopup()
        {
                var popupColumn = grdMoSpec.View.AddSelectPopupColumn("SPECID", 150, new SqlQuery("GetSpecPopup", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                    .SetPopupLayout("SELECTSPEC", PopupButtonStyles.Ok_Cancel, true, false)
                    .SetPopupResultCount(1)
                    .SetPopupResultMapping("SPECID", "SPECID")
                    .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                    .SetPopupAutoFillColumns("SPECNAME")
                    .SetTextAlignment(TextAlignment.Center)
                    .SetValidationIsRequired()
                    .SetValidationKeyColumn()
                .SetPopupApplySelection((selectedRows, dataGridRow) =>
                {
                    DataRow classRow = grdMoSpec.View.GetFocusedDataRow();

                    foreach (DataRow row in selectedRows)
                    {
                        classRow["SPECNAME"] = row["SPECNAME"];
                }
                });
                popupColumn.GridColumns.AddTextBoxColumn("SPECID", 80);
                popupColumn.GridColumns.AddTextBoxColumn("SPECNAME", 100);

                //검색조건
                //popupColumn.Conditions.AddTextBox("TEAM");
                //popupColumn.Conditions.AddComboBox("TEAM", new SqlQuery("GetCodeList", "00001", "CODECLASSID=TeamCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));
            }

        #endregion
    }
}

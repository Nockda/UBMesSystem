
#region using

using DevExpress.XtraEditors.Senders;
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
    /// 프 로 그 램 명  : 기준정보 > 공정편성 > 품목별표준공수관리
    /// 업  무  설  명  : 관리화면
    /// 생    성    자  : jylee    
    /// 생    성    일  : 2020-05-05
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class ScopeByItem : SmartConditionBaseForm
    {
        public ScopeByItem()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeList();
        }

        private void InitializeList()
        {
            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdList.View.SetSortOrder("ITEMID");

            //품목ID
            ClickItemPopup();
            //품명
            grdList.View.AddTextBoxColumn("ITEMNAME", 200)
                .SetIsReadOnly();

            //기종
            grdList.View.AddTextBoxColumn("MODELNAME", 150)
                .SetIsReadOnly();

            //도번
            grdList.View.AddTextBoxColumn("DRAWINGNUMBER", 150)
                .SetIsReadOnly();

            //공정
            grdList.View.AddComboBoxColumn("PROCESSID", 100, new SqlQuery("GetProcessSegment", "00003", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("PROCESSSEGMENT");

            //Team
            grdList.View.AddComboBoxColumn("TEAM", 100, new SqlQuery("GetTeamList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));

            //표준공수
            grdList.View.AddTextBoxColumn("SCOPE", 80);

            //표준공수
            grdList.View.AddTextBoxColumn("STANDARDTIME", 80)
                .SetIsReadOnly();


            grdList.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                   .SetTextAlignment(TextAlignment.Center)
                   .SetDefault("Valid")
                   .SetValidationIsRequired();
            grdList.View.AddTextBoxColumn("CREATOR", 80)
                   .SetIsReadOnly()
                   .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CREATEDTIME", 130)
                    .SetIsReadOnly()
                    .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                    .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("MODIFIER", 80)
                    .SetIsReadOnly()
                    .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                    .SetIsReadOnly()
                    .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                    .SetTextAlignment(TextAlignment.Center);

            grdList.View.PopulateColumns();
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

            DataTable dtGrid = await QueryAsync("GetScopeMgtList", "00001", values);

            if (dtGrid.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdList.DataSource = dtGrid;
        }

        #endregion

        #region ToolBar
        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdList.GetChangedRows();

            ExecuteRule("SaveScopeByItem", changed);
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

            DataTable changed = grdList.GetChangedRows();//변경된 row

            if (changed.Rows.Count == 0)
            {
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion


        private void ClickItemPopup()
        {
            var popupColumn = grdList.View.AddSelectPopupColumn("ITEMID", 150, new SqlQuery("GetItemModelPopup", "00001"))
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
                            DataRow classRow = grdList.View.GetFocusedDataRow();

                            foreach (DataRow row in selectedRows)
                            {
                                classRow["ITEMNAME"] = row["ITEMNAME"];
                                classRow["MODELNAME"] = row["MODELNAME"];
                                classRow["DRAWINGNUMBER"] = row["ITEMSTANDARD"];
                            }
                        });
                 popupColumn.GridColumns.AddTextBoxColumn("ITEMID", 80);
                 popupColumn.GridColumns.AddTextBoxColumn("ITEMNAME", 100);
                 popupColumn.GridColumns.AddTextBoxColumn("MODELNAME", 100);
                 popupColumn.GridColumns.AddTextBoxColumn("ITEMSTANDARD", 100)
                    .SetIsHidden();
        }

    }
}

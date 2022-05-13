
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

/// <summary>
/// 프 로 그 램 명  : 기준정보 > 코드관리 > 공정별기종스팩맵핑
/// 업  무  설  명  : 공정항목, 기종항목, 스팩 맵핑
/// 생    성    자  : 이준용
/// 생    성    일  : 2020-05-13
/// 수  정  이  력  : 
/// 
/// 
/// </summary>
namespace Micube.SmartMES.StandardInfo
{
    public partial class ProcessModelSpecMapping : SmartConditionBaseForm
    {
        public ProcessModelSpecMapping()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdList.View.SetSortOrder("PROCESSID");

            //공정ID
            ClickProcessPopup();
            //공정명
            grdList.View.AddTextBoxColumn("PROCESSNAME", 200)
                .SetIsReadOnly();
            //기종ID
            ClickModelPopup();
            //기종명
            grdList.View.AddTextBoxColumn("MODELNAME", 200)
                 .SetIsReadOnly();
            //스팩ID
            ClickSpecPopup();
            //스팩명
            grdList.View.AddTextBoxColumn("SPECNAME", 200)
                 .SetIsReadOnly();
            //유효상태
            grdList.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                   .SetTextAlignment(TextAlignment.Center)
                   .SetDefault("Valid")
                   .SetValidationIsRequired();
            //등록자
            grdList.View.AddTextBoxColumn("CREATOR", 80)
                     .SetIsReadOnly()
                     .SetTextAlignment(TextAlignment.Center);
            //등록일
            grdList.View.AddTextBoxColumn("CREATEDTIME", 130)
                    .SetIsReadOnly()
                    .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                    .SetTextAlignment(TextAlignment.Center);

            //수정자
            grdList.View.AddTextBoxColumn("MODIFIER", 80)
                    .SetIsReadOnly()
                    .SetTextAlignment(TextAlignment.Center);
            //수정일
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

            DataTable dtSpec = await QueryAsync("GetProcessModelSpecList", "00001", values);

            if (dtSpec.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdList.DataSource = dtSpec;
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

            ExecuteRule("MappingProcessModelSpec", changed);
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

        private void ClickSpecPopup()
        {
            var popupColumn = grdList.View.AddSelectPopupColumn("SPECID", new SqlQuery("GetSpecPopup", "00001"))
        .SetPopupLayout("SELECTSPEC", PopupButtonStyles.Ok_Cancel, true, false)
        .SetPopupResultCount(1)
        .SetPopupResultMapping("SPECID", "SPECID")
        .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
        .SetPopupAutoFillColumns("SPECNAME")
        .SetTextAlignment(TextAlignment.Center)
        .SetValidationKeyColumn()
            .SetPopupApplySelection((selectedRows, dataGridRow) =>
            {
                DataRow classRow = grdList.View.GetFocusedDataRow();

                foreach (DataRow row in selectedRows)
                {
                    classRow["SPECNAME"] = row["SPECNAME"];
                }
            });
            popupColumn.GridColumns.AddTextBoxColumn("SPECID", 80);
            popupColumn.GridColumns.AddTextBoxColumn("SPECNAME", 100);

            //팝업 검색조건
            popupColumn.Conditions.AddComboBox("P_SPECGROUPNAME", new SqlQuery("GetComboSpecGroup", "00001"))
                .SetValidationIsRequired();
        }

        private void ClickModelPopup()
        {
            var popupColumn = grdList.View.AddSelectPopupColumn("MODELID", new SqlQuery("GetModelPopup", "00001"))
                     .SetPopupLayout("SELECTMODEL", PopupButtonStyles.Ok_Cancel, true, false)
                     .SetPopupResultCount(1)
                     .SetPopupResultMapping("MODELID", "MODELID")
                     .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                     .SetPopupAutoFillColumns("MODELNAME")
                     .SetTextAlignment(TextAlignment.Center)
                     .SetValidationKeyColumn()
                         .SetPopupApplySelection((selectedRows, dataGridRow) =>
                         {
                             DataRow classRow = grdList.View.GetFocusedDataRow();

                             foreach (DataRow row in selectedRows)
                             {
                                 classRow["MODELNAME"] = row["MODELNAME"];
                             }
                         });
            popupColumn.GridColumns.AddTextBoxColumn("MODELID", 80);
            popupColumn.GridColumns.AddTextBoxColumn("MODELNAME", 100);

            //팝업 검색조건
            popupColumn.Conditions.AddComboBox("P_MODELGROUPNAME", new SqlQuery("GetComboModelGroup", "00001"))
                .SetValidationIsRequired();
        }

        private void ClickProcessPopup()
        {
            var popupColumn = grdList.View.AddSelectPopupColumn("PROCESSID", new SqlQuery("GetProcessPopup", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                    .SetPopupLayout("SELECTPROCESS", PopupButtonStyles.Ok_Cancel, true, false)
                    .SetPopupResultCount(1)
                    .SetPopupResultMapping("PROCESSID", "PROCESSID")
                    .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                    .SetPopupAutoFillColumns("PROCESSNAME")
                    .SetTextAlignment(TextAlignment.Center)
                    .SetValidationKeyColumn()
                          .SetPopupApplySelection((selectedRows, dataGridRow) =>
                          {
                              DataRow classRow = grdList.View.GetFocusedDataRow();

                              foreach (DataRow row in selectedRows)
                              {
                                  classRow["PROCESSNAME"] = row["PROCESSNAME"];
                              }
                          });
            popupColumn.GridColumns.AddTextBoxColumn("PROCESSID", 80);
            popupColumn.GridColumns.AddTextBoxColumn("PROCESSNAME", 100);
        }
    }
}

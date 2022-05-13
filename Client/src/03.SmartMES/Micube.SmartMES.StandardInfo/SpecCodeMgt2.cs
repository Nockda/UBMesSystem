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
    public partial class SpecCodeMgt2 : SmartConditionBaseForm
    {
        #region 생성자

        public SpecCodeMgt2()
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// 화면의 컨텐츠 영역을 초기화한다.
        /// </summary>
        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeEvent();

            // 컨트롤 초기화 로직 구성
            InitializeGrid();
        }

        /// <summary>        
        /// 코드그룹 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeGrid()
        {
            //그리드 초기화
            grdSpec.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdSpec.View.SetIsReadOnly();
            grdSpec.View.SetSortOrder("SEQ");

            //SEQ
            grdSpec.View.AddTextBoxColumn("SEQ", 100);
            //공정ID
            ClickProcessPopup();
            //공정
            grdSpec.View.AddTextBoxColumn("PROCESSNAME", 200);
            //스팩ID
            ClickSpecPopup();
            //스팩
            grdSpec.View.AddTextBoxColumn("SPECNAME", 200);
            //세부공정ID
            grdSpec.View.AddTextBoxColumn("SUBPROCESSID", 150);
            //세부공정
            grdSpec.View.AddTextBoxColumn("SUBPROCESSNAME", 200);
            //입력항목
            grdSpec.View.AddTextBoxColumn("INPUTITEM", 250);
            //단위
            grdSpec.View.AddTextBoxColumn("UNIT", 100);
            //스팩MIN
            grdSpec.View.AddTextBoxColumn("SPECMIN", 100)
                .SetTextAlignment(TextAlignment.Right);
            //스팩MAX
            grdSpec.View.AddTextBoxColumn("SPECMAX", 100)
                .SetTextAlignment(TextAlignment.Right);
            //유효상태
            grdSpec.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                   .SetTextAlignment(TextAlignment.Center)
                   .SetDefault("Valid")
                   .SetValidationIsRequired();
            grdSpec.View.AddTextBoxColumn("CREATOR", 80)
                 .SetIsReadOnly()
                 .SetTextAlignment(TextAlignment.Center);
            grdSpec.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);
            grdSpec.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdSpec.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetIsReadOnly()
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);

            grdSpec.View.PopulateColumns();
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

            DataTable dtSpec = await QueryAsync("GetSpecList", "00001", values);

            if (dtSpec.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdSpec.DataSource = dtSpec;
        }
        #endregion
        private void ClickSpecPopup()
        {
            var popupColumn = grdSpec.View.AddSelectPopupColumn("SPECID", new SqlQuery("GetSpecPopup", "00001"))
        .SetPopupLayout("SELECTSPEC", PopupButtonStyles.Ok_Cancel, true, false)
        .SetPopupResultCount(1)
        .SetPopupResultMapping("SPECID", "SPECID")
        .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
        .SetPopupAutoFillColumns("SPECNAME")
        .SetTextAlignment(TextAlignment.Center)
        .SetValidationKeyColumn()
            .SetPopupApplySelection((selectedRows, dataGridRow) =>
            {
                DataRow classRow = grdSpec.View.GetFocusedDataRow();

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
        private void ClickProcessPopup()
        {
            var popupColumn = grdSpec.View.AddSelectPopupColumn("PROCESSID", new SqlQuery("GetProcessPopup", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                    .SetPopupLayout("SELECTPROCESS", PopupButtonStyles.Ok_Cancel, true, false)
                    .SetPopupResultCount(1)
                    .SetPopupResultMapping("PROCESSID", "PROCESSID")
                    .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                    .SetPopupAutoFillColumns("PROCESSNAME")
                    .SetTextAlignment(TextAlignment.Center)
                    .SetValidationKeyColumn()
                          .SetPopupApplySelection((selectedRows, dataGridRow) =>
                          {
                              DataRow classRow = grdSpec.View.GetFocusedDataRow();

                              foreach (DataRow row in selectedRows)
                              {
                                  classRow["PROCESSNAME"] = row["PROCESSNAME"];
                              }
                          });
            popupColumn.GridColumns.AddTextBoxColumn("PROCESSID", 80);
            popupColumn.GridColumns.AddTextBoxColumn("PROCESSNAME", 100);
        }

        private void InitializeEvent()
        {
            
        }
    }
}

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
    /// 프 로 그 램 명  : 기준정보 > 공정편성 > 작업장(공정)별 사용자 관리
    /// 업  무  설  명  : 공정별 사용자를 맵핑
    /// 생    성    자  : 이준용
    /// 생    성    일  : 2020-05-05
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class UserInfoByArea2 : SmartConditionBaseForm
    {
        #region 생성자

        public UserInfoByArea2()
        {
            InitializeComponent();
        }

        #endregion

        #region 컨텐츠 영역 초기화

        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeGrid();
        }

        private void InitializeGrid()
        {
            grdUserArea.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdUserArea.View.SetSortOrder("AREAID");

            //작업장
            grdUserArea.View.AddComboBoxColumn("AREAID", 150, new SqlQuery("GetCodeList", "00001", "CODECLASSID=AreaCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                    .SetTextAlignment(TextAlignment.Center)
                    .SetValidationKeyColumn()
                    .SetValidationIsRequired();

            //공정
            grdUserArea.View.AddComboBoxColumn("PROCESSID", 150, new SqlQuery("GetComboProcessLargeCategory", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                    .SetTextAlignment(TextAlignment.Center)
                    .SetValidationKeyColumn()
                    .SetValidationIsRequired();

            //사용자ID(Hidden)
            grdUserArea.View.AddTextBoxColumn("USERID", 150)
                .SetIsHidden();

            //사용자
                ClickUserNamePopup();

            //직위
            grdUserArea.View.AddTextBoxColumn("POSITION", 150)
                .SetIsReadOnly();

            //Team
            grdUserArea.View.AddTextBoxColumn("TEAM", 150)
                .SetIsReadOnly();

            //유효상태
            grdUserArea.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                   .SetTextAlignment(TextAlignment.Center)
                   .SetDefault("Valid")
                   .SetValidationIsRequired();
            //등록자
            grdUserArea.View.AddTextBoxColumn("CREATOR", 80)
                     .SetIsReadOnly()
                     .SetTextAlignment(TextAlignment.Center);
            //등록일
            grdUserArea.View.AddTextBoxColumn("CREATEDTIME", 130)
                    .SetIsReadOnly()
                    .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                    .SetTextAlignment(TextAlignment.Center);
            
            //수정자
            grdUserArea.View.AddTextBoxColumn("MODIFIER", 80)
                    .SetIsReadOnly()
                    .SetTextAlignment(TextAlignment.Center);
            //수정일
            grdUserArea.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                    .SetIsReadOnly()
                    .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                    .SetTextAlignment(TextAlignment.Center);

            grdUserArea.View.PopulateColumns();


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

            DataTable dtUserArea = await QueryAsync("GetUserInfoByAreaList", "00001", values);

            if (dtUserArea.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdUserArea.DataSource = dtUserArea;
        }

        #endregion

        #region ToolBar
        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdUserArea.GetChangedRows();

            ExecuteRule("SaveUserInfoByArea", changed);
        }
        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터 저장할때 컨텐츠 영역의 유효성 검사
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();
            grdUserArea.View.CheckValidation();

            DataTable changed = grdUserArea.GetChangedRows();//변경된 row

            if (changed.Rows.Count == 0)
            {
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        private void ClickUserNamePopup()
        {
            var popupColumn = grdUserArea.View.AddSelectPopupColumn("USERNAME", new SqlQuery("GesUserPopup", "00001"))
                    .SetPopupLayout("SELECTUSER", PopupButtonStyles.Ok_Cancel, true, false)
                    .SetPopupResultCount(1)
                    .SetPopupResultMapping("USERNAME", "USERNAME")
                    .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                    .SetPopupAutoFillColumns("USERNAME")
                    .SetTextAlignment(TextAlignment.Center)
                                    .SetPopupApplySelection((selectedRows, dataGridRow) =>
                                    {
                                        DataRow classRow = grdUserArea.View.GetFocusedDataRow();

                                        foreach (DataRow row in selectedRows)
                                        {
                                            classRow["USERID"] = row["USERID"];
                                            classRow["POSITION"] = row["POSITION"];
                                            classRow["TEAM"] = row["TEAM"];
                                        }
                                    });
            popupColumn.GridColumns.AddTextBoxColumn("TEAM", 80);
            popupColumn.GridColumns.AddTextBoxColumn("USERNAME", 100);

            //팝업 검색조건
            popupColumn.Conditions.AddComboBox("TEAM", new SqlQuery("GetCodeList", "00001", "CODECLASSID=TeamCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));
        }

    }
}

using DevExpress.Charts.Native;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Spreadsheet.Formulas;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Helpers;
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

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 코드관리 > 공정코드
    /// 업  무  설  명  : 공정코드를 관리한다.
    /// 생    성    자  : 
    /// 생    성    일  : 
    /// 수  정  이  력  : 2020-05-07 유태근 / 신규컬럼 입력 및 다국어 수정
    /// 
    /// </summary>
    public partial class ProcessCode2 : SmartConditionBaseForm
    {
        #region 생성자

        public ProcessCode2()
        {
            InitializeComponent();
        }

        #endregion

        #region 컨텐츠영역 초기화

        protected override void InitializeContent()
        {
            base.InitializeContent();
            InitializeProcessGrid();
            InitializeEvent();
        }

        private void InitializeProcessGrid()
        {
            grdProcess.GridButtonItem = GridButtonItem.All;
            grdProcess.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdProcess.View.SetSortOrder("PROCESSSEGMENTID");
            grdProcess.View.SetAutoFillColumn("DESCRIPTION");

            //공정ID
            grdProcess.View.AddTextBoxColumn("PROCESSSEGMENTID", 100)
                .SetValidationKeyColumn()
                .SetTextAlignment(TextAlignment.Center);
            //공정명 
            grdProcess.View.AddLanguageColumn("PROCESSSEGMENTNAME", 150);
            //공정그룹
            grdProcess.View.AddComboBoxColumn("PROCESSSEGMENTCLASSID", 80, new SqlQuery("GetProcessSegmentClass", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            //설명
            grdProcess.View.AddTextBoxColumn("DESCRIPTION", 200);
            //작업지시유무
            //grdProcess.View.AddComboBoxColumn("WORKORDER", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YESNO", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
            //      .SetTextAlignment(TextAlignment.Center);
            //공정타입
            grdProcess.View.AddComboBoxColumn("PROCESSSEGMENTTYPE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=MainSubType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                  .SetTextAlignment(TextAlignment.Center);
            //검사실적유무
            grdProcess.View.AddComboBoxColumn("CHECKRESULT", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YESNO", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                  .SetTextAlignment(TextAlignment.Center);
            //메인공정여부                   
            grdProcess.View.AddComboBoxColumn("ISMAINPROCESSSEGMENT", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YESNO", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                  .SetTextAlignment(TextAlignment.Center);
                  
            
            /*
             * 2020-06-04 유태근 / 새로운 입력필드 추가 (사용자 Lot번호 입력여부, Lot채번 룰 ID)
             */

            //사용자 Lot번호 입력여부
            grdProcess.View.AddComboBoxColumn("ISUSEUSERLOTSERIAL", 120, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YesNo", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            //Lot채번 룰 ID
            grdProcess.View.AddComboBoxColumn("LOTCREATERULEID", 120, new SqlQuery("GetCodeList", "00001", "CODECLASSID=LotCreateRule", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"));
            //유효상태
            grdProcess.View.AddComboBoxColumn("VALIDSTATE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Valid")
               .SetValidationIsRequired();
            grdProcess.View.AddTextBoxColumn("PLANTID")
                .SetDefault(UserInfo.Current.Plant)
                .SetIsHidden();
            grdProcess.View.AddTextBoxColumn("ENTERPRISEID")
                .SetDefault(UserInfo.Current.Enterprise)
                .SetIsHidden();
            //생성자
            grdProcess.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            //생성일
            grdProcess.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            //수정자
            grdProcess.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            //수정일
            grdProcess.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);

            grdProcess.View.PopulateColumns();

        }

        #endregion

        #region 검색

        /// <summary>
        /// 비동기 override 모델
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtInfo = await QueryAsync("GetProcessList", "00001", values);

            if (dtInfo.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdProcess.DataSource = dtInfo;
        }

        #endregion

        #region 툴바

        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdProcess.GetChangedRows();

            checkMainOrSubRequired(changed);

            ExecuteRule("SaveProcessCode2", changed);
        }

        #endregion

        #region Event
        private void InitializeEvent()
        {
            grdProcess.View.ShowingEditor += View_ShowingEditor;
        }

        private void View_ShowingEditor(object sender, CancelEventArgs e)
        {
            DataRow row = grdProcess.View.GetFocusedDataRow();
            string focusColumn = grdProcess.View.FocusedColumn.FieldName;

            if (row["PROCESSSEGMENTTYPE"].ToString().Equals("MAIN"))
            {
                if (focusColumn.Equals("PROCESSSEGMENTCLASSID"))
                {
                    e.Cancel = false;
                }

            }
            else if (row["PROCESSSEGMENTTYPE"].ToString().Equals("SUB")) 
            {
                if (focusColumn.Equals("PROCESSSEGMENTCLASSID"))
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터 저장할때 컨텐츠 영역의 유효성 검사
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();
            grdProcess.View.CheckValidation();

            DataTable changed = grdProcess.GetChangedRows();//변경된 row

            if (changed.Rows.Count == 0)
            {
                throw MessageException.Create("NoSaveData");
            }

        }

        private void checkMainOrSubRequired(DataTable changed)
        {
            foreach (DataRow row in changed.Rows)
            {
                if (row["PROCESSSEGMENTTYPE"].ToString().Equals("MAIN"))
                {
                    if (row["PROCESSSEGMENTCLASSID"] == DBNull.Value)
                     { 
                        //메인공정은 공정그룹 선택이 필수입니다.
                        throw MessageException.Create("RequiredProcessClass");
                     }
                }
            }
        }

        #endregion

    }
}

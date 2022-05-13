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
    /// 프 로 그 램 명  : 기준정보 > 공정편성 > 공정기종별 기준서 등록
    /// 업  무  설  명  : 공정기종별 기준서를 등록한다
    /// 생    성    자  : 한주석
    /// 생    성    일  : 2020-06-04
    /// 수  정  이  력  : 2022-05-10 LJG 기종컬럼 팝업으로 교체
    /// 
    /// 
    /// </summary>
    public partial class ProcessStandarad : SmartConditionBaseForm
    {
        #region Local Variables

        // TODO : 화면에서 사용할 내부 변수 추가
        string _Text;                                       // 설명

        #endregion

        #region 생성자

        public ProcessStandarad()
        {
            InitializeComponent();
        }

        #endregion

        #region 컨텐츠 영역 초기화

        /// <summary>
        /// 화면의 컨텐츠 영역을 초기화한다.
        /// </summary>
        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeEvent();

            // TODO : 컨트롤 초기화 로직 구성
            InitializeGrid();
        }

        /// <summary>        
        /// 코드그룹 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeGrid()
        {
           
            grdprocesslist.GridButtonItem = GridButtonItem.All;
            // 공정
            grdprocesslist.View.AddComboBoxColumn("PROCESSSEGMENTID", 100, new SqlQuery("GetProcessSegment", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetValidationIsRequired()
                .SetLabel("PROCESSSEGMENT");
            // 기종
            //grdprocesslist.View.AddComboBoxColumn("MODELID", 100, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ModelCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
            //    .SetValidationIsRequired();
            
            InitializePopup_ModelId(); //2022-05-10 LJG 기종컬럼 팝업으로 교체

            //기준서1
            grdprocesslist.View.AddTextBoxColumn("STANDARD1", 100);
            //기준서2
            grdprocesslist.View.AddTextBoxColumn("STANDARD2", 100);
            //기준서3
            grdprocesslist.View.AddTextBoxColumn("STANDARD3", 100);
            //생성자
            grdprocesslist.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            //생성일
            grdprocesslist.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            //수정자
            grdprocesslist.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            //수정일
            grdprocesslist.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);

            grdprocesslist.View.PopulateColumns();
        }

        /// <summary>
        /// 팝업형 컬럼 초기화 - 기종
        /// </summary>
        private void InitializePopup_ModelId()
        {
            var popupColumn = grdprocesslist.View.AddSelectPopupColumn("MODELID", 100, new SqlQuery("GetModelPopup", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("SELECTMODEL", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupResultMapping("MODELID", "CODEID")
                .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                .SetPopupAutoFillColumns("CODENAME")
                .SetValidationIsRequired()
                .SetTextAlignment(TextAlignment.Center)
                .SetPopupApplySelection((selectedRows, dataGridRow) =>
                {
                    DataRow row = selectedRows.FirstOrDefault();
                    if (row == null)
                    {
                        dataGridRow["MODELID"] = string.Empty;
                        return;
                    }
                    else
                    {
                        dataGridRow["MODELID"] = row["CODEID"];
                    }
                })
                .SetLabel("MODELID");

            //검색조건
            popupColumn.Conditions.AddTextBox("TXTMODELID");

            popupColumn.GridColumns.AddComboBoxColumn("PROCESSSEGMENTID", 100, new SqlQuery("GetProcessSegment", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("PROCESSSEGMENT");
            popupColumn.GridColumns.AddTextBoxColumn("CODEID", 80).SetLabel("MODELID");
            popupColumn.GridColumns.AddTextBoxColumn("CODENAME", 100).SetLabel("MODELNAME");
        }



        #endregion
        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {

        }

        /// <summary>
        /// 코드그룹 리스트 그리드에서 추가 버튼 클릭 시 호출
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 툴바

        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

                 DataTable changed = grdprocesslist.GetChangedRows();

                 ExecuteRule("SaveProcessStandard", changed);
        }

        #endregion

        #region 검색

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            // TODO : 조회 SP 변경
            var values = Conditions.GetValues();

            DataTable dtCodeClass = SqlExecuter.Query("SelectProcessSegmentStandard", "00001", values);

            if (dtCodeClass.Rows.Count < 1) // 검색 조건에 해당하는 코드를 포함한 코드클래스가 없는 경우
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }

            grdprocesslist.DataSource = dtCodeClass;
        }

        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

            // TODO : 조회조건 추가 구성이 필요한 경우 사용
        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

            // TODO : 조회조건의 컨트롤에 기능 추가가 필요한 경우 사용
        }

        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터를 저장 할 때 컨텐츠 영역의 유효성을 검사한다.
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();

            // TODO : 유효성 로직 변경
            grdprocesslist.View.CheckValidation();

            DataTable changed = grdprocesslist.GetChangedRows();

            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function

        // TODO : 화면에서 사용할 내부 함수 추가
        /// <summary>
        /// 마스터 정보를 조회한다.
        /// </summary>
        private void LoadData()
        {

        }

        #endregion
    }
}
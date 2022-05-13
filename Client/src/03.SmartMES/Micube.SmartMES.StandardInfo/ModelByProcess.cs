#region using
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;

using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 공정 관리 > 공정별 기종 등록
    /// 업  무  설  명  : 공정별로 기종을 등록한다
    /// 생    성    자  : 한주석
    /// 생    성    일  : 2020-06-30
    /// 수  정  이  력  : 
    /// </summary>
    public partial class ModelByProcess : SmartConditionBaseForm
    {
        #region Local Variables
        // TODO : 화면에서 사용할 내부 변수 추가
        string _Text;                                       // 설명
        #endregion

        #region 생성자
        public ModelByProcess()
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
            // TODO : 그리드 초기화 로직 추가
            grdprocess.GridButtonItem = GridButtonItem.Expand | GridButtonItem.Restore;
            // 공정ID
            grdprocess.View.AddTextBoxColumn("PROCESSSEGMENTID", 100)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            // 공정명
            grdprocess.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 150)
                .SetIsReadOnly();
            // 모델수
            grdprocess.View.AddTextBoxColumn("MODELNUMBER", 100)
                .SetTextAlignment(TextAlignment.Right)
                .SetIsReadOnly();
            grdprocess.View.PopulateColumns();


            grdmodel.GridButtonItem = GridButtonItem.All;
            // 공정ID
            grdmodel.View.AddTextBoxColumn("PROCESSSEGMENTID", 100)
                .SetIsReadOnly()
                .SetIsHidden();
            grdmodel.View.AddTextBoxColumn("PROCESSSEGMENTVERSION", 80)
                 .SetIsReadOnly()
                 .SetIsHidden();
            //기종
            InitializeGrid_ModelListPopup();
            grdmodel.View.AddTextBoxColumn("MODELID")
                .SetIsHidden();
            //PLANT
            grdmodel.View.AddTextBoxColumn("PLANTID", 80)
                .SetDefault(UserInfo.Current.Plant)
                .SetIsHidden();
            //ENTERPRISE
            grdmodel.View.AddTextBoxColumn("ENTERPRISEID", 80)
                .SetDefault(UserInfo.Current.Enterprise)
                .SetIsHidden();
            //유효상태
            grdmodel.View.AddComboBoxColumn("VALIDSTATE", 100, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetDefault("Valid")
                .SetValidationIsRequired()
                .SetTextAlignment(TextAlignment.Center);
            //생성자
            grdmodel.View.AddTextBoxColumn("CREATOR", 150)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            //생성일시
            grdmodel.View.AddTextBoxColumn("CREATEDTIME", 140)
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetIsReadOnly();
            //수정자
            grdmodel.View.AddTextBoxColumn("MODIFIER", 150)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            //수정일시
            grdmodel.View.AddTextBoxColumn("MODIFIEDTIME", 140)
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetIsReadOnly();
            grdmodel.View.PopulateColumns();
        }

        /// <summary>
        /// 팝업형 컬럼 초기화 - 기종
        /// </summary>
        private void InitializeGrid_ModelListPopup()
        {
            var popupColumn = grdmodel.View.AddSelectPopupColumn("MODELNAME", 130
                    , new SqlQuery("GetCodeList", "00001", "CODECLASSID=ModelCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("SELECTMODEL", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupResultMapping("MODELNAME", "CODENAME")
                .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                .SetPopupAutoFillColumns("CODENAME")
                .SetValidationKeyColumn()
                .SetTextAlignment(TextAlignment.Left)
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
            grdprocess.View.FocusedRowChanged += View_FocusedRowChanged;
            grdmodel.View.AddingNewRow += View_AddingNewRow1;
        }

        private void View_AddingNewRow1(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            DataRow dr = grdprocess.View.GetFocusedDataRow();
            args.NewRow["PROCESSSEGMENTID"] = dr["PROCESSSEGMENTID"];
            args.NewRow["PROCESSSEGMENTVERSION"] = "*";
        }

        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            grdAreaFocusedRowChanged();
        }
        #endregion

        #region 툴바
        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();
            // TODO : 저장 Rule 변경
            DataTable changed = grdmodel.GetChangedRows();
            ExecuteRule("SaveModelByProcess", changed);
            grdAreaFocusedRowChanged();
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
            values.Add("P_LANGUAGETYPE", UserInfo.Current.LanguageType);
            DataTable dtCodeClass = SqlExecuter.Query("GetProcessSegment", "00004", values);
            if (dtCodeClass.Rows.Count < 1) // 검색 조건에 해당하는 코드를 포함한 코드클래스가 없는 경우
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }
            grdprocess.DataSource = dtCodeClass;
            grdAreaFocusedRowChanged();
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
            grdmodel.View.CheckValidation();
            DataTable changed = grdmodel.GetChangedRows();
            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }
        #endregion

        #region Private Function
        private void grdAreaFocusedRowChanged()
        {
            DataRow dr = grdprocess.View.GetFocusedDataRow();
            var values = Conditions.GetValues();
            Dictionary<string, object> param = new Dictionary<string, object>();
            if (!values["P_PROCESSSEGMENT"].Equals("*"))
            {
                grdprocess.View.FocusedRowHandle = 0;
                dr = grdprocess.View.GetFocusedDataRow();
                param.Add("P_PROCESSSEGMENT", dr["PROCESSSEGMENTID"]);
            }
            else
            {
                param.Add("P_PROCESSSEGMENT", dr["PROCESSSEGMENTID"]);
            }
            param.Add("p_validstate", values["P_VALIDSTATE"]);
            param.Add("P_LANGUAGETYPE", UserInfo.Current.LanguageType);
            DataTable dtmodel = SqlExecuter.Query("GetModelByProcess", "00001", param);
            grdmodel.DataSource = dtmodel;
        }
        #endregion
    }
}
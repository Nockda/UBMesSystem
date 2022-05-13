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
    /// 프 로 그 램 명  : 기준정보 > 코드관리 > 설비그룹
    /// 업  무  설  명  : 설비들의 상위코드를 관리하는 화면이다.
    /// 생    성    자  : 유태근
    /// 생    성    일  : 2020-06-05
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class EquipmentClass : SmartConditionBaseForm
    {
        #region Local Variables

        #endregion

        #region 생성자

        public EquipmentClass()
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
            InitializeGrid();
        }

        /// <summary>        
        /// 설비그룹 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeGrid()
        {
            grdEquipmentClass.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdEquipmentClass.View.SetAutoFillColumn("DESCRIPTION");

            grdEquipmentClass.View.AddTextBoxColumn("EQUIPMENTCLASSID", 120)
                .SetIsReadOnly(); // 설비그룹 ID
            grdEquipmentClass.View.AddLanguageColumn("EQUIPMENTCLASSNAME", 150); // 설비그룹명(다국어)
            grdEquipmentClass.View.AddTextBoxColumn("DESCRIPTION", 180); // 비고사항
            grdEquipmentClass.View.AddComboBoxColumn("VALIDSTATE", 100, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ValidState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center)
               .SetDefault("Valid")
               .SetValidationIsRequired(); // 사용여부
            grdEquipmentClass.View.AddTextBoxColumn("CREATOR", 100)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly(); // 생성자
            grdEquipmentClass.View.AddTextBoxColumn("CREATEDTIME", 200)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly(); // 생성일시
            grdEquipmentClass.View.AddTextBoxColumn("MODIFIER", 100)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly(); // 수정자
            grdEquipmentClass.View.AddTextBoxColumn("MODIFIEDTIME", 200)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly(); // 수정일시

            grdEquipmentClass.View.AddTextBoxColumn("ENTERPRISEID", 100)
                .SetIsHidden(); // 회사 ID
            grdEquipmentClass.View.AddTextBoxColumn("PLANTID", 100)
                .SetIsHidden(); // Plant ID

            grdEquipmentClass.View.PopulateColumns();

            grdEquipmentClass.View.OptionsNavigation.AutoMoveRowFocus = false;
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            grdEquipmentClass.View.AddingNewRow += View_AddingNewRow;
        }

        /// <summary>
        /// 행 추가시 필요한 데이터 바인딩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void View_AddingNewRow(Framework.SmartControls.Grid.BandedGrid.SmartBandedGridView sender, Framework.SmartControls.Grid.AddNewRowArgs args)
        {
            args.NewRow["ENTERPRISEID"] = UserInfo.Current.Enterprise;
            args.NewRow["PLANTID"] = UserInfo.Current.Plant;
        }

        #endregion

        #region 툴바

        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdEquipmentClass.GetChangedRows();

            ExecuteRule("SaveEquipmentClass", changed);
        }

        #endregion

        #region 검색

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("P_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dt = await QueryAsync("SelectEquipmentClass", "00001", values);

            if (dt.Rows.Count < 1) 
            {
                this.ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
                grdEquipmentClass.DataSource = null;
                
            }

            grdEquipmentClass.DataSource = dt;
        }

        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

            Conditions.AddTextBox("P_EQUIPMENTCLASSIDNAME")
                .SetPosition(0)
                .SetLabel("EQUIPMENTCLASSIDNAME"); // 설비그룹 ID / 명 조회조건
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
            grdEquipmentClass.View.CheckValidation();

            DataTable changed = grdEquipmentClass.GetChangedRows();

            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function 

        #endregion
    }
}
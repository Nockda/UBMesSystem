#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;

using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

#endregion

namespace Micube.SmartMES.Equipment
{
    /// <summary>
    /// 프 로 그 램 명  : 설비관리 > 설비점검 > 설비일상점검모니터링
    /// 업  무  설  명  : 설비일상점검표를 모니터링한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-04-10
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class ParameterMonitoring : SmartConditionBaseForm
    {
        public ParameterMonitoring()
        {
            InitializeComponent();
        }

        #region 컨텐츠 영역 초기화    

        /// <summary>
        /// 화면의 컨텐츠 영역을 초기화한다.
        /// </summary>
        protected override void InitializeContent()
        {
            base.InitializeContent();

            // 컨트롤 초기화 로직 구성
            InitializeGrid();
            InitializeEvent();

        }

        /// <summary>        
        /// 그리드 초기화
        /// </summary>
        private void InitializeGrid()
        {
            grdInfo.GridButtonItem = GridButtonItem.Export;
            grdInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            grdInfo.View.SetIsReadOnly();

            //grdInfo.View.SetSortOrder("EQUIPMENTCHECKID");
            //grdInfo.View.SetAutoFillColumn("EQUIPMENTCHECKNAME");

            //grdInfo.View.AddTextBoxColumn("CHECKMONTH", 80);
            grdInfo.View.AddTextBoxColumn("AREAID", 100).SetIsReadOnly();
            grdInfo.View.AddTextBoxColumn("EQUIPMENTCLASSID", 100).SetIsReadOnly();
            grdInfo.View.AddTextBoxColumn("EQUIPMENTID", 100).SetIsReadOnly();
            grdInfo.View.AddTextBoxColumn("EQUIPMENTNAME", 250).SetIsReadOnly();
            grdInfo.View.AddTextBoxColumn("PARAMETERID", 200).SetIsReadOnly();
            grdInfo.View.AddTextBoxColumn("PARAMETERNAME", 250).SetIsReadOnly();
            grdInfo.View.AddTextBoxColumn("VALUE", 80).SetIsReadOnly();
            //grdInfo.View.AddSpinEditColumn("VAULE", 80).SetDisplayFormat("#,##0.##", MaskTypes.Numeric, true);
            grdInfo.View.AddTextBoxColumn("CREATEDTIME", 130).SetIsReadOnly().SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetTextAlignment(TextAlignment.Center);

            grdInfo.View.PopulateColumns();
        }

        /// <summary>        
        /// 그리드 초기화
        /// </summary>
        private void InitializeEvent()
        {
            
        }
        #endregion

        #region 조회조건 구성
        protected override void InitializeCondition()
        {
            base.InitializeCondition();
            InitializeCondition_Parameter();
            // TODO : 조회조건 추가 구성이 필요한 경우 사용
        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();


            
            Conditions.GetControl<SmartComboBox>("p_equipmentGroup").EditValueChanged += EquipDailyCheckMonitoring_EditValueChanged;

        }

        private void EquipDailyCheckMonitoring_EditValueChanged(object sender, EventArgs e)
        {
            
            SqlQuery condition = new SqlQuery("GetEquipCode", "00002", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}", $"P_EQUIPMENTGROUP={Conditions.GetControl<SmartComboBox>("p_equipmentGroup").EditValue}");
            DataTable conditionTable = condition.Execute();
            Conditions.GetControl<SmartComboBox>("p_Equipment").ValueMember = "EQUIPMENTID";
            Conditions.GetControl<SmartComboBox>("p_Equipment").DisplayMember = "EQUIPMENTNAME";
            Conditions.GetControl<SmartComboBox>("p_Equipment").DataSource = conditionTable;
            Conditions.GetControl<SmartComboBox>("p_Equipment").EditValue = "*";
            


        }
        /// <summary>
		/// 팝업형 조회조건 생성 - 공정
		/// </summary>
		private void InitializeCondition_Parameter()
        {
            var parameterID = Conditions.AddSelectPopup("PARAMETERID", new SqlQuery("GetParameterDefList", "00002", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetPopupLayout("PARAMETERID", PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(0)
                .SetPopupLayoutForm(600, 600, FormBorderStyle.FixedToolWindow)
                .SetPopupAutoFillColumns("PARAMETERNAME")
                .SetPosition(5.1)
                .SetLabel("PARAMETER");

            parameterID.Conditions.AddTextBox("TXTPARAMETER");

            parameterID.GridColumns.AddTextBoxColumn("PARAMETERID", 150);
            parameterID.GridColumns.AddTextBoxColumn("PARAMETERNAME", 200);
            
        }
        #endregion



        #region Search

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {            

            await base.OnSearchAsync();

            try
            {
                grdInfo.View.ClearDatas();

                var values = Conditions.GetValues();

                values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

                // DataTable dtParameterList = await QueryAsync("GetPatameterHistory", "00001", values);
                
                // DataTable dtParameterList = await QueryAsyncDirect("GetPatameterHistory", "00001", values);

                DataTable dtParameterList = await SqlExecuter.QueryAsyncDirect("GetPatameterHistory", "00001", values);

                if (dtParameterList.Rows.Count < 1)
                {
                    //조회할 데이터가 없습니다.
                    ShowMessage("NoSelectData");
                }

                grdInfo.DataSource = dtParameterList;
            }
            catch(Exception ex)
            {
                throw MessageException.Create(ex.Message);
            }
            
        }

        #endregion
    }
}

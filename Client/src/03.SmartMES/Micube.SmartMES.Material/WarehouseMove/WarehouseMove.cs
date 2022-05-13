#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using Micube.SmartMES.Commons;

#endregion

namespace Micube.SmartMES.Material
{
    /// <summary>
    /// 프 로 그 램 명  : 자재관리 > 자재 > 자재 창고 이동 처리
    /// 업  무  설  명  : 자재창고이동 정보를 등록 및 처리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2020-06-01
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class WarehouseMove : SmartConditionBaseForm
    {
        public WarehouseMove()
        {
            InitializeComponent();
        }

        #region 컨텐츠 영역 초기화

        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeEvent();

            InitializeList();
        }

        private void InitializeList()
        {
            grdList.GridButtonItem = GridButtonItem.Export;
            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdList.View.SetSortOrder("CREATEDTIME");
            grdList.View.SetIsReadOnly();

            grdList.View.AddTextBoxColumn("SEQ", 30)
                .SetIsHidden();
            grdList.View.AddDateEditColumn("CREATEDTIME", 100)
                .SetDisplayFormat("yyyy-MM-dd")
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("PROCESSDATE");
            grdList.View.AddTextBoxColumn("CONSUMABLELOTID", 120)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CONSUMABLEDEFID", 100)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 150);
            grdList.View.AddComboBoxColumn("CONSUMABLETYPE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=MaterialDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddSpinEditColumn("MOVEQTY", 80)
                .SetDisplayFormat("#,##0.##");
            grdList.View.AddTextBoxColumn("UNIT", 50)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("FROMWAREHOUSEID", 120, new SqlQuery("GetComboWarehouse", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("FROMCELLID", 100, new SqlQuery("GetCellId", "00001"), "CELLNAME", "LOCATIONID")
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("TOWAREHOUSEID", 120, new SqlQuery("GetComboWarehouse", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("TOCELLID", 100, new SqlQuery("GetCellId", "00001"), "CELLNAME", "LOCATIONID")
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("MOVETYPE", 120, new SqlQuery("GetCodeList", "00001", "CODECLASSID=MoveType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("DESCRIPTION", 200);
            grdList.View.AddTextBoxColumn("CREATOR", 80) // 생성자
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetTextAlignment(TextAlignment.Center);

            grdList.View.PopulateColumns();

        }
        #endregion

        #region Event
        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            btnMove.Click += BtnMove_Click;
        }

        /// <summary>
        /// 이동처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMove_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowWaitArea();
                btnMove.Focus();
                btnMove.Enabled = false;

                WarehouseMovePopup popup = new WarehouseMovePopup();
                popup.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

                popup.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.CloseWaitArea();
                btnMove.Enabled = true;
                OnSearchAsync();
            }
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

            DataTable dtMaster = await QueryAsync("GetMaterialMoveList", "00001", values);

            if (dtMaster.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }
            grdList.DataSource = dtMaster;

        }

        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();
            CommonFunction.AddConditionAllItemPopup("P_PRODUCTDEFID", 2.1, false, Conditions, "PRODUCTDEFID");

        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

        }

        #endregion
    }
}

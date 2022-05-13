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
    /// 프 로 그 램 명  : 자재관리 > 자재 > 기타입출고
    /// 업  무  설  명  : 기타입출고 정보를 등록 및 처리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2020-05-15
    /// 수  정  이  력  : 2021-07-05 주시은 입고처리, 출고처리 팝업 그리드 형태로 변경
    /// 
    /// 
    /// </summary>
    public partial class EtcInOut : SmartConditionBaseForm
    {
        public EtcInOut()
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

            InitializeEvent();

            InitializeList();
        }

        /// <summary>        
        /// 리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeList()
        {
            grdList.GridButtonItem = GridButtonItem.Export;
            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdList.View.SetSortOrder("CREATEDTIME");
            grdList.View.SetAutoFillColumn("DESCRIPTION");
            grdList.View.SetIsReadOnly();

            grdList.View.AddTextBoxColumn("SEQ", 30)
                .SetIsHidden();
            grdList.View.AddDateEditColumn("CREATEDTIME", 80)
                .SetDisplayFormat("yyyy-MM-dd")
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("PROCESSDATE");
            grdList.View.AddComboBoxColumn("INOUTGUBUN", 60, new SqlQuery("GetCodeList", "00001", "CODECLASSID=InOutType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            //grdList.View.AddComboBoxColumn("INOUTTYPE", 120, new SqlQuery("GetEtcInoutType", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
            //    .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("INOUTTYPE", 100, new SqlQuery("GetComboForInOutHistory", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "TITLE", "FIELD")
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CONSUMABLEDEFID", 120)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 150);
            grdList.View.AddTextBoxColumn("CONSUMABLELOTID", 120)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("CONSUMABLETYPE", 70, new SqlQuery("GetCodeList", "00001", "CODECLASSID=MaterialDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("WAREHOUSEID", 50)
                .SetIsHidden();
            grdList.View.AddTextBoxColumn("WAREHOUSENAME", 80)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("LOCATIONID", 50)
                .SetIsHidden();
            grdList.View.AddTextBoxColumn("CELLNAME", 80)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddSpinEditColumn("PROCESSQTY", 60)
                .SetDisplayFormat("#,##0.##");
            grdList.View.AddTextBoxColumn("UNIT", 50);
            grdList.View.AddTextBoxColumn("DESCRIPTION", 200);
            grdList.View.AddTextBoxColumn("CREATOR", 80) // 생성자
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
            btnIn.Click += BtnIn_Click;
            btnOut.Click += BtnOut_Click;
        }

        /// <summary>
        /// 입고처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnIn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowWaitArea();
                btnIn.Focus();
                btnIn.Enabled = false;

                EtcInPopup_Grid popup = new EtcInPopup_Grid();
                //EtcInPopup popup = new EtcInPopup();
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
                btnIn.Enabled = true;
                OnSearchAsync();
            }
        }

        /// <summary>
        /// 출고처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOut_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowWaitArea();
                btnOut.Focus();
                btnOut.Enabled = false;

                EtcOutPopup_Grid popup = new EtcOutPopup_Grid();
                //EtcOutPopup popup = new EtcOutPopup();
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
                btnOut.Enabled = true;
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

            DataTable dtMaster = await QueryAsync("GetMaterialEtcInOut", "00001", values);

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
            CommonFunction.AddConditionAllItemPopup("P_PRODUCTDEFID", 1.1, false, Conditions, "PRODUCTDEFID");

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

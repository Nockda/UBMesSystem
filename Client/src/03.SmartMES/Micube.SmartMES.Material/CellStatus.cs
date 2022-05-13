#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
#endregion

namespace Micube.SmartMES.Material
{
    public partial class CellStatus : SmartConditionBaseForm
    {
        #region ◆ 생성자 |
        /// <summary>
        /// 생성자
        /// </summary>
        public CellStatus()
        {
            InitializeComponent();
        }
        #endregion

        #region ◆ Control 초기화 |
        /// <summary>
        /// Control 초기화
        /// </summary>
        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeGrid();

            InitializeEvent();
        }

        #region ▶ Grid 설정 :: InitializeGrid |
        /// <summary>
        /// Grid 설정
        /// </summary>
        private void InitializeGrid()
        {
            #region # Cell Group |
            grdCellGroup.GridButtonItem = GridButtonItem.Export;

            grdCellGroup.View.SetIsReadOnly();

            grdCellGroup.View.AddTextBoxColumn("CELLGROUPID", 100).SetTextAlignment(TextAlignment.Center);
            grdCellGroup.View.AddTextBoxColumn("CELLGROUPNAME", 100).SetTextAlignment(TextAlignment.Center);
            grdCellGroup.View.AddTextBoxColumn("WAREHOUSENAME", 100).SetTextAlignment(TextAlignment.Center);

            grdCellGroup.View.PopulateColumns();
            #endregion

            #region # Cell Status |
            grdCellStatus.GridButtonItem = GridButtonItem.Export;

            grdCellStatus.View.SetIsReadOnly();

            grdCellStatus.View.AddTextBoxColumn("CELLID", 100).SetTextAlignment(TextAlignment.Center);
            // CELL이름
            grdCellStatus.View.AddTextBoxColumn("CELLNAME", 150).SetTextAlignment(TextAlignment.Center);
            // CELLGROUPID
            grdCellStatus.View.AddTextBoxColumn("CELLGROUPID", 150).SetTextAlignment(TextAlignment.Center).SetIsHidden();
            // CELLGROUPNAME
            grdCellStatus.View.AddTextBoxColumn("CELLGROUPNAME", 150).SetIsHidden();
            // 자재 ID
            grdCellStatus.View.AddTextBoxColumn("PARTNUMBER", 150).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            // 자재명
            grdCellStatus.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 250).SetIsReadOnly();
            // 규격
            grdCellStatus.View.AddTextBoxColumn("STANDARD", 150).SetIsReadOnly();
            //자재LOTID
            grdCellStatus.View.AddTextBoxColumn("CONSUMABLELOTID", 150).SetTextAlignment(TextAlignment.Center);
            //자재LOT수량
            grdCellStatus.View.AddTextBoxColumn("CONSUMABLELOTQTY", 100).SetTextAlignment(TextAlignment.Right).SetLabel("QTY");
            // 위치
            grdCellStatus.View.AddTextBoxColumn("LOCATION", 100).SetTextAlignment(TextAlignment.Center);
            

            grdCellStatus.View.PopulateColumns();
            #endregion
        }
        #endregion
        #endregion

        #region ◆ Event 설정 |
        /// <summary>
        /// Event 설정
        /// </summary>
        private void InitializeEvent()
        {
            grdCellGroup.View.FocusedRowChanged += grdCellGroupView_FocusedRowChanged;
        }

        #region ▶ Cell Group Row Changed :: grdCellGroupView_FocusedRowChanged |
        /// <summary>
        /// Cell Group Row Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdCellGroupView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var row = grdCellGroup.View.GetDataRow(grdCellGroup.View.FocusedRowHandle);

            if (row != null)
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("P_CELLGROUPID", row["CELLGROUPID"].ToString());

                if (string.IsNullOrEmpty(row["CELLGROUPID"].ToString()))
                {
                    return;
                }
                grdCellStatus.View.ClearDatas();

                grdCellStatus.DataSource = SqlExecuter.Query("SelectCellStatus", "00001", param);
            }
        } 
        #endregion
        #endregion

        #region ◆ 검색 :: OnSearchAsync |
        //// <summary>
        /// 검색
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("P_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dt = await QueryAsync("GetCellGroupMasterList", "00001", values);

            if (dt.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
                grdCellGroup.DataSource = null;
                grdCellStatus.DataSource = null;
            }
            else if(dt.Rows.Count == 1)
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("P_CELLGROUPID", dt.Rows[0]["CELLGROUPID"].ToString());
                grdCellStatus.DataSource = SqlExecuter.Query("SelectCellStatus", "00001", param);
            }

            grdCellGroup.DataSource = dt;
        }
        #endregion
    }
}

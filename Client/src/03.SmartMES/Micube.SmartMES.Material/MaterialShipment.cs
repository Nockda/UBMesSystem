
#region using


using DevExpress.Charts.Native;
using DevExpress.CodeParser;
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using Micube.Framework;
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

namespace Micube.SmartMES.Material
{
    /// <summary>
    /// 프 로 그 램 명  : 자재관리 > 자재재고관리 > 부품출하등록
    /// 업  무  설  명  : 자재출하등록
    /// 생    성    자  : jylee
    /// 생    성    일  : 2020-07-08
    /// 수  정  이  력  : 2020-07-16 | JYLEE | CONSUMABLEDEFID => PARTNUMBER
    ///                   2020-07-23 | JYLEE | 분할x => 수량 차감, 이력탭 추가
    /// 
    /// </summary>
    public partial class MaterialShipment : SmartConditionBaseForm
    {
        int count = 1;

        public MaterialShipment()
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

            InitializeGrid();
            InitializeGridHistory();
            InitializeEvent();
        }

        private void InitializeGrid()
        {
            grdShip.GridButtonItem = GridButtonItem.Export;

            grdShip.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            //grdShip.View.SetSortOrder("_INTERNAL_CHECKMARK_SELECTION_");

            grdShip.View.SetSortOrder("TEMP");

            grdShip.View.AddTextBoxColumn("TEMP", 100)
                    .SetIsHidden();

            grdShip.View.AddTextBoxColumn("PARTNUMBER", 120)
                    .SetTextAlignment(TextAlignment.Center)
                    .SetLabel("CONSUMABLEDEFID")
                    .SetIsReadOnly();

            grdShip.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 250)
                    .SetIsReadOnly();

            grdShip.View.AddTextBoxColumn("STANDARD", 150)
                    .SetIsReadOnly();

            grdShip.View.AddTextBoxColumn("CONSUMABLELOTID", 120)
                    .SetTextAlignment(TextAlignment.Center)
                    .SetIsReadOnly();

            grdShip.View.AddTextBoxColumn("WAREHOUSENAME", 100)
                    .SetTextAlignment(TextAlignment.Center)
                    .SetIsReadOnly();

            grdShip.View.AddTextBoxColumn("CONSUMABLELOTQTY", 80)
                    .SetIsReadOnly();

            grdShip.View.AddTextBoxColumn("SHIPMENTQTY", 80)
                    .SetTextAlignment(TextAlignment.Right);

            grdShip.View.PopulateColumns();

        }

        private void InitializeGridHistory()
        {
            grdHistory.GridButtonItem = GridButtonItem.Export;

            grdHistory.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            grdHistory.View.SetIsReadOnly();

            grdHistory.View.AddTextBoxColumn("PARTNUMBER", 120)
                    .SetTextAlignment(TextAlignment.Center)
                    .SetLabel("CONSUMABLEDEFID");

            grdHistory.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 250);

            grdHistory.View.AddTextBoxColumn("STANDARD", 150);

            grdHistory.View.AddTextBoxColumn("CONSUMABLELOTID", 120)
                    .SetTextAlignment(TextAlignment.Center);
            grdHistory.View.AddTextBoxColumn("TXNHISTKEY", 100).SetIsHidden();
            grdHistory.View.AddTextBoxColumn("WAREHOUSENAME", 100)
                    .SetTextAlignment(TextAlignment.Center);

            grdHistory.View.AddTextBoxColumn("QTY", 80)
                    .SetLabel("CONSUMABLELOTQTY");

            grdHistory.View.AddTextBoxColumn("SHIPPEDQTY", 80)
                    .SetTextAlignment(TextAlignment.Right)
                    .SetLabel("SHIPMENTQTY");

            grdHistory.View.AddTextBoxColumn("CREATOR", 100)
                    .SetTextAlignment(TextAlignment.Center);


            grdHistory.View.AddTextBoxColumn("CREATEDTIME", 100)
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss");


            grdHistory.View.PopulateColumns();
        }

        #endregion

        #region Event

        private void InitializeEvent()
        {
            txtConsumableLotId.KeyPress += txtConsumableLotId_KeyPress;
            grdShip.View.RowStyle += View_RowStyle;
            grdShip.View.RowCellStyle += View_RowCellStyle;
            smartTabControl1.SelectedPageChanged += SmartTabControl1_SelectedPageChanged;
        }

        private void SmartTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (smartTabControl1.SelectedTabPageIndex == 0) // 부품출하 탭
            {
                SetConditionVisiblility("P_DATEPERIOD", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
            }
            else if (smartTabControl1.SelectedTabPageIndex == 1) // 실적조회 탭
            {
                SetConditionVisiblility("P_DATEPERIOD", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);
            }
        }

        private void View_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "SHIPMENTQTY")
            {
                e.Appearance.BackColor = System.Drawing.Color.LightYellow;
                e.Appearance.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void View_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (grdShip.View.IsRowChecked(e.RowHandle))
            {
                e.HighPriority = true;
                e.Appearance.BackColor = Color.FromArgb(250, 244, 192);
            }
            else
            {
                return;
            }

        }

        private void txtConsumableLotId_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar != (char)13) return;

            String txtConsumableLotId = this.txtConsumableLotId.Text.Trim();
            DataTable dt = grdShip.DataSource as DataTable;

            bool checkDef = false;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];

                if (txtConsumableLotId == (string)row["CONSUMABLELOTID"])
                {
                    grdShip.View.CheckRow(grdShip.View.GetRowHandle(i), true);
                    row["TEMP"] = count;
                    count++;
                    checkDef = true;
                }

            }

            if (!checkDef)
            {
                //선택된 LOT이 없습니다.
                throw MessageException.Create("LotNotSelected");
            }
            dt.AcceptChanges();

            var txtLotId = this.txtConsumableLotId;
            txtLotId.Text = null;
            this.ActiveControl = txtLotId;

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

           if(smartTabControl1.SelectedTabPageIndex == 0) // 부품출하 탭
            {
                DataTable dt = await QueryAsync("GetMaterialLotForShipment", "00001", values);

                if (dt.Rows.Count < 1)
                {
                    ShowMessage("NoSelectData");
                }

                grdShip.DataSource = dt;

                //검색이후 포커스
                var txtLotId = this.txtConsumableLotId;
                this.ActiveControl = txtLotId;
            }
            else if(smartTabControl1.SelectedTabPageIndex == 1) // 출하이력 탭
            {
                DataTable resultList = await QueryAsync("GetMaterialLotForShipmentHistory", "00001", values);
                if (resultList.Rows.Count < 1)
                {
                    ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
                }
                grdHistory.DataSource = resultList;
            }

        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

            SetConditionVisiblility("P_DATEPERIOD", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
        }

        #endregion

        #region ToolBar
        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            SmartButton btn = sender as SmartButton;
            string btnName = btn.Name.ToString();

            if(btnName == "Save")
            {
                if (smartTabControl1.SelectedTabPageIndex == 0) // 부품출하 탭
                {
                    DataTable dtChecked = grdShip.View.GetCheckedRows();
                    validationChecked(dtChecked);
                    if (ShowMessage(MessageBoxButtons.YesNo, "SaveMaterialShipmentYesNo") == DialogResult.Yes) //출하등록을 진행하시겠습니까?
                    {
                        ExecuteRule("SaveMaterialShipment", dtChecked);
                    }
                }
                else if (smartTabControl1.SelectedTabPageIndex == 1) // 출하이력 탭
                {
                    //이력정보는 저장할 수 없습니다.
                    throw MessageException.Create("NoSaveHistoryTab");
                }
            }
            else if(btnName == "CancelRegistration")
            {
                if (smartTabControl1.SelectedTabPageIndex == 1) // 출하이력 탭
                {
                    DataTable dtChecked = grdHistory.View.GetCheckedRows();
                    if (dtChecked.Rows.Count < 1)
                    {
                        //선택된 행이 없습니다.
                        ShowMessage("NoSelected");
                        return;
                    }

                    if(!validationLotNo(dtChecked))
                    {
                        ShowMessage("NeedOneLotNo");
                        return;
                    }

                    if (ShowMessage(MessageBoxButtons.YesNo, "CancelRegistrationYesNo") == DialogResult.Yes) //등록된 출하내역을 취소하시겠습니까?
                    {
                        ExecuteRule("CancelMaterialShipment", dtChecked);
                        ShowMessage("SuccessSave");
                        OnSearchAsync();
                    }
                }
            }
        }

        #endregion

        #region 유효성 검사

        private void validationChecked(DataTable dtChecked)
        {
            if(dtChecked.Rows.Count < 1)
            {
                //선택된 행이 없습니다.
                throw MessageException.Create("NoSelected");
            }

            foreach(DataRow row in dtChecked.Rows)
            {

                if (Format.GetDecimal(row["SHIPMENTQTY"].ToString()) == 0)
                {
                    //수량을 입력하세요.
                    throw MessageException.Create("ISREQUIREDQTY");
                }
                else if (Format.GetDecimal(row["CONSUMABLELOTQTY"].ToString()) < Format.GetDecimal(row["SHIPMENTQTY"].ToString()))
                {
                    //수량을 초과하였습니다.
                    throw MessageException.Create("OVERQTY");
                }
            }

        }

        //LOTNO가 중복되는 것이 있는지 체크
        private bool validationLotNo(DataTable dtChecked)
        {
            bool rValue = true;

            int i = dtChecked.DefaultView.ToTable(true, "CONSUMABLELOTID").Rows.Count;
            int j = dtChecked.Rows.Count;

            if (i != j)
                rValue = false;

            return rValue;
        }

        #endregion

    }
}

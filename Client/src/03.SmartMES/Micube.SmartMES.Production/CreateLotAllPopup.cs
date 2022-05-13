using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;


namespace Micube.SmartMES.Production
{
    /// <summary>
    /// 프 로 그 램 명  :  생산관리 > 생산계획 > 작업지시조회 > LOT일괄생성
    /// 업  무  설  명  :  LOT일괄생성 팝업
    /// 생    성    자  :  scmo
    /// 생    성    일  :  2022-05-03
    /// 수  정  이  력  :
    /// </summary>
    public partial class CreateLotAllPopup : SmartPopupBaseForm
    {
        #region Local Variables
        private DataRow _drBase;
        public int _createCount { get; set; }
        #endregion

        public CreateLotAllPopup(DataRow dr)
        {
            InitializeComponent();

            _drBase = dr;

            InitializeEvent();

            InitializeBaseInfo();
        }

        private void InitializeBaseInfo()
        {
            lblItemId.Editor.ReadOnly = true;
            lblItemName.Editor.ReadOnly = true;
            lblWorkorderQty.Editor.ReadOnly = true;
            lblLotSize.Editor.ReadOnly = true;
            lblCreateQty.Editor.ReadOnly = true;    //Create할 LOT 수량
            lblRealorderQty.Editor.ReadOnly = false;

            lblItemId.Editor.EditValue = Format.GetTrimString(_drBase["PARTNUMBER"]);
            lblItemName.Editor.EditValue = Format.GetTrimString(_drBase["PRODUCTDEFNAME"]);
            lblWorkorderQty.Editor.EditValue = Format.GetTrimString(_drBase["ORDERQTY"]);
            lblLotSize.Editor.EditValue = Format.GetTrimString(_drBase["LOTSIZE"]);
            lblRealorderQty.Editor.EditValue = Format.GetTrimString(_drBase["NOTPROCESSQTY"]);

            lblRealorderQty.Editor.Text = Format.GetTrimString(_drBase["NOTPROCESSQTY"]);
        }

        #region Event
        private void InitializeEvent()
        {
            btnCancel.Click += BtnCancel_Click;
            btnSave.Click += BtnSave_Click;

            lblRealorderQty.Editor.TextChanged += lblRealorderQty_TextChanged;
        }

        private void lblRealorderQty_TextChanged(object sender, EventArgs e)
        {
            double orderQty = Convert.ToDouble(lblRealorderQty.Editor.EditValue.ToString());
            double lotSize = Convert.ToDouble(lblLotSize.Editor.EditValue.ToString());

            double createLotQty = Math.Ceiling(orderQty / lotSize);

            lblCreateQty.Editor.EditValue = createLotQty;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this._createCount = Convert.ToInt32(lblCreateQty.Editor.EditValue);
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}

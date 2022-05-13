#region using

using DevExpress.XtraGrid.Views.Grid;
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

namespace Micube.SmartMES.Commons
{
    /// <summary>
    /// 프 로 그 램 명  : 
    /// 업  무  설  명  : 
    /// 생    성    자  : 
    /// 생    성    일  : 
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class LotCancelPopUp : SmartPopupBaseForm, ISmartCustomPopup
    {
        #region Local Variables

        /// <summary>
        /// 팝업진입전 그리드의 Row
        /// </summary>
        public DataRow CurrentDataRow { get; set; }
        public string Lotid = string.Empty;

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        public LotCancelPopUp()
        {
            InitializeComponent();

            InitializeEvent();
        }

        #endregion

        #region 컨텐츠 영역 초기화
        
        /// <summary>
        /// 상단 컨트롤 데이터 바인딩
        /// </summary>
        private void InitializeControl()
        {

        }

        /// <summary>
        /// 하단 세부공정 진척정보 그리드 바인딩
        /// </summary>
        private void InitializeGrid()
        {
        }

        #endregion

        #region Event

        /// <summary>        
        /// 이벤트 초기화
        /// </summary>
        public void InitializeEvent()
        {
            this.Load += LotCancelPopUp_Load;
            btnCancel.Click += BtnCancel_Click;
            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(txtComment.Text.Trim().Equals(string.Empty))
            {
                throw MessageException.Create("취소 사유를 입력해주세요");
            }
            if(ShowMessage(MessageBoxButtons.YesNo, "InfoSave", "") == DialogResult.No)
            {
                return;
            }

            MessageWorker messageWorker = new MessageWorker("CancelCreateLot");
            messageWorker.SetBody(new MessageBody()
            {
                { "EnterpriseId", UserInfo.Current.Enterprise },
                { "PlantId", UserInfo.Current.Plant },
                { "UserId", UserInfo.Current.Id },
                { "Comment", txtComment.Text.Trim() },
                { "LotId", txtLotid.Text.Trim() }
            });

            messageWorker.Execute();

            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LotCancelPopUp_Load(object sender, EventArgs e)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("LOTID", Lotid);
            dic.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dt = SqlExecuter.Query("SelectCancelLotInfo", "00001", dic);

            if(dt == null || dt.Rows.Count==0)
            {
                ShowMessageBox("CheckLotNo", "INFORMATION", MessageBoxButtons.OK);

                this.Close();
            }

            string LotState = Format.GetTrimString(dt.Rows[0]["LOTSTATE"]);
            string ProcessState = Format.GetTrimString(dt.Rows[0]["PROCESSSTATE"]);

            if (!LotState.Equals("InProduction") || !ProcessState.Equals("Idle"))
            {
                ShowMessageBox("CheckLotStateForCancel", "INFORMATION", MessageBoxButtons.OK); //LOT 상태가 대기 상태인(Idle) LOT만 취소 가능 합니다.
                this.Close();
            }

            txtLotid.Editor.Text = Format.GetTrimString(dt.Rows[0]["LOTID"]);
            txtQty.Editor.Text = Format.GetTrimString(dt.Rows[0]["QTY"]);
            txtState.Editor.Text = Format.GetTrimString(dt.Rows[0]["PROCESSSTATE"]);
            txtProductDefid.Text = Format.GetTrimString(dt.Rows[0]["PARTNUMBER"]);
            txtProductdefName.Text = Format.GetTrimString(dt.Rows[0]["PRODUCTDEFNAME"]);
            txtModel.Text = Format.GetTrimString(dt.Rows[0]["MODELNAME"]);
            this.ActiveControl = txtComment;
        }



        #endregion
 
        #region Private Function

        #endregion
    }
}

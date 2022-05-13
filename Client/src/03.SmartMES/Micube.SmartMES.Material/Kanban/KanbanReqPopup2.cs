
#region using

using DevExpress.XtraRichEdit.Commands;
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
/// <summary>
/// 프 로 그 램 명  : 자재관리 > 간반요청출고 > 간반요청팝업
/// 업  무  설  명  : 간반요청출고 화면에서 간반요청 팝업화면
/// 생    성    자  : jylee
/// 생    성    일  : 2020-04-24
/// 수  정  이  력  : 2020-06-10 | JYLEE | 정보load쿼리수정, 메시지팝업 추가
/// 
/// 
/// </summary>
namespace Micube.SmartMES.Material
{
    public partial class KanbanReqPopup2 : SmartPopupBaseForm
    {
        #region Local Variables

        private string kanbanCode;
        private string kanbanName;
        private string location;
        private string itemId;
        private string itemName;
        private string itemCategory;
        private string qty;
        private string unit;
        private string toWarehouseId;
        private string toWarehouse;
        private string dept;
        private string reqUserId;
        private string reqUserName;

        private string consumablefDefId = null;

        #endregion

        #region 컨텐츠 초기화

        public KanbanReqPopup2()
        {
            InitializeComponent();
            InitializeEvent();
            InitializeLabel();
        }

        private void InitializeLabel()
        {
            var kanbancode = this.txtKanbanCode;
            this.ActiveControl = kanbancode;

            this.txtKanbanName.ReadOnly = true;
            this.txtItemCode.ReadOnly = true;
            this.txtItemName.ReadOnly = true;
            this.txtQty.ReadOnly = true;
            this.txtUnit.ReadOnly = true;
            this.txtUser.ReadOnly = true;
            this.txtDept.ReadOnly = true;
            this.txtWarehouse.ReadOnly = true;
            this.txtLocation.ReadOnly = true;


        }

        private void InitializeEvent()
        {
            BtnSave.Click += BtnSave_Click;
            BtnClose.Click += BtnClose_Click;
            this.txtKanbanCode.KeyPress += TxtKanbanCode_KeyPress;
        }

        #endregion

        #region Event

        private void TxtKanbanCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                var key = this.txtKanbanCode.Text.Trim();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("P_CELLID", key);
                DataTable dtInfo = SqlExecuter.Query("GetReqKanban", "00001", param);

                //품목카테고리
                itemCategory = dtInfo.Rows[0]["CONSUMABLETYPE"].ToString();
                //요청자ID
                reqUserId = UserInfo.Current.Id;
                //요청부서
/*                dept = UserInfo.Current.Department;*/
                Dictionary<string, object> paramDept = new Dictionary<string, object>();
                paramDept.Add("P_USERID", UserInfo.Current.Id);
                DataTable dtDept = SqlExecuter.Query("GetDeptInfo", "00001", paramDept);
                //간반코드
                this.txtKanbanCode.Text = dtInfo.Rows[0]["KANBANCODE"].ToString();
                //간반명
                this.txtKanbanName.Text = dtInfo.Rows[0]["KANBANNAME"].ToString();
                //품목코드
                //this.txtItemCode.Text = dtInfo.Rows[0]["CONSUMABLEDEFID"].ToString();
                consumablefDefId = dtInfo.Rows[0]["CONSUMABLEDEFID"].ToString();
                this.txtItemCode.Text = dtInfo.Rows[0]["PARTNUMBER"].ToString();
                //품목명
                this.txtItemName.Text = dtInfo.Rows[0]["CONSUMABLEDEFNAME"].ToString();
                //수량
                this.txtQty.Text = dtInfo.Rows[0]["QTY"].ToString();
                //단위
                this.txtUnit.Text = dtInfo.Rows[0]["UNIT"].ToString();
                //요청자명
                this.txtUser.Text = UserInfo.Current.Name;
                //부서
                this.txtDept.Text = dtDept.Rows[0]["DEPARTMENTNAME"].ToString();
                //요청창고ID
                toWarehouseId = dtInfo.Rows[0]["TOWAREHOUSEID"].ToString();
                //요청창고
                this.txtWarehouse.Text = dtInfo.Rows[0]["TOWAREHOUSE"].ToString();
                //위치
                this.txtLocation.Text = dtInfo.Rows[0]["LOCATION"].ToString();
            }
        }
        //저장버튼
        private void BtnSave_Click(object sender, EventArgs e)
        {
             kanbanCode = this.txtKanbanCode.Text;
             kanbanName = this.txtKanbanName.Text;
             itemId = consumablefDefId;
             itemName = this.txtItemName.Text;
             qty = this.txtQty.Text;
             unit = this.txtUnit.Text;
             reqUserName = this.txtUser.Text;
             dept = this.txtDept.Text;
             toWarehouse = this.txtWarehouse.Text;
             location = this.txtLocation.Text;

            Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("kanbanCode", kanbanCode);
                param.Add("kanbanName", kanbanName);
                param.Add("location", location);
                param.Add("itemId", itemId);
                param.Add("itemName", itemName);
                param.Add("itemCategory", itemCategory);
                param.Add("qty", qty);
                param.Add("unit", unit);
                param.Add("toWhId", toWarehouseId);
                param.Add("to", toWarehouse);
                param.Add("from", "1"); // 자재창고코드 1
                param.Add("dept", dept);
                param.Add("userId", reqUserId);
                param.Add("userName", reqUserName);

            ExecuteRule("RequestKanban", param);
            //요청이 완료되었습니다.
            MSGBox.Show(MessageBoxType.Information, "RequestCompletion", MessageBoxButtons.OK, DialogResult.OK);
            this.Close();


        }

        //닫기버튼
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}

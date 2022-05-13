#region
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using System;
using System.Collections.Generic;
using System.Data;
#endregion

namespace Micube.SmartMES.Process
{
    /// <summary>
    /// 프 로 그 램 명  : 공정관리 > 공정실적등록 > 공정
    /// 업  무  설  명  : 공정실적등록 작업시작 팝업화면
    /// 생    성    자  : JYLEE
    /// 생    성    일  : 2020-05-25
    /// 수  정  이  력  : 
    /// </summary>
    public partial class StartProcessPopup : SmartPopupBaseForm
    {
        private string lotId;
        private string areaId;
        private decimal qty;

        #region 생성자
        public StartProcessPopup(string lotId, string areaId, decimal qty)
        {
            this.lotId = lotId;
            this.areaId = areaId;
            this.qty = qty;

            InitializeComponent();
            InitializeEvent();
        }

        private void InitializeEvent()
        {
            this.Load += StartProcessPopup_Load;
            btnSave.Click += btnSave_Click;
            btnClose.Click += btnClose_Click;
        }

        private void StartProcessPopup_Load(object sender, EventArgs e)
        {
            InitializeSelectEquip();
            InitializeSelectUser();
        }
         
        private void InitializeSelectEquip()
        {
            var popup = selectEquip.SelectPopupCondition.Conditions
                .AddSelectPopup("EQUIPMENTID", new SqlQuery("GetProcessEquipPopup", "00001", $"P_AREAID={areaId}"), "EQUIPMENTNAME", "EQUIPMENTID")
                .SetPopupLayout("SELECTEQUIPMENT", PopupButtonStyles.Ok_Cancel, true, true)
                .SetPopupResultCount(1)
                .SetPopupLayoutForm(700, 400, System.Windows.Forms.FormBorderStyle.Sizable);
            selectEquip.SelectPopupCondition = popup;

            // 검색조건
            popup.Conditions.AddTextBox("EQUIPMENTID");

            // 조회 컬럼
            popup.GridColumns.AddTextBoxColumn("EQUIPMENTCLASSNAME", 120);
            popup.GridColumns.AddTextBoxColumn("EQUIPMENTID", 120).SetTextAlignment(TextAlignment.Center);
            popup.GridColumns.AddTextBoxColumn("EQUIPMENTNAME", 180);
        }

        private void InitializeSelectUser()
        {
            var popup = selectUser.SelectPopupCondition.Conditions
                .AddSelectPopup("USERID", new SqlQuery("ProceeResultUserList", "00001", $"P_AREAID={areaId}"), "USERNAME", "USERID")
                .SetPopupLayout("SELECTUSER", PopupButtonStyles.Ok_Cancel, true, true)
                .SetPopupResultCount(1)
                .SetPopupLayoutForm(500, 400, System.Windows.Forms.FormBorderStyle.Sizable);
            selectUser.SelectPopupCondition = popup;

            // 검색조건
            popup.Conditions.AddTextBox("USERID");

            // 조회 컬럼
            popup.GridColumns.AddTextBoxColumn("USERID", 120);
            popup.GridColumns.AddTextBoxColumn("USERNAME", 180);
        }
        #endregion

        // 저장
        private void btnSave_Click(object sender, EventArgs e)
        {
            /*
            // NOTE : 인터락
            var param = new Dictionary<string, object>()
            {
                { "EQUIPMENTID", selectEquip.GetValue() }
            };
            DataTable dt = SqlExecuter.Query("GetInterLockInfo", "00001", param);
            if (dt.Rows.Count > 0)
            {
                // 설비에서 이상신호가 발견되었습니다. 설비상태를 확인해주세요. {0}
                throw MessageException.Create("EquipmentInterlock"
                    , string.Format("[설비명 : {0}] [알람ID : {1}] [알람명 : {2}] [발생일 : {3}]"
                        , dt.Rows[0]["EQUIPMENTNAME"].ToString()
                        , dt.Rows[0]["ALARMID"].ToString()
                        , dt.Rows[0]["ALARMNAME"].ToString()
                        , dt.Rows[0]["OCCURETIME"].ToString()));
            }
            */
            MessageWorker messageWorker = new MessageWorker("SubTrackInMachining");
            messageWorker.SetBody(new MessageBody()
            {
                { "lotid", lotId },
                { "equipmentid", selectEquip.GetValue() },
                { "userid", selectUser.GetValue() },
                { "qty", qty }
            });
            messageWorker.Execute();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        // 닫기
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}


#region Using

using DevExpress.Charts.Native;
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
using Micube.SmartMES.Commons;

#endregion

namespace Micube.SmartMES.Process
{
    /// <summary>
    /// 프 로 그 램 명  : 공정관리 > 공정실적 > 가공진척현황
    /// 업  무  설  명  : 공정실적 현황 조회
    /// 생    성    자  : JYLEE
    /// 생    성    일  : 2020-06-22
    /// 수  정  이  력  : 2020-06-29 | JYLEE | 검색조건: LOT상태 추가
    ///                                      | 컬럼명 변경
    /// </summary>
    public partial class MachiningStatus : SmartConditionBaseForm
    {
        public MachiningStatus()
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
            InitializeMasterGrid();
            InitializeEquipmentGrid();
            InitializeMaterialGrid();
            InitializeEvent();
        }

        private void InitializeMasterGrid()
        {
            grdMaster.GridButtonItem = GridButtonItem.Export;
            grdMaster.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdMaster.View.SetIsReadOnly();

            //실적일자
            grdMaster.View.AddTextBoxColumn("RESULTDATE", 100)
                          .SetDisplayFormat("yyyy-MM-dd")
                          .SetTextAlignment(TextAlignment.Center);
            //작업지시번호
            grdMaster.View.AddTextBoxColumn("WORKORDERID", 130);
            //Lot No.
            grdMaster.View.AddTextBoxColumn("LOTID", 120)
                        .SetTextAlignment(TextAlignment.Center);
            //품목코드
            grdMaster.View.AddTextBoxColumn("PRODUCTDEFID", 120).SetIsHidden();
            grdMaster.View.AddTextBoxColumn("PARTNUMBER", 120).SetLabel("PRODUCTDEFID");
            //품목명
            grdMaster.View.AddTextBoxColumn("PRODUCTDEFNAME", 300);
            //규격
            grdMaster.View.AddTextBoxColumn("STANDARD", 130);
            //기종명
            grdMaster.View.AddTextBoxColumn("MODELNAME", 100);
            //공정명
            grdMaster.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 120);
            //횟수
            grdMaster.View.AddTextBoxColumn("COUNT", 80);
            //LOT SIZE
            grdMaster.View.AddTextBoxColumn("LOTSIZE", 80);
            // 실적수량
            grdMaster.View.AddTextBoxColumn("RESULTQTY", 80);
            //시작일시
            grdMaster.View.AddTextBoxColumn("TRACKINTIME", 150)
                         .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                         .SetTextAlignment(TextAlignment.Center);
            //종료일시
            grdMaster.View.AddTextBoxColumn("TRACKOUTTIME", 150)
                        .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                        .SetTextAlignment(TextAlignment.Center);
            //작업시간(분)
            grdMaster.View.AddSpinEditColumn("WORKTIME", 100).SetDisplayFormat("#,##0.#", MaskTypes.Numeric);
            //표준시간(분)
            grdMaster.View.AddSpinEditColumn("STANDARDTIME", 100).SetLabel("STDTIME").SetDisplayFormat("#,##0.#",MaskTypes.Numeric);
            //작업지시번호
            grdMaster.View.AddTextBoxColumn("WORKORDERID", 150)
                       .SetTextAlignment(TextAlignment.Center);
            //LOT상태
            grdMaster.View.AddTextBoxColumn("LOTSTATE", 80);

            grdMaster.View.PopulateColumns();

        }

        private void InitializeEquipmentGrid()
        {
            grdEquip.GridButtonItem = GridButtonItem.Export;
            grdEquip.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdEquip.View.SetIsReadOnly();

            //설비ID
            grdEquip.View.AddTextBoxColumn("EQUIPMENTID", 100)
                                        .SetTextAlignment(TextAlignment.Center);
            //설비명
            grdEquip.View.AddTextBoxColumn("EQUIPMENTNAME", 200);
            //작업자
            grdEquip.View.AddTextBoxColumn("WORKER", 100)
                        .SetTextAlignment(TextAlignment.Center);
            //시작일시
            grdEquip.View.AddTextBoxColumn("TRACKINTIME", 140)
                                        .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                        .SetTextAlignment(TextAlignment.Center);
            //종료일시
            grdEquip.View.AddTextBoxColumn("TRACKOUTTIME", 140)
                                        .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                        .SetTextAlignment(TextAlignment.Center);
            //작업시간(분)
            grdEquip.View.AddTextBoxColumn("WORKTIME", 100);

            grdEquip.View.PopulateColumns();

        }

        private void InitializeMaterialGrid()
        {
            grdMaterial.GridButtonItem = GridButtonItem.Export;
            grdMaterial.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdMaterial.View.SetIsReadOnly();

            //자재코드
            grdMaterial.View.AddTextBoxColumn("CONSUMABLEDEFID", 150).SetIsHidden()
                .SetTextAlignment(TextAlignment.Center);
            grdMaterial.View.AddTextBoxColumn("PARTNUMBER", 150).SetLabel("CONSUMABLEDEFID");
            //자재명
            grdMaterial.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 260);
            //자재LOT
            grdMaterial.View.AddTextBoxColumn("MATERIALLOTID", 150)
               .SetTextAlignment(TextAlignment.Center);
            //일련번호
            grdMaterial.View.AddTextBoxColumn("SERIALNO", 120);
            //양품
            grdMaterial.View.AddTextBoxColumn("GOODQTY", 50);
            //불량
            grdMaterial.View.AddTextBoxColumn("BADQTY", 50);
            //특이사항
            grdMaterial.View.AddTextBoxColumn("DESCRIPTION", 150).SetLabel("COMMENT");
            //자재거래처
            grdMaterial.View.AddTextBoxColumn("CUSTOMERNAME", 120).SetLabel("VENDOR");

            grdMaterial.View.PopulateColumns();
        }

        #endregion

        #region Event
        private void InitializeEvent()
        {
            grdMaster.View.FocusedRowChanged += View_FocusedRowChanged;
            grdMaster.View.ColumnFilterChanged += View_ColumnFilterChanged;
        }

        private void View_ColumnFilterChanged(object sender, EventArgs e)
        {
            EquipmentGridDataLoad();
            MaterialGridDataLoad();
        }

        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            EquipmentGridDataLoad();
            MaterialGridDataLoad();
        }

        private void EquipmentGridDataLoad()
        {
            if(grdMaster.View.FocusedRowHandle < 0)
            {
                grdMaster.View.ClearDatas();
                grdMaterial.View.ClearDatas();
                return;
            }

            var row = grdMaster.View.GetDataRow(grdMaster.View.FocusedRowHandle);
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_LOTID", row["LOTID"].ToString());
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            grdEquip.DataSource = SqlExecuter.Query("GetProcessMachiningEquipment", "00001", param);

        }

        private void MaterialGridDataLoad()
        {
            if (grdMaster.View.FocusedRowHandle < 0)
            {
                grdEquip.View.ClearDatas();
                grdMaterial.View.ClearDatas();
                return;
            }

            var row = grdMaster.View.GetDataRow(grdMaster.View.FocusedRowHandle);
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_LOTID", row["LOTID"].ToString());
            param.Add("DBLINKNAME", CommonFunction.DbLinkName);

            if (row["TRACKOUTTIME"] == DBNull.Value || string.IsNullOrEmpty(row["TRACKOUTTIME"].ToString()))
            {
                // 작업완료되지 않은 LOT의 자재는 가투입 내역 조회
                grdMaterial.DataSource = SqlExecuter.Query("GetMachiningInsertMaterialInfo", "00003", param);
            }
            else
            {
                // 작업완료된 LOT의 자재는 실투입 내역 조회
                grdMaterial.DataSource = SqlExecuter.Query("GetMachiningInsertMaterialInfo", "00002", param);
            }

        }

        #endregion

        #region Search
        //// <summary>
        /// 비동기 override 모델
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();
            var values = Conditions.GetValues();
            values.Add("P_LANGUAGETYPE", UserInfo.Current.LanguageType);
            DataTable dt = await QueryAsync("GetMachiningStatus", "00001", values);
            if(dt.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdMaster.DataSource = dt;
        }
        #endregion

    }
}

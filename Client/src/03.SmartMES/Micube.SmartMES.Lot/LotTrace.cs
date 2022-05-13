#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.SmartMES.Commons;
using DevExpress.XtraTreeList;
using DevExpress.Utils;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
#endregion

namespace Micube.SmartMES.Lot
{
    /// <summary>
    /// 프 로 그 램 명  : Lot 추적
    /// 업  무  설  명  : Lot 추적화면
    /// 생    성    자  : 박정훈
    /// 생    성    일  : 2020-06-15
    /// 수  정  이  력  : 2020-11-05 | 이준용 | 쿼리시간 초과 이슈사항으로 인해 ERP테이블 정보를 가져오는 X번 쿼리 변경
    ///                     SelectLotTraceLotXManageList  version = "00001" => "00002" 사용
    ///                   2021-05-14 scmo 자재거래처필드 추가
    ///                   2022-04-18 scmo 작업실적, 검사실적 추가
    /// 
    /// </summary>
    public partial class LotTrace : SmartConditionBaseForm
    {
        #region ◆ Local Variables |
        #endregion

        #region ◆ 생성자 |
        /// <summary>
        /// 생성자
        /// </summary>
        public LotTrace()
        {
            InitializeComponent();
        }
        #endregion

        #region ◆ 컨텐츠 영역 초기화 |
        /// <summary>
        /// Control 설정
        /// </summary>
        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeTreeList();
            InitializeLotTree(treeFowardTrace);

            InitializeGrid();

            InitializeEvent();
        }


        #region ▶ TreeList 설정
        /// <summary>
        /// LOT 가계도 TREELIST 
        /// </summary>
        private void InitializeTreeList()
        {
            treeLotGeneal.SetResultCount(1);
            treeLotGeneal.SetIsReadOnly();
            treeLotGeneal.SetMember("LOTNAME", "PATH", "PARENTPATH");
            treeLotGeneal.SetSortColumn("LOTLEVEL", SortOrder.Ascending);

            treeReverseTrace.SetResultCount(1);
            treeReverseTrace.SetIsReadOnly();
            treeReverseTrace.SetMember("LOTNAME", "PATH", "PARENTPATH");
            treeReverseTrace.SetSortColumn("LOTLEVEL", SortOrder.Ascending);
        }
        #endregion

        #region ▶ TreeList 설정
        /// <summary>
        /// TreeList 설정
        /// </summary>
        /// <param name="treeList"></param>
        private void InitializeLotTree(SmartTreeList treeList)
        {
            treeList.BeginUpdate();

            treeList.RowHeight = 24;
            treeList.KeyFieldName = "LOTID";
            treeList.OptionsView.AutoWidth = false;

            TreeListColumn col1 = treeList.Columns.Add();
            col1.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col1.Caption = Language.Get("LOTID"); // LOTID
            col1.FieldName = "LOTID";
            col1.VisibleIndex = 0;
            col1.Width = 200;

            TreeListColumn col2 = treeList.Columns.Add();
            col2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col2.Caption = Language.Get("PARENTLOTID"); // 부모 LOT
            col2.FieldName = "PARENTLOTID";
            col2.VisibleIndex = 1;
            col2.Visible = false;

            TreeListColumn col3 = treeList.Columns.Add();
            col3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col3.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Default;
            col3.Caption = Language.Get("PROCESSSEGMENTNAME"); // 공정명
            col3.FieldName = "PROCESSSEGMENTNAME";
            col3.VisibleIndex = 2;
            col3.Width = 200;

            TreeListColumn col4 = treeList.Columns.Add();
            col4.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col4.Caption = Language.Get("PRODUCTDEFNAME"); // 품목명
            col4.FieldName = "PRODUCTDEFNAME";
            col4.VisibleIndex = 3;
            col4.Width = 350;

            TreeListColumn col5 = treeList.Columns.Add();
            col5.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far;
            col5.Caption = Language.Get("QTY"); // 수량
            col5.FieldName = "QTY";
            col5.VisibleIndex = 4;
            col5.Width = 80;

            TreeListColumn col6 = treeList.Columns.Add();
            col6.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col6.Caption = Language.Get("LOTLEVEL"); // LEVEL
            col6.FieldName = "LOTLEVEL";
            col6.VisibleIndex = 5;
            col6.Visible = false;

            TreeListColumn col7 = treeList.Columns.Add();
            col7.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col7.Caption = Language.Get("PATH"); // 순차구조(히든)
            col7.FieldName = "PATH";
            col7.VisibleIndex = 6;
            col7.Visible = false;

            TreeListColumn col8 = treeList.Columns.Add();
            col8.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col8.Caption = Language.Get("WORKSTARTTIME"); // 작업시작일
            col8.FieldName = "WORKSTARTTIME";
            col8.Format.FormatType = FormatType.DateTime;
            col8.Format.FormatString = "yyyy-MM-dd HH:mm:ss";
            col8.VisibleIndex = 7;
            col8.Width = 140;

            TreeListColumn col9 = treeList.Columns.Add();
            col9.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col9.Caption = Language.Get("WORKENDTIME"); // 작업완료일
            col9.FieldName = "WORKENDTIME";
            col9.Format.FormatType = FormatType.DateTime;
            col9.Format.FormatString = "yyyy-MM-dd HH:mm:ss";
            col9.VisibleIndex = 8;
            col9.Width = 140;

            TreeListColumn col10 = treeList.Columns.Add();
            col10.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col10.Caption = Language.Get("INCOMMINGDATE"); // 입고일
            col10.FieldName = "INCOMMINGDATE";
            col10.Format.FormatType = FormatType.DateTime;
            col10.Format.FormatString = "yyyy-MM-dd HH:mm:ss";
            col10.VisibleIndex = 9;
            col10.Width = 140;

            TreeListColumn col11 = treeList.Columns.Add();
            col11.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col11.Caption = Language.Get("SHIPMENTDATE"); // 출하일자
            col11.FieldName = "SHIPMENTDATE";
            col11.Format.FormatType = FormatType.DateTime;
            col11.Format.FormatString = "yyyy-MM-dd HH:mm:ss";
            col11.VisibleIndex = 10;
            col11.Width = 140;

            TreeListColumn col12 = treeList.Columns.Add();
            col12.FieldName = "ACTUALLOTID";               // 실적 LOT ID
            col12.Visible = false;

            TreeListColumn col13 = treeList.Columns.Add();
            col13.FieldName = "PROCESSSEGMENTID";
            col13.Visible = false;

            treeList.OptionsView.ShowColumns = true;
            treeList.OptionsFind.AlwaysVisible = false;

            treeList.SetSortColumn("LOTLEVEL", SortOrder.Ascending);

            treeList.EndUpdate();
        }
        #endregion

        #region ▶ Grid 설정 |
        /// <summary>
        /// Grid 설정
        /// </summary>
        private void InitializeGrid()
        {
            #region ＃ 생산실적 Grid |
            grdLotWorkResult.GridButtonItem = GridButtonItem.Export;

            grdLotWorkResult.View.SetIsReadOnly();
            grdLotWorkResult.SetIsUseContextMenu(false);

            grdLotWorkResult.View.AddTextBoxColumn("LOTID", 150).SetTextAlignment(TextAlignment.Center);
            grdLotWorkResult.View.AddTextBoxColumn("WORKORDERID", 150).SetTextAlignment(TextAlignment.Center);
            grdLotWorkResult.View.AddTextBoxColumn("AREANAME", 120).SetTextAlignment(TextAlignment.Left);
            grdLotWorkResult.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 180).SetTextAlignment(TextAlignment.Left);
            grdLotWorkResult.View.AddTextBoxColumn("PRODUCTDEFID", 120).SetTextAlignment(TextAlignment.Center).SetIsHidden();
            grdLotWorkResult.View.AddTextBoxColumn("PARTNUMBER", 120).SetLabel("PRODUCTDEFID").SetTextAlignment(TextAlignment.Center);
            grdLotWorkResult.View.AddTextBoxColumn("PRODUCTDEFNAME", 250).SetTextAlignment(TextAlignment.Left);
            grdLotWorkResult.View.AddTextBoxColumn("WORKENDQTY", 80).SetTextAlignment(TextAlignment.Right)
                                .SetLabel("QTY");
            grdLotWorkResult.View.AddTextBoxColumn("TRACKINTIME", 140).SetTextAlignment(TextAlignment.Center).SetDisplayFormat("yyyy-MM-dd HH:mm:ss");
            grdLotWorkResult.View.AddTextBoxColumn("TRACKOUTTIME", 140).SetTextAlignment(TextAlignment.Center).SetDisplayFormat("yyyy-MM-dd HH:mm:ss");
            grdLotWorkResult.View.AddTextBoxColumn("WORKTIME", 80).SetTextAlignment(TextAlignment.Right);
            grdLotWorkResult.View.AddTextBoxColumn("TRACKINUSERNAME", 120).SetTextAlignment(TextAlignment.Center)
                                .SetLabel("WORKSTARTUSER");
            grdLotWorkResult.View.AddTextBoxColumn("TRACKOUTUSERNAME", 120).SetTextAlignment(TextAlignment.Center)
                                .SetLabel("WORKENDUSER");

            grdLotWorkResult.View.PopulateColumns();
            #endregion

            #region ＃ 자재 투입 실적 |
            grdInputMaterial.GridButtonItem = GridButtonItem.Export;

            grdInputMaterial.View.SetIsReadOnly();
            grdInputMaterial.SetIsUseContextMenu(false);

            grdInputMaterial.View.AddTextBoxColumn("LOTID", 150).SetTextAlignment(TextAlignment.Center);
            grdInputMaterial.View.AddTextBoxColumn("MATERIALLOTID", 150).SetTextAlignment(TextAlignment.Center);
            grdInputMaterial.View.AddTextBoxColumn("CONSUMABLEDEFID", 120).SetTextAlignment(TextAlignment.Left).SetIsHidden();
            grdInputMaterial.View.AddTextBoxColumn("PARTNUMBER", 120).SetLabel("CONSUMABLEDEFID").SetTextAlignment(TextAlignment.Left);
            grdInputMaterial.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 180).SetTextAlignment(TextAlignment.Left);
            grdInputMaterial.View.AddTextBoxColumn("CONSUMEDQTY", 80).SetTextAlignment(TextAlignment.Right);
            grdInputMaterial.View.AddTextBoxColumn("SERIALNO", 120).SetTextAlignment(TextAlignment.Center);
            grdInputMaterial.View.AddTextBoxColumn("CREATEDTIME", 140).SetTextAlignment(TextAlignment.Center).SetLabel("INCOMMINGDATE").SetDisplayFormat("yyyy-MM-dd HH:mm:ss");
            grdInputMaterial.View.AddTextBoxColumn("CUSTOMERNAME", 120).SetLabel("VENDOR");            //자재거래처명

            grdInputMaterial.View.PopulateColumns();
            #endregion

            #region ＃ 설비 |

            grdLotEquipment.GridButtonItem = GridButtonItem.Export;

            grdLotEquipment.View.SetIsReadOnly();
            grdLotEquipment.SetIsUseContextMenu(false);

            grdLotEquipment.View.AddTextBoxColumn("LOTID", 150).SetTextAlignment(TextAlignment.Center);
            grdLotEquipment.View.AddTextBoxColumn("EQUIPMENTID", 150).SetTextAlignment(TextAlignment.Center);
            grdLotEquipment.View.AddTextBoxColumn("EQUIPMENTNAME", 180).SetTextAlignment(TextAlignment.Left);
            grdLotEquipment.View.AddTextBoxColumn("TRACKINTIME", 140).SetTextAlignment(TextAlignment.Center).SetDisplayFormat("yyyy-MM-dd HH:mm:ss");
            grdLotEquipment.View.AddTextBoxColumn("TRACKOUTTIME", 140).SetTextAlignment(TextAlignment.Center).SetDisplayFormat("yyyy-MM-dd HH:mm:ss");
            grdLotEquipment.View.AddTextBoxColumn("QTY", 80).SetTextAlignment(TextAlignment.Right);

            grdLotEquipment.View.PopulateColumns();
            #endregion

            #region ＃ 출하검사 이력 |
            grdShippingInsp.GridButtonItem = GridButtonItem.Export;
            grdShippingInsp.View.SetIsReadOnly();

            // 검사일자
            grdShippingInsp.View.AddTextBoxColumn("INSPECTIONDATE", 150);
            //품목코드
            grdShippingInsp.View.AddTextBoxColumn("PRODUCTDEFID", 100).SetIsHidden();
            grdShippingInsp.View.AddTextBoxColumn("PARTNUMBER", 100).SetLabel("PRODUCTDEFID");
            //품목명
            grdShippingInsp.View.AddTextBoxColumn("PRODUCTDEFNAME", 150);
            //규격
            grdShippingInsp.View.AddTextBoxColumn("STANDARD", 110);
            //LOTID
            grdShippingInsp.View.AddTextBoxColumn("LOTID", 90).SetTextAlignment(TextAlignment.Center);
            //공정
            grdShippingInsp.View.AddTextBoxColumn("PROCESSSEGMENT", 80);
            //팀
            grdShippingInsp.View.AddTextBoxColumn("TEAM", 80);
            //수량
            grdShippingInsp.View.AddTextBoxColumn("QTY", 50).SetTextAlignment(TextAlignment.Right);
            //검사자
            grdShippingInsp.View.AddTextBoxColumn("INSPECTOR", 70).SetTextAlignment(TextAlignment.Center);
            //검사자2
            grdShippingInsp.View.AddTextBoxColumn("INSPECTOR2", 70).SetTextAlignment(TextAlignment.Center);
            //확정여부
            grdShippingInsp.View.AddTextBoxColumn("ISCONFIRM", 60).SetTextAlignment(TextAlignment.Center);
            //검사결과
            grdShippingInsp.View.AddTextBoxColumn("A", 40).SetTextAlignment(TextAlignment.Center);
            grdShippingInsp.View.AddTextBoxColumn("B", 40).SetTextAlignment(TextAlignment.Center);
            grdShippingInsp.View.AddTextBoxColumn("C", 40).SetTextAlignment(TextAlignment.Center);
            grdShippingInsp.View.AddTextBoxColumn("D", 40).SetTextAlignment(TextAlignment.Center);
            grdShippingInsp.View.AddTextBoxColumn("E", 40).SetTextAlignment(TextAlignment.Center);
            grdShippingInsp.View.AddTextBoxColumn("F", 40).SetTextAlignment(TextAlignment.Center);
            grdShippingInsp.View.AddTextBoxColumn("G", 40).SetTextAlignment(TextAlignment.Center);
            grdShippingInsp.View.AddTextBoxColumn("H", 40).SetTextAlignment(TextAlignment.Center);

            grdShippingInsp.View.PopulateColumns();
            #endregion

            #region ＃ X번 관리 이력 |
            grdXmanage.GridButtonItem = GridButtonItem.Export;
            grdXmanage.View.OptionsNavigation.AutoMoveRowFocus = false;

            //관리번호
            var group1 = grdXmanage.View.AddGroupColumn("MANAGENUMBER");
            //X번호
            group1.AddTextBoxColumn("XNUMBER", 80).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            //Claim no
            group1.AddTextBoxColumn("CLAIMNUMBER", 80).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            //발행일자
            group1.AddTextBoxColumn("PUBLISHDATE", 90).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            //Claim 구분
            group1.AddTextBoxColumn("CLAIMTYPE", 60).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            //보고서
            group1.AddTextBoxColumn("ISREPORT", 60).SetTextAlignment(TextAlignment.Center).SetLabel("REPORT");
            //발행자
            group1.AddTextBoxColumn("PUBLISHER", 60).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();

            //유형구분
            var group2 = grdXmanage.View.AddGroupColumn("DIVISIONTYPE");
            //진행상태
            group2.AddTextBoxColumn("PROGRESSSTATE", 60).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            //경과일
            group2.AddTextBoxColumn("ELAPSEDDAY", 50).SetTextAlignment(TextAlignment.Right).SetIsReadOnly();
            //유/무상
            group2.AddTextBoxColumn("CHARGETYPE", 60).SetTextAlignment(TextAlignment.Center);
            //유형
            group2.AddTextBoxColumn("XTYPE", 80);
            //Troble분류
            group2.AddTextBoxColumn("TROUBLETYPE", 80);

            //제품정보
            var group3 = grdXmanage.View.AddGroupColumn("PRODUCTINFO");
            //제품군
            group3.AddTextBoxColumn("ITEMFAMILY", 100);
            //제조사
            group3.AddTextBoxColumn("MANUFACTURERID", 70);
            //기종
            group3.AddTextBoxColumn("MODELID", 100);
            //제조번호
            group3.AddTextBoxColumn("MANUFACTURENUMBER", 70).SetTextAlignment(TextAlignment.Center);
            //ETM(H)
            group3.AddTextBoxColumn("ETMHOUR", 70).SetTextAlignment(TextAlignment.Right);

            //고객정보
            var group4 = grdXmanage.View.AddGroupColumn("CUSTOMERINFO");
            //지역
            group4.AddTextBoxColumn("CUSTOMERREGIONID", 60).SetTextAlignment(TextAlignment.Center);
            //거래선
            group4.AddTextBoxColumn("CUSTOMERBASE", 100);
            //장치사
            group4.AddTextBoxColumn("DEVICECUSTOMERID", 80);
            //고객사
            group4.AddTextBoxColumn("CUSTOMERID", 80).SetIsHidden();
            group4.AddTextBoxColumn("CUSTOMERNAME", 120);

            //LINE
            group4.AddTextBoxColumn("LINEID", 50).SetTextAlignment(TextAlignment.Center);
            //소재지 
            group4.AddTextBoxColumn("CUSTOMERLOCATION", 80);
            //담당자 
            group4.AddTextBoxColumn("CUSTOMERMANAGER", 60).SetTextAlignment(TextAlignment.Center);
            //연락처 
            group4.AddTextBoxColumn("TELLNUMBER", 100).SetTextAlignment(TextAlignment.Center);

            //무상비용
            var group5 = grdXmanage.View.AddGroupColumn("UNPAID");
            //고정비
            group5.AddTextBoxColumn("FIXEDCOST", 70).SetTextAlignment(TextAlignment.Right);
            //변동비
            group5.AddTextBoxColumn("VARIABLECOST", 70).SetTextAlignment(TextAlignment.Right);
            //처리월
            group5.AddTextBoxColumn("PROCESSMONTH", 60).SetTextAlignment(TextAlignment.Center);

            //유상비용
            var group6 = grdXmanage.View.AddGroupColumn("PAID");
            //수주액
            group6.AddTextBoxColumn("ORDERPRICE", 70).SetTextAlignment(TextAlignment.Right);
            //수주월
            group6.AddTextBoxColumn("ORDERMONTH", 60).SetTextAlignment(TextAlignment.Center);
            //매출액
            group6.AddTextBoxColumn("SALESPRICE", 70).SetTextAlignment(TextAlignment.Right);
            //매출월
            group6.AddTextBoxColumn("SALESMONTH", 60).SetTextAlignment(TextAlignment.Center);
            //Claim 정보
            var group7 = grdXmanage.View.AddGroupColumn("CLAIMINFO");
            //발생일
            group7.AddTextBoxColumn("OCCURDATE", 90).SetTextAlignment(TextAlignment.Center).SetDisplayFormat("yyyy-MM-dd", MaskTypes.DateTime);
            //현상 
            group7.AddTextBoxColumn("STATEDESC", 150);
            //대응 
            group7.AddTextBoxColumn("RESPONSEDESC", 150);
            //대응처
            group7.AddTextBoxColumn("RESPONSEFROM", 100);
            //완료일
            group7.AddTextBoxColumn("COMPLETEDATE", 90).SetTextAlignment(TextAlignment.Center).SetDisplayFormat("yyyy-MM-dd", MaskTypes.DateTime);

            var group8 = grdXmanage.View.AddGroupColumn("ACTIONRESULT");
            //진행현황
            group8.AddTextBoxColumn("PROGRESSDESC", 250);

            //출하일자
            grdXmanage.View.AddTextBoxColumn("SHIPMENTDATE").SetIsHidden();

            grdXmanage.View.PopulateColumns();
            #endregion

            #region 작업실적
            grdWorkresultDetail.View.SetIsReadOnly();
            grdWorkresultDetail.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;

            grdWorkresultDetail.GridButtonItem = GridButtonItem.Export;
            grdWorkresultDetail.View.OptionsNavigation.AutoMoveRowFocus = false;
            //스펙 ID
            grdWorkresultDetail.View.AddTextBoxColumn("SPECDEFID", 100).SetTextAlignment(TextAlignment.Center);
            //순서
            grdWorkresultDetail.View.AddTextBoxColumn("USERSEQUENCE", 50).SetLabel("SPECSEQ").SetTextAlignment(TextAlignment.Center);
            //세부공정
            grdWorkresultDetail.View.AddTextBoxColumn("SUBPROCESSSEGMENTNAME", 150);
            //실적입력항목 INPUTRESULTITEM
            grdWorkresultDetail.View.AddTextBoxColumn("PARAMETERNAME", 250).SetLabel("INPUTRESULTITEM");
            //실적값 RESULTVALUE
            grdWorkresultDetail.View.AddTextBoxColumn("MEASUREVALUE", 90).SetLabel("RESULTVALUE");
            //단위 UNIT
            grdWorkresultDetail.View.AddTextBoxColumn("UNIT", 50);
            //MIN
            grdWorkresultDetail.View.AddTextBoxColumn("LSL", 80).SetLabel("MIN");
            //MAX
            grdWorkresultDetail.View.AddTextBoxColumn("USL", 80).SetLabel("MAX");
            //생성일시
            grdWorkresultDetail.View.AddTextBoxColumn("CREATEDTIME", 140).SetTextAlignment(TextAlignment.Center).SetLabel("WORKDAY");
            //생성자
            grdWorkresultDetail.View.AddTextBoxColumn("CREATOR", 80).SetTextAlignment(TextAlignment.Center).SetLabel("WORKER");
            grdWorkresultDetail.View.PopulateColumns();

            grdWorkresultDetail.View.OptionsView.AllowCellMerge = true; // CellMerge
            grdWorkresultDetail.View.Columns["PARAMETERNAME"].OptionsColumn.AllowMerge = DefaultBoolean.False;
            grdWorkresultDetail.View.Columns["MEASUREVALUE"].OptionsColumn.AllowMerge = DefaultBoolean.False;
            grdWorkresultDetail.View.Columns["UNIT"].OptionsColumn.AllowMerge = DefaultBoolean.False;
            grdWorkresultDetail.View.Columns["LSL"].OptionsColumn.AllowMerge = DefaultBoolean.False;
            grdWorkresultDetail.View.Columns["USL"].OptionsColumn.AllowMerge = DefaultBoolean.False;
            grdWorkresultDetail.View.Columns["CREATEDTIME"].OptionsColumn.AllowMerge = DefaultBoolean.False;
            grdWorkresultDetail.View.Columns["CREATOR"].OptionsColumn.AllowMerge = DefaultBoolean.False;

            #endregion
        }
        #endregion

        #endregion

        #region ◆ Event |
        /// <summary>
        /// Event
        /// </summary>
        public void InitializeEvent()
        {
            // TreeList Event
            treeLotGeneal.FocusedNodeChanged += treeGeneal_FocusedNodeChanged;
            treeReverseTrace.FocusedNodeChanged += treeReverseTrace_FocusedNodeChanged;
            treeFowardTrace.FocusedNodeChanged += treeFowardTrace_FocusedNodeChanged;

            // 역방향 Tree Export Event
            lblExportReverse.MouseHover += LblExportReverse_MouseHover;
            lblExportReverse.MouseLeave += LblExportReverse_MouseLeave;
            lblExportReverse.Click += LblExportReverse_Click;

            lblExportForward2.MouseHover += LblExportForward2_MouseHover;
            lblExportForward2.MouseLeave += LblExportForward2_MouseLeave;
            lblExportForward2.Click += LblExportForward2_Click;
        }

        #region ▶ 역방향 Tree Export Event |
        /// <summary>
        /// 역방향 데이터 Export
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblExportReverse_Click(object sender, EventArgs e)
        {
            if (treeReverseTrace.FocusedNode == null)
            {
                return;
            }

            ExportToExcel(treeReverseTrace);
        }

        /// <summary>
        /// MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblExportReverse_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblExportReverse_MouseHover(object sender, EventArgs e)
        {
            lblExportReverse.Cursor = Cursors.Hand;
        }
        #endregion

        #region ▶ 정방향 Tree Export Event |
        /// <summary>
        /// 역방향 데이터 Export
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblExportForward2_Click(object sender, EventArgs e)
        {
            if (treeFowardTrace.FocusedNode == null)
            {
                return;
            }

            ExportToExcel(treeFowardTrace);
        }

        /// <summary>
        /// MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblExportForward2_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblExportForward2_MouseHover(object sender, EventArgs e)
        {
            lblExportForward2.Cursor = Cursors.Hand;
        }
        #endregion

        #region ▶ TreeList Event |

        #region ＃ TreeList Event |
        /// <summary>
        /// TreeList Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeGeneal_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            pnlContent.ShowWaitArea();
            DataRow focusRow = treeLotGeneal.GetFocusedDataRow();
            if (focusRow == null)
            {
                pnlContent.CloseWaitArea();
                return;
            }
            setLotTraceGrid(focusRow["LOTID"].ToString());
            pnlContent.CloseWaitArea();
        }
        #endregion

        #region ＃ 역방향 TREE LIST EVENT |
        /// <summary>
        /// 역방향 TREE LIST EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeReverseTrace_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            pnlContent.ShowWaitArea();
            DataRow focusRow = treeReverseTrace.GetFocusedDataRow();
            if (focusRow == null)
            {
                pnlContent.CloseWaitArea();
                return;
            }
            SetLotHistory(focusRow["LOTID"].ToString());
            pnlContent.CloseWaitArea();
        }
        #endregion

        #region ＃ 정방향 Lot Trace 선택 Event |
        /// <summary>
        /// 정방향 Lot Trace 선택 Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeFowardTrace_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            pnlContent.ShowWaitArea();

            if (treeFowardTrace.FocusedNode == null)
            {
                pnlContent.CloseWaitArea();
                return;
            }

            string lotid = treeFowardTrace.FocusedNode["ACTUALLOTID"].ToString();
            string processsegmentid = treeFowardTrace.FocusedNode["PROCESSSEGMENTID"].ToString();

            GetWorkResult(lotid);

            GetInspResult(lotid, processsegmentid);

            pnlContent.CloseWaitArea();
        } 
        #endregion
        #endregion

        #endregion

        #region ◆ 검색 |

        /// <summary>
        /// 비동기 override 모델
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            // 기존 Grid Data 초기화
            SetInitControl();

            var values = Conditions.GetValues();
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            string lotid = values["P_LOTNUM"].ToString();

            if(string.IsNullOrWhiteSpace(lotid))
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
                return;
            }

            getLotGeneal(lotid);
        }

        #endregion

        #region ◆ Private Function |

        #region ▶ Control Data 초기화 |
        /// <summary>
        /// Control Data 초기화
        /// </summary>
        private void SetInitControl()
        {
            // Data 초기화
            treeLotGeneal.DataSource = null;
            treeReverseTrace.DataSource = null;
            treeFowardTrace.DataSource = null;
        }
        #endregion

        #region ▶ LOT 가계도 조회 |
        /// <summary>
        /// LOT 이력 가계도 조회
        /// </summary>
        /// <param name="lotId"></param>
        private void getLotGeneal(string lotId)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            param.Add("LOTID", lotId);

            try
            {
                DataTable dt = SqlExecuter.Query("SelectLotGenealTreeList", "00001", param);
                treeLotGeneal.DataSource = dt;
                //treeLotGeneal.DataSource = SqlExecuter.Query("SelectLotGenealTreeList", "00001", param);
                treeLotGeneal.PopulateColumns();
                treeLotGeneal.ExpandAll();

                treeLotGeneal.SetFocusedNode(treeLotGeneal.FindNodeByKeyID(lotId));

                if(treeLotGeneal.DataSource != null && ((DataTable)treeLotGeneal.DataSource).Rows.Count < 1)
                {
                    setLotTraceGrid(lotId);
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region ▶ 역방향 LOT 추적 TREE LIST |
        /// <summary>
        /// 역방향 LOT 추적 TREE LIST
        /// </summary>
        /// <param name="lotID"></param>
        private void setLotTraceGrid(string lotID)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            param.Add("LOTID", lotID);

            try
            {
                DataTable dt = SqlExecuter.Query("SelectLotReverseHist", "00001", param);
                //treeReverseTrace.DataSource = SqlExecuter.Query("SelectLotReverseHist", "00001", param);
                treeReverseTrace.DataSource = dt;
                treeReverseTrace.PopulateColumns();
                treeReverseTrace.ExpandAll();

                treeReverseTrace.SetFocusedNode(treeLotGeneal.FindNodeByKeyID(lotID));
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region ▶ 최종 Lot 이력 조회 |
        /// <summary>
        /// 최종 Lot 이력 조회
        /// </summary>
        /// <param name="lotid"></param>
        private void SetLotHistory(string lotid)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            param.Add("LOTID", lotid);
            try
            {
                DataTable dt = SqlExecuter.Query("SelectLotGenealTreeList", "00002", param);
                DataTable dtTree = dt.DefaultView.ToTable(false, new string[] { "LOTID", "PARENTLOTID","PROCESSSEGMENTNAME", "PRODUCTDEFNAME", "QTY", "LOTLEVEL", "PATH", "WORKSTARTTIME", "WORKENDTIME", "INCOMMINGDATE", "SHIPMENTDATE", "ACTUALLOTID", "PROCESSSEGMENTID" });
                BindTreeData(treeFowardTrace, dtTree);
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region ▶ 생산실적 조회 |
        /// <summary>
        /// 생산실적 조회
        /// </summary>
        /// <param name="lotid"></param>
        private void GetWorkResult(string lotid)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            param.Add("LOTID", lotid);
            param.Add("DBLINKNAME", CommonFunction.DbLinkName);

            try
            {
                // 생산실적
                DataTable dt = SqlExecuter.Query("SelectLotTraceWorkResult", "00001", param);

                grdLotWorkResult.DataSource = dt;

                // 자재투입실적
                DataTable dt2 = SqlExecuter.Query("SelectLotTraceLotMaterial", "00001", param);

                grdInputMaterial.DataSource = dt2;

                // 설비 실적
                DataTable dt3 = SqlExecuter.Query("SelectLotTraceLotEquipment", "00001", param);

                grdLotEquipment.DataSource = dt3;

                // X번 관리 이력
                Dictionary<string, object> param2 = new Dictionary<string, object>();
                param2.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
                param2.Add("P_MANUFACTURENUMBER", lotid);
                param2.Add("DBLINKNAME", CommonFunction.DbLinkName);

                DataTable dt4 = SqlExecuter.Query("SelectLotTraceLotXManageList", "00002", param2);

                grdXmanage.DataSource = dt4;

                // 출하검사
                Dictionary<string, object> param3 = new Dictionary<string, object>();
                param3.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
                param3.Add("P_LOTID", lotid);

                DataTable dt5 = SqlExecuter.Query("SelectSearchProductOQC", "00001", param3);

                grdShippingInsp.DataSource = dt5; 

                // 작업실적 ('22.04.18 scmo 추가)
                DataTable dt6 = SqlExecuter.Query("SearchAssyWorkResult", "00001", param);
                grdWorkresultDetail.DataSource = dt6;
            }
            catch (Exception ex)
            {
            }
        }

        // 검사실적 ('22.04.18 scmo 추가)
        private void GetInspResult(string lotid, string processsegmentid)
        {         
            DataTable dt7 = new DataTable();

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("LOTID", lotid);
        
            if (processsegmentid.Equals("SGM016"))  //펌프조립
            {
                dt7 = SqlExecuter.Query("SearchRepTimeData", "00001", param);
            }
            else if(processsegmentid.Equals("SGM014"))  //냉동기조립
            {
                dt7 = SqlExecuter.Query("SearchPumpTimeData", "00001", param);
            }


        }
        #endregion

        #region ▶ Tree List Grid Data Bind |
        /// <summary>
        /// Tree List Grid Data Bind
        /// </summary>
        /// <param name="smartTree"></param>
        /// <param name="dt"></param>
        private void BindTreeData(TreeList smartTree, DataTable dt)
        {
            smartTree.Nodes.Clear();

            int lastDepth = 0;
            TreeListNode node = null;
            Stack<TreeListNode> stack = new Stack<TreeListNode>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int depth = Int32.Parse(dr["LOTLEVEL"].ToString());

                if (depth == 1)
                {
                    stack.Clear();

                    node = smartTree.Nodes.Add(dr);
                    stack.Push(node);
                    lastDepth = depth;
                }
                else
                {
                    int removeCount = lastDepth - depth + 1;
                    for (int j = 0; j < removeCount; j++)
                    {
                        stack.Pop();
                    }

                    node = stack.Pop();
                    stack.Push(node);

                    node = node.Nodes.Add(dr);
                    stack.Push(node);
                    lastDepth = depth;
                }
            }

            smartTree.ExpandAll();
        }
        #endregion

        #region ▶ TreeList Export Excel :: ExportToExcel |
        /// <summary>
        /// TreeList Export Excel
        /// </summary>
        /// <param name="treeList"></param>
        private void ExportToExcel(SmartTreeList treeList)
        {
            using (var saveFileDialog = new SaveFileDialog { Filter = "XLSX file|*.xlsx|XLS file|*.xls", Title = "Save an Excel File" })
            {
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != string.Empty)
                {
                    var fileStream = (System.IO.FileStream)saveFileDialog.OpenFile();

                    treeList.ExportToXlsx(fileStream);
                    fileStream.Close();

                    ProcessStartInfo psi = new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true };
                    Process.Start(psi);
                }
            }
        } 
        #endregion

        #endregion
    }
}

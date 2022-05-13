#region using

using DevExpress.Data.TreeList;
using DevExpress.Utils;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;
using Micube.SmartMES.Commons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 코드관리 > BOM 정보
    /// 업  무  설  명  : BOM 정보를 관리한다.
    /// 생    성    자  : JYLEE
    /// 생    성    일  : 2019-03-05
    /// 수  정  이  력  : 2020-05-07 | scmo | ERP연동에 따른 쿼리 및 컬럼변경
    ///                  2020-05-28 유태근 / 화면 디자인 수정 및 데이터 조회쿼리 수정
    ///                  2020-07-16 유태근 / 품목코드 변경 
    /// 
    /// </summary>
    public partial class BomInfo : SmartConditionBaseForm
    {
        #region Local Variables

        #endregion

        #region 생성자

        public BomInfo()
        {
            InitializeComponent();
        }

        #endregion

        #region 컨텐츠 영역 초기화

        /// <summary>
        /// 화면의 컨텐츠 영역을 초기화한다.
        /// </summary>
        protected override void InitializeContent() 
        {
            base.InitializeContent();

            InitializeEvent();
            InitializeTree();
        }

        /// <summary>        
        /// BOM 트리를 초기화한다.
        /// </summary>
        private void InitializeTree()
        {
            gbxBomTree.GridButtonItem = GridButtonItem.Export;

            CreateTreeColumn(bomTree); // 트리컬럼 생성
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            bomTree.NodeCellStyle += BomTree_NodeCellStyle;
            gbxBomTree.HeaderButtonClickEvent += GbxBomTree_HeaderButtonClickEvent;
            bomTree.KeyDown += BomTree_KeyDown;
        }

        /// <summary>
        /// 최상위 노드의 스타일 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BomTree_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                e.Appearance.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                e.Appearance.BackColor = Color.Gainsboro;
                e.Appearance.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Excel Export
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GbxBomTree_HeaderButtonClickEvent(object sender, HeaderButtonClickArgs args)
        {
            if(args.ClickItem == GridButtonItem.Export)
            {
                ExportToExcel(this.bomTree);
            }
        }

        /// <summary>
        /// 특정 셀만 복사 (알박요청)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BomTree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                TreeList treeList = (TreeList)sender;
                Clipboard.SetText(treeList.FocusedNode.GetDisplayText(treeList.FocusedColumn));
                e.Handled = true;
            }
        }

        #endregion

        #region 툴바

        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            //base.OnToolbarSaveClick();

            //grdClaimInfo.View.PostEditor();
            //grdClaimInfo.View.UpdateCurrentRow();

            //DataTable changed = grdClaimInfo.GetChangedRows();

            //if (changed.Rows.Count < 1)
            //{
            //    this.ShowMessage("NoSaveData");
            //    return;
            //}

            //MessageWorker worker = new MessageWorker("SaveClaimManagerReg");
            //worker.SetBody(new MessageBody()
            //{
            //    { "list", changed }, // 저장할 데이터테이블
            //});
            //worker.Execute();
        }

        /// <summary>
        /// 툴바버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            SmartButton btn = sender as SmartButton;

            // 시정조치의뢰서 버튼클릭
            if (btn.Name.ToString().Equals("ClaimReferral"))
            {
                //BtnLabelPrint_Click(null, null);
            }
        }

        #endregion

        #region 검색

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);
            values.Add("DBLINKNAME", CommonFunction.DbLinkName);

            DataTable bomTreeDt = await QueryAsync("SelectBomTreeList", "00001", values);

            if (bomTreeDt.Rows.Count < 1)
            {
                // 조회할 데이터가 없습니다.
                this.ShowMessage("NoSelectData");
                bomTree.DataSource = null;
                bomTree.ClearNodes();
                return;
            }

            CreateTreeNode(bomTree, bomTreeDt); // 트리노드 생성
            //BindTreeData(bomTree, bomTreeDt, "LEVEL");

            /* 
             * 2020-05-28 유태근 / 불필요한 코드 주석처리
            DataTable dtBom = await QueryAsync("GetBom", "00001", values);
            dtBom.Columns.Add("CHILDNOKEY", typeof(string));
            dtBom.Columns.Add("PARENTNOKEY", typeof(string));

            if (dtBom.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            int i = 0;

            foreach(DataRow row in dtBom.Rows)
            {
                row["CHILDNOKEY"] = row["CHILDITEMID"].ToString() + "_PRKEY_" + i.ToString();
                row["PARENTNOKEY"] = row["PARENTITEMID"].ToString() + "_PRKEY_" + i.ToString();
                i++;
            }

            //treeBom.SetMember("ITEMID", "PARTNOKEY", "PARENTITEMID");

            //treeBom.KeyFieldName = "ITEMID";
            //treeBom.ParentFieldName = "PARENTITEMID";
            //treeBom.KeyFieldName = "CHILDNOKEY";
            //treeBom.ParentFieldName = "PARENTNOKEY";
            //treeBom.DataSource = dtBom;
            //treeBom.PopulateColumns();
            ////treeBom.ExpandAll();
            //treeBom.ExpandToLevel(1);
            *
            */
        }

        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

            InitializeConditionPopup_Product();
        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();
        }

        /// <summary>
        /// 품목 조회조건
        /// </summary>
        private void InitializeConditionPopup_Product()
        {
            // 팝업 컬럼설정
            var productPopup = Conditions.AddSelectPopup("P_PRODUCTDEFID", new SqlQuery("GetBomProductList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "PRODUCTDEFNAME", "PRODUCTDEFSEQ")
               .SetPopupLayout("PRODUCT", PopupButtonStyles.Ok_Cancel, true, true)
               .SetPopupLayoutForm(600, 800)
               .SetLabel("PRODUCT")
               .SetPopupAutoFillColumns("PRODUCTDEFNAME")
               .SetPopupResultCount(1)
               .SetValidationIsRequired();

            // 팝업 조회조건
            productPopup.Conditions.AddTextBox("PRODUCTDEFIDNAME");

            // 팝업 그리드
            productPopup.GridColumns.AddTextBoxColumn("PRODUCTDEFID", 120);
            productPopup.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 220);
            productPopup.GridColumns.AddTextBoxColumn("PRODUCTDEFVERSION", 80);
            productPopup.GridColumns.AddTextBoxColumn("PRODUCTDEFSEQ", 100)
                .SetIsHidden();
            productPopup.GridColumns.AddTextBoxColumn("PRODUCTDEFIDVERSION", 100)
                .SetIsHidden();
        }

        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터를 저장 할 때 컨텐츠 영역의 유효성을 검사한다.
        /// </summary>
        protected override void OnValidateContent()
        {
            //base.OnValidateContent();

            //// TODO : 유효성 로직 변경
            //grdClaimInfo.View.CheckValidation();

            //DataTable changed = grdClaimInfo.GetChangedRows();

            //if (changed.Rows.Count == 0)
            //{
            //    // 저장할 데이터가 존재하지 않습니다.
            //    throw MessageException.Create("NoSaveData");
            //}
        }

        #endregion

        #region Private Function

        /// <summary>
        /// 트리컬럼 생성
        /// </summary>
        /// <param name="treeList"></param>
        private void CreateTreeColumn(TreeList treeList)
        {
            treeList.BeginUpdate();

            treeList.RowHeight = 24;
            treeList.KeyFieldName = "PATH";
            
            TreeListColumn col1 = treeList.Columns.Add();
            col1.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col1.Caption = Language.Get("PRODUCTDEFID"); // 품목NUMBER
            col1.FieldName = "PRODUCTDEFNUMBER";
            col1.VisibleIndex = 0;          
            TreeListColumn col2 = treeList.Columns.Add();
            col2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col2.Caption = Language.Get("PRODUCTDEFNAME"); // 품목명
            col2.FieldName = "PRODUCTDEFNAME";
            col2.VisibleIndex = 1;
            TreeListColumn col3 = treeList.Columns.Add();
            col3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col3.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            col3.Caption = Language.Get("REQUIREMENTQTY"); // 소요량
            col3.FieldName = "NEEDQTY";
            col3.VisibleIndex = 2;
            TreeListColumn col4 = treeList.Columns.Add();
            col4.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col4.Caption = Language.Get("STANDARD"); // 규격
            col4.FieldName = "STANDARD";
            col4.VisibleIndex = 3;
            TreeListColumn col5 = treeList.Columns.Add();
            col5.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col5.Caption = Language.Get("THISTEAM"); // 팀
            col5.FieldName = "TEAM";
            col5.VisibleIndex = 4;
            TreeListColumn col6 = treeList.Columns.Add();
            col6.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col6.Caption = Language.Get("MODELID"); // 기종
            col6.FieldName = "MODEL";
            col6.VisibleIndex = 5;
            TreeListColumn col7 = treeList.Columns.Add();
            col7.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col7.Caption = Language.Get("UNIT"); // 단위
            col7.FieldName = "UNIT";
            col7.VisibleIndex = 6;
            TreeListColumn col8 = treeList.Columns.Add();
            col8.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col8.Caption = Language.Get("PATH"); // 순차구조(품목ID)
            col8.FieldName = "PATH";
            col8.VisibleIndex = 7;
            col8.Visible = false;
            TreeListColumn col9 = treeList.Columns.Add();
            col9.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col9.Caption = Language.Get("NUMPATH"); // 순차구조(품목NUMBER)
            col9.FieldName = "NUMPATH";
            col9.VisibleIndex = 8;
            col9.Visible = false;
            TreeListColumn col10 = treeList.Columns.Add();
            col10.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col10.Caption = Language.Get("PRODUCTDEFSEQ"); // 품목ID
            col10.FieldName = "PRODUCTDEFID";
            col10.VisibleIndex = 9;
            col10.Visible = false;

            treeList.OptionsView.ShowColumns = true;
            treeList.OptionsFind.AlwaysVisible = false;
            treeList.OptionsCustomization.AllowFilter = false;
            treeList.OptionsCustomization.AllowSort = false;

            //treeList.OptionsView.ShowSummaryFooter = true;
            //TreeListColumn column = treeList.Columns["NEEDQTY"];
            //column.AllNodesSummary = true;
            //column.SummaryFooterStrFormat = "Total: {0:0}";
            //column.SummaryFooter = SummaryItemType.Sum;

            treeList.EndUpdate();
        }

        /// <summary>
        /// 트리데이터 바인딩
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="treeTable"></param>
        private void CreateTreeNode(TreeList treeList, DataTable treeTable)
        {
            //treeList.BeginUnboundLoad();

            treeList.ClearNodes();

            treeList.OptionsBehavior.Editable = false;
            treeList.OptionsView.ShowColumns = true;
            treeList.OptionsView.ShowIndicator = false;

            //var data = from row in treeTable.AsEnumerable()
            //           group row by row["ROOTPRODUCTDEFID"] into gg
            //           select new
            //           {
            //               id = gg.Select(r => r.Field<string>("ROOTPRODUCTDEFID")),
            //               name = gg.Select(r => r.Field<string>("ROOTPRODUCTDEFNAME")),
            //               standard = gg.Select(r => r.Field<string>("STANDARD")),
            //               team = gg.Select(r => r.Field<string>("TEAMID")),
            //               unit = gg.Select(r => r.Field<string>("UNIT")),
            //           };  

            // 최상위(0 Level) 노드 생성
            foreach (var data in treeTable.AsEnumerable().Select(r => new { id = r["ROOTPRODUCTDEFID"], number = r["ROOTPRODUCTDEFNUMBER"], name = r["ROOTPRODUCTDEFNAME"], standard = r["STANDARD"], team = r["TEAMNAME"], model = r["MODELNAME"], unit = r["UNIT"] })
                                                         .Distinct())
            {
                treeList.Nodes.Add(new object[] { data.number, data.name, null, data.standard, data.team, data.model, data.unit, null, null, data.id });
                treeList.SetFocusedNode(treeList.FindNodeByFieldValue("PRODUCTDEFID", data.id));
               
                // 하위 노드 레벨에 따라 노드 생성
                foreach (DataRow row in treeTable.AsEnumerable().Where(r => r["ROOTPRODUCTDEFID"].Equals(data.id)))
                {
                    int level = Format.GetInteger(row["LEVEL"]); // 노드레벨
                    string[] pathId = Format.GetString(row["PATH"]).Split('|'); // 노드멤버(ID)
                    string[] pathNumber = Format.GetString(row["NUMPATH"]).Split('|'); // 노드멤버(NUMBER)
                    string[] pathName = string.IsNullOrWhiteSpace(Format.GetString(row["PATHNAME"])) ? new string[10] { "", "", "", "", "", "", "", "", "", "" } : Format.GetString(row["PATHNAME"]).Split('|'); // 노드멤버(명)
                    string[] pathQty = Format.GetString(row["NEEDQTYPATH"]).Split('|'); // 노드멤버(소요량)

                    switch (level)
                    {
                        case 1: // 1레벨
                            treeList.AppendNode(new object[] { pathNumber[1], pathName[1], string.Format("{0:0.00}", Format.GetDouble(pathQty[0], 0.0)), null, null, null, null, row["PATH"], row["NUMPATH"], pathId[1] }, treeList.FindNodeByFieldValue("PRODUCTDEFID", data.id));
                            break;
                        case 2: // 2레벨
                            string lv2PrevDefId = Format.GetString(treeList.FindNodeByFieldValue("PRODUCTDEFID", data.id).LastNode.GetValue("PATH")).Split('|')[1];
                            string lv2KeyPath = Format.GetString(row["PATH"]).Split('|')[0] + "|" + Format.GetString(row["PATH"]).Split('|')[1];

                            if (pathId[1].Equals(lv2PrevDefId))
                            {
                                treeList.AppendNode(new object[] { pathNumber[2], pathName[2], string.Format("{0:0.00}", Format.GetDouble(pathQty[1], 0.0)), null, null, null, null, row["PATH"], row["NUMPATH"], pathId[2] }, treeList.FindNodeByFieldValue("PATH", lv2KeyPath));
                            }
                            break;
                        case 3: // 3레벨
                            string lv3TwoPrevDefId = Format.GetString(treeList.FindNodeByFieldValue("PRODUCTDEFID", data.id).LastNode.GetValue("PATH")).Split('|')[1];
                            string lv3PrevDefId = Format.GetString(treeList.FindNodeByFieldValue("PRODUCTDEFID", lv3TwoPrevDefId).LastNode.GetValue("PATH")).Split('|')[2];
                            string lv3KeyPath = Format.GetString(row["PATH"]).Split('|')[0] + "|" + Format.GetString(row["PATH"]).Split('|')[1] + "|" + Format.GetString(row["PATH"]).Split('|')[2];

                             if (pathId[1].Equals(lv3TwoPrevDefId))
                            {
                                if (pathId[2].Equals(lv3PrevDefId))
                                {                                
                                    treeList.AppendNode(new object[] { pathNumber[3], pathName[3], string.Format("{0:0.00}", Format.GetDouble(pathQty[2], 0.0)), null, null, null, null, row["PATH"], row["NUMPATH"], pathId[3] }, treeList.FindNodeByFieldValue("PATH", lv3KeyPath));
                                }
                            }
                            break;
                        case 4: // 4레벨
                            string lv4ThreePrevDefId = Format.GetString(treeList.FindNodeByFieldValue("PRODUCTDEFID", data.id).LastNode.GetValue("PATH")).Split('|')[1];
                            string lv4TwoPrevDefId = Format.GetString(treeList.FindNodeByFieldValue("PRODUCTDEFID", lv4ThreePrevDefId).LastNode.GetValue("PATH")).Split('|')[2];
                            string lv4PrevDefId = Format.GetString(treeList.FindNodeByFieldValue("PRODUCTDEFID", lv4TwoPrevDefId).LastNode.GetValue("PATH")).Split('|')[2];
                            string lv4KeyPath = Format.GetString(row["PATH"]).Split('|')[0] + "|" + Format.GetString(row["PATH"]).Split('|')[1] + "|" + Format.GetString(row["PATH"]).Split('|')[2] + "|" + Format.GetString(row["PATH"]).Split('|')[3];

                            if (pathId[1].Equals(lv4ThreePrevDefId))
                            {
                                if (pathId[2].Equals(lv4TwoPrevDefId))
                                {
                                    if (pathId[3].Equals(lv4PrevDefId))
                                    {
                                        treeList.AppendNode(new object[] { pathNumber[4], pathName[4], string.Format("{0:0.00}", Format.GetDouble(pathQty[3], 0.0)), null, null, null, null, row["PATH"], row["NUMPATH"], pathId[4] }, treeList.FindNodeByFieldValue("PATH", lv4KeyPath));
                                    }                                 
                                }
                            }
                            break;
                    }
                }

                //CustomSummaryNode(treeList.FocusedNode);
            }

            treeList.BestFitColumns();
            treeList.ExpandAll();

            //treeList.EndUnboundLoad();
        }

        /// <summary>
        /// 루트노트의 모든 하위노드를 다 그릴때마다 계산해서 각각의 노드에 맞는 소요량을 계산해주는 함수
        /// </summary>
        /// <param name="rootNode"></param>
        private void CustomSummaryNode(TreeListNode rootNode)
        {
            IEnumerator enumerator = rootNode.Nodes.GetEnumerator();
            
            double needQty = 0; // 소요량

            while (enumerator.MoveNext())
            {
                TreeListNode currentNode = (TreeListNode)enumerator.Current;

                if (currentNode.HasChildren)
                {
                    CustomSummaryNode(currentNode);
                }

                needQty += Format.GetDouble(currentNode.GetValue("NEEDQTY"), 0.0);
                string needQtyStr = string.Format("{0:0.00}", needQty);

                currentNode.ParentNode.SetValue("NEEDQTY", needQtyStr);
            }
        }

        /// <summary>
        /// 테스트중
        /// </summary>
        /// <param name="smartTree"></param>
        /// <param name="dt"></param>
        /// <param name="depthColumnName"></param>
        private void BindTreeData(SmartTreeList smartTree, DataTable dt, string depthColumnName)
        {
            smartTree.Nodes.Clear();

            int lastDepth = 0;
            TreeListNode node = null;
            Stack<TreeListNode> stack = new Stack<TreeListNode>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int depth = Int32.Parse(dr[depthColumnName].ToString());

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
    }
}

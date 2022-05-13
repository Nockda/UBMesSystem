#region using
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.SmartMES.Commons;
using Micube.Framework.SmartControls.Grid.BandedGrid;
using Micube.Framework.SmartControls.Grid;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Micube.SmartMES.Commons.Controls;
#endregion

namespace Micube.SmartMES.Material
{
    /// <summary>
    /// 프 로 그 램 명  : 자재관리 > 항목 > 자재Lot 보류 해제
    /// 업  무  설  명  : 자재Lot 보류 해제 설정
    /// 생    성    자  : 강유라
    /// 생    성    일  : 2020-06-09
    /// 수  정  이  력  : 2020-07-17 | 이준용 | (PARTNUMBER) ERP품번
    /// 
    /// 
    /// </summary>
    public partial class ConsumableLotHoldRelease : SmartConditionBaseForm
    {
        #region ◆ Local Variables |

        #endregion

        #region ◆ 생성자 |
        /// <summary>
        /// 생성자
        /// </summary>
        public ConsumableLotHoldRelease()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Form_Load(object sender, EventArgs e)
        {
            InitializeComboBox();
            InitializeGrid();
        }
        #endregion

        #region ◆ 컨텐츠 영역 초기화 |
        /// <summary>
        /// Control 설정
        /// </summary>
        protected override void InitializeContent()
        {
            base.InitializeContent();

            // Up / Down Control 설정
            this.ucDataUpDownBtnCtrl.SourceGrid = this.grdConsumLot;
            this.ucDataUpDownBtnCtrl.TargetGrid = this.grdHoldRelease;

            InitializeEvent();


        }

        #region ▶ 조회조건 설정 |
        /// <summary>
        /// 검색조건 설정
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

            ConditionHelper.AddConditionConsumProductPopup("p_itemId", 1.2, false, Conditions);
        }

        /// <summary>
        /// 조회조건 설정
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

        }
        #endregion

        #region ▶ ComboBox 초기화 |
        /// <summary>
        /// 콤보박스를 초기화 하는 함수
        /// </summary>
        private void InitializeComboBox()
        {
            #region - 보류사유 ComboBox |
            // 분류 ComboBox 설정
            cboHoldReleaseReason.Editor.ComboBoxColumnShowType = ComboBoxColumnShowType.DisplayMemberOnly;
            cboHoldReleaseReason.Editor.ValueMember = "CODEID";
            cboHoldReleaseReason.Editor.DisplayMember = "CODENAME";

            cboHoldReleaseReason.Editor.DataSource = SqlExecuter.Query("GetCodeList", "00001"
                    , new Dictionary<string, object>() { { "LANGUAGETYPE", UserInfo.Current.LanguageType }, { "CODECLASSID", "ConsumLotHoldReleaseReason" } });

            cboHoldReleaseReason.Editor.ShowHeader = false;
            #endregion
        }
        #endregion

        #region ▶ Grid 설정 |
        /// <summary>        
        /// 그리드 초기화
        /// </summary>
        private void InitializeGrid()
        {
            #region - 재공 Grid 설정 |
            grdConsumLot.GridButtonItem = GridButtonItem.Export;

            grdConsumLot.View.SetIsReadOnly();

            // CheckBox 설정
            this.grdConsumLot.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            grdConsumLot.View.AddTextBoxColumn("CONSUMABLELOTID", 200);
            grdConsumLot.View.AddTextBoxColumn("TXNHISTKEY", 200).SetIsHidden();
            grdConsumLot.View.AddTextBoxColumn("AREANAME", 150);
            grdConsumLot.View.AddTextBoxColumn("CONSUMABLEDEFID", 150).SetIsHidden();
            grdConsumLot.View.AddTextBoxColumn("PARTNUMBER", 150);
            grdConsumLot.View.AddTextBoxColumn("CONSUMABLEDEFVERSION", 80);
            grdConsumLot.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 200);
            grdConsumLot.View.AddTextBoxColumn("LOCATIONID", 70);
            grdConsumLot.View.AddTextBoxColumn("CREATEDQTY", 80).SetDisplayFormat("{0:#,###}");
            grdConsumLot.View.AddTextBoxColumn("CONSUMABLELOTQTY", 80).SetDisplayFormat("{0:#,###}");
            grdConsumLot.View.AddTextBoxColumn("HOLDREASONCODENAME", 80).SetLabel("HOLDREASON");
            grdConsumLot.View.AddTextBoxColumn("HOLDCOMMENTS", 100);
            grdConsumLot.View.AddTextBoxColumn("HOLDDATE", 140).SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetTextAlignment(TextAlignment.Center);
            grdConsumLot.View.AddTextBoxColumn("HOLDUSERNAME", 80);

            grdConsumLot.View.PopulateColumns();

            #endregion

            #region - Hold Grid |
            grdHoldRelease.GridButtonItem = GridButtonItem.None;

            grdHoldRelease.View.SetIsReadOnly();

            // CheckBox 설정
            this.grdHoldRelease.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            grdHoldRelease.View.AddTextBoxColumn("CONSUMABLELOTID", 200);
            grdHoldRelease.View.AddTextBoxColumn("TXNHISTKEY", 200).SetIsHidden();
            grdHoldRelease.View.AddTextBoxColumn("AREANAME", 150);
            grdHoldRelease.View.AddTextBoxColumn("CONSUMABLEDEFID", 150).SetIsHidden();
            grdHoldRelease.View.AddTextBoxColumn("PARTNUMBER", 200);
            grdHoldRelease.View.AddTextBoxColumn("CONSUMABLEDEFVERSION", 80);
            grdHoldRelease.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 200);
            grdHoldRelease.View.AddTextBoxColumn("LOCATIONID", 70);
            grdHoldRelease.View.AddTextBoxColumn("CREATEDQTY", 80).SetDisplayFormat("{0:#,###}");
            grdHoldRelease.View.AddTextBoxColumn("CONSUMABLELOTQTY", 80).SetDisplayFormat("{0:#,###}");
            grdHoldRelease.View.AddTextBoxColumn("HOLDREASONCODENAME", 80).SetLabel("HOLDREASON");
            grdHoldRelease.View.AddTextBoxColumn("HOLDCOMMENTS", 100);
            grdHoldRelease.View.AddTextBoxColumn("HOLDDATE", 140).SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetTextAlignment(TextAlignment.Center);
            grdHoldRelease.View.AddTextBoxColumn("HOLDUSERNAME", 80);

            grdHoldRelease.View.PopulateColumns();
            #endregion
        }
        #endregion

        #endregion

        #region ◆ Event |

        /// <summary>        
        /// 이벤트 초기화
        /// </summary>
        public void InitializeEvent()
        {
            // TODO : 화면에서 사용할 이벤트 추가
            this.Load += Form_Load;

            grdConsumLot.View.DoubleClick += View_DoubleClick;
            grdConsumLot.View.RowStyle += ConsumableLot_RowStyle;
            grdHoldRelease.View.RowStyle += Target_RowStyle;
        }

        #region ▶ Grid Event |

        #region - 재공 Grid 더블클릭 |
        /// <summary>
        /// 재공 Grid 더블클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_DoubleClick(object sender, EventArgs e)
        {
            // 더블클릭 시 체크박스 체크
            SmartBandedGridView view = (SmartBandedGridView)sender;

            if (grdConsumLot.View.IsRowChecked(view.FocusedRowHandle))
                grdConsumLot.View.CheckRow(view.FocusedRowHandle, false);
            else
                grdConsumLot.View.CheckRow(view.FocusedRowHandle, true);
        }
        #endregion

        #region - 재공 Row Stype Event |
        /// <summary>
        /// 재공 Row Stype Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsumableLot_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            int rowIndex = grdConsumLot.View.FocusedRowHandle;

            if (rowIndex == e.RowHandle)
            {
                e.Appearance.BackColor = Color.FromArgb(254, 254, 16);
                e.HighPriority = true;
            }
        }
        #endregion

        #region - Target Grid Row Stype Event |
        /// <summary>
        /// Target Grid Row Stype Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Target_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            int rowIndex = grdHoldRelease.View.FocusedRowHandle;

            if (rowIndex == e.RowHandle)
            {
                e.Appearance.BackColor = Color.FromArgb(254, 254, 16);
                e.HighPriority = true;
            }
        }
        #endregion

        #endregion
        #endregion

        #region ◆ 툴바 |

        /// <summary>
        /// 저장버튼 클릭
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            // TODO : 저장 Rule 변경
            DataTable lockList = grdHoldRelease.DataSource as DataTable;

            if (lockList == null || lockList.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }

            // 보류 해제 사유 선택 체크
            if (this.cboHoldReleaseReason.EditValue == null || string.IsNullOrWhiteSpace(this.cboHoldReleaseReason.EditValue.ToString()))
            {
                // 보류 해제 사유 선택은 필수 선택입니다.
                throw MessageException.Create("NoExistHoldReleaseReason");
            }

            // 보류사유
            string holdReason = (string)cboHoldReleaseReason.GetValue();

            MessageWorker worker = new MessageWorker("SaveConsumableLotHold");
            worker.SetBody(new MessageBody()
            {
                { "TransactionType", "SetReleaseConsumableLotHold" },
                { "EnterpriseID", UserInfo.Current.Enterprise },
                { "PlantID", UserInfo.Current.Plant },
                { "ReasonCode", holdReason },
                { "Comments", txtComment.Text },
                { "UserId", UserInfo.Current.Id },
                { "Lotlist", lockList }
            });

            worker.Execute();

            // Data 초기화
            this.cboHoldReleaseReason.EditValue = null;
            this.txtComment.Text = string.Empty;
        }

        #endregion

        #region ◆ 검색 |

        /// <summary>
        /// 비동기 override 모델
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            // 기존 Grid Data 초기화
            this.grdConsumLot.DataSource = null;
            this.grdHoldRelease.DataSource = null;

            var values = Conditions.GetValues();
      
            DataTable dt = await SqlExecuter.QueryAsyncDirect("SelectConsumableLotListRelease", "00001", values);

            if (dt.Rows.Count < 1)
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }

            grdConsumLot.DataSource = dt;
        }

        #endregion

        #region ◆ 유효성 검사 |

        /// <summary>
        /// 데이터 저장할때 컨텐츠 영역의 유효성 검사
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();
        }

        #endregion

        #region ◆ Private Function |

        // TODO : 화면에서 사용할 내부 함수 추가

        #endregion
    }
}

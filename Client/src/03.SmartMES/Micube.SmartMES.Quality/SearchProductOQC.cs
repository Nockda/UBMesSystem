#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.SmartMES.Commons;
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

namespace Micube.SmartMES.Quality
{
	/// <summary>
	/// 프 로 그 램 명  : 품질관리 > 출하 > 출하 검사 조회
	/// 업  무  설  명  : 
	/// 생    성    자  : 정승원
	/// 생    성    일  : 2020-06-11
	/// 수  정  이  력  : 
	/// 
	/// 
	/// </summary>
	public partial class SearchProductOQC : SmartConditionBaseForm
	{
		#region 생성자

		public SearchProductOQC()
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

			// TODO : 컨트롤 초기화 로직 구성
			InitializeGrid();
		}

		/// <summary>        
		/// 그리드를 초기화한다.
		/// </summary>
		private void InitializeGrid()
		{
			grdResultList.GridButtonItem = GridButtonItem.None;
			grdResultList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
			grdResultList.View.SetIsReadOnly();

			//품목코드
			grdResultList.View.AddTextBoxColumn("PRODUCTDEFID", 100);
			//품목명
			grdResultList.View.AddTextBoxColumn("PRODUCTDEFNAME", 150);
			//규격
			grdResultList.View.AddTextBoxColumn("STANDARD", 110);
			//LOTID
			grdResultList.View.AddTextBoxColumn("LOTID", 90).SetTextAlignment(TextAlignment.Center);
			//공정
			grdResultList.View.AddTextBoxColumn("PROCESSSEGMENT", 80);
			//팀
			grdResultList.View.AddTextBoxColumn("TEAM", 80);
			//수량
			grdResultList.View.AddTextBoxColumn("QTY", 50).SetTextAlignment(TextAlignment.Right);
			//검사자
			grdResultList.View.AddTextBoxColumn("INSPECTOR", 70).SetTextAlignment(TextAlignment.Center);
			//검사자2
			grdResultList.View.AddTextBoxColumn("INSPECTOR2", 70).SetTextAlignment(TextAlignment.Center);
			//확정여부
			grdResultList.View.AddTextBoxColumn("ISCONFIRM", 60).SetTextAlignment(TextAlignment.Center);
			//검사결과
			grdResultList.View.AddTextBoxColumn("A", 40).SetTextAlignment(TextAlignment.Center);
			grdResultList.View.AddTextBoxColumn("B", 40).SetTextAlignment(TextAlignment.Center);
			grdResultList.View.AddTextBoxColumn("C", 40).SetTextAlignment(TextAlignment.Center);
			grdResultList.View.AddTextBoxColumn("D", 40).SetTextAlignment(TextAlignment.Center);
			grdResultList.View.AddTextBoxColumn("E", 40).SetTextAlignment(TextAlignment.Center);
			grdResultList.View.AddTextBoxColumn("F", 40).SetTextAlignment(TextAlignment.Center);
			grdResultList.View.AddTextBoxColumn("G", 40).SetTextAlignment(TextAlignment.Center);
			grdResultList.View.AddTextBoxColumn("H", 40).SetTextAlignment(TextAlignment.Center);

			grdResultList.View.PopulateColumns();
		}

		#endregion

		#region Event

		/// <summary>
		/// 화면에서 사용되는 이벤트를 초기화한다.
		/// </summary>
		public void InitializeEvent()
		{
			btnConfirm.Click += BtnConfirm_Click;
            grdResultList.View.CheckStateChanged += View_CheckStateChanged;
            grdResultList.View.CheckMarkSelection.CheckBoxHeaderClick += CheckMarkSelection_CheckBoxHeaderClick;
		}

        private void CheckMarkSelection_CheckBoxHeaderClick(object sender, HandledEventArgs e)
		{
            DataTable dataSource = grdResultList.DataSource as DataTable;
            int notConfirmed = 0;
            foreach(DataRow each in dataSource.Rows)
            {
                if(Format.GetFullTrimString(each["ISCONFIRM"]) != "Y")
                {
                    notConfirmed++;
                }
            }

            grdResultList.View.CheckStateChanged -= View_CheckStateChanged;
            foreach (int rowHandle in grdResultList.View.GetRowHandles(x => true))
            {
                if (grdResultList.View.CheckMarkSelection.SelectedCount < notConfirmed)
                {
                    if (Format.GetFullTrimString(grdResultList.View.GetRowCellValue(rowHandle, "ISCONFIRM")) == "Y")
                    {
                        grdResultList.View.CheckRow(rowHandle, false);
                    }
                    else
                    {
                        grdResultList.View.CheckRow(rowHandle, true);
                    }
                }
                else
                {
                    grdResultList.View.CheckRow(rowHandle, false);
                }
            }
            grdResultList.View.CheckStateChanged += View_CheckStateChanged;
            e.Handled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_CheckStateChanged(object sender, EventArgs e)
		{
            if(Format.GetFullTrimString(grdResultList.View.GetFocusedRowCellValue("ISCONFIRM")) == "Y")
            {
                grdResultList.View.CheckStateChanged -= View_CheckStateChanged;
                grdResultList.View.CheckRow(grdResultList.View.FocusedRowHandle, false);
                grdResultList.View.CheckStateChanged += View_CheckStateChanged;
            }

            /*
			Framework.SmartControls.Grid.GridCheckMarksSelection grd = sender as Framework.SmartControls.Grid.GridCheckMarksSelection;

			if(grdResultList.View.GetCheckedRows().Rows.Count == 0)
				return;

			grdResultList.View.CheckStateChanged -= View_CheckStateChanged;

			grdResultList.View.CheckedAll(false);
			DataRow dr = grdResultList.View.GetDataRow(grd.SelectedCount);

			if (Format.GetFullTrimString(dr["ISCONFIRM"]).Equals("Y"))
			{
				grdResultList.View.CheckRow(grdResultList.View.GetRowHandleByValue("LOTID", dr["LOTID"]), false);
			}
			else
			{
				grdResultList.View.CheckRow(grdResultList.View.GetRowHandleByValue("LOTID", dr["LOTID"]), true);
			}

			if (!_isAllCheck)
			{
				grdResultList.View.CheckedAll(false);
			}

			grdResultList.View.CheckStateChanged += View_CheckStateChanged;
            */

            /*
			if ((grdResultList.DataSource as DataTable).Rows.Count -1 == grd.SelectedCount) 
			{
				grdResultList.View.CheckStateChanged -= View_CheckStateChanged;
				if (_isAllCheck)
				{
					grdResultList.View.CheckedAll(false);

					DataTable dt = grdResultList.DataSource as DataTable;
					foreach (DataRow r in dt.Rows)
					{
						int index = dt.Rows.IndexOf(r);
						if (Format.GetFullTrimString(r["ISCONFIRM"]).Equals("Y"))
						{
							grdResultList.View.CheckRow(index, false);
						}
						else
						{
							grdResultList.View.CheckRow(index, true);
						}
					}
				}
				else
				{
					grdResultList.View.CheckedAll(false);
				}
				grdResultList.View.CheckStateChanged += View_CheckStateChanged;
			}
			else if(grdResultList.View.GetCheckedRows().Rows.Count == 1)
			{
				if(_isAllCheck) return;

				DataRow oneRow = grdResultList.View.GetCheckedRows().AsEnumerable().FirstOrDefault();
				if(oneRow == null) return;

				grdResultList.View.CheckStateChanged -= View_CheckStateChanged;

				grdResultList.View.CheckedAll(false);

				if (Format.GetFullTrimString(oneRow["ISCONFIRM"]).Equals("Y"))
				{
					grdResultList.View.CheckRow(grdResultList.View.GetRowHandleByValue("LOTID", oneRow["LOTID"]), false);
				}
				else
				{
					grdResultList.View.CheckRow(grdResultList.View.GetRowHandleByValue("LOTID", oneRow["LOTID"]), true);
				}
				grdResultList.View.CheckStateChanged += View_CheckStateChanged;
			}
			*/
        }

		/// <summary>
		/// 출하 확정
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnConfirm_Click(object sender, EventArgs e)
		{
			DataTable dt = grdResultList.View.GetCheckedRows();
			if(dt.Rows.Count == 0)
			{
				//확정할 대상을 체크하세요.
				ShowMessage("SELECTTARGETTOCONFIRM");
				return;
			}

			MessageWorker worker = new MessageWorker("SaveSearchProductOQC");
			worker.SetBody(new MessageBody()
			{
				{ "list",  dt }
			});

			worker.Execute();
			ShowMessage("SuccessSave");
			OnSearchAsync();
		}
		#endregion

		#region 검색

		/// <summary>
		/// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
		/// </summary>
		protected async override Task OnSearchAsync()
		{
			await base.OnSearchAsync();

			// TODO : 조회 SP 변경
			var values = Conditions.GetValues();
			values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

			DataTable dtResult = await QueryAsync("SelectSearchProductOQC", "00001", values);

			if (dtResult.Rows.Count < 1)
			{
				// 조회할 데이터가 없습니다.
				ShowMessage("NoSelectData"); 
			}

			grdResultList.DataSource = dtResult;
		}

		/// <summary>
		/// 조회조건 항목을 추가한다.
		/// </summary>
		protected override void InitializeCondition()
		{
			base.InitializeCondition();

			//품목코드
			CommonFunction.AddConditionProductPopup("P_PRODUCTDEFID", 4, true, Conditions);
			//LOTID - 출하검사 완료 대상 LOT
			InitializationCondition_LotId();
		}

		/// <summary>
		/// 팝업형 조회조건 초기화 - LOTID
		/// </summary>
		private void InitializationCondition_LotId()
		{
			var lotid = Conditions.AddSelectPopup("P_LOTID", new SqlQuery("GetOutGoingLot", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "LOTID", "LOTID")
				.SetPopupLayout("SELECTLOTID", PopupButtonStyles.Ok_Cancel, true, false)
				.SetPopupLayoutForm(800, 800)
				.SetPopupAutoFillColumns("PRODUCTDEFNAME")
				.SetLabel("LOTID")
				.SetPopupResultCount(0);
			lotid.Conditions.AddTextBox("TXTLOTID").SetLabel("LOTID");
			lotid.Conditions.AddTextBox("TXTPRODUCTDEFNAME");
			lotid.Conditions.AddTextBox("TXTPROCESSSEGMENT");

			lotid.GridColumns.AddTextBoxColumn("LOTID", 100);
			lotid.GridColumns.AddTextBoxColumn("PRODUCTDEFID", 100);
			lotid.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 150);
			lotid.GridColumns.AddTextBoxColumn("PROCESSSEGMENT", 100);
		}

		/// <summary>
		/// 조회조건의 컨트롤을 추가한다.
		/// </summary>
		protected override void InitializeConditionControls()
		{
			base.InitializeConditionControls();

			// TODO : 조회조건의 컨트롤에 기능 추가가 필요한 경우 사용
		}

		#endregion
	}
}
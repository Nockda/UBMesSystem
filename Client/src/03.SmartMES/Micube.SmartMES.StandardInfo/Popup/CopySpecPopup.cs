using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Micube.Framework.SmartControls;
using Micube.Framework;
using Micube.SmartMES.Commons.Controls;
using System.IO;
using Micube.Framework.Net;
using DevExpress.XtraEditors.Repository;
using Micube.Framework.Net.Data;

namespace Micube.SmartMES.StandardInfo
{
	public partial class CopySpecPopup : SmartPopupBaseForm, ISmartCustomPopup
	{
        #region Variable

        public DataRow CurrentDataRow { get; set; }
		DataTable selectRows;
        private string ORIGIN;

        #endregion

        #region 생성자

        public CopySpecPopup(DataTable selectRows)
		{
			this.selectRows = selectRows;
            InitializeComponent();

			InitializeControl();
			InitializeEvent();
			
		}



        #endregion


        #region init Control
        private void InitializeControl()
		{
            ORIGIN = selectRows.Select()[0]["SPECDEFID"].ToString();
            // 이제 여기서 쿼리 돌려서 룰에 최신버전 값 보내주기
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("SPECDEFID", ORIGIN);

            cboSpecBox.Editor.DisplayMember = "SPECDEFID";
			cboSpecBox.Editor.ValueMember = "SPECDEFID";
			cboSpecBox.Editor.DataSource = SqlExecuter.Query("GetSpecdefidList", "00001", param);
			cboSpecBox.Editor.UseEmptyItem = true;
			cboSpecBox.Editor.ShowHeader = false;
		}
        #endregion

        #region Event

        /// <summary>
        /// 이벤트 초기화
        /// </summary>
        private void InitializeEvent() 
		{
			btnSave.Click += BtnSave_Click;                                                                                                                
			btnClose.Click += BtnClose_Click;
		}


		/// <summary>
		/// 저장 버튼 클릭 - 파일저장
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnSave_Click(object sender, EventArgs e)
		{
			//저장로직 구현
            try { 
			
				this.ShowWaitArea();
                
                var SPECDEFID = cboSpecBox.GetValue();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("SPECDEFID", SPECDEFID);

                DataTable dtSubSpecList = SqlExecuter.Query("GetSubSpecListForCopy", "00001", param);
                DataTable dtSubSpecDetailList = SqlExecuter.Query("GetSubSpecDetailListForCopy", "00001", param);
                // 현재 복사하려는 공정의 스펙 최신버전이 무엇인지 확인해서 룰 넘겨주기
                DataTable dt = SqlExecuter.Query("GetLatestSpecdefVersion", "00001", new Dictionary<string, object>() { { "SPECDEFID", ORIGIN } });
                string _str = dt.Select()[0]["SPECDEFIDVERSION"].ToString();

                if (dtSubSpecList.Rows.Count == 0)
                {
                    ShowMessage("SpecCopyISNULL");
             
                    this.Close();
                    return;
                }

                MessageWorker worker = new MessageWorker("SaveSpecManagement");
                worker.SetBody(new MessageBody()
                {
                    { "type", "COPYSPEC" },
                    { "specList", selectRows },
                    { "enterpriseid", UserInfo.Current.Enterprise },
                    { "plantid", UserInfo.Current.Plant },
                    { "subSpecList", dtSubSpecList },
                    { "subSpecDetailList", dtSubSpecDetailList },
                    { "specversion", _str }
                });

                worker.Execute();
                ShowMessage("SuccessSave");
			}
			catch(Exception ex)
			{
				ShowMessage(ex.ToString());
			}
			finally
			{
				this.CloseWaitArea();
			}

			this.Close();
		}

		/// <summary>
		/// 닫기 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        #endregion

    }
}

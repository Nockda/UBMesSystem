#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;

using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

using DevExpress.Utils;

#endregion

namespace Micube.SmartMES.Process
{
    /// <summary>
    /// 프 로 그 램 명  : 공정관리 > 작업관리 > 작업메뉴얼
    /// 업  무  설  명  : 작업메뉴얼을 조회한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-04-08
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class WorkManual : SmartConditionBaseForm
    {
        public WorkManual()
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

            InitializeEvent();

            // 컨트롤 초기화 로직 구성
            InitializeInfo();
        }

        /// <summary>        
        /// 메뉴얼리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeInfo()
        {
            grdInfo.GridButtonItem = GridButtonItem.None;
            grdInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;

            // 그리드 초기화
            grdInfo.View.SetIsReadOnly();

            grdInfo.View.SetSortOrder("PROCESSID");
            grdInfo.View.SetAutoFillColumn("DESCRIPTION");

            grdInfo.View.AddTextBoxColumn("PROCESSID", 80)
                .SetIsHidden();


            if (UserInfo.Current.LanguageType == Commons.Constants.LanguageType_KO_KR)
            {
                grdInfo.View.AddTextBoxColumn("PROCESSNAMEKOR", 250);
            }
            if (UserInfo.Current.LanguageType == Commons.Constants.LanguageType_EN_US)
            {
                grdInfo.View.AddTextBoxColumn("PROCESSNAMEENG", 250);
            }
            if (UserInfo.Current.LanguageType == Commons.Constants.LanguageType_zh_CN)
            {
                grdInfo.View.AddTextBoxColumn("PROCESSNAMEJPN", 250);
            }
            grdInfo.View.AddTextBoxColumn("DESCRIPTION", 200);
            grdInfo.View.AddTextBoxColumn("FILENAME", 150);
            grdInfo.View.AddTextBoxColumn("FILEDATA", 80)
                .SetIsHidden();
            grdInfo.View.PopulateColumns();
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            grdInfo.View.DoubleClick += View_DoubleClick;

        }

        private void View_DoubleClick(object sender, EventArgs e)
        {
            if (grdInfo.View.FocusedRowHandle < 0)
                return;

            DataRow row = (sender as SmartBandedGridView).GetFocusedDataRow();

            if (row["FILEDATA"].ToString() == "")
            {
                ShowMessage("NoSelectData");
                return;
            }

            byte[] fileBytes = Convert.FromBase64String(row["FILEDATA"].ToString());


            System.IO.Directory.CreateDirectory(@"C:\WorkStandardFiles");

            string strDownloadPath = @"C:\WorkStandardFiles\" + row["FILENAME"].ToString();

            File.WriteAllBytes(strDownloadPath, fileBytes);

            System.Diagnostics.Process.Start(strDownloadPath);
        }

        #endregion

        #region Search

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtMaster = await QueryAsync("GetWorkManual", "00001", values);

            if (dtMaster.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdInfo.DataSource = dtMaster;
        }

        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

        }

        #endregion
    }
}

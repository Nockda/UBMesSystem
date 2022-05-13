using Micube.Framework.SmartControls;
using SmartDeploy.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Micube.SmartMES.SystemManagement
{
    /// <summary>
    /// - 설      명 : 배포 이력 리스트 팝업창
    /// - 작  성  자 : 장선미
    /// - 최초작성일 : 2020.03.06
    /// - 주요변경로그  
    /// </summary>

    public partial class DeployHistoryListPopup : SmartPopupBaseForm
    {
        /// <summary>
        /// Deploy Service Upload 경로
        /// </summary>
        private string _strDeployUploadURL = string.Empty;

        public DeployHistoryListPopup(string strDeployUploadURL)
        {
            InitializeComponent();

            this._strDeployUploadURL = strDeployUploadURL;

            InitializeGird();
        }

        private void InitializeGird()
        {

            grdHistoryList.ShowButtonBar = false;
            grdHistoryList.View.SetIsReadOnly();
            grdHistoryList.View.SetSortOrder("DEPLOYDATE");
            grdHistoryList.View.SetAutoFillColumn("DEPLOYNOTE");

            //배포일시
            grdHistoryList.View.AddTextBoxColumn("DEPLOYDATE", 130)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);

            //배포자
            grdHistoryList.View.AddTextBoxColumn("DEPLOYER", 120);

            //배포사유
            grdHistoryList.View.AddTextBoxColumn("DEPLOYNOTE", 700);

            grdHistoryList.View.PopulateColumns();

            DataTable dtList = DeployCommonFunction.GetDeployHistroyList(this._strDeployUploadURL);
            grdHistoryList.DataSource = dtList;
        }

    }
}

#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;

#endregion

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 라우터관리 > 품목라우터관리 > 팝업 > 세부작업 공정관리
    /// 업  무  설  명  : 세부작업 공정관리 팝업을 이용해 등록한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-09
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class DetailProcessPopup : SmartPopupBaseForm
    {
        public DetailProcessPopup()
        {
            InitializeComponent();
            InitializeInfo();
        }

        #region 컨텐츠 영역 초기화

        /// <summary>        
        /// 세부작업 공정관리 그리드를 초기화한다.
        /// </summary>
        private void InitializeInfo()
        {
            // 그리드 초기화
            grdInfo.GridButtonItem = GridButtonItem.Refresh;

            grdInfo.View.SetIsReadOnly();

            grdInfo.View.SetSortOrder("순서");
            grdInfo.View.SetAutoFillColumn("SUB공정코드");
            
            grdInfo.View.AddTextBoxColumn("순서", 50);
            grdInfo.View.AddTextBoxColumn("SUB공정코드", 120);
            grdInfo.View.AddTextBoxColumn("실적유무", 100);
            grdInfo.View.AddTextBoxColumn("외주여부", 100);
            grdInfo.View.AddTextBoxColumn("CREATOR", 50);
            grdInfo.View.AddTextBoxColumn("CREATEDTIME", 70);
            grdInfo.View.AddTextBoxColumn("MODIFIER", 50);
            grdInfo.View.AddTextBoxColumn("MODIFIEDTIME", 70);
            grdInfo.View.PopulateColumns();
        }

        #endregion
    }
}

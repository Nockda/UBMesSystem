using DevExpress.XtraReports.UI;
using Micube.Framework;
using System;
using System.IO;
using System.Windows.Forms;

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 바코드관리 > 바코드라벨관리 팝업(라벨 디자이너)
    /// 업  무  설  명  : 라벨 디자이너
    /// 생    성    자  : yshwang
    /// 생    성    일  : 2020-05-20
    /// 수  정  이  력  : 
    /// </summary>
    public partial class LabelForm_Popup : Form
    {
        public byte[] LabelData { get; private set; }   // 라벨 디자인 데이터

        /// <summary>
        /// 라벨 디자이너 팝업
        /// </summary>
        /// <param name="labelId">라벨ID</param>
        /// <param name="labelName">라벨명</param>
        /// <param name="labelData">라벨 디자인 데이터(신규라벨은 null)</param>
        public LabelForm_Popup(string labelId, string labelName, byte[] labelData)
        {
            InitializeComponent();
            InitializeEvent();

            this.LabelData = labelData;
            lblLabelId.Text = labelId;
            lblLabelName.Text = labelName;
            this.DialogResult = DialogResult.Cancel;

            ApplyMultiLanguage();

            if (labelData == null)  // 신규 라벨인 경우 신규 리포트 생성
            {
                reportDesigner1.CreateNewReport();
            }
            else // 기존 라벨인 경우 리포트 불러오기
            {
                using (MemoryStream stream = new MemoryStream(labelData))
                {
                    reportDesigner1.OpenReport(XtraReport.FromStream(stream, true));
                }
            }
        }

        /// <summary>
        /// 다국어 처리
        /// SmartBaseForm 을 상속 받을 수 없기 때문에(MDI Container 사용할 수 없음) 다국어를 자체적으로 처리한다.
        /// </summary>
        private void ApplyMultiLanguage()
        {
            smartLabel1.Text = Language.Get(smartLabel1.LanguageKey);
            smartLabel4.Text = Language.Get(smartLabel4.LanguageKey);
            btnSave.Text = Language.Get(btnSave.LanguageKey);
        }

        /// <summary>
        /// 이벤트 등록
        /// </summary>
        private void InitializeEvent()
        {
            btnSave.Click += BtnSave_Click;
            this.FormClosing += BarcodeList_Popup_FormClosing;
        }

        /// <summary>
        /// 현재 액티브 상태의 report 하나의 디자인을 byte[] 에 저장해서 this.LabelData를 통해 반환한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 저장하시겠습니까?
            if (MessageBox.Show(Language.GetMessage("InfoSave").Message, Language.GetMessage("InfoSave").Title
                , MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            XtraReport report = reportDesigner1.ActiveDesignPanel.Report;
            using (MemoryStream stream = new MemoryStream())
            {
                report.SaveLayout(stream);
                stream.Seek(0, SeekOrigin.Begin);
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                this.LabelData = bytes;
            }

            // XtraReportDesigner 에서 파일을 저장할거냐고 묻지 않게 하기위해 상태 변경
            reportDesigner1.ActiveDesignPanel.ReportState = DevExpress.XtraReports.UserDesigner.ReportState.Saved;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BarcodeList_Popup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult != DialogResult.OK)
            {
                // 정말 종료하시겠습니까? 저장하지 않은 데이터는 사라집니다.
                if (MessageBox.Show(Language.GetMessage("CloseWithoutSave").Message, Language.GetMessage("CloseWithoutSave").Title
                    , MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}

using DevExpress.Spreadsheet;
using DevExpress.XtraPrinting;
using Micube.Framework;
using Micube.Framework.Log;
using Micube.Framework.SmartControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Micube.SmartMES.Quality
{
    /// <summary>
    /// 프 로 그 램 명  : 품질관리 > 불량관리 > 불량통지서 조회팝업
    /// 업  무  설  명  : 불량통지서를 엑셀파일에 데이터 바인딩
    /// 생    성    자  : 강유라
    /// 생    성    일  : 2020-06-24
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class DefectExcelPopup : SmartPopupBaseForm, ISmartCustomPopup
    {
        #region Global Variables

        public DataRow CurrentDataRow { get; set; }
        public Image CurrentImage;

        #endregion

        #region Local Variables

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        public DefectExcelPopup()
        {
            InitializeComponent();
            InitializeEvent();
        }

        #endregion

        #region 컨텐츠 영역 초기화

        /// <summary>
        /// 스프레드 시트영역 초기화 및 데이터바인딩
        /// </summary>
        private void InitializeReport()
        {
            FileStream stream = File.OpenRead(@"ExcelFile\(QEP-Q-02-02)Defect.xlsx");
            sphDefect.LoadDocument(stream, DocumentFormat.Xlsx);
            SheetDataBinding();
        }

        #endregion

        #region Event

        /// <summary>
        /// 이벤트 초기화
        /// </summary>
        private void InitializeEvent()
        {
            this.Load += DefectExcelPopup_Load;

            this.btnPrint.Click += btnPrint_Click;
            this.btnExport.Click += btnExport_Click;
            this.btnClose.Click += BtnClose_Click;
        }

        /// <summary>
        /// 폼 로드 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DefectExcelPopup_Load(object sender, EventArgs e)
        {
           //this.FormBorderStyle = FormBorderStyle.FixedDialog;

            InitializeReport();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (PrintingSystem printingSystem = new PrintingSystem())
            {
                using (PrintableComponentLink link = new PrintableComponentLink(printingSystem))
                {
                    link.Component = this.sphDefect;
                    link.CreateDocument();
                    link.ShowPreviewDialog();
                }
            }
        }

        /// <summary>
        /// Export 버튼 Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {

            SaveFileDialog opf = new SaveFileDialog();

            opf.FileName = @"Measuring R&R Report_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"; //초기 파일명을 지정할 때 사용한다.
            opf.Filter = "Excel Files(*.xlsx)|*.xlsx;*.xls";
            opf.Title = "Save an Excel File";

            DevExpress.XtraPivotGrid.PivotXlsxExportOptions exOpt = new DevExpress.XtraPivotGrid.PivotXlsxExportOptions();
            exOpt.ExportType = DevExpress.Export.ExportType.WYSIWYG;
            exOpt.ShowGridLines = true;

            opf.ShowDialog();
            if (opf.FileName.Length > 0)
            {
                sphDefect.SaveDocument(opf.FileName.ToString());
            }

        }

        /// <summary>
        /// 닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Private Function

        /// <summary>
        /// 스프레드 시트에 데이터를 바인딩한다.
        /// </summary>
        private void SheetDataBinding()
        {
            string data = "";
            try
            {
                IWorkbook workbook = sphDefect.Document;
                Worksheet worksheet = workbook.Worksheets[0];

                for (int i = 0; i < worksheet.Comments.Count; i++)
                {
                    string memoCoordinatesReference = worksheet.Comments[i].Reference.ToString();
                    string memoCoordinatesText = worksheet.Comments[i].Text.ToString();

                    char[] delimiterChars_sym1 = { '#' };

                    string[] strDtcAry;

                    strDtcAry = memoCoordinatesText.Split(delimiterChars_sym1);

                    if (strDtcAry != null && strDtcAry.Length > 0)
                    {
                        switch (strDtcAry[0].ToString())
                        {
                            case "IMAGE":
                                this.ImageInsert(workbook, worksheet, CurrentImage, memoCoordinatesReference);
                                break;
                            case "INFO":
                                data = Format.GetString(CurrentDataRow[strDtcAry[1]]);
                                break;
                            case "DATA":
                                data = "";
                                break;
                            default:
                                break;
                        }
                    }

                    worksheet.Cells[memoCoordinatesReference].SetValueFromText(data);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        /// <summary>
        /// Sheet에 Image 입력.
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="worksheet"></param>
        /// <param name="image"></param>
        /// <param name="cellRangeValue"></param>
        private void ImageInsert(IWorkbook workbook, Worksheet worksheet, Image image, string cellRangeValue)
        {
            try
            {
                if (image != null)
                {
                    //Image image1 = Image.FromFile(@"C:\60.Source\97.image\Seyung.PNG");
                    var src = SpreadsheetImageSource.FromImage(image);
                    //string cellRangeValue = this.txtImageLocation.Text;
                    if (cellRangeValue != null && cellRangeValue != "")
                    {
                        var targetCell = worksheet.Cells[cellRangeValue];
                        var picture = worksheet.Pictures.AddPicture(src, targetCell, true);
                        picture.Move(150, 30);
                        //picture.Placement = Placement.MoveAndSize;
                        picture.Width = 100; // (850 / 150) * 100;
                        //picture.Height = 1285;
                        picture.Height = 900;

                        //picture.Width = picture.OriginalWidth;
                        //picture.Height = picture.OriginalHeight;
                        //picture.Placement = Placement.Move;
                        //picture.TopLeftCell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                        //picture.TopLeftCell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                    }
                }
                //Comment comment = worksheet.SelectedComment;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        #endregion

        #region Public Function

        #endregion
    }
}

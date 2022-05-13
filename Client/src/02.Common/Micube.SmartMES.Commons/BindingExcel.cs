using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;



namespace Micube.SmartMES.Commons
{
    public class BindingExcel
    {
        public static void File(string path, Dictionary<string, object> cellValue)
        {
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkbook = null;
            Excel.Worksheet xlWorksheet = null;

            path = System.IO.Path.GetFullPath(path);

            xlApp = new Excel.Application();
            xlWorkbook = xlApp.Workbooks.Open(path);
            xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.Item[1];

            foreach (KeyValuePair<string, object> items in cellValue)
            {
                xlWorksheet.Range[items.Key].Value = items.Value;
            }

            string fileName = Path.GetFileName(path);
            string filePath = Path.GetDirectoryName(path);
            string nowDate = System.DateTime.Now.ToString("yyyyMMddHHmmss");

            xlWorkbook.SaveAs(filePath + @"\" + fileName.Split('.')[0].ToString() + "_" + nowDate);

            xlWorkbook.Save();
            //xlWorkbook.Close();

            xlApp.Visible = true;

        }
    }
}

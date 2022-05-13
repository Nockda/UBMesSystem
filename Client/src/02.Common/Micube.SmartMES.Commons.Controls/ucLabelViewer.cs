#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.SmartMES.Commons;
using DevExpress.XtraReports.UI;
using DevExpress.XtraVerticalGrid.Rows;
using DevExpress.XtraEditors.Repository;
using System.Collections;

#endregion

namespace Micube.SmartMES.Commons.Controls
{
    /// <summary>
    /// 프 로 그 램 명  : 라벨 출력 미리 보기 기능
    /// 업  무  설  명  : 
    /// 생    성    자  : 박윤신
    /// 생    성    일  : 2019-07-25
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class ucLabelViewer : UserControl
    {

        public ucLabelViewer()
        {
            InitializeComponent();

            if (!this.IsDesignMode())
            {
                InitializeEvent();
            }

        }
        private void InitializeEvent()
        {
            this.Load += UcLabelViewer_Load;
            this.smartPropertyGrid1.CustomPropertyDescriptors += SmartPropertyGrid1_CustomPropertyDescriptors;
        }

        private void SmartPropertyGrid1_CustomPropertyDescriptors(object sender, DevExpress.XtraVerticalGrid.Events.CustomPropertyDescriptorsEventArgs e)
        {

            PropertyDescriptorCollection properties = e.Properties;
            ArrayList list = new ArrayList(properties);
            Conditionals cd = e.Source as Conditionals;

            foreach (KeyValuePair<string, object> keyValue in cd.dynamicProperties)
            {
                List<Attribute> attributes = new List<Attribute>();
                attributes.Add(new DisplayNameAttribute(Language.Get(keyValue.Key)));

                DynamicPropertyDescriptor property = new DynamicPropertyDescriptor(cd, keyValue.Key, typeof(string), attributes.ToArray());
                list.Add(property);
            }

            PropertyDescriptor[] result = new PropertyDescriptor[list.Count];
            list.ToArray().CopyTo(result, 0);
            e.Properties = new PropertyDescriptorCollection(result);

            XtraReport report = this.documentViewer1.DocumentSource as XtraReport;

            Band detailBand = report.Bands.GetBandByType(typeof(DetailBand));

            //detailBand.Controls
            foreach (XRControl control in detailBand.Controls)
            {
                if (control is DevExpress.XtraReports.UI.XRLabel || control is DevExpress.XtraReports.UI.XRBarCode)
                {
                    if (!string.IsNullOrEmpty(control.Tag.ToString()))
                    {
                        control.Text = cd.dynamicProperties[control.Tag.ToString()].ToString();
                    }
                }

                else if (control is DevExpress.XtraReports.UI.XRTable)
                {
                    XRTable xt = control as XRTable;

                    foreach (XRTableRow tr in xt.Rows)
                    {
                        for (int i = 0; i < tr.Cells.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(tr.Cells[i].Tag.ToString()))
                            {
                                tr.Cells[i].Text = cd.dynamicProperties[tr.Cells[i].Tag.ToString()].ToString();
                            }
                        }
                    }
                }
            }

            report.CreateDocument();
            this.documentViewer1.DocumentSource = report;

            this.documentViewer1.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.ZoomToPageWidth);


        }


       

        #region ◆ Event |

        private void UcLabelViewer_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region ◆ Public Event Handler |

        #endregion

        #region ◆ Function |

        public void SetBindingPreview(XtraReport report)
        {

            report.CreateDocument();
            this.documentViewer1.DocumentSource = report;
            this.documentViewer1.Zoom = 0.5f;

            this.documentViewer1.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.ZoomToPageWidth);


            Band topBand = report.Bands.GetBandByType(typeof(TopMarginBand));
            Band bottomBand = report.Bands.GetBandByType(typeof(BottomMarginBand));

            if (topBand != null) report.Bands.Remove(topBand);
            if (bottomBand != null) report.Bands.Remove(bottomBand);

            Band detailBand = report.Bands.GetBandByType(typeof(DetailBand));


            Conditionals cd = new Conditionals();
            //detailBand.Controls
            foreach (XRControl control in detailBand.Controls)
            {
                if (control is DevExpress.XtraReports.UI.XRLabel)
                {
                    if (!string.IsNullOrEmpty(control.Tag.ToString()))
                    {
                        if (!cd.dynamicProperties.ContainsKey(control.Tag.ToString()))
                            cd.dynamicProperties.Add(control.Tag.ToString(), control.Text);
                    }


                }
                else if (control is DevExpress.XtraReports.UI.XRBarCode)
                {
                    if (!string.IsNullOrEmpty(control.Tag.ToString()))
                    {
                        if (!cd.dynamicProperties.ContainsKey(control.Tag.ToString()))
                            cd.dynamicProperties.Add(control.Tag.ToString(), control.Text);
                    }

                }


                else if (control is DevExpress.XtraReports.UI.XRTable)
                {
                    XRTable xt = control as XRTable;

                    foreach (XRTableRow tr in xt.Rows)
                    {
                        for (int i = 0; i < tr.Cells.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(tr.Cells[i].Tag.ToString()))
                            {
                                if (!cd.dynamicProperties.ContainsKey(control.Tag.ToString()))
                                    cd.dynamicProperties.Add(tr.Cells[i].Tag.ToString(), tr.Cells[i].Text);
                            }
                        }
                    }
                }
            }


            smartPropertyGrid1.SelectedObject = cd;

        }

        public XtraReport GetLabelReport()
        {
            return this.documentViewer1.DocumentSource as XtraReport;
        }

        #endregion

        private void propertyGridControl1_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {

        }
    }


    public class Conditionals
    {
        public readonly IDictionary<string, object> dynamicProperties =
       new Dictionary<string, object>();
    }

    public class DynamicPropertyDescriptor : PropertyDescriptor
    {
        private readonly Conditionals businessObject;
        private readonly Type propertyType;

        public DynamicPropertyDescriptor(Conditionals businessObject,
            string propertyName, Type propertyType, Attribute[] propertyAttributes)
            : base(propertyName, propertyAttributes)
        {
            this.businessObject = businessObject;
            this.propertyType = propertyType;
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override object GetValue(object component)
        {
            return businessObject.dynamicProperties[Name];
        }

        public override void ResetValue(object component)
        {
        }

        public override void SetValue(object component, object value)
        {
            businessObject.dynamicProperties[Name] = value;
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }

        public override Type ComponentType
        {
            get { return typeof(Conditionals); }
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override Type PropertyType
        {
            get { return propertyType; }
        }
    }
}

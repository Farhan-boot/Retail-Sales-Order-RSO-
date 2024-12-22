using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.Web;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace APL.BL.SFTS.ShelterZone
{
    public class CrystalReportUtility : System.Web.UI.Page
    {
        List<NameValue> oParameterValueList = new List<NameValue>();

        public string RptLevel { get; set; }
        public string UniquePostfixName { get; set; }
        public string ReportTitle { get; set; }
        public int ZoomFactor { get; set; }

        public CrystalReportUtility()
        {

        }
        public void CRParameterList(string ParamName, DateTime ParamValue)
        {
            oParameterValueList.Add(new NameValue(ParamName, ParamValue));
        }
        public void CRParameterList(string ParamName, bool ParamValue)
        {
            oParameterValueList.Add(new NameValue(ParamName, ParamValue));
        }
        public void CRParameterList(string ParamName, string ParamValue)
        {
            oParameterValueList.Add(new NameValue(ParamName, ParamValue));
        }
        public void CRParameterList(string ParamName, decimal ParamValue)
        {
            oParameterValueList.Add(new NameValue(ParamName, ParamValue));
        }

        public string SetUniquePostfixName(string _rptLevel)
        {
            this.RptLevel = _rptLevel;
            this.UniquePostfixName = Session.SessionID.ToString() + "_" + DateTime.Now.ToString("MMddyyyy_HHmmss");
            return UniquePostfixName;
        }

        public void SetRptDataTable(DataTable dt)
        {
            Session["rptDataTable" + this.RptLevel + "_" + UniquePostfixName] = dt;
        }

        public void SetRptDataSet(DataSet _dataSet)
        {
            Session["rptDataSet" + this.RptLevel + "_" + UniquePostfixName] = _dataSet;
        }
        public void SetRptXLSDataTable(DataTable dt)
        {
            Session["rptXLSDataTable" + this.RptLevel + "_" + UniquePostfixName] = dt;
        }

        public void SetRptPath(string _path)
        {
            Session["rptPath" + this.RptLevel + "_" + UniquePostfixName] = _path;
            Session["rptParameterValueList" + this.RptLevel + "_" + UniquePostfixName] = oParameterValueList;
        }

        public void GenerateCrystalReport(CrystalReportViewer crv, HtmlInputHidden hiPageOrientation, HtmlInputHidden hiPaperSize)
        {
            if (Session["rptPath" + this.RptLevel + "_" + UniquePostfixName] != null && Session["rptDataTable" + this.RptLevel + "_" + UniquePostfixName] != null && Session["rptParameterValueList" + this.RptLevel + "_" + UniquePostfixName] != null)
            {
                string reportPath = (string)Session["rptPath" + this.RptLevel + "_" + UniquePostfixName];
                DataTable oDataTable = (DataTable)Session["rptDataTable" + this.RptLevel + "_" + UniquePostfixName];
                List<NameValue> oParameterValueList = (List<NameValue>)Session["rptParameterValueList" + this.RptLevel + "_" + UniquePostfixName];
                ReportDocument oReportDocument = new ReportDocument();
                oReportDocument.Load(reportPath);
                oReportDocument.SetDataSource(oDataTable);

                foreach (NameValue oNameValue in oParameterValueList)
                {
                    oReportDocument.SetParameterValue(oNameValue.Name, oNameValue.Value);
                }

                hiPageOrientation.Value = ((int)oReportDocument.PrintOptions.PaperOrientation).ToString();
                hiPaperSize.Value = ((int)oReportDocument.PrintOptions.PaperSize).ToString();
                crv.ReportSource = oReportDocument;
                ConfigureCrystalReportViewer(crv);
                Session["rptDoc" + this.RptLevel + "_" + UniquePostfixName] = oReportDocument;
            }

            else if (Session["rptPath" + this.RptLevel + "_" + UniquePostfixName] != null && Session["rptDataSet" + this.RptLevel + "_" + UniquePostfixName] != null && Session["rptParameterValueList" + this.RptLevel + "_" + UniquePostfixName] != null)
            {
                string reportPath = (string)Session["rptPath" + this.RptLevel + "_" + UniquePostfixName];
                DataSet oDataSet = (DataSet)Session["rptDataSet" + this.RptLevel + "_" + UniquePostfixName];
                List<NameValue> oParameterValueList = (List<NameValue>)Session["rptParameterValueList" + this.RptLevel + "_" + UniquePostfixName];
                ReportDocument oReportDocument = new ReportDocument();
                oReportDocument.Load(reportPath);
                oReportDocument.SetDataSource(oDataSet);

                foreach (NameValue oNameValue in oParameterValueList)
                {
                    oReportDocument.SetParameterValue(oNameValue.Name, oNameValue.Value);
                }

                hiPageOrientation.Value = ((int)oReportDocument.PrintOptions.PaperOrientation).ToString();
                hiPaperSize.Value = ((int)oReportDocument.PrintOptions.PaperSize).ToString();
                crv.ReportSource = oReportDocument;
                ConfigureCrystalReportViewer(crv);
                Session["rptDoc" + this.RptLevel + "_" + UniquePostfixName] = oReportDocument;
            }
        }

        private void ConfigureCrystalReportViewer(CrystalReportViewer crv)
        {
            crv.PrintMode = PrintMode.ActiveX;
            crv.DisplayGroupTree = false;
            crv.HasToggleGroupTreeButton = false;
            crv.HasCrystalLogo = false;
            crv.HasDrillUpButton = false;
            crv.EnableDrillDown = false;
            crv.HasViewList = false;
            crv.PageToTreeRatio = 100;
            crv.HasExportButton = false;
          
            if (this.ZoomFactor == 0)
            {
                crv.Zoom(125);
            }
            else
            {
                crv.Zoom(ZoomFactor);
            }
        }

        public void ExportReport(CrystalReportViewer crv, HtmlInputHidden hiPageOrientation, HtmlInputHidden hiPaperSize, string ExportOptions, HttpResponse PageResponse)
        {
            string ExportFileName = ReportTitle + "_" + UniquePostfixName;

            GenerateCrystalReport(crv, hiPageOrientation, hiPaperSize);
            if (Session["rptDoc" + this.RptLevel + "_" + UniquePostfixName] != null)
            {
                ReportDocument oReportDocument = (ReportDocument)Session["rptDoc" + this.RptLevel + "_" + UniquePostfixName];
                if (ExportOptions == "Excel")
                {
                    oReportDocument.ExportToHttpResponse(ExportFormatType.Excel, PageResponse, true, ExportFileName);
                }
                else if (ExportOptions == "Pdf")
                {
                    oReportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, PageResponse, true, ExportFileName);
                }
                else if (ExportOptions == "Word")
                {
                    oReportDocument.ExportToHttpResponse(ExportFormatType.WordForWindows, PageResponse, true, ExportFileName);
                }
            }
            CloseGenerateReportDocument(crv);


        }

        public void CloseGenerateReportDocument(CrystalReportViewer crv)
        {
            if (Session["rptDoc" + this.RptLevel + "_" + UniquePostfixName] != null)
            {
                ReportDocument oReportDocument = (ReportDocument)Session["rptDoc" + this.RptLevel + "_" + UniquePostfixName];
                Session["rptDoc" + this.RptLevel + "_" + UniquePostfixName] = null;
                crv.ReportSource = null;
                oReportDocument.Close();
                oReportDocument.Dispose();
                GC.Collect();
            }
        }


    }
}

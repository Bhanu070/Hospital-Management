using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management.Report
{
    public partial class IPD_Receipt : System.Web.UI.Page
    {
        public static string connection = ConfigurationSettings.AppSettings["Connectioninfo"];
        SqlConnection con = new SqlConnection(connection);
        ReportDocument crystalReport;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        ReportDocument ReportDoc = new ReportDocument();         
        public object CrystalReportViewer2 { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            string RollNo = Request.QueryString["Id"].ToString();
            if (RollNo != null)
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Connection.Open();
                cmd.CommandText = "IPD_Receipt";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@MainId", RollNo);
                da.TableMappings.Add("Table", "IPD_Receipt");
                da.TableMappings.Add("Table1", "IPD_Receipt_Item");

                da.Fill(ds);

                Session["reportpath"] = "~/CR_Reports/IPD_Receipt.rpt";
                String RptFilePath;
                RptFilePath = Server.MapPath(Server.UrlPathEncode(Session["reportpath"].ToString()));
                ReportDoc.Load(RptFilePath);
                ReportDoc.SetDataSource(ds);
                CrystalReportViewer1.ReportSource = ReportDoc;
                Stream oStream = null;
                oStream = (System.IO.Stream)ReportDoc.ExportToStream(ExportFormatType.PortableDocFormat);
                ReportDoc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Crystal");
                Response.End();
                GC.Collect();

            }
            else
            {
                //Response.Redirect("../Employee");
            }
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            if (this.ReportDoc != null)
            {
                this.ReportDoc.Close();
                this.ReportDoc.Dispose();
            }
        }
    }
}
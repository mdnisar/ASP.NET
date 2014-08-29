using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Ionic.Zip;
using System.IO;
using System.Text;
using System.Net;
public partial class DownloadZip1 : System.Web.UI.Page
{
    ClassControl cm = new ClassControl();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = cm.getdt("SELECT * FROM VW_RFI_ATCH_DTL_ALL_ZIP WHERE RAD_RFH_ID = 97");
        string output = "<style> table { min-width:600px; padding: 0px; box-shadow: 2px 2px 3px #888888; border: 1px solid #cccccc; -moz-border-radius-bottomleft: 0px; -webkit-border-bottom-left-radius: 0px; border-bottom-left-radius: 0px; -moz-border-radius-bottomright: 0px; -webkit-border-bottom-right-radius: 0px; border-bottom-right-radius: 0px; -moz-border-radius-topright: 0px; -webkit-border-top-right-radius: 0px; border-top-right-radius: 0px; -moz-border-radius-topleft: 0px; -webkit-border-top-left-radius: 0px; border-top-left-radius: 0px; } table table { height: 100%; margin: 0px; padding: 0px; } table tr:last-child td:last-child { -moz-border-radius-bottomright: 0px; -webkit-border-bottom-right-radius: 0px; border-bottom-right-radius: 0px; } table table tr:first-child td:first-child { -moz-border-radius-topleft: 0px; -webkit-border-top-left-radius: 0px; border-top-left-radius: 0px; } table table tr:first-child td:last-child { -moz-border-radius-topright: 0px; -webkit-border-top-right-radius: 0px; border-top-right-radius: 0px; } table tr:last-child td:first-child { -moz-border-radius-bottomleft: 0px; -webkit-border-bottom-left-radius: 0px; border-bottom-left-radius: 0px; } table tr:hover td { background-color: #e5e5e5; } table td { vertical-align: middle; background: -o-linear-gradient(bottom, #ffffff 5%, #e5e5e5 100%); background: -webkit-gradient( linear, left top, left bottom, color-stop(0.05, #ffffff), color-stop(1, #e5e5e5) ); background: -moz-linear-gradient( center top, #ffffff 5%, #e5e5e5 100% ); filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#ffffff', endColorstr='#e5e5e5'); background: -o-linear-gradient(top,#ffffff,e5e5e5); background-color: #ffffff; border: 1px solid #cccccc; border-width: 0px 1px 1px 0px; text-align: left; padding: 7px 4px 7px 4px; font-size: 10px; font-family: Arial; font-weight: normal; color: #000000; } table tr:last-child td { border-width: 0px 1px 0px 0px; } table tr td:last-child { border-width: 0px 0px 1px 0px; } table tr:last-child td:last-child { border-width: 0px 0px 0px 0px; } table tr:first-child td { background: -o-linear-gradient(bottom, #cccccc 5%, #b2b2b2 100%); background: -webkit-gradient( linear, left top, left bottom, color-stop(0.05, #cccccc), color-stop(1, #b2b2b2) ); background: -moz-linear-gradient( center top, #cccccc 5%, #b2b2b2 100% ); filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#cccccc', endColorstr='#b2b2b2'); background: -o-linear-gradient(top,#cccccc,b2b2b2); background-color: #cccccc; border: 0px solid #cccccc; text-align: center; border-width: 0px 0px 1px 1px; font-size: 12px; font-family: Arial; font-weight: bold; color: #000000; } table tr:first-child:hover td { background: -o-linear-gradient(bottom, #cccccc 5%, #b2b2b2 100%); background: -webkit-gradient( linear, left top, left bottom, color-stop(0.05, #cccccc), color-stop(1, #b2b2b2) ); background: -moz-linear-gradient( center top, #cccccc 5%, #b2b2b2 100% ); filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#cccccc', endColorstr='#b2b2b2'); background: -o-linear-gradient(top,#cccccc,b2b2b2); background-color: #cccccc; } table tr:first-child td:first-child { border-width: 0px 0px 1px 0px; } table tr:first-child td:last-child { border-width: 0px 0px 1px 1px; } table th { background: -o-linear-gradient(bottom, #ffffff 5%, #e5e5e5 100%); background: -webkit-gradient( linear, left top, left bottom, color-stop(0.05, #ffffff), color-stop(1, #e5e5e5) ); background: -moz-linear-gradient( center top, #ffffff 5%, #e5e5e5 100% ); filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#ffffff', endColorstr='#e5e5e5'); background: -o-linear-gradient(top,#ffffff,e5e5e5); background-color: #ffffff; border: 1px solid #888888; padding: 3px; font-family: Arial; font-size: 12px; } body { font-family: Arial; font-size: 12px; } </style>";
        output += "<div style=''><b>RFI for " + dt.Rows[0]["RAD_RFH_RFINO"].ToString() + "</b></div>";

        using (ZipFile zip = new ZipFile())
        {
            zip.AlternateEncodingUsage = ZipOption.Never;
            output += "<table>";
            output += "<tr><th>RFI Attach Type</th><th>Insepection</th><th>Remark</th><th>Date</th></tr>";
            foreach (DataRow row in dt.Rows)
            {
                output += "<tr>";
                if (File.Exists(Server.MapPath(row["RAD_FILE_SRVR"].ToString())))
                {
                    zip.AddFile(Server.MapPath(row["RAD_FILE_SRVR"].ToString()), (row["file_path"].ToString()));
                    output += "<td>";
                    output += (row["RAD_FILE_SRVR_link"].ToString());
                    output += "</td>";
                    output += "<td>";
                    output += (row["RAD_VAL_TYPE"].ToString());
                    output += "</td>";
                    output += "<td>";
                    output += (row["RAD_REMARKS"].ToString());
                    output += "</td>";
                    output += "<td>";
                    output += (row["RAD_DOC_DT"].ToString());
                    output += "</td>";
                }
                else
                {
                    output += "<td>";
                    output += "No file found";
                    output += "</td>";
                    output += "<td>";
                    output += (row["RAD_VAL_TYPE"].ToString());
                    output += "</td>";
                    output += "<td>";
                    output += (row["RAD_REMARKS"].ToString());
                    output += "</td>";
                    output += "<td>";
                    output += (row["RAD_DOC_DT"].ToString());
                    output += "</td>";
                    //zip.AddFile("");
                }
                output += "</tr>";
            }
            output += "</table>";
            byte[] data = Encoding.UTF8.GetBytes(output);
            zip.AddEntry("info.html", data);
            Response.Clear();
            Response.BufferOutput = false;
            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "attachment; filename=Zip_" + DateTime.Now.ToString("yyyy-MMM-dd-HHmmss") + ".zip");
            zip.Save(Response.OutputStream);
            Response.End();
        }
    }
}
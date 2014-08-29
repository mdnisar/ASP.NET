using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using Ionic.Zip;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindGridview();
        }
    }
    // Bind Data to Gridview
    protected void BindGridview()
    {
        string[] filesPath = Directory.GetFiles(Server.MapPath("~/SampleFiles/"));
        List<ListItem> files = new List<ListItem>();
        foreach (string path in filesPath)
        {
            files.Add(new ListItem(Path.GetFileName(path)));
        }
        gvDetails.DataSource = files;
        gvDetails.DataBind();
    }
    // insert files in folder
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (fileUpload1.HasFile)
        {
            string filename = Path.GetFileName(fileUpload1.PostedFile.FileName);
            string path = Server.MapPath("~/SampleFiles/" + filename);
            fileUpload1.SaveAs(path);
            lbltxt.Text = "File Uploaded Successfully";
            BindGridview();
        }
    }   
    // Zip all files from folder
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        using (ZipFile zip = new ZipFile())
        {
            foreach (GridViewRow gvrow in gvDetails.Rows)
            {
                CheckBox chk = (CheckBox) gvrow.FindControl("chkSelect");
                if(chk.Checked)
                {
                    string fileName= gvrow.Cells[1].Text ;
                    string filePath = Server.MapPath("~/SampleFiles/" + fileName);
                    zip.AddFile(filePath, "files");
                }
            }
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=DownloadedFile.zip");
            Response.ContentType = "application/zip";
            zip.Save(Response.OutputStream);
            Response.End();
        }
    }
  }

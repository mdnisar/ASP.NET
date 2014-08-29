using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Data.SqlClient;
/// <summary>
/// Summary description for ClassControl
/// </summary>
public class ClassControl
{
    public SqlConnection sqlCon = new SqlConnection("server=.; database=del; integrated security=true");
    public SqlDataAdapter adp;
    public DataTable Datatbl;
    public DataSet ds = new DataSet();
    public SqlCommand cmd;
    private readonly string _constring;
    public static Int32 NUM;
    public static string s;
    string oledbstring;
    public DataTable dt;

    public ClassControl()
    {
        _constring = "server=.; database=del; integrated security=true";
        //
        // TODO: Add constructor logic here
        //
    }
    public void Popddl(DropDownList cmbName, string tabName, string valueField, string displayField, string condition, string orderby, SqlConnection con)
    {

        oledbstring = "SELECT DISTINCT " + displayField + "," + valueField + " FROM " + tabName + " WHERE " + condition + " ORDER BY " + orderby + "";

        SqlConnection sqlCon = new SqlConnection(_constring);

        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(oledbstring, sqlCon);
        if (sqlCon.State != ConnectionState.Open)
        {
            sqlCon.Open();
        }
        da.Fill(ds);
        cmbName.AppendDataBoundItems = true;
        //cmbName.Items.Add("SELECT");
        //cmbName.Items[0].Value = "0";
        cmbName.DataSource = ds.Tables[0];
        cmbName.DataValueField = valueField;
        cmbName.DataTextField = displayField;
        cmbName.DataBind();
    }

    public void PopCmb(DropDownList cmbName, string tabName, string displayField, string condition, string orderby, SqlConnection con)
    {

        oledbstring = "SELECT DISTINCT " + displayField + " FROM " + tabName + " WHERE " + condition + " ORDER BY " + orderby + "";

        SqlConnection sqlCon = new SqlConnection(_constring);

        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(oledbstring, sqlCon);
        if (sqlCon.State != ConnectionState.Open)
        {
            sqlCon.Open();
        }
        da.Fill(ds);
        cmbName.AppendDataBoundItems = true;
        //cmbName.Items.Add("SELECT");
        //cmbName.Items[0].Value = "0";
        cmbName.DataSource = ds.Tables[0];
        cmbName.DataValueField = displayField;
        cmbName.DataTextField = displayField;
        cmbName.DataBind();
    }


    public DataSet GETDATASET(string QRY)
    {
        SqlConnection sqlCon = new SqlConnection(_constring);

        SqlDataAdapter dad = new SqlDataAdapter(QRY, sqlCon);
        DataSet dst = new DataSet();
        using (sqlCon)
        {
            dad.Fill(dst);
        }
        return dst;
    }

    public DataSet Duplicate(string QRY, TextBox txt)
    {
        SqlConnection sqlCon = new SqlConnection(_constring);

        DataSet dttxt = new DataSet();
        SqlDataAdapter dtadpt = new SqlDataAdapter(QRY, sqlCon);
        using (sqlCon)
        {
            dtadpt.Fill(dttxt);
        }
        return dttxt;
    }


    public DataTable getdt(string query)
    {
        adp = new SqlDataAdapter(query, sqlCon);
        Datatbl = new DataTable();
        adp.Fill(Datatbl);
        return Datatbl;
    }
    public DataTable getds1(string query)
    {
        if (sqlCon.State != ConnectionState.Open)
        {
            sqlCon.Open();
        }
        cmd = new SqlCommand(query, sqlCon);
        cmd.CommandTimeout = 0;
        //adp = new SqlDataAdapter(query, sqlCon);
        adp = new SqlDataAdapter(cmd);
        Datatbl = new DataTable();
        adp.Fill(Datatbl);
        sqlCon.Close();
        return Datatbl;
    }

    public void insert(string tbname, string val)
    {
        if (sqlCon.State != ConnectionState.Open)
        {
            sqlCon.Open();
        }
        adp = new SqlDataAdapter("insert into " + tbname + " values(" + val + ")", sqlCon);
        adp.Fill(ds);
        sqlCon.Close();
    }
    public void InseretRecord(string strTblNm, string strFieleds, string strValues)
    {
        if (sqlCon.State != ConnectionState.Open)
        {
            sqlCon.Open();
        }
        adp = new SqlDataAdapter("INSERT INTO " + strTblNm + "(" + strFieleds + ") VALUES (" + strValues + ")", sqlCon);
        adp.Fill(ds);
        sqlCon.Close();
    }
    public void DeleteRecords(string strTblNm, string strCondition)
    {
        if (sqlCon.State != ConnectionState.Open)
        {
            sqlCon.Open();
        }
        cmd = new SqlCommand("DELETE FROM " + strTblNm + " WHERE " + strCondition + "", sqlCon);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
    }
    //FOR GRIDVIEW
    public void FillGrid(string strQuery, GridView grd)
    {
        adp = new SqlDataAdapter(strQuery, sqlCon);
        ds = new DataSet();
        adp.Fill(ds);
        grd.DataSource = ds;
        grd.DataBind();
    }

    //FOR DATALIST
    public void Filldatalist(string strQuery, DataList dtl)
    {
        adp = new SqlDataAdapter(strQuery, sqlCon);
        ds = new DataSet();
        adp.Fill(ds);
        dtl.DataSource = ds;
        dtl.DataBind();
    }
    //FOR DROPDOWNLIST 
    public void FillDropDownList(string strQuery, string TextField, string ValueField, DropDownList drp)
    {
        // SqlConnection sqlCon = new SqlConnection(_constring);
        adp = new SqlDataAdapter(strQuery, sqlCon);
        ds = new DataSet();
        adp.Fill(ds);
        drp.DataSource = ds;
        drp.DataTextField = ds.Tables[0].Columns[TextField].ToString();
        drp.DataValueField = ds.Tables[0].Columns[ValueField].ToString();
        drp.DataBind();
        drp.Items.Insert(0, "SELECT");
    }
    public void FillDropDownListAll(string strQuery, string TextField, string ValueField, DropDownList drp)
    {
        // SqlConnection sqlCon = new SqlConnection(_constring);
        adp = new SqlDataAdapter(strQuery, sqlCon);
        ds = new DataSet();
        adp.Fill(ds);
        drp.DataSource = ds;
        drp.DataTextField = ds.Tables[0].Columns[TextField].ToString();
        drp.DataValueField = ds.Tables[0].Columns[ValueField].ToString();
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("All", "%"));
    }


    public void deleteid(string tblnm, string columnnm, string id)
    {
        adp = new SqlDataAdapter("DELETE_ID '" + tblnm + "','" + columnnm + "','" + id + "'", sqlCon);
        ds = new DataSet();
        adp.Fill(ds);

    }
    # region "Reset form control values"
    public void ResetFormControlValues(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.Controls.Count > 0)
            {
                ResetFormControlValues(c);
            }
            else
            {
                switch (c.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)c).Text = "";
                        break;
                    case "System.Web.UI.WebControls.CheckBox":
                        ((CheckBox)c).Checked = false;
                        break;
                    case "System.Web.UI.WebControls.RadioButton":
                        ((RadioButton)c).Checked = false;
                        break;
                    case "System.Web.UI.WebControls.HiddenField":
                        ((HiddenField)c).Value = "";
                        break;
                    case "System.Web.UI.WebControls.DropDownList":
                        ((DropDownList)c).SelectedIndex = -1;
                        break;
                    //case "System.Web.UI.WebControls.Label":
                    //    ((Label)c).Text = "";
                    //    break;
                }
            }
        }
    }
    # endregion

    public void vis_T(WebControl cntrl)
    {
        cntrl.Visible = true;
    }
    public void vis_F(WebControl cntrl)
    {
        cntrl.Visible = false;
    }
    public void enb_T(WebControl cntrl)
    {
        cntrl.Enabled = true;
        cntrl.BackColor = Color.White;
    }
    public void enb_F(WebControl cntrl)
    {
        cntrl.Enabled = false;
    }
    public void enb_False(WebControl cntrl)
    {
        cntrl.BackColor = System.Drawing.ColorTranslator.FromHtml("#D5D4FE");
        cntrl.Enabled = false;

    }
    public void insert(string strQry)
    {
        if (sqlCon.State != ConnectionState.Open)
        {
            sqlCon.Open();
        }
        string str = strQry;
        cmd = new SqlCommand();
        cmd.CommandTimeout = 0;
        cmd.CommandText = str;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = sqlCon;
        cmd.ExecuteNonQuery();
        sqlCon.Close();

    }
    public Boolean executeQuery(string Query)
    {
        try
        {
            if (sqlCon.State != ConnectionState.Open)
            {
                sqlCon.Open();
            }
            cmd = new SqlCommand(Query, sqlCon);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch { return false; }
    }
    public void grdvcolumnF(GridView grdv, int columnname)
    {
        grdv.Columns[columnname].Visible = false;
    }
    public void grdvcolumnT(GridView grdv, int columnname)
    {
        grdv.Columns[columnname].Visible = true;
    }


    public SqlDataReader GetDataReader(string Query)
    {
        SqlDataReader dr;

        try
        {
            SqlCommand cmd = new SqlCommand();
            sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = Query;
            dr = cmd.ExecuteReader();
            return dr;
            sqlCon.Close();
            // }
        }
        catch (Exception)
        {

            throw;
        }
    }


}

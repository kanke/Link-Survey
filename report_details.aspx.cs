using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using System.Text;
using CarlosAg.ExcelXmlWriter;

public partial class report_details : System.Web.UI.Page
{
    //DataSet dset = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        dset = new DataTable();
        string conn = ConfigurationManager.ConnectionStrings["link_surveyConnectionString"].ConnectionString;

        string sql = @"select l.qno
        ,l.response
        ,l.date
        ,b.name
        ,re.name
        ,hs.hss_name
        ,bm.bm_name

        from linksur.link_responses l 
        inner join linksur.link_branches b on l.branch_no = b.branch_no
        inner join linksur.link_regions re on l.region_no = re.region_no
		inner join linksur.link_hss hs on l.hss_no = hs.hss_no
        inner join linksur.link_bm bm on l.bm_no = bm.bm_no";
        //where l.qno in('2') order by l.qno desc,l.dept_no,l.branch_no";
        SqlConnection connection = new SqlConnection(conn);
        SqlCommand selectcommand = new SqlCommand(sql, connection);

        SqlDataAdapter adap = new SqlDataAdapter(selectcommand);
        adap.Fill(dset);

        GridView1.DataSource = dset;
        GridView1.DataBind();
        //} 
    }
    protected DataTable dset
    {
        set
        {
            ViewState["dset"] = value;
        }
        get
        {
            return (ViewState["dset"] != null) ? (DataTable)ViewState["dset"] : new DataTable();
        }
    }
    private DataTable GetData()
    {
        dset = new DataTable();
        string conn = ConfigurationManager.ConnectionStrings["link_surveyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(conn);

        string sql = @"select l.qno
        ,l.response
        ,l.date
        ,b.name
        ,re.name
        ,hs.hss_name
        ,bm.bm_name

        from linksur.link_responses l 
        inner join linksur.link_branches b on l.branch_no = b.branch_no
        inner join linksur.link_regions re on l.region_no = re.region_no
		inner join linksur.link_hss hs on l.hss_no = hs.hss_no
        inner join linksur.link_bm bm on l.bm_no = bm.bm_no
        where l.date >= @fromdate and l.date <= @todate order by l.date ASC";

        /* 
         ,l.response
         ,l.date
         ,d.dept_name
         ,b.name
         ,re.name
         ,hs.hss_name
         ,bm.bm_name
        
         * from linksur.link_responses l 
         inner join linksur.link_departments d on l.dept_no = d.dept_no
         inner join linksur.link_branches b on l.branch_no = b.branch_no
         inner join linksur.link_regions re on l.region_no = re.region_no
         inner join linksur.link_hss hs on l.hss_no = hs.hss_no
         inner join linksur.link_bm bm on l.bm_no = bm.bm_no
         where l.date >= @fromdate and l.date <= @todate order by l.date ASC";*/

        SqlCommand selectcommand = new SqlCommand(sql, connection);

        selectcommand.Parameters.AddWithValue("@fromdate", fromTextBox.Text);
        selectcommand.Parameters.AddWithValue("@todate", toTextBox.Text);
        connection.Open();

        SqlDataAdapter adap = new SqlDataAdapter(selectcommand);
        adap.Fill(dset);

        return dset;
    }
    private void DisplayResults()
    {
        GridView1.DataSource = GetData();
        GridView1.DataBind();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DisplayResults();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        fromTextBox.Text = "";
        toTextBox.Text = "";
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = GetData();
        GridView1.DataBind();
    }

    private void ExportEx()
    {
        DataTable dt = GetData();

        Workbook book = new Workbook();
        Worksheet sheet = book.Worksheets.Add("link-Performance-Survey-Report");

        WorksheetStyle style = book.Styles.Add("HeaderStyle");
        style.Font.FontName = "Tahoma";
        style.Font.Size = 14;
        style.Font.Bold = true;
        style.Alignment.Horizontal = StyleHorizontalAlignment.Center;
        style.Font.Color = "White";
        style.Interior.Color = "Blue";
        style.Interior.Pattern = StyleInteriorPattern.DiagCross;

        //Create the Default Style to use for everyone
        style = book.Styles.Add("Default");
        style.Font.FontName = "Tahoma";
        style.Font.Size = 10;


        WorksheetRow wsrow = sheet.Table.Rows.Add();
        //foreach (DataColumn TCol in dt.Columns) {
        //    wsrow.Cells.Add(TCol.ColumnName.ToString(), DataType.String, "HeaderStyle");
            wsrow.Cells.Add("Question number", DataType.String, "HeaderStyle");
            wsrow.Cells.Add("Response", DataType.String, "HeaderStyle");
            wsrow.Cells.Add("Date", DataType.String, "HeaderStyle");
           wsrow.Cells.Add("Branch", DataType.String, "HeaderStyle");
            wsrow.Cells.Add("Region", DataType.String, "HeaderStyle");
            wsrow.Cells.Add("Head of Service Support", DataType.String, "HeaderStyle");
            wsrow.Cells.Add("Branch Manager", DataType.String, "HeaderStyle");
        //}

        foreach (DataRow Row in dt.Rows) {
	        wsrow = sheet.Table.Rows.Add();
	        foreach (DataColumn TCol in dt.Columns) {
		        wsrow.Cells.Add(Row[TCol].ToString());
	        }
        }

        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Link-Performance-Survey-Report" + DateTime.Now.ToString("yyyyMMddhhmm") + ".xls");
        book.Save(Response.OutputStream);
        Response.End();
    }
    public static void Export(string fileName, GridView gv)
    {
        string style = @"<style> .text { mso-number-format:\@; } </style> ";
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader(
        "content-disposition", string.Format("attachment; filename={0}", fileName));
        HttpContext.Current.Response.ContentType = "application/ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                // Create a form to contain the grid
                Table table = new Table();

                // add the header row to the table
                if (gv.HeaderRow != null)
                {
                    PrepareControlForExport(gv.HeaderRow);
                    table.Rows.Add(gv.HeaderRow);
                }

                // add each of the data rows to the table
                foreach (GridViewRow row in gv.Rows)
                {
                    PrepareControlForExport(row);
                    table.Rows.Add(row);
                }

                // add the footer row to the table
                if (gv.FooterRow != null)
                {
                    PrepareControlForExport(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }

                // render the table into the htmlwriter
                table.RenderControl(htw);
                HttpContext.Current.Response.Write(style);
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }
    }
    private static void PrepareControlForExport(Control control)
    {
        for (int i = 0; i < control.Controls.Count; i++)
        {
            Control current = control.Controls[i];
            if (current is Label)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as Label).Text));
            }
            if (current is LinkButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
            }
            else if (current is HyperLink)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is CheckBox)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }

            if (current.HasControls())
            {
                PrepareControlForExport(current);
            }
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //string attachment = "attachment; filename = Remedy-Survey Report" + System.DateTime.Now.ToString(("yyyyMMddhhmm") + ".xls");
        //Response.ClearContent();
        //Response.AddHeader("content-disposition", attachment);
        //Response.ContentType = "application/vnd-excel";
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter htw = new HtmlTextWriter(sw);
        //// Create a form to contain the grid
        //HtmlForm frm = new HtmlForm();
        //GridView1.Parent.Controls.Add(frm);
        //frm.Attributes.Add("runat", "server");
        //frm.Controls.Add(GridView1);
        //frm.RenderControl(htw);
        ////GridView1.RenderControl(htw);
        //Response.Write(sw.ToString());
        //Response.End();

            }



    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        ExportEx();
        //Export the grid data to excel sheet
        //Export("Remedy-Survey-Report" + System.DateTime.Now.ToString("yyyyMMddhhmm") + ".xls", this.GridView1);

    }
    protected void ExportImageButton_Click(object sender, ImageClickEventArgs e)
    {
        
    }
}
    

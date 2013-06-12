using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for ExcelExport
/// </summary>
public class ExcelExport
{
	public ExcelExport()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    /*protected void createExcelReport()
    {
        DataTable table = new DataTable();
        CrefX.CsvWriter writer = new CrefX.CsvWriter(true, CrefX.BadCharAction.QuoteEntireField, ',');


        string sqlString = "select" //...rest of sql query

        Response.Clear();
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment; filename=\"survey_results.csv\"");

        sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        sqlcmd = new SqlCommand(sqlString, sqlcon);
        SqlDataAdapter adap = new SqlDataAdapter(sqlcmd);
        adap.Fill(table);

        string outputText = writer.WriteString(table);
        Response.Write(outputText);
        Response.End();        
    }*/
}

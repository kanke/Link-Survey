using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Sql;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Datahandler
/// </summary>
public class DBhandler
{
    public SqlCommand command;
    public SqlConnection connection;
    public DBhandler()
	{
        connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["link_surveyConnectionString"].ConnectionString;

        command = new SqlCommand();
        command.Connection = connection;
	}

    public void executeQueryBatch(string[] sqlquery)
    {
        try
        {
            connection.Open();
            foreach (string query in sqlquery)
            {
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        catch (SqlException sqle)
        {
            connection.Close();
            throw sqle;
        }
        finally
        {
            connection.Close();
        }
    }

    public int[][] executeReportBatch(string[][] sqlquery)
    {
        int[][] aggregates = new int[sqlquery.Length][];
        try
        {
            connection.Open();
            for(int x=1; x <= sqlquery.Length; x++)
            {
                aggregates[x-1] = new int[sqlquery[x-1].Length];
                for (int y = 1; y<= sqlquery[x-1].Length; y++)
                {
                    command.CommandText = sqlquery[x-1][y-1];
                    aggregates[x-1][y-1] = (int)command.ExecuteScalar();
                }
            }
            return aggregates;
        }
        catch (SqlException sqle)
        {
            throw sqle;
        }
        finally
        {
            connection.Close();
        }
    }
    
    public int executeScalar(string sqlquery)
    {
        try
        {
            connection.Open();
            command.CommandText = sqlquery;
            return (int)command.ExecuteScalar();                
        }
        catch (SqlException sqle)
        {
            throw sqle;
        }
        finally
        {
            connection.Close();
        }
    }
}

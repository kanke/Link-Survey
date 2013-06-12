using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Default : System.Web.UI.Page
{
    string[] responses = new string[10];
    string[] queries = new string[10];
   
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Redirect("Closed.aspx", true);
        //msgLabel.Visible = false;
        //for (int i = 1; i <= responses.Length; i++) 
        //{
        //    responses[i-1] = "";
        //    queries[i-1] = "";
        //}
       //TextBox28.Visible =/t9.SelectedValue.ToUpper().Equals("YES")); 
        
        
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
       
        try
        {
            ////build and store sql queries
            //for (int i = 1; i <= queries.Length; i++)
            //{
            //    queries[i - 1] = "insert into remsur.remedy_responses(qno,response,branch_no,dept_no,region_no,Date) values('";
            //    queries[i - 1] += i;
            //    queries[i - 1] += "','" + responses[i - 1];
            //    queries[i - 1] += "','" + DropDownList1.SelectedValue;
            //    queries[i - 1] += "','" + DeptDropDownList2.SelectedValue;
            //    queries[i - 1] += "','" + regDropDownList2.SelectedValue;
            //    queries[i - 1] += " ','" + DateTime.Now.ToString();
            //    //queries[i - 1] += "','" + BizRadioButtonList.SelectedValue;
            //    //queries[i - 1] += "','" + BizDDL.SelectedValue;
            //    //queries[i - 1] += "','" + DeptDDL.SelectedValue;
            //    //queries[i - 1] += "','" + BizRadioButtonList.SelectedValue;
            //    //queries[i - 1] += "','" + DeptRadioButtonList.SelectedValue;
            //    queries[i - 1] += "')";
            //}

            ////execute queries
            //new DBhandler().executeQueryBatch(queries);

           string insertSql;
           string conn = ConfigurationManager.ConnectionStrings["link_surveyConnectionString"].ConnectionString;
           SqlConnection connection = new SqlConnection(conn);

           insertSql = "insert into linksur.link_responses(qno,response,branch_no,region_no,Date,hss_no,bm_no)";
           insertSql += "VALUES (@qno,@response,@branch_no,@region_no,@Date,@HSS,@BM)";
          
           SqlCommand insertcommand = new SqlCommand(insertSql, connection);
           connection.Open();

            SqlParameter param1 = new SqlParameter("@qno", null);
            param1.SqlDbType = SqlDbType.VarChar;

            SqlParameter param2 = new SqlParameter("@response", null);
            param2.SqlDbType = SqlDbType.VarChar;

            SqlParameter param3 = new SqlParameter("@branch_no", null);
            param3.SqlDbType = SqlDbType.Int;

            //SqlParameter param4 = new SqlParameter("@dept_no", null);
            //param4.SqlDbType = SqlDbType.Int;

            SqlParameter param5= new SqlParameter("@region_no", null);
            param5.SqlDbType = SqlDbType.Int;

            SqlParameter param6 = new SqlParameter("@Date", null);
            param6.SqlDbType = SqlDbType.VarChar;

            SqlParameter param7 = new SqlParameter("@HSS", null);
            param7.SqlDbType = SqlDbType.VarChar;

            SqlParameter param8 = new SqlParameter("@BM", null);
            param8.SqlDbType = SqlDbType.VarChar;

            insertcommand.Parameters.Clear();
            insertcommand.Parameters.Add(param1);
            insertcommand.Parameters.Add(param2);
            insertcommand.Parameters.Add(param3);
            //insertcommand.Parameters.Add(param4);
            insertcommand.Parameters.Add(param5);
            insertcommand.Parameters.Add(param6);
            insertcommand.Parameters.Add(param7);
            insertcommand.Parameters.Add(param8);


            insertcommand.Parameters["@qno"].Value = 1;
            insertcommand.Parameters["@response"].Value = RadioButtonList1.SelectedItem.Text;
            insertcommand.Parameters["@branch_no"].Value = DropDownList1.SelectedValue;
            //insertcommand.Parameters["@dept_no"].Value = DeptDropDownList2.SelectedValue;
            insertcommand.Parameters["@region_no"].Value = regDropDownList2.SelectedValue;
            insertcommand.Parameters["@Date"].Value = DateTextBox.Text;
            insertcommand.Parameters["@HSS"].Value= HSSDropDownList.SelectedValue;
            insertcommand.Parameters["@BM"].Value= BMDropDownList.SelectedValue;
            //insertcommand.Parameters["@role"].Value = RadioButtonList10.SelectedItem.Text;
            insertcommand.ExecuteNonQuery();

            insertcommand.Parameters["@qno"].Value = 2;
            insertcommand.Parameters["@response"].Value = TextBox27.Text;
            insertcommand.Parameters["@branch_no"].Value = DropDownList1.SelectedValue;
            //insertcommand.Parameters["@dept_no"].Value = DeptDropDownList2.SelectedValue;
            insertcommand.Parameters["@region_no"].Value = regDropDownList2.SelectedValue;
            insertcommand.Parameters["@Date"].Value = DateTextBox.Text;
            insertcommand.Parameters["@HSS"].Value= HSSDropDownList.SelectedValue;
            insertcommand.Parameters["@BM"].Value= BMDropDownList.SelectedValue;
            //insertcommand.Parameters["@role"].Value = RadioButtonList10.SelectedItem.Text;
            insertcommand.ExecuteNonQuery();
       
            connection.Close();
            Response.Redirect("Endpage.aspx", true);
        }
        catch (Exception ex)
        {
            msgLabel.Text = ex.Message;
            msgLabel.Visible = true;
        }
      
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        responses[0] = RadioButtonList1.SelectedValue;
    }    
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //responses[1] = RadioButtonList2.SelectedValue;
    }
    protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        //responses[2] = RadioButtonList3.SelectedValue;
    }
    protected void RadioButtonList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        //responses[3] = RadioButtonList4.SelectedValue;
    }
    protected void RadioButtonList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        //responses[4] = RadioButtonList5.SelectedValue;
    }    
    protected void RadioButtonList6_SelectedIndexChanged(object sender, EventArgs e)
    {
       // responses[5] = RadioButtonList6.SelectedValue;
    }
    protected void RadioButtonList7_SelectedIndexChanged(object sender, EventArgs e)
    {
        //responses[6] = RadioButtonList7.SelectedValue;
    }
    protected void RadioButtonList8_SelectedIndexChanged(object sender, EventArgs e)
    {
        //responses[7] = RadioButtonList8.SelectedValue;
    }    
    protected void RadioButtonList9_SelectedIndexChanged(object sender, EventArgs e)
    {
        //responses[8] = RadioButtonList9.SelectedValue;
    }

    protected void TextBox26_TextChanged(object sender, EventArgs e)
    {
        //responses[8] = TextBox26.Text;
    }
    protected void TextBox27_TextChanged(object sender, EventArgs e)
    {
        responses[1] = TextBox27.Text;
    }
    protected void BizDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DeptDDL.DataBind();
        //if (BizDDL.SelectedValue.Equals("Wealth") == false)
        //{
        //    DeptDDL.Items.Add(new ListItem("Other", "Other"));
        //}
    }
    protected void DeptDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        //dept = DeptDDL.SelectedValue;
        //dept = DeptDDL.Text;
    }

    protected void DeptDDL_DataBound(object sender, EventArgs e)
    {
        
    }
    protected void DeptRadioButtonList_DataBound(object sender, EventArgs e)
    {
        //if (DeptRadioButtonList.Items.Count > 0)
        //    if (DeptRadioButtonList.Items[0].Text != "Wealth")//(DeptDDL.Items[0].Text != "Wealth")
        //        DeptRadioButtonList.Items.Add(new ListItem("Other", "Other"));
    }
    protected void BizRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void DeptRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //protected void RadioButtonList9_SelectedIndexChanged1(object sender, EventArgs e)
    //{
    //    ////if ( RadioButtonList9.SelectedItem.Text = "yes")
    //    ////{
    //    ////    TextBox27.Visible = true;
    //    ////}

    //    //if (yesRadioButton1.Checked)
    //    //{
    //    //    TextBox27.Visible = true;
    //    //}
    //    //else
    //    //{
    //    //    TextBox27.Visible = false;
    //    //}
    
    //}
    protected void yesRadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        //if (yesRadioButton1.Checked)
        //{
        //    TextBox27.Visible = true;
        //}
        //else
        //{
        //    TextBox27.Visible = false;
        //}
    }
    protected void noRadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        
    }
    protected void RadioButtonList9_SelectedIndexChanged2(object sender, EventArgs e)
    {
        //TextBox28.Visible = (RadioButtonList9.SelectedValue.ToUpper().Equals("YES"));

    }
    protected void RadioButtonList9_TextChanged(object sender, EventArgs e)
    {

    }
    protected void regDropDownList2_DataBound(object sender, EventArgs e)
    {
        //DeptDropDown.Items.Insert(0, new ListItem("-- Select One --", "0"));
        regDropDownList2.Items.Insert(0, new ListItem("-- Select Region --", "0"));
    }
    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        DropDownList1.Items.Insert(0, new ListItem("-- Select Branch --", "0"));
    }
    protected void DeptDropDownList2_DataBound(object sender, EventArgs e)
    {
        //DeptDropDownList2.Items.Insert(0, new ListItem("-- Select Department --", "0"));
    }

    protected void HSSDropDownList_DataBound(object sender, EventArgs e)
    {
       // HSSDropDownList.Items.Insert(0, new ListItem("-- Select HSS --", "0"));
    }

    protected void BMDropDownList_DataBound(object sender, EventArgs e)
    {
      //  BMDropDownList.Items.Insert(0, new ListItem("-- Select BM --", "0"));  
    }
    protected void HSSDropDownList_DataBound1(object sender, EventArgs e)
    {
        HSSDropDownList.Items.Insert(0, new ListItem("-- Select HSS --", "0"));
    }
    protected void BMDropDownList_DataBound1(object sender, EventArgs e)
    {
        BMDropDownList.Items.Insert(0, new ListItem("-- Select BM --", "0")); 
    }
}




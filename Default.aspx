<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%--EnableViewState="true"--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
</script>

<%--<script type="text/javascript" language="javascript">
function InterfaceControl1(id)
{
var radioQ1 = document.getElementsByName(id);
for (var ii = 0; ii < radioQ1;i++)
{
if (radioQ1[ii].checked)
{
if (radioQ1[ii].value == "0")
{
document.getElementById("TextBox27").style.display = 'inline';
//to show
}
else
{
document.getElementById("TextBox27").style.display = 'none';
//to hide
}
}
}
}

</script>--%>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Link Performance Survey</title>
    <style type="text/css">
        .style1
        {
            width: 194px;
        }
        .style2
        {
            width: 86px;
        }
        .style3
        {
            width: 22px;
            height: 13px;
        }
        .style4
        {
            width: 500px;
            height: 13px;
        }
        .style5
        {
            width: 362px;
            height: 13px;
        }
        .style6
        {
            width: 74px;
            height: 13px;
        }
        .style7
        {
            width: 22px;
            height: 27px;
        }
        .style8
        {
            width: 500px;
            height: 27px;
        }
        .style9
        {
            width: 362px;
            height: 27px;
        }
        .style10
        {
            width: 74px;
            height: 27px;
        }
        .style11
        {
            height: 23px;
        }
        .style12
        {
            width: 86px;
            height: 23px;
        }
        .style13
        {
            width: 194px;
            height: 23px;
        }
    </style>
</head>
<body>
<%--#ffffe7--%>
<%--C0F7FE--%>
    <form id="form1" runat="server">
    <div style="border:double 2pt #0070c0; padding:2pt 2pt 2pt 2pt; background:#C0F7FE;
    font-size: 10pt; font-family:Trebuchet MS" >              
        <p>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/banner.jpg" Width="1393px" 
                Height="77px" />
        </p>
        <p>Welcome to the Link Performance Survey!</p>

        <%--<p>The Core Banking Project is now in its critical stages and significant business involvement will be required till go-live. One of the tools to assess the current state of the business in terms of readiness for the implementation is the Business Readiness survey.</p>

        <p>The Business Readiness Survey is a periodic assessment geared at obtaining feedback on the readiness of the organization for the Core Banking change and the effectiveness of the change management and engagement activities completed to date.  This will help us in developing action plans to address readiness shortfalls  and issues and risks that may be identified.</p>--%>

        <p>Kindly provide your honest opinion as this will help in addressing your link 
            performance at your Brannch/Region. </p>

        <p>This questionnaire consist of only ONE section and addresses your level of satisfaction with the 
            data links at the branch.</p>

       <%-- <p>The questionnaires will be assessed for each stakeholder group based on averages.</p>

        <p>Please provide honest answers.</p>--%>

        
        <p><b>PERFORMANCE LINK KEY: </b></p>
            
        <p><B>GOOD - Posting completed unders 3 minutes</B></p>
        <p><b>BAD - Posting took over 3 minutes</b></p>
        </div>
        
    <div>
        <table style="font-size: 10pt; font-family:Trebuchet MS">
            <tr>
                <td>&nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td>Date: </td>
                <td class="style2">
                    <asp:TextBox ID="DateTextBox" runat="server">--Select Date--</asp:TextBox>
                    <cc1:CalendarExtender ID="DateTextBox_CalendarExtender" runat="server" 
                        TargetControlID="DateTextBox">
                    </cc1:CalendarExtender>
                </td>
                <td class="style1">
                    <asp:Image ID="Image2" runat="server" Height="28px" 
                        ImageUrl="~/images/1305898649_Calender.png" Width="31px" />
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" 
                        ControlToValidate="DateTextBox" ErrorMessage="Please select a Date"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td>Region:</td>
                <td class="style2">
                    <asp:DropDownList ID="regDropDownList2" runat="server" AutoPostBack="True" 
                        DataSourceID="RegionSqlDataSource2" DataTextField="name" 
                        DataValueField="region_no" ondatabound="regDropDownList2_DataBound">
                        <asp:ListItem Value="0">--select Region--</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" 
                        ControlToValidate="regDropDownList2" ErrorMessage="Please select a region"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td><asp:Label ID="Label1" runat="server">Branch:</asp:Label></td>
                <td class="style2">
                <%--
                    <asp:DropDownList ID="BizDDL" runat="server" Width="199px" OnSelectedIndexChanged="BizDDL_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value="Business Support" Text="Business Support"></asp:ListItem>
                        <asp:ListItem Value="CEO Direct Reports" Text="CEO Direct Reports"></asp:ListItem>
                        <asp:ListItem Value="CIB" Text="CIB"></asp:ListItem>
                        <asp:ListItem Value="PBB" Text="PBB"></asp:ListItem>
                        <asp:ListItem Value="Wealth" Text="Wealth"></asp:ListItem></asp:DropDownList></td>
                --%>
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        DataSourceID="BranchSqlDataSource3" DataTextField="name" 
                        DataValueField="branch_no" Height="22px" Width="141px" AutoPostBack="True" 
                        ondatabound="DropDownList1_DataBound">
                        <asp:ListItem Value="0">-select Branch--</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style1"><asp:RequiredFieldValidator ID="BranchRequiredFieldValidator" 
                        runat="server" ControlToValidate="DropDownList1"
                        ErrorMessage="Please select a Branch"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="style11"></td>
                <td class="style12">
                    </td>
                <td class="style13"></td>
            </tr>
            <tr>
                <td>HSS:</td>
                <td class="style2">
                    <asp:DropDownList ID="HSSDropDownList" runat="server" AutoPostBack="True" 
                        DataSourceID="hssSqlDataSource" DataTextField="hss_name" 
                        DataValueField="hss_no" ondatabound="HSSDropDownList_DataBound1">
                        <asp:ListItem Value="0">--select HSS--</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style1">
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator32" runat="server" 
                        ControlToValidate="HSSDropDownList" ErrorMessage="Please select a HSS"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td>BM:</td>
                <td class="style2">
                    <asp:DropDownList ID="BMDropDownList" runat="server" AutoPostBack="True" 
                        DataSourceID="bmSqlDataSource2" DataTextField="bm_name" DataValueField="bm_no" 
                        ondatabound="BMDropDownList_DataBound1">
                        <asp:ListItem Value="0">--select Branch Manager--</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style1">
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator33" runat="server" 
                        ControlToValidate="BMDropDownList" ErrorMessage="Please select a BM"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">&nbsp;</td>
            </tr>
          
        </table>
    </div>
    <div><table></table>&nbsp;<br /></div>
    <div>
     <table style="font-family:Trebuchet MS ; font-size: 10pt; vertical-align:middle" border="0" width="1000">
            <tr>
                <td class="style7">&nbsp;</td>
                <td class="style8"> How was the performance of the Branch link today?</td>
                <td class="style9" >
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                        <asp:ListItem Value="1" Text="GOOD"></asp:ListItem>
                        <asp:ListItem Value="0" Text="BAD"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style10"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadioButtonList1"
                        ErrorMessage="required"></asp:RequiredFieldValidator></td>
            </tr>            
            <tr>
                <td class="style3"></td>
                <td class="style4"></td>
                <td class="style5" >
                </td>
                <td class="style6">
                </td>
            </tr>            
            <tr>
                <td style="width: 22px">&nbsp;</td>
                <td style="width: 500px"><B><I>SERVICE IMPROVEMENT:</I></B></td>
                <td style="width: 362px" >                    
                    &nbsp;</td>
                <td style="width: 74px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 22px">&nbsp;</td>
                <td style="width: 500px">&nbsp;</td>
                <td style="width: 362px" >                    
                    &nbsp;</td>
                <td style="width: 74px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 22px">&nbsp;</td>
                <td style="width: 500px">Kindly state any additional problems/areas of 
                    dissatisfaction ?</td>
                <td style="width: 362px" >                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:TextBox ID="TextBox27" runat="server" TextMode="MultiLine" Width="250px" 
                        OnTextChanged="TextBox27_TextChanged" MaxLength="500" 
                        style="text-align: left" ></asp:TextBox>                    
                </td>
               
               
                <td style="width: 74px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="TextBox27"
                        ErrorMessage="required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr align="center">
                <td colspan="4">
                    <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
                </td>
            </tr>
            
            
            
            
              <tr align="center">
                <td colspan="4">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:Label ID="msgLabel" runat="server" Width="600px"></asp:Label>
                </td>
            </tr>
            
            
        </table>
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        &nbsp;<asp:SqlDataSource ID="hssSqlDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:hss_DataCaptureConnectionString %>" 
        SelectCommand="select hss_name,hss_no from linksur.link_hss where (branch_no=@branch)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="branch" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="RegionSqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:RegionConnectionString %>" 
        SelectCommand="select name,region_no from linksur.link_regions">
    </asp:SqlDataSource>
&nbsp;<asp:SqlDataSource ID="bmSqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:bm_DataCaptureConnectionString %>" 
        SelectCommand="select bm_name,bm_no from linksur.link_bm where (branch_no=@branch)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="branch" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="BranchSqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:BranchesSqlDataSource %>" 
        
        SelectCommand="select name,branch_no  from linksur.link_branches WHERE (region_no=@region)">
        <SelectParameters>
            <asp:ControlParameter ControlID="regDropDownList2" Name="region" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
        
    <br />
        
    </form>
</body>
</html>

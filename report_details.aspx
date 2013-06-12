<%@ Page Language="C#"  EnableEventValidation ="false" AutoEventWireup="true" CodeFile="report_details.aspx.cs" Inherits="report_details" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Link Performance Survey : Detailed Report</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
        }
        .style3
        {
        }
        .style4
        {
            width: 125px;
        }
        .style5
        {
            width: 130px;
            height: 31px;
        }
        .style6
        {
            width: 187px;
            height: 31px;
        }
        .style7
        {
            width: 125px;
            height: 31px;
        }
        .style8
        {
            height: 31px;
        }
        .style9
        {
            height: 69px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
        <asp:TableHeaderRow ID="TableHeaderRow1" runat="server"  HorizontalAlign="Center">
                <asp:TableHeaderCell ID="TableHeaderCell1" runat="server" ColumnSpan="14" BackColor="Gold"> Detailed Report
                    <%--<asp:Label ID="LabelTotalRespondents" runat="server"></asp:Label>--%>
                </asp:TableHeaderCell>                
            </asp:TableHeaderRow>
            <tr>
                <td class="style2">
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl="~/images/1305883412_table_excel.png" 
                        onclick="ImageButton1_Click1" Height="40px" ToolTip="Export to Excel" 
                        Width="53px" />
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Date Range From:&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="fromTextBox" 
                        runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="fromTextBox_CalendarExtender" runat="server" 
                        TargetControlID="fromTextBox">
                    </cc1:CalendarExtender>&nbsp;&nbsp;
                    <asp:Image ID="Image1" runat="server" 
                        ImageUrl="~/images/1305898649_Calender.png" />
                </td>
                <td class="style3">
                    &nbsp;
                    To:&nbsp;&nbsp;<asp:TextBox ID="toTextBox" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="toTextBox_CalendarExtender" runat="server" 
                        TargetControlID="toTextBox">
                    </cc1:CalendarExtender>&nbsp;&nbsp;
                    <asp:Image ID="Image2" runat="server" 
                        ImageUrl="~/images/1305898649_Calender.png" />
                    </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;
                    </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Button ID="Button2" runat="server" Text="Submit" onclick="Button2_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="Clear" onclick="Button1_Click" />
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    </td>
                <td class="style6">
                    </td>
                <td class="style7">
                    </td>
                <td class="style8">
                    </td>
            </tr>
            <tr>
                <td class="style9" colspan="3">
                    <asp:GridView ID="GridView1" runat="server" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" 
                        ForeColor="#333333" GridLines="None" style="margin-left: 0px" 
                        Width="751px" AllowPaging="True" 
                        onpageindexchanging="GridView1_PageIndexChanging" PageSize="13">
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="qno" HeaderText="Q.No" />
                            <asp:BoundField DataField="response" HeaderText="Response" />
                            <asp:BoundField DataField="date" HeaderText="Date" />
                            <asp:BoundField DataField="name" HeaderText="Branch" />
                            <asp:BoundField DataField="name" HeaderText="Region" />
                            <asp:BoundField DataField="hss_name" HeaderText="Head of Service Support" />
                            <asp:BoundField DataField="bm_name" HeaderText="Branch Manager" />
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </td>
                <td class="style9">
                    </td>
            </tr>
            <tr>
                <td class="style9" colspan="3">
        <asp:Table ID="Table1" runat="server">            
            <asp:TableFooterRow>            
                <asp:TableCell><asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Endpage.aspx">Exit</asp:LinkButton></asp:TableCell>
            </asp:TableFooterRow>
        </asp:Table>
        
                </td>
                <td class="style9">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" colspan="3">
                    <asp:SqlDataSource ID="link_responseSqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:link_responses %>" SelectCommand="select l.qno
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
order by l.qno desc,l.branch_no"></asp:SqlDataSource>
                </td>
                <td class="style9">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <br />
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemIssueStock.aspx.cs" Inherits="FalconReportingweb.ItemIssueStock" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Item Stock Report</title>
    <link href="Asstes/Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-3">
                        <b>Select Date</b>
                        <asp:TextBox ID="datetxt" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <b>Select Project</b>
                        <asp:DropDownList ID="projectddr" AppendDataBoundItems="true" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id">
                            <asp:ListItem Value="0">STORE</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FalconHouseConnectionString %>" SelectCommand="SELECT [Id], [Name] FROM [ProjectTypeTb]"></asp:SqlDataSource>
                    </div>
                </div>
                
                <asp:Button ID="filterbtn" runat="server" Text="Filter" OnClick="filterbtn_Click" />
            </div>
            <div class="col-md-3">
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
            </div>
             <div class="col-md-6">
                 <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="395px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="845px">
                     <LocalReport ReportPath="Reports\IssueStock.rdlc">
                     </LocalReport>
                 </rsweb:ReportViewer>
            </div>
             <div class="col-md-3">
             </div>
        </div>
    </form>
</body>
</html>

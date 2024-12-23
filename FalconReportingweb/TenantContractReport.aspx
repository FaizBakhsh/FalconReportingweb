<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TenantContractReport.aspx.cs" Inherits="FalconReportingweb.TenantContractReport" %>


<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Servant Card</title>
    <link href="Asstes/Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

         <div class="container-fluid">
            <div class="row">
                <div class="col-md-3">
                </div>
                <div class="col-md-3">
                    <b>From Date</b>
                    <br />
                    <asp:TextBox ID="fromdate" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <b>To Date</b>
                    <br />
                    <asp:TextBox ID="Todate" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <b></b>
                    <br />
                    <asp:Button ID="filterbtn" CssClass="btn btn-success" runat="server" Text="Filter" OnClick="filterbtn_Click" />
                </div>
                <div class="col-md-3">
                </div>
                <div class="col-md-8">
                      <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server"  AutoDataBind="true" />
                   
                </div>
                <div class="col-md-1">
                </div>
            </div>
        </div>


       <%-- <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-6">
            </div>
            <div class="col-md-3">
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-6">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="677px" AsyncRendering="False" KeepSessionAlive="False" Height="708px">
                    <LocalReport ReportPath="Reports\RentContractReport.rdlc" EnableExternalImages="True">
                    </LocalReport>
                </rsweb:ReportViewer>
            </div>
            <div class="col-md-3">
            </div>
        </div>--%>


    </form>
</body>
</html>

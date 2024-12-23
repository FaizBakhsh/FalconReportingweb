<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chargesreport.aspx.cs" Inherits="FalconReportingweb.Chargesreport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Charges</title>
    <link href="Asstes/Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
    <div class="row">
        <div class="col-md-2">

        </div>
        <div class="col-md-8">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="574px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="681px">
                <LocalReport ReportPath="Reports\Chargesrpt.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
        <div class="col-md-2">

        </div>
    </div>
    </div>
    </form>
</body>
</html>

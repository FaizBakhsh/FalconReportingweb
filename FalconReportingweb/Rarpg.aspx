<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rarpg.aspx.cs" Inherits="FalconReportingweb.Rarpg" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Infragistics4.Web.v21.1, Version=21.1.20211.2, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI" TagPrefix="ig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ig:WebScriptManager ID="WebScriptManager1" runat="server"></ig:WebScriptManager>
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="679px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="806px">
            <LocalReport ReportPath="Reports\RarReport.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>

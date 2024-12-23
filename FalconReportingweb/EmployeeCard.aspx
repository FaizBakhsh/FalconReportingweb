<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeCard.aspx.cs" Inherits="FalconReportingweb.EmployeeCard" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <div>
       <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="500px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="788px" AsyncRendering="False" KeepSessionAlive="False">
            <localreport reportpath="Reports\Employee.rdlc" enableexternalimages="True">
            </localreport>
        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>

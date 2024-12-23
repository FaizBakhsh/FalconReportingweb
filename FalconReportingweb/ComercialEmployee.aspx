<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComercialEmployee.aspx.cs" Inherits="FalconReportingweb.ComercialEmployee" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Asstes/Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluide">
    <div class="row">
        <div class="col-md-2">

        </div>
         <div class="col-md-8">
             <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="728px" Height="580px">
                 <LocalReport EnableExternalImages="True" ReportPath="Reports\ComercialEmployee.rdlc">
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

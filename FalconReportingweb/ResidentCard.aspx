<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResidentCard.aspx.cs" Inherits="FalconReportingweb.ResidentCard" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Asstes/Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row">
            <div class="col-md-2">

            </div>
             <div class="col-md-8">
                  <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="630px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="780px" AsyncRendering="False" KeepSessionAlive="False">
            <localreport reportpath="Reports\LocalResident.rdlc" enableexternalimages="True">
            </localreport>
        </rsweb:ReportViewer>
            </div>
             <div class="col-md-2">

            </div>
        </div>

    </form>
</body>
</html>

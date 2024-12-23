<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResidentForeginer.aspx.cs" Inherits="FalconReportingweb.ResidentForeginer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Resident Card</title>
    <link href="Asstes/Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

         <div class="row">
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
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="500px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="650px" AsyncRendering="False" KeepSessionAlive="False">
             <localreport reportpath="Reports\ForeignerReport.rdlc" enableexternalimages="True">
            </localreport>
        </rsweb:ReportViewer>
            </div>
            <div class="col-md-3">
            </div>
        </div>

  
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VehicleReport.aspx.cs" Inherits="FalconReportingweb.VehicleReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vehicle Report</title>
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
           <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="700px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="650px" AsyncRendering="False" KeepSessionAlive="False">
            <LocalReport ReportPath="Reports\VehicleRpt.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
            </div>
            <div class="col-md-3">
            </div>
        </div>

    <div>

    </div>
    </form>
</body>
</html>

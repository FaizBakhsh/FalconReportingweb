<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HouseDetail.aspx.cs" Inherits="FalconReportingweb.HouseDetail" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous"/>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <div class="row">
            <div class="col-md-4">

            </div>
              <div class="col-md-4">
                  <asp:TextBox ID="housenumber" placeholder="HoseNumber" runat="server"></asp:TextBox>
                  <asp:Button ID="Button1"  runat="server" Text="HouseDetail" OnClick="Button1_Click" />
            </div>
              <div class="col-md-4">

            </div>
        </div>
        <div class="row">
            <div class="col-md-4">

            </div>
              <div class="col-md-4">
         <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="500px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="650px" AsyncRendering="False" KeepSessionAlive="False">
            <LocalReport EnableExternalImages="True" EnableHyperlinks="True" ReportPath="Reports\HDetailRpt.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
            </div>
              <div class="col-md-4">

            </div>
        </div> 
    </div>
    </form>
</body>
</html>

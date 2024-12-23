﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HouseOccupancy.aspx.cs" Inherits="FalconReportingweb.HouseOccupancy" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Infragistics4.Web.v21.1, Version=21.1.20211.2, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI" TagPrefix="ig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>House Occupancy</title>
    <link href="Asstes/Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <ig:WebScriptManager ID="WebScriptManager1" runat="server"></ig:WebScriptManager>
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
                    <LocalReport EnableExternalImages="True" ReportPath="Reports\HouseOccupancy.rdlc" EnableHyperlinks="True">
                    </LocalReport>
                </rsweb:ReportViewer>
            </div>
            <div class="col-md-3">
            </div>
        </div>
    </form>
</body>
</html>

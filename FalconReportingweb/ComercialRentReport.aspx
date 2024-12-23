﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComercialRentReport.aspx.cs" Inherits="FalconReportingweb.ComercialRentReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Comercial Rent Report</title>
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
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="555px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="661px">
                        <LocalReport ReportPath="Reports\ComercialRent1.rdlc">
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
                <div class="col-md-1">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
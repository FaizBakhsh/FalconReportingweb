<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintFinepg.aspx.cs" Inherits="FalconReporting.PrintFinepg" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fine</title>
    <link href="Asstes/Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div  style="text-align:center; margin-left:300px">

                <%-- Start Report  --%>

             
 

                                                        <h2>
                                                            <asp:Label ID="displaylbl" runat="server" Text=""></asp:Label></h2>

                <CR:CrystalReportViewer ID="CrystalReportViewer1" ToolPanelView="None" runat="server" AutoDataBind="true" />   
        </div>
    </form>
</body>
</html>

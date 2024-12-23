<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvanceBill.aspx.cs" Inherits="FalconReportingweb.AdvanceBill" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bills</title>
    <link href="Asstes/Content/bootstrap.min.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-3">

                </div>
                <div class="col-md-2">
                    <b>Select Month</b>
                    <asp:TextBox ID="monthtxt" CssClass="form-control" TextMode="Date" placeholder="Select Month" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <b>Select House</b>
                    <asp:DropDownList ID="houseddr" runat="server" CssClass="form-control" AppendDataBoundItems="true" DataSourceID="SqlDataSource1" DataTextField="HouseNo" DataValueField="Id">
                        <asp:ListItem Value="0">All</asp:ListItem>
                        <asp:ListItem Value="-1">All IH</asp:ListItem>
                        <asp:ListItem Value="-2">All SD</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FalconHouseConnectionString %>" SelectCommand="SELECT [Id], [HouseNo] FROM [House]"></asp:SqlDataSource>
                </div>
                <div class="col-md-2" style="padding-top:15px">
                  
                    <asp:Button ID="filterbtn" CssClass="btn btn-primary" runat="server" Text="Filter" OnClick="filterbtn_Click" />
                </div>
                <div class="col-md-3">

                </div>
            </div>
          
        </div>
        
             <div  style="text-align:center; margin-left:300px">

                <%-- Start Report  --%>

             
 

                                                        <h2>
                                                            <asp:Label ID="displaylbl" runat="server" Text=""></asp:Label></h2>
                                            
                                                       

                 <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server"  AutoDataBind="true" />
        </div>
          
    </form>
</body>
</html>
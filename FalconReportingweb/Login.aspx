<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FalconReportingweb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Asstes/Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid" style="margin-top:150px">
            <div class="row">
                <div class="col-md-4">

                </div>
                <div class="col-md-4">
                    <div class="row">
                        <div class="col-md-12">
                            <b>User Name</b>
                            <asp:TextBox ID="usernametxt" CssClass="form-control" placeholder="User Name" required="" runat="server"></asp:TextBox>
                        </div>
                          <div class="col-md-12">
                            <b>Password</b>
                            <asp:TextBox ID="passtxt" CssClass="form-control" placeholder="Password" required="" runat="server"></asp:TextBox>
                        </div>
                          <div class="col-md-12">
                            <b>.</b>
                              <asp:Button ID="loginbtn" runat="server" Text="Login" CssClass="btn btn-dark" OnClick="loginbtn_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-md-4">

                </div>
            </div>
        </div>
    </form>
</body>
</html>

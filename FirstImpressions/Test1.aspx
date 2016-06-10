<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test1.aspx.cs" Inherits="FirstImpressions.Test1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

         <div class="form-group">
                        <div class="col-md-10">

                        Current User ID: <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" /> <br /> <br />
                         pictureid: <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control" /> <br /> <br />
                         raterslot: <asp:TextBox runat="server" ID="TextBox3" CssClass="form-control" /> <br /> <br />
                            Gender: <asp:TextBox runat="server" ID="TextBox4" CssClass="form-control" /> <br /> <br />
                            Counter: <asp:TextBox runat="server" ID="TextBox5" CssClass="form-control" /> <br /> <br />

                        </div>
             </div>
    
    </div>
    </form>
</body>
</html>

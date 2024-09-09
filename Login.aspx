<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project1.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login Page</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
    
    <style>
        .banner {
            width: 100%;
        }

        .center-content {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 55vh; /* Full viewport height */
            text-align: center;
        }
    </style>
    
    <script type="text/javascript">
        function validateNumberInput(event) {
            var charCode = (event.which) ? event.which : event.keyCode;
            if (charCode === 8 || charCode === 9 || charCode === 37 || charCode === 39 || charCode === 46) {
                return true;
            }
            if (charCode >= 48 && charCode <= 57) {
                return true;
            }
            event.preventDefault();
            return false;
        }
    </script>

</head>
<body>
    <div>
        <img src="Banner1.png" class="banner" />
        <hr style="border: 3px solid black; margin: 2px 0;" />
    </div> 
    <br /><br /><br /><br />
    <div class="center-content">
        <div class="card" style="width: 100%; max-width: 400px;">
            <div class="card-body bg-success rounded">
                <h1 class="card-title text-center"; style="color: white">Login Info</h1><br />
                <form id="loginForm" runat="server">
                    <div class="mb-3" style="text-align: left">
                        <label for="TextBoxEmp_Id" class="form-label" style="color: white; font-size: 20px">Employee ID:</label>
                        <asp:TextBox ID="TextBoxEmp_Id" runat="server" CssClass="form-control" onkeypress="return validateNumberInput(event)" />
                        <asp:Label ID="LabelEmp_IdError" runat="server" ForeColor="yellow"></asp:Label>
                    </div>
                    <div class="mb-3" style="text-align: left">
                        <label for="TextBoxPassword" class="form-label" style="color: white; font-size: 20px">Password:</label>
                        <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="form-control" TextMode="Password" />
                        <asp:Label ID="LabelPasswordError" runat="server" ForeColor="yellow"></asp:Label>
                    </div>
                    <br />
                    <div class="d-grid">
                        <asp:Button ID="LoginButton" runat="server" Text="Login" CssClass="btn btn-info" OnClick="LoginButton_Click" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
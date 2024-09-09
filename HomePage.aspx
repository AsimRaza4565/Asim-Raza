<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login Page</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>

    <style>
        /* Flexbox container for centering content */
        .center-content {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 80vh; /* Full viewport height */
            text-align: center;
        }

        .nav-link {
            color: white;
        }

            .nav-link:hover {
                text-decoration: underline;
                color: greenyellow;
            }
    </style>

</head>
<body style="font-size: 20px">
    <div class="container-fluid">
        <!-- Navigation Bar -->
        <nav class="navbar navbar-expand-sm bg-success nav-margin">
            <div class="container-fluid">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" href="HomePage.aspx">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="OPTION_FORM.aspx">C.P FUND OPTION FORM</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="NOMINATION_FORM.aspx">C.P FUND NOMINATION FORM</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Login.aspx">Exit></a>
                    </li>
                </ul>
            </div>
        </nav>
        <!-- Centered Content -->
        <div class="center-content" style="background-color: lightgreen">
            <h1 class="display-1" style="font-family: 'Arial'; font-weight: bold; color: white">BISP EMPLOYEES' C.P FUND FORMS</h1>
        </div>
    </div>
</body>
</html>

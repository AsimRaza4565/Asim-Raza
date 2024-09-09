<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NOMINATION_FORM.aspx.cs" Inherits="Project1.NOMINATION_FORM" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Employee Form</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>

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

        function showSuccessModal() {
            var myModal = new bootstrap.Modal(document.getElementById('successModal'));
            myModal.show();
        }

        function updateModalContent(message, showGoBackButton) {
            document.getElementById('modalBodyContent').innerHTML = message;
            if (showGoBackButton) {
                document.getElementById('goBackButton').style.display = 'inline-block';
            } else {
                document.getElementById('goBackButton').style.display = 'none';
            }
        }

        function onFormSubmitSuccess() {
            updateModalContent('Form submitted successfully!', true);
            showSuccessModal();
        }

        function onlyLetters(event) {
            var charCode = (event.which) ? event.which : event.keyCode;
            if (charCode === 8 || charCode === 9 || charCode === 37 || charCode === 39 || charCode === 46) {
                return true;
            }
            if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122) || charCode === 32) {
                return true;
            }
            event.preventDefault();
            return false;
        }
    </script>

    <style>
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
        <br />

        <p style="text-align: right; padding-right: 40px;"><u>ANNEX-II</u></p>
        <h2 class="text-center"><b><u>BISP EMPLOYEES' C.P FUND NOMINATION FORM</u></b></h2>
        <h3 class="text-center"><u>Part-I</u></h3>
        <br />
    </div>

    <div class="container-fluid">
        <div class="page-body">
            <form id="form1" runat="server" autocomplete="off" style="padding-left: 40px; padding-right: 40px;">
                <asp:ScriptManager ID="ScriptManager1" runat="server" />

                <div class="row">
                    <!--Part-I-->
                    <div class="col-sm-6">
                        <label for="TextBox1"><b>Name of Applicant:</b></label>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Your Name" onkeypress="return onlyLetters(event)"></asp:TextBox>
                        &nbsp;
                        <asp:Label ID="LabelNameError" runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>
                    <div class="col-sm-6">
                        <label for="TextBox2"><b>Designation:</b></label>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Your Designation" onkeypress="return onlyLetters(event)"></asp:TextBox>
                        &nbsp;
                        <asp:Label ID="LabelDesgError" runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <label for="TextBox3"><b>SPS:</b></label>
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="SPS" onkeypress="return validateNumberInput(event)"></asp:TextBox>
                        &nbsp;
                        <asp:Label ID="LabelSPSError" runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <label for="TextBox4"><b>Employee ID:</b></label>
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="Your Id" onkeypress="return validateNumberInput(event)"></asp:TextBox>
                        &nbsp;
                        <asp:Label ID="LabelEmp_IdError" runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <label for="TextBox5"><b>CPF A/c No:</b></label>
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" placeholder="Your Account" onkeypress="return validateNumberInput(event)"></asp:TextBox>
                        &nbsp;
                        <asp:Label ID="LabelCPF_Acc_NoError" runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <label for="DropDownListAcc_Type"><b>A/c Type:</b></label>
                        <asp:DropDownList ID="DropDownListAcc_Type" runat="server" CssClass="form-control">
                            <asp:ListItem Text="" Value="" />
                        </asp:DropDownList>
                        &nbsp;
                        <asp:Label runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>

                    <hr style="border: 3px solid black; border-radius: 2px;" />

                    <!--Part-II-->
                    <h3 class="text-center"><u>Part-II</u></h3>
                    <!--Nominee 1-->
                    <div class="col-sm-12">
                        <label for="TextBox6"><b>Nominee1.</b></label>
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" onkeypress="return onlyLetters(event)" placeholder="Nominee1 Name">
                        </asp:TextBox>
                        &nbsp;
                        <asp:Label runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>
                    <div class="col-sm-7">
                        <label for="DropDownList1"><b>Relationship with the Subscriber:</b></label>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                            <asp:ListItem Text="" Value="" />
                        </asp:DropDownList>
                        &nbsp;
                        <asp:Label runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>
                    <div class="col-sm-5">
                        <label for="TextBox7"><b>% age of Fund</b></label>
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" onkeypress="return validateNumberInput(event)"></asp:TextBox>
                        &nbsp;
                        <asp:Label runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>
                    <!--Nominee 2-->
                    <div class="col-sm-12">
                        <label for="TextBox8"><b>Nominee2.</b></label>
                        <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" onkeypress="return onlyLetters(event)" placeholder="Nominee2 Name">
                        </asp:TextBox>
                        &nbsp;
                        <asp:Label runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>
                    <div class="col-sm-7">
                        <label for="DropDownList2"><b>Relationship with the Subscriber:</b></label>
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                            <asp:ListItem Text="" Value="" />
                        </asp:DropDownList>
                        &nbsp;
                        <asp:Label runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>
                    <div class="col-sm-5">
                        <label for="TextBox9"><b>% age of Fund</b></label>
                        <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control" onkeypress="return validateNumberInput(event)"></asp:TextBox>
                        &nbsp;
                        <asp:Label runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>
                    <!--Nominee 3-->
                    <div class="col-sm-12">
                        <label for="TextBox10"><b>Nominee3.</b></label>
                        <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control" onkeypress="return onlyLetters(event)" placeholder="Nominee3 Name">
                        </asp:TextBox>
                        &nbsp;
                        <asp:Label runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>
                    <div class="col-sm-7">
                        <label for="DropDownList3"><b>Relationship with the Subscriber:</b></label>
                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" placeholder="abs">
                            <asp:ListItem Text="" Value="" />
                        </asp:DropDownList>
                        &nbsp;
                        <asp:Label runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>
                    <div class="col-sm-5">
                        <label for="TextBox11"><b>% age of Fund</b></label>
                        <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control"></asp:TextBox>
                        &nbsp;
                        <asp:Label runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>
                    <!--Nominee 4-->
                    <div class="col-sm-12">
                        <label for="TextBox12"><b>Nominee4.</b></label>
                        <asp:TextBox ID="TextBox12" runat="server" CssClass="form-control" onkeypress="return onlyLetters(event)" placeholder="Nominee4 Name">
                        </asp:TextBox>
                        &nbsp;
                        <asp:Label runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>
                    <div class="col-sm-7">
                        <label for="DropDownList4"><b>Relationship with the Subscriber:</b></label>
                        <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control">
                            <asp:ListItem Text="" Value="" />
                        </asp:DropDownList>
                        &nbsp;
                        <asp:Label runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>
                    <div class="col-sm-5">
                        <label for="TextBox13"><b>% age of Fund</b></label>
                        <asp:TextBox ID="TextBox13" runat="server" CssClass="form-control"></asp:TextBox>
                        &nbsp;
                        <asp:Label runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>

                    <hr style="border: 3px solid black; border-radius: 2px;" />

                    <!--Part-III-->
                    <center>
                        <h3 style="margin-bottom: 20px"><u>Part-III</u></h3>
                    </center>
                    The nominations
                    <div class="col-sm-3">
                        <asp:TextBox ID="TextBox14" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:Label runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>
                    as per Part-II above are
                    <div class="col-sm-3">
                        <asp:DropDownList ID="DropDownListPart3II" runat="server" CssClass="form-control">
                            <asp:ListItem Text="" Value="" />
                        </asp:DropDownList>
                        &nbsp;
                        <asp:Label runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>
                    <br />
                    <br />
                    <hr style="border: 3px solid black; border-radius: 2px;" />

                    <!--Part-IV-->
                    <center>
                        <h3 style="margin-bottom: 20px"><u>Part-IV</u></h3>
                    </center>
                    The records of Funds of Fund subscriber have been updated on
                    <div class="col-sm-3">
                        <asp:TextBox ID="TextBox15" runat="server" CssClass="form-control"></asp:TextBox>
                        &nbsp;
                        <asp:Label runat="server" CssClass="error-message" ForeColor="red"></asp:Label>
                    </div>

                    <!-- Bootstrap Modal -->
                    <div class="modal fade" id="successModal" tabindex="-1" aria-labelledby="modalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="modalLabel">Submission Status</h5>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body" id="modalBodyContent">
                                    Your form has been submitted successfully!
                                </div>
                                <div class="modal-footer">
                                    <a id="goBackButton" href="HomePage.aspx" class="btn btn-primary">Go Back</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Submit button-->
                <div class="form-group" style="text-align: right">
                    <asp:Button runat="server" ID="ButtonSubmit" CssClass="btn btn-success" Text="Submit" OnClick="Button1_Click" />
                </div>
                <div>
                    <hr />
                </div>
            </form>
        </div>
    </div>

    <script>
        function onFormSubmitSuccess() {
            updateModalContent('Your Form is submitted successfully!', true);
        }
    </script>

</body>
</html>

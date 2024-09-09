using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace Project1
{
    public partial class Login : Page
    {
        private string connectionString = "Server=.\\sqlexpress;Database=Project1;User Id=sa;Password=sa;";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Clears previous error messages and inputs on every page load
            if (!IsPostBack)
            {
                ClearForm();
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string inputEmp_Id = TextBoxEmp_Id.Text.Trim();
            string inputPassword = TextBoxPassword.Text.Trim();

            bool isValid = true;

            if (string.IsNullOrEmpty(inputEmp_Id))
            {
                LabelEmp_IdError.Text = "Employee Id is required.";
                isValid = false;
            }
            if (string.IsNullOrEmpty(inputPassword))
            {
                LabelPasswordError.Text = "Password is required.";
                isValid = false;
            }
            if (isValid)
            {
                int status = AuthenticateUserStatus(inputEmp_Id, inputPassword);

                if (status == 1)
                {
                    Session["AuthenticatedUser"] = inputEmp_Id; // Setting session variable
                    Response.Redirect("HomePage.aspx");
                }
                else if (status == 0)
                {
                    LabelPasswordError.Text = "Your account is inactive! Please contact the Administrator.";
                }
                else
                {
                    LabelPasswordError.Text = "Invalid Employee Id or password.";
                }
            }
        }

        private bool AuthenticateUser(string Emp_Id, string password)
        {
            string query = "SELECT COUNT(*) FROM Login_Info WHERE Emp_Id = @Emp_Id AND Password = @Password AND is_active = 1";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Emp_Id", Emp_Id);
                    cmd.Parameters.AddWithValue("@Password", password);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private int AuthenticateUserStatus(string Emp_Id, string password)
        {
            string query = "SELECT is_active FROM Login_Info WHERE Emp_Id = @Emp_Id AND Password = @Password";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Emp_Id", Emp_Id);
                    cmd.Parameters.AddWithValue("@Password", password);

                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    // If no user is found
                    if (result == null)
                        return -1; // User not found

                    return Convert.ToInt32(result); // will return is_active value (0 or 1)
                }
            }
        }

        private void ClearForm()
        {
            // Clears the TextBox fields
            TextBoxEmp_Id.Text = "";
            TextBoxPassword.Text = "";
            // Clears error messages
            LabelEmp_IdError.Text = "";
            LabelPasswordError.Text = "";
        }
    }
}
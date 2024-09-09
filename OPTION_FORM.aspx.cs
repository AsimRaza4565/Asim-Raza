using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class OPTION_FORM : System.Web.UI.Page
    {
        private string connectionString = "Server=.\\sqlexpress;Database=Project1;User Id=sa;Password=sa;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AuthenticatedUser"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindDropdowns();
            }
        }

        private void BindDropdowns()
        {
            BindDropdown(DropDownListpart2, "SELECT Id, type FROM part2", "type", "Id");
            BindDropdown(DropDownListpart3, "SELECT Id, type FROM part2", "type", "Id"); //loading part2 dropdown in part3 of the form
            BindDropdown(DropDownListPart3II, "SELECT Id, type FROM part3", "type", "Id");
        }

        private void BindDropdown(DropDownList dropdown, string query, string textField, string valueField)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dropdown.DataSource = dt;
                    dropdown.DataTextField = textField;
                    dropdown.DataValueField = valueField;
                    dropdown.DataBind();
                    dropdown.Items.Insert(0, new ListItem(""));
                }
                catch (Exception ex)
                {
                    // Log or show error message
                    Response.Write("Error in BindDropdown: " + ex.Message);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Server-side form handling logic
            string NameText = TextBox1.Text.Trim();
            string DesgText = TextBox2.Text.Trim();
            string SPSText = TextBox3.Text.Trim();
            string Emp_IdText = TextBox4.Text.Trim();
            string CPF_Acc_NoText = TextBox5.Text.Trim();
            string part2Text = DropDownListpart2.SelectedItem.Text;
            string part3Text = DropDownListpart3.SelectedItem.Text;
            string Part3IIText = DropDownListPart3II.SelectedItem.Text;
            string part4Text = TextBox6.Text.Trim();

            if (ValidateForm(Emp_IdText, NameText, SPSText, DesgText, CPF_Acc_NoText))
            {
                InsertData(NameText, DesgText, SPSText, Emp_IdText, CPF_Acc_NoText, part2Text, part3Text, Part3IIText, part4Text);
                ClearForm();

                // displaying another success modal
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showSuccessMessage", "onFormSubmitSuccess();", true);
            }
        }

        private bool DoesEmp_IdExist(string Emp_Id)
        {
            string query = "SELECT COUNT(*) FROM CP_FUND_OPTION_FORM WHERE Emp_Id = @Emp_Id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Emp_Id", Emp_Id);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private bool ValidateForm(string Emp_Id, string Name, string SPS, string Desg, string CPF_Acc_No)
        {
            bool isValid = true;

            LabelNameError.Text = "";
            LabelDesgError.Text = "";
            LabelSPSError.Text = "";
            LabelEmp_IdError.Text = "";
            LabelCPF_Acc_NoError.Text = "";

            if (string.IsNullOrEmpty(Emp_Id))
            {
                LabelEmp_IdError.Text = "Id is required.";
                isValid = false;
            }
            else if (DoesEmp_IdExist(Emp_Id))
            {
                LabelEmp_IdError.Text = "User already exists.";
                isValid = false;
            }
            if (string.IsNullOrEmpty(Name))
            {
                LabelNameError.Text = "Name is required.";
                isValid = false;
            }
            if (string.IsNullOrEmpty(SPS))
            {
                LabelSPSError.Text = "SPS is required.";
                isValid = false;
            }
            if (string.IsNullOrEmpty(Desg))
            {
                LabelDesgError.Text = "Designation is required.";
                isValid = false;
            }
            if (string.IsNullOrEmpty(CPF_Acc_No))
            {
                LabelCPF_Acc_NoError.Text = "Account Number required.";
                isValid = false;
            }
            return isValid;
        }

        private void InsertData(string Name, string Desg, string SPS, string Emp_Id, string CPF_Acc_No, string part2, string part3, string Part3II, string part4)
        {
            string query = "INSERT INTO CP_FUND_OPTION_FORM (Name, Desg, SPS, Emp_Id, CPF_Acc_No, part2, part3, Part3II, part4) " +
            "VALUES (@Name, @Desg, @SPS, @Emp_Id, @CPF_Acc_No, @part2, @part3, @Part3II, @part4)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Desg", Desg);
                cmd.Parameters.AddWithValue("@SPS", SPS);
                cmd.Parameters.AddWithValue("@Emp_Id", Emp_Id);
                cmd.Parameters.AddWithValue("@CPF_Acc_No", CPF_Acc_No);
                cmd.Parameters.AddWithValue("@part2", part2);
                cmd.Parameters.AddWithValue("@part3", part3);
                cmd.Parameters.AddWithValue("@Part3II", Part3II);
                cmd.Parameters.AddWithValue("@part4", part4);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log the exception or show it
                    Response.Write("Error in InsertData: " + ex.Message);
                }
            }
        }

        private void ClearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            DropDownListpart2.SelectedIndex = 0;
            DropDownListpart3.SelectedIndex = 0;
            DropDownListPart3II.SelectedIndex = 0;
            TextBox6.Text = "";
        }
    }
}
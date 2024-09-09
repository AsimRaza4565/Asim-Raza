using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Project1
{
    public partial class NOMINATION_FORM : System.Web.UI.Page
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
            BindDropdown(DropDownListAcc_Type, "SELECT Id, type FROM Acc_Type", "type", "Id");
            BindDropdown(DropDownList1, "SELECT Id, Relation FROM NR", "Relation", "Id");
            BindDropdown(DropDownList2, "SELECT Id, Relation FROM NR", "Relation", "Id");
            BindDropdown(DropDownList3, "SELECT Id, Relation FROM NR", "Relation", "Id");
            BindDropdown(DropDownList4, "SELECT Id, Relation FROM NR", "Relation", "Id");
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
            string NameText = TextBox1.Text.Trim();
            string DesgText = TextBox2.Text.Trim();
            string SPSText = TextBox3.Text.Trim();
            string Emp_IdText = TextBox4.Text.Trim();
            string CPF_Acc_NoText = TextBox5.Text.Trim();
            string Acc_TypeText = DropDownListAcc_Type.SelectedItem.Text; // Will get the text, not the value
            string Nominee1Text = TextBox6.Text.Trim();
            string Relation1Text = DropDownList1.SelectedItem.Text;
            string Percentage1Text = TextBox7.Text.Trim();
            string Nominee2Text = TextBox8.Text.Trim();
            string Relation2Text = DropDownList2.SelectedItem.Text;
            string Percentage2Text = TextBox9.Text.Trim();
            string Nominee3Text = TextBox10.Text.Trim();
            string Relation3Text = DropDownList3.SelectedItem.Text;
            string Percentage3Text = TextBox11.Text.Trim();
            string Nominee4Text = TextBox12.Text.Trim();
            string Relation4Text = DropDownList1.SelectedItem.Text;
            string Percentage4Text = TextBox13.Text.Trim();
            string Part3Text = TextBox14.Text.Trim();
            string Part3IIText = DropDownListPart3II.SelectedItem.Text;
            string Part4Text = TextBox15.Text.Trim();

            // Converting Emp_Id to int
            int.TryParse(Emp_IdText, out int Emp_Id);

            if (ValidateForm(Emp_IdText, NameText, SPSText, DesgText, CPF_Acc_NoText))
            {
                InsertData(NameText, DesgText, SPSText, Emp_Id, CPF_Acc_NoText, Acc_TypeText, Nominee1Text, Relation1Text, Percentage1Text,
                Nominee2Text, Relation2Text, Percentage2Text, Nominee3Text, Relation3Text, Percentage3Text, Nominee4Text,
                Relation4Text, Percentage4Text, Part3Text, Part3IIText, Part4Text);

                ClearForm();
                // displaying another success modal
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showSuccessMessage", "onFormSubmitSuccess();", true);
            }
        }

        private bool DoesEmp_IdExist(string Emp_Id)
        {
            string query = "SELECT COUNT(*) FROM CP_FUND_NOMINATION_FORM WHERE Emp_Id = @Emp_Id";

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

        private void InsertData(string Name, string Desg, string SPS, int Emp_Id, string CPF_Acc_No, string Acc_Type, string Nominee1,
        string Relation1, string Percentage1, string Nominee2, string Relation2, string Percentage2, string Nominee3, string Relation3,
        string Percentage3, string Nominee4, string Relation4, string Percentage4, string Part3, string Part3II, string Part4)
        {
            string query = "INSERT INTO CP_FUND_NOMINATION_FORM (Name, Desg, SPS, Emp_Id, CPF_Acc_No, Acc_Type, Nominee1, Relation1, Percentage1, " +
            "Nominee2, Relation2, Percentage2, Nominee3, Relation3, Percentage3, Nominee4, Relation4, Percentage4, Part3, Part3II, Part4) " +
            "VALUES (@Name, @Desg, @SPS, @Emp_Id, @CPF_Acc_No, @Acc_Type, @Nominee1, @Relation1, @Percentage1, " +
            "@Nominee2, @Relation2, @Percentage2, @Nominee3, @Relation3, @Percentage3, @Nominee4, @Relation4, @Percentage4, @Part3, @Part3II, @Part4)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Desg", Desg);
                cmd.Parameters.AddWithValue("@SPS", SPS);
                cmd.Parameters.AddWithValue("@Emp_Id", Emp_Id);
                cmd.Parameters.AddWithValue("@CPF_Acc_No", CPF_Acc_No);
                cmd.Parameters.AddWithValue("@Acc_Type", Acc_Type);
                cmd.Parameters.AddWithValue("@Nominee1", Nominee1);
                cmd.Parameters.AddWithValue("@Relation1", Relation1);
                cmd.Parameters.AddWithValue("@Percentage1", Percentage1);
                cmd.Parameters.AddWithValue("@Nominee2", Nominee2);
                cmd.Parameters.AddWithValue("@Relation2", Relation2);
                cmd.Parameters.AddWithValue("@Percentage2", Percentage2);
                cmd.Parameters.AddWithValue("@Nominee3", Nominee3);
                cmd.Parameters.AddWithValue("@Relation3", Relation3);
                cmd.Parameters.AddWithValue("@Percentage3", Percentage3);
                cmd.Parameters.AddWithValue("@Nominee4", Nominee4);
                cmd.Parameters.AddWithValue("@Relation4", Relation4);
                cmd.Parameters.AddWithValue("@Percentage4", Percentage4);
                cmd.Parameters.AddWithValue("@Part3", Part3);
                cmd.Parameters.AddWithValue("@Part3II", Part3II);
                cmd.Parameters.AddWithValue("@Part4", Part4);

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
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox13.Text = "";
            TextBox14.Text = "";
            TextBox15.Text = "";
            DropDownListAcc_Type.SelectedIndex = 0;
            DropDownList1.SelectedIndex = 0;
            DropDownList2.SelectedIndex = 0;
            DropDownList3.SelectedIndex = 0;
            DropDownList4.SelectedIndex = 0;
            DropDownListPart3II.SelectedIndex = 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavAppDesktopRegistration
{
    public partial class Login : Form
    {
        #region Private Fields
        private string pass;
        private int userID;
        private UserModel _currentUser;

        #endregion

        #region Ctor
        public Login()
        {
           InitializeComponent();
           Init();
        } 
        #endregion

        #region Private Event CallBack 
        private void CloseBtn_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loginbtn_MouseEnter(object sender, EventArgs e)
        {

        }
        private void loginbtn_Click(object sender, EventArgs e)
        {
            //Check here Login Success or Not then
            //if success then 

            HoldButton();
            //this.Hide();
            //new RegistrationFormMain(_currentUser, this).Show();                       
        }
        #endregion

        #region Private Mothods
        private static DataTable LookupUser(string Username)
        {
            const string connStr = @"Data Source=.;Initial Catalog=beta_2;Integrated Security=True";

            //"Data Source=apex2006sql;Initial Catalog=Leather;Integrated Security=True;";

            const string query = "Select password, UserID From dbo.Users Where UserName = @UserName";
            DataTable result = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = Username;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        result.Load(dr);
                    }
                }
            }
            return result;
        }


        private void HoldButton()
        {
            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                //Focus box before showing a message
                tbUsername.Focus();
                MessageBox.Show("Enter your username", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Focus again afterwards, sometimes people double click message boxes and select another control accidentally
                tbUsername.Focus();
                tbPassword.Clear();
                return;
            }
            else if (string.IsNullOrEmpty(tbPassword.Text))
            {
                tbPassword.Focus();
                MessageBox.Show("Enter your password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbPassword.Focus();
                return;

            }
            //OK they enter a user and pass, lets see if they can authenticate
            using (DataTable dt = LookupUser(tbUsername.Text))
            {
                if (dt.Rows.Count == 0)
                {
                    tbUsername.Focus();
                    MessageBox.Show("Invalid username.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbUsername.Focus();
                    tbUsername.Clear();
                    tbPassword.Clear();
                    return;
                }
                else
                {
                    string dbPassword = Convert.ToString(dt.Rows[0]["Password"]);
                    string appPassword = Convert.ToString(tbPassword.Text); //we store the password as encrypted in the DB
                    userID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                    pass = dbPassword;

                    Console.WriteLine(string.Compare(dbPassword, appPassword));

                    if (string.Compare(dbPassword, appPassword) == 0)
                    {
                        DialogResult = DialogResult.OK;
                        this.Hide();
                        //_congratulation = new CongratulationPageView();
                        //_congratulation.Show();
                        new RegistrationFormMain(_currentUser, this).Show();
                        insert();

                    }
                    else
                    {
                        //You may want to use the same error message so they can't tell which field they got wrong
                        tbPassword.Focus();
                        MessageBox.Show("Invalid Password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbPassword.Focus();
                        tbPassword.Clear();
                        return;
                    }
                }
            }
        }

        #endregion

        #region Public Method
        public void Init()
        {
            _currentUser = new UserModel();
        }

        public string UserName
        {
            get
            {
                return tbUsername.Text;
            }
        }

        public void insert()
        {

            const string connStr = @"Data Source=.;initial Catalog=beta_2;Integrated Security=True"; 
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("logentry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@TimeOfEnter", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
    }
}

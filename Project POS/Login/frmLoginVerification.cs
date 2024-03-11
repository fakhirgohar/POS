using Project_POS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_POS.Login
{
    public partial class frmLoginVerification : Form
    {
        public frmLoginVerification()
        {
            InitializeComponent();
        }
        SqlConnection con; SqlTransaction tran;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLoginID.Text.Trim().ToString()))
            {
                MessageBox.Show(this, "Please Enter LoginID !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text.Trim().ToString()))
            {
                MessageBox.Show(this, "Please Enter Password !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return;
            }
            else
            {
                string LoginId = string.Empty;
                if (SqlQuery.IsFound(con, tran, Global.ConnectionString, "tbl_Users", $"UserName='{txtLoginID.Text}'"))
                {
                    LoginId = SqlQuery.GetSingleValue(con, tran, Global.ConnectionString, $"SELECT UserId FROM tbl_Users WHERE UserName = '{txtLoginID.Text}'");
                }

                string hash = SqlQuery.GetSingleValue(con, tran, Global.ConnectionString, $"SELECT HashingPassword FROM LoginVerification WITH(NOLOCK) WHERE LoginID = '{LoginId}'");
                string salt = SqlQuery.GetSingleValue(con, tran, Global.ConnectionString, $"SELECT SaltString FROM LoginVerification WITH(NOLOCK) WHERE LoginID = '{LoginId}'");
                bool isValidPassword = VerifyPassword(txtPassword.Text, hash, salt);
                if (isValidPassword)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Invalid LoginID or Password !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return;
                }
            }
        }

        public static bool VerifyPassword(string password, string hash, string salt)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hash) || string.IsNullOrEmpty(salt))
            {
                return false;
            }

            else
            {
                byte[] saltBytes = Convert.FromBase64String(salt);
                Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
                byte[] hashBytes = rfc2898DeriveBytes.GetBytes(20);
                string hashString = Convert.ToBase64String(hashBytes);
                return hashString == hash;
            }
        }
    }
}

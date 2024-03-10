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
            string LoginID = txtLoginID.Text;
            string password = txtPassword.Text;
            string hash = SqlQuery.GetSingleValue(con, tran, Global.ConnectionString, $"SELECT HashingPassword FROM LoginVerification WITH(NOLOCK) WHERE LoginID = '{LoginID}'");
            string salt = SqlQuery.GetSingleValue(con, tran, Global.ConnectionString, $"SELECT SaltString FROM LoginVerification WITH(NOLOCK) WHERE LoginID = '{LoginID}'");
            bool isValidPassword = VerifyPassword(password, hash, salt);
            if (isValidPassword)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Invalid LoginID or Password !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
            }


            //if (!(SqllExtension.IsFound(con, tran, Global.ConnectionString, "LoginVerification", $"LoginID = '{txtLoginID.Text}' AND Password = '{txtPassword.Text}'")))
            //{

            //}
            //else
            //{
            //    this.Close();
            //}
        }

        public static bool VerifyPassword(string password, string hash, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            byte[] hashBytes = rfc2898DeriveBytes.GetBytes(20);
            string hashString = Convert.ToBase64String(hashBytes);
            return hashString == hash;
        }
    }
}

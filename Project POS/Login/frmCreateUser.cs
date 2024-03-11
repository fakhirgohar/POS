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
    public partial class frmCreateUser : Form
    {
        public frmCreateUser()
        {
            InitializeComponent();
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
        }
        SqlConnection con; SqlTransaction tran; DataTable dtCategory = new DataTable();

        #region functions
        private void Insert()
        {
            using (con = new SqlConnection(Global.ConnectionString))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    if (string.IsNullOrEmpty(txtUserName.Text)) { MessageBox.Show(this, "Enter User Name !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }
                    txtUserID.Text = Convert.ToString(SqlQuery.GetTransNo(con, tran, Global.ConnectionString, "tbl_Users", "UserId"));
                    byte[] saltBytes = GenerateSalt();
                    string salt = Convert.ToBase64String(saltBytes);
                    string hashedPassword = HashPassword(txtPass.Text, saltBytes);
                    SqlQuery.Insert(con, tran, "tbl_Users", Global.ConnectionString, new Dictionary<string, object> { { "UserId", txtUserID.Text }, { "UserName", txtUserName.Text }, { "Password", txtPass.Text}, { "IsActive", chkActive.Checked } });
                    SqlQuery.Insert(con, tran, "LoginVerification", Global.ConnectionString, new Dictionary<string, object> { {"LoginID", txtUserID.Text }, { "SaltString", salt }, { "HashingPassword", hashedPassword } });;
                    tran.Commit();
                    con.Dispose();
                    MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Save);
                    MessageBox.Show(this, "Saved Successfully !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    IsEnable(false);
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open) { con.Close(); }
                }
            }
        }
        private new void Update()
        {
            if (BeforeUpdateDelete())
            {
                using (con = new SqlConnection(Global.ConnectionString))
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    try
                    {
                        if (string.IsNullOrEmpty(txtUserName.Text)) { MessageBox.Show(this, "Enter Category Name !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }
                        SqlQuery.Update(con, tran, Global.ConnectionString, "Inventory_Category", $"WHERE CatID = {txtUserID.Text} ", new Dictionary<string, object> { { "CatName", txtUserName.Text } });
                        tran.Commit();
                        con.Dispose();
                        MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Save);
                        MessageBox.Show(this, "Update Successfully !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        IsEnable(false);
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open) { con.Close(); }
                    }
                }
            }
        }
        private void Delete()
        {
            if (string.IsNullOrEmpty(txtUserID.Text.Trim())) { MessageBox.Show(this, "No Record to Delete !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }

            else
            {
                if (BeforeUpdateDelete())
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to Delete ?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        using (con = new SqlConnection(Global.ConnectionString))
                        {
                            con.Open();
                            tran = con.BeginTransaction();
                            try
                            {
                                SqlQuery.Delete(con, tran, Global.ConnectionString, "tbl_Users", $" UserId = '{txtUserID.Text}'");
                                SqlQuery.Delete(con, tran, Global.ConnectionString, "LoginVerification", $" LoginId = '{txtUserID.Text}'");
                                tran.Commit();
                                con.Dispose();
                                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Cancel);
                                txtboxClear();
                                MessageBox.Show(this, "Deleted Successfully !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                IsEnable(false);
                            }
                            catch (Exception ex)
                            {
                                tran.Rollback();
                                throw new Exception(ex.Message);
                            }
                            finally
                            {
                                if (con.State == ConnectionState.Open) { con.Close(); }
                            }
                        }
                    }
                }
            }
        }

        private bool BeforeUpdateDelete()
        {
            //if (SqlQuery.IsFound(con, tran, Global.ConnectionString, "Inventory_Products", $"CatID = {txtUserID.Text}"))
            //{
            //    MessageBox.Show(this, "Category Used in Product !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false;
            //}
            //else if (SqlQuery.IsFound(con, tran, Global.ConnectionString, "Inventory_Items", $"CatID = {txtUserID.Text}"))
            //{
            //    MessageBox.Show(this, "Category Used in Items !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false;
            //}
            return true;

        }
        private void Edit()
        {
            MessageBox.Show(this, "Cannot Edit The User !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            //if (BeforeUpdateDelete())
            //{
            //    if (string.IsNullOrEmpty(txtUserID.Text.Trim()))
            //    {
            //        MessageBox.Show(this, "No Record to Edit!", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            //        return;
            //    }
            //    MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Edit);
            //    IsEnable(true);
            //}
        }
        private void Cancel()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Cancel this Transaction?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                txtboxClear();
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Cancel);
                IsEnable(false);
            }
        }
        private void Search()
        {
            SqlConnection con = new SqlConnection(Global.ConnectionString);
            frmLOV frm = new frmLOV();
            frm.SetData(con, Global.ConnectionString, "SELECT * FROM Inventory_Category WITH(NOLOCK)", "CatID");
            frm.FormClosing += (o, a) =>
            {
                con.Open();
                var frmKey = o as frmLOV;
                string code = frmKey.Code;
                if (string.IsNullOrEmpty(code))
                {
                    return;
                }
                string query = "SELECT * FROM Inventory_Category WITH(NOLOCK) WHERE CatID = @Code";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Code", code);
                SqlDataReader reader = cmd.ExecuteReader();
                dtCategory.Rows.Clear();
                dtCategory.Load(reader);
                con.Close();

                if (dtCategory.Rows.Count > 0)
                {
                    DataRow row = dtCategory.Rows[0];
                    txtUserID.Text = row["CatID"].ToString();
                    txtUserName.Text = row["CatName"].ToString();
                }
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
            };
            frm.ShowDialog();
        }
        private void New()
        {
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.New);
            txtboxClear();
            IsEnable(true);
        }
        private void txtboxClear()
        {
            txtUserID.Text = string.Empty;
            txtUserName.Text = string.Empty;
        }
        private void IsEnable(bool cond)
        {
            txtUserID.Enabled = cond;
            txtUserName.Enabled = cond;
            txtPass.Enabled = cond;
            txtConPass.Enabled = cond;
            chkActive.Enabled = cond;
        }


        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private string HashPassword(string password, byte[] saltBytes)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000))
            {
                byte[] hashBytes = pbkdf2.GetBytes(20);
                return Convert.ToBase64String(hashBytes);
            }
        }


        #endregion

        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserID.Text.Trim()))
            {
                Insert();
            }
            else
            {
                Update();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}

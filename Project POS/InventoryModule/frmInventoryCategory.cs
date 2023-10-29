using Project_POS.Classes;
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

namespace Project_POS.InventoryModule
{
    public partial class frmInventoryCategory : Form
    {
        public frmInventoryCategory()
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
                    if (string.IsNullOrEmpty(txtCatName.Text)) { MessageBox.Show(this, "Enter Category Name !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }
                    txtCatID.Text = Convert.ToString(SqlQuery.GetTransNo(con, tran, Global.ConnectionString, "Inventory_Category", "CatID"));
                    SqlQuery.Insert(con, tran, "Inventory_Category", Global.ConnectionString, new Dictionary<string, object> { { "CatID", txtCatID.Text }, { "CatName", txtCatName.Text } });
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
                        if (string.IsNullOrEmpty(txtCatName.Text)) { MessageBox.Show(this, "Enter Category Name !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }
                        SqlQuery.Update(con, tran, Global.ConnectionString, "Inventory_Category", $"WHERE CatID = {txtCatID.Text} ", new Dictionary<string, object> { { "CatName", txtCatName.Text } });
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
            if (string.IsNullOrEmpty(txtCatID.Text.Trim())) { MessageBox.Show(this, "No Record to Delete !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }

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
                                SqlQuery.Delete(con, tran, Global.ConnectionString, "Inventory_Category", $" CatID = '{txtCatID.Text}'");
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
            if (SqlQuery.IsFound(con, tran, Global.ConnectionString, "Inventory_Products", $"CatID = {txtCatID.Text}"))
            {
                MessageBox.Show(this, "Category Used in Product !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false;
            }
            else if (SqlQuery.IsFound(con, tran, Global.ConnectionString, "Inventory_Items", $"CatID = {txtCatID.Text}"))
            {
                MessageBox.Show(this, "Category Used in Items !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false;
            }
            return true;

        }
        private void Edit()
        {
            if (BeforeUpdateDelete())
            {
                if (string.IsNullOrEmpty(txtCatID.Text.Trim()))
                {
                    MessageBox.Show(this, "No Record to Edit!", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Edit);
                IsEnable(true);
            }
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
                    txtCatID.Text = row["CatID"].ToString();
                    txtCatName.Text = row["CatName"].ToString();
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
            txtCatID.Text = string.Empty;
            txtCatName.Text = string.Empty;
        }
        private void IsEnable(bool cond)
        {
            grpMain.Enabled = cond;
        }

        #endregion

        private void frmInventoryCategory_Load(object sender, EventArgs e)
        {
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
            txtboxClear();
            IsEnable(false);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtCatID.Text.Trim()))
            {
                MessageBox.Show(this, "No Record To Edit !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
            }
            else
            {
                IsEnable(true);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCatID.Text.Trim()))
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string reprotPath = string.Empty;
            reprotPath = Global.InventoryReportPath + @"rptInventoryCategory.rdlc";
            Dictionary<string, string> dicParm = new Dictionary<string, string>();
            Dictionary<string, DataTable> dataSets = new Dictionary<string, DataTable>();

            dicParm.Add("pmrCatID", txtCatID.Text);
            dicParm.Add("pmrCatName", txtCatName.Text);
            dicParm.Add("pmrReportName", "Inventory Category Report");

            //dataSets.Add("DataSet1", dtCategory);
            frmReportVeiwer frmReport = new frmReportVeiwer(reprotPath, dataSets, dicParm);
            frmReport.Text = "Inventory Category";
            frmReport.Show();
        }
    }
    
}

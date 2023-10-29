using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_POS.Classes
{
    public static class SqlQuery
    {
        public static void Insert(SqlConnection con, SqlTransaction tran, string TableName, string ConnectionString, Dictionary<string, object> LstValues)
        {
            try
            {
                string columns = string.Join(",", LstValues.Keys);
                string values = string.Join(",", LstValues.Keys.Select(v => "@" + v.ToString()));
                string query = $"INSERT INTO {TableName} ({columns}) VALUES({values})";
                SqlCommand cmd = new SqlCommand(query, con, tran);
                foreach (var kvp in LstValues)
                {
                    cmd.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


        public static void Update(SqlConnection con, SqlTransaction tran, string ConnectionString, string TableName, string UpdateCondition = "", Dictionary<string, object> lstCondFields = null)
        {
            try
            {
                string setClause = string.Join(",", lstCondFields.Select(kv => $"{kv.Key} = @{kv.Key}"));
                string query = $"UPDATE {TableName} SET {setClause} {UpdateCondition}";
                SqlCommand cmd = new SqlCommand(query, con, tran);
                foreach (var kvp in lstCondFields)
                {
                    cmd.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


        public static void Delete(SqlConnection con, SqlTransaction tran, string ConnectionString, string TableName, string DeleteCondtion = "")
        {
            try
            {
                string query = $"DELETE FROM {TableName} WHERE  {DeleteCondtion}";
                SqlCommand cmd = new SqlCommand(query, con, tran);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

        public static long GetTransNo(SqlConnection con, SqlTransaction tran, string ConnectionString, string TableName, string ColName/*, int Length = 1*/)
        {
            try
            {
                using (con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    string Query = $"SELECT COALESCE(MAX({ColName}), 0) + 1 AS TransNo FROM {TableName} ";
                    SqlCommand cmd = new SqlCommand(Query, con, tran);
                    long TransNo = Convert.ToInt64(cmd.ExecuteScalar());
                    tran.Commit();
                    con.Dispose();
                    con.Close();
                    return TransNo;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public static Int64 GetTransNo(SqlConnection con, SqlTransaction tran, string ConnectionString, string TableName, string ColName, int Length)
        {
            try
            {
                string FormatStr = string.Empty;
                using (con = new SqlConnection(ConnectionString))
                {
                    for (int i = 1; i <= Length; i++) { FormatStr += "0"; }
                    con.Open();
                    tran = con.BeginTransaction();
                    string Query = $"SELECT CASE WHEN MAX({ColName}) + 1 < 10000 THEN RIGHT('{FormatStr}' + CAST(MAX({ColName}) + 1 AS VARCHAR({Length})), {Length}) ELSE CAST(MAX({ColName}) + 1 AS VARCHAR(10)) END AS NewBillNo FROM {TableName} ";
                    string lastTwoYearDigits = DateTime.Now.ToString("yy");
                    string lastTwoMonthDigits = DateTime.Now.ToString("MM");
                    SqlCommand cmd = new SqlCommand(Query, con, tran);
                    Int64 Value = Convert.ToInt64(cmd.ExecuteScalar());
                    Int64 TransNo = Convert.ToInt64($"{lastTwoYearDigits}{lastTwoMonthDigits}-{Value}");
                    tran.Commit();
                    con.Dispose();
                    con.Close();
                    return TransNo;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public static string GetNewTransNo()
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                int year = currentDate.Year;
                int month = currentDate.Month;
                int day = currentDate.Day;
                string formattedDate = string.Format("{0:D2}{1:D2}{2:D3}", year % 100, month, day);
                Random random = new Random();
                int randomNumber = random.Next(1000000, 10000000);
                string primaryKeyValue = string.Format("{0}-{1}", formattedDate, randomNumber);
                return primaryKeyValue;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public static DataTable Read(SqlConnection con, SqlTransaction tran, string ConnectionString, string query)
        {
            try
            {
                using (con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    DataTable dtRead = new DataTable();
                    SqlCommand cmd = new SqlCommand(query, con, tran);
                    var reader = cmd.ExecuteReader();
                    dtRead.Load(reader);
                    tran.Commit();
                    con.Dispose();
                    con.Close();
                    return dtRead;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public static bool IsFound(SqlConnection con, SqlTransaction tran, string ConnectionString, string TableName, string Condition)
        {
            try
            {

                using (con = new SqlConnection(ConnectionString))
                {
                    bool cond;
                    string query = $"SELECT Top 1 * FROM {TableName} WITH(NOLOCK) WHERE {Condition}";
                    con.Open();
                    tran = con.BeginTransaction();
                    DataTable dtRead = new DataTable();
                    SqlCommand cmd = new SqlCommand(query, con, tran);
                    var reader = cmd.ExecuteReader();
                    dtRead.Load(reader);
                    tran.Commit();
                    con.Dispose();
                    con.Close();
                    if (dtRead.Rows.Count > 0) { cond = true; }
                    else { cond = false; }
                    return cond;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public static string GetSingleValue(SqlConnection con, SqlTransaction tran, string ConnectionString, string Query)
        {
            try
            {
                string value = string.Empty;
                using (con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    SqlCommand cmd = new SqlCommand(Query, con, tran);
                    value = Convert.ToString(cmd.ExecuteScalar());
                    tran.Commit();
                    con.Dispose();
                    con.Close();
                    return value;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public static void ExecuteNonQuery(SqlConnection con, SqlTransaction tran, string ConnectionString, string Query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(Query, con, tran);
                cmd.ExecuteScalar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public static void ExecuteNonQuery(string ConnectionString, string Query)
        {
            SqlConnection con; SqlTransaction tran;
            try
            {
                using (con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    SqlCommand cmd = new SqlCommand(Query, con, tran);
                    cmd.ExecuteScalar();
                    tran.Commit();
                    con.Dispose();
                    con.Close();
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}

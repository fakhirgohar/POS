using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_POS.Classes
{
    public static class Global
    {

        //"Data Source=SKYTERNE\SQLEXPRESS;Initial Catalog=Testing;Integrated Security=True"   H
        //"Data Source=DESKTOP-TC3F7UH;Initial Catalog=Testing;Integrated Security=True" S


        public static string ConnectionString = "Data Source=DESKTOP-TC3F7UH;Initial Catalog=Testing;Integrated Security=True";
        public static SqlConnection Con = new SqlConnection();
        public static SqlTransaction tran;
        public static string InventoryReportPath = @"InventoryModule\Reports\";
        public static string PurchaseReportPath = @"Inventory Reports ";

    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlBanDoAnNhanh
{
    internal class Truyxuatcsdl
    {
        private static string duongdan = "Data Source=.\\AnhDuc;Initial Catalog=qlbandoan;Integrated Security=True";
        public static SqlConnection taoketnoi()
        {
            return new SqlConnection(duongdan);
        }

        public static int themsuaxoa(string sql)
        {
            SqlConnection con = taoketnoi();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            int count = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return count;
        }
        public static int getInt(string sql)
        {
            SqlConnection con = taoketnoi();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            object result = cmd.ExecuteScalar();
            con.Close();
            cmd.Dispose();

            
            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }
            else
            {
                
                return 0;
            }
        }
        public static DataTable get_tt(string sql)
        {
            SqlConnection con = Truyxuatcsdl.taoketnoi();
            con.Open();
            SqlDataAdapter adt = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            adt.Fill(table);
            adt.Dispose();
            con.Close();
            return table;
        }

        
    }
}

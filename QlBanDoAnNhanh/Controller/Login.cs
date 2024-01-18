using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlBanDoAnNhanh.Controller
{
    public class Login
    {
        public static int check = 0;
        public static int manv;
        public static void kt_login(string tendangnhap, string password)
        {
            try
            {
                SqlConnection ketnoi = Truyxuatcsdl.taoketnoi();
                ketnoi.Open();
                string sql = $"SELECT COUNT(tendangnhap) FROM DangNhap WHERE tendangnhap = '{tendangnhap}' AND password = '{password}'";
                string sql1 = $"SELECT id FROM ChucVu WHERE id = (SELECT idCv FROM NhanVien WHERE id = (SELECT idUser FROM DangNhap WHERE tendangnhap = '{tendangnhap}'))";

                SqlCommand cmd = new SqlCommand(sql, ketnoi);
                int count = (int)cmd.ExecuteScalar();
                if (count>0)
                {
                    string sqlget_manv = $"select idUser from DangNhap where tendangnhap = '{tendangnhap}'";
                    DataTable table = Truyxuatcsdl.get_tt(sqlget_manv);
                    DataRow dr = table.Rows[0];
                    string macv = Truyxuatcsdl.get_tt(sql1).Rows[0][0].ToString();
                    manv = Convert.ToInt32(dr["idUser"]);

                    if (macv == "1")
                    {
                        check = 1;

                    }
                    else if (macv == "2")
                    {
                        check = 2;
                    }

                }
                else
                {
                    MessageBox.Show("ĐĂNG NHẬP THẤT BẠI");
                    check = 0;
                }
                ketnoi.Close();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối"+ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}

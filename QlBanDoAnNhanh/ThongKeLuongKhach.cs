using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlBanDoAnNhanh
{
    public partial class ThongKeLuongKhach : Form
    {
        public ThongKeLuongKhach()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string formattedDate = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
            string sql = $"select sum(slkhach) from HoaDonBan where ngayban = '{formattedDate}' ";
            int soluong = Truyxuatcsdl.getInt(sql);
            txtLuongKhach.Text = soluong.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int thang, nam;
            if(txtNam.Text == "")
            {
                if(txtThang.Text=="" || !int.TryParse(txtThang.Text,out thang))
                {
                    MessageBox.Show("Vui lòng xem lại dữ liệu cần tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string sql = $"select sum(slkhach) from HoaDonBan where Month(ngayban)={thang} ";
                    int soluong = Truyxuatcsdl.getInt(sql);
                    txtLuongKhach.Text = soluong.ToString();
                }
            }
            else
            {
                if (!int.TryParse(txtNam.Text, out nam))
                {
                    MessageBox.Show("Vui lòng xem lại dữ liệu cần tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtThang.Text == "" || !int.TryParse(txtThang.Text, out thang))
                    {
                        string sql = $"select sum(slkhach) from HoaDonBan where Year(ngayban)={nam} ";
                        int soluong = Truyxuatcsdl.getInt(sql);
                        txtLuongKhach.Text = soluong.ToString();
                    }
                    else
                    {
                        string sql = $"select sum(slkhach) from HoaDonBan where Month(ngayban)={thang} and Year(ngayban)={nam} ";
                        int soluong = Truyxuatcsdl.getInt(sql);
                        txtLuongKhach.Text = soluong.ToString();
                    }
                }
            }
        }
    }
}

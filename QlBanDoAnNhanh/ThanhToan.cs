using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QlBanDoAnNhanh
{
    public partial class ThanhToan : Form
    {
        private int manv;
        private bool check =false;
        public ThanhToan(int manv)
        {
            InitializeComponent();
            this.manv = manv;
           
        }
        public void get_tt()
        {
            string sql = $"select id,ngayban,chietkhau,slkhach,tongtien from HoaDonBan";
            dataGridView1.DataSource=Truyxuatcsdl.get_tt(sql);
        }
        private void ThanhToan_Load(object sender, EventArgs e)
        {
            string sql1 = "select  id,tenban from Ban";
            cboBan.Items.Add("Chọn bàn");
            cboBan.SelectedIndex = 0;
            foreach (DataRow row in Truyxuatcsdl.get_tt(sql1).Rows)
            {
                cboBan.Items.Add(row["id"].ToString() + "-" + row["tenban"].ToString());
            }
            get_tt();
        }

        private void cboBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBan.SelectedIndex != 0)
            {
                int index = cboBan.Text.IndexOf("-"); // Tìm vị trí của dấu cách đầu tiên
                int maban = int.Parse(cboBan.Text.Substring(0, index));
                string sql = $"select tinhtrang from Ban where id = {maban}";
                if (Truyxuatcsdl.get_tt(sql).Rows[0]["tinhtrang"].ToString() == "Trống")
                {
                    txtTinhTrang.Text = "Trống";
                    check = true;
                    DataTable dataTable = (DataTable)dgvChiTiet.DataSource;
                    if (dgvChiTiet.Rows.Count > 0)
                    {
                        dataTable.Rows.Clear();
                    }
                    txtTongTien.Text = "";
                    txtThanhTien.Text = "";
                }
                else
                {
                    check = false;
                    txtTinhTrang.Text = "Có người/Chờ thanh toán";
                    try
                    {
                        string sql1 = $"select Menu.id,Menu.tenmon,ChiTietHoaDon.slban,Menu.gia from ChiTietHoaDon inner join Menu on ChiTietHoaDon.idMonAn= Menu.id where ChiTietHoaDon.idHoaDon = (select max(HoaDonBan.id) from HoaDonBan inner join Ban on HoaDonBan.idBan=Ban.id where HoaDonBan.idBan = {maban}); ";
                        dgvChiTiet.DataSource = Truyxuatcsdl.get_tt(sql1);
                        txtTongTien.Text = tongtien().ToString();
                        txtThanhTien.Text = thanhtien(0).ToString();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm thất bại!" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
        }
        public long tongtien()
        {
            long tong = 0;
            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                if (!row.IsNewRow)
                {
                    int sl = int.Parse(row.Cells["slban"].Value.ToString());
                    long dongia = long.Parse(row.Cells["gia"].Value.ToString());
                    tong += tinh(sl, dongia);
                }
            }
            return tong;
        }
        public double thanhtien(int chietkhau)
        {
            double tong = int.Parse(txtTongTien.Text);
            tong = tong * ((100 - chietkhau) * 0.01);
            return tong;
        }
        private static long tinh(int soluong, long dongia)
        {
            long tong;
            tong = (long)(soluong * dongia );
            return tong;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            
            if(cboBan.SelectedIndex== 0)
            {
                MessageBox.Show("Vui lòng chọn bàn cần thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int index = cboBan.Text.IndexOf("-"); // Tìm vị trí của dấu cách đầu tiên
                int maban = int.Parse(cboBan.Text.Substring(0, index));
                int slkhach;
                DateTime ngayban = DateTime.Now;
                
                int chietkhau;
                if (check)
                {
                    MessageBox.Show("Bàn này hiện không có hóa đơn cần thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    long thanhtien = long.Parse(txtThanhTien.Text);
                    if (!int.TryParse(txtSlKhach.Text, out slkhach))
                    {
                        MessageBox.Show("Vui lòng xem lại số lượng khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else if (!int.TryParse(txtChietkhau.Text, out chietkhau))
                    {
                        MessageBox.Show("Vui lòng xem lại chiết khấu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            string ngay = ngayban.Date.ToString("yyyy - MM - dd");
                            string sql = $"update HoaDonBan set trangthai = N'Đã thanh toán', ngayban = '{ngay}',tongtien = {thanhtien} ,slkhach = {slkhach} , chietkhau = {chietkhau} where id = (select max(HoaDonBan.id) from HoaDonBan inner join Ban on HoaDonBan.idBan=Ban.id where HoaDonBan.idBan = {maban})";
                            string sql1 = $"update Ban set tinhtrang = N'Trống' where id = {maban}";
                            Truyxuatcsdl.themsuaxoa(sql);
                            Truyxuatcsdl.themsuaxoa(sql1);
                            txtTongTien.Text = "";
                            txtThanhTien.Text = "";
                            txtChietkhau.Text = "0";
                            txtTinhTrang.Text = "";
                            txtSlKhach.Text = "";
                            cboBan.SelectedIndex = 0;
                            DataTable dataTable = (DataTable)dgvChiTiet.DataSource;
                            dataTable.Rows.Clear();
                            MessageBox.Show("Thanh toán thanh công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            check = true;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Sửa thất bại!" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                       

                    }
                }
            }
            get_tt();
        }

        private void txtChietkhau_TextChanged(object sender, EventArgs e)
        {
            int chietkhau;
            if(!int.TryParse(txtChietkhau.Text, out chietkhau))
            {
                MessageBox.Show("Vui lòng nhập số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                txtThanhTien.Text = thanhtien(chietkhau).ToString();
            }
        }
    }
}

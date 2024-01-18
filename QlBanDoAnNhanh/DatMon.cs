using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QlBanDoAnNhanh
{
    public partial class DatMon : Form
    {
        private int manv;
        private int id;
        private bool chkCellClick=false;
        private long tong = 0;
        private int checkban = 0;
        
        public DatMon(int manv)
        {
            InitializeComponent();
            this.manv = manv;
        }

        private void DatMon_Load(object sender, EventArgs e)
        {                                  
            txtManv.Text = this.manv.ToString();
            string sql1 = "select  id,hoten from KhachHang";
            string sql2 = "select  id,tenban from Ban";
            cboKh.Items.Add("Chọn khách hàng");
            cboKh.SelectedIndex = 0;
            foreach (DataRow row in Truyxuatcsdl.get_tt(sql1).Rows)
            {
                cboKh.Items.Add(row["id"].ToString() + "-" + row["hoten"].ToString());
            }
            cboBan.Items.Add("Chọn bàn");
            cboBan.SelectedIndex = 0;
            foreach (DataRow row in Truyxuatcsdl.get_tt(sql2).Rows)
            {
                cboBan.Items.Add(row["id"].ToString() + "-" + row["tenban"].ToString());
            }
            string sql3 = $"select id,tenmon,gia,soluong,dvt,ghichu from Menu";
            dgvMenu.DataSource = Truyxuatcsdl.get_tt(sql3);
            
        }

        private void dgvMenu_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvMenu.Rows[e.RowIndex].Cells["Column1"].Value = e.RowIndex + 1;
        }

        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                chkCellClick = true;
                txtMon.Text = dgvMenu.CurrentRow.Cells["dataGridViewTextBoxColumn3"].Value.ToString();
                txtDongia.Text = dgvMenu.CurrentRow.Cells["dataGridViewTextBoxColumn4"].Value.ToString();
                id = int.Parse(dgvMenu.CurrentRow.Cells["dataGridViewTextBoxColumn2"].Value.ToString());
                btnThemvaohoadon.Visible = true;
                btnTaomoi.Visible = true;
                btnSua.Visible = false;
                btnXoa.Visible = false;
            }
        }

        private void btnTaomoi_Click(object sender, EventArgs e)
        {
            txtMon.Text = "";
            txtDongia.Text = "";
            txtSoluong.Text = "";
        }
        private static long thanhtien(int soluong, long dongia)
        {
            long tong;
            tong = (long)(soluong * dongia );
            return tong;
        }

        private void btnThemvaohoadon_Click(object sender, EventArgs e)
        {
            if (checkban == 0)
            {
                MessageBox.Show("Vui lòng lựa chọn bàn cần thêm món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (chkCellClick)
                {

                    int soluong;
                    if (!int.TryParse(txtSoluong.Text, out soluong))
                    {
                        MessageBox.Show("Vui lòng nhâp lại số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }else if (checkSoLuong(soluong))
                    {
                        MessageBox.Show("Số lượng trong kho không đủ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int index = cboBan.Text.IndexOf("-");
                        int maban = int.Parse(cboBan.Text.Substring(0, index));
                        if (checkban == 1)
                        {

                            string sql;
                            if (cboKh.SelectedIndex != 0)
                            {
                                int index1 = cboKh.Text.IndexOf("-");
                                int makh = int.Parse(cboKh.Text.Substring(0, index1));
                                sql = $"insert into HoaDonBan(trangthai,idBan,idKh,idNv)" +
                               $"values(N'Chờ thanh toán',{maban},{makh},{manv})";


                            }
                            else
                            {
                                sql = $"insert into HoaDonBan(trangthai,idBan,idNv)" +
                               $"values(N'Chờ thanh toán',{maban},{manv})";
                            }

                            try
                            {
                                int count = Truyxuatcsdl.themsuaxoa(sql);

                                if (count > 0)
                                {
                                    checkban = 2;
                                    string sqlupdate = $"update Ban set tinhtrang = N'Có người' where id = {maban}";
                                    Truyxuatcsdl.themsuaxoa(sqlupdate);



                                }



                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Thêm thất bại!" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }


                            /*string[] row = new string[] { demrow.ToString(), id.ToString(), txtMon.Text, txtSoluong.Text, txtDongia.Text, txtChietkhau.Text };

                            //dtctpn.Rows.Add(txtTenhang.Text, txtDongia.Text, txtSoluong.Text, txtChietkhau.Text, mt);
                            // dgvChitietnhaphang.DataSource = dtctpn;
                            dgvChiTiet.Rows.Add(row);
                            tong = tong + thanhtien(soluong, long.Parse(txtDongia.Text), chietkhau);
                            txtThanhTien.Text = tong.ToString();
                            btnTaomoi_Click(sender, e);*/
                        }
                        string sql1;
                        if (checktrung(id))
                        {
                            
                            sql1 = $"update ChiTietHoaDon set slban = slban+{soluong} from ChiTietHoaDon inner join HoaDonBan on ChiTietHoaDon.idHoaDon = HoaDonBan.id WHERE HoaDonBan.trangthai=N'Chờ thanh toán' and HoaDonBan.idBan = {maban} and ChiTietHoaDon.idMonAn={id}";
                        }
                        else
                        {
                            sql1 = $"insert into ChiTietHoaDon(idHoaDon,idMonAn,slban) values((select max(HoaDonBan.id) from HoaDonBan inner join Ban on HoaDonBan.idBan=Ban.id where HoaDonBan.idBan = {maban}),{id},{soluong}) ";
                        }
                        

                        try
                        {
                            Truyxuatcsdl.themsuaxoa(sql1);
                            string sql2 = $"update Menu set soluong=soluong-{soluong} where id = {id}";
                            Truyxuatcsdl.themsuaxoa(sql2);
                            btnTaomoi_Click(sender, e);
                            chkCellClick = false;
                            string sql3 = $"select Menu.id,Menu.tenmon,ChiTietHoaDon.slban,Menu.gia from ChiTietHoaDon inner join Menu on ChiTietHoaDon.idMonAn= Menu.id where ChiTietHoaDon.idHoaDon = (select max(HoaDonBan.id) from HoaDonBan inner join Ban on HoaDonBan.idBan=Ban.id where HoaDonBan.idBan = {maban}); ";
                            dgvChiTiet.DataSource = Truyxuatcsdl.get_tt(sql3);
                            string sql4 = $"select id,tenmon,gia,soluong,dvt,ghichu from Menu";
                            dgvMenu.DataSource = Truyxuatcsdl.get_tt(sql4);
                            txtThanhTien.Text = tongtien().ToString();
                            DialogResult result1 = MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Thêm thất bại!" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }


                    }



                }
                else
                {
                    MessageBox.Show("Vui lòng lựa chọn món ăn cần thêm trên bảng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
           
            
        }

        private void dgvChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvChiTiet_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvChiTiet.Rows[e.RowIndex].Cells["Stt"].Value = e.RowIndex + 1;
        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                chkCellClick = true;
                txtMon.Text = dgvChiTiet.CurrentRow.Cells["tenmon"].Value.ToString();
                txtDongia.Text = dgvChiTiet.CurrentRow.Cells["gia"].Value.ToString();
                txtSoluong.Text = dgvChiTiet.CurrentRow.Cells["slban"].Value.ToString();
                id = int.Parse(dgvChiTiet.CurrentRow.Cells["mamonan"].Value.ToString());
                btnThemvaohoadon.Visible = false;
                btnTaomoi.Visible = false;
                btnSua.Visible = true;
                btnXoa.Visible = true;

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int index = cboBan.Text.IndexOf("-");
            int maban = int.Parse(cboBan.Text.Substring(0, index));
            int soluong;
            if (!int.TryParse(txtSoluong.Text, out soluong))
            {
                MessageBox.Show("Vui lòng nhâp lại số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                try
                {
                    string sql1 = $"select ChiTietHoaDon.slban from ChiTietHoaDon inner join HoaDonBan on ChiTietHoaDon.idHoaDon = HoaDonBan.id WHERE HoaDonBan.trangthai=N'Chờ thanh toán' and HoaDonBan.idBan = {maban} and ChiTietHoaDon.idMonAn={id}";

                    int soluongtruoc = Truyxuatcsdl.getInt(sql1);

                    string sql = $"update ChiTietHoaDon set slban = {soluong} from ChiTietHoaDon inner join HoaDonBan on ChiTietHoaDon.idHoaDon = HoaDonBan.id WHERE HoaDonBan.trangthai=N'Chờ thanh toán' and HoaDonBan.idBan = {maban} and ChiTietHoaDon.idMonAn={id};";
                    Truyxuatcsdl.themsuaxoa(sql);

                    string sql3;
                    if (soluongtruoc >= soluong)
                    {
                         sql3 = $"update Menu set soluong=soluong+{soluongtruoc- soluong} where id = {id}";
                    }
                    else
                    {
                        sql3 = $"update Menu set soluong=soluong-{soluong - soluongtruoc} where id = {id}";
                    }
                    Truyxuatcsdl.themsuaxoa(sql3);
                    string sql4 = $"select id,tenmon,gia,soluong,dvt,ghichu from Menu";
                    dgvMenu.DataSource = Truyxuatcsdl.get_tt(sql4);
                    btnThemvaohoadon.Visible = true;
                    btnTaomoi.Visible = true;
                    btnSua.Visible = false;
                    btnXoa.Visible = false;
                    btnTaomoi_Click(sender, e);
                    chkCellClick = false;
                    string sql2 = $"select Menu.id,Menu.tenmon,ChiTietHoaDon.slban,Menu.gia from ChiTietHoaDon inner join Menu on ChiTietHoaDon.idMonAn= Menu.id where ChiTietHoaDon.idHoaDon = (select max(HoaDonBan.id) from HoaDonBan inner join Ban on HoaDonBan.idBan=Ban.id where HoaDonBan.idBan = {maban}); ";
                    dgvChiTiet.DataSource = Truyxuatcsdl.get_tt(sql2);
                    txtThanhTien.Text = tongtien().ToString();
                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sửa thất bại!" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    tong += thanhtien(sl, dongia);
                }
            }
            return tong;
        }
        public bool checktrung(int id)
        {
            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                if (!row.IsNewRow)
                {
                    int mamonan = int.Parse(row.Cells["mamonan"].Value.ToString());
                    if (mamonan == id)
                    {
                        return true;
                    }
                    
                }
            }
            return false;
        }
        public bool checkSoLuong(int sl)
        {
            string sql = $"select soluong from Menu where id={id}";
            if (Truyxuatcsdl.getInt(sql) < sl)
            {
                return true;
            }
            return false;
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
                    checkban = 1;
                    txtTinhTrang.Text = "Trống";
                    DataTable dataTable = (DataTable)dgvChiTiet.DataSource;
                    if (dgvChiTiet.Rows.Count > 0)
                    {
                        dataTable.Rows.Clear();
                    }
                }
                else
                {
                    checkban = 2 ;
                    txtTinhTrang.Text = "Có người";
                    try
                    {
                        string sql1 = $"select Menu.id,Menu.tenmon,ChiTietHoaDon.slban,Menu.gia from ChiTietHoaDon inner join Menu on ChiTietHoaDon.idMonAn= Menu.id where ChiTietHoaDon.idHoaDon = (select max(HoaDonBan.id) from HoaDonBan inner join Ban on HoaDonBan.idBan=Ban.id where HoaDonBan.idBan = {maban}); ";
                        dgvChiTiet.DataSource = Truyxuatcsdl.get_tt(sql1);
                        txtThanhTien.Text = tongtien().ToString();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm thất bại!" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
                chkCellClick = false;
                btnTaomoi_Click(sender, e);
            }
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int index = cboBan.Text.IndexOf("-");
            int maban = int.Parse(cboBan.Text.Substring(0, index));
            try
            {
                string sql1 = $"select ChiTietHoaDon.slban from ChiTietHoaDon inner join HoaDonBan on ChiTietHoaDon.idHoaDon = HoaDonBan.id WHERE HoaDonBan.trangthai=N'Chờ thanh toán' and HoaDonBan.idBan = {maban} and ChiTietHoaDon.idMonAn={id}";
                int soluongtruoc = Truyxuatcsdl.getInt(sql1);


                string sql = $"DELETE cthd FROM ChiTietHoaDon AS cthd " +
                     $"INNER JOIN HoaDonBan AS hdb ON cthd.idHoaDon = hdb.id " +
                    $"WHERE hdb.trangthai = N'Chờ thanh toán' AND hdb.idBan = {maban} AND cthd.idMonAn = {id}";
    
                Truyxuatcsdl.themsuaxoa(sql);

                string sql3 = $"update Menu set soluong=soluong+{soluongtruoc} where id = {id}";
                Truyxuatcsdl.themsuaxoa(sql3);
                btnThemvaohoadon.Visible = true;
                btnTaomoi.Visible = true;
                btnSua.Visible = false;
                btnXoa.Visible = false;
                btnTaomoi_Click(sender, e);
                chkCellClick = false;
                string sql2 = $"select Menu.id,Menu.tenmon,ChiTietHoaDon.slban,Menu.gia from ChiTietHoaDon inner join Menu on ChiTietHoaDon.idMonAn= Menu.id where ChiTietHoaDon.idHoaDon = (select max(HoaDonBan.id) from HoaDonBan inner join Ban on HoaDonBan.idBan=Ban.id where HoaDonBan.idBan = {maban}); ";
                dgvChiTiet.DataSource = Truyxuatcsdl.get_tt(sql2);
                string sql4 = $"select id,tenmon,gia,soluong,dvt,ghichu from Menu";
                dgvMenu.DataSource = Truyxuatcsdl.get_tt(sql4);
                txtThanhTien.Text = tongtien().ToString();
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại!" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

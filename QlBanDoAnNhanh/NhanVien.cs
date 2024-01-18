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
    public partial class NhanVien : Form
    {
        bool check = false;
        public NhanVien()
        {
            InitializeComponent();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            string sql = "SELECT NhanVien.id, hoten, ChucVu.tencv, ngaysinh, IIF(gioitinh = 1, 'Nam', N'Nữ') AS gioitinh, quequan, sdt, email, ChucVu.id FROM NhanVien INNER JOIN ChucVu ON NhanVien.idCv = ChucVu.id;\r\n";
            dgvTableNhanVien.DataSource = Truyxuatcsdl.get_tt(sql);
            string sql1 = "select id, tencv from ChucVu";
            cboChucVu.Items.Add("Chức vụ");
            cboChucVu.SelectedIndex = 0;
            foreach (DataRow row in Truyxuatcsdl.get_tt(sql1).Rows)
            {
                cboChucVu.Items.Add(row["id"].ToString() + "-" + row["tencv"].ToString());
            }
        }

        private void dgvTableNhanVien_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvTableNhanVien.Rows[e.RowIndex].Cells["Stt"].Value = e.RowIndex + 1;
        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            txtQueQuan.Text = "";
            txtSdt.Text = "";
            txtEmail.Text = "";
            cboChucVu.SelectedIndex = 0;
            cboGioiTinh.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cboChucVu.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtSdt.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm nhân viên ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int index = cboChucVu.Text.IndexOf("-"); // Tìm vị trí của dấu cách đầu tiên
                    int macv = int.Parse(cboChucVu.Text.Substring(0, index));
                    string ngay = dateTimePicker1.Value.Date.ToString("yyyy - MM - dd");
                    string gioiTinh = cboGioiTinh.Text;

                    bool gioitinhDB = gioiTinh.ToLower() == "nam";
                    string sql = $"INSERT INTO NhanVien(idCv, hoten, ngaysinh, gioitinh, quequan, sdt, email)" +
                                 $"VALUES({macv}, N'{txtHoTen.Text}', '{ngay}', '{gioitinhDB}', N'{txtQueQuan.Text}', '{txtSdt.Text}', '{txtEmail.Text}')";

                    try
                    {
                        int count = Truyxuatcsdl.themsuaxoa(sql);
                        if (count > 0)
                        {
                            DialogResult result1 = MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            string sql1 = "SELECT NhanVien.id, hoten, ChucVu.tencv, ngaysinh, IIF(gioitinh = 1, 'Nam', N'Nữ') AS gioitinh, quequan, sdt, email, ChucVu.id FROM NhanVien INNER JOIN ChucVu ON NhanVien.idCv = ChucVu.id;\r\n";
                            dgvTableNhanVien.DataSource = Truyxuatcsdl.get_tt(sql1);
                            if (result1 == DialogResult.OK)
                            {

                                btnClear_Click(sender, e);

                            }
                        }



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm thất bại!" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    txtHoTen.Focus();
                }
            }
        }

        private void dgvTableNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                check = true;
                txtHoTen.Text = dgvTableNhanVien.CurrentRow.Cells["hoten"].Value.ToString();
               // cboChucVu.Text = dgvTbleNhanVien.CurrentRow.Cells["macv"].Value.ToString() + "-" + dgvTableNhanVien.CurrentRow.Cells["chucvu"].Value.ToString();
                txtEmail.Text = dgvTableNhanVien.CurrentRow.Cells["email"].Value.ToString();
                cboGioiTinh.Text = dgvTableNhanVien.CurrentRow.Cells["gioitinh"].Value.ToString();
                txtQueQuan.Text = dgvTableNhanVien.CurrentRow.Cells["quequan"].Value.ToString();
                txtSdt.Text = dgvTableNhanVien.CurrentRow.Cells["sdt"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (check)
            {
                if (txtHoTen.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cboChucVu.SelectedIndex == 0)
                {
                    MessageBox.Show("Vui lòng chọn chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtEmail.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtSdt.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int id = (int)dgvTableNhanVien.CurrentRow.Cells["manhanvien"].Value;
                    int index = cboChucVu.Text.IndexOf("-"); // Tìm vị trí của dấu cách đầu tiên
                    int macv = int.Parse(cboChucVu.Text.Substring(0, index));
                    string ngay = dateTimePicker1.Value.Date.ToString("yyyy - MM - dd");
                    string gioiTinh = cboGioiTinh.Text;
                    bool gioitinhDB = gioiTinh.ToLower() == "nam";

                    string sql = $"UPDATE NhanVien SET idCv = {macv}, hoten = N'{txtHoTen.Text}', ngaysinh = '{ngay}', gioitinh = '{gioitinhDB}', quequan = N'{txtQueQuan.Text}', sdt = '{txtSdt.Text}', email = '{txtEmail.Text}' WHERE id = {id}";

                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin món ăn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            int count = Truyxuatcsdl.themsuaxoa(sql);
                            if (count > 0)
                            {

                                DialogResult result1 = MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                string sql1 = "SELECT NhanVien.id, hoten, ChucVu.tencv, ngaysinh, IIF(gioitinh = 1, 'Nam', N'Nữ') AS gioitinh, quequan, sdt, email, ChucVu.id FROM NhanVien INNER JOIN ChucVu ON NhanVien.idCv = ChucVu.id;\r\n";
                                dgvTableNhanVien.DataSource = Truyxuatcsdl.get_tt(sql1);
                                if (result1 == DialogResult.OK)
                                {

                                    btnClear_Click(sender, e);

                                }
                                check = false;
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Sửa thất bại!" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        txtHoTen.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (check)
            {

                int id = (int)dgvTableNhanVien.CurrentRow.Cells["manhanvien"].Value;
                string sql = $"delete  from NhanVien where id ={id}";
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int count = Truyxuatcsdl.themsuaxoa(sql);
                        if (count > 0)
                        {

                            DialogResult result1 = MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            string sql1 = "select NhanVien.id,hoten,ChucVu.tencv,ngaysinh,gioitinh,quequan,sdt,email,ChucVu.id from NhanVien inner join ChucVu on NhanVien.idCv = ChucVu.id";
                            dgvTableNhanVien.DataSource = Truyxuatcsdl.get_tt(sql1);
                            if (result1 == DialogResult.OK)
                            {

                                btnClear_Click(sender, e);

                            }
                            check = false;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thất bại!" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

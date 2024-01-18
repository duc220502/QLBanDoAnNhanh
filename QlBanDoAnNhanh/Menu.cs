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
    public partial class Menu : Form
    {
        bool check = false;
        public Menu()
        {
            InitializeComponent();
        }
        BindingSource bs = new BindingSource();
        private void Menu_Load(object sender, EventArgs e)
        {
            string sql = "select Menu.id,tenmon,Loaimonan.tenloai,gia,soluong,dvt,ghichu,Loaimonan.id from Menu inner join Loaimonan on Menu.idLoaimonan = Loaimonan.id";
            bs.DataSource = Truyxuatcsdl.get_tt(sql);
            dgvTableMonAn.DataSource = bs;
            string sql1 = "select id, tenloai from loaimonan";
            cboLoai.Items.Add("Loại món ăn");
            cboLoai.SelectedIndex = 0;
            foreach (DataRow row in Truyxuatcsdl.get_tt(sql1).Rows)
            {
                cboLoai.Items.Add(row["id"].ToString()+"-"+row["tenloai"].ToString());
            }
            dgvTableMonAn.ClearSelection();
        }

        private void dgvTablehanghoa_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvTableMonAn.Rows[e.RowIndex].Cells["Stt"].Value = e.RowIndex + 1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMonAn.Text = "";
            cboLoai.SelectedIndex = 0;
            txtGia.Text = "";
            txtSoLuong.Text = "";
            txtDvt.Text = "";
            txtGhiChu.Text = "";
            check = false;
        }

        private void dgvTableMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                check = true;
                txtMonAn.Text = dgvTableMonAn.CurrentRow.Cells["tenmon"].Value.ToString();
                cboLoai.Text = dgvTableMonAn.CurrentRow.Cells["maloai"].Value.ToString()+"-"+dgvTableMonAn.CurrentRow.Cells["tenloai"].Value.ToString();
                txtGia.Text = dgvTableMonAn.CurrentRow.Cells["gia"].Value.ToString();
                txtSoLuong.Text = dgvTableMonAn.CurrentRow.Cells["soluong"].Value.ToString();
                txtDvt.Text = dgvTableMonAn.CurrentRow.Cells["dvt"].Value.ToString();
                txtGhiChu.Text = dgvTableMonAn.CurrentRow.Cells["ghichu"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            long gia;
            int soluong;

            if (txtMonAn.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên món ăn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cboLoai.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn loại món ăn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!long.TryParse(txtGia.Text, out gia) || txtGia.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng xem lại trường giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(txtSoLuong.Text, out soluong) || txtSoLuong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng xem lại trường số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtDvt.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (txtGhiChu.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập ghi chú", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm đồ ăn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int index = cboLoai.Text.IndexOf("-"); // Tìm vị trí của dấu cách đầu tiên
                    int maloai = int.Parse(cboLoai.Text.Substring(0, index));
                    int giatien = int.Parse(txtGia.Text);
                    int sluong = int.Parse(txtSoLuong.Text);
                    string sql = $"insert into Menu(idLoaimonan,tenmon,gia,soluong,dvt,ghichu)" +
                        $"values({maloai},N'{txtMonAn.Text}',{giatien},{sluong},N'{txtDvt.Text}',N'{txtGhiChu.Text}')";

                    try
                    {
                        int count = Truyxuatcsdl.themsuaxoa(sql);
                        if (count > 0)
                        {
                            DialogResult result1 = MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            string sql1 = "select Menu.id,tenmon,Loaimonan.tenloai,gia,soluong,dvt,ghichu,Loaimonan.id from Menu inner join Loaimonan on Menu.idLoaimonan = Loaimonan.id";
                            bs.DataSource = Truyxuatcsdl.get_tt(sql1);
                            dgvTableMonAn.DataSource = bs;

                            if (result1 == DialogResult.OK)
                            {

                                btnClear_Click(sender, e);

                            }
                        }



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm thất bại!"+ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    txtMonAn.Focus();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
            if (check)
            {
                int id = (int)dgvTableMonAn.CurrentRow.Cells["mamonan"].Value;
                long gia;
                int soluong;

                if (txtMonAn.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập tên món ăn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cboLoai.SelectedIndex == 0)
                {
                    MessageBox.Show("Vui lòng chọn loại món ăn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!long.TryParse(txtGia.Text, out gia) || txtGia.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng xem lại trường giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!int.TryParse(txtSoLuong.Text, out soluong) || txtSoLuong.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng xem lại trường số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtDvt.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtGhiChu.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập ghi chú", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int index = cboLoai.Text.IndexOf("-");
                    int maloai = int.Parse(cboLoai.Text.Substring(0, index));
                    int giatien = int.Parse(txtGia.Text);
                    int sluong = int.Parse(txtSoLuong.Text);
                    string sql = $"update Menu set idLoaimonan = {maloai} , tenmon = N'{txtMonAn.Text}',gia = {giatien},soluong = {soluong}," 
                        +$"dvt=N'{txtDvt.Text}',ghichu = N'{txtGhiChu.Text}' where id = {id} ";
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin món ăn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            int count = Truyxuatcsdl.themsuaxoa(sql);
                            if (count > 0)
                            {

                                DialogResult result1 = MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                string sql1 = "select Menu.id,tenmon,Loaimonan.tenloai,gia,soluong,dvt,ghichu,Loaimonan.id from Menu inner join Loaimonan on Menu.idLoaimonan = Loaimonan.id";
                                bs.DataSource = Truyxuatcsdl.get_tt(sql1);
                                dgvTableMonAn.DataSource = bs;
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
                        txtMonAn.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món ăn cần sửa", "Thông báo" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (check)
            {

                int id = (int)dgvTableMonAn.CurrentRow.Cells["mamonan"].Value;
                string sql = $"delete  from Menu where id ={id}";
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int count = Truyxuatcsdl.themsuaxoa(sql);
                        if (count > 0)
                        {

                            DialogResult result1 = MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            string sql1 = "select Menu.id,tenmon,Loaimonan.tenloai,gia,soluong,dvt,ghichu,Loaimonan.id from Menu inner join Loaimonan on Menu.idLoaimonan = Loaimonan.id";
                            bs.DataSource = Truyxuatcsdl.get_tt(sql1);
                            dgvTableMonAn.DataSource = bs;
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
                MessageBox.Show("Vui lòng chọn món ăn cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"select Menu.id,tenmon,Loaimonan.tenloai,gia,soluong,dvt,ghichu,Loaimonan.id from Menu inner join Loaimonan on Menu.idLoaimonan = Loaimonan.id where Menu.tenmon like N'%{txtSearch.Text.Trim()}%'";
            dgvTableMonAn.DataSource = Truyxuatcsdl.get_tt(sql);
        }
    }
}

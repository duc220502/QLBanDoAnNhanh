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
    public partial class DatBan : Form
    {
        public DatBan()
        {
            InitializeComponent();
        }
        bool check=false;
        private void DatBan_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dgvTableDatBan.Columns["thoigian"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            string sql = "select PhieuDatBan.id,tenkhach,sdt,tenban,thoigian,ghichu,Ban.id from PhieuDatBan inner join Ban on PhieuDatBan.idBan = Ban.id";
            dgvTableDatBan.DataSource = Truyxuatcsdl.get_tt(sql);
            string sql1 = "select id, tenban from Ban";
            cboBan.Items.Add("Tên bàn");
            cboBan.SelectedIndex = 0;
            foreach (DataRow row in Truyxuatcsdl.get_tt(sql1).Rows)
            {
                cboBan.Items.Add(row["id"].ToString() + "-" + row["tenban"].ToString());
            }
            dgvTableDatBan.ClearSelection();
        }

        private void dgvTableDatBan_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvTableDatBan.Rows[e.RowIndex].Cells["Stt"].Value = e.RowIndex + 1;
        }

        private void dgvTableDatBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                check = true;
                txtTenKh.Text = dgvTableDatBan.CurrentRow.Cells["tenkhach"].Value.ToString();
                txtSdt.Text = dgvTableDatBan.CurrentRow.Cells["sdt"].Value.ToString();
                cboBan.Text = dgvTableDatBan.CurrentRow.Cells["maban"].Value.ToString()+"-"+ dgvTableDatBan.CurrentRow.Cells["tenban"].Value.ToString();
                txtGhiChu.Text = dgvTableDatBan.CurrentRow.Cells["ghichu"].Value.ToString();
                CultureInfo viCulture = new CultureInfo("vi-VN");
                string tg = dgvTableDatBan.CurrentRow.Cells["thoigian"].Value.ToString();
                if (DateTime.TryParseExact(tg.Trim(), "dd/MM/yyyy h:mm:ss tt", viCulture, DateTimeStyles.None, out DateTime parsedDateTime))
                {
                    dateTimePicker1.Value = parsedDateTime;
                }
                else
                {
                    MessageBox.Show("Lỗi thời gian");
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DateTime ngayGioHienTai = DateTime.Now;
           // double khoangCachGio = (dateTimePicker1.Value - ngayGioHienTai).TotalHours;

            if (txtSdt.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (cboBan.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn cần đặt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }/*
            else if (khoangCachGio > 2)
            {
                MessageBox.Show("Không đặt trước quá 2 ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            else
            {
                
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đặt bàn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int index = cboBan.Text.IndexOf("-");
                    int maban = int.Parse(cboBan.Text.Substring(0, index));
                    DateTime selectedDateTime = dateTimePicker1.Value;
                    string formattedDateTime = selectedDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sql = $"insert into PhieuDatBan(idBan,tenkhach,sdt,thoigian,ghichu)" +
                        $"values({maban},N'{txtTenKh.Text}','{txtSdt.Text}','{formattedDateTime}',N'{txtGhiChu.Text}')";

                    try
                    {
                        int count = Truyxuatcsdl.themsuaxoa(sql);
                        if (count > 0)
                        {
                            DialogResult result1 = MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            string sql1 = "select PhieuDatBan.id,tenkhach,sdt,tenban,thoigian,ghichu,Ban.id from PhieuDatBan inner join Ban on PhieuDatBan.idBan = Ban.id";
                            dgvTableDatBan.DataSource = Truyxuatcsdl.get_tt(sql1);

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
                    txtTenKh.Focus();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenKh.Text = "";
            txtSdt.Text = "";
            txtGhiChu.Text = "";
            cboBan.SelectedIndex = 0;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (check)
            {
                int id = (int)dgvTableDatBan.CurrentRow.Cells["madatban"].Value;
                DateTime ngayGioHienTai = DateTime.Now;
                double khoangCachGio = (dateTimePicker1.Value - ngayGioHienTai).TotalHours;

                if (txtSdt.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cboBan.SelectedIndex == 0)
                {
                    MessageBox.Show("Vui lòng chọn bàn cần đặt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dateTimePicker1.Value < ngayGioHienTai)
                {
                    MessageBox.Show("Thời gian phải lớn hơn thời gian hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               /* else if (khoangCachGio > 2)
                {
                    MessageBox.Show("Không đặt trước quá 2 ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin đặt bàn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int index = cboBan.Text.IndexOf("-");
                        int maban = int.Parse(cboBan.Text.Substring(0, index));
                        DateTime selectedDateTime = dateTimePicker1.Value;
                        string formattedDateTime = selectedDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        string sql = $"update PhieuDatBan set idBan = {maban} , tenkhach = N'{txtTenKh.Text}',sdt = '{txtSdt.Text}',thoigian = '{formattedDateTime}',"
                             + $"ghichu = N'{txtGhiChu.Text}' where id = {id} ";

                        try
                        {
                            int count = Truyxuatcsdl.themsuaxoa(sql);
                            if (count > 0)
                            {
                                DialogResult result1 = MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                string sql1 = "select PhieuDatBan.id,tenkhach,sdt,tenban,thoigian,ghichu,Ban.id from PhieuDatBan inner join Ban on PhieuDatBan.idBan = Ban.id";
                                dgvTableDatBan.DataSource = Truyxuatcsdl.get_tt(sql1);

                                if (result1 == DialogResult.OK)
                                {

                                    btnClear_Click(sender, e);

                                }
                            }



                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Sửa thất bại!" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        txtTenKh.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin đặt bàn cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (check)
            {
                int id = (int)dgvTableDatBan.CurrentRow.Cells["madatban"].Value;
                string sql = $"delete  from PhieuDatBan where id ={id}";
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu đặt bàn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int count = Truyxuatcsdl.themsuaxoa(sql);
                        if (count > 0)
                        {

                            DialogResult result1 = MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            string sql1 = "select PhieuDatBan.id,tenkhach,sdt,tenban,thoigian,ghichu,Ban.id from PhieuDatBan inner join Ban on PhieuDatBan.idBan = Ban.id";
                            dgvTableDatBan.DataSource = Truyxuatcsdl.get_tt(sql1);
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
                MessageBox.Show("Vui lòng chọn thông tin đặt bàn cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = $"select PhieuDatBan.id,tenkhach,sdt,tenban,thoigian,ghichu,Ban.id from PhieuDatBan inner join Ban on PhieuDatBan.idBan = Ban.id where PhieuDatBan.tenkhach like N'%{txtSearch.Text.Trim()}%' or PhieuDatBan.sdt like N'%{txtSearch.Text.Trim()}%'";
            dgvTableDatBan.DataSource = Truyxuatcsdl.get_tt(sql);
        }
    }
}

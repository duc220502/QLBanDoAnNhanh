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
    public partial class ThongKeDoanhThu : Form
    {
        public ThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            string sql1 = "select id, tenmon from Menu";
            cboMon.Items.Add("Tên món");
            cboMon.SelectedIndex = 0;
            foreach (DataRow row in Truyxuatcsdl.get_tt(sql1).Rows)
            {
                cboMon.Items.Add(row["id"].ToString() + "-" + row["tenmon"].ToString());
            }
            cboMon.Text = "Tên món";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string formattedDate = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
            string sql = $"select id,tongtien,idNv,idKh from HoaDonBan where ngayban = '{formattedDate}' ";
            dgvChiTiet.Visible = true;
            dataGridView1.Visible = false;
            dgvChiTiet.DataSource = Truyxuatcsdl.get_tt(sql);


            long tong = 0;
            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                if (!row.IsNewRow)
                {
                   tong += long.Parse(row.Cells["tongtien"].Value.ToString());
                }
            }
            txtTongTien.Text = tong.ToString();
        }

        private void dgvChiTiet_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvChiTiet.Rows[e.RowIndex].Cells["Stt"].Value = e.RowIndex + 1;
        }

        private void cboBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMon.SelectedIndex != 0)
            {
                int index = cboMon.Text.IndexOf("-"); // Tìm vị trí của dấu cách đầu tiên
                int mamon = int.Parse(cboMon.Text.Substring(0, index));
                string sql = $"select Menu.tenmon,sum(slban) as slban,Menu.gia from ChiTietHoaDon inner join Menu on ChiTietHoaDon.idMonAn = Menu.id where ChiTietHoaDon.idMonAn = {mamon} group by tenmon,gia  ";
                dgvChiTiet.Visible = false;
                dataGridView1.Visible = true;
                dataGridView1.DataSource = Truyxuatcsdl.get_tt(sql);
                long tong = 0;
                if (dataGridView1.Rows.Count > 0)
                {
                    int soluong = int.Parse(dataGridView1.Rows[0].Cells["slban"].Value.ToString());
                    long gia = long.Parse(dataGridView1.Rows[0].Cells["gia"].Value.ToString());
                    tong = (long)soluong * gia;
                    
                }
                txtTongTien.Text = tong.ToString();

            }
           
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].Value = e.RowIndex + 1;
        }
    }
}

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
    public partial class Trangchu_nv : Form
    {
        private string tendangnhap;
        private string password;
        private int manv;
        private int macv;
        public Trangchu_nv(string tendangnhap, string password, int manv,int macv)
        {
            InitializeComponent();
            this.tendangnhap = tendangnhap;
            this.password = password;
            this.manv = manv;
            this.macv = macv;
            panel1.Visible = false;
            /*panel1.Visible = false;
            panel2.Visible = false;*/
        }
        private Form currentFormqnvchild;
        private void openchildFormqnv(Form childform)
        {
            panel1.Visible = true;
            if (currentFormqnvchild != null)
            {
                currentFormqnvchild.Close();
            }
            currentFormqnvchild = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panel1.Controls.Add(childform);
            panel1.Tag = childform;
            childform.BringToFront();
            childform.Show();

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel2.Visible = !panel2.Visible;
            if (panel2.Visible == true)
            {
                panel2.BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Trangchu_nv_Load(object sender, EventArgs e)
        {
            lblUsername.Text = tendangnhap;
            if(macv == 1)
            {
                cậpToolStripMenuItem.Enabled = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void cậpNhậtMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
               Menu menu = new Menu();
               openchildFormqnv(menu);
        }

        private void đặtBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatBan datban = new DatBan();
            openchildFormqnv(datban);
        }

        private void đặtMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatMon datban = new DatMon(manv);
            openchildFormqnv(datban);
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan(manv);
            openchildFormqnv(thanhToan);
        }

        private void thốngKêDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeDoanhThu thongKeDoanhThu = new ThongKeDoanhThu();
            openchildFormqnv(thongKeDoanhThu);
        }

        private void thốngKêLượngKháchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeLuongKhach thongKeLuongKhach = new ThongKeLuongKhach();
            openchildFormqnv(thongKeLuongKhach);
;        }

        private void cậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien nhanVien = new NhanVien();
            openchildFormqnv(nhanVien);
        }
    }
}

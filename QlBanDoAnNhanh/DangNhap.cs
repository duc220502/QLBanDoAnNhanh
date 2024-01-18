using QlBanDoAnNhanh.Controller;
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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            txtDangnhap.Select();
        }

        private void txtDangnhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (txtDangnhap.Text.Trim() == "")
            {
                DialogResult result = MessageBox.Show("Vui lòng nhập tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    txtDangnhap.Focus();
                }
            }
            else if (txtPassword.Text.Trim() == "")
            {
                DialogResult result = MessageBox.Show("Vui lòng nhập password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    txtPassword.Focus();
                }
            }
            Login.kt_login(txtDangnhap.Text, txtPassword.Text);

            if (Login.check != 0)
            {
                Trangchu_nv x = new Trangchu_nv(txtDangnhap.Text, txtPassword.Text, Login.manv, Login.check);
                this.Visible = false;
                x.ShowDialog();
                DangNhap dangnhap = new DangNhap();
                dangnhap.Show();
            }
            
           

        }
    }
}

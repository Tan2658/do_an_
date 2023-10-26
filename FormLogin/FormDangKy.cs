using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Data;
using BUS;

namespace FormLogin
{
    public partial class FormDangKy : Form
    {
        private readonly TaiKhoanService taikhoan = new TaiKhoanService();

        public FormDangKy()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Format("Hôm nay là ngày {0} ", DateTime.Now.ToString("dd / MM / yyyy"));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                List<TaiKhoan> ts = taikhoan.GetAll();
                foreach (var item in ts)
                {
                    if (txtAccount.Text == item.TenDangNhap)
                    {
                        throw new Exception("Tài khoản đã tổn tại !!!");
                    }
                }
                if (txtAccount.Text == "" || txtPassword.Text == "")
                {
                    throw new Exception("Yêu cầu nhập các fields đầy đủ !");
                }
                else if (txtPassword.Text.Length > 21 || txtPassword.Text.Length > 10)
                {
                    throw new Exception("Tên tài khoản tối đa chỉ 21 kí tự và mật khẩu tối đa 10 kí tự");
                }
                else
                {
                    TaiKhoan k = new TaiKhoan()
                    {
                        TenDangNhap = txtAccount.Text,
                        MatKhau = txtPassword.Text,
                    };
                    taikhoan.InsertUpdate(k);
                    FormTrangChu frm = new FormTrangChu();
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

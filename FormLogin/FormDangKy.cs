using DAL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLogin
{
    public partial class FormDangKy : Form
    {
        public FormDangKy()
        {
            InitializeComponent();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Format("Hôm nay là ngày {0} ",  DateTime.Now.ToString("dd / MM / yyyy"));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !checkBox1.Checked;
        }
        DentalContextDB context= new DentalContextDB();

        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                List<TaiKhoan> ts = context.TaiKhoans.ToList();
                foreach (var item in ts)
                {
                    if (txtPassword.Text != item.MatKhau && txtAccount.Text != item.TenDangNhap)
                    {
                        MessageBox.Show("Tài khoản và Mật khẩu bạn chưa tổn tại !!!");
                    }
                }
                if (txtAccount.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Yêu cầu nhập các fields đầy đủ !");
                }
                else if (txtPassword.Text.Length>21 ||  txtPassword.Text.Length>10)
                {
                    MessageBox.Show("Tên tài khoản tối đa chỉ 21 kí tự và mật khẩu tối đa 10 kí tự");

                }
                else
                {
                    TaiKhoan k = new TaiKhoan()
                    {
                        TenDangNhap=txtAccount.Text,
                        MatKhau=txtPassword.Text,
                    };
                    context.TaiKhoans.Add(k);
                    context.SaveChanges();
                    FormTrangChu frm = new FormTrangChu(this);
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

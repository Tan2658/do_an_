using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL.Data;

namespace FormLogin
{
    public partial class ForgetPassword : Form
    {
        private readonly TaiKhoanService ts = new TaiKhoanService();
        DentalContextDB context = new DentalContextDB();
        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Bạn có muốn thoát không ?", "Yes / No", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            { 
               this.Close();
            }
        }
        private bool checkData()
        {

            if (txtUsername.Text == "" || txtNewPassword.Text == "")
            {
                return false;

            }
           return true;
        }
        private void clearContent()
        {
            txtUsername.Text = "";
            txtNewPassword.Text = "";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
     
            //try
            //{
            //    List<TaiKhoan> ts = context.TaiKhoans.ToList();
            //    if (checkData())
            //    {
            //        TaiKhoan item = context.TaiKhoans.FirstOrDefault(p => p.TenDangNhap == txtUsername.Text);
            //        item.MatKhau = txtNewPassword.Text;
            //        context.SaveChanges();
            //        clearContent();
            //        MessageBox.Show("Cập nhật mật khẩu thành công", "Thông Báo", MessageBoxButtons.OK);
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }
        private void btnLog_Click(object sender, EventArgs e)
        {
                this.Close();
        }
    }
}

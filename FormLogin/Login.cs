﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Web;
using System.Windows.Forms;
using DAL.Data;

namespace FormLogin
{
    public partial class formLogin : Form
    {
        System.Timers.Timer timer;
        int minute = 2, second;

        DentalContextDB context = new DentalContextDB();
        public formLogin()
        {
            InitializeComponent();
        }
        private void eventCountdown()
        {

            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += OnTimeEvent;
            timer.Start();
        }

        private void txtAccount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAccount_Click(object sender, EventArgs e)
        {
            txtAccount.BackColor = Color.White;
            panelAccount.BackColor = Color.White;
            txtPassword.BackColor = SystemColors.Control;
            panelPas.BackColor = SystemColors.Control;
            timer.Stop();
            minute = 2;
            second = 0;

            // Kiểm tra sự kiện này click thì set time lại 
            eventCountdown();
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
            panelPas.BackColor = Color.White;
            txtAccount.BackColor = SystemColors.Control;
            panelAccount.BackColor = SystemColors.Control;
            timer.Stop();
            minute = 2;
            second = 0;

            // Kiểm tra sự kiện này click thì set time lại 
            eventCountdown();
        }

        private void picAccount_Click(object sender, EventArgs e)
        {
            txtAccount.Focus();
            panelAccount.BackColor = Color.White;
            panelPas.BackColor = SystemColors.Control;
            txtAccount.BackColor = Color.White;
            txtPassword.BackColor = SystemColors.Control;
            timer.Stop();
            minute = 2;
            second = 0;

            // Kiểm tra sự kiện này click thì set time lại 
            eventCountdown();
        }

        private void picLock_Click(object sender, EventArgs e)
        {
            txtPassword.Focus();
            panelPas.BackColor = Color.White;
            panelAccount.BackColor = SystemColors.Control;
            txtPassword.BackColor = Color.White;
            txtAccount.BackColor = SystemColors.Control;
            timer.Stop();
            minute = 2;
            second = 0;

            // Kiểm tra sự kiện này click thì set time lại 
            eventCountdown();
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            
                string newImagePath = "C:\\Users\\Admin\\source\\repos\\DA Nha Khoa\\FormLogin\\Resources\\picture-show.png";
                Image newImage = Image.FromFile(newImagePath);

                pictureBox4.Image = newImage;

                txtPassword.UseSystemPasswordChar = false;     
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            string newImagePath = "C:\\Users\\Admin\\source\\repos\\DA Nha Khoa\\FormLogin\\Resources\\noShowPas.png";

            Image newImage = Image.FromFile(newImagePath);

            pictureBox4.Image = newImage;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    timer.Stop();
            //    List<TaiKhoan> ts  = context.TaiKhoans.ToList();
            //   foreach(var item in ts)
            //    {
            //        if(txtAccount.Text == "" || txtPassword.Text == "")
            //        {
            //            MessageBox.Show("Yêu cầu nhập các fields đầy đủ !");
            //        }else if(txtPassword.Text != item.MatKhau && txtAccount.Text == item.TenDangNhap)
            //        {
            //            MessageBox.Show("Nếu bạn quên mật khẩu thì click vào Forget Password ?");
            //        }else if(txtPassword.Text != item.MatKhau && txtAccount.Text != item.TenDangNhap)
            //        {
            //            MessageBox.Show("Tài khoản và Mật khẩu bạn chưa tổn tại !!!");
            //        }
            //        else
            //        {

            //            MessageBox.Show("Đăng nhập thành công !");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnForget_Click(object sender, EventArgs e)
        {
            timer.Stop();

            ForgetPassword form = new ForgetPassword();
            form.Show();
            //this.Close();
        }
      
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void formLogin_Load(object sender, EventArgs e)
        {
         
            eventCountdown();
        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
              
                second--;
                if(second < 0 )
                {
                    second = 59;
                    minute-=1;
                }else if(minute == 0 && second == 0)
                {
                    this.Close();
                }
                txtTimer.Text = string.Format("{0}:{1}", minute.ToString().PadLeft(2, '0'), second.ToString().PadLeft(2, '0'));
            }));
        }

    }
}
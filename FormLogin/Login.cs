using System;
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

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                timer.Stop();
                List<TaiKhoan> ts = context.TaiKhoans.ToList();
                foreach (var item in ts)
                {
                    if (txtAccount.Text == "" || txtPassword.Text == "")
                    {
                        MessageBox.Show("Yêu cầu nhập các fields đầy đủ !");
                    }
                    else if (txtPassword.Text != item.MatKhau && txtAccount.Text == item.TenDangNhap)
                    {
                        MessageBox.Show("Nếu bạn quên mật khẩu thì click vào Forget Password ?");
                    }
                    else if (txtPassword.Text != item.MatKhau && txtAccount.Text != item.TenDangNhap)
                    {
                        MessageBox.Show("Tài khoản và Mật khẩu bạn chưa tổn tại !!!");
                        break;
                    }
                    else
                    {

                        MessageBox.Show("Đăng nhập thành công !");
                        FormTrangChu frm = new FormTrangChu(this);
                        this.Hide();
                        frm.ShowDialog();
                        this.Close();
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtTimer_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panelPas_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panelAccount_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDangKy frm=new FormDangKy(this);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !checkBox2.Checked;
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

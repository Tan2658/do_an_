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
using BUS;
using System.Runtime.Remoting.Contexts;
using System.Drawing.Imaging;
using System.Xml.Linq;
using Microsoft.Reporting.WinForms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace FormLogin
{
    public partial class FormTrangChu : Form
    {
        private readonly NguoiDungService nguoidung = new NguoiDungService();
        private readonly TaiKhoanService taikhoan = new TaiKhoanService();
        private readonly BenhNhanService benhnhan  = new BenhNhanService();
        private readonly BenhNhanDangKiService dangki = new BenhNhanDangKiService();
        public FormTrangChu()
        {
            InitializeComponent();
        }

        private void khámBệnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabTrangChu.Visible = true;
            tabNguoiDung.Parent = null;
        }
        int indexPicture = 0;
        int indexPicture2 = 6;
        private void FormTrangChu_Load(object sender, EventArgs e)
        {
           
            pictureBox1.Image = imageListTrangChu.Images[indexPicture];
            pictureBox2.Image = imageListTrangChu.Images[indexPicture2];
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dtNgayKhamDau.Format = DateTimePickerFormat.Custom;
            dtNgayKhamDau.CustomFormat = "dd/MM/yyyy";
            lblDuocVatTu.Hide();
            lblNguoiDung.Hide();
            lblKhamBenh.Hide();
            lblThongKe.Hide();
            lblTiepNhan.Hide();
        }

        private void menustripNguoiDung_Click(object sender, EventArgs e)
        {
           // tabNguoiDung.Parent = tabTrangChu;
            tabTrangChu.Visible = true;
            tabTiepNhan.Parent = null;
        }

        private void menustripNguoiDung_MouseEnter(object sender, EventArgs e)
        {
            lblNguoiDung.Show();
        }

        private void menustripNguoiDung_MouseLeave(object sender, EventArgs e)
        {
            lblNguoiDung.Hide() ;   
        }

        private void menustripTiepNhan_MouseEnter(object sender, EventArgs e)
        {
            lblTiepNhan.Show() ;
        }

        private void menustripTiepNhan_MouseLeave(object sender, EventArgs e)
        {
            lblTiepNhan.Hide() ;
        }

        private void menustripKhamBenh_MouseEnter(object sender, EventArgs e)
        {
            lblKhamBenh.Show() ;
        }

        private void menustripKhamBenh_MouseLeave(object sender, EventArgs e)
        {
            lblKhamBenh .Hide() ;
        }

        private void menustripThuoc_MouseEnter(object sender, EventArgs e)
        {
            lblDuocVatTu.Show() ;
        }

        private void menustripThuoc_MouseLeave(object sender, EventArgs e)
        {
            lblDuocVatTu .Hide() ;
        }

        private void menustripThongKe_MouseEnter(object sender, EventArgs e)
        {
                lblThongKe.Show() ;
        }

        private void menustripThongKe_MouseLeave(object sender, EventArgs e)
        {
            lblThongKe .Hide() ;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
           
        }

        
        private void FillMember(List<BacSi> list)
        {
            dgvNhaKhoa.Rows.Clear();
            foreach (var item in list)
            {
                int index = dgvNhaKhoa.Rows.Add();
                dgvNhaKhoa.Rows[index].Cells[0].Value = item.MaNV;
                dgvNhaKhoa.Rows[index].Cells[1].Value = item.Ten;
                dgvNhaKhoa.Rows[index].Cells[2].Value = item.TaiKhoan.TenDangNhap;
                dgvNhaKhoa.Rows[index].Cells[3].Value = item.ChucVu;
                dgvNhaKhoa.Rows[index].Cells[4].Value = item.SDT;
                dgvNhaKhoa.Rows[index].Cells[5].Value = item.KinhNghiem;
                dgvNhaKhoa.Rows[index].Cells[6].Value = item.MoTa;
            }
        }
        private void FillBenhNhan(List<BenhNhan> list)
        {
            dgvBenhNhan.Rows.Clear();
            foreach (var item in list)
            {
                int index = dgvBenhNhan.Rows.Add();
                dgvBenhNhan.Rows[index].Cells[0].Value = item.IDBenhNhan;
                dgvBenhNhan.Rows[index].Cells[1].Value = item.HoTen;
                if(item.Gioi == false)
                {
                    dgvBenhNhan.Rows[index].Cells[2].Value = "Nữ";

                }
                else
                {
                    dgvBenhNhan.Rows[index].Cells[2].Value = "Nam";
                }
                dgvBenhNhan.Rows[index].Cells[3].Value = item.NamSinh;
                dgvBenhNhan.Rows[index].Cells[4].Value = item.SDT;
                dgvBenhNhan.Rows[index].Cells[5].Value = item.DiaChi;
            }
        }




        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var listMember = nguoidung.GetAll();
                FillMember(listMember);
                MessageBox.Show("Tải thông tin thành viên phòng khám thành công");
            }
            catch (Exception ex)
           {

               MessageBox.Show(ex.Message);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioBacSi.Checked)
                {
                    var listDoctor = nguoidung.GetAllDoctor();
                    dgvNhaKhoa.Rows.Clear();
                    foreach (var item in listDoctor)
                    {
                        int index = dgvNhaKhoa.Rows.Add();
                        dgvNhaKhoa.Rows[index].Cells[0].Value = item.MaNV;
                        dgvNhaKhoa.Rows[index].Cells[1].Value = item.Ten;
                        dgvNhaKhoa.Rows[index].Cells[2].Value = item.TaiKhoan.TenDangNhap;
                        dgvNhaKhoa.Rows[index].Cells[3].Value = item.ChucVu;
                        dgvNhaKhoa.Rows[index].Cells[4].Value = item.SDT;
                        dgvNhaKhoa.Rows[index].Cells[5].Value = item.KinhNghiem;
                        dgvNhaKhoa.Rows[index].Cells[6].Value = item.MoTa;
                    }
                    MessageBox.Show("Tải thông tin bác sĩ thành công");
                }
                else
                {
                    var listStaff = nguoidung.GetAllStaff();
                    dgvNhaKhoa.Rows.Clear();
                    foreach (var item in listStaff)
                    {
                        int index = dgvNhaKhoa.Rows.Add();
                        dgvNhaKhoa.Rows[index].Cells[0].Value = item.MaNV;
                        dgvNhaKhoa.Rows[index].Cells[1].Value = item.Ten;
                        dgvNhaKhoa.Rows[index].Cells[2].Value = item.TaiKhoan.TenDangNhap;
                        dgvNhaKhoa.Rows[index].Cells[3].Value = item.ChucVu;
                        dgvNhaKhoa.Rows[index].Cells[4].Value = item.SDT;
                        dgvNhaKhoa.Rows[index].Cells[5].Value = item.KinhNghiem;
                        dgvNhaKhoa.Rows[index].Cells[6].Value = item.MoTa;
                    }
                    MessageBox.Show("Tải thông tin nhân viên thành công");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtNameBN.Text;
                BenhNhan dbDelete = benhnhan.findNameBenhNhan(name);
                if (dbDelete == null)
                {
                    throw new Exception("Không tìm thấy mã số sinh viên cần xóa");
                }
                else
                {
                    if (dbDelete != null)
                    {
                        DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "Yes / No", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            dgvBenhNhan.Rows.RemoveAt(dgvBenhNhan.CurrentRow.Index); // Xóa ở DGV
                            benhnhan.removeBenhNhan(name);
                            clearContentBN();
                            MessageBox.Show("Xóa sinh viên thành công", "Thông báo", MessageBoxButtons.OK);
                        }

                    }


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string RemoveDiacritics(string text)
        {
            string formD = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char ch in formD)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbTimKiemBN.Checked)
                {
                    int starMonth = Convert.ToInt32(dateTimePicker1.Value.Month);
                    int endMonth = Convert.ToInt32(dateTimePicker2.Value.Month);
                    var listBNbyMonth = benhnhan.FindBenhNhanWithMonth(starMonth, endMonth);
                    dgvBenhNhan.Rows.Clear();
                    foreach (var item in listBNbyMonth)
                    {
                        int index = dgvBenhNhan.Rows.Add();
                        dgvBenhNhan.Rows[index].Cells[0].Value = item.IDBenhNhan;
                        dgvBenhNhan.Rows[index].Cells[1].Value = item.HoTen;
                        if (item.Gioi == false)
                        {
                            dgvBenhNhan.Rows[index].Cells[2].Value = "Nữ";

                        }
                        else
                        {
                            dgvBenhNhan.Rows[index].Cells[2].Value = "Nam";
                        }
                        dgvBenhNhan.Rows[index].Cells[3].Value = item.NamSinh;
                        dgvBenhNhan.Rows[index].Cells[4].Value = item.SDT;
                        dgvBenhNhan.Rows[index].Cells[5].Value = item.DiaChi;
                    }
                }   
                else
                {
                    for (int i = 0; i < dgvBenhNhan.Rows.Count -1 ; i++)
                    {
                        string name = dgvBenhNhan.Rows[i].Cells[1].Value.ToString();
                        string findName = txtNameBN.Text;

                        name = RemoveDiacritics(name);
                        findName = RemoveDiacritics(findName);

                        bool contains = name.IndexOf(findName, StringComparison.OrdinalIgnoreCase) >= 0;
                        if (contains)
                        {
                            dgvBenhNhan.Rows[i].Visible = true;
                        }
                        else
                        {
                            dgvBenhNhan.Rows[i].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private bool checkDataFields()
        {
            if (txtNameBN.Text == "" || txtNamSinhBN.Text == "" || txtSDTBN.Text == "" || txtLyDoBN.Text == "" || txtDiaChiBN.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu bệnh nhân đầy đủ", "Thong Bao", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime currentDateTime = DateTime.Now;
                var listBenhNhan = benhnhan.GetAll();
                foreach(var item in listBenhNhan)
                {
                    if(item.HoTen != txtNameBN.Text)
                    {
                        var number = radioMale.Checked ? 1 : 0;
                        BenhNhan b = new BenhNhan() { 
                            IDBenhNhan = "B"+dgvBenhNhan.Rows.Count.ToString(),
                            HoTen = txtNameBN.Text,
                            Gioi = radioMale.Checked ? true: false,
                            NamSinh = txtNamSinhBN.Text,
                            SDT = txtSDTBN.Text,
                            DiaChi = txtDiaChiBN.Text,
                            NgayKhamDau = dtNgayKhamDau.Value
                        };
                        benhnhan.InsertUpdate(b);
                        clearContentBN();
                        MessageBox.Show("Thêm bệnh nhân thành công");
                        var listBenhNhanAdd = benhnhan.GetAll();
                        FillBenhNhan(listBenhNhanAdd);
                    }
                    else
                    {
                        MessageBox.Show("Có lẽ bạn đã có trong danh sách của chúng tôi");
                    }
                }
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }
        }

        private void btnLoadBN_Click(object sender, EventArgs e)
        {
            try
            {
                var listBenhNhan = benhnhan.GetAll();
                FillBenhNhan(listBenhNhan);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void clearContentBN()
        {

            txtNameBN.Text = "";
            txtNamSinhBN.Text = "";
            txtLyDoBN.Text = "";
            txtSDTBN.Text = "";
            txtDiaChiBN.Text = "";
        }
        private void dgvBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var listBenhNhan = benhnhan.GetAll();

               if (dgvBenhNhan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvBenhNhan.CurrentRow.Selected = true;
                    txtNameBN.Text = dgvBenhNhan.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    if(dgvBenhNhan.Rows[e.RowIndex].Cells[2].FormattedValue.ToString() == "Nam")
                    {
                        radioMale.Checked = true;
                    }
                   else
                   {
                       radioFemale.Checked = true;
                   }
                  txtNamSinhBN.Text = dgvBenhNhan.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                  txtSDTBN.Text = dgvBenhNhan.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                 txtDiaChiBN.Text = dgvBenhNhan.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnXoaTimKiem_Click(object sender, EventArgs e)
        {
            var listBN = benhnhan.GetAll();
            clearContentBN();
            if(txtNameBN.Text == "")
            {
                FillBenhNhan(listBN);
            }
        }
       
        private void FillBenhnhanDangKi(List<DanhSachKham> list)
        {
            dgvBenhNhanDangKi.Rows.Clear();
            foreach (var item in list)
            {
                int index = dgvBenhNhanDangKi.Rows.Add();
                dgvNhaKhoa.Rows[index].Cells[0].Value = item.IDKham;
                dgvNhaKhoa.Rows[index].Cells[1].Value = item.IDBenhNhan;
                dgvNhaKhoa.Rows[index].Cells[2].Value = item.BenhNhan.HoTen;
                dgvNhaKhoa.Rows[index].Cells[3].Value = item.BenhNhan.NamSinh;
                dgvNhaKhoa.Rows[index].Cells[4].Value = item.BenhNhan.SDT;
                dgvNhaKhoa.Rows[index].Cells[5].Value = item.BenhNhan.NgayKhamDau;
                dgvNhaKhoa.Rows[index].Cells[6].Value = null;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
          FormReportView formrp = new FormReportView();
         formrp.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtNameBN_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabTrangChu.Visible = false;
        }

        private void menustripKhamBenh_Click(object sender, EventArgs e)
        {
            tabTrangChu.Visible = true;
            tabNguoiDung.Parent = null;
        }

        private void menustripThuoc_Click(object sender, EventArgs e)
        {
            tabTrangChu.Visible = true;
            tabTiepNhan.Parent = null;
        }

        private void menustripThongKe_Click(object sender, EventArgs e)
        {
            tabTrangChu.Visible = true;
            tabTiepNhan.Parent = null;
        }

        private void tabTiepNhan_Click(object sender, EventArgs e)
        {

        }
        DanhSachKham c;


        private void btnDangKi_Click(object sender, EventArgs e)
        {
            try
            {
                BenhNhan b = benhnhan.findNameBenhNhan(txtNameBN.Text);
                if(b.HoTen == txtNameBN.Text)
                {
                    c = new DanhSachKham()
                    {
                        IDKham = dgvBenhNhanDangKi.Rows.Count.ToString(),
                        IDBenhNhan = txtNameBN.Text,
                        MaNV = c.MaNV.ToString(),
                        NgayKham = dtNgayKhamDau.Value
                    };
                    dangki.InsertUpdateDanhSachKham(c);
                    MessageBox.Show("Đăng kí bệnh nhân thành công");
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void dgvBenhNhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string col = dgvBenhNhan.Columns[e.ColumnIndex].Name;
            BenhNhan b = benhnhan.findNameBenhNhan(txtNameBN.Text);
            var doctormanyExperience = nguoidung.getDoctorManyexperience("Bác sĩ B");
            if (col == "Column14" && b.HoTen == txtNameBN.Text)
            {
                dgvBenhNhanDangKi.Rows.Add(dgvBenhNhanDangKi.Rows.Count,
                dgvBenhNhan.Rows[e.RowIndex].Cells[0].Value.ToString(),
                dgvBenhNhan.Rows[e.RowIndex].Cells[1].Value.ToString(),
               dgvBenhNhan.Rows[e.RowIndex].Cells[3].Value.ToString(),
               dgvBenhNhan.Rows[e.RowIndex].Cells[4].Value.ToString(),
                dtNgayKhamDau.Value.ToString(),
                  "0 Đồng");
                dgvBenhNhan.Rows.RemoveAt(dgvBenhNhan.CurrentRow.Index);
                MessageBox.Show("Đăng kí bệnh nhân thành công");
                c = new DanhSachKham()
                {
                    IDKham = dgvBenhNhanDangKi.Rows.Count.ToString(),
                    IDBenhNhan = dgvBenhNhan.Rows[e.RowIndex].Cells[0].Value.ToString(),
                    NgayKham = b.NgayKhamDau.Value,
                    MaNV = doctormanyExperience.MaNV,
                };
                dangki.InsertUpdateDanhSachKham(c);
            }
        }
    }
}

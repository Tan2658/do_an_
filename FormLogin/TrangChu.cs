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
        ReportDataSource rp = new ReportDataSource();
        DentalContextDB db1 = new DentalContextDB();
        DentalContextDB db = new DentalContextDB();
        public FormTrangChu()
        {
            InitializeComponent();
        }

        private void khámBệnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabTrangChu.Visible = true;
            tabTiepNhan.Parent = tabTrangChu;
            tabNguoiDung.Parent = null;
        }
        int indexPicture = 0;
        int indexPicture2 = 6;
        private void FormTrangChu_Load(object sender, EventArgs e)
        {
           
            //pictureBox1.Image = imageListTrangChu.Images[indexPicture];
            //pictureBox2.Image = imageListTrangChu.Images[indexPicture2];
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "dd/MM/yyyy";
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
            tabNguoiDung.Parent = tabTrangChu;
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
        private void FillRegistered(List<BacSi> list)
        {
            //dgvNguoiDung.Rows.Clear();
            //foreach (var item in list)
            //{
            //    int index = dgvNguoiDung.Rows.Add();
            //    dgvNguoiDung.Rows[index].Cells[0].Value = item.TrangThai;
            //    dgvNguoiDung.Rows[index].Cells[1].Value = item.Ten;
            //    dgvNguoiDung.Rows[index].Cells[2].Value = item.STD;
            //    dgvNguoiDung.Rows[index].Cells[3].Value = item.TenDangNhap;
            //    dgvNguoiDung.Rows[index].Cells[4].Value = item.MatKhau;
            //    dgvNguoiDung.Rows[index].Cells[5].Value = item.KinhNghiem;
            //    dgvNguoiDung.Rows[index].Cells[6].Value = item.Mota;
            //}
        }
        private void FillRegister(List<BacSi> list)
        {
            //dgvDangKi.Rows.Clear();
            //foreach (var item in list)
            //{
            //    int index = dgvDangKi.Rows.Add();
            //    dgvDangKi.Rows[index].Cells[0].Value = item.TrangThai;
            //    dgvDangKi.Rows[index].Cells[1].Value = item.Ten;
            //    dgvDangKi.Rows[index].Cells[2].Value = item.STD;
            //    dgvDangKi.Rows[index].Cells[3].Value = item.TenDangNhap;
            //    dgvDangKi.Rows[index].Cells[4].Value = item.MatKhau;
            //    dgvDangKi.Rows[index].Cells[5].Value = item.KinhNghiem;
            //    dgvDangKi.Rows[index].Cells[6].Value = item.Mota;
            //}
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
            //try
            //{
            //    var listRegistered = nguoidung.GetRegisted();
            //    var listRegister = nguoidung.GetRegister();
            //    FillRegistered(listRegistered);
            //    FillRegister(listRegister);
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var listSortRegistered = nguoidung.SortRegisted();
            //    var listSortRegister = nguoidung.SortRegister();
            //    FillRegistered(listSortRegistered);
            //    FillRegister(listSortRegister);
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }

       

        private void dgvNguoiDung_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra chỉ định ô cần đặt màu nền
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                // Lấy giá trị của ô
                var cellValue = dgvNguoiDung.Rows[e.RowIndex].Cells[0].Value;

                // Kiểm tra giá trị và đặt màu nền cho ô
                if (cellValue != null && cellValue.ToString() == "Sử dụng")
                {
                    e.CellStyle.BackColor = Color.Green; // Đặt màu nền là màu đỏ
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if(radioDangKi.Checked)
            //    {
            //        BacSi bs = nguoidung.findByName(txtSearch.Text);
            //        dgvDangKi.Rows.Clear();
            //        int index = dgvDangKi.Rows.Add();
            //        dgvDangKi.Rows[index].Cells[0].Value = bs.TrangThai.ToString();
            //        dgvDangKi.Rows[index].Cells[1].Value = bs.Ten.ToString();
            //        dgvDangKi.Rows[index].Cells[2].Value = bs.STD.ToString();
            //        dgvDangKi.Rows[index].Cells[3].Value = bs.TenDangNhap.ToString();
            //        dgvDangKi.Rows[index].Cells[4].Value = bs.MatKhau.ToString();
            //        dgvDangKi.Rows[index].Cells[5].Value = bs.KinhNghiem.ToString();
            //        dgvDangKi.Rows[index].Cells[6].Value = bs.Mota.ToString();
            //    }
            //    else
            //    {
            //        BacSi bs = nguoidung.findByName(txtSearch.Text);
            //        dgvNguoiDung.Rows.Clear();
            //        int index = dgvNguoiDung.Rows.Add();
            //        dgvNguoiDung.Rows[index].Cells[0].Value = bs.TrangThai.ToString();
            //        dgvNguoiDung.Rows[index].Cells[1].Value = bs.Ten.ToString();
            //        dgvNguoiDung.Rows[index].Cells[2].Value = bs.STD.ToString();
            //        dgvNguoiDung.Rows[index].Cells[3].Value = bs.TenDangNhap.ToString();
            //        dgvNguoiDung.Rows[index].Cells[4].Value = bs.MatKhau.ToString();
            //        dgvNguoiDung.Rows[index].Cells[5].Value = bs.KinhNghiem.ToString();
            //        dgvNguoiDung.Rows[index].Cells[6].Value = bs.Mota.ToString();
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }
        public int checkIDBenhNhan(string IDBN)
        {
            if (dgvBenhNhan.Rows.Count > 0)
            {
                for (int i = 0; i < dgvBenhNhan.Rows.Count; i++)
                {
                    if (dgvBenhNhan.Rows[i].Cells[0].Value.ToString() == IDBN)
                    {
                        return 1;
                    }
                }
            }
            return -1;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string ID = txtIDBN.Text;

            //    BenhNhan dbDelete = db1.BenhNhans.FirstOrDefault(p => p.IDBenhNhan == ID);
            //    if (dbDelete == null)
            //    {
            //        throw new Exception("Không tìm thấy benh nhan cần xóa !");
            //    }
            //    else
            //    {
            //        if (dbDelete != null)
            //        {
            //            DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "Yes / No", MessageBoxButtons.YesNo);
            //            if (dr == DialogResult.Yes)
            //            {
            //                dgvBenhNhan.Rows.RemoveAt(dgvBenhNhan.CurrentRow.Index); // Xóa ở DGV
            //                db1.BenhNhans.Remove(dbDelete); // Xóa ở DB
            //                db1.SaveChanges();
            //                clearContentBN();
            //                MessageBox.Show("Xóa sinh viên thành công", "Thông báo", MessageBoxButtons.OK);
            //            }

            //        }


            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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

        //private void btnTim_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (cbTimKiemBN.Checked)
        //        {
        //            int starMonth = Convert.ToInt32(dateTimePicker1.Value.Month);
        //            int endMonth = Convert.ToInt32(dateTimePicker2.Value.Month);
        //            var listBNbyMonth = benhnhan.FindBenhNhanWithMonth(starMonth, endMonth);
        //            dgvBenhNhan.Rows.Clear();
        //            foreach (var item in listBNbyMonth)
        //            {
        //                int index = dgvBenhNhan.Rows.Add();
        //                dgvBenhNhan.Rows[index].Cells[0].Value = item.IDBenhNhan;
        //                dgvBenhNhan.Rows[index].Cells[1].Value = item.HoTen;
        //                if (item.Gioi == false)
        //                {
        //                    dgvBenhNhan.Rows[index].Cells[2].Value = "Nữ";

        //                }
        //                else
        //                {
        //                    dgvBenhNhan.Rows[index].Cells[2].Value = "Nam";
        //                }
        //                dgvBenhNhan.Rows[index].Cells[3].Value = item.NamSinh;
        //                dgvBenhNhan.Rows[index].Cells[4].Value = item.SDT;
        //                dgvBenhNhan.Rows[index].Cells[5].Value = item.DiaChi;
        //            }
        //        }
        //        else if (txtNameBN.Text == "")
        //        {
        //            BenhNhan IDBenhNhan = benhnhan.FindIDBenhNhan(txtIDBN.Text);
        //            dgvBenhNhan.Rows.Clear();
        //            int index = dgvBenhNhan.Rows.Add();
        //            dgvBenhNhan.Rows[index].Cells[0].Value = IDBenhNhan.IDBenhNhan;
        //            dgvBenhNhan.Rows[index].Cells[1].Value = IDBenhNhan.HoTen;
        //            if (IDBenhNhan.Gioi == false)
        //            {
        //                dgvBenhNhan.Rows[index].Cells[2].Value = "Nữ";

        //            }
        //            else
        //            {
        //                dgvBenhNhan.Rows[index].Cells[2].Value = "Nam";
        //            }
        //            dgvBenhNhan.Rows[index].Cells[3].Value = IDBenhNhan.NamSinh;
        //            dgvBenhNhan.Rows[index].Cells[4].Value = IDBenhNhan.SDT;
        //            dgvBenhNhan.Rows[index].Cells[5].Value = IDBenhNhan.DiaChi;
        //        }
        //        else
        //        {
        //            for (int i = 0; i < dgvBenhNhan.Rows.Count; i++)
        //            {
        //                string name = dgvBenhNhan.Rows[i].Cells[1].Value.ToString();
        //                string findName = txtNameBN.Text;

        //                name = RemoveDiacritics(name);
        //                findName = RemoveDiacritics(findName);

        //                bool contains = name.IndexOf(findName, StringComparison.OrdinalIgnoreCase) >= 0;
        //                if (contains)
        //                {
        //                    dgvBenhNhan.Rows[i].Visible = true;
        //                }
        //                else
        //                {
        //                    dgvBenhNhan.Rows[i].Visible = false;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show("Tìm thấy bệnh nhân thành công");
        //    }
        //}
        private bool checkDataFields()
        {
            if (txtIDBN.Text == "" || txtNameBN.Text == "" || txtNamSinhBN.Text == "" || txtSDTBN.Text == "" || txtGiaDinhBN.Text == "" || txtNgheNghiepBN.Text == ""  || txtTienSuBN.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu bệnh nhân đầy đủ", "Thong Bao", MessageBoxButtons.OK);
                return false;
            }
            else if (txtIDBN.Text.Length != 3)
            {
                MessageBox.Show("ID Bệnh nhân chỉ có 3 ky tu", "Thong Bao", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    if (checkDataFields())
            //    {
            //        BenhNhan s =
            //            new BenhNhan()
            //            {
            //                IDBenhNhan = txtIDBN.Text,
            //                HoTen = txtNameBN.Text,
            //                Gioi = radioMale.Checked ? true : false,
            //                NamSinh = txtNamSinhBN.Text,    
            //                SDT = txtSDTBN.Text,
            //                DiaChi = txtDiaChiBN.Text,
            //                LyDo = txtTienSuBN.Text,
            //                NgayKhamDau = dateTimePicker3.Value


                            
                            
            //            };
            //        db1.BenhNhans.Add(s);
            //        db1.SaveChanges();
            //        clearContentBN();
            //        MessageBox.Show("Thêm bệnh nhân thành công", "Thông báo", MessageBoxButtons.OK);
            //        List<BenhNhan> listBN = db1.BenhNhans.ToList();
            //        FillBenhNhan(listBN);
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
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
            txtIDBN.Text = "";
            txtNamSinhBN.Text = "";
            txtSDTBN.Text = "";
            txtGiaDinhBN.Text = "";
            txtNameBN.Text = "";
            txtNgheNghiepBN.Text = "";
            txtTienSuBN.Text = "";
        }

        private void dgvBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    List<BenhNhan> listBN = db1.BenhNhans.ToList();

            //    if (dgvBenhNhan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //    {
            //        dgvBenhNhan.CurrentRow.Selected = true;
            //        txtIDBN.Text = dgvBenhNhan.Rows[e.RowIndex].Cells["Column1"].FormattedValue.ToString();
            //        txtNameBN.Text = dgvBenhNhan.Rows[e.RowIndex].Cells["Column2"].FormattedValue.ToString();
            //        if(dgvBenhNhan.Rows[e.RowIndex].Cells["Column3"].FormattedValue.ToString() == "Nam")
            //        {
            //            radioMale.Checked = true;
            //        }
            //        else
            //        {
            //            radioFemale.Checked = true;
            //        }
            //       txtNamSinhBN.Text = dgvBenhNhan.Rows[e.RowIndex].Cells["Column4"].FormattedValue.ToString();
            //       txtSDTBN.Text = dgvBenhNhan.Rows[e.RowIndex].Cells["Column5"].FormattedValue.ToString();
            //       txtDiaChiBN.Text = dgvBenhNhan.Rows[e.RowIndex].Cells["Column6"].FormattedValue.ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

       

        private void btnXoaTimKiem_Click(object sender, EventArgs e)
        {
            var listBN = benhnhan.GetAll();
            clearContentBN();
            if(txtIDBN.Text == "")
            {
                FillBenhNhan(listBN);
            }
        }
        private void dgvBenhNhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowCount = dgvBenhNhanDangKi.RowCount;
            string col = dgvBenhNhan.Columns[e.ColumnIndex].Name;
            if (col == "Column14")
            {
                   // BenhNhan dbDelete = benhnhan.FindIDBenhNhan(dgvBenhNhan.Rows[e.RowIndex].Cells[0].Value.ToString());
                    dgvBenhNhanDangKi.Rows.Add(rowCount.ToString(), dgvBenhNhan.Rows[e.RowIndex].Cells[0].Value.ToString(), dgvBenhNhan.Rows[e.RowIndex].Cells[1].Value.ToString(), dgvBenhNhan.Rows[e.RowIndex].Cells[3].Value.ToString(), dgvBenhNhan.Rows[e.RowIndex].Cells[4].Value.ToString(), dgvBenhNhan.Rows[e.RowIndex].Cells[5].Value.ToString(), "0 đồng".ToString());
                    dgvBenhNhan.Rows.Remove(dgvBenhNhan.CurrentRow);
                   // db1.BenhNhans.Remove(dbDelete); // Xóa ở DB
                    db1.SaveChanges();
                MessageBox.Show("Đăng kí khám thành công");
            }
        }

        private void btnTraBenhNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBenhNhan.Rows.Count > 0)
                {
                  
                    for (int i = 0; i < dgvBenhNhanDangKi.Rows.Count; i++)
                    {
                        if (dgvBenhNhanDangKi.Rows[i].Cells[1].Value.ToString() == txtIDBN.Text)
                        {
                            BenhNhan s = benhnhan.FindIDBenhNhan(txtIDBN.Text);
                            dgvBenhNhan.Rows.Add(s.IDBenhNhan,s.HoTen,s.Gioi == false ? "Nữ" : "Nam", s.NamSinh, s.SDT, s.DiaChi);
                            int rowIndex = dgvBenhNhanDangKi.SelectedRows[i].Index;
                            dgvBenhNhanDangKi.Rows.RemoveAt(rowIndex);
                            MessageBox.Show("Trả bệnh nhân thành công !");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Trả bệnh nhân thành công");
              
            }
        }

        private void dgvBenhNhanDangKi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    List<BenhNhan> listBN = db1.BenhNhans.ToList();

            //    if (dgvBenhNhanDangKi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //    {
            //        dgvBenhNhanDangKi.CurrentRow.Selected = true;
            //        txtIDBN.Text = dgvBenhNhanDangKi.Rows[e.RowIndex].Cells["Column8"].FormattedValue.ToString();
            //        txtNameBN.Text = dgvBenhNhanDangKi.Rows[e.RowIndex].Cells["Column9"].FormattedValue.ToString();
            //        txtNamSinhBN.Text = dgvBenhNhanDangKi.Rows[e.RowIndex].Cells["Column10"].FormattedValue.ToString();
            //        txtSDTBN.Text = dgvBenhNhanDangKi.Rows[e.RowIndex].Cells["Column11"].FormattedValue.ToString();
            //        txtDiaChiBN.Text = dgvBenhNhanDangKi.Rows[e.RowIndex].Cells["Column12"].FormattedValue.ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
          FormReportView formrp = new FormReportView();
         formrp.ShowDialog();
        }
      
        private void timerTrangChu_Tick(object sender, EventArgs e)
        {
          
            if (indexPicture > imageListTrangChu.Images.Count - 1)
            {
                indexPicture = 0;
            }
            if(indexPicture2 < 0)
            {
                indexPicture2 = imageListTrangChu.Images.Count -1;
         
            }
            //pictureBox1.Image = imageListTrangChu.Images[indexPicture++];
            //pictureBox2.Image = imageListTrangChu.Images[indexPicture2--];
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

        private void tabNguoiDung_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void tabTiepNhan_Click(object sender, EventArgs e)
        {

        }
    }
}

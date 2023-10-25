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
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace FormLogin
{
    public partial class FormTrangChu : Form
    {
        private readonly NguoiDungService nguoidung = new NguoiDungService();
        private readonly TaiKhoanService taikhoan = new TaiKhoanService();
        private readonly BenhNhanService benhnhan  = new BenhNhanService();
        private readonly VatTuService ms= new VatTuService();
        ReportDataSource rp = new ReportDataSource();
        DentalContextDB context = new DentalContextDB();
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
            tabNguoiDung.Parent = tabTrangChu;
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

        private void dgvDangKi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
            string col = dgvDangKi.Columns[e.ColumnIndex].Name;
            if(col == "col8")
            {
                dgvNguoiDung.Rows.Add(dgvDangKi.Rows[e.RowIndex].Cells[0].Value.ToString(), dgvDangKi.Rows[e.RowIndex].Cells[1].Value.ToString(), dgvDangKi.Rows[e.RowIndex].Cells[2].Value.ToString(), dgvDangKi.Rows[e.RowIndex].Cells[3].Value.ToString(), dgvDangKi.Rows[e.RowIndex].Cells[4].Value.ToString(), dgvDangKi.Rows[e.RowIndex].Cells[5].Value.ToString(), dgvDangKi.Rows[e.RowIndex].Cells[6].Value.ToString());
                dgvDangKi.Rows.RemoveAt(dgvDangKi.CurrentRow.Index);
           
            }
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

            //    BenhNhan dbDelete = context.BenhNhans.FirstOrDefault(p => p.IDBenhNhan == ID);
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
            //                context.BenhNhans.Remove(dbDelete); // Xóa ở context
            //                context.SaveChanges();
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (cbTimKiemBN.Checked)
            //    {
            //        int starMonth = Convert.ToInt32(dateTimePicker1.Value.Month);
            //        int endMonth = Convert.ToInt32(dateTimePicker2.Value.Month);
            //        var listBNbyMonth = benhnhan.FindBenhNhanWithMonth(starMonth, endMonth);
            //        dgvBenhNhan.Rows.Clear();
            //        foreach (var item in listBNbyMonth)
            //        {
            //            int index = dgvBenhNhan.Rows.Add();
            //            dgvBenhNhan.Rows[index].Cells[0].Value = item.IDBenhNhan;
            //            dgvBenhNhan.Rows[index].Cells[1].Value = item.HoTen;
            //            if (item.Gioi == false)
            //            {
            //                dgvBenhNhan.Rows[index].Cells[2].Value = "Nữ";

            //            }
            //            else
            //            {
            //                dgvBenhNhan.Rows[index].Cells[2].Value = "Nam";
            //            }
            //            dgvBenhNhan.Rows[index].Cells[3].Value = item.NamSinh;
            //            dgvBenhNhan.Rows[index].Cells[4].Value = item.SDT;
            //            dgvBenhNhan.Rows[index].Cells[5].Value = item.DiaChi;
            //        }
            //    }
            //    else if (txtNameBN.Text == "")
            //    {
            //        BenhNhan IDBenhNhan = benhnhan.FindIDBenhNhan(txtIDBN.Text);
            //        dgvBenhNhan.Rows.Clear();
            //        int index = dgvBenhNhan.Rows.Add();
            //        dgvBenhNhan.Rows[index].Cells[0].Value = IDBenhNhan.IDBenhNhan;
            //        dgvBenhNhan.Rows[index].Cells[1].Value = IDBenhNhan.HoTen;
            //        if (IDBenhNhan.Gioi == false)
            //        {
            //            dgvBenhNhan.Rows[index].Cells[2].Value = "Nữ";

            //        }
            //        else
            //        {
            //            dgvBenhNhan.Rows[index].Cells[2].Value = "Nam";
            //        }
            //        dgvBenhNhan.Rows[index].Cells[3].Value = IDBenhNhan.NamSinh;
            //        dgvBenhNhan.Rows[index].Cells[4].Value = IDBenhNhan.SDT;
            //        dgvBenhNhan.Rows[index].Cells[5].Value = IDBenhNhan.DiaChi;
            //    }
            //    else
            //    {
            //        for (int i = 0; i < dgvBenhNhan.Rows.Count; i++)
            //        {
            //            string name = dgvBenhNhan.Rows[i].Cells[1].Value.ToString();
            //            string findName = txtNameBN.Text;

            //            name = RemoveDiacritics(name);
            //            findName = RemoveDiacritics(findName);

            //            bool contains = name.IndexOf(findName, StringComparison.OrdinalIgnoreCase) >= 0;
            //            if (contains)
            //            {
            //                dgvBenhNhan.Rows[i].Visible = true;
            //            }
            //            else
            //            {
            //                dgvBenhNhan.Rows[i].Visible = false;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("Tìm thấy bệnh nhân thành công");
            //}
        }
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
            //        context.BenhNhans.Add(s);
            //        context.SaveChanges();
            //        clearContentBN();
            //        MessageBox.Show("Thêm bệnh nhân thành công", "Thông báo", MessageBoxButtons.OK);
            //        List<BenhNhan> listBN = context.BenhNhans.ToList();
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
            //    List<BenhNhan> listBN = context.BenhNhans.ToList();

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
                   // context.BenhNhans.Remove(dbDelete); // Xóa ở context
                    context.SaveChanges();
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
            //    List<BenhNhan> listBN = context.BenhNhans.ToList();

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
            pictureBox1.Image = imageListTrangChu.Images[indexPicture++];
            pictureBox2.Image = imageListTrangChu.Images[indexPicture2--];
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
        private int GetSelectedRow(string id)
        {
            for (int i = 0; i < dgvThiTruong.Rows.Count; i++)
            {
                if (dgvThiTruong.Rows[i].Cells[0].Value.ToString() == id)
                {
                    return i;
                }
            }
            return -1;
        }
        private bool checkDataFieldsMedic()
        {
            if (txtMa.Text == "" || txtTen.Text == "" || txtPrice.Text == "" || txtSL.Text == "")
            {
                MessageBox.Show("Vui long nhap day du thong tin");
                return false;
            }

            return true;
        }

        private void btnNhapThem_Click(object sender, EventArgs e)
        {
            try
            {
                int selectRow = GetSelectedRow(txtMa.Text);
                if (checkDataFieldsMedic() == true)
                {
                    decimal sl = Convert.ToDecimal(txtSL.Text);
                    decimal donGia = Convert.ToDecimal(txtPrice.Text);
                    if (selectRow == -1)
                    {
                        LichSuNhapXuat d = new LichSuNhapXuat()
                        {
                            NoiDung = rdoNhap.Checked ? true : false,
                            IDDungCu = txtMa.Text,
                            TenDungCu = txtTen.Text,
                            Loai = cboLoai.Text,
                            DonViTinh = cboDVT.Text,
                            SoLuongNhapXuat = int.Parse(txtSL.Text),
                            Don = decimal.Parse(txtPrice.Text),
                            ThanhTien = sl * donGia,
                            NgayNhap = dtpNhap.Value
                        };
                        if (rdoNhap.Checked == true && ms.FindIDKho(txtMa.Text) != null)
                        {
                            Kho k = context.Khoes.FirstOrDefault(p=> p.IDDungCu == txtMa.Text) ;
                            k.SoLuong = k.SoLuong + int.Parse(txtSL.Text);
                            context.SaveChanges();
                            clearContentVatTuNhap();
                        }
                        else if (rdoXuat.Checked == true && ms.FindIDKho(txtMa.Text) != null)
                        {
                            Kho k = context.Khoes.FirstOrDefault(p => p.IDDungCu == txtMa.Text);

                            if (k.SoLuong < int.Parse(txtSL.Text))
                            {
                                MessageBox.Show("Số lượng xuất lớn hơn số lượng tồn");
                            }
                            k.SoLuong = k.SoLuong - int.Parse(txtSL.Text);
                            context.SaveChanges();
                            clearContentVatTuNhap();
                        }
                        else
                        {
                            MessageBox.Show("Chỉ được truy suất vào các mặt hàng có sẵn trên thị trường");
                        }
                        ms.InsertUpdate(d);
                        MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK);
                        clearContentVatTuNhap();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        public void clearContentVatTuNhap()
        {
            txtMa.Text = string.Empty;
            txtTen.Text = string.Empty;
            txtSL.Text = string.Empty;
            cboDVT.SelectedIndex = -1;
            txtPrice.Text = string.Empty;
        }

        
        private void BindGridThiTruong(List<ThiTruong> Markets)
        {
            dgvThiTruong.Rows.Clear();
            foreach (var market in Markets)
            {
                int index = dgvThiTruong.Rows.Add();
                dgvThiTruong.Rows[index].Cells[0].Value = market.IDSanPham.ToString();
                dgvThiTruong.Rows[index].Cells[1].Value = market.TenSanPham.ToString();
                dgvThiTruong.Rows[index].Cells[2].Value = market.Loai.ToString();
                dgvThiTruong.Rows[index].Cells[3].Value = market.DonViTinh.ToString();
                dgvThiTruong.Rows[index].Cells[4].Value = market.DonGia.ToString();

            }
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            List<ThiTruong> listMarket = context.ThiTruongs.ToList();
            BindGridThiTruong(listMarket);
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            FormKho frm = new FormKho(this);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        
        private void dgvThiTruong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvThiTruong.SelectedRows.Count > 0)
            {
                var listStore = new List<Kho>();
                listStore = ms.GetAll();
                foreach (var item in listStore)
                {
                    if (item.TenDungCu.ToString() == dgvThiTruong.Rows[e.RowIndex].Cells[1].Value.ToString())
                    {
                        txtMa.Text = item.IDDungCu.ToString();
                        break;
                    }

                }
                txtTen.Text = dgvThiTruong.Rows[e.RowIndex].Cells[1].Value.ToString();
                cboLoai.Text = dgvThiTruong.Rows[e.RowIndex].Cells[2].Value.ToString();
                cboDVT.Text = dgvThiTruong.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPrice.Text = dgvThiTruong.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            else
            {
                MessageBox.Show("Can chon vao dong ban muon sua");
            }
        }

        private void btnLichSuNX_Click(object sender, EventArgs e)
        {
            FormLichSuNhapXuat frm = new FormLichSuNhapXuat(this);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void cboFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvThiTruong.Rows.Count; i++)
            {
                if (cboFind.SelectedItem.ToString() == dgvThiTruong.Rows[i].Cells[3].Value.ToString())
                {
                    dgvThiTruong.Rows[i].Visible = true;
                }
                else
                {
                    dgvThiTruong.Rows[i].Visible = false;
                }
            }
        }

        private void tabTK_Enter(object sender, EventArgs e)
        {
            dtpMonth.CustomFormat = "MM/yyyy";
            dtpMonth.Format = DateTimePickerFormat.Custom;
            dtpYear.CustomFormat = "yyyy";
            dtpYear.Format = DateTimePickerFormat.Custom;
            dtpQuy.CustomFormat = "MM/yyyy";
            dtpQuy.Format = DateTimePickerFormat.Custom;
            List<LichSuNhapXuat> listStatic = context.LichSuNhapXuats.ToList();
            BindGridTK(listStatic);
        }

        private void BindGridTK(List<LichSuNhapXuat> Statics)
        {
            dgvThongKeVT.Rows.Clear();
            foreach (var item in Statics)
            {
                int index = dgvThongKeVT.Rows.Add();
                if (item.NoiDung == false)
                {
                    dgvThongKeVT.Rows[index].Cells[0].Value = "Xuất";
                }
                else
                {
                    dgvThongKeVT.Rows[index].Cells[0].Value = "Nhập";
                }
                dgvThongKeVT.Rows[index].Cells[1].Value = item.IDDungCu;
                dgvThongKeVT.Rows[index].Cells[2].Value = item.TenDungCu.ToString();
                dgvThongKeVT.Rows[index].Cells[3].Value = item.Loai.ToString();
                dgvThongKeVT.Rows[index].Cells[4].Value = item.DonViTinh.ToString();
                dgvThongKeVT.Rows[index].Cells[5].Value = item.SoLuongNhapXuat.ToString();
                dgvThongKeVT.Rows[index].Cells[6].Value = item.Don.ToString();
                dgvThongKeVT.Rows[index].Cells[7].Value = item.ThanhTien.ToString();
                dgvThongKeVT.Rows[index].Cells[8].Value = item.NgayNhap.ToString();

            }
        }

        private void btnLoadTK_Click(object sender, EventArgs e)
        {
            List<LichSuNhapXuat> listStatic = context.LichSuNhapXuats.ToList();
            BindGridTK(listStatic);
        }

        private void btnThongKeVT_Click(object sender, EventArgs e)
        {
            decimal TienTong = 0;
            decimal TienXuat = 0;
            decimal TienNhap = 0;
            int countNhap = 0;
            int countXuat = 0;
            for (int i = 0; i < dgvThongKeVT.Rows.Count; i++)
            {
                if (rdpMoth.Checked)
                {
                    if (dtpMonth.Value.Month.ToString() == DateTime.Parse(dgvThongKeVT.Rows[i].Cells[8].Value.ToString()).Month.ToString()
                        && dtpYear.Value.Year.ToString() == DateTime.Parse(dgvThongKeVT.Rows[i].Cells[8].Value.ToString()).Year.ToString())
                    {
                        if (dgvThongKeVT.Rows[i].Cells[0].Value.ToString() == "Nhập")
                        {
                            countNhap++;
                            TienNhap += decimal.Parse(dgvThongKeVT.Rows[i].Cells[7].Value.ToString());
                            TienTong -= decimal.Parse(dgvThongKeVT.Rows[i].Cells[7].Value.ToString());
                        }
                        else
                        {
                           countXuat++;
                           TienXuat+= decimal.Parse(dgvThongKeVT.Rows[i].Cells[7].Value.ToString());
                           TienTong+= decimal.Parse(dgvThongKeVT.Rows[i].Cells[7].Value.ToString());

                        }
                        txtNhap.Text=countNhap.ToString();
                        txtXuat.Text=countXuat.ToString();
                        txtTienNhap.Text = TienNhap.ToString();
                        txtTienXuat.Text = TienXuat.ToString();
                        txtDoanh.Text = TienTong.ToString();
                    }
                }
                else if (rdpYear.Checked)
                {
                    if (dtpYear.Value.Year.ToString() == DateTime.Parse(dgvThongKeVT.Rows[i].Cells[8].Value.ToString()).Year.ToString())
                    {
                        if (dgvThongKeVT.Rows[i].Cells[0].Value.ToString() == "Nhập")
                        {
                            countNhap++;
                            TienNhap += decimal.Parse(dgvThongKeVT.Rows[i].Cells[7].Value.ToString());
                            TienTong -= decimal.Parse(dgvThongKeVT.Rows[i].Cells[7].Value.ToString());
                        }
                        else
                        {
                            countXuat++;
                            TienXuat += decimal.Parse(dgvThongKeVT.Rows[i].Cells[7].Value.ToString());
                            TienTong += decimal.Parse(dgvThongKeVT.Rows[i].Cells[7].Value.ToString());

                        }
                        txtNhap.Text = countNhap.ToString();
                        txtXuat.Text = countXuat.ToString();
                        txtTienNhap.Text = TienNhap.ToString();
                        txtTienXuat.Text = TienXuat.ToString();
                        txtDoanh.Text = TienTong.ToString();
                    }
                }
                else if (rdpQui.Checked)
                {
                    if (dtpQuy.Value.Year.ToString() == DateTime.Parse(dgvThongKeVT.Rows[i].Cells[8].Value.ToString()).Year.ToString())
                    {
                        int quy = cboQui.SelectedIndex;
                        int transactionQuarter =
                              (int.Parse(DateTime.Parse(dgvThongKeVT.Rows[i].Cells[8].Value.ToString()).Month.ToString()) - 1) / 3;
                        if (transactionQuarter == quy)
                        {
                            if (dgvThongKeVT.Rows[i].Cells[0].Value.ToString() == "Nhập")
                            {
                                countNhap++;
                                TienNhap += decimal.Parse(dgvThongKeVT.Rows[i].Cells[7].Value.ToString());
                                TienTong -= decimal.Parse(dgvThongKeVT.Rows[i].Cells[7].Value.ToString());
                            }
                            else
                            {
                                countXuat++;
                                TienXuat += decimal.Parse(dgvThongKeVT.Rows[i].Cells[7].Value.ToString());
                                TienTong += decimal.Parse(dgvThongKeVT.Rows[i].Cells[7].Value.ToString());

                            }
                        }
                        txtNhap.Text = countNhap.ToString();
                        txtXuat.Text = countXuat.ToString();
                        txtTienNhap.Text = TienNhap.ToString();
                        txtTienXuat.Text = TienXuat.ToString();
                        txtDoanh.Text = TienTong.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Ban can phai chon nut thong kẻ");
                    break;
                }
            }
        }

        private void dtpMonth_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvThongKeVT.Rows.Count; i++)
            {

                if( dtpMonth.Value.Month.ToString() == DateTime.Parse(dgvThongKeVT.Rows[i].Cells[8].Value.ToString()).Month.ToString()
                        && dtpYear.Value.Year.ToString() == DateTime.Parse(dgvThongKeVT.Rows[i].Cells[8].Value.ToString()).Year.ToString())
                {
                    dgvThongKeVT.Rows[i].Visible = true;
                }
                else
                {
                    dgvThongKeVT.Rows[i].Visible = false;
                }
            }
        }

        private void tabTrangChu_Enter(object sender, EventArgs e)
        {
            List<ThiTruong> listMarket = context.ThiTruongs.ToList();
            BindGridThiTruong(listMarket);
        }

        private void dtpQuy_ValueChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < dgvThongKeVT.Rows.Count; i++)
            {


                if (dtpQuy.Value.Year.ToString() == DateTime.Parse(dgvThongKeVT.Rows[i].Cells[8].Value.ToString()).Year.ToString())
                {
                    int quy = cboQui.SelectedIndex;
                    int transactionQuarter =
                          (int.Parse(DateTime.Parse(dgvThongKeVT.Rows[i].Cells[8].Value.ToString()).Month.ToString()) - 1) / 3;
                    if (transactionQuarter == quy)
                    {
                        dgvThongKeVT.Rows[i].Visible = true;
                    }
                }
                else
                {
                    dgvThongKeVT.Rows[i].Visible = false;
                }
            }
        }

        private void dtpYear_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvThongKeVT.Rows.Count; i++)
            {

                if (dtpYear.Value.Year.ToString() == DateTime.Parse(dgvThongKeVT.Rows[i].Cells[8].Value.ToString()).Year.ToString())
                {
                    dgvThongKeVT.Rows[i].Visible = true;
                }
                else
                {
                    dgvThongKeVT.Rows[i].Visible = false;
                }
            }
        }
    }
}

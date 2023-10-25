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
        private readonly DSKhamService dskham = new DSKhamService();
        private readonly DieuTriService dieutri = new DieuTriService();
        private readonly DichVuService dichvu = new DichVuService();
        private readonly CanLamSangService canlamsang = new CanLamSangService();
        private readonly KhoService kho = new KhoService();
        private readonly LichSuService lichsu = new LichSuService();

        public FormTrangChu()
        {
            InitializeComponent();
        }

        private void khámBệnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabTrangChu.Visible = true;
            tabTiepNhan.Parent = tabTrangChu;
            tabNguoiDung.Parent = null;
            tabKhamBenh.Parent = null;
        }
        int indexPicture = 0;
        int indexPicture2 = 6;
        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = "dd/MM/yyyy";
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.CustomFormat = "dd/MM/yyyy";
            lblDuocVatTu.Hide();
            lblNguoiDung.Hide();
            lblKhamBenh.Hide();
            lblThongKe.Hide();
            lblTiepNhan.Hide();

            fillBacSiBox();
        }

        private void fillBacSiBox()
        {
            List<BacSi> bacSis = nguoidung.GetRegisted();
            cmbBacSi.DataSource = bacSis;
            cmbBacSi.DisplayMember = "Ten";
            cmbBacSi.ValueMember = "MaNV";
        }

        private void menustripNguoiDung_Click(object sender, EventArgs e)
        {
           // tabNguoiDung.Parent = tabTrangChu;
            tabTrangChu.Visible = true;
            tabNguoiDung.Parent = tabTrangChu;
            tabTiepNhan.Parent = null;
            tabKhamBenh.Parent = null;
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
            dgvNguoiDung.Rows.Clear();
            foreach (var item in list)
            {
                int index = dgvNguoiDung.Rows.Add();
                dgvNguoiDung.Rows[index].Cells[0].Value = item.Ten;
                dgvNguoiDung.Rows[index].Cells[1].Value = item.SDT;
                dgvNguoiDung.Rows[index].Cells[2].Value = item.TenDangNhap;
                dgvNguoiDung.Rows[index].Cells[3].Value = item.TaiKhoan.MatKhau;
                dgvNguoiDung.Rows[index].Cells[4].Value = item.KinhNghiem;
                dgvNguoiDung.Rows[index].Cells[5].Value = item.MoTa;
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
                    dgvBenhNhan.Rows[index].Cells[2].Value = "Nữ";
                else
                    dgvBenhNhan.Rows[index].Cells[2].Value = "Nam";

                dgvBenhNhan.Rows[index].Cells[3].Value = item.NamSinh;
                dgvBenhNhan.Rows[index].Cells[4].Value = item.SDT;
                dgvBenhNhan.Rows[index].Cells[5].Value = item.DiaChi;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var listRegistered = nguoidung.GetRegisted();
                FillRegistered(listRegistered);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            try
            {
                var listSortRegistered = nguoidung.SortRegisted();
                FillRegistered(listSortRegistered);
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
                if (txtSearch.Text == "")
                    throw new Exception("Vui lòng nhập đủ thông tin");

                BacSi bs = nguoidung.findByName(txtSearch.Text);
                dgvNguoiDung.Rows.Clear();
                int index = dgvNguoiDung.Rows.Add();
                dgvNguoiDung.Rows[index].Cells[0].Value = bs.Ten;
                dgvNguoiDung.Rows[index].Cells[1].Value = bs.SDT;
                dgvNguoiDung.Rows[index].Cells[2].Value = bs.TenDangNhap;
                dgvNguoiDung.Rows[index].Cells[3].Value = bs.TaiKhoan.MatKhau;
                dgvNguoiDung.Rows[index].Cells[4].Value = bs.KinhNghiem;
                dgvNguoiDung.Rows[index].Cells[5].Value = bs.MoTa;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            try
            {
                if (txtIDBN.Text == "")
                    throw new Exception("Vui lòng nhập mã của bệnh nhân cần xóa");

                int flag = -1;

                for (int i = 0; i < dgvBenhNhan.Rows.Count; i++)
                {
                    if (dgvBenhNhan.Rows[i].Cells[0].Value.ToString() == txtIDBN.Text)
                    {
                        DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "Yes / No", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            dskham.DeleteAllWithID(txtIDBN.Text);
                            benhnhan.Delete(txtIDBN.Text);
                            clearContentBN();
                            MessageBox.Show("Xóa bệnh nhân thành công", "Thông báo", MessageBoxButtons.OK);
                        }
                        flag = 1;
                        break;
                    }
                }

                if (flag == -1)
                    throw new Exception("Không tìm thấy bệnh nhân");
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
                    int starMonth = Convert.ToInt32(dtpFrom.Value.Month);
                    int endMonth = Convert.ToInt32(dtpTo.Value.Month);
                    var listBNbyMonth = benhnhan.FindBenhNhanWithMonth(starMonth, endMonth);
                    dgvBenhNhan.Rows.Clear();
                    foreach (var item in listBNbyMonth)
                    {
                        int index = dgvBenhNhan.Rows.Add();
                        dgvBenhNhan.Rows[index].Cells[0].Value = item.IDBenhNhan;
                        dgvBenhNhan.Rows[index].Cells[1].Value = item.HoTen;

                        if (item.Gioi == false)
                            dgvBenhNhan.Rows[index].Cells[2].Value = "Nữ";
                        else
                            dgvBenhNhan.Rows[index].Cells[2].Value = "Nam";

                        dgvBenhNhan.Rows[index].Cells[3].Value = item.NamSinh;
                        dgvBenhNhan.Rows[index].Cells[4].Value = item.SDT;
                        dgvBenhNhan.Rows[index].Cells[5].Value = item.DiaChi;
                    }
                }
                else if (txtNameBN.Text == "")
                {
                    BenhNhan IDBenhNhan = benhnhan.FindIDBenhNhan(txtIDBN.Text);
                    dgvBenhNhan.Rows.Clear();
                    int index = dgvBenhNhan.Rows.Add();
                    dgvBenhNhan.Rows[index].Cells[0].Value = IDBenhNhan.IDBenhNhan;
                    dgvBenhNhan.Rows[index].Cells[1].Value = IDBenhNhan.HoTen;

                    if (IDBenhNhan.Gioi == false)
                        dgvBenhNhan.Rows[index].Cells[2].Value = "Nữ";
                    else
                        dgvBenhNhan.Rows[index].Cells[2].Value = "Nam";

                    dgvBenhNhan.Rows[index].Cells[3].Value = IDBenhNhan.NamSinh;
                    dgvBenhNhan.Rows[index].Cells[4].Value = IDBenhNhan.SDT;
                    dgvBenhNhan.Rows[index].Cells[5].Value = IDBenhNhan.DiaChi;
                }
                else
                {
                    for (int i = 0; i < dgvBenhNhan.Rows.Count; i++)
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
            if (txtNameBN.Text == "" || txtNamSinhBN.Text == "" || txtSDTBN.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu bệnh nhân đầy đủ", "Thong Bao", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkDataFields())
                {
                    string stt = (dgvBenhNhan.Rows.Count + 1).ToString();

                    if (int.Parse(stt) < 10)
                        stt = stt.Insert(0, "00");
                    else if (int.Parse(stt) < 100)
                            stt = stt.Insert(0, "0");

                    BenhNhan s =
                        new BenhNhan()
                        {
                            IDBenhNhan = stt,
                            HoTen = txtNameBN.Text,
                            Gioi = radioMale.Checked ? true : false,
                            NamSinh = txtNamSinhBN.Text,
                            SDT = txtSDTBN.Text,
                            DiaChi = txtDiaChiBN.Text,
                            NgayKhamDau = System.DateTime.Now
                        };
                    benhnhan.Add(s);
                    clearContentBN();
                    MessageBox.Show("Thêm bệnh nhân thành công", "Thông báo", MessageBoxButtons.OK);
                    List<BenhNhan> listBN = benhnhan.GetAll();
                    FillBenhNhan(listBN);
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
            txtIDBN.Text = "";
            txtNamSinhBN.Text = "";
            txtSDTBN.Text = "";
            txtNameBN.Text = "";
            txtDiaChiBN.Text = "";
        }

        private void dgvBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                List<BenhNhan> listBN = benhnhan.GetAll();

                if (dgvBenhNhan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvBenhNhan.CurrentRow.Selected = true;
                    txtIDBN.Text = dgvBenhNhan.Rows[e.RowIndex].Cells["Column1"].FormattedValue.ToString();
                    txtNameBN.Text = dgvBenhNhan.Rows[e.RowIndex].Cells["Column2"].FormattedValue.ToString();
                    if (dgvBenhNhan.Rows[e.RowIndex].Cells["Column3"].FormattedValue.ToString() == "Nam")
                    {
                        radioMale.Checked = true;
                    }
                    else
                    {
                        radioFemale.Checked = true;
                    }
                    txtNamSinhBN.Text = dgvBenhNhan.Rows[e.RowIndex].Cells["Column4"].FormattedValue.ToString();
                    txtSDTBN.Text = dgvBenhNhan.Rows[e.RowIndex].Cells["Column5"].FormattedValue.ToString();
                    txtDiaChiBN.Text = dgvBenhNhan.Rows[e.RowIndex].Cells["Column6"].FormattedValue.ToString();
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
            if(txtIDBN.Text == "")
            {
                FillBenhNhan(listBN);
            }
        }

        private string setIDKham(string ID)
        {
            List<DanhSachKham> danhSachKhams = dskham.GetAllWithID(ID);

            if (danhSachKhams == null)
                return "001";
            else
            {
                int i = 1;
                foreach (var item in danhSachKhams)
                    i++;

                string stt = i.ToString();

                if (i < 10)
                    return stt.Insert(0, "00");
                else if (i < 100)
                    return stt.Insert(0, "0");

                return stt;
            }
        }

        private void dgvBenhNhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowCount = dgvBenhNhanDangKi.RowCount;
            string col = dgvBenhNhan.Columns[e.ColumnIndex].Name;
            if (col == "ColDKBN")
            {
                dgvBenhNhanDangKi.Rows.Add(rowCount.ToString(), dgvBenhNhan.Rows[e.RowIndex].Cells[0].Value.ToString(), dgvBenhNhan.Rows[e.RowIndex].Cells[1].Value.ToString(), dgvBenhNhan.Rows[e.RowIndex].Cells[3].Value.ToString(), dgvBenhNhan.Rows[e.RowIndex].Cells[4].Value.ToString(), dgvBenhNhan.Rows[e.RowIndex].Cells[5].Value.ToString(), "0 đồng".ToString());
                
                DanhSachKham ds = new DanhSachKham() 
                { 
                    IDBenhNhan = txtIDBN.Text, 
                    IDKham = setIDKham(txtIDBN.Text), 
                    MaNV = null, 
                    NgayKham = System.DateTime.Now 
                };
                dskham.Add(ds);

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
                            int rowIndex = dgvBenhNhanDangKi.SelectedRows[i].Index;
                            dgvBenhNhanDangKi.Rows.RemoveAt(rowIndex);
                            MessageBox.Show("Trả bệnh nhân thành công !");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
              
            }
        }

        private void dgvBenhNhanDangKi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvBenhNhanDangKi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvBenhNhanDangKi.CurrentRow.Selected = true;
                    txtIDBN.Text = dgvBenhNhanDangKi.Rows[e.RowIndex].Cells["Column8"].FormattedValue.ToString();
                    txtNameBN.Text = dgvBenhNhanDangKi.Rows[e.RowIndex].Cells["Column9"].FormattedValue.ToString();
                    txtNamSinhBN.Text = dgvBenhNhanDangKi.Rows[e.RowIndex].Cells["Column10"].FormattedValue.ToString();
                    txtSDTBN.Text = dgvBenhNhanDangKi.Rows[e.RowIndex].Cells["Column11"].FormattedValue.ToString();
                    txtDiaChiBN.Text = dgvBenhNhanDangKi.Rows[e.RowIndex].Cells["Column12"].FormattedValue.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            tabTrangChu.Visible = false;
        }

        private void BindDSKham(string id)
        {
            List<DanhSachKham> danhSachKhams = dskham.GetAllWithID(id);

            dgvBenhNhanKham.Rows.Clear();

            foreach(var item in danhSachKhams)
            {
                int index = dgvBenhNhanKham.Rows.Add();
                dgvBenhNhanKham.Rows[index].Cells[0].Value = item.IDKham;
                dgvBenhNhanKham.Rows[index].Cells[1].Value = item.NgayKham;
                dgvBenhNhanKham.Rows[index].Cells[2].Value = item.BenhNhan.HoTen;
                dgvBenhNhanKham.Rows[index].Cells[3].Value = 0;
            }
        }

        private void menustripKhamBenh_Click(object sender, EventArgs e)
        {
            tabTrangChu.Visible = true;
            tabKhamBenh.Parent = tabTrangChu;
            tabNguoiDung.Parent = null;
            tabTiepNhan.Parent = null;

            BindDSKham(txtIDBN.Text);
        }

        private void menustripThuoc_Click(object sender, EventArgs e)
        {
            tabTrangChu.Visible = true;
            tabTiepNhan.Parent = null;
            tabKhamBenh.Parent = null;
            tabNguoiDung.Parent = null;
        }

        private void menustripThongKe_Click(object sender, EventArgs e)
        {
            tabTrangChu.Visible = true;
            tabTiepNhan.Parent = null;
            tabKhamBenh.Parent = null;
            tabNguoiDung.Parent = null;
        }

        private void dgvBenhNhanKham_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBenhNhanKham.SelectedRows[0].Cells[0].Value != null)
            {
                if (dgvBenhNhanKham.SelectedRows[0].Cells[3].Value.ToString() == "0")
                    btnTaoDieuTri.Enabled = true;
                else
                    btnTaoDieuTri.Enabled = false;

                DanhSachKham ds = dskham.TimTheoIDKham(dgvBenhNhanKham.SelectedRows[0].Cells[0].Value.ToString());
                if (ds.MaNV != null)
                    cmbBacSi.SelectedValue = ds.MaNV;

                CanLamSang cls = canlamsang.GetWithIDKham(ds.IDKham);
                if (cls != null)
                {
                    txtHuyetAp.Text = cls.HuyetAp.ToString();
                    txtMach.Text = cls.Mach.ToString();
                    txtBaoHanh.Text = cls.BaoHanh;
                    txtKhac.Text = cls.Khac;
                    txtDuong.Text = cls.DuongHuyet;

                    if (cls.MauKhoDong == true)
                        rdoMauTS.Checked = true;
                    else
                        rdoMauTC.Checked = true;

                    if (cls.BenhTim == true)
                        rdoTimCo.Checked = true;
                    else
                        rdoTimKhong.Checked = true;

                    if (cls.ThieuNang == true)
                        rdoTNangCo.Checked = true;
                    else
                        rdoTNangKhong.Checked = true;
                }
            }
        }

        private void BindGridDieuTri()
        {
            List<DichVu> dichVus = dichvu.GetAll();
            dgvDieuTri.Rows.Clear();

            foreach (var item in dichVus)
            {
                int index = dgvDieuTri.Rows.Add();

                dgvDieuTri.Rows[index].Cells[0].Value = item.IDDichVu;
                dgvDieuTri.Rows[index].Cells[1].Value = item.TenDichVu;
                dgvDieuTri.Rows[index].Cells[2].Value = item.DonViTinh;
                dgvDieuTri.Rows[index].Cells[3].Value = item.DonGia.ToString();
                dgvDieuTri.Rows[index].Cells[4].Value = "0";
                dgvDieuTri.Rows[index].Cells[5].Value = "0";
            }
        }

        private void btnTaoDieuTri_Click(object sender, EventArgs e)
        {
            BindGridDieuTri();
        }

        private void btnLuuInfoKham_Click(object sender, EventArgs e)
        {
            string idkham = dgvBenhNhanKham.SelectedRows[0].Cells[0].Value.ToString();

            dskham.UpdateMaNV(cmbBacSi.SelectedValue.ToString(), idkham);

            CanLamSang cls = new CanLamSang()
            {
                IDKham = idkham,
                BaoHanh = txtBaoHanh.Text,
                BenhTim = rdoTimCo.Checked,
                DuongHuyet = txtDuong.Text,
                HuyetAp = int.Parse(txtHuyetAp.Text),
                Khac = txtKhac.Text,
                Mach = int.Parse(txtMach.Text),
                MauKhoDong = rdoMauTS.Checked,
                ThieuNang = rdoTNangCo.Checked
            };

            canlamsang.AddUpdate(cls);

            for (int i = 0; i < dgvDieuTri.Rows.Count; i++)
            {
                if (int.Parse(dgvDieuTri.Rows[i].Cells[4].Value.ToString()) > 0)
                {
                    DieuTri dt = new DieuTri()
                    {
                        IDKham = dgvBenhNhanKham.SelectedRows[0].Cells[0].Value.ToString(),
                        IDDichVu = dgvDieuTri.Rows[i].Cells[0].Value.ToString(),
                        IDDungCu = "DC01",
                        SoLuong = int.Parse(dgvDieuTri.Rows[i].Cells[4].Value.ToString()),
                        ThanhTien = int.Parse(dgvDieuTri.Rows[i].Cells[5].Value.ToString())
                    };
                    dieutri.Add(dt);

                    kho.TruDungCu(int.Parse(dgvDieuTri.Rows[i].Cells[4].Value.ToString()), "DC01");

                    Kho kh = kho.FindByIDDungCu("DC01");

                    LichSuNhapXuat ls = new LichSuNhapXuat()
                    {
                        NoiDung = false,
                        IDDungCu = kh.IDDungCu,
                        TenDungCu = kh.TenDungCu,
                        Loai = kh.Loai,
                        DonViTinh = kh.DonViTinh,
                        SoLuongNhapXuat = dt.SoLuong,
                        Don = kh.ThiTruong.DonGia,
                        ThanhTien = dt.SoLuong * kh.ThiTruong.DonGia,
                        NgayNhap = dskham.TimTheoIDKham(idkham).NgayKham
                    };

                    lichsu.AddEntry(ls);
                }
            }
        }

        private void dgvDieuTri_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                float sum = 0;

                for (int i = 0; i < dgvDieuTri.Rows.Count; i++)
                {
                    if (dgvDieuTri.Rows[i].Cells[5].Value != null)
                    {
                        dgvDieuTri.Rows[i].Cells[5].Value =
                            (float.Parse(dgvDieuTri.Rows[i].Cells[3].Value.ToString())
                            * float.Parse(dgvDieuTri.Rows[i].Cells[4].Value.ToString())).ToString();

                        sum += float.Parse(dgvDieuTri.Rows[i].Cells[5].Value.ToString());
                    }
                }

                txtTongDieuTri.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

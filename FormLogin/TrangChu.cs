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
        private readonly VatTuService ms = new VatTuService();
        private readonly ThiTruongService thitruong = new ThiTruongService();
        private readonly HoaDonService hoadon = new HoaDonService();
        
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
            tabThongKe.Parent = null;
            tabDVT.Parent = null;
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
            List<BacSi> bacSis = nguoidung.GetBacSi();
            cmbBacSi.DataSource = bacSis;
            cmbBacSi.DisplayMember = "Ten";
            cmbBacSi.ValueMember = "MaNV";
        }

        private void menustripNguoiDung_Click(object sender, EventArgs e)
        {
            tabTrangChu.Visible = true;
            tabNguoiDung.Parent = tabTrangChu;
            tabTiepNhan.Parent = null;
            tabKhamBenh.Parent = null;
            tabThongKe.Parent = null;
            tabDVT.Parent = null;
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

                    BenhNhan temp = benhnhan.FindNameBenhNhan(txtNameBN.Text);
                    if (temp != null)
                        throw new Exception("Đã tồn tại bệnh nhân với họ tên đó");

                    BenhNhan s = new BenhNhan()
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
            }
        }

        private void menustripKhamBenh_Click(object sender, EventArgs e)
        {
            tabTrangChu.Visible = true;
            tabKhamBenh.Parent = tabTrangChu;
            tabNguoiDung.Parent = null;
            tabTiepNhan.Parent = null;
            tabThongKe.Parent = null;
            tabDVT.Parent = null;

            BindDSKham(txtIDBN.Text);
        }

        private void menustripThuoc_Click(object sender, EventArgs e)
        {
            tabTrangChu.Visible = true;
            tabDVT.Parent = tabTrangChu;
            tabTiepNhan.Parent = null;
            tabKhamBenh.Parent = null;
            tabNguoiDung.Parent = null;
            tabThongKe.Parent = null;
        }

        private void menustripThongKe_Click(object sender, EventArgs e)
        {
            tabTrangChu.Visible = true;
            tabThongKe.Parent = tabTrangChu;
            tabTiepNhan.Parent = null;
            tabKhamBenh.Parent = null;
            tabNguoiDung.Parent = null;
            tabDVT.Parent = null;
        }

        private void dgvBenhNhanKham_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBenhNhanKham.SelectedRows[0].Cells[0].Value != null)
            {
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

                List<DieuTri> dieuTris = dieutri.GetAllWithID(dgvBenhNhanKham.SelectedRows[0].Cells[0].Value.ToString());

                if (dieuTris != null)
                {
                    BindGridDieuTri();
                    btnTaoDieuTri.Enabled = false;

                    foreach (var item in dieuTris)
                        for (int i = 0; i < dgvDieuTri.Rows.Count; i++)
                        {
                            if (dgvDieuTri.Rows[i].Cells[0].Value.ToString() == item.IDDichVu)
                            {
                                dgvDieuTri.Rows[i].Cells[4].Value = item.SoLuong;
                                break;
                            }
                        }
                }
                else
                    btnTaoDieuTri.Enabled = true;
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

            List<DieuTri> dieuTris = dieutri.GetAllWithID(dgvBenhNhanKham.SelectedRows[0].Cells[0].Value.ToString());
            
            if (dieuTris == null)
            {
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
                MessageBox.Show("Lưu thông tin khám và thông tin điều trị thành công!");
            }
            MessageBox.Show("Lưu thông tin khám thành công!");
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
                            kho.CongDungCu(int.Parse(txtSL.Text), txtMa.Text);
                            clearContentVatTuNhap();
                        }
                        else if (rdoXuat.Checked == true && ms.FindIDKho(txtMa.Text) != null)
                        {
                            Kho k = kho.FindByIDDungCu(txtMa.Text);

                            if (k.SoLuong < int.Parse(txtSL.Text))
                            {
                                throw new Exception("Số lượng xuất lớn hơn số lượng tồn");
                            }

                            kho.TruDungCu(int.Parse(txtSL.Text), k.IDDungCu);
                            clearContentVatTuNhap();
                        }
                        else
                        {
                            throw new Exception("Chỉ được truy suất vào các mặt hàng có sẵn trên thị trường");
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
            BindGridThiTruong(thitruong.GetAll());
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            FormKho frm = new FormKho();
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
            FormLichSuNhapXuat frm = new FormLichSuNhapXuat();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void cboFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvThiTruong.Rows.Count; i++)
            {
                if (cboFind.SelectedItem.ToString() == dgvThiTruong.Rows[i].Cells[2].Value.ToString())
                {
                    dgvThiTruong.Rows[i].Visible = true;
                }
                else
                {
                    dgvThiTruong.Rows[i].Visible = false;
                }
            }
        }
        private void BindGridDoanhThu(List<HoaDon> Bill)
        {
            dgvDoanhThu.Rows.Clear();
            foreach (var item in Bill)
            {
                int index = dgvThongKeVT.Rows.Add();
                dgvDoanhThu.Rows[index].Cells[0].Value = item.IDHoaDon.ToString();
                dgvDoanhThu.Rows[index].Cells[1].Value = item.DanhSachKham.BenhNhan.HoTen.ToString();
                dgvDoanhThu.Rows[index].Cells[2].Value = item.PhuongThucThanhToan.ToString();
                dgvDoanhThu.Rows[index].Cells[3].Value = item.TongTien.ToString();
                dgvDoanhThu.Rows[index].Cells[4].Value = item.NgayLap.ToString();

            }
        }

        private void tabThongKe_Enter(object sender, EventArgs e)
        {
            dtpMonth.CustomFormat = "MM/yyyy";
            dtpMonth.Format = DateTimePickerFormat.Custom;
            dtpYear.CustomFormat = "yyyy";
            dtpYear.Format = DateTimePickerFormat.Custom;
            dtpQuy.CustomFormat = "yyyy";
            dtpQuy.Format = DateTimePickerFormat.Custom;
            dtpMonthDT.CustomFormat = "MM/yyyy";
            dtpMonthDT.Format = DateTimePickerFormat.Custom;
            dtpYearDT.CustomFormat = "yyyy";
            dtpYearDT.Format = DateTimePickerFormat.Custom;
            dtpQuiDT.CustomFormat = "yyyy";
            dtpQuiDT.Format = DateTimePickerFormat.Custom;
            BindGridTK(lichsu.GetAll());
            BindGridDoanhThu(hoadon.GetAll());
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
            BindGridTK(lichsu.GetAll());
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
                    MessageBox.Show("Ban can phai chon nut thong kê");
                    break;
                }
            }
        }

        private void dtpMonth_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvThongKeVT.Rows.Count; i++)
            {

                if (dtpMonth.Value.Month.ToString() == DateTime.Parse(dgvThongKeVT.Rows[i].Cells[8].Value.ToString()).Month.ToString()
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

        private void tabDVT_Enter(object sender, EventArgs e)
        {
            BindGridThiTruong(thitruong.GetAll());
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

        private void btnTKDoanhThu_Click(object sender, EventArgs e)
        {
            decimal TienTong = 0;
            for (int i = 0; i < dgvDoanhThu.Rows.Count; i++)
            {
                if (rdoMonthDT.Checked)
                {
                    if (dtpMonthDT.Value.Month.ToString() == DateTime.Parse(dgvDoanhThu.Rows[i].Cells[4].Value.ToString()).Month.ToString()
                        && dtpYearDT.Value.Year.ToString() == DateTime.Parse(dgvDoanhThu.Rows[i].Cells[4].Value.ToString()).Year.ToString())
                    {

                        TienTong += decimal.Parse(dgvThongKeVT.Rows[i].Cells[3].Value.ToString());
                        txtTongDT.Text = TienTong.ToString();
                    }
                }
                else if (rdoYearDT.Checked)
                {

                    if (dtpYearDT.Value.Year.ToString() == DateTime.Parse(dgvDoanhThu.Rows[i].Cells[4].Value.ToString()).Year.ToString())
                    {

                        TienTong += decimal.Parse(dgvThongKeVT.Rows[i].Cells[3].Value.ToString());
                        txtTongDT.Text = TienTong.ToString();
                    }
                }
                else if (rdoQuiDT.Checked)
                {
                    if (dtpQuiDT.Value.Year.ToString() == DateTime.Parse(dgvDoanhThu.Rows[i].Cells[4].Value.ToString()).Year.ToString())
                    {
                        int quy = cboQuiDT.SelectedIndex;
                        int transactionQuarter =
                              (int.Parse(DateTime.Parse(dgvDoanhThu.Rows[i].Cells[4].Value.ToString()).Month.ToString()) - 1) / 3;
                        if (transactionQuarter == quy)
                        {
                            TienTong += decimal.Parse(dgvThongKeVT.Rows[i].Cells[3].Value.ToString());
                            txtTongDT.Text = TienTong.ToString();
                            txtTongDT.Text = TienTong.ToString();
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Ban can phai chon nut thong kê");
                    break;
                }
            }
        }

        private void rdoNV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNV.Checked == true)
            {
                List<BacSi> nhanViens = nguoidung.GetNhanVien();

                FillRegistered(nhanViens);
            }
        }

        private void rdoBS_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBS.Checked == true)
            {
                List<BacSi> bacSis = nguoidung.GetBacSi();

                FillRegistered(bacSis);
            }
        }
    }
}

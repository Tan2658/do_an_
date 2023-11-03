using BUS;
using DAL.Data;
using Microsoft.Reporting.WinForms;
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
    public partial class RPViewHoaDon : Form
    {
        private readonly NguoiDungService nguoidung = new NguoiDungService();
        private readonly TaiKhoanService taikhoan = new TaiKhoanService();
        private readonly BenhNhanService benhnhan = new BenhNhanService();
        private readonly DSKham benhnhankham = new DSKham();
        private readonly HoaDonService hoadon = new HoaDonService();

        public RPViewHoaDon()
        {
            InitializeComponent();
        }

        private void RPViewHoaDon_Load(object sender, EventArgs e)
        {
            var listDSKham = benhnhankham.GetAll();
            var listHoaDon = hoadon.GetAll();  
            List<DanhSachKham> formDSKham  = new List<DanhSachKham>();
            List<HoaDon> formReportViews = new List<HoaDon>();
            List<BenhNhan> benhNhans = new List<BenhNhan>();
            foreach (var item in listDSKham)
            {
                foreach (var item2 in listHoaDon) {

                    if(item.IDKham == item2.IDKham )
                    {
                        BenhNhan temp1 = new BenhNhan();
                        HoaDon temp = new HoaDon();
                      temp.TienThuoc = item2.TienThuoc;
                      temp.TienDieuTri = item2.TienDieuTri;
                      temp.NgayLap = item2.NgayLap;
                      temp.TongTien = item2.TongTien;
                      temp.IDKham = item2.IDKham;   
                      foreach(var item3 in benhNhans)
                       {
                            temp1.HoTen = item3.HoTen;
                            temp1.DiaChi = item3.DiaChi;
                            benhNhans.Add(temp1);
                       }
                        formReportViews.Add(temp);
                        break;
                    }
                }
               break;
            }
            reportViewer1.LocalReport.ReportPath = "RPHoaDon.rdlc";
            var source = new ReportDataSource("DataSet1", formReportViews);
            var source2 = new ReportDataSource("DataSet2", formDSKham);
            var source1 = new ReportDataSource("DataSet3", benhNhans);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.LocalReport.DataSources.Add(source1);
            reportViewer1.LocalReport.DataSources.Add(source2);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}

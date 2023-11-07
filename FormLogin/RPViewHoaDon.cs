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
using Microsoft.Reporting.WinForms;
using DAL.Data;

namespace FormLogin
{
    public partial class RPViewHoaDon : Form
    {
        public RPViewHoaDon()
        {
            InitializeComponent();
        }

        HoaDonReportInfo hd;
        public RPViewHoaDon(HoaDonReportInfo incomingInfo)
        {
            InitializeComponent();
            hd = incomingInfo;
        }

        private void RPViewHoaDon_Load(object sender, EventArgs e)
        {
            List<HoaDon> hoaDons = new List<HoaDon>();
            List<BenhNhan> benhNhans = new List<BenhNhan>();

            bool gioi;

            if (hd.HDGioi == "Nam")
                gioi = true;
            else
                gioi = false;

            BenhNhan rpbn = new BenhNhan()
            {
                IDBenhNhan = hd.HDMaBenhNhan,
                HoTen = hd.HDHoTen,
                Gioi = gioi,
                NamSinh = hd.HDNamSinh,
                SDT = hd.HDSDT,
                DiaChi = hd.HDDiaChi
            };
            benhNhans.Add(rpbn);

            HoaDon rphd = new HoaDon()
            {
                IDHoaDon = "",
                PhuongThucThanhToan = hd.HDDichVuThanhToan,
                TienThuoc = decimal.Parse(hd.HDTienThuoc),
                TienDieuTri = decimal.Parse(hd.HDTienDichVu),
                TongTien = decimal.Parse(hd.HDTienTong),
                NgayLap = hd.HDNgayLap,
            };
            hoaDons.Add(rphd);

            var sourceHoaDon = new ReportDataSource("DataSetHoaDon", hoaDons);
            var sourceBenhNhan = new ReportDataSource("DataSetBenhNhan", benhNhans);
            RPVHoaDon.LocalReport.DataSources.Clear();
            RPVHoaDon.LocalReport.DataSources.Add(sourceHoaDon);
            RPVHoaDon.LocalReport.DataSources.Add(sourceBenhNhan);
            this.RPVHoaDon.RefreshReport();
        }
    }
}

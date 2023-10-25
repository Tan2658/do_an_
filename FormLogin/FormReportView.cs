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
using DAL.Data;
using Microsoft.Reporting.WinForms;
using System.Reflection;

namespace FormLogin
{
    public partial class FormReportView : Form
    {
        private readonly NguoiDungService nguoidung = new NguoiDungService();
        private readonly TaiKhoanService taikhoan = new TaiKhoanService();
        private readonly BenhNhanService benhnhan = new BenhNhanService();
        ReportDataSource rp = new ReportDataSource();
        DentalContextDB db = new DentalContextDB();
        public FormReportView()
        {
            InitializeComponent();
        }

        private void FormReportView_Load(object sender, EventArgs e)
        {
            var listBenhNhan = benhnhan.GetAll();
            BacSi getBacSi = nguoidung.getDoctorManyexperience("Bác sĩ A");
            List<BacSi> formBacSi = new List<BacSi>();  
            List<BenhNhan> formReportViews = new List<BenhNhan>();
            foreach (var item in listBenhNhan)
            {
                BenhNhan temp = new BenhNhan();
                temp.HoTen = item.HoTen;
                temp.NamSinh = item.NamSinh;
                temp.DiaChi = item.DiaChi;
                temp.NgayKhamDau = item.NgayKhamDau;
                formReportViews.Add(temp);
            }
            BacSi temp1 = new BacSi();
                temp1.Ten = getBacSi.Ten;
            formBacSi.Add(temp1);

            reportViewer1.LocalReport.ReportPath = "ReportDSDK.rdlc";
            var source = new ReportDataSource("DataSet1", formReportViews);
            var source1 = new ReportDataSource("DataSet2", formBacSi);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.LocalReport.DataSources.Add(source1);
            this.reportViewer1.RefreshReport();
        }
    }
}

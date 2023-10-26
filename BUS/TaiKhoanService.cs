using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Data;

namespace BUS
{
    public class TaiKhoanService
    {
        public List<TaiKhoan> GetAll()
        {
            DentalContextDB context = new DentalContextDB();
            return context.TaiKhoans.ToList();
        }
        public List<TaiKhoan> GetTKNV()
        {
            DentalContextDB context = new DentalContextDB();
            return context.TaiKhoans.Where(p => p.MatKhau.Contains("nhanvien")).ToList();
        }
        public TaiKhoan GetTaiKhoan(string name)
        {
            DentalContextDB contextDB = new DentalContextDB();
            return contextDB.TaiKhoans.FirstOrDefault(p => p.TenDangNhap == name && p.TenDangNhap.Contains("admin") || p.TenDangNhap.Contains("nhanvien"));
        }

   
        public void InsertUpdate(TaiKhoan s)
        {
            DentalContextDB context = new DentalContextDB();
            context.TaiKhoans.AddOrUpdate(s);
            context.SaveChanges();
        }
    }
}

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
    public class NguoiDungService
    {
        public List<BacSi> GetAll()
        {
            DentalContextDB db = new DentalContextDB();
            return db.BacSis.ToList();
        }
        //public List<BacSi> GetRegisted()
        //{
        //    DentalContextDB db = new DentalContextDB();
        //    return db.BacSis.Where(p => p.TrangThai == "Sử Dụng" || p.TrangThai == "No Sử Dụng").ToList();
        //}
        //public List<BacSi> GetRegister()
        //{
        //    DentalContextDB db = new DentalContextDB();
        //    return db.BacSis.Where(p => p.TrangThai == "Đăng kí").ToList();
        //}
        public void InsertUpdate(BacSi bacSi)
        {
            DentalContextDB db = new DentalContextDB();
            db.BacSis.AddOrUpdate(bacSi);
            db.SaveChanges();
        }
        //public List<BacSi> SortRegisted()
        //{
        //    DentalContextDB db = new DentalContextDB();
        //    return db.BacSis.Where(p => p.TrangThai == "Sử Dụng" || p.TrangThai == "No Sử Dụng").OrderBy(p => p.Ten).ToList();
        //}
        //// test
        //public List<BacSi> SortRegister()
        //{
        //    DentalContextDB db = new DentalContextDB();
        //    return db.BacSis.Where(p => p.TrangThai == "Đăng kí").OrderBy(p => p.Ten).ToList();
        //}
        public BacSi findByExperience(string experience)
        {
            DentalContextDB db = new DentalContextDB();
            return db.BacSis.FirstOrDefault(p => p.KinhNghiem == experience);
        }
        public BacSi findByName(string name)
        {
            DentalContextDB db = new DentalContextDB();
            return db.BacSis.FirstOrDefault(p => p.Ten == name);
        }
    }
}
    
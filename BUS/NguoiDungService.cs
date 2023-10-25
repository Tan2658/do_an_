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
      public List<BacSi> GetAllDoctor()
      {
         DentalContextDB db = new DentalContextDB();
       return db.BacSis.Where(p => p.ChucVu == "Bác Sĩ").ToList();
      }
       public List<BacSi> GetAllStaff()
      {
           DentalContextDB db = new DentalContextDB();
           return db.BacSis.Where(p => p.ChucVu == "Nhân Viên").ToList();
       }
        public void InsertUpdate(BacSi bacSi)
        {
            DentalContextDB db = new DentalContextDB();
            db.BacSis.AddOrUpdate(bacSi);
            db.SaveChanges();
        }
        public BacSi getDoctorManyexperience(string name)
        {
            DentalContextDB db = new DentalContextDB();
            return db.BacSis.FirstOrDefault(b => b.Ten == name);
        }
    }
}
    
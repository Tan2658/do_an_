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
            return db.BacSi.ToList();
        }

        public List<BacSi> GetRegisted()
        {
            DentalContextDB db = new DentalContextDB();
            return db.BacSi.ToList();
        }
        public void InsertUpdate(BacSi bacSi)
        {
            DentalContextDB db = new DentalContextDB();
            db.BacSi.AddOrUpdate(bacSi);
            db.SaveChanges();
        }
        public List<BacSi> SortRegisted()
        {
            DentalContextDB db = new DentalContextDB();
            return db.BacSi.OrderBy(p => p.Ten).ToList();
        }

        public BacSi findByExperience(string experience)
        {
            DentalContextDB db = new DentalContextDB();
            return db.BacSi.FirstOrDefault(p => p.KinhNghiem == experience);
        }
        public BacSi findByName(string name)
        {
            DentalContextDB db = new DentalContextDB();
            return db.BacSi.FirstOrDefault(p => p.Ten == name);
        }
    }
}
    
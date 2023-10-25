using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;


namespace BUS
{
    public class BenhNhanService
    {
        public List<BenhNhan> GetAll()
        {
            DentalContextDB db1 = new DentalContextDB();
            return db1.BenhNhan.ToList();
        }
        public BenhNhan FindIDBenhNhan(string idBenhNhan)
        {
            DentalContextDB db1 = new DentalContextDB ();
            return db1.BenhNhan.FirstOrDefault(p => p.IDBenhNhan == idBenhNhan);
        }
        public List<BenhNhan> FindBenhNhanWithMonth(int startMonth, int endMonth)
        {
            DentalContextDB db1 = new DentalContextDB();
            return db1.BenhNhan.Where(p => p.NgayKhamDau.Value.Month <= endMonth && p.NgayKhamDau.Value.Month >= startMonth).ToList();
        }

        public void Add(BenhNhan bn)
        {
            DentalContextDB db1 = new DentalContextDB();
            db1.BenhNhan.Add(bn);
            db1.SaveChanges();
        }

        public void Delete(string ID)
        {
            DentalContextDB db1 = new DentalContextDB();
            BenhNhan dbDelete = db1.BenhNhan.FirstOrDefault(p => p.IDBenhNhan == ID);
            if (dbDelete != null)
            {
                db1.BenhNhan.Remove(dbDelete);
                db1.SaveChanges();
            }
        }
    }
}

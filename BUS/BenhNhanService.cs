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
            return db1.BenhNhan.Where(p => p.NgayKhamDau.Month < endMonth && p.NgayKhamDau.Month > startMonth).ToList();
        }
    }
}

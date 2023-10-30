using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public  class ThuocService
    {
        public void AddUpdate(DonThuoc cls)
        {
            DentalContextDB context = new DentalContextDB();

            DonThuoc db = context.DonThuoc.FirstOrDefault(q => q.IDKham == cls.IDKham);

            if (db == null)
            {
                context.DonThuoc.Add(cls);
                context.SaveChanges();
            }
            else
            {
                db.IDDonThuoc = cls.IDDonThuoc;
                db.IDKham = cls.IDKham;
                db.TongTien = cls.TongTien;
                db.NgayLapDT = cls.NgayLapDT;
                context.SaveChanges();
            }
        }
        public List<Kho> GetAllMedicine(string name)
        {
            DentalContextDB context = new DentalContextDB();
            return context.Kho.Where(q => q.Loai == name).ToList();
        }
        public List<DonThuoc> GetAllWithID(string id)
        {
            DentalContextDB context = new DentalContextDB();
            return context.DonThuoc.Where(q => q.IDKham == id).ToList();
        }
    }
}

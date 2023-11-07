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
        public void AddUpdate(DonThuoc dt)
        {
            DentalContextDB context = new DentalContextDB();

            DonThuoc db = context.DonThuoc.FirstOrDefault(q => q.IDKham == dt.IDKham);

            if (db == null)
            {
                context.DonThuoc.Add(dt);
                context.SaveChanges();
            }
            else
            {
                db.IDDonThuoc = dt.IDDonThuoc;
                db.IDKham = dt.IDKham;
                db.TongTien = dt.TongTien;
                db.NgayLapDT = dt.NgayLapDT;
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

        public List<DonThuoc> GetDonThuoc()
        {
            DentalContextDB context = new DentalContextDB();
            return context.DonThuoc.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;

namespace BUS
{
    public class CanLamSangService
    {
        public CanLamSang GetWithIDKham(string id)
        {
            DentalContextDB context = new DentalContextDB();
            return context.CanLamSang.FirstOrDefault(q => q.IDKham == id);
        }

        public void AddUpdate(CanLamSang cls)
        {
            DentalContextDB context = new DentalContextDB();

            CanLamSang db = context.CanLamSang.FirstOrDefault(q => q.IDKham == cls.IDKham);

            if (db == null)
            {
                context.CanLamSang.Add(cls);
                context.SaveChanges();
            }
            else
            {
                db.HuyetAp = cls.HuyetAp;
                db.Khac = cls.Khac;
                db.Mach = cls.Mach;
                db.MauKhoDong = cls.MauKhoDong;
                db.ThieuNang = cls.ThieuNang;
                db.BenhTim = cls.BenhTim;
                db.BaoHanh = cls.BaoHanh;
                context.SaveChanges();
            }
        }
    }
}

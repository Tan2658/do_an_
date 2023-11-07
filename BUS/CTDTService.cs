using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CTDTService
    {
        public void AddDonThuoc(CTDonThuoc cls)
        {
            DentalContextDB context = new DentalContextDB();

            CTDonThuoc db = context.CTDonThuoc.FirstOrDefault(q => q.TenThuoc == cls.TenThuoc);

            if (db == null)
            {
                context.CTDonThuoc.Add(cls);
                context.SaveChanges();
            }
            else
            {
                if (db.IDDonThuoc != cls.IDDonThuoc)
                {
                    context.CTDonThuoc.Add(cls);
                    context.SaveChanges();
                }
                else
                {
                    db.SoLuong = cls.SoLuong;
                    db.ThanhGia = cls.ThanhGia;
                    context.SaveChanges();
                }
            }
        }
    }
}

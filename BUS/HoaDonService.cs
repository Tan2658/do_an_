using DAL.Data;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class HoaDonService
    {
        public List<HoaDon> GetAll()
        {
            DentalContextDB context = new DentalContextDB();
            return context.HoaDon.ToList();
        }

        public HoaDon GetWithID(string id)
        {
            DentalContextDB context = new DentalContextDB();
            return context.HoaDon.FirstOrDefault(q => q.IDKham == id);
        }

        public void AddUpdate(HoaDon hd)
        {
            DentalContextDB context = new DentalContextDB();
            HoaDon db = context.HoaDon.FirstOrDefault(q => q.IDHoaDon == hd.IDHoaDon);

            if (db == null)
            {
                context.HoaDon.Add(hd);
                hd.TongTien = hd.TienThuoc + hd.TienDieuTri;
                context.SaveChanges();
            }
            else
            {
                db.IDHoaDon = hd.IDHoaDon;
                db.IDKham = hd.IDKham;
                if (hd.PhuongThucThanhToan != null)
                    db.PhuongThucThanhToan = hd.PhuongThucThanhToan;
                if (hd.TienThuoc != 0)
                    db.TienThuoc = hd.TienThuoc;
                if (hd.TienDieuTri != 0)
                    db.TienDieuTri = hd.TienDieuTri;
                db.TongTien = db.TienThuoc + db.TienDieuTri;
                if (hd.NgayLap != null)
                    db.NgayLap = hd.NgayLap;
                context.SaveChanges();
            }
        }
    }
}

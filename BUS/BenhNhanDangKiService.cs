using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using System.Data.Entity.Migrations;

namespace BUS
{
    public class BenhNhanDangKiService
    {
        public List<DanhSachKham> GetAll()
        {
            DentalContextDB db1 = new DentalContextDB();
            return db1.DanhSachKhams.ToList();
        }
        public void InsertUpdateDanhSachKham(DanhSachKham bn)
        {
            DentalContextDB db = new DentalContextDB();
            db.DanhSachKhams.AddOrUpdate(bn);
            db.SaveChanges();
        }
    }
}

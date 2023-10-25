using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
            return db1.BenhNhans.ToList();
        }
      
        public List<BenhNhan> FindBenhNhanWithMonth(int startMonth, int endMonth)
        {
            DentalContextDB db1 = new DentalContextDB();
            return db1.BenhNhans.Where(p => p.NgayKhamDau.Value.Month < endMonth && p.NgayKhamDau.Value.Month > startMonth).ToList();
        }
        public BenhNhan findNameBenhNhan(string nameBN)
        {
            DentalContextDB db1 = new DentalContextDB();
            return db1.BenhNhans.FirstOrDefault(b => b.HoTen == nameBN);
        }
        public void removeBenhNhan(string name)
        {
            DentalContextDB context = new DentalContextDB();
            var entity = context.BenhNhans.Find(name);
            if (entity != null)
            {
                var entry = context.Entry(entity);
                if (entry.State == EntityState.Detached)
                {
                    // Đối tượng đã bị tách (detached)
                    // Hãy đính kèm (attach) đối tượng vào DbContext trước khi thực hiện xóa
                    context.BenhNhans.Attach(entity);
                }

                // Thực hiện xóa đối tượng
                context.BenhNhans.Remove(entity);
                context.SaveChanges();
            }
        }
        public void InsertUpdate(BenhNhan benhnhan)
        {
            DentalContextDB db = new DentalContextDB();
            db.BenhNhans.AddOrUpdate(benhnhan);
            db.SaveChanges();
        }
        public void SaveChanges()
        {
            DentalContextDB context = new DentalContextDB();
            context.SaveChanges();
        }
      
    }
}

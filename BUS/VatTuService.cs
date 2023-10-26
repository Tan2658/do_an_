using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;

namespace BUS
{
    public class VatTuService
    {
        public LichSuNhapXuat FindIDLS(string id)
        {
            DentalContextDB context = new DentalContextDB();
            return context.LichSuNhapXuat.FirstOrDefault(p => p.IDDungCu == id);
        }
        public Kho FindIDKho(string id)
        {
            DentalContextDB context = new DentalContextDB();
            return context.Kho.FirstOrDefault(p => p.IDDungCu == id);
        }
        public ThiTruong FindIDThiTruong(string id)
        {
            DentalContextDB context = new DentalContextDB();
            return context.ThiTruong.FirstOrDefault(p => p.IDSanPham == id);
        }
        public void InsertUpdate(LichSuNhapXuat d)
        {
            DentalContextDB context = new DentalContextDB();
            context.LichSuNhapXuat.Add(d);
            context.SaveChanges();
        }
        public void InsertUpdate(Kho d)
        {
            DentalContextDB context = new DentalContextDB();
            context.Kho.Add(d);
            context.SaveChanges();
        }
        public List<Kho> GetAll()
        {
            DentalContextDB context = new DentalContextDB();
            return context.Kho.ToList();
        }
    }
}

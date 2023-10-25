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
            return context.LichSuNhapXuats.FirstOrDefault(p => p.IDDungCu == id);
        }
        public Kho FindIDKho(string id)
        {
            DentalContextDB context = new DentalContextDB();
            return context.Khoes.FirstOrDefault(p => p.IDDungCu == id);
        }
        public ThiTruong FindIDThiTruong(string id)
        {
            DentalContextDB context = new DentalContextDB();
            return context.ThiTruongs.FirstOrDefault(p => p.IDSanPham == id);
        }
        public void InsertUpdate(LichSuNhapXuat d)
        {
            DentalContextDB context = new DentalContextDB();
            context.LichSuNhapXuats.Add(d);
            context.SaveChanges();
        }
        public void InsertUpdate(Kho d)
        {
            DentalContextDB context = new DentalContextDB();
            context.Khoes.Add(d);
            context.SaveChanges();
        }
        public List<Kho> GetAll()
        {
            DentalContextDB context = new DentalContextDB();
            return context.Khoes.ToList();
        }
    }
}

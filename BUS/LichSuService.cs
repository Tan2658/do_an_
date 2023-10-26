using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;

namespace BUS
{
    public class LichSuService
    {
        public void AddEntry(LichSuNhapXuat ls)
        {
            DentalContextDB context = new DentalContextDB();
            context.LichSuNhapXuat.Add(ls);
            context.SaveChanges();
        }

        public List<LichSuNhapXuat> GetAll()
        {
            DentalContextDB context = new DentalContextDB();
            return context.LichSuNhapXuat.ToList();
        }
    }
}

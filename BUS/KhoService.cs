using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;

namespace BUS
{
    public class KhoService
    {
        public void TruDungCu(int sl, string id)
        {
            DentalContextDB context = new DentalContextDB();
            Kho db = context.Kho.FirstOrDefault(q => q.IDDungCu == id);
            db.SoLuong -= sl;
            context.SaveChanges();
        }

        public Kho FindByIDDungCu(string id)
        {
            DentalContextDB context = new DentalContextDB();
            return context.Kho.FirstOrDefault(q => q.IDDungCu == id);
        }
    }
}

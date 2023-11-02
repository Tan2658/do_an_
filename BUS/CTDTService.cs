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

            CTDonThuoc db = context.CTDonThuoc.FirstOrDefault(q => q.IDDonThuoc == cls.IDDonThuoc);

            context.CTDonThuoc.Add(cls);
            context.SaveChanges();
            
        }
    }
}

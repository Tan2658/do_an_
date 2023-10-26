using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;

namespace BUS
{
    public class HoaDonService
    {
        public List<HoaDon> GetAll()
        {
            DentalContextDB context = new DentalContextDB();
            return context.HoaDon.ToList();
        }
    }
}

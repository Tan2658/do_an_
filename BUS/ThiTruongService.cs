using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;

namespace BUS
{
    public class ThiTruongService
    {
        public List<ThiTruong> GetAll()
        {
            DentalContextDB context = new DentalContextDB();
            return context.ThiTruong.ToList();
        }
    }
}

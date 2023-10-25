using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;

namespace BUS
{
    public class DichVuService
    {
        public List<DichVu> GetAll()
        {
            DentalContextDB context = new DentalContextDB();
            return context.DichVu.ToList();
        }
    }
}

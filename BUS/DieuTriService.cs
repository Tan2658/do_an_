using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;

namespace BUS
{
    public class DieuTriService
    {
        public List<DieuTri> GetAllWithID(string id)
        {
            DentalContextDB context = new DentalContextDB();
            return context.DieuTri.Where(q => q.IDKham == id).ToList();
        }
    }
}

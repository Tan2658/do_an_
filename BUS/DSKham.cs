using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DSKham
    {
        public List<DanhSachKham> GetAll()
        {
            DentalContextDB context = new DentalContextDB();
            return context.DanhSachKhams.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;

namespace BUS
{
    public class DSKhamService
    {
        public List<DanhSachKham> GetAll()
        {
            DentalContextDB context = new DentalContextDB();
            return context.DanhSachKham.ToList();
        }

        public List<DanhSachKham> GetAllWithID(string ID)
        {
            DentalContextDB context = new DentalContextDB();
            return context.DanhSachKham.Where(q => q.IDBenhNhan == ID).ToList();
        }

        public DanhSachKham TimTheoIDKham(string ID)
        {
            DentalContextDB context = new DentalContextDB();
            return context.DanhSachKham.FirstOrDefault(q => q.IDKham == ID);
        }

        public void Add(DanhSachKham ds)
        {
            DentalContextDB context = new DentalContextDB();
            context.DanhSachKham.Add(ds);
            context.SaveChanges();
        }

        public void DeleteAllWithID(string id)
        {
            DentalContextDB context = new DentalContextDB();
            int flag = 1;
            do
            {
                DanhSachKham ds = context.DanhSachKham.FirstOrDefault(q => q.IDBenhNhan == id);

                if (ds != null)
                {
                    context.DanhSachKham.Remove(ds);
                    context.SaveChanges();
                }
                else
                    flag = -1;
            } while (flag != -1);
        }

        public void UpdateMaNV(string manv, string id)
        {
            DentalContextDB context = new DentalContextDB();

            DanhSachKham ds = context.DanhSachKham.FirstOrDefault(q => q.IDKham == id);

            ds.MaNV = manv;
            context.SaveChanges();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Data;

namespace BUS
{
    public class TaiKhoanService
    {
        public List<TaiKhoan> GetAll()
        {
            DentalContextDB context = new DentalContextDB();
            return context.TaiKhoan.ToList();
        }

        public void InsertUpdate(TaiKhoan s)
        {
            DentalContextDB context = new DentalContextDB();
            context.TaiKhoan.AddOrUpdate(s);
            context.SaveChanges();
        }

        public TaiKhoan TimTenTaiKhoan(string ten)
        {
            DentalContextDB context = new DentalContextDB();
            return context.TaiKhoan.FirstOrDefault(q => q.TenDangNhap == ten);
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Data
{
    public partial class DentalContextDB : DbContext
    {
        public DentalContextDB()
            : base("name=DentalContextDB")
        {
        }

        public virtual DbSet<BacSi> BacSi { get; set; }
        public virtual DbSet<BenhNhan> BenhNhan { get; set; }
        public virtual DbSet<ChanDoan> ChanDoan { get; set; }
        public virtual DbSet<DanhSachKham> DanhSachKham { get; set; }
        public virtual DbSet<DichVu> DichVu { get; set; }
        public virtual DbSet<DonThuoc> DonThuoc { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<Kho> Kho { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public virtual DbSet<ThiTruong> ThiTruong { get; set; }
        public virtual DbSet<CanLamSang> CanLamSang { get; set; }
        public virtual DbSet<CTDonThuoc> CTDonThuoc { get; set; }
        public virtual DbSet<DieuTri> DieuTri { get; set; }
        public virtual DbSet<LichSuNhapXuat> LichSuNhapXuat { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BacSi>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BacSi>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<BacSi>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.IDBenhNhan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.NamSinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .HasMany(e => e.DanhSachKham)
                .WithRequired(e => e.BenhNhan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChanDoan>()
                .Property(e => e.IDChanDoan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChanDoan>()
                .HasMany(e => e.DichVu)
                .WithRequired(e => e.ChanDoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhSachKham>()
                .Property(e => e.IDKham)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DanhSachKham>()
                .Property(e => e.IDBenhNhan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DanhSachKham>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DanhSachKham>()
                .HasMany(e => e.CanLamSang)
                .WithRequired(e => e.DanhSachKham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhSachKham>()
                .HasMany(e => e.DieuTri)
                .WithRequired(e => e.DanhSachKham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhSachKham>()
                .HasMany(e => e.DonThuoc)
                .WithRequired(e => e.DanhSachKham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhSachKham>()
                .HasMany(e => e.HoaDon)
                .WithRequired(e => e.DanhSachKham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.IDDichVu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.IDChanDoan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.DonGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DichVu>()
                .HasMany(e => e.DieuTri)
                .WithRequired(e => e.DichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonThuoc>()
                .Property(e => e.IDDonThuoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DonThuoc>()
                .Property(e => e.IDKham)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DonThuoc>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DonThuoc>()
                .HasMany(e => e.CTDonThuoc)
                .WithRequired(e => e.DonThuoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.IDHoaDon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.IDKham)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TienThuoc)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TienDieuTri)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.NgayLap)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Kho>()
                .Property(e => e.IDSanPham)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Kho>()
                .Property(e => e.IDDungCu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Kho>()
                .HasMany(e => e.DieuTri)
                .WithRequired(e => e.Kho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kho>()
                .HasMany(e => e.LichSuNhapXuat)
                .WithRequired(e => e.Kho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.BacSi)
                .WithRequired(e => e.TaiKhoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThiTruong>()
                .Property(e => e.IDSanPham)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThiTruong>()
                .Property(e => e.DonGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ThiTruong>()
                .HasMany(e => e.Kho)
                .WithRequired(e => e.ThiTruong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CanLamSang>()
                .Property(e => e.IDKham)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTDonThuoc>()
                .Property(e => e.IDDonThuoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTDonThuoc>()
                .Property(e => e.ThanhGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DieuTri>()
                .Property(e => e.IDDichVu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DieuTri>()
                .Property(e => e.IDKham)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DieuTri>()
                .Property(e => e.IDDungCu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DieuTri>()
                .Property(e => e.ThanhTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LichSuNhapXuat>()
                .Property(e => e.IDDungCu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LichSuNhapXuat>()
                .Property(e => e.Don)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LichSuNhapXuat>()
                .Property(e => e.ThanhTien)
                .HasPrecision(19, 4);
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public partial class DentalContextDB1 : DbContext
    {
        public DentalContextDB1()
            : base("name=DentalContextDB1")
        {
        }

        public virtual DbSet<BenhNhan> BenhNhans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
        }
    }
}

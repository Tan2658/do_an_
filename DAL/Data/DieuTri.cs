namespace DAL.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DieuTri")]
    public partial class DieuTri
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string IDDichVu { get; set; }

        [StringLength(6)]
        public string IDKham { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string IDDungCu { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SoLuong { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "money")]
        public decimal ThanhTien { get; set; }

        public virtual DanhSachKham DanhSachKham { get; set; }

        public virtual DichVu DichVu { get; set; }

        public virtual Kho Kho { get; set; }
    }
}

namespace DAL.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichSuNhapXuat")]
    public partial class LichSuNhapXuat
    {
        [Key]
        [Column(Order = 0)]
        public bool NoiDung { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string IDDungCu { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string TenDungCu { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string Loai { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string DonViTinh { get; set; }

        public int? SoLuongNhapXuat { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "money")]
        public decimal Don { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "money")]
        public decimal ThanhTien { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime NgayNhap { get; set; }

        public virtual Kho Kho { get; set; }
    }
}

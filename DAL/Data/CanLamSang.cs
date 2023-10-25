namespace DAL.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CanLamSang")]
    public partial class CanLamSang
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string IDKham { get; set; }

        public int? HuyetAp { get; set; }

        public int? Mach { get; set; }

        [StringLength(255)]
        public string DuongHuyet { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool MauKhoDong { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool BenhTim { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool ThieuNang { get; set; }

        [StringLength(255)]
        public string BaoHanh { get; set; }

        [StringLength(255)]
        public string Khac { get; set; }

        public virtual DanhSachKham DanhSachKham { get; set; }
    }
}

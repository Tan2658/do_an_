namespace DAL.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        [StringLength(3)]
        public string IDHoaDon { get; set; }

        [Required]
        [StringLength(3)]
        public string IDKham { get; set; }

        [StringLength(255)]
        public string PhuongThucThanhToan { get; set; }

        [Column(TypeName = "money")]
        public decimal TienThuoc { get; set; }

        [Column(TypeName = "money")]
        public decimal TienDieuTri { get; set; }

        [Column(TypeName = "money")]
        public decimal TongTien { get; set; }

        [Column(TypeName = "money")]
        public decimal NgayLap { get; set; }

        public virtual DanhSachKham DanhSachKham { get; set; }
    }
}

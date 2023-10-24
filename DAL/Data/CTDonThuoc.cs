namespace DAL.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTDonThuoc")]
    public partial class CTDonThuoc
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string IDDonThuoc { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string TenThuoc { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "money")]
        public decimal DonGia { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string DonViTinh { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SoLuong { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "money")]
        public decimal ThanhGia { get; set; }

        public virtual DonThuoc DonThuoc { get; set; }
    }
}

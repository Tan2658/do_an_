namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BenhNhan")]
    public partial class BenhNhan
    {
        [Key]
        [StringLength(3)]
        public string IDBenhNhan { get; set; }

        [Required]
        [StringLength(255)]
        public string HoTen { get; set; }

        public bool? Gioi { get; set; }

        [Required]
        [StringLength(4)]
        public string NamSinh { get; set; }

        [Required]
        [StringLength(11)]
        public string SDT { get; set; }

        [Required]
        [StringLength(255)]
        public string DiaChi { get; set; }

        public DateTime NgayKhamDau { get; set; }

        [Required]
        [StringLength(255)]
        public string LyDo { get; set; }
    }
}

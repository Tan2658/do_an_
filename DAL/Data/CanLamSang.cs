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
        public string IDBenhNhan { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Loai { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(25)]
        public string ThongSo { get; set; }

        public virtual BenhNhan BenhNhan { get; set; }
    }
}

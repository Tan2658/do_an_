namespace DAL.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVu")]
    public partial class DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            DieuTris = new HashSet<DieuTri>();
        }

        [Key]
        [StringLength(4)]
        public string IDDichVu { get; set; }

        [Required]
        [StringLength(3)]
        public string IDChanDoan { get; set; }

        [Required]
        [StringLength(255)]
        public string TenDichVu { get; set; }

        [Required]
        [StringLength(255)]
        public string DonViTinh { get; set; }

        [Column(TypeName = "money")]
        public decimal DonGia { get; set; }

        public virtual ChanDoan ChanDoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DieuTri> DieuTris { get; set; }
    }
}

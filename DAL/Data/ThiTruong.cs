namespace DAL.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThiTruong")]
    public partial class ThiTruong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThiTruong()
        {
            Khoes = new HashSet<Kho>();
        }

        [Key]
        [StringLength(4)]
        public string IDSanPham { get; set; }

        [Required]
        [StringLength(255)]
        public string TenSanPham { get; set; }

        [Required]
        [StringLength(50)]
        public string Loai { get; set; }

        [Required]
        [StringLength(255)]
        public string DonViTinh { get; set; }

        [Column(TypeName = "money")]
        public decimal DonGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kho> Khoes { get; set; }
    }
}

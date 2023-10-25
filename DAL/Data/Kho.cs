namespace DAL.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kho")]
    public partial class Kho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kho()
        {
            DieuTri = new HashSet<DieuTri>();
            LichSuNhapXuat = new HashSet<LichSuNhapXuat>();
        }

        [Required]
        [StringLength(4)]
        public string IDSanPham { get; set; }

        [Key]
        [StringLength(4)]
        public string IDDungCu { get; set; }

        [Required]
        [StringLength(255)]
        public string TenDungCu { get; set; }

        [Required]
        [StringLength(255)]
        public string Loai { get; set; }

        [Required]
        [StringLength(255)]
        public string DonViTinh { get; set; }

        public int? SoLuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DieuTri> DieuTri { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSuNhapXuat> LichSuNhapXuat { get; set; }

        public virtual ThiTruong ThiTruong { get; set; }
    }
}

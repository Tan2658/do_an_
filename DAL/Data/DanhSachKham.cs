namespace DAL.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhSachKham")]
    public partial class DanhSachKham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhSachKham()
        {
            CanLamSang = new HashSet<CanLamSang>();
            DieuTri = new HashSet<DieuTri>();
            DonThuoc = new HashSet<DonThuoc>();
            HoaDon = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(3)]
        public string IDKham { get; set; }

        [Required]
        [StringLength(3)]
        public string IDBenhNhan { get; set; }

        [Required]
        [StringLength(3)]
        public string MaNV { get; set; }

        public DateTime NgayKham { get; set; }

        public virtual BacSi BacSi { get; set; }

        public virtual BenhNhan BenhNhan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CanLamSang> CanLamSang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DieuTri> DieuTri { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonThuoc> DonThuoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDon { get; set; }
    }
}

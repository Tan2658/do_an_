namespace DAL.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BacSi")]
    public partial class BacSi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BacSi()
        {
            BenhNhan = new HashSet<BenhNhan>();
        }

        [Key]
        [StringLength(3)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(22)]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(50)]
        public string Ten { get; set; }

        [Required]
        [StringLength(50)]
        public string ChucVu { get; set; }

        [Required]
        [StringLength(50)]
        public string KinhNghiem { get; set; }

        [Required]
        [StringLength(10)]
        public string SDT { get; set; }

        [Required]
        [StringLength(100)]
        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BenhNhan> BenhNhan { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}

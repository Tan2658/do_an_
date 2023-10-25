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
            DanhSachKham = new HashSet<DanhSachKham>();
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

        [StringLength(50)]
        public string ChucVu { get; set; }

        [StringLength(50)]
        public string KinhNghiem { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhSachKham> DanhSachKham { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}

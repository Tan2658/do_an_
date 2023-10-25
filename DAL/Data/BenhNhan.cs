namespace DAL.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BenhNhan")]
    public partial class BenhNhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BenhNhan()
        {
            DanhSachKham = new HashSet<DanhSachKham>();
        }

        [Key]
        [StringLength(3)]
        public string IDBenhNhan { get; set; }

        [Required]
        [StringLength(255)]
        public string HoTen { get; set; }

        public bool? Gioi { get; set; }

        [StringLength(4)]
        public string NamSinh { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        public DateTime? NgayKhamDau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhSachKham> DanhSachKham { get; set; }
    }
}

namespace DAL.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonThuoc")]
    public partial class DonThuoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonThuoc()
        {
            CTDonThuocs = new HashSet<CTDonThuoc>();
        }

        [Key]
        [StringLength(3)]
        public string IDDonThuoc { get; set; }

        [Required]
        [StringLength(3)]
        public string IDKham { get; set; }

        [Column(TypeName = "money")]
        public decimal TongTien { get; set; }

        public DateTime? NgayLapDT { get; set; }

        public virtual DanhSachKham DanhSachKham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDonThuoc> CTDonThuocs { get; set; }
    }
}

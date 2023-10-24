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
            CTDonThuoc = new HashSet<CTDonThuoc>();
        }

        [Key]
        [StringLength(3)]
        public string IDDonThuoc { get; set; }

        [Required]
        [StringLength(3)]
        public string IDBenhNhan { get; set; }

        public virtual BenhNhan BenhNhan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDonThuoc> CTDonThuoc { get; set; }
    }
}

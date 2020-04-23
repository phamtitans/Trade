namespace WebApplication3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DOITAC")]
    public partial class DOITAC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOITAC()
        {
            GIAODICHes = new HashSet<GIAODICH>();
        }

        [Key]
        public int MaDT { get; set; }

        [Required]
        [StringLength(255)]
        public string TenDT { get; set; }

        [Required]
        [StringLength(255)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(255)]
        public string NguoiDaiDien { get; set; }

        [Required]
        [StringLength(255)]
        public string TaiKhoanNHNN { get; set; }

        [Required]
        [StringLength(255)]
        public string TaiKhoanHNX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIAODICH> GIAODICHes { get; set; }
    }
}

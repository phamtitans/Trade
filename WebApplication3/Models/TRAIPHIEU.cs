namespace WebApplication3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRAIPHIEU")]
    public partial class TRAIPHIEU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRAIPHIEU()
        {
            GIAODICHes = new HashSet<GIAODICH>();
        }

        [Key]
        public int MaTP { get; set; }

        [Required]
        [StringLength(255)]
        public string TCPH { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayPH { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDH { get; set; }

        public double? LSCoupon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIAODICH> GIAODICHes { get; set; }
    }
}

namespace WebApplication3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIAODICH")]
    public partial class GIAODICH
    {
        [Key]
        public int MaDinhDanh { get; set; }

        [Required]
        [StringLength(255)]
        public string MaLK { get; set; }

        [Column(TypeName = "money")]
        public decimal GiaCoSo { get; set; }

        [Column(TypeName = "money")]
        public decimal GiaThucHien { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayGiaoDich { get; set; }

        [Required]
        [StringLength(255)]
        public string LoaiGiaoDich { get; set; }

        public int MaDT { get; set; }

        public int MaTP { get; set; }

        public int SoLuong { get; set; }

        public int LoaiRepo { get; set; }

        public virtual DOITAC DOITAC { get; set; }

        public virtual TRAIPHIEU TRAIPHIEU { get; set; }
    }
}

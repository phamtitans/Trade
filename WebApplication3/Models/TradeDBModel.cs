namespace WebApplication3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TradeDBModel : DbContext
    {
        public TradeDBModel()
            : base("name=TradeModel")
        {
        }

        public virtual DbSet<DOITAC> DOITACs { get; set; }
        public virtual DbSet<GIAODICH> GIAODICHes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TRAIPHIEU> TRAIPHIEUx { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DOITAC>()
                .HasMany(e => e.GIAODICHes)
                .WithRequired(e => e.DOITAC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GIAODICH>()
                .Property(e => e.GiaCoSo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GIAODICH>()
                .Property(e => e.GiaThucHien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TRAIPHIEU>()
                .HasMany(e => e.GIAODICHes)
                .WithRequired(e => e.TRAIPHIEU)
                .WillCascadeOnDelete(false);
        }
    }
}

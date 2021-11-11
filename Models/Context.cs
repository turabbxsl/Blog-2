namespace Blogsayti.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context7")
        {
        }

        public virtual DbSet<etiket> etikets { get; set; }
        public virtual DbSet<kategoriya> kategoriyas { get; set; }
        public virtual DbSet<kullanici> kullanicis { get; set; }
        public virtual DbSet<kullanicirol> kullanicirols { get; set; }
        public virtual DbSet<meqale> meqales { get; set; }
        public virtual DbSet<resm> resms { get; set; }
        public virtual DbSet<Roll> Rolls { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<yorum> yorums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<etiket>()
                .HasMany(e => e.meqales)
                .WithMany(e => e.etikets)
                .Map(m => m.ToTable("meqaleetiket").MapLeftKey("etiketid").MapRightKey("meqaleid"));

            modelBuilder.Entity<kategoriya>()
                .HasMany(e => e.meqales)
                .WithRequired(e => e.kategoriya)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<kullanici>()
                .HasMany(e => e.kullanicirols)
                .WithRequired(e => e.kullanici)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<kullanici>()
                .HasMany(e => e.meqales)
                .WithRequired(e => e.kullanici)
                .HasForeignKey(e => e.yazarid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<kullanici>()
                .HasMany(e => e.kullanici1)
                .WithMany(e => e.kullanicis)
                .Map(m => m.ToTable("yazartakib").MapLeftKey("yazarid").MapRightKey("kullaniciid"));

            modelBuilder.Entity<meqale>()
                .HasMany(e => e.resms)
                .WithOptional(e => e.meqale)
                .HasForeignKey(e => e.meqaleid);

            modelBuilder.Entity<meqale>()
                .HasMany(e => e.yorums)
                .WithRequired(e => e.meqale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<resm>()
                .HasMany(e => e.kullanicis)
                .WithOptional(e => e.resm)
                .HasForeignKey(e => e.resmid);

            modelBuilder.Entity<resm>()
                .HasMany(e => e.meqales)
                .WithOptional(e => e.resm)
                .HasForeignKey(e => e.resmid);

            modelBuilder.Entity<Roll>()
                .HasMany(e => e.kullanicirols)
                .WithRequired(e => e.Roll)
                .HasForeignKey(e => e.rolid)
                .WillCascadeOnDelete(false);
        }
    }
}

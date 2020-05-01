using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.DataAccess.DataBase
{
    public partial class GtGroupContext : DbContext
    {
        public GtGroupContext()
        {
        }

        public GtGroupContext(DbContextOptions<GtGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:saguir.database.windows.net;Initial Catalog=GtGroup;Persist Security Info=False;User ID=saguiradmin;Password=Saguir2020*");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UseIdUsuarioPk);

                entity.Property(e => e.UseIdUsuarioPk)
                    .HasColumnName("use_idUsuarioPk")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.UseFirstLastName)
                    .HasColumnName("use_firstLastName")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.UseFirstName)
                    .IsRequired()
                    .HasColumnName("use_firstName")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.UseSecondLastName)
                    .HasColumnName("use_secondLastName")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.UseSecondName)
                    .HasColumnName("use_secondName")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.UseUsername)
                    .IsRequired()
                    .HasColumnName("use_username")
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });
        }
    }
}

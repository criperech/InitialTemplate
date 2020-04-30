using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.DataAccess.DataBase
{
    public partial class Db_SaguirContext : DbContext
    {
        public Db_SaguirContext()
        {
        }

        public Db_SaguirContext(DbContextOptions<Db_SaguirContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DicResidentialSites> DicResidentialSites { get; set; }
        public virtual DbSet<DicStatesNews> DicStatesNews { get; set; }
        public virtual DbSet<DicTypeNews> DicTypeNews { get; set; }
        public virtual DbSet<DicTypesImagesNews> DicTypesImagesNews { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TraImagesNews> TraImagesNews { get; set; }
        public virtual DbSet<TraNews> TraNews { get; set; }
        public virtual DbSet<UserRolesResidentialSites> UserRolesResidentialSites { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:saguir.database.windows.net;Initial Catalog=Db_Saguir;Persist Security Info=False;User ID=saguiradmin;Password=Saguir2020*");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<DicResidentialSites>(entity =>
            {
                entity.HasKey(e => e.RsiIdResidentialPk);

                entity.ToTable("Dic_ResidentialSites", "ope");

                entity.Property(e => e.RsiIdResidentialPk)
                    .HasColumnName("rsi_idResidentialPk")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.RsiDirection)
                    .HasColumnName("rsi_direction")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.RsiName)
                    .IsRequired()
                    .HasColumnName("rsi_name")
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DicStatesNews>(entity =>
            {
                entity.HasKey(e => e.StnIdStatePk);

                entity.ToTable("Dic_StatesNews", "adm");

                entity.Property(e => e.StnIdStatePk).HasColumnName("stn_idStatePk");

                entity.Property(e => e.StnDescripcion)
                    .IsRequired()
                    .HasColumnName("stn_descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DicTypeNews>(entity =>
            {
                entity.HasKey(e => e.TynIdTypePk);

                entity.ToTable("Dic_TypeNews", "adm");

                entity.Property(e => e.TynIdTypePk).HasColumnName("tyn_idTypePk");

                entity.Property(e => e.TynDescription)
                    .HasColumnName("tyn_description")
                    .IsUnicode(false);

                entity.Property(e => e.TynName)
                    .IsRequired()
                    .HasColumnName("tyn_name")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.TynState).HasColumnName("tyn_state");
            });

            modelBuilder.Entity<DicTypesImagesNews>(entity =>
            {
                entity.HasKey(e => e.TinIdTypeImagePk);

                entity.ToTable("Dic_TypesImagesNews", "adm");

                entity.Property(e => e.TinIdTypeImagePk).HasColumnName("tin_idTypeImagePk");

                entity.Property(e => e.TinName)
                    .IsRequired()
                    .HasColumnName("tin_name")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.TinState).HasColumnName("tin_state");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RolIdRolPk);

                entity.ToTable("Roles", "adm");

                entity.Property(e => e.RolIdRolPk).HasColumnName("rol_idRolPk");

                entity.Property(e => e.RolDateCreation)
                    .HasColumnName("rol_dateCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.RolDescription)
                    .IsRequired()
                    .HasColumnName("rol_description")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.RolName)
                    .IsRequired()
                    .HasColumnName("rol_name")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TraImagesNews>(entity =>
            {
                entity.HasKey(e => e.ImnIdImagePk);

                entity.ToTable("Tra_ImagesNews", "ope");

                entity.Property(e => e.ImnIdImagePk)
                    .HasColumnName("imn_idImagePk")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ImnIdTypeFk).HasColumnName("imn_idTypeFk");

                entity.Property(e => e.ImnName)
                    .IsRequired()
                    .HasColumnName("imn_name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ImnNameFile)
                    .HasColumnName("imn_nameFile")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ImnState).HasColumnName("imn_state");
            });

            modelBuilder.Entity<TraNews>(entity =>
            {
                entity.HasKey(e => e.NewIdNewPk);

                entity.ToTable("Tra_News", "ope");

                entity.Property(e => e.NewIdNewPk)
                    .HasColumnName("new_idNewPk")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.NewEndValidDate)
                    .HasColumnName("new_endValidDate")
                    .HasColumnType("date");

                entity.Property(e => e.NewIdImageFk).HasColumnName("new_idImageFk");

                entity.Property(e => e.NewIdTypeFk).HasColumnName("new_idTypeFk");

                entity.Property(e => e.NewIdUserCreatorFk).HasColumnName("new_idUserCreatorFk");

                entity.Property(e => e.NewInitialValidDate)
                    .HasColumnName("new_initialValidDate")
                    .HasColumnType("date");

                entity.Property(e => e.NewLastUpdate)
                    .HasColumnName("new_lastUpdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewLongDescription)
                    .HasColumnName("new_longDescription")
                    .IsUnicode(false);

                entity.Property(e => e.NewMore).HasColumnName("new_more");

                entity.Property(e => e.NewSecondTitle)
                    .HasColumnName("new_secondTitle")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NewShortDescription)
                    .IsRequired()
                    .HasColumnName("new_shortDescription")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NewStartDate)
                    .HasColumnName("new_startDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewState).HasColumnName("new_state");

                entity.Property(e => e.NewTitle)
                    .IsRequired()
                    .HasColumnName("new_title")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.NewIdTypeFkNavigation)
                    .WithMany(p => p.TraNews)
                    .HasForeignKey(d => d.NewIdTypeFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tra_News_Dic_TypeNews");
            });

            modelBuilder.Entity<UserRolesResidentialSites>(entity =>
            {
                entity.HasKey(e => e.UrrIdUserRolPk)
                    .HasName("PK_UserRoles");

                entity.ToTable("UserRolesResidentialSites", "adm");

                entity.Property(e => e.UrrIdUserRolPk).HasColumnName("urr_idUserRolPk");

                entity.Property(e => e.UrrDateCreation)
                    .HasColumnName("urr_dateCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.UrrIdResidentialSiteFk)
                    .IsRequired()
                    .HasColumnName("urr_idResidentialSiteFk")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UrrIdRolFk).HasColumnName("urr_idRolFk");

                entity.Property(e => e.UrrIdUserFk)
                    .IsRequired()
                    .HasColumnName("urr_idUserFK")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.UrrIdResidentialSiteFkNavigation)
                    .WithMany(p => p.UserRolesResidentialSites)
                    .HasForeignKey(d => d.UrrIdResidentialSiteFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRolesResidentialSites_Dic_ResidentialSites");

                entity.HasOne(d => d.UrrIdRolFkNavigation)
                    .WithMany(p => p.UserRolesResidentialSites)
                    .HasForeignKey(d => d.UrrIdRolFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRolesResidentialSites_Roles");

                entity.HasOne(d => d.UrrIdUserFkNavigation)
                    .WithMany(p => p.UserRolesResidentialSites)
                    .HasForeignKey(d => d.UrrIdUserFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRolesResidentialSites_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UseIdUsuarioPk);

                entity.ToTable("Users", "adm");

                entity.Property(e => e.UseIdUsuarioPk)
                    .HasColumnName("use_idUsuarioPk")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.UseAccessFailedCount).HasColumnName("use_accessFailedCount");

                entity.Property(e => e.UseBirthdayDate)
                    .HasColumnName("use_birthdayDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UseCreationDate)
                    .HasColumnName("use_creationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UseEmail)
                    .HasColumnName("use_email")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.UseFirstLastName)
                    .IsRequired()
                    .HasColumnName("use_firstLastName")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UseFirstName)
                    .IsRequired()
                    .HasColumnName("use_firstName")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UseIdUserCreate).HasColumnName("use_idUserCreate");

                entity.Property(e => e.UseImage)
                    .HasColumnName("use_image")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UseLockoutEnabled).HasColumnName("use_lockoutEnabled");

                entity.Property(e => e.UseLockoutEndDateUtc)
                    .HasColumnName("use_lockoutEndDateUtc")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsePasswordHash)
                    .IsRequired()
                    .HasColumnName("use_passwordHash")
                    .IsUnicode(false);

                entity.Property(e => e.UsePhoneHome)
                    .HasColumnName("use_phoneHome")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UsePhoneNumber)
                    .HasColumnName("use_phoneNumber")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UsePostalCode)
                    .HasColumnName("use_postalCode")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.UseSecondLastName)
                    .HasColumnName("use_secondLastName")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UseSecondName)
                    .HasColumnName("use_secondName")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UseSecurityStamp)
                    .HasColumnName("use_securityStamp")
                    .IsUnicode(false);

                entity.Property(e => e.UseState).HasColumnName("use_state");

                entity.Property(e => e.UseStreetAddress)
                    .HasColumnName("use_streetAddress")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UseTokenRecovery)
                    .HasColumnName("use_tokenRecovery")
                    .HasMaxLength(256);

                entity.Property(e => e.UseTwoFactorEnabled).HasColumnName("use_twoFactorEnabled");

                entity.Property(e => e.UseUserName)
                    .IsRequired()
                    .HasColumnName("use_userName")
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiConsumoEletrico.Persistence
{
    public partial class ApplicationContextcls : DbContext
    {
        public ApplicationContextcls()
        {
        }

        public ApplicationContextcls(DbContextOptions<ApplicationContextcls> options)
            : base(options)
        {
        }

        public virtual DbSet<Dealership> Dealerships { get; set; }
        public virtual DbSet<Electronic> Electronics { get; set; }
        public virtual DbSet<HouseProfile> HouseProfiles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=DESKTOP-ELG8RI2\\SQLEXPRESS;Initial Catalog=eletroMais; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Dealership>(entity =>
            {
                entity.ToTable("dealership");

                entity.Property(e => e.DealershipId).HasColumnName("dealershipId");

                entity.Property(e => e.DealershipName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("dealershipName");

                entity.Property(e => e.KhwPrice).HasColumnName("khwPrice");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("state");
            });

            modelBuilder.Entity<Electronic>(entity =>
            {
                entity.HasKey(e => e.ElectronicsId)
                    .HasName("PK__electron__F288227C18E94027");

                entity.ToTable("electronics");

                entity.Property(e => e.ElectronicsId).HasColumnName("electronicsId");

                entity.Property(e => e.ElectronicsName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("electronicsName");

                entity.Property(e => e.ElectronicsPotency).HasColumnName("electronicsPotency");

                entity.Property(e => e.UsageTimePerDay).HasColumnName("usageTimePerDay");

                entity.Property(e => e.UsedInHouse).HasColumnName("usedInHouse");

                entity.HasOne(d => d.UsedInHouseNavigation)
                    .WithMany(p => p.Electronics)
                    .HasForeignKey(d => d.UsedInHouse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_houseUse");
            });

            modelBuilder.Entity<HouseProfile>(entity =>
            {
                entity.ToTable("houseProfile");

                entity.Property(e => e.HouseProfileId).HasColumnName("houseProfileId");

                entity.Property(e => e.Dealership).HasColumnName("dealership");

                entity.Property(e => e.HouseName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("houseName");

                entity.Property(e => e.ProfileUser).HasColumnName("profileUser");

                entity.HasOne(d => d.DealershipNavigation)
                    .WithMany(p => p.HouseProfiles)
                    .HasForeignKey(d => d.Dealership)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dealership_prices");

                entity.HasOne(d => d.ProfileUserNavigation)
                    .WithMany(p => p.HouseProfiles)
                    .HasForeignKey(d => d.ProfileUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_profileUser");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

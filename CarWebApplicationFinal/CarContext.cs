using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarWebApplicationFinal
{
    public partial class CarContext : DbContext
    {
        public CarContext()
        {
        }

        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AutoShowroom> AutoShowrooms { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Characteristic> Characteristics { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Model> Models { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= OLENAKARDASH-PC; Database=Car; Trusted_Connection=True; TrustServerCertificate=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutoShowroom>(entity =>
            {
                entity.HasKey(e => e.AsId);

                entity.ToTable("Auto_Showroom");

                entity.Property(e => e.AsId).HasColumnName("AS_ID");

                entity.Property(e => e.AsCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AS_Country");

                entity.Property(e => e.AsName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AS_Name");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.BrId);

                entity.ToTable("Brand");

                entity.Property(e => e.BrId).HasColumnName("BR_ID");

                entity.Property(e => e.BrCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BR_Country");

                entity.Property(e => e.BrModels)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BR_Models");

                entity.Property(e => e.BrName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BR_Name");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.CrId);

                entity.ToTable("Car");

                entity.Property(e => e.CrId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CR_ID");

                entity.Property(e => e.CrAutoShowroom)
                    .HasMaxLength(50)
                    .HasColumnName("CR_Auto_Showroom");

                entity.Property(e => e.CrBrand)
                    .HasMaxLength(50)
                    .HasColumnName("CR_Brand");

                entity.Property(e => e.CrManufacturerCountry)
                    .HasMaxLength(50)
                    .HasColumnName("CR_Manufacturer_Country");

                entity.Property(e => e.CrModel)
                    .HasMaxLength(50)
                    .HasColumnName("CR_Model");

                entity.Property(e => e.CrPrice).HasColumnName("CR_Price");

                entity.Property(e => e.CrYearOfIssue).HasColumnName("CR_Year_Of_Issue");

                entity.HasOne(d => d.Cr)
                    .WithOne(p => p.Car)
                    .HasForeignKey<Car>(d => d.CrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Car_Brand");
            });

            modelBuilder.Entity<Characteristic>(entity =>
            {
                entity.HasKey(e => e.ChMaxSpeed);

                entity.Property(e => e.ChMaxSpeed).HasColumnName("CH_Max_Speed");

                entity.Property(e => e.ChHorsepower).HasColumnName("CH_Horsepower");

                entity.Property(e => e.ChNumOfSeats).HasColumnName("CH_Num_Of_Seats");

                entity.Property(e => e.ChWeight).HasColumnName("CH_Weight");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.MfcountryId);

                entity.ToTable("Country");

                entity.Property(e => e.MfcountryId).HasColumnName("MFCountry_ID");

                entity.Property(e => e.MfcountryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MFCountry_Name");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.MdId);

                entity.ToTable("Model");

                entity.Property(e => e.MdId).HasColumnName("MD_ID");

                entity.Property(e => e.MdCharacteristics)
                    .HasColumnType("text")
                    .HasColumnName("MD_Characteristics");

                entity.Property(e => e.MdName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MD_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

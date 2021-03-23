using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CinemaLogic.DB
{
    public partial class CinemaDb : DbContext
    {
        public CinemaDb()
        {
        }

        public CinemaDb(DbContextOptions<CinemaDb> options)
            : base(options)
        {
        }

        public virtual DbSet<Auditoriums> Auditoriums { get; set; }
        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<SeatTypes> SeatTypes { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\victo\\source\\repos\\C2_Day15\\CinemaDb.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookings>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Pic).HasMaxLength(200);

                entity.Property(e => e.SeatType).HasMaxLength(50);

                entity.Property(e => e.SelectedTime).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.Property(e => e.AvailableTime).HasColumnType("datetime");

                entity.Property(e => e.BasePrice).HasColumnType("money");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Pic)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SeatTypes>(entity =>
            {
                entity.HasKey(e => e.SeatTypeId)
                    .HasName("PK__SeatType__7468C4FE4CEB23B7");

                entity.Property(e => e.Naming)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using CarPartShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CarPartShop.Models
{
    public partial class CarPartShopContext : DbContext
    {
        public CarPartShopContext()
        {
        }

        public CarPartShopContext(DbContextOptions<CarPartShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarPart> CarParts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<User> Users { get; set; }

        /*        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    if (!optionsBuilder.IsConfigured)
                    {
        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                        optionsBuilder.UseSqlite("DataSource=./CarPartShop.db;");
                    }
                }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarPart>(entity =>
            {
                entity.ToTable("CarPart");

                entity.Property(e => e.CarPartId).ValueGeneratedNever();

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("ImageURL")
                    .HasDefaultValueSql("'https://cdn2.iconfinder.com/data/icons/car-parts-12/200/227-512.png'");

                entity.Property(e => e.PartName).IsRequired();
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CarPartId });

                entity.ToTable("CartItem");

                entity.HasOne(d => d.CarPart)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CarPartId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "IX_User_Email")
                    .IsUnique();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Password).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

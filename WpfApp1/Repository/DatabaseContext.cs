using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<ClientModel> Clients { get; set; }
        public virtual DbSet<MovieModel> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DELLINSPIRON15;Initial Catalog=MoviesRental;User Id = sa; Password = uibrotho3421;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                //FOR LAPTOP "Server=DELLINSPIRON15;Initial Catalog=MoviesRental;User Id = sa; Password = uibrotho3421;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                //FOR DESKTOP Server=DESKTOP-S4TPVIB;Initial Catalog=MoviesRental;User Id = sa; Password = sql_vwmp034;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.Id); //primary key

                //regular properties
                entity.Property(u => u.Name).HasColumnName("Login").IsRequired();
                entity.Property(u => u.Password).HasColumnName("Password").IsRequired();
                entity.Property(u => u.Name).HasColumnName("Name");
                entity.Property(u => u.Surname).HasColumnName("Surname");
                entity.Property(u => u.Email).HasColumnName("Email").IsRequired();
            });

            modelBuilder.Entity<ClientModel>(entity =>
            {
                entity.ToTable("Clients");
                entity.HasKey(u => u.Id); //primary key

                //regular properties
                entity.Property(u => u.Name).HasColumnName("Name").IsRequired();
                entity.Property(u => u.Surname).HasColumnName("Surname").IsRequired();
                entity.Property(u => u.Adress).HasColumnName("Adress");
                entity.Property(u => u.PhoneNumber).HasColumnName("PhoneNumber");
            });

            modelBuilder.Entity<MovieModel>(entity =>
            {
                entity.ToTable("Movies");
                entity.HasKey(u => u.Id); //primary key

                //regular properties
                entity.Property(u => u.Title).HasColumnName("Title").IsRequired();
                entity.Property(u => u.Description).HasColumnName("Description");
                entity.Property(u => u.Director).HasColumnName("Director");
                entity.Property(u => u.TimeLapse).HasColumnName("TimeLapse");
                entity.Property(u => u.Category).HasColumnName("Category");
                entity.Property(u => u.IsRented).HasColumnName("IsRented").IsRequired();
                entity.Property(u => u.ClientId).HasColumnName("ClientId").IsRequired(false);

                entity.HasOne(x => x.Client)
                .WithMany(c => c.Movies)
                .HasForeignKey(x => x.ClientId)
                .HasConstraintName("FK_Movie_Client")
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }

        protected DatabaseContext GetConnection()
        {
            return new DatabaseContext();
        }
    }
}

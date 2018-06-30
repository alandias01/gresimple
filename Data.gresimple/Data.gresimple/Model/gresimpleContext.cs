using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.gresimple.Model
{
    public partial class gresimpleContext : DbContext
    {
        public gresimpleContext()
        {
        }

        public gresimpleContext(DbContextOptions<gresimpleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Grelists> Grelists { get; set; }
        public virtual DbSet<Greusers> Greusers { get; set; }
        public virtual DbSet<Grewords> Grewords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:alandiasazure.database.windows.net,1433;Initial Catalog=gresimple;Persist Security Info=False;User ID=alandiasazure@gmail.com@alandiasazure;Password=Classic445;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grelists>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.ListName).IsUnicode(false);

                entity.Property(e => e.Word).IsUnicode(false);
            });

            modelBuilder.Entity<Greusers>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Password).IsUnicode(false);
            });

            modelBuilder.Entity<Grewords>(entity =>
            {
                entity.Property(e => e.Definition).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);

                entity.Property(e => e.Word).IsUnicode(false);
            });
        }
    }
}

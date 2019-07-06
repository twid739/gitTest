using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace libraryIIMS.Model
{

    public partial class libraryIIMSContext : DbContext
    {
        public libraryIIMSContext()
        {
        }

        public libraryIIMSContext(DbContextOptions<libraryIIMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Item { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:msalibraryiims.database.windows.net,1433;Initial Catalog=libraryIIMS;Persist Security Info=False;User ID=twid739;Password=msaNZ2019;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.ItemId).ValueGeneratedNever();

                entity.Property(e => e.AuthorFirstName).IsUnicode(false);

                entity.Property(e => e.AuthorLastName).IsUnicode(false);

                entity.Property(e => e.ItemType).IsUnicode(false);

                entity.Property(e => e.Publisher).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });
        }
    }
}

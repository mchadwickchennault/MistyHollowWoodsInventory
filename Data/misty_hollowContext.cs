using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MistyHollowWoodsInventory.Models;

#nullable disable

namespace MistyHollowWoodsInventory.Data
{
    public partial class misty_hollowContext : DbContext
    {
        public misty_hollowContext()
        {
        }

        public misty_hollowContext(DbContextOptions<misty_hollowContext> options)
            : base(options)
        {
        }
        public DbSet<Bowls> Bowls { get; set; }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<Bowls>(entity =>
            {
                entity.HasKey(e => e.ID);
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

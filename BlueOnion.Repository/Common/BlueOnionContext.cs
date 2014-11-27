using BlueOnion.Domain.Model;
using System.Data.Entity;

namespace BlueOnion.Repository
{
    /// <summary>
    /// The Default DbContext for the solution
    /// </summary>
    public partial class BlueOnionContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(255));

            modelBuilder.Entity<UserRole>().HasKey(u => new { u.RoleId, u.UserId });
        }
    }
}
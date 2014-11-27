using BlueOnion.Domain.Model;
using System.Data.Entity;

namespace BlueOnion.Repository
{
    /// <summary>
    /// A partial to keep on model creating only
    /// </summary>
    public partial class BlueOnionContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(255));

            modelBuilder.Entity<UserRole>().HasKey(u => new { u.RoleId, u.UserId });
        }
    }
}
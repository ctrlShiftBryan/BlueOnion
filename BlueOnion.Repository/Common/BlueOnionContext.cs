using BlueOnion.Domain.Model;
using System.Data.Entity;

namespace BlueOnion.Repository.Common
{
    /// <summary>
    /// The Default DbContext for the solution
    /// </summary>
    public partial class BlueOnionContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
    }
}
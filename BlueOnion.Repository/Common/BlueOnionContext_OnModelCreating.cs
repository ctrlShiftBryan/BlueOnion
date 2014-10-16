using System.Data.Entity;

namespace BlueOnion.Repository.Common
{
    /// <summary>
    /// A partial to keep on model creating only
    /// </summary>
    public partial class BlueOnionContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
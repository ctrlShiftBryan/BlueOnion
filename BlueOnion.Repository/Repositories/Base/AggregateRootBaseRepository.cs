using BlueOnion.Domain.Interfaces;
using BlueOnion.Repository.Interfaces;
using BlueOnion.ViewModel.Common;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.OData.Query;

namespace BlueOnion.Repository
{
    /// <summary>
    /// A basic repository that can be used for any aggregate root.
    /// Icludes basic paging with OData query support
    /// </summary>
    /// <typeparam name="T">The aggregate root</typeparam>
    /// <typeparam name="TId">The Id type of the aggregate root (guid,int,string,etc)</typeparam>
    public class AggregateRootBaseRepository<T, TId> : EntityBaseRepository<T, TId>
        where T : class, IAggregateRoot<TId>, IEntityBase<TId>, new()
        where TId : IEquatable<TId>
    {
        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="user">The user who is using the repository</param>
        /// <param name="unitOfWork">The UnitOfWork this repo belongs to</param>
        /// <param name="limit">The default limit returned by all</param>
        public AggregateRootBaseRepository(IUser user, IUnitOfWork unitOfWork, int limit = 1000)
            : base(user, unitOfWork, limit)
        {

        }

        public DbSet<T> DbSet()
        {
            return Db.Set<T>();
        }

        protected static long GetODataCount(ODataQueryOptions odataOptions)
        {
            var req = odataOptions.Request.Properties;
            if (!req.ContainsKey("MS_InlineCount")) return -1;
            var totalCountString = req.First(x => x.Key == "MS_InlineCount").Value.ToString();
            var count = long.Parse(totalCountString);
            return count;
        }

        protected static ListWithPageInfo<T> GetListWithPageInfo(ODataQueryOptions<T> odataOptions, IQueryable<T> dbset)
        {
            return new ListWithPageInfo<T>(
                odataOptions.ApplyTo(dbset).Cast<T>().ToList(),
                odataOptions.Top.Value,
                odataOptions.Skip.Value,
                GetODataCount(odataOptions)
            );
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BlueOnion.Domain.Interfaces;
using BlueOnion.Repository.Interfaces;

namespace BlueOnion.Repository
{
    public class EntityBaseRepository<T, TId>
        where T : class, IEntityBase<TId>, new()
        where TId : IEquatable<TId>
    {
        protected readonly IUser User;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly int Limit;

        protected DbContext Db
        {
            get { return UnitOfWork.Context; }
        }

        public EntityBaseRepository(IUser user, IUnitOfWork unitOfWork, int limit = 1000)
        {
            User = user;
            UnitOfWork = unitOfWork;
            Limit = limit;
        }

        public virtual List<T> All()
        {
            return Db.Set<T>().Take(Limit).ToList();
        }

        public virtual T GetById(TId id)
        {

            return Db.Set<T>().Single(x => x.Id.Equals(id));
        }

        protected virtual T GetById(TId id, IEnumerable<string> include, bool asNoTracking = false)
        {
            var query = Db.Set<T>().AsQueryable();

            if (include != null)
            {
                query = include.Aggregate(query, (current, i) => current.Include(i));
            }

            if (asNoTracking)
                query = query.AsNoTracking();

            return query.Single(x => x.Id.Equals(id));
        }

        public virtual void Add(T entity)
        {
            Db.Set<T>().Add(entity);
        }

        public virtual List<T> Where(Expression<Func<T, bool>> predicate)
        {
            return Db.Set<T>().Where(predicate).ToList();
        }

        public virtual void LoadReferences()
        {
            throw new System.NotImplementedException();
        }
    }
}
using BlueOnion.Repository.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace BlueOnion.Repository.Common
{
    /// <summary>
    /// A Unit of work wrapper for the main DbContext
    /// </summary>
    public sealed class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            Context = new BlueOnionContext();
        }
        DbContextTransaction _transaction;

        public UnitOfWork(BlueOnionContext dtContext)
        {
            Context = dtContext;
        }

        public DbContextTransaction Transaction()
        {
            return _transaction;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public IEnumerable<DbEntityValidationResult> GetValidationErrors()
        {

            return Context.GetValidationErrors();
        }

        public void DebugChangeTracker()
        {
            var Added = Context.ChangeTracker.Entries().Where(p => p.State ==
                                                   System.Data.Entity.EntityState.Added);

            var Deleted = Context.ChangeTracker.Entries().Where(p =>

                                                   p.State == System.Data.Entity.EntityState.Deleted);

            var Modified = Context.ChangeTracker.Entries().Where(p =>

                                                  p.State == System.Data.Entity.EntityState.Modified);
        }

        public void BeginTransaction()
        {
            _transaction = Context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _transaction.Commit();
        }

        public void RollbackTransaction()
        {
            _transaction.Rollback();
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public BlueOnionContext Context { get; private set; }
    }
}
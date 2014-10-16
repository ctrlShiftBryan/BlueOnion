using BlueOnion.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace BlueOnion.Repository.Interfaces
{
    public interface IUnitOfWork<out TContext> : IDisposable
    {
        int Save();
        TContext Context { get; }
        IEnumerable<DbEntityValidationResult> GetValidationErrors();
    }

    public interface IUnitOfWork : IUnitOfWork<BlueOnionContext>
    {
        void DebugChangeTracker();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
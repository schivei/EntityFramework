// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Infrastructure.Internal;
using Microsoft.Data.Entity.Internal;
using Microsoft.Data.Entity.Utilities;

namespace Microsoft.Data.Entity.Storage
{
    public class InMemoryTransactionManager : IDbContextTransactionManager
    {
        private readonly InMemoryOptionsExtension _inMemoryOptionsExtension;

        public InMemoryTransactionManager([NotNull] IDbContextOptions options)
        {
            Check.NotNull(options, nameof(options));

            _inMemoryOptionsExtension = options.Extensions
                .OfType<InMemoryOptionsExtension>()
                .FirstOrDefault();
        }

        public virtual IDbContextTransaction BeginTransaction()
        {
            if (!_inMemoryOptionsExtension.IgnoreTransactions)
            {
                throw new InvalidOperationException(InMemoryStrings.TransactionsNotSupported);
            }
            return new InMemoryTransaction();
        }

        public virtual Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!_inMemoryOptionsExtension.IgnoreTransactions)
            {
                throw new InvalidOperationException(InMemoryStrings.TransactionsNotSupported);
            }

            return Task.FromResult<IDbContextTransaction>(new InMemoryTransaction());
        }

        public virtual void CommitTransaction()
        {
            if (!_inMemoryOptionsExtension.IgnoreTransactions)
            {
                throw new InvalidOperationException(InMemoryStrings.TransactionsNotSupported);
            }
        }

        public virtual void RollbackTransaction()
        {
            if (!_inMemoryOptionsExtension.IgnoreTransactions)
            {
                throw new InvalidOperationException(InMemoryStrings.TransactionsNotSupported);
            }
        }
    }
}

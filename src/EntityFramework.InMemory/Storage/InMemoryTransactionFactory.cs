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
    public class InMemoryTransactionFactory : IDbContextTransactionFactory
    {
        private readonly InMemoryOptionsExtension _inMemoryOptionsExtension;

        public InMemoryTransactionFactory([NotNull] IDbContextOptions options)
        {
            Check.NotNull(options, nameof(options));

            _inMemoryOptionsExtension = options.Extensions
                .OfType<InMemoryOptionsExtension>()
                .FirstOrDefault();
        }

        public virtual IDbContextTransaction Create()
        {
            if (_inMemoryOptionsExtension.IgnoreTransactions)
            {
                throw new InvalidOperationException(InMemoryStrings.TransactionsNotSupported);
            }
            return new InMemoryTransaction();
        }

        public virtual Task<IDbContextTransaction> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_inMemoryOptionsExtension.IgnoreTransactions)
            {
                throw new InvalidOperationException(InMemoryStrings.TransactionsNotSupported);
            }

            return Task.FromResult<IDbContextTransaction>(new InMemoryTransaction());
        }
    }
}

// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Microsoft.Data.Entity.Storage
{
    public interface IRelationalConnection : IDbContextTransactionFactory, IDisposable
    {
        string ConnectionString { get; }

        DbConnection DbConnection { get; }

        IDbContextTransaction CurrentTransaction { get; }

        int? CommandTimeout { get; set; }

        IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel);

        Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken = default(CancellationToken));

        IDbContextTransaction UseTransaction([CanBeNull] DbTransaction transaction);

        void Open();

        Task OpenAsync(CancellationToken cancellationToken = default(CancellationToken));

        void Close();

        bool IsMultipleActiveResultSetsEnabled { get; }
    }
}

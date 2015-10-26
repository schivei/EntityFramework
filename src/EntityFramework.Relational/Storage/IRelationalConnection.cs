// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Data.Entity.Storage
{
    public interface IRelationalConnection : IRelationalTransactionManager, IDisposable
    {
        string ConnectionString { get; }

        DbConnection DbConnection { get; }

        IDbContextTransaction CurrentTransaction { get; }

        int? CommandTimeout { get; set; }

        void Open();

        Task OpenAsync(CancellationToken cancellationToken = default(CancellationToken));

        void Close();

        bool IsMultipleActiveResultSetsEnabled { get; }
    }
}

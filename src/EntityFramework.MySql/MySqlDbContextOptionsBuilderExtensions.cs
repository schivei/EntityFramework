// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Data.Common;
using JetBrains.Annotations;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Infrastructure.Internal;
using Microsoft.Data.Entity.Utilities;

namespace Microsoft.Data.Entity
{
    public static class MySqlDbContextOptionsBuilderExtensions
    {
        public static MySqlDbContextOptionsBuilder UseMySql([NotNull] this DbContextOptionsBuilder options, [NotNull] string connectionString)
        {
            Check.NotNull(options, nameof(options));
            Check.NotEmpty(connectionString, nameof(connectionString));

            var extension = GetOrCreateExtension(options);
            extension.ConnectionString = connectionString;
            ((IDbContextOptionsBuilderInfrastructure)options).AddOrUpdateExtension(extension);

            return new MySqlDbContextOptionsBuilder(options);
        }

        public static MySqlDbContextOptionsBuilder UseMySql([NotNull] this DbContextOptionsBuilder options, [NotNull] DbConnection connection)
        {
            Check.NotNull(options, nameof(options));
            Check.NotNull(connection, nameof(connection));

            var extension = GetOrCreateExtension(options);
            extension.Connection = connection;
            ((IDbContextOptionsBuilderInfrastructure)options).AddOrUpdateExtension(extension);

            return new MySqlDbContextOptionsBuilder(options);
        }

        private static MySqlOptionsExtension GetOrCreateExtension(DbContextOptionsBuilder options)
        {
            var existingExtension = options.Options.FindExtension<MySqlOptionsExtension>();

            return existingExtension != null
                ? new MySqlOptionsExtension(existingExtension)
                : new MySqlOptionsExtension();
        }
    }
}

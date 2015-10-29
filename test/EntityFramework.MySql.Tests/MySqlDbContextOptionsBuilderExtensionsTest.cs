// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Data.Entity.Infrastructure.Internal;
using Microsoft.Data.MySql;
using Xunit;

namespace Microsoft.Data.Entity.MySql.Tests
{
    public class MySqlDbContextOptionsBuilderExtensionsTest
    {
        [Fact]
        public void Can_add_extension_with_max_batch_size()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseMySql("Database=Crunchie").MaxBatchSize(123);

            var extension = optionsBuilder.Options.Extensions.OfType<MySqlOptionsExtension>().Single();

            Assert.Equal(123, extension.MaxBatchSize);
        }

        [Fact]
        public void Can_add_extension_with_command_timeout()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseMySql("Database=Crunchie").CommandTimeout(30);

            var extension = optionsBuilder.Options.Extensions.OfType<MySqlOptionsExtension>().Single();

            Assert.Equal(30, extension.CommandTimeout);
        }

        [Fact]
        public void Can_add_extension_with_ambient_transaction_warning_suppressed()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseMySql("Database=Crunchie").SuppressAmbientTransactionWarning();

            var extension = optionsBuilder.Options.Extensions.OfType<MySqlOptionsExtension>().Single();

            Assert.Equal(false, extension.ThrowOnAmbientTransaction);
        }

        [Fact]
        public void Can_add_extension_with_connection_string()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseMySql("Database=Crunchie");

            var extension = optionsBuilder.Options.Extensions.OfType<MySqlOptionsExtension>().Single();

            Assert.Equal("Database=Crunchie", extension.ConnectionString);
            Assert.Null(extension.Connection);
            Assert.True(extension.EnforceForeignKeys);
        }

        [Fact]
        public void Can_add_extension_with_connection_string_using_generic_options()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
            optionsBuilder.UseMySql("Database=Whisper");

            var extension = optionsBuilder.Options.Extensions.OfType<MySqlOptionsExtension>().Single();

            Assert.Equal("Database=Whisper", extension.ConnectionString);
            Assert.Null(extension.Connection);
        }

        [Fact]
        public void Can_add_extension_with_connection()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            var connection = new MySqlConnection();

            optionsBuilder.UseMySql(connection);

            var extension = optionsBuilder.Options.Extensions.OfType<MySqlOptionsExtension>().Single();

            Assert.Same(connection, extension.Connection);
            Assert.Null(extension.ConnectionString);
        }

        [Fact]
        public void Can_add_extension_with_connection_using_generic_options()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
            var connection = new MySqlConnection();

            optionsBuilder.UseMySql(connection);

            var extension = optionsBuilder.Options.Extensions.OfType<MySqlOptionsExtension>().Single();

            Assert.Same(connection, extension.Connection);
            Assert.Null(extension.ConnectionString);
        }

        [Fact]
        public void Can_suppress_foreign_keys()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();

            optionsBuilder.UseMySql("some string")
                .SuppressForeignKeyEnforcement();

            var extension = optionsBuilder.Options.Extensions.OfType<MySqlOptionsExtension>().Single();

            Assert.False(extension.EnforceForeignKeys);
        }
    }
}

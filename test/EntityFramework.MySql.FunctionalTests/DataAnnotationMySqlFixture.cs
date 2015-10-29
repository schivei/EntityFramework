// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.Data.Entity.FunctionalTests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Microsoft.Data.Entity.MySql.FunctionalTests
{
    public class DataAnnotationMySqlFixture : DataAnnotationFixtureBase<MySqlTestStore>
    {
        public static readonly string DatabaseName = "DataAnnotations";

        private readonly IServiceProvider _serviceProvider;

        private readonly string _connectionString = MySqlTestStore.CreateConnectionString(DatabaseName);

        public DataAnnotationMySqlFixture()
        {
            _serviceProvider = new ServiceCollection()
                .AddEntityFramework()
                .AddMySql()
                .ServiceCollection()
                .AddSingleton(TestMySqlModelSource.GetFactory(OnModelCreating))
                .AddInstance<ILoggerFactory>(new TestSqlLoggerFactory())
                .BuildServiceProvider();
        }

        public override MySqlTestStore CreateTestStore()
        {
            return MySqlTestStore.GetOrCreateShared(DatabaseName, () =>
                {
                    var optionsBuilder = new DbContextOptionsBuilder();
                    optionsBuilder.UseMySql(_connectionString);

                    using (var context = new DataAnnotationContext(_serviceProvider, optionsBuilder.Options))
                    {
                        // TODO: Delete DB if model changed
                        context.Database.EnsureDeleted();
                        if (context.Database.EnsureCreated())
                        {
                            DataAnnotationModelInitializer.Seed(context);
                        }

                        TestSqlLoggerFactory.SqlStatements.Clear();
                    }
                });
        }

        public override DataAnnotationContext CreateContext(MySqlTestStore testStore)
        {
            var optionsBuilder = new DbContextOptionsBuilder();

            optionsBuilder
                .EnableSensitiveDataLogging()
                .UseMySql(testStore.Connection)
                .SuppressForeignKeyEnforcement();

            var context = new DataAnnotationContext(_serviceProvider, optionsBuilder.Options);
            context.Database.UseTransaction(testStore.Transaction);
            return context;
        }
    }
}

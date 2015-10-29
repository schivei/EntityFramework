// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.Data.Entity.FunctionalTests;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Data.Entity.MySql.FunctionalTests
{
    public class GraphUpdatesMySqlTest 
        : GraphUpdatesTestBase<MySqlTestStore, GraphUpdatesMySqlTest.GraphUpdatesMySqlFixture>
    {
        public GraphUpdatesMySqlTest(GraphUpdatesMySqlFixture fixture)
            : base(fixture)
        {
        }

        public class GraphUpdatesMySqlFixture : GraphUpdatesFixtureBase
        {
            private const string DatabaseName = "GraphUpdatesTest";

            private readonly IServiceProvider _serviceProvider;

            public GraphUpdatesMySqlFixture()
            {
                _serviceProvider = new ServiceCollection()
                    .AddEntityFramework()
                    .AddMySql()
                    .ServiceCollection()
                    .AddSingleton(TestMySqlModelSource.GetFactory(OnModelCreating))
                    .BuildServiceProvider();
            }

            public override MySqlTestStore CreateTestStore()
            {
                return MySqlTestStore.GetOrCreateShared(DatabaseName, () =>
                    {
                        var optionsBuilder = new DbContextOptionsBuilder();
                        optionsBuilder.UseMySql(MySqlTestStore.CreateConnectionString(DatabaseName));

                        using (var context = new GraphUpdatesContext(_serviceProvider, optionsBuilder.Options))
                        {
                            context.Database.EnsureDeleted();
                            if (context.Database.EnsureCreated())
                            {
                                Seed(context);
                            }
                        }
                    });
            }

            public override DbContext CreateContext(MySqlTestStore testStore)
            {
                var optionsBuilder = new DbContextOptionsBuilder();
                optionsBuilder.UseMySql(testStore.Connection);

                var context = new GraphUpdatesContext(_serviceProvider, optionsBuilder.Options);
                context.Database.UseTransaction(testStore.Transaction);
                return context;
            }
        }
    }
}

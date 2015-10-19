// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Internal;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Microsoft.Data.Entity.FunctionalTests
{
    public class InMemoryTransactionTest
    {
        [Fact]
        public void Throws_on_BeginTransaction()
        {
            var serviceProvider
                = new ServiceCollection()
                .AddEntityFramework()
                .AddInMemoryDatabase()
                .ServiceCollection()
                .BuildServiceProvider();

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseInMemoryDatabase();

            using (var context = new TransactionContext(serviceProvider, optionsBuilder.Options))
            {
                Assert.Equal(
                    InMemoryStrings.TransactionsNotSupported,
                    Assert.Throws<InvalidOperationException>(
                        () => context.Database.BeginTransaction()).Message);
            }
        }

        [Fact]
        public void Does_not_throw_on_BeginTransaction_with_transaction_exceptions_suppressed()
        {
            var serviceProvider
                = new ServiceCollection()
                .AddEntityFramework()
                .AddInMemoryDatabase()
                .ServiceCollection()
                .BuildServiceProvider();

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseInMemoryDatabase()
                .IgnoreTransactions();

            using (var context = new TransactionContext(serviceProvider, optionsBuilder.Options))
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    transaction.Commit();
                    transaction.Rollback();
                }
            }
        }

        [Fact]
        public async Task Throws_on_BeginTransactionAsync()
        {
            var serviceProvider
                = new ServiceCollection()
                .AddEntityFramework()
                .AddInMemoryDatabase()
                .ServiceCollection()
                .BuildServiceProvider();

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseInMemoryDatabase();

            using (var context = new TransactionContext(serviceProvider, optionsBuilder.Options))
            {
                Assert.Equal(
                    InMemoryStrings.TransactionsNotSupported,
                    (await Assert.ThrowsAsync<InvalidOperationException>(
                        async () => await context.Database.BeginTransactionAsync())).Message);
            }
        }

        [Fact]
        public async Task Does_not_throw_on_BeginTransactionAsync_with_transaction_exceptions_suppressed()
        {
            var serviceProvider
                = new ServiceCollection()
                .AddEntityFramework()
                .AddInMemoryDatabase()
                .ServiceCollection()
                .BuildServiceProvider();

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseInMemoryDatabase()
                .IgnoreTransactions();

            using (var context = new TransactionContext(serviceProvider, optionsBuilder.Options))
            {
                using (var transaction = await context.Database.BeginTransactionAsync())
                {
                    transaction.Commit();
                    transaction.Rollback();
                }
            }
        }

        public class TransactionContext : DbContext
        {
            public TransactionContext(IServiceProvider serviceProvider, DbContextOptions options)
                : base(serviceProvider, options)
            {
            }
        }
    }
}

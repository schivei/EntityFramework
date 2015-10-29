// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Tests;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace Microsoft.Data.Entity.MySql.Tests
{
    public class MySqlTestHelpers : RelationalTestHelpers
    {
        protected MySqlTestHelpers()
        {
        }

        public new static MySqlTestHelpers Instance { get; } = new MySqlTestHelpers();

        public override EntityFrameworkServicesBuilder AddProviderServices(EntityFrameworkServicesBuilder builder)
            => builder.AddMySql();

        protected override void UseProviderOptions(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(new MySqlConnection("Data Source=:memory:"));
    }
}

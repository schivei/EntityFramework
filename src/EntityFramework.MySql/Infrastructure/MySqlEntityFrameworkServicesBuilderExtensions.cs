// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Infrastructure.Internal;
using Microsoft.Data.Entity.Metadata.Conventions.Internal;
using Microsoft.Data.Entity.Metadata.Internal;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Internal;
using Microsoft.Data.Entity.Query.ExpressionTranslators.Internal;
using Microsoft.Data.Entity.Query.Sql;
using Microsoft.Data.Entity.Storage;
using Microsoft.Data.Entity.Storage.Internal;
using Microsoft.Data.Entity.Update.Internal;
using Microsoft.Data.Entity.Utilities;
using Microsoft.Data.Entity.ValueGeneration.Internal;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MySqlEntityFrameworkServicesBuilderExtensions
    {
        public static EntityFrameworkServicesBuilder AddMySql([NotNull] this EntityFrameworkServicesBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            var service = builder.AddRelational().GetInfrastructure();

            service.TryAddEnumerable(ServiceDescriptor
                .Singleton<IDatabaseProvider, DatabaseProvider<MySqlDatabaseProviderServices, MySqlOptionsExtension>>());

            service.TryAdd(new ServiceCollection()
                .AddSingleton<MySqlValueGeneratorCache>()
                .AddSingleton<MySqlAnnotationProvider>()
                .AddSingleton<MySqlTypeMapper>()
                .AddSingleton<MySqlSqlGenerator>()
                .AddSingleton<MySqlModelSource>()
                .AddSingleton<MySqlMigrationsAnnotationProvider>()
                .AddScoped<MySqlModelValidator>()
                .AddScoped<MySqlConventionSetBuilder>()
                .AddScoped<MySqlUpdateSqlGenerator>()
                .AddScoped<MySqlModificationCommandBatchFactory>()
                .AddScoped<MySqlDatabaseProviderServices>()
                .AddScoped<MySqlRelationalConnection>()
                .AddScoped<MySqlMigrationsSqlGenerator>()
                .AddScoped<MySqlDatabaseCreator>()
                .AddScoped<MySqlHistoryRepository>()
                .AddQuery());

            return builder;
        }

        private static IServiceCollection AddQuery(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddScoped<MySqlCompositeMemberTranslator>()
                .AddScoped<MySqlCompositeMethodCallTranslator>()
                .AddScoped<MySqlQuerySqlGeneratorFactory>();
    }
}

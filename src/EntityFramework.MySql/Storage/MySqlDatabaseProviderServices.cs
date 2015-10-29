// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Reflection;
using JetBrains.Annotations;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Infrastructure.Internal;
using Microsoft.Data.Entity.Internal;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Conventions.Internal;
using Microsoft.Data.Entity.Metadata.Internal;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Internal;
using Microsoft.Data.Entity.Query.ExpressionTranslators;
using Microsoft.Data.Entity.Query.ExpressionTranslators.Internal;
using Microsoft.Data.Entity.Query.Sql;
using Microsoft.Data.Entity.Storage.Internal;
using Microsoft.Data.Entity.Update;
using Microsoft.Data.Entity.Update.Internal;
using Microsoft.Data.Entity.ValueGeneration;
using Microsoft.Data.Entity.ValueGeneration.Internal;

namespace Microsoft.Data.Entity.Storage
{
    public class MySqlDatabaseProviderServices : RelationalDatabaseProviderServices
    {
        public MySqlDatabaseProviderServices([NotNull] IServiceProvider services)
            : base(services)
        {
        }

        public override string InvariantName => GetType().GetTypeInfo().Assembly.GetName().Name;
        public override IDatabaseCreator Creator => GetService<MySqlDatabaseCreator>();
        public override IHistoryRepository HistoryRepository => GetService<MySqlHistoryRepository>();
        public override ISqlGenerator SqlGenerator => GetService<MySqlSqlGenerator>();
        public override IMigrationsSqlGenerator MigrationsSqlGenerator => GetService<MySqlMigrationsSqlGenerator>();
        public override IModelSource ModelSource => GetService<MySqlModelSource>();
        public override IRelationalConnection RelationalConnection => GetService<MySqlRelationalConnection>();
        public override IUpdateSqlGenerator UpdateSqlGenerator => GetService<MySqlUpdateSqlGenerator>();
        public override IValueGeneratorCache ValueGeneratorCache => GetService<MySqlValueGeneratorCache>();
        public override IRelationalTypeMapper TypeMapper => GetService<MySqlTypeMapper>();
        public override IModificationCommandBatchFactory ModificationCommandBatchFactory => GetService<MySqlModificationCommandBatchFactory>();
        public override IRelationalDatabaseCreator RelationalDatabaseCreator => GetService<MySqlDatabaseCreator>();
        public override IConventionSetBuilder ConventionSetBuilder => GetService<MySqlConventionSetBuilder>();
        public override IRelationalAnnotationProvider AnnotationProvider => GetService<MySqlAnnotationProvider>();
        public override IMethodCallTranslator CompositeMethodCallTranslator => GetService<MySqlCompositeMethodCallTranslator>();
        public override IMemberTranslator CompositeMemberTranslator => GetService<MySqlCompositeMemberTranslator>();
        public override IMigrationsAnnotationProvider MigrationsAnnotationProvider => GetService<MySqlMigrationsAnnotationProvider>();
        public override ISqlQueryGeneratorFactory SqlQueryGeneratorFactory => GetService<MySqlQuerySqlGeneratorFactory>();
        public override IModelValidator ModelValidator => GetService<MySqlModelValidator>();
    }
}

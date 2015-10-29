// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Data.Entity.Infrastructure.Internal;
using Microsoft.Data.Entity.Metadata.Conventions.Internal;
using Microsoft.Data.Entity.Metadata.Internal;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Internal;
using Microsoft.Data.Entity.Query.ExpressionTranslators.Internal;
using Microsoft.Data.Entity.MySql.Tests;
using Microsoft.Data.Entity.Storage;
using Microsoft.Data.Entity.Storage.Internal;
using Microsoft.Data.Entity.Tests;
using Microsoft.Data.Entity.Update.Internal;
using Microsoft.Data.Entity.ValueGeneration.Internal;

namespace Microsoft.Data.Entity
{
    public class MySqlEntityFrameworkServicesBuilderExtensionsTest : RelationalEntityFrameworkServicesBuilderExtensionsTest
    {
        public override void Services_wire_up_correctly()
        {
            base.Services_wire_up_correctly();

            // MySql dingletones
            VerifySingleton<MySqlValueGeneratorCache>();
            VerifySingleton<MySqlAnnotationProvider>();
            VerifySingleton<MySqlTypeMapper>();
            VerifySingleton<MySqlModelSource>();
            VerifySingleton<MySqlMigrationsAnnotationProvider>();

            // MySql scoped
            VerifyScoped<MySqlConventionSetBuilder>();
            VerifyScoped<MySqlUpdateSqlGenerator>();
            VerifyScoped<MySqlModificationCommandBatchFactory>();
            VerifyScoped<MySqlDatabaseProviderServices>();
            VerifyScoped<MySqlRelationalConnection>();
            VerifyScoped<MySqlMigrationsSqlGenerator>();
            VerifyScoped<MySqlDatabaseCreator>();
            VerifyScoped<MySqlHistoryRepository>();
            VerifyScoped<MySqlCompositeMethodCallTranslator>();
            VerifyScoped<MySqlCompositeMemberTranslator>();
            VerifyScoped<MySqlModelValidator>();
        }

        public MySqlEntityFrameworkServicesBuilderExtensionsTest()
            : base(MySqlTestHelpers.Instance)
        {
        }
    }
}

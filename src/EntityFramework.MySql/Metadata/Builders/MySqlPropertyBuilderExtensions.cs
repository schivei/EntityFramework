// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Utilities;

// ReSharper disable once CheckNamespace

namespace Microsoft.Data.Entity
{
    public static class MySqlPropertyBuilderExtensions
    {
        public static PropertyBuilder ForMySqlHasColumnName([NotNull] this PropertyBuilder builder, [CanBeNull] string name)
        {
            Check.NotNull(builder, nameof(builder));
            Check.NullButNotEmpty(name, nameof(name));

            builder.Metadata.MySql().ColumnName = name;

            return builder;
        }

        public static PropertyBuilder<TEntity> ForMySqlHasColumnName<TEntity>(
            [NotNull] this PropertyBuilder<TEntity> builder,
            [CanBeNull] string name)
            where TEntity : class
            => (PropertyBuilder<TEntity>)((PropertyBuilder)builder).ForMySqlHasColumnName(name);

        public static PropertyBuilder ForMySqlHasColumnType([NotNull] this PropertyBuilder builder, [CanBeNull] string type)
        {
            Check.NotNull(builder, nameof(builder));
            Check.NullButNotEmpty(type, nameof(type));

            builder.Metadata.MySql().ColumnType = type;

            return builder;
        }

        public static PropertyBuilder<TEntity> ForMySqlHasColumnType<TEntity>(
            [NotNull] this PropertyBuilder<TEntity> builder,
            [CanBeNull] string type)
            where TEntity : class
            => (PropertyBuilder<TEntity>)((PropertyBuilder)builder).ForMySqlHasColumnType(type);

        public static PropertyBuilder ForMySqlHasDefaultValueSql(
            [NotNull] this PropertyBuilder builder,
            [CanBeNull] string sql)
        {
            Check.NotNull(builder, nameof(builder));
            Check.NullButNotEmpty(sql, nameof(sql));

            builder.ValueGeneratedOnAdd();
            builder.Metadata.MySql().GeneratedValueSql = sql;

            return builder;
        }

        public static PropertyBuilder<TEntity> ForMySqlHasDefaultValueSql<TEntity>(
            [NotNull] this PropertyBuilder<TEntity> builder,
            [CanBeNull] string sql)
            where TEntity : class
            => (PropertyBuilder<TEntity>)((PropertyBuilder)builder).ForMySqlHasDefaultValueSql(sql);
    }
}

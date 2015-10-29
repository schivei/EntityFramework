﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Utilities;

// ReSharper disable once CheckNamespace

namespace Microsoft.Data.Entity
{
    public static class MySqlReferenceCollectionBuilderExtensions
    {
        public static ReferenceCollectionBuilder ForMySqlHasConstraintName(
            [NotNull] this ReferenceCollectionBuilder builder,
            [CanBeNull] string name)
        {
            Check.NotNull(builder, nameof(builder));
            Check.NullButNotEmpty(name, nameof(name));

            builder.Metadata.MySql().Name = name;

            return builder;
        }

        public static ReferenceCollectionBuilder<TEntity, TReferencedEntity> ForMySqlHasConstraintName<TEntity, TReferencedEntity>(
            [NotNull] this ReferenceCollectionBuilder<TEntity, TReferencedEntity> builder,
            [CanBeNull] string name)
            where TEntity : class
            where TReferencedEntity : class
            => (ReferenceCollectionBuilder<TEntity, TReferencedEntity>)((ReferenceCollectionBuilder)builder).ForMySqlHasConstraintName(name);
    }
}

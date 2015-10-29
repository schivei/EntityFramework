// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Internal;
using Microsoft.Data.Entity.Utilities;

// ReSharper disable once CheckNamespace

namespace Microsoft.Data.Entity
{
    public static class MySqlMetadataExtensions
    {
        public static IRelationalEntityTypeAnnotations MySql([NotNull] this IEntityType entityType)
            => new RelationalEntityTypeAnnotations(Check.NotNull(entityType, nameof(entityType)), MySqlAnnotationNames.Prefix);

        public static RelationalEntityTypeAnnotations MySql([NotNull] this IMutableEntityType entityType)
            => (RelationalEntityTypeAnnotations)MySql((IEntityType)entityType);

        public static IRelationalForeignKeyAnnotations MySql([NotNull] this IForeignKey foreignKey)
            => new RelationalForeignKeyAnnotations(Check.NotNull(foreignKey, nameof(foreignKey)), MySqlAnnotationNames.Prefix);

        public static RelationalForeignKeyAnnotations MySql([NotNull] this IMutableForeignKey foreignKey)
            => (RelationalForeignKeyAnnotations)MySql((IForeignKey)foreignKey);

        public static IRelationalIndexAnnotations MySql([NotNull] this IIndex index)
            => new RelationalIndexAnnotations(Check.NotNull(index, nameof(index)), MySqlAnnotationNames.Prefix);

        public static RelationalIndexAnnotations MySql([NotNull] this IMutableIndex index)
            => (RelationalIndexAnnotations)MySql((IIndex)index);

        public static IRelationalKeyAnnotations MySql([NotNull] this IKey key)
            => new RelationalKeyAnnotations(Check.NotNull(key, nameof(key)), MySqlAnnotationNames.Prefix);

        public static RelationalKeyAnnotations MySql([NotNull] this IMutableKey key)
            => (RelationalKeyAnnotations)MySql((IKey)key);

        public static RelationalModelAnnotations MySql([NotNull] this IMutableModel model)
            => (RelationalModelAnnotations)MySql((IModel)model);

        public static IRelationalModelAnnotations MySql([NotNull] this IModel model)
            => new RelationalModelAnnotations(Check.NotNull(model, nameof(model)), MySqlAnnotationNames.Prefix);

        public static IRelationalPropertyAnnotations MySql([NotNull] this IProperty property)
            => new RelationalPropertyAnnotations(Check.NotNull(property, nameof(property)), MySqlAnnotationNames.Prefix);

        public static RelationalPropertyAnnotations MySql([NotNull] this IMutableProperty property)
            => (RelationalPropertyAnnotations)MySql((IProperty)property);
    }
}

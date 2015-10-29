// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;

namespace Microsoft.Data.Entity.Metadata.Internal
{
    public static class MySqlInternalMetadataBuilderExtensions
    {
        public static RelationalModelBuilderAnnotations MySql(
            [NotNull] this InternalModelBuilder builder,
            ConfigurationSource configurationSource)
            => new RelationalModelBuilderAnnotations(builder, configurationSource, MySqlAnnotationNames.Prefix);

        public static RelationalPropertyBuilderAnnotations MySql(
            [NotNull] this InternalPropertyBuilder builder,
            ConfigurationSource configurationSource)
            => new RelationalPropertyBuilderAnnotations(builder, configurationSource, MySqlAnnotationNames.Prefix);

        public static RelationalEntityTypeBuilderAnnotations MySql(
            [NotNull] this InternalEntityTypeBuilder builder,
            ConfigurationSource configurationSource)
            => new RelationalEntityTypeBuilderAnnotations(builder, configurationSource, MySqlAnnotationNames.Prefix);

        public static RelationalKeyBuilderAnnotations MySql(
            [NotNull] this InternalKeyBuilder builder,
            ConfigurationSource configurationSource)
            => new RelationalKeyBuilderAnnotations(builder, configurationSource, MySqlAnnotationNames.Prefix);

        public static RelationalIndexBuilderAnnotations MySql(
            [NotNull] this InternalIndexBuilder builder,
            ConfigurationSource configurationSource)
            => new RelationalIndexBuilderAnnotations(builder, configurationSource, MySqlAnnotationNames.Prefix);

        public static RelationalForeignKeyBuilderAnnotations MySql(
            [NotNull] this InternalRelationshipBuilder builder,
            ConfigurationSource configurationSource)
            => new RelationalForeignKeyBuilderAnnotations(builder, configurationSource, MySqlAnnotationNames.Prefix);
    }
}

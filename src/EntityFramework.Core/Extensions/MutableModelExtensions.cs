// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using JetBrains.Annotations;
using Microsoft.Data.Entity.Internal;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Utilities;

namespace Microsoft.Data.Entity
{
    public static class MutableModelExtensions
    {
        public static IMutableEntityType FindEntityType([NotNull] this IMutableModel model, [NotNull] Type type)
            => (IMutableEntityType)((IModel)model).FindEntityType(type);

        public static IMutableEntityType GetOrAddEntityType([NotNull] this IMutableModel model, [NotNull] string name)
        {
            Check.NotNull(model, nameof(model));

            return model.FindEntityType(name) ?? model.AddEntityType(name);
        }

        public static IMutableEntityType GetOrAddEntityType([NotNull] this IMutableModel model, [NotNull] Type type)
            => model.FindEntityType(type) ?? model.AddEntityType(type);

        public static IMutableEntityType AddEntityType([NotNull] this IMutableModel model, [NotNull] Type type)
        {
            Check.NotNull(model, nameof(model));
            Check.NotNull(type, nameof(type));

            var entityType = model.AddEntityType(type.DisplayName());
            entityType.ClrType = type;
            return entityType;
        }

        public static IMutableEntityType RemoveEntityType([NotNull] this IMutableModel model, [NotNull] Type type)
        {
            Check.NotNull(model, nameof(model));
            Check.NotNull(type, nameof(type));

            return model.RemoveEntityType(type.DisplayName());
        }
    }
}

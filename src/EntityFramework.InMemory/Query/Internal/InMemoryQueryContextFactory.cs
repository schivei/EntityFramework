// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.Data.Entity.ChangeTracking.Internal;
using Microsoft.Data.Entity.Storage.Internal;
using Microsoft.Data.Entity.Utilities;

namespace Microsoft.Data.Entity.Query.Internal
{
    public class InMemoryQueryContextFactory : QueryContextFactory
    {
        private readonly IInMemoryDatabase _database;

        public InMemoryQueryContextFactory(
            [NotNull] IStateManager stateManager,
            [NotNull] IKeyValueFactorySource keyValueFactorySource,
            [NotNull] IInMemoryDatabase database)
            : base(stateManager, keyValueFactorySource)
        {
            Check.NotNull(database, nameof(database));

            _database = database;
        }

        public override QueryContext Create()
            => new InMemoryQueryContext(CreateQueryBuffer, _database.Store);
    }
}

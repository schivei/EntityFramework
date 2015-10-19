﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.Data.Entity.Storage
{
    public class InMemoryTransaction : IDbContextTransaction
    {
        public InMemoryTransaction()
        {
        }

        public virtual void Commit()
        {
        }

        public virtual void Rollback()
        {
        }

        public virtual void Dispose()
        {
        }
    }
}

﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Data.Entity.FunctionalTests;

namespace Microsoft.Data.Entity.MySql.FunctionalTests
{
    public class AsyncFromSqlQueryMySqlTest : AsyncFromSqlQueryTestBase<NorthwindQueryMySqlFixture>
    {
        public AsyncFromSqlQueryMySqlTest(NorthwindQueryMySqlFixture fixture)
            : base(fixture)
        {
        }
    }
}

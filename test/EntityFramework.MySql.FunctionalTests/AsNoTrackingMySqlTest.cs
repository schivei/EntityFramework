// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Data.Entity.FunctionalTests;

namespace Microsoft.Data.Entity.MySql.FunctionalTests
{
    public class AsNoTrackingMySqlTest : AsNoTrackingTestBase<NorthwindQueryMySqlFixture>
    {
        public AsNoTrackingMySqlTest(NorthwindQueryMySqlFixture fixture)
            : base(fixture)
        {
        }
    }
}

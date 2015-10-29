// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.IO;
using Xunit.Abstractions;

namespace EntityFramework.MySql.Design.FunctionalTests.ReverseEngineering
{
    public class MySqlAllFluentApiE2ETest : MySqlE2ETestBase
    {
        public MySqlAllFluentApiE2ETest(ITestOutputHelper output)
            : base(output)
        {
        }

        protected override string DbSuffix { get; } = "FluentApi";
        protected override bool UseFluentApiOnly { get; } = true;
        protected override string ExpectedResultsParentDir { get; } = Path.Combine("ReverseEngineering", "Expected", "AllFluentApi");

        protected override string ProviderName => "EntityFramework.MySql.Design";
    }
}

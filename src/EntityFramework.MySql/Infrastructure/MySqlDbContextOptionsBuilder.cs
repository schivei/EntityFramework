﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.Data.Entity.Infrastructure.Internal;

namespace Microsoft.Data.Entity.Infrastructure
{
    public class MySqlDbContextOptionsBuilder : RelationalDbContextOptionsBuilder<MySqlDbContextOptionsBuilder, MySqlOptionsExtension>
    {
        public MySqlDbContextOptionsBuilder([NotNull] DbContextOptionsBuilder optionsBuilder)
            : base(optionsBuilder)
        {
        }

        protected override MySqlOptionsExtension CloneExtension()
            => new MySqlOptionsExtension(OptionsBuilder.Options.GetExtension<MySqlOptionsExtension>());

        public virtual MySqlDbContextOptionsBuilder SuppressForeignKeyEnforcement()
            => SetOption(e => e.EnforceForeignKeys = false);
    }
}

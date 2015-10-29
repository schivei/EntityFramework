// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace Microsoft.Data.Entity.Query.ExpressionTranslators.Internal
{
    public class MySqlCompositeMethodCallTranslator : RelationalCompositeMethodCallTranslator
    {
        private static readonly IMethodCallTranslator[] _MySqlTranslators =
        {
            new MySqlMathAbsTranslator(),
            new MySqlStringToLowerTranslator(),
            new MySqlStringToUpperTranslator()
        };

        public MySqlCompositeMethodCallTranslator(
            [NotNull] ILogger<MySqlCompositeMethodCallTranslator> logger)
            : base(logger)
        {
            AddTranslators(_MySqlTranslators);
        }
    }
}

using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.Data.Entity.Infrastructure;

namespace Microsoft.Data.Entity.Metadata
{
    public interface IMutableAnnotatable : IAnnotatable
    {
        new object this[[NotNull] string annotationName] { get; [param: CanBeNull] set; }
        new IEnumerable<Annotation> GetAnnotations();
        Annotation AddAnnotation([NotNull] string annotationName, [NotNull] object value);
        new Annotation FindAnnotation([NotNull] string annotationName);
        Annotation RemoveAnnotation([NotNull] string annotationName);
    }
}
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Microsoft.Data.Entity.Metadata
{
    /// <summary>
    ///     <para>
    ///         Represents a relationship where a foreign key property(s) in a dependent entity type
    ///         reference a corresponding primary or alternate key in a principal entity type.
    ///     </para>
    ///     <para>
    ///         This interface is used during model creation and allows the metadata to be modified.
    ///         Once the model is built, <see cref="IForeignKey"/> represents a ready-only view of the same metadata.
    ///     </para>
    /// </summary>
    public interface IMutableForeignKey : IForeignKey, IMutableAnnotatable
    {
        /// <summary>
        ///     Gets the foreign key properties in the dependent entity.
        /// </summary>
        new IReadOnlyList<IMutableProperty> Properties { get; }

        /// <summary>
        ///     Gets the primary or alternate key that the relationship targets.
        /// </summary>
        new IMutableKey PrincipalKey { get; }

        /// <summary>
        ///     Gets the dependent entity type. This may be different from the type that <see cref="Properties"/>
        ///     are defined on when the relationship is defined a derived type in an inheritance hierarchy (since the properties
        ///     may be defined on a base type).
        /// </summary>
        new IMutableEntityType DeclaringEntityType { get; }

        /// <summary>
        ///     Gets the principal entity type that this relationship targets. This may be different from the type that 
        ///     <see cref="PrincipalKey"/> is defined on when the relationship targets a derived type in an inheritance 
        ///     hierarchy (since the key is defined on the base type of the hierarchy).
        /// </summary>
        new IMutableEntityType PrincipalEntityType { get; }

        /// <summary>
        ///     Gets or sets the navigation property on the dependent entity type that points to the principal entity.
        /// </summary>
        new IMutableNavigation DependentToPrincipal { get; [param: CanBeNull] set; }

        /// <summary>
        ///     Gets or sets the navigation property on the principal entity type that points to the dependent entity(s).
        /// </summary>
        new IMutableNavigation PrincipalToDependent { get; [param: CanBeNull] set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the values assigned to the foreign key properties are unique.
        /// </summary>
        new bool? IsUnique { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating if this relationship is required. If true, the dependent entity must always be
        ///     assigned to a valid principal entity.
        /// </summary>
        new bool? IsRequired { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating how a delete operation is applied to dependent entities in the relationship when the 
        ///     principal is deleted or the relationship is severed.
        /// </summary>
        new DeleteBehavior? DeleteBehavior { get; set; }
    }
}
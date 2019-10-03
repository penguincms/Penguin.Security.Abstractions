using System.Collections.Generic;

namespace Penguin.Security.Abstractions.Interfaces
{
    /// <summary>
    /// An interface denoting that the object can be directly assigned roles as permissions
    /// </summary>
    public interface IHasRoles
    {
        /// <summary>
        /// A list of roles that the object belongs to
        /// </summary>
        IReadOnlyList<IRole> Roles { get; }
    }
}
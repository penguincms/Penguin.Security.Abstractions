using System.Collections.Generic;

namespace Penguin.Security.Abstractions.Interfaces
{
    /// <summary>
    /// An interface denoting that an object can be assigned to groups
    /// </summary>
    public interface IHasGroups
    {
        /// <summary>
        /// A list of groups that the object belongs to
        /// </summary>
        IEnumerable<IGroup> Groups { get; }
    }
}
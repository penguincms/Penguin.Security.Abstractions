using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Security.Abstractions.Interfaces
{
    /// <summary>
    /// An interface representing an object that can be assigned permissions
    /// </summary>
    public interface IPermissionableEntity 
    {
        /// <summary>
        /// A list of permissions assigned to the object
        /// </summary>
        IReadOnlyList<ISecurityGroupPermission> Permissions { get; }
    }
}

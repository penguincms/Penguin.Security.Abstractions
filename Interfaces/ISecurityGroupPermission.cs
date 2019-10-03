using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Security.Abstractions.Interfaces
{
    /// <summary>
    /// An interface representing an individual permission for an object
    /// </summary>
    public interface ISecurityGroupPermission
    {
        /// <summary>
        /// The security group this permission applies to
        /// </summary>
        ISecurityGroup SecurityGroup { get; }

        /// <summary>
        /// The type of the permissions this grants
        /// </summary>
        PermissionTypes Type { get; }
    }
}

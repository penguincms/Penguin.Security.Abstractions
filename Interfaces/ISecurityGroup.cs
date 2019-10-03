using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Security.Abstractions.Interfaces
{
    /// <summary>
    /// An interface representing the common base type for users, groups, and roles
    /// </summary>
    public interface ISecurityGroup
    {
        /// <summary>
        /// A unique string ID for the security object
        /// </summary>
        string ExternalId { get; }

        /// <summary>
        /// A description of the object
        /// </summary>
        string Description { get; }


        /// <summary>
        /// An unchanging guid representing the object
        /// </summary>
        Guid Guid { get; }
    }
}

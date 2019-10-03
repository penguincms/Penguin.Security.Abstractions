using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Security.Abstractions.Interfaces
{
    /// <summary>
    /// An attribute used to enforce role requirements
    /// </summary>
    public interface IRequiresRoleAttribute
    {
        /// <summary>
        /// A list of string ID's for the allowed roles
        /// </summary>
        IReadOnlyList<string> AllowedRoles { get; }
    }
}

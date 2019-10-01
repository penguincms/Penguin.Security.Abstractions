using Penguin.Security.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Security.Abstractions.Extensions
{
    public static class ISecurityGroupPermissionExtensions
    {
        /// <summary>
        /// Checks this permission using flags, to determine if this allows for a particular kind of access
        /// </summary>
        /// <param name="type">The access type to check for</param>
        /// <returns>True if the access should be granted</returns>
        public static bool HasPermission(this ISecurityGroupPermission securityGroupPermission, PermissionTypes type)
        {
            return securityGroupPermission.Type.HasFlag(type);
        }
    }
}

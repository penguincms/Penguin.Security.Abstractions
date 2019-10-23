using Penguin.Security.Abstractions.Interfaces;

namespace Penguin.Security.Abstractions.Extensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    public static class ISecurityGroupPermissionExtensions
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
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
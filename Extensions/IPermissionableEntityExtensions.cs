using Penguin.Security.Abstractions.Interfaces;
using System;
using System.Linq;

namespace Penguin.Security.Abstractions.Extensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    public static class IEntityPermissionsExtensions
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// Checks to see if the user specified is allowed to access this object in a given way, based on its groups/roles
        /// </summary>
        /// <param name="user">The user to check for access</param>
        /// <param name="type">The type of access to check for</param>
        /// <returns>Whether or not the given user is allowed the requested access type</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "user.SecurityGroups() incorrectly reporting error")]
        public static bool AllowsAccessType(this IEntityPermissions source, IUser user, PermissionTypes type)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            foreach (ISecurityGroup securityGroup in user.SecurityGroups())
            {
                if (source.Permissions.Any(sg => sg.HasPermission(type) && sg.SecurityGroup.ExternalId == securityGroup.ExternalId))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
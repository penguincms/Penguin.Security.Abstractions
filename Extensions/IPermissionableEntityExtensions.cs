using Penguin.Security.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Penguin.Security.Abstractions.Extensions
{
    public static class IPermissionableEntityExtensions
    {
        /// <summary>
        /// Checks to see if the user specified is allowed to access this object in a given way, based on its groups/roles
        /// </summary>
        /// <param name="user">The user to check for access</param>
        /// <param name="type">The type of access to check for</param>
        /// <returns>Whether or not the given user is allowed the requested access type</returns>
        public static bool AllowsAccessType<TSecurityGroupPermission, TSecurityGroup, TGroup, TRole>(this IPermissionableEntity<TSecurityGroupPermission, TSecurityGroup> source, IUser<TGroup, TRole> user, PermissionTypes type) where TSecurityGroupPermission : ISecurityGroupPermission<TSecurityGroup> where TSecurityGroup : ISecurityGroup where TGroup : IGroup<IRole> where TRole : IRole
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            foreach (TSecurityGroup securityGroup in user.SecurityGroups())
            {
                if(source.Permissions.Any(sg => sg.HasPermission<TSecurityGroupPermission, TSecurityGroup>(type) && sg.SecurityGroup.ExternalId == securityGroup.ExternalId))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

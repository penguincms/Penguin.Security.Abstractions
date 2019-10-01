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
        public static bool AllowsAccessType(this IPermissionableEntity source, IUser user, PermissionTypes type)
        {
            foreach(ISecurityGroup securityGroup in user.SecurityGroups())
            {
                if(source.Permissions.Any(sg => sg.HasPermission(type) && sg.SecurityGroup.ExternalId == securityGroup.ExternalId))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

using Penguin.Security.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Penguin.Security.Abstractions.Extensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    public static class IUserExtensions
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// Returns all roles from associated groups as well as directly assigned
        /// </summary>
        /// <param name="target">The object to retrieve roles for</param>
        /// <returns>An IEnumerable of distinct roles</returns>
        public static IEnumerable<IRole> AllRoles(this IHasGroupsAndRoles target)
        {
            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            List<IRole> allRoles = new List<IRole>();

            if (target.Groups != null)
            {
                foreach (IGroup g in target.Groups)
                {
                    if (g.Roles != null)
                    {
                        foreach (IRole r in g.Roles)
                        {
                            if (!allRoles.Contains(r))
                            {
                                yield return r;
                                allRoles.Add(r);
                            }
                        }
                    }
                }
            }

            if (target.Roles != null)
            {
                foreach (IRole r in target.Roles)
                {
                    if (!allRoles.Contains(r))
                    {
                        yield return r;
                        allRoles.Add(r);
                    }
                }
            }
        }

        /// <summary>
        /// Checks the target group list to see if a group exists
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <param name="thisGroup">The group to check for</param>
        /// <returns>If the target has the group in its group list</returns>
        public static bool HasGroup(this IHasGroups target, IGroup thisGroup)
        {
            if (thisGroup is null)
            {
                throw new ArgumentNullException(nameof(thisGroup));
            }

            return target.HasGroup(thisGroup.ExternalId);
        }

        /// <summary>
        /// Checks the target group list to see if a group exists
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <param name="groupName">The group name to check for</param>
        /// <returns>If the target has the group in its group list</returns>
        public static bool HasGroup(this IHasGroups target, string groupName)
        {
            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return target.Groups.Any(g => string.Equals(groupName, g.ExternalId, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Checks the target role list and roles associated with groups to see if a role exists
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <param name="thisRole">The role to check for</param>
        /// <returns>If the target has the role in its role list</returns>
        public static bool HasRole(this IHasGroupsAndRoles target, IRole thisRole)
        {
            if (thisRole is null)
            {
                throw new ArgumentNullException(nameof(thisRole));
            }

            return target.HasRole(thisRole.ExternalId);
        }

        /// <summary>
        /// Checks the target role list to see if a role exists
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <param name="thisRole">The role to check for</param>
        /// <returns>If the target has the role in its role list</returns>
        public static bool HasRole(this IHasRoles target, IRole thisRole)
        {
            if (thisRole is null)
            {
                throw new ArgumentNullException(nameof(thisRole));
            }

            return target.HasRole(thisRole.ExternalId);
        }

        /// <summary>
        /// Checks the target role list and roles associated with groups to see if a role exists
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <param name="roleName">The name of the role to check for</param>
        /// <returns>If the target has the role</returns>
        public static bool HasRole(this IHasGroupsAndRoles target, string roleName)
        {
            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            List<IRole> userRoles = target.Roles.ToList() ?? new List<IRole>();

            List<IRole> groupRoles = target.Groups?.SelectMany(g => g.Roles)?.ToList() ?? new List<IRole>();

            return userRoles.Any(r => string.Equals(r.ExternalId, roleName, StringComparison.InvariantCultureIgnoreCase)) || groupRoles.Any(r => string.Equals(r.ExternalId, roleName, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Checks the target role list to see if a role exists
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <param name="roleName">The name of the role to check for</param>
        /// <returns>If the target has the role in its role list</returns>
        public static bool HasRole(this IHasRoles target, string roleName)
        {
            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            ICollection<IRole> userRoles = target.Roles.ToList() ?? new List<IRole>();
            return userRoles.Any(r => string.Equals(r.ExternalId, roleName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
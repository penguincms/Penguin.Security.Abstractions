using Penguin.Security.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace Penguin.Security.Abstractions.Extensions
{
    public static class IUserExtensions
    {

        /// <summary>
        /// Returns all roles from associated groups as well as directly assigned
        /// </summary>
        /// <param name="target">The object to retrieve roles for</param>
        /// <returns>An IEnumerable of distinct roles</returns>
        public static IEnumerable<TRole> AllRoles<TGroup, TRole>(this IHasGroupsAndRoles<TGroup, TRole> target) where TGroup : IGroup<IRole> where TRole : IRole
        {
            Contract.Requires(target != null);

            List<IRole> allRoles = new List<IRole>();

            if (target.Groups != null)
            {
                foreach (TGroup g in target.Groups)
                {
                    if (g.Roles != null)
                    {
                        foreach (TRole r in g.Roles)
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
                foreach (TRole r in target.Roles)
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
        public static bool HasGroup<TGroup>(this IHasGroups<TGroup> target, TGroup thisGroup) where TGroup : IGroup<IRole> 
        {
            Contract.Requires(target != null);
            Contract.Requires(thisGroup != null);
            return target.HasGroup(thisGroup.ExternalId);
        }

        /// <summary>
        /// Checks the target group list to see if a group exists
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <param name="groupName">The group name to check for</param>
        /// <returns>If the target has the group in its group list</returns>
        public static bool HasGroup<TGroup>(this IHasGroups<TGroup> target, string groupName) where TGroup : IGroup<IRole>
        {
            Contract.Requires(target != null);
            return target.Groups.Any(g => string.Equals(groupName, g.ExternalId, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Checks the target role list and roles associated with groups to see if a role exists
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <param name="thisRole">The role to check for</param>
        /// <returns>If the target has the role in its role list</returns>
        public static bool HasRole<TGroup, TRole>(this IHasGroupsAndRoles<TGroup, TRole> target, TRole thisRole) where TGroup : IGroup<IRole> where TRole : IRole
        {
            Contract.Requires(target != null);
            Contract.Requires(thisRole != null);
            return target.HasRole(thisRole.ExternalId);
        }

        /// <summary>
        /// Checks the target role list to see if a role exists
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <param name="thisRole">The role to check for</param>
        /// <returns>If the target has the role in its role list</returns>
        public static bool HasRole<TRole>(this IHasRoles<TRole> target, TRole thisRole) where TRole : IRole
        {
            Contract.Requires(target != null);
            Contract.Requires(thisRole != null);
            return target.HasRole(thisRole.ExternalId);
        }

        /// <summary>
        /// Checks the target role list and roles associated with groups to see if a role exists
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <param name="roleName">The name of the role to check for</param>
        /// <returns>If the target has the role</returns>
        public static bool HasRole<TGroup, TRole>(this IHasGroupsAndRoles<TGroup, TRole> target, string roleName) where TGroup : IGroup<IRole> where TRole : IRole
        {
            Contract.Requires(target != null);

            List<TRole> userRoles = target.Roles.ToList() ?? new List<TRole>();
            
            List<IRole> groupRoles = target.Groups?.SelectMany(g => g.Roles)?.ToList() ?? new List<IRole>();

            return userRoles.Any(r => string.Equals(r.ExternalId, roleName, StringComparison.InvariantCultureIgnoreCase)) || groupRoles.Any(r => string.Equals(r.ExternalId, roleName, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Checks the target role list to see if a role exists
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <param name="roleName">The name of the role to check for</param>
        /// <returns>If the target has the role in its role list</returns>
        public static bool HasRole<TRole>(this IHasRoles<TRole> target, string roleName) where TRole : IRole
        {
            Contract.Requires(target != null);

            ICollection<TRole> userRoles = target.Roles.ToList() ?? new List<TRole>();
            return userRoles.Any(r => string.Equals(r.ExternalId, roleName, StringComparison.InvariantCultureIgnoreCase));
        }

    }
}

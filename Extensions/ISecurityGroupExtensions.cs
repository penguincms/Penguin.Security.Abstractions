using Penguin.Security.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Penguin.Security.Abstractions.Extensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    public static class ISecurityGroupExtensions
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// Returns a list of Guids representing the user themselves, all groups, and all roles (inc recursive)
        /// </summary>
        /// <param name="target">The user to check</param>
        /// <returns>A list of Guids representing the user themselves, all groups, and all roles (inc recursive)</returns>
        public static IEnumerable<Guid> SecurityGroupGuids(this IUser target)
        {
            Contract.Requires(target != null);

            yield return target.Guid;

            foreach (Guid g in GetGroupGuids(target))
            {
                yield return g;
            }

            foreach (Guid g in GetRoleGuids(target))
            {
                yield return g;
            }
        }

        /// <summary>
        /// Gets a list of security groups for the user containing themselves, all groups, and all roles (inc recursive)
        /// </summary>
        /// <param name="target">The user to retrieve the security groups for</param>
        /// <returns>A list of security groups for the user containing themselves, all groups, and all roles (inc recursive)</returns>
        public static IEnumerable<ISecurityGroup> SecurityGroups(this IUser target)
        {
            Contract.Requires(target != null);

            yield return target as ISecurityGroup;

            foreach (ISecurityGroup g in GetGroups(target))
            {
                yield return g;
            }

            foreach (ISecurityGroup g in GetRoles(target))
            {
                yield return g;
            }
        }

        /// <summary>
        /// Gets a list of security group guids for the target containing all groups, and all roles (inc recursive)
        /// </summary>
        /// <param name="target">The user to retrieve the security groups for</param>
        /// <returns>A list of security group guids for the user containing all groups, and all roles (inc recursive)</returns>
        public static IEnumerable<Guid> SecurityGroups(this IHasGroupsAndRoles target)
        {
            Contract.Requires(target != null);

            if (target is ISecurityGroup te)
            {
                yield return te.Guid;
            }

            foreach (Guid g in GetGroupGuids(target))
            {
                yield return g;
            }

            foreach (Guid g in GetRoleGuids(target))
            {
                yield return g;
            }
        }

        /// <summary>
        /// Returns a list of Guids representing ONLY the groups (not roles) that an object belongs to
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <returns>A list of Guids representing ONLY the groups (not roles) that an object belongs to</returns>
        public static IEnumerable<Guid> SecurityGroups(this IHasGroups target)
        {
            Contract.Requires(target != null);

            if (target is ISecurityGroup te)
            {
                yield return te.Guid;
            }

            foreach (Guid g in GetGroupGuids(target))
            {
                yield return g;
            }
        }

        /// <summary>
        /// Returns a list of Guids representing ONLY the roles (not groups) that an object belongs to
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <returns>A list of Guids representing ONLY the roles (not groups) that an object belongs to</returns>
        public static IEnumerable<Guid> SecurityGroups(this IHasRoles target)
        {
            Contract.Requires(target != null);

            if (target is ISecurityGroup te)
            {
                yield return te.Guid;
            }

            foreach (Guid g in GetRoleGuids(target))
            {
                yield return g;
            }
        }

        /// <summary>
        /// Returns a list of Guids representing groups AND roles that an object belongs to
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <returns>A list of Guids representing groups AND roles that an object belongs to</returns>
        private static IEnumerable<Guid> GetGroupGuids(IHasGroups target)
        {
            foreach (IGroup thisGroup in target.Groups)
            {
                yield return thisGroup.Guid;

                foreach (Guid g in GetRoleGuids(thisGroup))
                {
                    yield return g;
                }
            }
        }

        /// <summary>
        /// Returns a list of security groups including groups AND roles that an object belongs to
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <returns>A list of Guids representing groups AND roles that an object belongs to</returns>
        private static IEnumerable<ISecurityGroup> GetGroups(IHasGroups target)
        {
            foreach (IGroup thisGroup in target.Groups)
            {
                yield return thisGroup;

                foreach (ISecurityGroup r in GetRoles(thisGroup))
                {
                    yield return r;
                }
            }
        }

        private static IEnumerable<Guid> GetRoleGuids(IHasRoles target)
        {
            foreach (IRole r in target.Roles)
            {
                yield return r.Guid;
            }
        }

        private static IEnumerable<ISecurityGroup> GetRoles(IHasRoles target)
        {
            foreach (ISecurityGroup r in target.Roles)
            {
                yield return r;
            }
        }
    }
}
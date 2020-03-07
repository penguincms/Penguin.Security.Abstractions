using Penguin.Security.Abstractions.Attributes;
using Penguin.Security.Abstractions.Extensions;
using Penguin.Security.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Penguin.Security.Abstractions.Providers
{
    /// <summary>
    /// Checks permission types for an object based on RequiresRole attributes
    /// </summary>
    public class ObjectSecurityProvider : ISecurityProvider<object>
    {
        private IUserSession UserSession { get; set; }

        /// <summary>
        /// Constructs a new instance using the specified user session
        /// </summary>
        /// <param name="userSession">The user session to use when checking access</param>
        public ObjectSecurityProvider(IUserSession userSession)
        {
            this.UserSession = userSession;
        }

        void ISecurityProvider<object>.AddPermissions(object entity, PermissionTypes permissionTypes, ISecurityGroup source)
        {
            throw new NotImplementedException();
        }

        void ISecurityProvider<object>.AddPermissions(object entity, PermissionTypes permissionTypes, Guid source)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks for access using the provided user session, and Requires Role attributes on the object
        /// </summary>
        /// <param name="entity">The entity to check access for</param>
        /// <param name="permissionTypes">The type of permission being checked for</param>
        /// <returns>True if access is allowed</returns>
        public bool CheckAccess(object entity, PermissionTypes permissionTypes = PermissionTypes.Read)
        {
            if (entity is null)
            {
                return false;
            }

            List<ISecurityGroup> LoggedInSecurity = this.UserSession.LoggedInUser.SecurityGroups().ToList();

            if (LoggedInSecurity.Any(r => r.ExternalId == entity.GetType().Name))
            {
                return true;
            }

            if (this.GetType().GetCustomAttribute<EntityRequiresRoleAttribute>() is EntityRequiresRoleAttribute roleRequirements)
            {
                foreach (string Role in roleRequirements.AllowedRoles)
                {
                    if (LoggedInSecurity.Any(r => r.ExternalId == Role))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        void ISecurityProvider<object>.ClonePermissions(object source, object destination)
        {
            throw new NotImplementedException();
        }

        void ISecurityProvider<object>.SetDefaultPermissions(params object[] o)
        {
            throw new NotImplementedException();
        }

        void ISecurityProvider<object>.SetLoggedIn(object entity)
        {
            throw new NotImplementedException();
        }

        void ISecurityProvider<object>.SetPublic(object entity)
        {
            throw new NotImplementedException();
        }
    }
}
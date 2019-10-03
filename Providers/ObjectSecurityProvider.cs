using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Penguin.Security.Abstractions;
using Penguin.Security.Abstractions.Interfaces;
using Penguin.Security.Abstractions.Extensions;
using Penguin.Security.Abstractions.Attributes;

namespace Penguin.Cms.Modules.Security.SecurityProviders
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
            UserSession = userSession;
        }

        /// <summary>
        /// Checks for access using the provided user session, and Requires Role attributes on the object
        /// </summary>
        /// <param name="entity">The entity to check access for</param>
        /// <param name="permissionTypes">The type of permission being checked for</param>
        /// <returns>True if access is allowed</returns>
        public bool CheckAccess(object entity, PermissionTypes permissionTypes = PermissionTypes.Read)
        {
            if(entity is null)
            {
                return false;
            }

            List<ISecurityGroup> LoggedInSecurity = this.UserSession.LoggedInUser.SecurityGroups().ToList();

            if(LoggedInSecurity.Any(r => r.ExternalId == entity.GetType().Name))
            {
                return true;
            }

            if (this.GetType().GetCustomAttribute<RequiresRoleAttribute>() is RequiresRoleAttribute roleRequirements)
            {
                foreach(string Role in roleRequirements.AllowedRoles)
                {
                    if(LoggedInSecurity.Any(r => r.ExternalId == Role))
                    {
                        return true;
                    } 
                }
            }
            
            return false;
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="entity">Not implemented</param>
        public void SetLoggedIn(object entity) => throw new NotImplementedException();

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="entity">Not implemented</param>
        public void SetPublic(object entity) => throw new NotImplementedException();

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="o">Not implemented</param>
        public void SetDefaultPermissions(params object[] o) => throw new NotImplementedException();
    }
}

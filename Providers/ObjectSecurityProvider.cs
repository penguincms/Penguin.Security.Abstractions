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
    public class ObjectSecurityProvider : ISecurityProvider<object>
    {
        protected IUserSession UserSession { get; set; }
        public ObjectSecurityProvider(IUserSession userSession)
        {
            UserSession = userSession;
        }
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
        public void SetLoggedIn(object entity) => throw new NotImplementedException();
        public void SetPublic(object entity) => throw new NotImplementedException();
        public void SetDefaultPermissions(params object[] o) => throw new NotImplementedException();
    }
}

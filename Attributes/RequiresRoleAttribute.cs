using Penguin.Security.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Penguin.Security.Abstractions.Attributes
{
    /// <summary>
    /// Used to denote that a Controller Action should require the session user to have any role matching the provided in order to access it
    /// </summary>
    [SuppressMessage("Design", "CA1056:Uri properties should not be strings")]
    public class RequiresRoleAttribute : Attribute, IRequiresRoleAttribute
    {
        /// <summary>
        /// The roles allowed by this attribute
        /// </summary>
        public IList<string> AllowedRoles { get; }

        /// <summary>
        /// Mark the Controller Action as only being accessible to users with any of the provided roles
        /// </summary>
        /// <param name="roleNames"></param>
        public RequiresRoleAttribute(params string[] roleNames)
        {
            this.AllowedRoles = roleNames.ToList();
        }
    }
}

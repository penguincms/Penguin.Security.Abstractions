﻿using Penguin.Security.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Penguin.Security.Abstractions.Attributes
{
    /// <summary>
    /// Used to denote that a Controller Action should require the session user to have any role matching the provided in order to access it
    /// </summary>
    public class EntityRequiresRoleAttribute : Attribute, IRequiresRoleAttribute
    {
        /// <summary>
        /// The roles allowed by this attribute
        /// </summary>
        public string[] AllowedRoles { get; }

        IReadOnlyList<string> IRequiresRoleAttribute.AllowedRoles => AllowedRoles;

        /// <summary>
        /// Mark the Controller Action as only being accessible to users with any of the provided roles
        /// </summary>
        /// <param name="roleNames"></param>
        public EntityRequiresRoleAttribute(params string[] roleNames)
        {
            this.AllowedRoles = roleNames.ToArray();
        }
    }
}
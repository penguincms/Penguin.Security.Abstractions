﻿namespace Penguin.Security.Abstractions.Interfaces
{
    /// <summary>
    /// An interface representing a user, containing a collection of groups and roles
    /// </summary>
    public interface IUser : ISecurityGroup, IHasGroupsAndRoles
    {
    }
}
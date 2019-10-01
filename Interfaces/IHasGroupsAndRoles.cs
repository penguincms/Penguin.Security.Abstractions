﻿namespace Penguin.Security.Abstractions.Interfaces
{
    /// <summary>
    /// Used for objects that contain a list of groups, as well as roles
    /// </summary>
    public interface IHasGroupsAndRoles : IHasGroups, IHasRoles
    {
    }
}
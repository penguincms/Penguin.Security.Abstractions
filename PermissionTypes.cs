using System;

namespace Penguin.Security.Abstractions
{
    /// <summary>
    /// Defines the type of access that a security group has to a permissionable entity
    /// </summary>
    [Flags]
    public enum PermissionTypes
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        None = 0,
        Read = 1,
        Write = 2,
        Create = 4,
        Delete = 8,
        Full = Read | Write | Create | Delete
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Security.Abstractions.Interfaces
{
    public interface IPermissionableEntity<out TSecurityGroupPermission, out TSecurityGroup> where TSecurityGroupPermission : ISecurityGroupPermission<TSecurityGroup> where TSecurityGroup : ISecurityGroup
    {
        IReadOnlyList<TSecurityGroupPermission> Permissions { get; }
    }
}

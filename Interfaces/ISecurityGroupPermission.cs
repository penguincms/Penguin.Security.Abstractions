using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Security.Abstractions.Interfaces
{
    public interface ISecurityGroupPermission<TSecurityGroup> where TSecurityGroup : ISecurityGroup
    {
        TSecurityGroup SecurityGroup { get; }
        PermissionTypes Type { get; }
    }
}

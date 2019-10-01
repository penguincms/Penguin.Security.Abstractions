using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Security.Abstractions.Interfaces
{
    public interface ISecurityGroupPermission
    {
        ISecurityGroup SecurityGroup { get; set; }
        PermissionTypes Type { get; }
    }
}

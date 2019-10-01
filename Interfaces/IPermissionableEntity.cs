using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Security.Abstractions.Interfaces
{
    public interface IPermissionableEntity
    {
        IList<ISecurityGroupPermission> Permissions { get; }
    }
}

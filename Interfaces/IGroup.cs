using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Security.Abstractions.Interfaces
{
    public interface IGroup<out TRole> : ISecurityGroup, IHasRoles<TRole> where TRole : IRole
    {
    }

    public interface IGroup : IGroup<IRole>
    {

    }
}

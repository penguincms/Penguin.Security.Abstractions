using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Security.Abstractions.Interfaces
{
    public interface IUser<out TGroup, out TRole> : ISecurityGroup, IHasGroups<TGroup>, IHasRoles<TRole>  where TGroup : IGroup<IRole>where TRole : IRole
    {
    }

    public interface IUser : IUser<IGroup, IRole>
    {

    }
}

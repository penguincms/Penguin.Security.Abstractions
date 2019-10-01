using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Security.Abstractions.Interfaces
{
    public interface ISecurityGroup : IHasRoles
    {
        string ExternalId { get; }

        Guid Guid { get; }
    }
}

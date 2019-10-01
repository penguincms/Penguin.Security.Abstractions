using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Security.Abstractions.Interfaces
{
    public interface ISecurityGroup
    {
        string ExternalId { get; }

        Guid Guid { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Security.Abstractions.Interfaces
{
    /// <summary>
    /// An interface represending a role, a granular unit of permission
    /// </summary>
    public interface IRole : ISecurityGroup
    {
    }
}

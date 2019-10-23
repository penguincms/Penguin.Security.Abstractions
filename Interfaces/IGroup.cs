namespace Penguin.Security.Abstractions.Interfaces
{
    /// <summary>
    /// An interface representing a collection of roles
    /// </summary>
    public interface IGroup : ISecurityGroup, IHasRoles
    {
    }
}
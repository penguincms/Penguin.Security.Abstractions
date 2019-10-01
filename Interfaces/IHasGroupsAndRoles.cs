namespace Penguin.Security.Abstractions.Interfaces
{
    /// <summary>
    /// Used for objects that contain a list of groups, as well as roles
    /// </summary>
    public interface IHasGroupsAndRoles<TGroup, TRole> : IHasGroups<TGroup>, IHasRoles<TRole> where TGroup : IGroup<IRole> where TRole : IRole
    {
    }
}
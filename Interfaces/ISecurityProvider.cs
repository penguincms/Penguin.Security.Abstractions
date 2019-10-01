using Penguin.Security.Abstractions;

namespace Penguin.Security.Abstractions.Interfaces
{
    public interface ISecurityProvider<in T>
    {
        void SetPublic(T entity);

        void SetLoggedIn(T entity);

        bool CheckAccess(T entity, PermissionTypes permissionTypes = PermissionTypes.Read);

        void SetDefaultPermissions(params T[] o);
    }
}

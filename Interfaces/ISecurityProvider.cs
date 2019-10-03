using Penguin.Security.Abstractions;

namespace Penguin.Security.Abstractions.Interfaces
{
    /// <summary>
    /// An interface that processes security permissions for an object
    /// </summary>
    /// <typeparam name="T">The base type of the objects that this processes</typeparam>
    public interface ISecurityProvider<in T>
    {
        /// <summary>
        /// Assigns public read permissions for the object
        /// </summary>
        /// <param name="entity">The entity to assign permissions to</param>
        void SetPublic(T entity);

        /// <summary>
        /// Requires a registered and logged in account for read access
        /// </summary>
        /// <param name="entity">The entity to assign permissions to</param>
        void SetLoggedIn(T entity);

        /// <summary>
        /// Checks the entity for specified permissions against the current session user
        /// </summary>
        /// <param name="entity">The entity to check</param>
        /// <param name="permissionTypes">The specific permissions to check for</param>
        /// <returns>True if the access type requested is allowed</returns>
        bool CheckAccess(T entity, PermissionTypes permissionTypes = PermissionTypes.Read);

        /// <summary>
        /// Ensures that the objects passed in have the system default permissions
        /// </summary>
        /// <param name="o">The objects to assign permissions to</param>
        void SetDefaultPermissions(params T[] o);
    }
}

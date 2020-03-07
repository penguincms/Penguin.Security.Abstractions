using System;

namespace Penguin.Security.Abstractions.Interfaces
{
    /// <summary>
    /// An interface that processes security permissions for an object
    /// </summary>
    /// <typeparam name="T">The base type of the objects that this processes</typeparam>
    public interface ISecurityProvider<in T>
    {
        /// <summary>
        /// Adds permissions to the given object
        /// </summary>
        /// <param name="entity">The entity to be permissioned</param>
        /// <param name="permissionTypes">The type of permission to assign</param>
        /// <param name="source">The security group being given the permissions, or null for the current security group</param>
        void AddPermissions(T entity, PermissionTypes permissionTypes, ISecurityGroup source = null);

        /// <summary>
        /// Adds permissions to the given object
        /// </summary>
        /// <param name="entity">The entity to be permissioned</param>
        /// <param name="permissionTypes">The type of permission to assign</param>
        /// <param name="source">The GUID of the security group being given the permissions</param>
        void AddPermissions(T entity, PermissionTypes permissionTypes, Guid source);

        /// <summary>
        /// Checks the entity for specified permissions against the current session user
        /// </summary>
        /// <param name="entity">The entity to check</param>
        /// <param name="permissionTypes">The specific permissions to check for</param>
        /// <returns>True if the access type requested is allowed</returns>
        bool CheckAccess(T entity, PermissionTypes permissionTypes = PermissionTypes.Read);

        /// <summary>
        /// Dupilcates the permissions between two objects
        /// </summary>
        /// <param name="source">The source of the permissions</param>
        /// <param name="destination">Thedestination for the permissions</param>
        void ClonePermissions(T source, T destination);

        /// <summary>
        /// Ensures that the objects passed in have the system default permissions
        /// </summary>
        /// <param name="o">The objects to assign permissions to</param>
        void SetDefaultPermissions(params T[] o);

        /// <summary>
        /// Requires a registered and logged in account for read access
        /// </summary>
        /// <param name="entity">The entity to assign permissions to</param>
        void SetLoggedIn(T entity);

        /// <summary>
        /// Assigns public read permissions for the object
        /// </summary>
        /// <param name="entity">The entity to assign permissions to</param>
        void SetPublic(T entity);
    }
}
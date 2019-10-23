using Penguin.Security.Abstractions.Interfaces;

namespace Penguin.Security.Abstractions.Extensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    public static class ISecurityProviderExtensions
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// Assigns public read permissions for the object if the provider is not null
        /// </summary>
        /// <param name="provider">The provider to use try and use for this check</param>
        /// <param name="entity">The entity to assign permissions to</param>
        public static void TrySetPublic<T>(this ISecurityProvider<T> provider, T entity)
        {
            if (provider != null)
            {
                provider.SetPublic(entity);
            }
        }

        /// <summary>
        /// Requires a registered and logged in account for read access if the provider is not null
        /// </summary>
        /// <param name="provider">The provider to use try and use for this check</param>
        /// <param name="entity">The entity to assign permissions to</param>
        public static void TrySetLoggedIn<T>(this ISecurityProvider<T> provider, T entity)
        {
            if (provider != null)
            {
                provider.SetPublic(entity);
            }
        }

        /// <summary>
        /// Checks the entity for specified permissions against the current session user if the provider is not null
        /// </summary>
        /// <param name="provider">The provider to use try and use for this check</param>
        /// <param name="entity">The entity to check</param>
        /// <param name="permissionTypes">The specific permissions to check for</param>
        /// <returns>True if the access type requested is allowed</returns>
        public static bool TryCheckAccess<T>(this ISecurityProvider<T> provider, T entity, PermissionTypes permissionTypes = PermissionTypes.Read)
        {
            if (provider is null) { return true; }

            return provider.CheckAccess(entity, permissionTypes);
        }

        /// <summary>
        /// Ensures that the objects passed in have the system default permissions if the provider is not null
        /// </summary>
        /// <param name="o">The objects to assign permissions to</param>
        public static void TrySetDefaultPermissions<T>(this ISecurityProvider<T> provider, params T[] o)
        {
            if (provider != null)
            {
                provider.SetDefaultPermissions(o);
            }
        }

        /// <summary>
        /// Returns the requested entity only if the access is allowed or the provider is null
        /// </summary>
        /// <typeparam name="TReturn">The type of the entity to return</typeparam>
        /// <typeparam name="TProvider">The entity type being checked</typeparam>
        /// <param name="provider">The provider to use try and use for this check</param>
        /// <param name="entity">The entity to check permissions on</param>
        /// <returns>The entity, or null if access is explicitely denied</returns>
        public static TReturn TryFind<TReturn, TProvider>(this ISecurityProvider<TProvider> provider, TReturn entity) where TReturn : class, TProvider
        {
            if (provider.TryCheckAccess(entity))
            {
                return entity;
            }
            else
            {
                return null;
            }
        }
    }
}
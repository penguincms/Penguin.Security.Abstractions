using Penguin.Security.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Security.Abstractions.Extensions
{
    public static class ISecurityProviderExtensions
    {
        public static void TrySetPublic<T>(this ISecurityProvider<T> provider, T entity)
        {
            if (provider != null)
            {
                provider.SetPublic(entity);
            }
        }

        public static void TrySetLoggedIn<T>(this ISecurityProvider<T> provider, T entity)
        {
            if (provider != null)
            {
                provider.SetPublic(entity);
            }
        }

        public static bool TryCheckAccess<T>(this ISecurityProvider<T> provider, T entity, PermissionTypes permissionTypes = PermissionTypes.Read)
        {
            if (provider is null) { return true; }

            return provider.CheckAccess(entity, permissionTypes);
        }

        public static void TrySetDefaultPermissions<T>(this ISecurityProvider<T> provider, params T[] o)
        {
            if (provider != null)
            {
                provider.SetDefaultPermissions(o);
            }
        }

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

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Security.Abstractions.Constants
{
    /// <summary>
    /// Constant strings for role names
    /// </summary>
    public static class RoleNames
    {
        /// <summary>
        /// This role allows a user or group to access the administration panel
        /// </summary>
        public const string AdminAccess = "Admin Access";

        /// <summary>
        /// This role is the base for all site users
        /// </summary>
        public const string AllUsers = "All Users";

        /// <summary>
        /// This role represents users that are not logged in
        /// </summary>
        public const string Guest = "Guest";

        /// <summary>
        /// This role represents users that are logged in
        /// </summary>
        public const string LoggedIn = "Logged In";

        /// <summary>
        /// This role is grants access to all aspects of the web site
        /// </summary>
        public const string SysAdmin = "System Administrator";

        /// <summary>
        /// This role allows access to functions that control other users
        /// </summary>
        public const string UserManager = "User Manager";
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Security.Abstractions.Interfaces
{
    /// <summary>
    /// An interface representing an active user session
    /// </summary>
    public interface IUserSession<out TUser> where TUser : IUser<IGroup<IRole>, IRole>
    {
        /// <summary>
        /// True if the connection is coming from LocalHost
        /// </summary>
        bool IsLocalConnection { get; }

        /// <summary>
        /// There is an active user session
        /// </summary>
        bool IsLoggedIn { get; }

        /// <summary>
        /// The current logged in user
        /// </summary>
        TUser LoggedInUser { get; }
    }

    public interface IUserSession : IUserSession<IUser<IGroup<IRole>, IRole>>
    {

    }
}

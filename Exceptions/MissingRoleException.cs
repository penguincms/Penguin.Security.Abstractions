using System;
using System.Collections.Generic;

namespace Penguin.Security.Abstractions.Exceptions
{
    /// <summary>
    /// Thrown when a user attempts to access a resource that they do not have permissions to access
    /// </summary>
    public class MissingRoleException : Exception
    {
        /// <summary>
        /// The roles that are missing
        /// </summary>
        public ICollection<string> MissingRoles { get; }

        /// <summary>
        /// Constructs a new instance with the given message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="missingRoles">The missing roles</param>
        public MissingRoleException(string message, params string[] missingRoles) : base(message)
        {
            this.MissingRoles = missingRoles;
        }

        /// <summary>
        /// Constructs an instance with the given message and inner exception
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="innerException">An exception that lead to the inability to check the roles</param>
        /// <param name="missingRoles">The roles that are missing</param>
        public MissingRoleException(string message, Exception innerException, params string[] missingRoles) : base(message, innerException)
        {
            this.MissingRoles = missingRoles;
        }

        /// <summary>
        /// Constructs a new instance with the specified roles
        /// </summary>
        /// <param name="missingRoles">The roles that are missing</param>
        public MissingRoleException(params string[] missingRoles)
        {
            this.MissingRoles = missingRoles;
        }

        internal MissingRoleException()
        {
        }

        internal MissingRoleException(string message) : base(message)
        {
        }

        internal MissingRoleException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
using System;

namespace Penguin.Security.Abstractions.Exceptions
{
    /// <summary>
    /// Thrown when a user attempts to access a resource that requires being logged in, and they are not
    /// </summary>
    public class NotLoggedInException : Exception
    {
        /// <summary>
        /// Constructs an empty instance of this exception
        /// </summary>
        public NotLoggedInException()
        {
        }

        /// <summary>
        /// Constructs a new instance with the given message
        /// </summary>
        /// <param name="message">The message</param>
        public NotLoggedInException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructs a new instance with the given message and inner exception
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="innerException">The inner exception</param>
        public NotLoggedInException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
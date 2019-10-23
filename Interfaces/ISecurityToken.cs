namespace Penguin.Security.Abstractions.Interfaces
{
    /// <summary>
    /// Represents a security validation attempt
    /// </summary>
    public interface ISecurityToken
    {
        /// <summary>
        /// If true, access should be allowed
        /// </summary>
        bool IsValid { get; }
    }
}
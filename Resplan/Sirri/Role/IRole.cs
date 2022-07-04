using Resplan.Pasini;

namespace Resplan.Sirri.Role
{
    /// <summary>
    /// Interface that represents a guest, a soundtrack or effects at high level.
    /// </summary>
    public interface IRole : IElement
    {
        /// <summary>
        /// Represents the three possible types of role.
        /// </summary>
        enum RoleType
        {
            Speech,
            Soundtrack, 
            Effects
        }
        
        /// <summary>
        /// Gets the type of role.
        /// </summary>
        RoleType Type { get; }
    }
}

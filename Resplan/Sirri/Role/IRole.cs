using Resplan.Pasini;

namespace Resplan.Sirri.Role
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRole : IElement
    {
        /// <summary>
        /// 
        /// </summary>
        enum RoleType
        {
            Speech,
            Soundtrack, 
            Effects
        }
        
        /// <summary>
        /// 
        /// </summary>
        RoleType Type { get; }
        
    }
}

using Resplan.Pasini;

namespace Resplan.Sirri.Role
{
    public abstract class AbstractRole : IRole
    {
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; }
        /// <summary>
        /// <inheritdoc cref="IElement.Description"/>
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IRole.RoleType Type { get; }

        protected AbstractRole(string title, IRole.RoleType type, string? description = null)
        {
            Title = title;
            Type = type;
            Description = description;
        }
    }
}
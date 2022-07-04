using Resplan.Pasini;

namespace Resplan.Sirri.Role
{
    /// <summary>
    /// Abstract implementation of an <see cref="IRole"/>.
    /// </summary>
    public abstract class AbstractRole : IRole
    {
        /// <summary>
        /// <inheritdoc cref="IElement.Title"/>
        /// </summary>
        public string Title { get; }
        
        /// <summary>
        /// <inheritdoc cref="IElement.Description"/>
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// <inheritdoc cref="IRole.Type"/>
        /// </summary>
        public IRole.RoleType Type { get; }

        /// <summary>
        /// Constructs an instance of role of the given type. A title is compulsory while a description is merely
        /// optional. 
        /// </summary>
        /// <param name="title">
        /// The title of the role.
        /// </param>
        /// <param name="type">
        /// The type of role.
        /// </param>
        /// <param name="description">
        /// The description associated with the role.
        /// </param>
        protected AbstractRole(string title, IRole.RoleType type, string? description = null)
        {
            Title = title;
            Type = type;
            Description = description;
        }
    }
}

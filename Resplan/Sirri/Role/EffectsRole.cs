namespace Resplan.Sirri.Role
{
    /// <summary>
    /// Class that represents a role of type "Effects".
    /// </summary>
    public class EffectsRole : AbstractRole
    {
        /// <summary>
        /// Constructs an instance of role of type "Effects" with the given title and (optionally) description.
        /// </summary>
        /// <param name="title">
        /// <inheritdoc cref="AbstractRole"/>
        /// </param>
        /// <param name="description">
        /// <inheritdoc cref="AbstractRole"/>
        /// </param>
        public EffectsRole(string title, string? description = null) 
            : base(title, IRole.RoleType.Effects, description) {}
    }
}

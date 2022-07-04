namespace Resplan.Sirri.Role
{
    /// <summary>
    /// Class that represents a role of type "Soundtrack".
    /// </summary>
    public class SoundtrackRole : AbstractRole
    {
        /// <summary>
        /// Constructs an instance of role of type "Soundtrack" with the given title and (optionally) description.
        /// </summary>
        /// <param name="title">
        /// <inheritdoc cref="AbstractRole"/>
        /// </param>
        /// <param name="description">
        /// <inheritdoc cref="AbstractRole"/>
        /// </param>
        public SoundtrackRole(string title, string? description = null) 
            : base(title, IRole.RoleType.Soundtrack, description) {}
    }
}

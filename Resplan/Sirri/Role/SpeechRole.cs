using Resplan.Menghi.Speaker;

namespace Resplan.Sirri.Role
{
    /// <summary>
    /// Class that represents a role of type "Speech".
    /// </summary>
    public class SpeechRole : AbstractRole
    {
        /// <summary>
        /// A role of type speech can be associated with a <see cref="Speaker"/>.
        /// It is always possible to add a speaker to a speech role that does not possess it and even if it does,
        /// it can always be changed to a new one. 
        /// </summary>
        public ISpeaker? Speaker { get; set; }

        /// <summary>
        /// Constructs an instance of role of type "Speech" with the given title and (optionally) description.
        /// Furthermore, a role of this type can also be immediately associated with a speaker.
        /// </summary>
        /// <param name="title">
        /// <inheritdoc cref="AbstractRole"/>
        /// </param>
        /// <param name="description">
        /// <inheritdoc cref="AbstractRole"/>
        /// </param>
        /// <param name="speaker">
        /// <inheritdoc cref="AbstractRole"/>
        /// </param>
        public SpeechRole(string title, string? description = null, ISpeaker? speaker = null) 
            : base(title, IRole.RoleType.Speech, description) => Speaker = speaker;
    }
}

namespace Resplan.Menghi.Project
{
    /// <summary>
    /// A builder for an ISpeaker
    /// </summary>
    public interface ISpeakerBuilder
    {
        /// <summary>
        /// Set the speaker's first name
        /// </summary>
        /// <param name="firstName">The first name to set</param>
        /// <returns>The current builder</returns>
        ISpeakerBuilder FirstName(string firstName);

        /// <summary>
        /// Set the speaker's last name
        /// </summary>
        /// <param name="lastName">The last name to set</param>
        /// <returns>The current builder</returns>
        ISpeakerBuilder LastName(string lastName);

        /// <summary>
        /// Create the ISpeaker
        /// </summary>
        /// <returns>The ISpeaker created</returns>
        ISpeaker Build();
    }
}

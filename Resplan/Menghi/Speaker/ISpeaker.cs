namespace Resplan.Menghi.Speaker
{
    /// <summary>
    /// This interface represents a speaker who can participate in a project
    /// </summary>
    public interface ISpeaker
    {
        /// <summary>
        /// The code representing the speaker
        /// </summary>
        int SpeakerCode { get; }
        /// <summary>
        /// The first name of the speaker
        /// </summary>
        string FirstName { get; }
        /// <summary>
        /// The last name of the speaker
        /// </summary>
        string LastName { get; }
    }
}

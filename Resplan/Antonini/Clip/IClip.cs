namespace Resplan.Antonini.Clip
{
    /// <summary>
    /// A container for each content (such as an audio/MIDI file) you want to
    /// add to any RPTapeChannel.
    /// <p>Every RPClip stores its duration, its content and its content position. </p>
    /// <br>The duration of an RPClip could be different from its content duration, so the section </br>
    /// of the content you want to fill the clip is set adjusting the duration through <see cref="set_Duration"/> 
    /// and the content starting position through <see cref="set_ContentPosition"/>.
    /// <p>An RPClip could also be empty.</p>
    /// An empty RPClip is used for reserving space in any RPTapeChannel, so it can be filled later.
    /// <p>Calling the <see cref="Duplicate"/> method generate an exact copy of a clip.</p>
    /// </summary>
    /// <param name="X"> The content type.</param>
    public interface IClip<X>
    {
        /// <summary>
        /// This should be the default duration for an RPClip if it has not been specified or is not yet known.
        /// </summary>
        public const double DEFAULT_DURATION = 5000;
        
        /// <summary>
        /// Title of this clip.
        /// <returns>the title of this clip.</returns>
        /// </summary>
        string Title { get; }

        /// <summary>
        /// The duration of this RPClip.
        /// </summary>
        double Duration { get; set; }
        
        /// <summary>
        /// The content starting point.
        /// </summary>
        double ContentPosition { get; set; }
        
        /// <summary>
        /// The content duration.
        /// </summary>
        double ContentDuration { get; }
        
        /// <summary>
        /// Check if this RPClip is empty.
        /// </summary>
        /// <returns> true if and only if the clip has no content;
        /// false otherwise.</returns>
        bool IsEmpty();
        
        /// <summary>
        /// Get a <see cref="X"/> object with the content of this RPClip.
        /// </summary>
        /// <returns>The clip content.</returns>
        X GetContent();

        /// <summary>
        /// Generate an exact copy of this RPClip.
        /// </summary>
        /// <param name="title">The title of the new clip.</param>
        /// <returns>a duplicate of this RPClip.</returns>
        IClip<X> Duplicate(string title);
    }
}
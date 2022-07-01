namespace Resplan.Pasini.Part
{

    /// <summary>
    /// An extension of the <see cref="Part"/> class without the Text property.
    /// </summary>
    public class SoundPart : Part
    {
        /// <summary>
        /// Creates a new instance of the <see cref="Part"/> class of type Sound.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public SoundPart(string title, string? description = null) : base(title, IPart.PartType.Sound, description)
        {
        }
    }
}
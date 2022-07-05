namespace Resplan.Pasini.Part
{

    /// <summary>
    /// An extension of the <see cref="AbstractPart"/> class without the Text property.
    /// </summary>
    public class SoundPart : AbstractPart
    {
        /// <summary>
        /// Creates a new instance of the <see cref="AbstractPart"/> class of type Sound.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public SoundPart(string title, string? description = null) 
            : base(title, IPart.PartType.Sound, description) {}
    }
}
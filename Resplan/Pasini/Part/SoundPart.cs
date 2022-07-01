namespace Resplan.Pasini.Part
{

    /// <summary>
    /// An extension of the <see cref="AbstractPart"/> class without the Text property.
    /// </summary>
    public class SoundAbstractPart : AbstractPart
    {
        /// <summary>
        /// Creates a new instance of the <see cref="AbstractPart"/> class of type Sound.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public SoundAbstractPart(string title, string? description = null) 
            : base(title, IPart.PartType.Sound, description) {}
    }
}
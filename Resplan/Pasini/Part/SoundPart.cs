namespace Resplan.Pasini.Part
{

    /// <summary>
    /// An extension of the <see cref="Part"/> class without the Text property.
    /// </summary>
    public class SoundPart : Part
    {
        /// <summary>
        /// <inheritdoc cref=""/>
        /// </summary>
        /// <param name="title"></param>
        /// <param name="type"></param>
        /// <param name="description"></param>
        public SoundPart(string title, IPart.PartType type, string description = "") : base(title, type, description)
        {
        }
    }
}
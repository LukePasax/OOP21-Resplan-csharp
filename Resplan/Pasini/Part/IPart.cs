namespace Resplan.Pasini.Part
{

    /// <summary>
    ///  It's an interface that represents a clip in high level which could belong to a guest, a soundtrack or to effects.
    /// </summary>
    public interface IPart : IElement
    {
        
       /// <summary>
       ///  The two possible types of a RPPart.
       /// </summary>
        enum PartType
        {
            Speech,
            Sound
        }

       /// <summary>
       ///  Returns the type of the part.
       /// </summary>
        PartType Type { get; }

    }
}
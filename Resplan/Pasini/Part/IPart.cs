namespace Resplan.Pasini.Part
{

    public interface IPart : IElement
    {
        enum PartType
        {
            Speech,
            Soundtrack,
            Effects
        }

        PartType Type { get; }

    }
}
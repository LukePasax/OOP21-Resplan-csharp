namespace Resplan.Pasini.Part
{

    /// <summary>
    /// An extension of the <see cref="AbstractPart"/> class that adds a <see cref="SpeechAbstractPart.Text"/> property.
    /// </summary>
    public class SpeechAbstractPart : AbstractPart
    {
        public string? Text { get; set; }

        public SpeechAbstractPart(string title, string? description = null, string? text = null) 
            : base(title, IPart.PartType.Speech, description)
        {
            Text = text;
        }
        
    }
}
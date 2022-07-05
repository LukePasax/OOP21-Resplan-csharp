namespace Resplan.Pasini.Part
{

    /// <summary>
    /// An extension of the <see cref="AbstractPart"/> class that adds a <see cref="SpeechPart.Text"/> property.
    /// </summary>
    public class SpeechPart : AbstractPart
    {
        public string? Text { get; set; }

        public SpeechPart(string title, string? description = null, string? text = null) 
            : base(title, IPart.PartType.Speech, description)
        {
            Text = text;
        }
        
    }
}
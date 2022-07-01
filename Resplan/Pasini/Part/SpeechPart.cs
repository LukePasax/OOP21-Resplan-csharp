namespace Resplan.Pasini.Part
{

    /// <summary>
    /// An extension of the <see cref="Part"/> class that adds a <see cref="SpeechPart.Text"/> property.
    /// </summary>
    public class SpeechPart : Part
    {
        public string Text { get; set; }

        public SpeechPart(string title, IPart.PartType type, string description = "") : base(title, type, description)
        {
        }


    }
}
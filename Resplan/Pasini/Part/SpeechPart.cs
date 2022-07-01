namespace Resplan.Pasini.Part
{

    public class SpeechPart : Part
    {
        public string Text { get; set; }

        public SpeechPart(string title, IPart.PartType type, string description = "") : base(title, type, description)
        {
        }


    }
}
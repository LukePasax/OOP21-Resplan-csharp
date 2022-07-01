namespace Resplan.GabrieleMenghi.Project
{
    class Speaker : ISpeaker
    {
        public int SpeakerCode { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Speaker(int speakerCode, string firstName, string lastName)
        {
            SpeakerCode = speakerCode;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString() => $"S {SpeakerCode}, {FirstName}, {LastName}";
    }
}

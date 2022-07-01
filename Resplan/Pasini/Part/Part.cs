namespace Resplan.Pasini.Part
{

    public abstract class Part : IPart
    {
        private string _description;

        public string Title { get; }
        public IPart.PartType Type { get; }

        public string Description
        {
            get => _description == "" ? null : _description;
            set => _description = value;
        }

        protected Part(string title, IPart.PartType type, string description = "")
        {
            Title = title;
            _description = description;
            Type = type;
        }
    }
}
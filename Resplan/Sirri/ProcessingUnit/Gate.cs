namespace Resplan.Sirri.ProcessingUnit
{
    public class Gate : Effect
    {
        private const string Name = "Gate";
        
        public Gate(int channels) : base(channels, Name) {}
    }
}

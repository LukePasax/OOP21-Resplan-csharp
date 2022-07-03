namespace Resplan.Sirri.ProcessingUnit
{
    public class HighPassFilter : Effect
    {
        private const string Name = "High Pass";
        
        public HighPassFilter(int channels) : base(channels, Name) {}
    }
}
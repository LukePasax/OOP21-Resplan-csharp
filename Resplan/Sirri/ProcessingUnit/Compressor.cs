namespace Resplan.Sirri.ProcessingUnit
{
    public class Compressor : Effect
    {
        private const string Name = "Compressor";

        public Compressor(int channels) : base(channels, Name) {}
    }
}
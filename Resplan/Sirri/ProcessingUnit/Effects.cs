namespace Resplan.Sirri.ProcessingUnit
{
    /// <summary>
    /// 
    /// </summary>
    public class Compressor : AbstractEffect
    {
        private const string EffectName = "Compressor";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channels"></param>
        public Compressor(int channels) : base(channels, EffectName) {}
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class Gate : AbstractEffect
    {
        private const string EffectName = "Gate";
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="channels"></param>
        public Gate(int channels) : base(channels, EffectName) {}
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class HighPassFilter : AbstractEffect
    {
        private const string EffectName = "High Pass";
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="channels"></param>
        public HighPassFilter(int channels) : base(channels, EffectName) {}
    }
}
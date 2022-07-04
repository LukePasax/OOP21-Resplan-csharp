using Resplan.Sirri.ProcessingUnit;

namespace Resplan.Sirri.Channel
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Channel : IChannel
    {
        private const int InitialVolume = 100;
        private const int DefaultChannels = 2;
        
        /// <summary>
        /// 
        /// </summary>
        public Gain GainIn { get; }
        
        /// <summary>
        /// 
        /// </summary>
        public Gain GainOut { get; }

        private int _volume = InitialVolume;
        
        /// <summary>
        /// 
        /// </summary>
        public int Volume
        {
            get => _volume;
            set
            {
                if (value > 0 && value < 100)
                {
                    _volume = value;
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public IChannel.ChannelType Type { get; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool Enabled { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        public IProcessingUnit? ProcessingUnit { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public Channel(IChannel.ChannelType type)
        {
            Type = type;
            Enabled = true;
            ProcessingUnit = null;
            GainIn = new Gain(DefaultChannels);
            GainOut = new Gain(DefaultChannels);
            GainOut.AddInput(GainIn);
        } 
        
        /// <summary>
        /// 
        /// </summary>
        public void Enable() => Enabled = true;
        
        /// <summary>
        /// 
        /// </summary>
        public void Disable() => Enabled = false;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pu"></param>
        public void AddProcessingUnit(IProcessingUnit pu)
        {
            ProcessingUnit = pu;
            ProcessingUnit.AddInput(GainIn);
            GainOut.RemoveAllInputs();
            ProcessingUnit.Connect(GainOut);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemoveProcessingUnit()
        {
            ProcessingUnit = null;
            GainOut.RemoveAllInputs();
            GainOut.AddInput(GainIn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsProcessingUnitPresent() => ProcessingUnit != null;
        
    }
}

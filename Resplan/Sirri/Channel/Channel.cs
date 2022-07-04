using Resplan.Sirri.ProcessingUnit;

namespace Resplan.Sirri.Channel
{
    /// <summary>
    /// This class represents a basic implementation of {<see cref="IChannel"/>.
    /// Note that the presence of a <see cref="IProcessingUnit"/> is merely optional, as a channel is functionally
    /// just a pipe through which an audio stream flows.
    /// Moreover, the channel is thought to initially have no <see cref="IProcessingUnit"/>; thereby, the only way to
    /// add one is to call the method which does that.
    /// A channel can be of one and only one <see cref="IChannel.ChannelType"/>,
    /// which is immutable and must be declared upon initialization.
    /// </summary>
    public sealed class Channel : IChannel
    {
        private const int InitialVolume = 100;
        private const int DefaultChannels = 2;
        
        private int _volume = InitialVolume;
        
        private Gain GainIn { get; }

        private Gain GainOut { get; }
        
        /// <summary>
        /// <inheritdoc cref="IChannel.Volume"/>
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
        /// <inheritdoc cref="IChannel.Type"/>
        /// </summary>
        public IChannel.ChannelType Type { get; }
        
        /// <summary>
        /// <inheritdoc cref="IChannel.Enabled"/>
        /// </summary>
        public bool Enabled { get; private set; }
        
        /// <summary>
        /// <inheritdoc cref="IChannel.ProcessingUnit"/>
        /// </summary>
        public IProcessingUnit? ProcessingUnit { get; private set; }

        /// <summary>
        /// Constructs a channel with the given type and parameters. The channel is initially enabled and has
        /// no <see cref="IProcessingUnit"/>.
        /// </summary>
        /// <param name="type">
        /// the type of the channel.
        /// </param>
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
        /// <inheritdoc cref="IChannel.Enable"/>
        /// </summary>
        public void Enable() => Enabled = true;
        
        /// <summary>
        /// <inheritdoc cref="IChannel.Disable"/>
        /// </summary>
        public void Disable() => Enabled = false;
        
        /// <summary>
        /// <inheritdoc cref="IChannel.AddProcessingUnit"/>
        /// </summary>
        /// <param name="pu">
        ///<inheritdoc cref="IChannel.AddProcessingUnit"/>
        /// </param>
        public void AddProcessingUnit(IProcessingUnit pu)
        {
            ProcessingUnit = pu;
            ProcessingUnit.AddInput(GainIn);
            GainOut.RemoveAllInputs();
            ProcessingUnit.Connect(GainOut);
        }

        /// <summary>
        /// <inheritdoc cref="IChannel.RemoveProcessingUnit"/>
        /// </summary>
        public void RemoveProcessingUnit()
        {
            ProcessingUnit = null;
            GainOut.RemoveAllInputs();
            GainOut.AddInput(GainIn);
        }

        /// <summary>
        /// <inheritdoc cref="IChannel.IsProcessingUnitPresent"/>
        /// </summary>
        /// <returns></returns>
        public bool IsProcessingUnitPresent() => ProcessingUnit != null;
        
    }
}
using Resplan.Sirri.ProcessingUnit;

namespace Resplan.Sirri.Channel
{
    /// <summary>
    /// This interface models a channel, which is a representation of sound coming from an input and going to an output.
    /// Different forms of channel need to be supported by this interface.
    /// </summary>
    public interface IChannel
    {
        /// <summary>
        /// Identifies different forms of channels.
        /// </summary>
        enum ChannelType
        {
            /// <summary>
            /// Audio channels are all channels that are neither return nor master.
            /// </summary>
            Audio,

            /// <summary>
            /// Channel that takes as input the sum of all the other channels' outputs.
            /// </summary>
            Master
        }
        
        /// <summary>
        /// A 0 to 100 integer value that represent the channel's volume.
        /// </summary>
        int Volume { get; set; }
        
        /// <summary>
        /// Gets the type of the channel.
        /// </summary>
        ChannelType Type { get; }
        
        /// <summary>
        /// Gets whether the channel is enabled or not.
        /// </summary>
        bool Enabled { get; }
        
        /// <summary>
        /// Enables the channel.
        /// </summary>
        void Enable();

        /// <summary>
        /// Disables the channel.
        /// </summary>
        void Disable();

        /// <summary>
        /// Return the <see cref="ProcessingUnit"/> if it is present, otherwise null.
        /// </summary>
        IProcessingUnit? ProcessingUnit { get; }
        
        /// <summary>
        /// Adds the given <see cref="ProcessingUnit"/> to the channel.
        /// </summary>
        /// <param name="pu">
        /// the <see cref="ProcessingUnit"/> to be added.
        /// </param>
        void AddProcessingUnit(IProcessingUnit pu);

        /// <summary>
        /// Removes the <see cref="ProcessingUnit"/> if it is present, otherwise it does nothing.
        /// </summary>
        void RemoveProcessingUnit();

        /// <summary>
        /// Allows knowing whether the channel has a <see cref="ProcessingUnit"/> attached or not.
        /// </summary>
        bool IsProcessingUnitPresent();
    }
}

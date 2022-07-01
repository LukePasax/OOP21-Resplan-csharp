namespace Resplan.Sirri
{
    /// <summary>
    ///     This interface models a channel, which is a representation of sound coming from an input and going to an output.
    ///     Different forms of channel need to be supported by this interface.
    /// </summary>
    public interface IChannel
    {
        enum ChannelType
        {
            /// <summary>
            /// Audio channels are all channels that are neither return nor master.
            /// </summary>
            Audio,

            /// <summary>
            /// Auxiliary channel that takes the duplicate of an audio channel's output as input,
            /// to allow parallel signal processing.
            /// </summary>
            Return,

            /// <summary>
            /// Channel that takes as input the sum of all the other channels' outputs.
            /// </summary>
            Master
        }

        /// <summary>
        /// Property for the volume of the channel.
        /// </summary>
        int Volume { get; set; }
        
        /// <summary>
        /// Gets the type of the channel.
        /// </summary>
        ChannelType Type { get; }
        
        /// <summary>
        /// Gets the enabling of the channel.
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
    }
}

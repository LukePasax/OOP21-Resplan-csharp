namespace Resplan.Sirri
{
    /// <summary>
    ///     This interface models a channel, which is a representation of sound coming from an input and going to an output.
    ///     Different forms of channel need to be supported by this interface.
    /// </summary>
    public interface IChannel
    {
        enum Type
        {
            /// <summary>
            /// Audio channels are all channels that are neither return nor master.
            /// </summary>
            AUDIO,

            /// <summary>
            /// Auxiliary channel that takes the duplicate of an audio channel's output as input,
            /// to allow parallel signal processing.
            /// </summary>
            RETURN,

            /// <summary>
            /// Channel that takes as input the sum of all the other channels' outputs.
            /// </summary>
            MASTER
        }

    }
}
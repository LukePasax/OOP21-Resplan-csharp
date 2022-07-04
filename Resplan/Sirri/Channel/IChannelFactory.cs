namespace Resplan.Sirri.Channel
{
    /// <summary>
    /// This factory allows the client to acquire a particular form of <see cref="IChannel"/>.
    /// The channels are distinguished here only by their <see cref="ProcessingUnit"/>.
    /// Still, every form of built-in channel can be later modulated by adding
    /// <see cref="Resplan.Sirri.ProcessingUnit.Effect"/>s that serve as effects for sound processing.
    /// </summary>
    public interface IChannelFactory
    {
        /// <summary>
        /// Creates an <see cref="IChannel"/> that does not possess a <see cref="ProcessingUnit"/>.
        /// This is channel represents the most modular choice when creating a channel,
        /// as no built-in structure is provided.
        /// </summary>
        /// <returns>
        /// the <see cref="IChannel"/>.
        /// </returns>
        IChannel Basic();

        /// <summary>
        /// Creates a gated <see cref="IChannel"/>. To know what a gate is and when to use it,
        /// please read the documentation at <see cref="Resplan.Sirri.ProcessingUnit.Gate"/>.
        /// </summary>
        /// <returns>
        /// the <see cref="IChannel"/>.
        /// </returns>
        IChannel Gated();

        /// <summary>
        /// Creates an <see cref="IChannel"/> thought for musical purposes.
        /// </summary>
        /// <returns>
        /// the <see cref="IChannel"/>.
        /// </returns>
        IChannel Audio();

        /// <summary>
        /// Creates a master channel. A master channel is the one to which all other <see cref="IChannel"/>s'
        /// outputs are sent.
        /// </summary>
        /// <returns>
        /// the <see cref="IChannel"/>.
        /// </returns>
        IChannel Master();
    }
}

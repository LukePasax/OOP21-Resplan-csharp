using System.Collections.Generic;
using Resplan.Sirri.ProcessingUnit;

namespace Resplan.Sirri.Channel
{
    /// <summary>
    /// A basic implementation of an <see cref="IChannelFactory"/>.
    /// </summary>
    public class ChannelFactory : IChannelFactory
    {
        private const int DefaultChannels = 2;
        
        /// <summary>
        /// <inheritdoc cref="IChannelFactory.Basic"/>
        /// </summary>
        /// <returns>
        /// <inheritdoc cref="IChannelFactory.Basic"/>
        /// </returns>
        public IChannel Basic() => new Channel(IChannel.ChannelType.Audio);
        
        /// <summary>
        /// <inheritdoc cref="IChannelFactory.Gated"/>
        /// </summary>
        /// <returns>
        /// <inheritdoc cref="IChannelFactory.Gated"/>
        /// </returns>
        public IChannel Gated()
        {
            var channel = new Channel(IChannel.ChannelType.Audio);
            var effects = new List<AbstractEffect> { new Gate(DefaultChannels) };
            var pu = new ProcessingUnit.ProcessingUnit(effects);
            channel.AddProcessingUnit(pu);
            return channel;
        }

        /// <summary>
        /// <inheritdoc cref="IChannelFactory.Audio"/>
        /// </summary>
        /// <returns>
        /// <inheritdoc cref="IChannelFactory.Audio"/>
        /// </returns>
        public IChannel Audio()
        {
            var channel = new Channel(IChannel.ChannelType.Audio);
            var effects = new List<AbstractEffect> { new Compressor(DefaultChannels) };
            var pu = new ProcessingUnit.ProcessingUnit(effects);
            channel.AddProcessingUnit(pu);
            return channel;
        }

        /// <summary>
        /// <inheritdoc cref="IChannelFactory.Master"/>
        /// </summary>
        /// <returns>
        /// <inheritdoc cref="IChannelFactory.Master"/>
        /// </returns>
        public IChannel Master()
        {
            var channel = new Channel(IChannel.ChannelType.Master);
            var effects = new List<AbstractEffect> { new Compressor(DefaultChannels), new HighPassFilter(DefaultChannels) };
            var pu = new ProcessingUnit.ProcessingUnit(effects);
            channel.AddProcessingUnit(pu);
            return channel;
        }
    }
}

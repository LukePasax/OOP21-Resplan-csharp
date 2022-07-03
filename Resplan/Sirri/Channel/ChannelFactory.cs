using Resplan.Sirri.ProcessingUnit;

namespace Resplan.Sirri.Channel
{
    public class ChannelFactory : IChannelFactory
    {
        private const int DefaultChannels = 2;
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IChannel Basic()
        {
            return new Channel(IChannel.ChannelType.Audio);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IChannel Gated()
        {
            var channel = new Channel(IChannel.ChannelType.Audio);
            var pu = new ProcessingUnit.ProcessingUnit(DefaultChannels);
            pu.AddEffectAtPosition(0, new Gate(DefaultChannels));
            channel.AddProcessingUnit(pu);
            return channel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IChannel Audio()
        {
            var channel = new Channel(IChannel.ChannelType.Audio);
            var pu = new ProcessingUnit.ProcessingUnit(DefaultChannels);
            pu.AddEffectAtPosition(0, new Compressor(DefaultChannels));
            channel.AddProcessingUnit(pu);
            return channel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IChannel Master()
        {
            var channel = new Channel(IChannel.ChannelType.Master);
            var pu = new ProcessingUnit.ProcessingUnit(DefaultChannels);
            pu.AddEffectAtPosition(0, new Compressor(DefaultChannels));
            pu.AddEffectAtPosition(1, new HighPassFilter(DefaultChannels));
            channel.AddProcessingUnit(pu);
            return channel;
        }
    }
}
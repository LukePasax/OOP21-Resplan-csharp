﻿using System.Collections.Generic;
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
            var effects = new List<Effect> { new Gate(DefaultChannels) };
            var pu = new ProcessingUnit.ProcessingUnit(effects);
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
            var effects = new List<Effect> { new Compressor(DefaultChannels) };
            var pu = new ProcessingUnit.ProcessingUnit(effects);
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
            var effects = new List<Effect> { new Compressor(DefaultChannels), new HighPassFilter(DefaultChannels) };
            var pu = new ProcessingUnit.ProcessingUnit(effects);
            channel.AddProcessingUnit(pu);
            return channel;
        }
    }
}
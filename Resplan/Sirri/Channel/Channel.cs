namespace Resplan.Sirri.Channel
{
    public sealed class Channel : IChannel
    {
        public int Volume { get; set; }
        public IChannel.ChannelType Type { get; }
        
        public bool Enabled { get; private set; }

        public Channel(IChannel.ChannelType type) => Type = type;

        public void Enable() => Enabled = true;
        
        public void Disable() => Enabled = false;
    }
}

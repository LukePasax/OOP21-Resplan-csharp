namespace Resplan.Sirri
{
    public sealed class Channel : IChannel
    {
        public int Volume { get; set; }
        public IChannel.ChannelType Type { get; }
        public bool Enabled { get; private set; }

        public void Enable()
        {
            Enabled = true;
        }

        public void Disable()
        {
            Enabled = false;
        }
    }
}

namespace Resplan.Sirri
{
    public sealed class Channel : IChannel
    {
        private IChannel.Type _type;
        private boolean _enabled;

        public Type { get => _type; }
        public Enabled { get => _enabled; }
    }
}
namespace Resplan.Sirri.Channel
{
    public interface IChannelFactory
    {
        IChannel Basic();

        IChannel Gated();

        IChannel Audio();

        IChannel Master();
    }
}
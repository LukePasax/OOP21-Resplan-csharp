using NUnit.Framework;
using Resplan.Sirri.Channel;

namespace Resplan.Sirri.Test
{
    [TestFixture]
    public class TestChannel
    {
        private IChannel Channel { get; } = new Channel.Channel(IChannel.ChannelType.Audio);

        [Test]
        public void TestVolume()
        {
            // Volume must be a value between 0 and 100.
            Channel.Volume = 50;
            Assert.AreEqual(50, Channel.Volume);
            Channel.Volume = -10;
            Assert.AreEqual(50, Channel.Volume);
            Channel.Volume = 110;
            Assert.AreEqual(50, Channel.Volume);
        }

        [Test]
        public void TestEnabled()
        {
            Assert.IsTrue(Channel.Enabled);
            Channel.Disable();
            Assert.IsFalse(Channel.Enabled);
            Channel.Enable();
            Assert.IsTrue(Channel.Enabled);
        }

    }
}
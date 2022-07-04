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
            Assert.AreEqual(100, Channel.Volume);
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

        [Test]
        public void TestFactory()
        {
            IChannelFactory cf = new ChannelFactory();
            var audio = cf.Audio();
            Assert.AreEqual(IChannel.ChannelType.Audio, audio.Type);
            Assert.AreEqual("Compressor", audio.ProcessingUnit?.GetEffectAtPosition(0).Name);
            var master = cf.Master();
            Assert.AreEqual(IChannel.ChannelType.Master, master.Type);
            Assert.AreEqual("High Pass", master.ProcessingUnit?.GetEffectAtPosition(1).Name);
        }
    }
}
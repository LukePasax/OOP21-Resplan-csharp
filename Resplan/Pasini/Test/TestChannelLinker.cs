using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Resplan.Pasini.Linker;
using Resplan.Sirri.Channel;
using Resplan.Sirri.Role;

namespace Resplan.Pasini.Test
{
    [TestFixture]
    public class TestChannelLinker
    {
        private IChannelLinker _channelLinker = new ChannelLinker();
        private readonly IChannelFactory _channelFactory = new ChannelFactory();
        
        [SetUp]
        public void Initialize()
        {
            _channelLinker = new ChannelLinker();
        }

        [Test]
        public void TestAddition()
        {
            IRole luca = new SpeechRole("Luca");
            IRole giacomo = new SpeechRole("Giacomo");
            IRole music = new SoundtrackRole("Music");
            IRole master = new SoundtrackRole("Master");
            _channelLinker.AddChannelReferences(luca, _channelFactory.Gated());
            _channelLinker.AddChannelReferences(giacomo, _channelFactory.Gated());
            _channelLinker.AddChannelReferences(music, _channelFactory.Audio());
            _channelLinker.AddChannelReferences(master, _channelFactory.Master());
            Assert.True(_channelLinker.ChannelExists("Luca"));
            Assert.True(_channelLinker.ChannelExists("Giacomo"));
            Assert.True(_channelLinker.ChannelExists("Music"));
            Assert.True(_channelLinker.ChannelExists("Master"));
            Assert.False(_channelLinker.ChannelExists("NonExistent"));
            Assert.AreEqual(new HashSet<IRole>{luca, giacomo}, 
                _channelLinker.GetRolesSetOfType(IRole.RoleType.Speech));
            Assert.AreEqual(new HashSet<IRole>{music, master}, 
                _channelLinker.GetRolesSetOfType(IRole.RoleType.Soundtrack));
            Assert.AreEqual(new HashSet<IRole>{luca, giacomo, music, master}, 
                _channelLinker.GetRoles());
        }

        [Test]
        public void TestRemoval()
        {
            _channelLinker.AddChannelReferences(new SpeechRole("Luca"), _channelFactory.Gated());
            Assert.AreEqual(true, _channelLinker.ChannelExists("Luca"));
            _channelLinker.RemoveChannel(_channelLinker.GetRoleFromTitle("Luca"));
            Assert.AreEqual(false, _channelLinker.ChannelExists("Luca"));
        }

        [Test]
        public void TestGetters()
        {
            IRole role = new SpeechRole("Luca");
            var channel = _channelFactory.Gated();
            _channelLinker.AddChannelReferences(role, channel);
            Assert.AreEqual(channel, _channelLinker.GetChannel(role));
            Assert.AreEqual(role, _channelLinker.GetRole(channel));
            Assert.AreEqual(role, _channelLinker.GetRoleFromTitle("Luca"));
        }
        
    }
}
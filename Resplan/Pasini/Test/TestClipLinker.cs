using NUnit.Framework;
using Resplan.Antonini.Clip;
using Resplan.Pasini.Linker;
using Resplan.Pasini.Part;

namespace Resplan.Pasini.Test
{
    [TestFixture]
    public class TestClipLinker
    {
        private IClipLinker<NoContent> _clipLinker = new ClipLinker<NoContent>();

        [SetUp]
        public void Initialize()
        {
            _clipLinker = new ClipLinker<NoContent>();
        }

        [Test]
        public void TestAddition()
        {
            _clipLinker.addClipReferences(new EmptyClip("Luca"), new SpeechPart("Luca"));
            _clipLinker.addClipReferences(new EmptyClip("Giacomo"), new SpeechPart("Giacomo"));
            _clipLinker.addClipReferences(new EmptyClip("Music"), new SpeechPart("Music"));
            Assert.True(_clipLinker.clipExists("Luca"));
            Assert.True(_clipLinker.clipExists("Giacomo"));
            Assert.True(_clipLinker.clipExists("Music"));
            Assert.False(_clipLinker.clipExists("NonExistent"));
        }

        [Test]
        public void TestRemoval()
        {
            _clipLinker.addClipReferences(new EmptyClip("Luca"), new SpeechPart("Luca"));
            _clipLinker.addClipReferences(new EmptyClip("Giacomo"), new SpeechPart("Giacomo"));
            Assert.True(_clipLinker.clipExists("Luca"));
            Assert.True(_clipLinker.clipExists("Giacomo"));
            _clipLinker.removeClip(new SpeechPart("Luca"));
            Assert.False(_clipLinker.clipExists("Luca"));
            Assert.True(_clipLinker.clipExists("Giacomo"));
        }

        [Test]
        public void TestGetters()
        {
            IClip<NoContent> clip = new EmptyClip("Luca");
            _clipLinker.addClipReferences(clip, new SpeechPart("Luca"));
            Assert.AreEqual(clip, _clipLinker.getClipFromPart(new SpeechPart("Luca")));
            Assert.AreEqual(new SpeechPart("Luca"), _clipLinker.getPartFromClip(clip));
            Assert.AreEqual(new SpeechPart("Luca"), _clipLinker.getPart("Luca"));
            
        }
    }
}
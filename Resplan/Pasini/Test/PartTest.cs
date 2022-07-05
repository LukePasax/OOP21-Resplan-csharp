using NUnit.Framework;
using Resplan.Antonini.Clip;
using Resplan.Pasini.Part;

namespace Resplan.Pasini.Test
{
    [TestFixture]
    public class PartTest
    {

        [Test]
        public void TestTitle()
        {
            IPart part = new SoundPart("Primo");
            Assert.AreEqual("Primo", part.Title);
            part = new SpeechPart("Secondo");
            Assert.AreEqual("Secondo", part.Title);
        }

        [Test]
        public void TestDescription()
        {
            IPart part = new SoundPart("Primo", "Primo");
            Assert.AreEqual("Primo", part.Description);
            part = new SpeechPart("Secondo");
            Assert.AreEqual(null, part.Description);
            part.Description = "Secondo";
            Assert.AreEqual("Secondo", part.Description);
        }

        [Test]
        public void TestText()
        {
            var part = new SpeechPart("Primo", "Primo");
            Assert.AreEqual(null, part.Text);
            part.Text = "Text";
            Assert.AreEqual("Text", part.Text);
        }
    }
}
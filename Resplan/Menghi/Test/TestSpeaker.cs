using NUnit.Framework;
using Resplan.Menghi.Project;

namespace Resplan.Menghi.Test
{
    [TestFixture]
    class TestSpeaker
    {
        private readonly ISpeaker _speaker = new Speaker(1, "Gabriele", "Menghi");

        [Test]
        public void TestCode()
        {
            Assert.AreEqual(1, _speaker.SpeakerCode);
        }

        [Test]
        public void TestFirstName()
        {
            Assert.AreEqual("Gabriele", _speaker.FirstName);
        }

        [Test]
        public void TestLastName()
        {
            Assert.AreEqual("Menghi", _speaker.LastName);
        }
    }
}
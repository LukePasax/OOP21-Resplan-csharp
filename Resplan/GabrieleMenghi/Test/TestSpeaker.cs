using NUnit.Framework;
using Resplan.GabrieleMenghi.Project;

namespace TestProject
{
    [TestFixture]
    class TestSpeaker
    {
        private readonly ISpeaker speaker = new Speaker(1, "Gabriele", "Menghi");

        [Test]
        public void TestCode()
        {
            Assert.AreEqual(1, speaker.SpeakerCode);
        }

        [Test]
        public void TestFirstName()
        {
            Assert.AreEqual("Gabriele", speaker.FirstName);
        }

        [Test]
        public void TestLastName()
        {
            Assert.AreEqual("Menghi", speaker.LastName);
        }
    }
}

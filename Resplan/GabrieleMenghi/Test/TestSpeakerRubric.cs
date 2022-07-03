using System.Collections.Generic;
using NUnit.Framework;
using Resplan.GabrieleMenghi.Project;

namespace TestProject
{
    [TestFixture]
    class TestSpeakerRubric
    {
        private readonly ISpeaker _s1 = new Speaker(1, "Gabriele", "Menghi");
        private readonly ISpeaker _s2 = new Speaker(2, "Alessandro", "Antonini");
        private readonly ISpeaker _s3 = new Speaker(3, "Giacomo", "Sirri");
        private readonly ISpeaker _s4 = new Speaker(4, "Luca", "Pasini");

        private readonly ISpeakerRubric _rubric = new SpeakerRubric();

        [Test]
        public void TestAddition()
        {
            Assert.IsTrue(_rubric.AddSpeaker(_s1));
            Assert.IsFalse(_rubric.AddSpeaker(_s1));
        }

        [Test]
        public void TestRemoval()
        {
            Assert.IsTrue(_rubric.RemoveSpeaker(_s1));
            Assert.IsFalse(_rubric.RemoveSpeaker(_s1));
        }

        [Test]
        public void TestSearch()
        {
            _rubric.AddSpeaker(_s1);
            _rubric.RemoveSpeaker(_s3);
            Assert.AreEqual(_s1, _rubric.SearchSpeaker(1));
            Assert.AreEqual(null, _rubric.SearchSpeaker(3));
        }

        [Test]
        public void TestFilteredSearch()
        {
            _rubric.AddSpeaker(_s1);
            _rubric.AddSpeaker(_s2);
            _rubric.AddSpeaker(_s3);
            _rubric.AddSpeaker(_s4);
            IList<ISpeaker> filtered = new List<ISpeaker>
            {
                _s1,
                _s3
            };
            Assert.AreEqual(filtered, _rubric.GetFilteredSpeakers(x => x.FirstName.StartsWith("G")));
        }
    }
}

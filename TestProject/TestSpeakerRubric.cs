using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Resplan.GabrieleMenghi.Project;

namespace TestProject
{
    [TestFixture]
    class TestSpeakerRubric
    {
        private readonly ISpeaker _s1 = new Speaker(1, "Gabriele", "Menghi");
        private readonly ISpeaker _s2 = new Speaker(1, "Alessandro", "Antonini");
        private readonly ISpeaker _s3 = new Speaker(1, "Giacomo", "Sirri");
        private readonly ISpeaker _s4 = new Speaker(1, "Luca", "Pasini");

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
    }
}

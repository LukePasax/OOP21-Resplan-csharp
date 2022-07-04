using System;
using System.Collections.Generic;
using NUnit.Framework;
using Resplan.Menghi.Section;
using Resplan.Menghi.Timeline;

namespace Resplan.Menghi.Test
{
    [TestFixture]
    class TestTimeline
    {
        private readonly ISection _s1 = new Section.Section("Section1", "This is the first section", 2500.0);
        private readonly ISection _s2 = new Section.Section("Section2", "This is the second section", 1600.0);
        private readonly ISection _s3 = new Section.Section("Section3", "This is the third section", 1400.0);
        private readonly ISection _s4 = new Section.Section("Section4", "This is the fourth section", 1300.0);

        private readonly ITimeline _timeline = new Timeline.Timeline();

        [Test]
        public void TestAddition()
        {
            this._timeline.RemoveSection(_s1);
            this._timeline.RemoveSection(_s2);
            this._timeline.RemoveSection(_s3);
            this._timeline.RemoveSection(_s4);
            Assert.IsTrue(this._timeline.AddSection(0.0, _s1));
            Assert.IsFalse(this._timeline.AddSection(0.0, _s2));
            Assert.IsFalse(this._timeline.AddSection(1500.0, _s3));
            Assert.IsTrue(this._timeline.AddSection(2501.0, _s4));
        }

        [Test]
        public void TestRemoval()
        {
            this._timeline.RemoveSection(_s1);
            this._timeline.RemoveSection(_s2);
            this._timeline.RemoveSection(_s3);
            this._timeline.RemoveSection(_s4);
            this._timeline.AddSection(0.0, _s1);
            this._timeline.AddSection(2501.0, _s4);
            Assert.AreEqual(_s4, this._timeline.GetSection(2501));
            _timeline.RemoveSection(_s4);
            Assert.AreEqual(null, this._timeline.GetSection(2501));
        }

        [Test]
        public void TestAllSections()
        {
            this._timeline.RemoveSection(_s1);
            this._timeline.RemoveSection(_s2);
            this._timeline.RemoveSection(_s3);
            this._timeline.RemoveSection(_s4);
            this._timeline.AddSection(0.0, _s1);
            this._timeline.AddSection(2501.0, _s4);
            Console.WriteLine(this._timeline.GetAllSections().Count);
            ISet<ISection> allSections = new HashSet<ISection>
            {
                _s4,
                _s1
            };

            Assert.AreEqual(allSections, this._timeline.GetAllSections());
        }

        [Test]
        public void TestOverallDurtation()
        {
            this._timeline.RemoveSection(_s1);
            this._timeline.RemoveSection(_s2);
            this._timeline.RemoveSection(_s3);
            this._timeline.RemoveSection(_s4);
            this._timeline.AddSection(0.0, _s1);
            this._timeline.AddSection(2501.0, _s4);
            this._timeline.AddSection(3802.0, _s2);
            this._timeline.AddSection(5403.0, _s3);

            Assert.AreEqual(6803.0, this._timeline.GetOverallDuration());

            ITimeline _timeline2 = new Timeline.Timeline();
            Assert.AreEqual(0.0, _timeline2.GetOverallDuration());
        }
    }
}

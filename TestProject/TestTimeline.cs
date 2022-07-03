using NUnit.Framework;
using Resplan.GabrieleMenghi.Project;

namespace TestProject
{
    [TestFixture]
    class TestTimeline
    {
        private readonly ISection _s1 = new Section("Section1", "This is the first section", 2500.0);
        private readonly ISection _s2 = new Section("Section2", "This is the second section", 1600.0);
        private readonly ISection _s3 = new Section("Section3", "This is the third section", 1400.0);
        private readonly ISection _s4 = new Section("Section4", "This is the fourth section", 1300.0);

        private readonly ITimeline _timeline = new Timeline();

        [Test]
        public void TestAddition()
        {
            Assert.IsTrue(this._timeline.AddSection(0.0, _s1));
            Assert.IsFalse(this._timeline.AddSection(0.0, _s2));
            Assert.IsFalse(this._timeline.AddSection(1500.0, _s3));
            Assert.IsTrue(this._timeline.AddSection(2501.0, _s4));
        }
    }
}

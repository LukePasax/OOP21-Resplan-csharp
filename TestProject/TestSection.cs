using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Resplan.GabrieleMenghi.Project;

namespace TestProject
{
    [TestFixture]
    class TestSection
    {
        private readonly ISection _section = new Section("First", "This is the first section", 20.0);

        [Test]
        public void TestTitle()
        {
            Assert.AreEqual("First", _section.Title);
        }

        [Test]
        public void TestDescription()
        {
            Assert.AreEqual("This is the first section", _section.Description);
        }

        [Test]
        public void TestDuration()
        {
            Assert.AreEqual(20.0, _section.Duration);
        }
    }
}

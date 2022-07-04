using System;
using NUnit.Framework;
using Resplan.Antonini.Clip;

namespace Resplan.Antonini.Test
{
    [TestFixture]
    public class TestEmptyClip
    {
        [Test]
        public void TestCreation()
        {
            IClip<NoContent> emptyClip = new EmptyClip("title");
            Assert.True(emptyClip.IsEmpty());
            Assert.AreEqual(emptyClip.Duration, IClip<NoContent>.DEFAULT_DURATION);
        }

        [Test]
        public void TestDuration()
        {
            IClip<NoContent> clip = new EmptyClip("title");
            clip.Duration = 1000;
            Assert.AreEqual(clip.Duration, 1000);
        }

        [Test]
        public void TestDurationExceptions()
        {
            IClip<NoContent> clip = new EmptyClip("title");
            Assert.Throws(typeof(ArgumentException), () => clip.Duration = -10);
        }
        
        [Test]
        public void TestContentExceptions()
        {
            IClip<NoContent> clip = new EmptyClip("title");
            Assert.Throws(typeof(InvalidOperationException), () => clip.ContentPosition = 10);
            Assert.Throws(typeof(InvalidOperationException), () => clip.GetContent());
        }
    }
}
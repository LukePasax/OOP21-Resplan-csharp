using System;
using NUnit.Framework;
using Resplan.Menghi.Speaker;

namespace Resplan.Menghi.Test
{
    [TestFixture]
    class TestSpeakerBuilder
    {
        private readonly ISpeakerBuilder _b1 = new SpeakerBuilder(1);
        private readonly ISpeakerBuilder _b2 = new SpeakerBuilder(1);

        [Test]
        public void TestRightCreation()
        {
            try
            {
                _b1.FirstName("Gabriele")
                        .LastName("Menghi")
                        .Build();
            }
            catch (MissingFieldException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TestWrongCreation()
        {
            try
            {
                _b2.FirstName("Gabriele")
                        .Build();

                Assert.Fail();
            }
            catch (MissingFieldException) { }
        }
    }
}

using System;
using NUnit.Framework;
using Resplan.GabrieleMenghi.Project;

namespace Resplan.GabrieleMenghi.Test
{
    [TestFixture]
    class TestSpeakerBuilder
    {
        private readonly ISpeakerBuilder builder = new SpeakerBuilder(1);

        [Test]
        public void TestRightCreation()
        {
            try
            {
                builder.FirstName("Gabriele")
                        .LastName("Menghi")
                        .Build();
            } catch (MissingFieldException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TestWrongCreation()
        {
            try
            {
                builder.FirstName("Gabriele")
                        .Build();
                Assert.Fail();
            }
            catch (MissingFieldException) {}
        }

        [Test]
        public void Testbase()
        {
            Assert.Pass();
        }
    }
}

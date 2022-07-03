using System;
using NUnit.Framework;
using Resplan.GabrieleMenghi.Project;

namespace TestProject
{
    [TestFixture]
    class TestSpeakerBuilder
    {
        private readonly ISpeakerBuilder builder = new SpeakerBuilder(1);
        private readonly ISpeakerBuilder builder2 = new SpeakerBuilder(1);

        [Test]
        public void TestRightCreation()
        {
            try
            {
                builder.FirstName("Gabriele")
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
                builder2.FirstName("Gabriele")
                        .Build();

                Assert.Fail();
            }
            catch (MissingFieldException) { }
        }
    }
}

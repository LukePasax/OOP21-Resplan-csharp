using System;
using NUnit.Framework;
using Resplan.Antonini.Clock;

namespace Resplan.Antonini.Test
{
    [TestFixture]
    public class TestClock
    {
        [Test]
        public void TestCreation()
        {
            IClock clock = new Clock.Clock();
            Assert.AreEqual(0, clock.Time);
            Assert.AreEqual(0, clock.Step);
        }

        [Test]
        public void TestTime()
        {
            IClock clock = new Clock.Clock();
            var time = 423784863.343234;
            clock.Time = time;
            Assert.AreEqual(Clock.Clock.Utility.TimeToClockSteps(time), clock.Step);
            Assert.AreEqual(Clock.Clock.Utility.RoundToExistingClockTime(time), clock.Time);
            time = Clock.Clock.Utility.GetClockMaxTime();
            clock.Time = time;
            Assert.AreEqual(Clock.Clock.Utility.TimeToClockSteps(time), clock.Step, "Tested with Clock Max Time");
            Assert.AreEqual(Clock.Clock.Utility.RoundToExistingClockTime(time), clock.Time, "Tested with Clock Max Time");
        }

        [Test]
        public void TestClockStep()
        {
            IClock clock = new Clock.Clock();
            const long steps = 200;
            for(var i = 0; i<steps; i++) {
                clock.DoStep();	
            }
            Assert.AreEqual(steps, clock.Step);
        }

        [Test]
        public void TestClockReset()
        {
            IClock clock = new Clock.Clock();
            for(var i = 0; i<25; i++) {
                clock.DoStep();
            }
            clock.Reset();
            Assert.AreEqual(0, clock.Time);
            Assert.AreEqual(0, clock.Step);
        }

        [Test]
        public void TestMaxTimeReached()
        {
            IClock clock = new Clock.Clock();
            var time = Clock.Clock.Utility.GetClockMaxTime();
            clock.Time = time;
            Assert.AreEqual(Clock.Clock.Utility.GetClockMaxTime(), clock.Time);
            Assert.AreEqual(Clock.Clock.Utility.RoundToExistingClockTime(time), clock.Time);
            Assert.Throws(typeof(Exception), () => clock.DoStep());
        }

        [Test]
        public void TestClock1000RandomTimes()
        {
            IClock clock = new Clock.Clock();
            for(var i=0; i<1000; i++) {
                var time = new Random().NextDouble() * Clock.Clock.Utility.GetClockMaxTime();
                clock.Time = time;
                Assert.AreEqual(Clock.Clock.Utility.TimeToClockSteps(time), clock.Step);
                Assert.AreEqual(Clock.Clock.Utility.RoundToExistingClockTime(time), clock.Time);
            }
        }

        [Test]
        public void TestAllDifferentTimes()
        {
            IClock clock = new Clock.Clock();
            var rand = (long)(new Random().NextDouble() * Clock.Clock.Utility.GetClockMaxStep());
            for(var i=rand; i<rand+10000 && i<Clock.Clock.Utility.GetClockMaxStep(); i++) {
                var oldTime = clock.Time;
                clock.DoStep();
                Assert.True(clock.Time>oldTime);
            }
        }

        [Test]
        public void Consistency()
        {
            IClock clock = new Clock.Clock();
            for(var i=0; i<200; i++) {
                var rand = new Random().NextDouble() * Clock.Clock.Utility.GetClockMaxTime();
                clock.Time = rand;
                Assert.AreEqual(Clock.Clock.Utility.RoundToExistingClockTime(rand), clock.Time);
            }
        }
    }
}
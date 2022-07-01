using System;

namespace Resplan.Antonini.Clock
{
    public class Clock : IClock
    {
        private const double ClockStepUnit = 1;

        private static readonly double ClockMaxTime = Utility.RoundToExistingClockTime(3.154E10);

        public long Step { get; private set; }

        public double Time
        {
            get => Utility.ClockStepToTime(Step);
            set
            {
                if (Time > Clock.ClockMaxTime)
                {
                    throw new ArgumentException("Time or corresponding steps are bigger than Clock.CLOCK_MAX_TIME");
                }

                Step = Utility.TimeToClockSteps(value);
            }
        }

        public void DoStep()
        {
            if (Time >= ClockMaxTime)
            {
                throw new Exception("Clock has reached the CLOCK_MAX_TIME value.");
            }

            Step++;
        }

        public void Reset()
        {
            Step = 0;
        }

        public class Utility
        {
            public static long TimeToClockSteps(double time) => (long)(time / Clock.ClockStepUnit);
            public static double ClockStepToTime(long clockStep) => clockStep * Clock.ClockStepUnit;

            public static double GetClockStepUnit() => Clock.ClockStepUnit;

            public static double GetClockMaxTime() => ClockMaxTime;

            public static long GetClockMaxStep() => Clock.Utility.TimeToClockSteps(Clock.ClockMaxTime);

            public static double RoundToExistingClockTime(double time) =>
                Clock.Utility.ClockStepToTime(Clock.Utility.TimeToClockSteps(time));
        }
    }
}
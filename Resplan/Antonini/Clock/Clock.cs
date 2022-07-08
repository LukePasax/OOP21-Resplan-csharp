using System;

namespace Resplan.Antonini.Clock
{
    public class Clock : IClock
    {
        /// <summary>
        /// The corresponding time in ms to a single step of the clock.
        /// </summary>
        private const double ClockStepUnit = 1;

        /// <summary>
        /// Approximately one year is the max time value reachable for this clock.
        /// <see cref="ClockMaxTime"/> avoids Double representation problems.
        /// </summary>
        private static readonly double ClockMaxTime = Utility.RoundToExistingClockTime(3.154E10);

        public long Step { get; private set; }

        /// <summary>
        /// <inheritdoc cref="IClock.Time"/>
        /// </summary>
        /// <exception cref="ArgumentException">If time or corresponding steps are bigger than <see cref="ClockMaxTime"/></exception>
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

        /// <summary>
        /// <inheritdoc cref="IClock.DoStep"/>
        /// </summary>
        /// <exception cref="Exception">If clock max time is reached.</exception>
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

        /// <summary>
        /// Clock Utilities.
        /// </summary>
        public static class Utility
        {
            /// <summary>
            /// Narrow conversion from time to the corresponding clock step.
            /// </summary>
            /// <param name="time">The time to convert in steps.</param>
            /// <returns>the step corresponding to the given time.</returns>
            public static long TimeToClockSteps(double time) => (long)(time / Clock.ClockStepUnit);
            
            /// <summary>
            /// Conversion from clockStep to the corresponding time.
            /// </summary>
            /// <param name="clockStep">The step to convert in time.</param>
            /// <returns>the time corresponding to the given step.</returns>
            public static double ClockStepToTime(long clockStep) => clockStep * Clock.ClockStepUnit;

            /// <summary>
            /// Get the corresponding time in ms to a single step of the clock.
            /// </summary>
            /// <returns>the clock step unit in milliseconds.</returns>
            public static double GetClockStepUnit() => Clock.ClockStepUnit;

            /// <summary>
            /// Get the clock max time value reachable for the clock.
            /// </summary>
            /// <returns>the clock max time value in milliseconds.</returns>
            public static double GetClockMaxTime() => ClockMaxTime;

            /// <summary>
            /// Get the clock max step value reachable for the clock.
            /// </summary>
            /// <returns>the clock max step.</returns>
            public static long GetClockMaxStep() => Clock.Utility.TimeToClockSteps(Clock.ClockMaxTime);

            /// <summary>
            /// Round the given time to the closest existing time.
            /// </summary>
            /// <param name="time">The time to round.</param>
            /// <returns>the existing time closest to the given time.</returns>
            public static double RoundToExistingClockTime(double time) =>
                Clock.Utility.ClockStepToTime(Clock.Utility.TimeToClockSteps(time));
        }
    }
}
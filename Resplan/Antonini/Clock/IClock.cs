namespace Resplan.Antonini.Clock
{
    /// <summary>
    /// A clock ticks the current playback time.
    /// <p>The clock current time is updated in steps.
    /// Each step of the clock corresponds to a pre-definite time interval, so the clock
    /// do not memorize all possible time values.</p>
    /// <br>The clock could be set to a specific time.
    /// In this case the given time will be converted to an existing clock time.</br>
    /// </summary>
    public interface IClock
    {
        /// <summary>
        /// The current step.
        /// </summary>
        long Step { get; }

        /// <summary>
        /// The current time.
        /// </summary>
        double Time { get; set; }
        
        /// <summary>
        /// Add one step to the current time.
        /// </summary>
        void DoStep();
        
        /// <summary>
        /// Reset the current time to zero.
        /// </summary>
        void Reset();
    }
}
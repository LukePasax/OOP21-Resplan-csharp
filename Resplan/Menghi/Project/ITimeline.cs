using System.Collections.Generic;

namespace Resplan.Menghi.Project
{
    /// <summary>
    /// This interface represents the timeline at high level
    /// </summary>
    public interface ITimeline
    {
        /// <summary>
        /// Allow to add a section to the timeline. Returns true if the addition is successful
        /// </summary>
        /// <param name="initialTime">the time at which the section starts</param>
        /// <param name="section">the section to add</param>
        /// <returns>true if the addition is successful, false if something goes wrong</returns>
        bool AddSection(double initialTime, ISection section);

        /// <summary>
        /// Allow to remove a section from the timeline
        /// </summary>
        /// <param name="section">the section to remove</param>
        void RemoveSection(ISection section);

        /// <summary>
        /// Allow to get a specific section
        /// </summary>
        /// <param name="initialTime">the starting time of the section to be obtained</param>
        /// <returns>the nullable section, null if the section doesn't exist</returns>
        ISection? GetSection(double initialTime);

        /// <summary>
        /// Get the total duration of the sections that make up the timeline
        /// </summary>
        /// <returns>the overall duration of the timeline</returns>
        double GetOverallDuration();

        /// <summary>
        /// Gets a set containing all the sections in the timeline
        /// </summary>
        /// <returns>a set of all the sections</returns>
        ISet<ISection> GetAllSections();
    }
}

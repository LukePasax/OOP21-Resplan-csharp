using System;
using System.Collections.Generic;

namespace Resplan.GabrieleMenghi.Project
{
    /// <summary>
    /// This interface models a rubric that contains all the speakers saved before
    /// </summary>
    interface ISpeakerRubric
    {
        /// <summary>
        /// Returns all the speakers in the rubric
        /// </summary>
        /// <returns>the list of the speakers who make up the rubric</returns>
        IList<ISpeaker> GetSpeakers();

        /// <summary>
        /// Add a speaker to the rubric
        /// </summary>
        /// <param name="speaker">the speaker to add</param>
        /// <returns>true if the addition is ok, false if the speaker code is already associated to someone</returns>
        bool AddSpeaker(ISpeaker speaker);

        /// <summary>
        /// Remove a speaker from the rubric
        /// </summary>
        /// <param name="speaker">the speaker to remove</param>
        /// <returns>true if the removal is ok, false if the speaker doesn't exist</returns>
        bool RemoveSpeaker(ISpeaker speaker);

        /// <summary>
        /// Search a speaker into the rubric
        /// </summary>
        /// <param name="speakerCode">the code of the speaker to search for</param>
        /// <returns>the nullable speaker found, null if no matches are found</returns>
        ISpeaker? SearchSpeaker(int speakerCode);

        /// <summary>
        /// Return all the speakers in the rubric matching the filter
        /// </summary>
        /// <param name="filter">the filter to apply to the search</param>
        /// <returns>the filtered speaker list</returns>
        IList<ISpeaker> getFilteredSpeakers(Predicate<ISpeaker> filter);

    }
}

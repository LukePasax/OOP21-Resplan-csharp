﻿using System;
using System.Collections.Generic;
using Resplan.Menghi.Speaker;

namespace Resplan.Menghi.Rubric
{
    /// <summary>
    /// This is the implementation of an ISpeakerRubric
    /// </summary>
    public class SpeakerRubric : ISpeakerRubric
    {
        private readonly IList<ISpeaker> rubric = new List<ISpeaker>();

        /// <inheritdoc/>
        public IList<ISpeaker> GetSpeakers()
        {
            return this.rubric;
        }

        /// <inheritdoc/>
        public bool AddSpeaker(ISpeaker speaker)
        {
            foreach (ISpeaker s in this.rubric)
            {
                if (speaker.Equals(s))
                {
                    return false;
                }
            }
            this.rubric.Add(speaker);
            return true;
        }

        /// <inheritdoc/>
        public bool RemoveSpeaker(ISpeaker speaker)
        {
            foreach (ISpeaker s in this.rubric)
            {
                if (speaker.Equals(s))
                {
                    this.rubric.Remove(speaker);
                    return true;
                }
            }
            return false;
        }

        /// <inheritdoc/>
        public ISpeaker? SearchSpeaker(int speakerCode)
        {
            foreach (ISpeaker s in this.rubric)
            {
                if (speakerCode == s.SpeakerCode)
                {
                    return s;
                }
            }
            return null;
        }

        /// <inheritdoc/>
        public IList<ISpeaker> GetFilteredSpeakers(Predicate<ISpeaker> filter)
        {
            IList<ISpeaker> filteredRubric = new List<ISpeaker>();
            foreach (ISpeaker s in this.rubric)
            {
                if (filter(s))
                {
                    filteredRubric.Add(s);
                }
            }
            return filteredRubric;
        }
    }
}

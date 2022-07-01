using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Resplan.GabrieleMenghi.Project
{
    class SpeakerRubric : ISpeakerRubric
    {
        private readonly IList<ISpeaker> rubric = new List<ISpeaker>();

        public IList<ISpeaker> GetSpeakers()
        {
            return this.rubric;
        }

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

        public bool RemoveSpeaker(ISpeaker speaker)
        {
            foreach (ISpeaker s in this.rubric)
            {
                if (speaker.Equals(s) && speaker.FirstName.Equals(s.FirstName) && speaker.LastName.Equals(s.LastName))
                {
                    this.rubric.Remove(speaker);
                    return true;
                }
            }
            return false;
        }

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

        public IList<ISpeaker> getFilteredSpeakers(Predicate<ISpeaker> filter)
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

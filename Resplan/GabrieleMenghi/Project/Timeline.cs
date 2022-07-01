using System;
using System.Collections.Generic;
using System.Text;

namespace Resplan.GabrieleMenghi.Project
{
    /// <summary>
    /// It's the implementation of an ITimeline
    /// </summary>
    class Timeline : ITimeline
    {
        private IDictionary<double, ISection> sections = new Dictionary<double, ISection>();

        private bool IsAddValid(double initialTime, ISection section)
        {
            foreach (double i in this.sections.Keys)
            {
                if (i.Equals(initialTime))
                {
                    return false;
                }
            }
            foreach (ISection s in this.sections.Values)
            {
                if (s.Equals(section))
                {
                    return false;
                }
            }
            foreach (var (i, s) in this.sections)
            {
                if (initialTime >= i && initialTime <= i + s.Duration)
                {
                    return false;
                }
            }
            return true;
        }

        /// <inheritdoc/>
        public bool AddSection(double initialTime, ISection section)
        {
            if (this.IsAddValid(initialTime, section))
            {
                this.sections.Add(initialTime, section);
                return true;
            }
            return false;
        }

        /// <inheritdoc/>
        public void RemoveSection(ISection section)
        {
            foreach (var (i, s) in this.sections)
            {
                if (s.Equals(section))
                {
                    this.sections.Remove(i);
                }
            }
        }

        /// <inheritdoc/>
        public ISection? GetSection(double initialTime)
        {
            foreach (var (i, s) in this.sections)
            {
                if (i.Equals(initialTime))
                {
                    return s;
                }
            }
            return null;
        }

        /// <inheritdoc/>
        public double GetOverallDuration()
        {
            double totalDuration = 0.0;
            double max = 0.0;
            if (this.sections.Count == 0)
            {
                return totalDuration;
            }
            foreach (double i in this.sections.Keys){
                if(i >= max)
                {
                    max = i;
                }
            }
            foreach (var (i,s) in this.sections)
            {
                if (i.Equals(max))
                {
                    totalDuration = i + s.Duration;
                }
            }
            return totalDuration;
        }

        /// <inheritdoc/>
        public ISet<ISection> GetAllSections()
        {
            ISet<ISection> sec = new HashSet<ISection>();
            foreach (ISection s in sections.Values)
            {
                sec.Add(s);
            }
            return sec;
        }
    }
}

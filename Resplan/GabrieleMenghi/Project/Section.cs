using System;

namespace Resplan.GabrieleMenghi.Project
{
    /// <summary>
    /// It's the implementation of an ISection
    /// </summary>
    class Section : ISection
    {
        public string Title { get; private set; }

        public string? Description { get; set; }

        public double Duration { get; private set; }

        /// <summary>
        /// It is used to build a new Object of type ISection with a description
        /// </summary>
        /// <param name="title">the title of the section</param>
        /// <param name="description">the description of the section</param>
        /// <param name="duration">the duration of the section</param>
        public Section(string title, string description, int duration)
        {
            this.Title = title;
            this.Description = description;
            this.Duration = duration;
        }

        /// <summary>
        /// It is used to build a new Object of type ISection without a description
        /// </summary>
        /// <param name="title">the title of the section</param>
        /// <param name="duration">the duration of the section</param>
        public Section(string title, int duration)
        {
            this.Title = title;
            this.Description = null;
            this.Duration = duration;
        }

        /// <inheritdoc/>
        public override string ToString() => $"Section {Title}, {Description}, {Duration}";

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            Section other = (Section)obj;
            return Object.Equals(Title, other.Title);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(Title);
    }
}

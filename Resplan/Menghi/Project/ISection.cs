﻿using Resplan.Pasini.Part;

namespace Resplan.GabrieleMenghi.Project
{
    /// <summary>
    /// It's an interface modelling a section, that is a named part of the timeline
    /// </summary>
    public interface ISection : IElement
    {
        /// <summary>
        /// Return the duration of the section
        /// </summary>
        double Duration { get; }
    }
}

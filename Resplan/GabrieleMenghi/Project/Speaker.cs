﻿namespace Resplan.GabrieleMenghi.Project
{
    /// <summary>
    /// This is a simple implementation of an ISpeaker
    /// </summary>
    class Speaker : ISpeaker
    {
        /// <inheritdoc/>
        public int SpeakerCode { get; private set; }

        /// <inheritdoc/>
        public string FirstName { get; private set; }

        /// <inheritdoc/>
        public string LastName { get; private set; }

        /// <summary>
        /// Build a speaker
        /// </summary>
        /// <param name="speakerCode">the code associated to the speaker</param>
        /// <param name="firstName">the first name of the speaker</param>
        /// <param name="lastName">the last name of the speaker</param>
        public Speaker(int speakerCode, string firstName, string lastName)
        {
            SpeakerCode = speakerCode;
            FirstName = firstName;
            LastName = lastName;
        }

        /// <inheritdoc/>
        public override string ToString() => $"S {SpeakerCode}, {FirstName}, {LastName}";
    }
}

using System;

namespace Resplan.Menghi.Speaker
{
    /// <summary>
    /// This is the implementation of the builder for an ISpeaker
    /// </summary>
    public class SpeakerBuilder : ISpeakerBuilder
    {
        private readonly int _speakerCode;
        private string? _firstName = null;
        private string? _lastName = null;

        /// <summary>
        /// First part of the builder
        /// </summary>
        /// <param name="speakerCode">the code associated to the speaker</param>
        public SpeakerBuilder(int speakerCode)
        {
            this._speakerCode = speakerCode;
        }

        /// <inheritdoc/>
        public ISpeakerBuilder FirstName(string firstName)
        {
            this._firstName = firstName;
            return this;
        }

        /// <inheritdoc/>
        public ISpeakerBuilder LastName(string lastName)
        {
            this._lastName = lastName;
            return this;
        }

        /// <inheritdoc/>
        public ISpeaker Build()
        {
            if(this._firstName == null || this._lastName == null)
            {
                throw new MissingFieldException("Null parameters");
            }
            return new Speaker(this._speakerCode, this._firstName, this._lastName);
        }
    }
}

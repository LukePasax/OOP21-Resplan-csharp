using System;

namespace Resplan.GabrieleMenghi.Project
{
    class SpeakerBuilder : ISpeakerBuilder
    {
        private int _speakerCode;
        private string _firstName = null;
        private string _lastName = null;

        public SpeakerBuilder(int speakerCode)
        {
            this._speakerCode = speakerCode;
        }

        public ISpeakerBuilder FirstName(string firstName)
        {
            this._firstName = firstName;
            return this;
        }

        public ISpeakerBuilder LastName(string lastName)
        {
            this._lastName = lastName;
            return this;
        }

        public ISpeaker build()
        {
            if(this._firstName == null || this._lastName == null)
            {
                throw new MissingFieldException("Null parameters");
            }
            return new Speaker(this._speakerCode, this._firstName, this._lastName);
        }
    }
}

using System;
using System.Text;

namespace Resplan.GabrieleMenghi.Project
{
    public interface ISpeaker
    {
        int SpeakerCode { get; }
        string FirstName { get; }
        string LastName { get; }
    }
}

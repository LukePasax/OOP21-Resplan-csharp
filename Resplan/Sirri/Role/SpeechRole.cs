using Resplan.GabrieleMenghi.Project;

namespace Resplan.Sirri.Role
{
    public class SpeechRole : AbstractRole
    {
        public ISpeaker? Speaker { get; set; }

        public SpeechRole(string title, IRole.RoleType type, string? description = null, ISpeaker? speaker = null) 
            : base(title, type, description)
        {
            Speaker = speaker;
        }
    }
}

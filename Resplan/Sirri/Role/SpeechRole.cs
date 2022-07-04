using Resplan.Menghi.Project;

namespace Resplan.Sirri.Role
{
    public class SpeechRole : AbstractRole
    {
        public ISpeaker? Speaker { get; set; }

        public SpeechRole(string title, string? description = null, ISpeaker? speaker = null) 
            : base(title, IRole.RoleType.Speech, description)
        {
            Speaker = speaker;
        }
    }
}

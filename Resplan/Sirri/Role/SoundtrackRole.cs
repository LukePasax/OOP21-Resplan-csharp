namespace Resplan.Sirri.Role
{
    public class SoundtrackRole : AbstractRole
    {
        public SoundtrackRole(string title, string? description = null) 
            : base(title, IRole.RoleType.Soundtrack, description) {}
    }
}

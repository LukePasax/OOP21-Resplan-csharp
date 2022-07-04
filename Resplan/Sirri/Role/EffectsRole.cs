namespace Resplan.Sirri.Role
{
    public class EffectsRole : AbstractRole
    {
        public EffectsRole(string title, string? description = null) 
            : base(title, IRole.RoleType.Effects, description) {}
    }
}

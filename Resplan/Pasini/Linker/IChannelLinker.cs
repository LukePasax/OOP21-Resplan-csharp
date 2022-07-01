using System.Collections.Generic;
using Resplan.Sirri;
using Resplan.Sirri.Role;

namespace Resplan.Pasini.Linker
{
    public interface IChannelLinker
    {
        void AddChannelReferences(IRole role, IChannel channel);
        
        IChannel GetChannel(IRole role);
        
        IRole GetRole(IChannel channel);
        
        IRole GetRoleFromTitle(string title);
        
        ISet<IRole> getRolesSet(IRole.RoleType type);
        
        bool ChannelExists(string channelTitle);
        
    }
}
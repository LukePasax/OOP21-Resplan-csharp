using System.Collections.Generic;
using System.Linq;
using Resplan.Sirri;
using Resplan.Sirri.Role;

namespace Resplan.Pasini.Linker
{
    public class ChannelLinker : IChannelLinker
    {

        private readonly Dictionary<IRole, IChannel> _channels;
        
        public ChannelLinker()
        {
            _channels = new Dictionary<IRole, IChannel>();
        }
        
        public void AddChannelReferences(IRole role, IChannel channel)
        {
            _channels.Add(role, channel);
        }

        public IChannel GetChannel(IRole role)
        {
            return _channels[role];
        }

        public IRole GetRole(IChannel channel)
        {
            return _channels.First(x => x.Value == channel).Key;
        }

        public IRole GetRoleFromTitle(string title)
        {
           return _channels.First(x => x.Key.Title == title).Key;
        }

        public ISet<IRole> getRolesSet(IRole.RoleType type)
        {
            return _channels.Where(x => x.Key.Type == type)
                .Select(x => x.Key).ToHashSet();
        }

        public bool ChannelExists(string channelTitle)
        {
            return _channels.Any(x => x.Key.Title == channelTitle);
        }
        
    }
}
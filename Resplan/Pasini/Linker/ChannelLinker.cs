using System.Collections.Generic;
using System.Linq;
using Resplan.Sirri.Channel;
using Resplan.Sirri.Role;

namespace Resplan.Pasini.Linker
{
    public class ChannelLinker : IChannelLinker
    {
        
        private readonly Dictionary<IRole, IChannel> _channels;
        
        /// <summary>
        /// Creates a new instance of the <see cref="ChannelLinker"/> class.
        /// </summary>
        public ChannelLinker()
        {
            _channels = new Dictionary<IRole, IChannel>();
        }
        
        /// <summary>
        /// <inheritdoc cref="IChannelLinker.AddChannelReferences"/>
        /// </summary>
        public void AddChannelReferences(IRole role, IChannel channel)
        {
            _channels.Add(role, channel);
        }

        /// <summary>
        /// <inheritdoc cref="IChannelLinker.GetChannel"/>
        /// </summary>
        public IChannel GetChannel(IRole role)
        {
            return _channels[role];
        }

        /// <summary>
        /// <inheritdoc cref="IChannelLinker.GetRole"/>
        /// </summary>
        public IRole GetRole(IChannel channel)
        {
            return _channels.First(x => x.Value == channel).Key;
        }

        /// <summary>
        /// <inheritdoc cref="IChannelLinker.GetRoleFromTitle"/>
        /// </summary>
        public IRole GetRoleFromTitle(string title)
        {
           return _channels.First(x => x.Key.Title == title).Key;
        }

        /// <summary>
        /// <inheritdoc cref="IChannelLinker.GetRolesSetOfType"/>
        /// </summary>
        public ISet<IRole> GetRolesSetOfType(IRole.RoleType type)
        {
            return _channels.Where(x => x.Key.Type == type)
                .Select(x => x.Key).ToHashSet();
        }

        /// <summary>
        /// <inheritdoc cref="IChannelLinker.GetRoles"/>
        /// </summary>
        public ISet<IRole> GetRoles()
        {
            return _channels.Select(x => x.Key).ToHashSet();
        }

        /// <summary>
        /// <inheritdoc cref="IChannelLinker.ChannelExists"/>
        /// </summary>
        public bool ChannelExists(string channelTitle)
        {
            return _channels.Any(x => x.Key.Title == channelTitle);
        }

        /// <summary>
        /// <inheritdoc cref="IChannelLinker.RemoveChannel"/>
        /// </summary>
        public void RemoveChannel(string channelTitle)
        {
            _channels.Remove(GetRoleFromTitle(channelTitle));
        }
    }
}
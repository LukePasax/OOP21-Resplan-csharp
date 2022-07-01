using System.Collections.Generic;
using Resplan.Sirri;
using Resplan.Sirri.Role;

namespace Resplan.Pasini.Linker
{
    /// <summary>
    /// This interface is used to link <see cref="IRole"/> to <see cref="IChannel"/>.
    /// </summary>
    public interface IChannelLinker
    {
        
        /// <summary>
        /// This method links <see cref="IRole"/> to <see cref="IChannel"/>.
        /// </summary>
        /// <param name="role"> The <see cref="IRole"/> to link </param>
        /// <param name="channel"> The <see cref="IChannel"/> to link </param>
        void AddChannelReferences(IRole role, IChannel channel);
        
        /// <summary>
        /// A method to get the <see cref="IChannel"/>s linked to a <see cref="IRole"/>.
        /// </summary>
        /// <param name="role"> The <see cref="IRole"/> linked </param>
        /// <returns> The <see cref="IChannel"/> associated with the <see cref="IRole"/> </returns>
        IChannel GetChannel(IRole role);
        
        /// <summary>
        /// A method to get the <see cref="IRole"/>s linked to a <see cref="IChannel"/>.
        /// </summary>
        /// <param name="channel"> The <see cref="IChannel"/> linked </param>
        /// <returns> The <see cref="IRole"/> associated with the <see cref="IChannel"/> </returns>
        IRole GetRole(IChannel channel);
        
        /// <summary>
        /// A method to get the <see cref="IRole"/> with the given title.
        /// </summary>
        /// <param name="title"> The title of the <see cref="IRole"/> </param>
        /// <returns> The <see cref="IRole"/> with the given title </returns>
        IRole GetRoleFromTitle(string title);
        
        /// <summary>
        /// This method returns all <see cref="IRole"/>s with the given <see cref="IRole.RoleType"/>.
        /// </summary>
        /// <param name="type"> The <see cref="IRole.RoleType"/> </param>
        /// <returns> A set with the <see cref="IRole"/>s </returns>
        ISet<IRole> GetRolesSetOfType(IRole.RoleType type);

        /// <summary>
        /// This method returns all <see cref="IRole"/>s.
        /// </summary>
        /// <returns> A set containing all the <see cref="IRole"/>s </returns>
        ISet<IRole> GetRoles();

        /// <summary>
        /// This method is used to check if a Channel with the given title exists.
        /// </summary>
        /// <param name="channelTitle"> The title of the Channel </param>
        /// <returns> True if the Channel exists, false otherwise </returns>
        bool ChannelExists(string channelTitle);
        
        /// <summary>
        /// A method to remove a Channel from the <see cref="IChannelLinker"/>.
        /// </summary>
        /// <param name="channelTitle"> The title of the channel </param>
        void RemoveChannel(string channelTitle);
        
    }
}
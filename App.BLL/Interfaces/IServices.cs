using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.BLL.Data_Transfer_Objects;
using Microsoft.AspNet.Identity;

namespace App.BLL.Interfaces
{
    public interface IServices : IDisposable
    {
        Task CreateUserAndAddRoleAsync(UserDto userDTO);
        Task SetInitilizeDatabaseUsersAndRoles(IEnumerable<UserDto> UsersAndRolesDefault);
        IEnumerable<TopicViewDto> GetAllTopic();
        IServices BuildSetEmailServiceIdentity(IIdentityMessageService mailServ);
        ArticleDto GetArticleId(int id);
    }
}

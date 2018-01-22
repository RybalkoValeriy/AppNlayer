using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using App.BLL.Data_Transfer_Objects;
using App.DAL.Entities.Users;
using App.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace App.BLL.Interfaces
{
    public interface IServices : IDisposable
    {
        IEnumerable<TopicViewDto> GetAllTopic();
        IQueryable<TopicViewDto> GetInclude(params Expression<Func<Topic, object>>[] expr)
        IServices BuildSetEmailServiceIdentity(IIdentityMessageService mailServ);
        ArticleDto GetArticleId(int id);

        IQueryable<TopicViewDto> WhereTopic(IQueryable<TopicViewDto> coll, Func<TopicViewDto, bool> predicate);


        Task SetInitilizeDatabaseUsersAndRoles(IEnumerable<UserDto> UsersAndRolesDefault);

        Task<ApplicationUsers> CreateUserAndGetUserAsync(ApplicationUsers newUser);
        Task AddRoleAndUserToRoleAddAsync(ApplicationUsers user, object roleName);
        Task CreateUserAndAddRoleAsync(UserDto userDTO);

    }
}

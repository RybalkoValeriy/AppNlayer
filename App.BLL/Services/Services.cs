using App.BLL.Interfaces;
using App.DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DAL.Base;
using Microsoft.AspNet.Identity;
using App.BLL.Data_Transfer_Objects;
using AutoMapper;
using App.DAL.Entities;
using App.DAL.Intrefaces;
using System.Linq.Expressions;

namespace App.BLL.Services
{
    public class Services : IServices
    {
        public IUnitOfWork unitOfWork;
        public Services(IUnitOfWork uofw)
        {
            unitOfWork = uofw;
        }

        public IServices BuildSetEmailServiceIdentity(IIdentityMessageService mailServ)
        {
            this.unitOfWork.UsersManagers.EmailService = mailServ;
            return this;
        }
        // Заполнение базы
        public async Task SetInitilizeDatabaseUsersAndRoles(IEnumerable<UserDto> UsersAndRolesDefault)
        {
            foreach (var item in UsersAndRolesDefault)
            {
                await CreateUserAndAddRoleAsync(item);
            }
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public async Task<ApplicationUsers> CreateUserAndGetUserAsync(ApplicationUsers newUser)
        {
            var result = await unitOfWork.UsersManagers.CreateAsync(newUser);
            if (result.Succeeded)
            {
                return await unitOfWork.UsersManagers.FindByIdAsync(newUser.Id);
            }
            throw new Exception("error create user");
        }

        public async Task AddRoleAndUserToRoleAddAsync(ApplicationUsers user, object roleName)
        {
            if (!String.IsNullOrEmpty(roleName.ToString()))
            {
                var findRole = await unitOfWork.RolesManagers.FindByNameAsync(roleName.ToString());
                if (findRole == null)
                {
                    await unitOfWork.RolesManagers.CreateAsync(new ApplicationRole { Name = roleName.ToString() });
                }
                await unitOfWork.UsersManagers.AddToRoleAsync(user.Id, roleName.ToString());
            }
            else
                throw new ArgumentNullException("roleName is null");
        }

        public async Task CreateUserAndAddRoleAsync(UserDto userDTO)
        {
            var validationUser = await unitOfWork.UsersManagers.FindByEmailAsync(userDTO.Email);
            if (validationUser == null)
            {
                var userMapper = Mapper.Map(userDTO, new ApplicationUsers());
                var user = await CreateUserAndGetUserAsync(userMapper);
                await AddRoleAndUserToRoleAddAsync(user, userDTO.RoleName);
            }
        }

        public IEnumerable<TopicViewDto> GetAllTopic()
        {
            return Mapper.Map<IEnumerable<Topic>, IEnumerable<TopicViewDto>>(unitOfWork.Topics.GGetAll());
        }

        public IQueryable<TopicViewDto> GetInclude(params Expression<Func<Topic, object>>[] expr)
        {
            return GetInclude(expr);
        }

        public IQueryable<TopicViewDto> WhereTopic(IQueryable<TopicViewDto> coll, Func<TopicViewDto, bool> predicate)
        {
            return coll.Where(predicate).AsQueryable();
        }

        public ArticleDto GetArticleId(int id)
        {
            return Mapper.Map<Article, ArticleDto>(unitOfWork.Articles.GGetId(id));
        }


    }
}

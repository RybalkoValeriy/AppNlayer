using App.BLL.Interfaces;
using App.DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DAL.Identity;
using App.DAL.Base;
using App.DAL.Interfaces;
using App.DAL.Identity.Manager;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Net.Mail;
using App.BLL.Data_Transfer_Objects;
using AutoMapper;
using App.DAL.Entities;
using System.Linq.Expressions;

namespace App.BLL.Services
{
    public class Services : IServices
    {
        public UnitOfWork unitOfWork;
        public Services(UnitOfWork uofw)
        {
            // todo: interface iunitofwork
            unitOfWork = uofw;
        }



        public IServices BuildSetEmailServiceIdentity(IIdentityMessageService mailServ)
        {
            this.unitOfWork.UsersManager.EmailService = mailServ;
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


        public async Task CreateUserAndAddRoleAsync(UserDto userDTO)
        {

            var validationUser = await unitOfWork.UsersManager.FindByEmailAsync(userDTO.Email);
            if (validationUser == null)
            {
                //Mapper.Initialize(conf => conf.CreateMap<UserDto, ApplicationUsers>());
                var userMapper = Mapper.Map(userDTO, new ApplicationUsers());
                var user = await unitOfWork.CreateUserAndGetUserAsync(userMapper);
                await unitOfWork.AddRoleAndUserToRoleAddAsync(user, userDTO.RoleName);
            }
            //throw new Exception("userDto error");

        }

        public IEnumerable<TopicViewDto> GetAllTopic()
        {
            return Mapper.Map<IEnumerable<Topic>, IEnumerable<TopicViewDto>>(unitOfWork.Topics.GGetAll());
        }

        public  IQueryable<TopicViewDto> WhereTopic(IQueryable<TopicViewDto> coll, Func<TopicViewDto, bool> predicate)
        {
            return coll.Where(predicate).AsQueryable();
        }

        public ArticleDto GetArticleId(int id)
        {
            return Mapper.Map<Article, ArticleDto>(unitOfWork.Articles.GGetId(id));
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using App.DAL.Entities;
using App.DAL.Entities.Users;
using App.BLL.Data_Transfer_Objects;

namespace App.BLL.Infrastructure
{
    public static class AutoMapperConfigure
    {
        public static void Initialize()
        {
            Mapper.Initialize(
                conf =>
                    {
                        conf.CreateMap<Topic, TopicViewDto>();
                        conf.CreateMap<UserDto, ApplicationUsers>();
                    }
                );
        }
    }
}

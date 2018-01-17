using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using App.WEB.Controllers;
using System.Diagnostics;
using System.Collections.Generic;
using App.BLL.Interfaces;
using App.BLL.Data_Transfer_Objects;
using Moq;

namespace App.WEB.Tests.Controller
{
    [TestClass]
    public class HomeControllerTest
    {
        HomeController homeController;
        Mock<IServices> mockServices;
        List<TopicViewDto> testModel;
        IEnumerable<UserDto> initilizeUserDto;

        [TestInitialize]
        public void ControllerInitilize()
        {
            homeController = new HomeController();
            mockServices = new Mock<IServices>();
            homeController.Services = mockServices.Object;
            testModel = new List<TopicViewDto>
            {
                new TopicViewDto
                {
                    Id=1,
                    Name="asd",
                    DateAdd=DateTime.Today.Date,
                    DateResulution=DateTime.Today.Date
                },
                new TopicViewDto
                {
                    Id=2,
                    Name="asd",
                    DateAdd=DateTime.Today.Date,
                    DateResulution=DateTime.Today.Date
                }
            };
            initilizeUserDto = new List<UserDto>
            {
                new UserDto
                {
                    UserName="aaa",
                    Email="123@mail.com",
                    Password="123456",
                    RoleName="aaa"
                }
            };
        }

        [TestMethod]
        public void Topic_NotNull_cshtmlResults()
        {
            //Arrange
            //Act
            var viewResult = homeController.Topic() as ViewResult;
            //Assert
            Assert.IsNotNull(viewResult, "result action Topic is null");
        }

        [TestMethod]
        public void Topic_ViewNameTopic_TopicReturns()
        {
            string viewNameExpected = "Topic";
            var viewResult = homeController.Topic() as ViewResult;
            Assert.AreEqual(viewNameExpected, viewResult.ViewName, "name of view is not Topic");
        }

        [TestMethod]
        public void Topic_inModel_ModelReturns()
        {
            mockServices.Setup(mq => mq.GetAllTopic()).Returns(testModel);
            var viewResult = homeController.Topic() as ViewResult;
            Assert.AreEqual(testModel, viewResult.Model);
        }

        public void Topic_InitilizeDb_UsersAndRoleReturns()
        {
            mockServices.Setup(mq => mq.SetInitilizeDatabaseUsersAndRoles(initilizeUserDto));
            var task = homeController.Services.SetInitilizeDatabaseUsersAndRoles(initilizeUserDto);


        }
    }
}

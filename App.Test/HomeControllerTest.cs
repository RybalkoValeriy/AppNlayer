using NUnit.Framework;
using App.WEB.Controllers;
using System.Web.Mvc;
using NSubstitute;
using App.BLL.Interfaces;
using App.BLL.Services;
using System.Threading.Tasks;
using System.Collections;
using App.BLL.Data_Transfer_Objects;
using App.WEB;

namespace App.Test
{
    [TestFixture]
    public class HomeControllerTest
    {
        // Организовываем  Arrange
        HomeController homeController = new HomeController(Substitute.For<Services>());

        [Test]
        public void Topic_ReturnTask_Completed()
        {
            // Действие Act
            var actionResult = homeController.Topic();
            var viewReuslt = actionResult as ViewResult;
            var services = Substitute.For<IServices>();

            //var model = services.GetAllTopic();
            // Результат Assert
            Assert.That(viewReuslt, Is.Not.Null);
            //Assert.That(viewReuslt.Model, Is.Not.Null);
            //Assert.That(model, Is.Not.Null);
            //Assert.AreEqual("Topic", viewReuslt.ViewName);
            //Assert.AreEqual(model, viewReuslt.Model);
        }


    }
}

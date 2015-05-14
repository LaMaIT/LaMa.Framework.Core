using System;
using System.Web.Mvc;
using LaMa.Framework.Core.Web.Controllers;
using NUnit.Framework;

namespace LaMa.Framework.Core.Web.Tests
{
    [TestFixture]
    public class LoadResources
    {
      
        [Test]
        public void CanLoadResources()
        {
            //Arrange
            var controller = new LaMaResourceController();
            var resourceName = "jquery.js";
            //Act
            var result = controller.GetResource(resourceName);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof (System.Web.Mvc.FileStreamResult),result.GetType());
        }
        [Test]
        public void Return404WhenResourceDoesNotExist()
        {
            //Arrange
            var controller = new LaMaResourceController();
            var resourceName = "theirIsASmallChanceThatThisResourceFileExist.test";
            //Act
            var result = controller.GetResource(resourceName) as HttpStatusCodeResult;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }
    }
}

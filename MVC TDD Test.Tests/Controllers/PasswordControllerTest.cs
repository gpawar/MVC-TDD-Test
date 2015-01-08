using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVC_TDD_Test;
using MVC_TDD_Test.Controllers;

namespace MVC_TDD_Test.Tests.Controllers
{
    [TestClass]
    public class PasswordControllerTest
    {
        [TestMethod]
        public void Index()
        {
            PasswordController controller = new PasswordController();
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.AreEqual(result.ViewBag.Something,"Something");
        }
    }
}

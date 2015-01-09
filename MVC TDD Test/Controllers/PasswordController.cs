using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_TDD_Test.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class PasswordController : Controller
    {
        // GET: Password
        public ActionResult Index()
        {
            ViewBag.Something = "Something";
            return View();
        }
    }
}
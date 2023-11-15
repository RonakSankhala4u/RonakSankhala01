using Microsoft.AspNetCore.Mvc;

namespace RonakSankhala.Web.Controllers
{
    public class TestController : Controller
    {
        //basepath{localhost/controller/actionName}
        static int a = 0;
        public IActionResult ShowButton()
        {
            //++a;
            return View();
        }

        public IActionResult ClickAction()
        {
            ++a;
            return View("ShowButton", a);
        }
    }
}

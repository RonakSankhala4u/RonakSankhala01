using Microsoft.AspNetCore.Mvc;
using RonakSankhala.Web.Models;
using System.Diagnostics;

namespace RonakSankhala.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Method 1 : Through Variable

            //string a = "10";

            // Method 2 : Through Class and Object

            //People people = new People();
            //people.Id = 1;
            //people.Name = "Ronak Sankhala";
            //people.City = "Jaipur";
            //people.Description = "Ronak is a Software Engineer";

            // Method 3: Through List
            List<People> people = new List<People>();
            people.Add(new People { Id = 1, Name= "Ronak", City = "Jaipur", Description = "I'm Software Engineer"});
            people.Add(new People { Id = 2, Name= "Nimit", City = "Jodhpur", Description = "He is Graphic Designer"});
            people.Add(new People { Id = 3, Name= "Vivek", City = "Jaislmer", Description = "he is Web Designer"});
            people.Add(new People { Id = 4, Name= "Anil", City = "Ramgarh", Description = "He is Front End Developer"});

            return View("Index", people);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
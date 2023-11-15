using Microsoft.AspNetCore.Mvc;
using RonakSankhala.Web.Data;
using RonakSankhala.Web.Models;

namespace RonakSankhala.Web.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var people = _context.Peoples.ToList();
            return View(people);
        }
        // httpGet httpPost
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(People people)
        {
            _context.Peoples.Add(people); // To Add Data in Memory (RAM)
            _context.SaveChanges(); // To Make Changes (Storage)
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var people = _context.Peoples.Find(id);
            return View(people);
        }
    }
}

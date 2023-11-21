using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RonakSankhala.Entities;
using RonakSankhala.Repositories.Implementations;
using RonakSankhala.Repositories.Interfaces;

namespace RonakSankhala.UI.Controllers
{
    public class CitiesController : Controller
    {
        private readonly IStateRepo _stateRepo;
        private readonly ICityRepo  _cityRepo;

        public CitiesController(IStateRepo stateRepo, ICityRepo cityRepo)
        {
            _stateRepo = stateRepo;
            _cityRepo = cityRepo;
        }

        public IActionResult Index()
        {
            var cities = _cityRepo.GetAll();
            return View(cities);
        }

        // Paste Here
        [HttpGet]
        public IActionResult Create()
        {
            var states = _stateRepo.GetAll();
            ViewBag.StateList = new SelectList(states, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(City city)
        {
            _cityRepo.Save(city);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var city = _cityRepo.GetById(id);
            var states = _stateRepo.GetAll();
            ViewBag.StateList = new SelectList(states, "Id", "Name");
            return View(city);
        }
        [HttpPost]
        public IActionResult Edit(City city)
        {
            _cityRepo.Edit(city);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var city = _cityRepo.GetById(id);
            _cityRepo.RemoveData(city);
            return RedirectToAction("Index");
        }
    }
}

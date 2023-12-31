﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RonakSankhala.Entities;
using RonakSankhala.Repositories.Implementations;
using RonakSankhala.Repositories.Interfaces;
using RonakSankhala.UI.ViewModels.CityViewModels;

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
            var vm = new List<CityViewModel>();
            foreach (var city in cities)
            {
                vm.Add(new CityViewModel { Id = city.Id, CityName = city.Name,
                    StateName = city.State.Name, CountryName = city.State.Country.Name});
            }
            return View(vm);
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
        public IActionResult Create(CreateCityViewModel vm)
        {
            var city = new City
            {
                Name = vm.CityName,
                StateId = vm.StateId,
            };
            _cityRepo.Save(city);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var city = _cityRepo.GetById(id);
            var states = _stateRepo.GetAll();
            ViewBag.StateList = new SelectList(states, "Id", "Name");

            var vm = new EditCityViewModel
            {
                Id = city.Id,
                CityName = city.Name,
                StateId = city.StateId,
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(EditCityViewModel vm)
        {
            var city = new City
            {
                Id = vm.Id,
                Name = vm.CityName,
                StateId = vm.StateId,
            };
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

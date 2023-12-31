﻿using Microsoft.AspNetCore.Mvc;
using RonakSankhala.Entities;
using RonakSankhala.Repositories.Interfaces;
using RonakSankhala.UI.ViewModels.CountryViewModels;

namespace RonakSankhala.UI.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryRepo _countryRepo;

        public CountriesController(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public IActionResult Index()
        {
            List<CountryViewModel> vm = new List<CountryViewModel>();
            
            var countries = _countryRepo.GetAll();

            foreach (var country in countries)
            {
                vm.Add(new CountryViewModel { Id = country.Id, Name = country.Name });
            }
             
            return View(vm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateCountryViewModel country = new CreateCountryViewModel();
            //Country country = new Country();
            return View(country);
        }

        [HttpPost]
        public IActionResult Create(CreateCountryViewModel vm)
        {
            var country = new Country()
            {
                Name = vm.Name,
            };
            _countryRepo.Save(country);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var country = _countryRepo.GetById(id);
            CountryViewModel vm = new CountryViewModel
            {
                Id = country.Id,
                Name = country.Name,
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(CountryViewModel vm)
        {
            var country = new Country()
            {
                Id = vm.Id,
                Name = vm.Name,

            };
            _countryRepo.Edit(country);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var country = _countryRepo.GetById(id);
            _countryRepo.RemoveData(country);
            return RedirectToAction("Index");
        }
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace RonakSankhala.UI.ViewModels.CityViewModels
{
    public class EditCityViewModel
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        [Display(Name = "State Name")]
        public int StateId { get; set; }
    }
}

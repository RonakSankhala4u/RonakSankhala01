using System.ComponentModel.DataAnnotations;

namespace RonakSankhala.UI.ViewModels.CityViewModels
{
    public class CreateCityViewModel
    {
        public string CityName { get; set; }
        [Display(Name ="State Name")]
        public int StateId { get; set; }
    }
}

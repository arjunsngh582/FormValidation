using FormsValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FormsValidation.Models
{
    public class UserModel
    {
        public UserModel()
        {
            Country = new List<CountryList>() {
        new CountryList { Name = "India", CountryId = 1 },
        new CountryList { Name = "China", CountryId = 2 },
        new CountryList { Name = "America", CountryId = 3 },
        new CountryList { Name = "Nepal", CountryId = 4 },
        new CountryList { Name = "Australia", CountryId = 5 },
        };
        }

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm Passwor does not match")]
        public string ConfirmPassword { get; set; }


        [RegularExpression("^[789]\\d{9}$", ErrorMessage = "Please Enter Correct Contact")]
        [Required]
        public string? Contact { get; set; }

        [Required]
        public List<CountryList> Country { get; set; }

        [Required]
        public List<CityList> City { get; set; }

        [Required]
        public string Gender { get; set; }

        [ValidateCheckBox(ErrorMessage = "Please Accept Terms")]
        public bool Terms { get; set; }

    }
}

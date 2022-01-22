using FormsValidation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace FormsValidation.Controllers
{
    public class AccountController : Controller
    {
        List<CountryList> countryList = new List<CountryList> {
               new CountryList { CountryId=1,  Name="India"},
               new CountryList { CountryId=2,  Name="China"},
               new CountryList { CountryId=3,  Name="America"},

            };
        List<CityList> cityList = new List<CityList> {
               new CityList { CountryId=1,  Name="Ghaziabad", Id=1},
               new CityList { CountryId=2,  Name="beijing", Id=2},
               new CityList { CountryId=3,  Name="NewYork", Id=3},

            };

        public IActionResult SignUp()
        {

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var country in countryList)
            {
                list.Add(new SelectListItem { Text = country.Name, Value = country.CountryId.ToString() });
            };
            ViewBag.CountryList = list;
           

            return View();
        }
        public JsonResult GetCityList(string countryId) {
            
            var cities = cityList.FindAll(r => r.CountryId == Convert.ToInt32( countryId));
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var city in cities)
            {
                list.Add(new SelectListItem { Text = city.Name, Value = city.Id.ToString() });
            };
             //Json(list) ;
            return Json(JsonSerializer.Serialize(list));

        }

        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            //if (string.IsNullOrEmpty(model.Name))
            //{
            //    ModelState.AddModelError("Name", "Please Enter Name");
            //}
            //if (string.IsNullOrEmpty(model.Email))
            //{
            //    ModelState.AddModelError("Email", "Please Enter Email");
            //}
            if (ModelState.IsValid)
            {
                return RedirectToAction("Message");
            }
            return View();
        }
        public IActionResult Message()
        {
            return View();
        }
        public IActionResult CountryDropdown()
        {
            UserModel model = new UserModel();
            return View(model);
        }
    }
}

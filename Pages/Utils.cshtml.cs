using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Pages
{
    public class UtilsModel : PageModel
    {
        [BindProperty]

        // [Display(Name="Year:")]
        public int BirthYear { get; set; }

        public string ImagePath { get; set; }

        public void OnGet()
        {
            ViewData["Animals"] = null;
            ImagePath = "";
        }

        public void OnPost() {
            if (BirthYear < 1901 || BirthYear > 2023) {
                ViewData["Animal"] = "None. Year must be between 1900 and next year. Please try again.";
            } else {
                ViewData["Animal"] = Utils.GetZodiac(BirthYear).ToLower();
                ImagePath = "/images/" + Utils.GetZodiac(BirthYear).ToLower() + ".png";
                Console.WriteLine("image: " + "/images/" + Utils.GetZodiac(BirthYear).ToLower() + ".png");

            }
        }
    }
}
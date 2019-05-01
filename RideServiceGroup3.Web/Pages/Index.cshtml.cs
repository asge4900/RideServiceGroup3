using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RideServiceGroup3.Dal;
using RideServiceGroup3.Entities;

namespace RideServiceGroup3.Web.Pages
{
    public class IndexModel : PageModel
    {
        public List<RideCategory> RideCategories { get; set; }
        
        public List<Ride> Rides { get; set; }
        [BindProperty]
        public string SearchString { get; set; }

        [BindProperty]
        public int Status { get; set; }

        [BindProperty]
        public string Category { get; set; }

        public void OnGet()
        {
            RideRepository rideRepo = new RideRepository();

            Rides = rideRepo.GetAllRides();

            InitializeSearchFunction();

        }

        public void OnPost()
        {
            RideRepository rideRepo = new RideRepository();

            Rides = rideRepo.FindRide(SearchString, Category, Status);

            InitializeSearchFunction();
        }

        private void InitializeSearchFunction()
        {
            CategoryRepository categoryrepo = new CategoryRepository();
            RideCategories = categoryrepo.GetAllCategory();
        }
    }
}
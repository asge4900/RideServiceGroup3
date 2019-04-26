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
    public class RideModel : PageModel
    {

        public Ride Ride { get; set; }

        public void OnGet(int id)
        {
            RideRepository rideRepo = new RideRepository();

            Ride = rideRepo.GetRide(id);
        }
    }
}
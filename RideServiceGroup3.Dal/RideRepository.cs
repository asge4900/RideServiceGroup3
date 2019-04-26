using RideServiceGroup3.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RideServiceGroup3.Dal
{
    public class RideRepository : BaseRepository
    {
        public RideRepository()
        {
        }

        public List<Ride> GetAllRides()
        {
            List<Ride> rides = new List<Ride>();

            string sql = "SELECT r.RideId, r.Name, r.ImageUrl, r.Description FROM dbo.Rides r";

            DataTable ridesTable = ExecuteQuery(sql);

            foreach (DataRow row in ridesTable.Rows)
            {
                int id = (int)row["RideId"];
                string name = (string)row["Name"];
                string url = (string)row["ImageUrl"];
                string description = (string)row["Description"];
                
                Ride ride = new Ride()
                {
                    Id = id,
                    Name = name,
                    Url = url,
                    Description = description
                };
                rides.Add(ride);               
            }

            ReportRepository reportRepository = new ReportRepository();
            foreach (Ride ride in rides)
            {
                ride.Reports = reportRepository.GetReportsFor(ride);
            }
            return rides;
        }

        public Ride GetRide(int id)
        {
            string sql = $"SELECT top (1) r.RideId, r.Name, r.ImageUrl, r.Description FROM dbo.Rides r JOIN dbo.RideCategories rc ON r.CategoryId = rc.RideCategoryId JOIN dbo.Report r2 ON r.RideId = r2.RideId WHERE r.Rideid = '{id}' ORDER BY r2.ReportTime DESC";

            DataTable ridesTable = ExecuteQuery(sql);

            if (ridesTable.Rows.Count > 0)
            {
                DataRow row =  ridesTable.Rows[0];

                int rideId = (int)row["RideId"];
                string name = (string)row["Name"];
                string url = (string)row["ImageUrl"];
                string description = (string)row["Description"];

                Ride ride = new Ride()
                {
                    Id = rideId,
                    Name = name,
                    Url = url,
                    Description = description
                };

                CategoryRepository categoryRepository = new CategoryRepository();
                ride.Category = categoryRepository.GetCategoryFor(ride);

                ReportRepository reportRepository = new ReportRepository();
                ride.NumberOfShutdowns = reportRepository.NumberOfShutdowns(ride);
                ride.LastShutdown = reportRepository.LastShutdown(ride);
                ride.Reports = reportRepository.GetReportsFor(ride);


                return ride;
            }

            return null;
        }

       
    }
}

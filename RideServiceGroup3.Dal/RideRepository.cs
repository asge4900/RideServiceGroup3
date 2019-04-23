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

            string sql = "SELECT r.RideId, r.Name, r.ImageUrl, r.Description, r2.Notes FROM dbo.Rides r JOIN dbo.Report r2 ON r.RideId = r2.RideId";

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
    }
}

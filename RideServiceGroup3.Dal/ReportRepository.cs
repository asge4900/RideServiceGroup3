using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RideServiceGroup3.Entities;

namespace RideServiceGroup3.Dal
{
    public class ReportRepository : BaseRepository
    {
        public ReportRepository()
        {
        }

        internal List<Report> GetReportsFor(Ride ride)
        {
            List<Report> reports = new List<Report>();

            string sql = $"SELECT * FROM dbo.Report r WHERE Rideid = '{ride.Id}'";

            DataTable reportsTable = ExecuteQuery(sql);

            foreach (DataRow row in reportsTable.Rows)
            {
                int reportId = (int)row["ReportId"];                
                Status status = (Status)row["Status"];
                DateTime date = (DateTime)row["ReportTime"];
                string notes = (string)row["Notes"];

                Report report = new Report(reportId, ride, status, date, notes);
               
                reports.Add(report);
            }
            return reports;
        }

        internal int NumberOfShutdowns(Ride ride)
        {
            

            string sql = $"SELECT count (status) as NumberOfShutdowns FROM dbo.Rides r JOIN dbo.Report r2 ON r.RideId = r2.RideId WHERE r.Rideid = '{ride.Id}' And r2.Status = 2";

            DataTable reportsTable = ExecuteQuery(sql);

            if (reportsTable.Rows.Count > 0)
            {
                DataRow row = reportsTable.Rows[0];

                int shutdowns = (int)row["NumberOfShutdowns"];

                return shutdowns; 
            }
            return 0;

            
        }

        internal DateTime LastShutdown(Ride ride)
        {
           
            string sql = $"SELECT top (1) r2.ReportTime FROM dbo.Rides r JOIN dbo.Report r2 ON r.RideId = r2.RideId WHERE r.Rideid = {ride.Id} And r2.Status = 2 ORDER BY r2.ReportTime DESC";

            DataTable reportsTable = ExecuteQuery(sql);

            if (reportsTable.Rows.Count > 0)
            {
                DataRow row = reportsTable.Rows[0];

                DateTime date = (DateTime)row["ReportTime"];

                return date;
            }
            return DateTime.Now;
        }
    }
}

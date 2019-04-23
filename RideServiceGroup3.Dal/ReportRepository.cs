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
    }
}

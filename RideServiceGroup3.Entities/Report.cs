using System;
using System.Collections.Generic;
using System.Text;

namespace RideServiceGroup3.Entities
{
    public class Report
    {
        public Report()
        {

        }

        public Report(int id, Ride ride, Status status, DateTime reportTime, string notes)
        {
            Id = id;
            Ride = ride;
            Status = status;
            ReportTime = reportTime;
            Notes = notes;
        }

        public int Id { get; set; }
        public Ride Ride { get; set; }
        public Status Status { get; set; }
        public DateTime ReportTime { get; set; }
        public string Notes { get; set; }
    }
}

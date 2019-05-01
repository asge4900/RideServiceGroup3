using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RideServiceGroup3.Entities
{
    public class Ride
    {
        public Ride()
        {

        }

        public Ride(int id, string name, string description, string url, RideCategory category, List<Report> reports)
        {
            Id = id;
            Name = name;
            Description = description;
            Url = url;
            Category = category;
            Reports = reports;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public RideCategory Category { get; set; }
        public Status Status
        {
            get
            {
                if (Reports.Count == 0)
                {
                    return Status.Working;
                }
              
                var sortedReports = Reports.OrderByDescending( r => r.ReportTime ).ToList();
                return sortedReports[0].Status;
            }
        }
        public List<Report> Reports { get; set; } = new List<Report>();
        public int NumberOfShutdowns { get; set; }
        public DateTime LastShutdown { get; set; }


        public int NumberOfShutdownsMethodForm()
        {
            int shutdowns = 0;
            foreach (Report report in Reports)
            {
                if(report.Status == Status.Broken)
                {
                    shutdowns++;
                }
            }
            return shutdowns;
        }

        public int DaysSinceLastShutdown()
        {            
            System.TimeSpan diff = DateTime.Now.Subtract(LastShutdown);
            return diff.Days;
        }

        public string GetShortDescription()
        { 
            string sub = Description.Substring(0, 50);
            return $"{sub}...";
        }

        public string TranslateStatus()
        {
            string s = "";

            switch (Status)
            {
                case Status.Working:
                    s = "Virker";
                    break;
                case Status.Broken:
                    s = "Ude af drift";
                    break;
                case Status.BeingRepaired:
                    s = "Repareres";
                    break;
                default:
                    break;
            }
            return s;
        }
    }
}

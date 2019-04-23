using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RideServiceGroup3.Entities
{
    public class Ride
    {
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
        public List<Report> Reports { get; set; }


        //public int NumberOfShutdowns()
        //{

        //}

        //public int DaysSinceLastShutdown()
        //{

        //}

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

using System;
using System.Collections.Generic;
using System.Text;

namespace RideServiceGroup3.Entities
{
    public class RideCategory
    {
        public RideCategory()
        {

        }

        public RideCategory(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

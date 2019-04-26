using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RideServiceGroup3.Entities;

namespace RideServiceGroup3.Dal
{
    public class CategoryRepository : BaseRepository
    {
        public CategoryRepository()
        {
        }

        internal RideCategory GetCategoryFor(Ride ride)
        {
            string sql = $"SELECT rc.* FROM dbo.RideCategories rc JOIN dbo.Rides r ON r.CategoryId = rc.RideCategoryId WHERE r.RideId = '{ride.Id}'";

            DataTable categoryTable = ExecuteQuery(sql);

            if (categoryTable.Rows.Count > 0)
            {
                DataRow row = categoryTable.Rows[0];

                int id = (int)row["RideCategoryId"];
                string name = (string)row["Name"];
                string description = (string)row["Description"];

                RideCategory rideCategory = new RideCategory(id, name, description);

                return rideCategory;
            }

            return null;
        }
    }
}

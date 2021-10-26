using PavilionKyrpton.DatabaseConnection;
using PavilionKyrpton.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionKyrpton.ApplicationMethods
{
    public static class MasterDataMethods
    {
        private static DbConnection _dbConnection = new DbConnection();
        
        public static DataTable getLocations()
        {
            var locations = _dbConnection.Locations.ToList();
            var dt = new DataTable();

            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("AppLocation", typeof(string));
            dt.Columns.Add("EurorunnerLocation", typeof(string));
            dt.Columns.Add("EnagasLocation", typeof(string));
            dt.Columns.Add("PrisamLocation", typeof(string));


            //if (locations.Count == 0)
            //{
            //    var newRow = dt.NewRow();
            //    dt.Rows.Add(newRow);
            //}

            foreach(var item in locations)
            {
                var newRow = dt.NewRow();
                newRow["Id"] = item.Id;
                newRow["AppLocation"] = item.AppLocation;
                newRow["EurorunnerLocation"] = item.EurorunnerLocation;
                newRow["EnagasLocation"] = item.EnagasLocation;
                newRow["PrisamLocation"] = item.PrisamLocation;

                dt.Rows.Add(newRow);
            }
            return dt;
        }

        public static void updateLocation(Location location)
        {
            _dbConnection.Update(location);
            _dbConnection.SaveChanges();
        }

        public static void addLocation(DataTable dInput)
        {

            foreach (DataRow row in dInput.Rows)
            {
                if (row.RowState == DataRowState.Unchanged)
                    continue;

                var location = new Location()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    AppLocation = row["AppLocation"].ToString(),
                    EurorunnerLocation = row["EurorunnerLocation"].ToString(),
                    EnagasLocation = row["EnagasLocation"].ToString(),
                    PrisamLocation = row["EnagasLocation"].ToString()
                };

                _dbConnection.Locations.Add(location);
            }
            
            _dbConnection.SaveChanges();
        }

        public static void deleteLocation(int id)
        {
            var location = _dbConnection.Locations.Where(x => x.Id.Equals(id)).FirstOrDefault();

            if (location != null)
            {
                _dbConnection.Remove(location);
                _dbConnection.SaveChanges();
            }            
        }



    }
}

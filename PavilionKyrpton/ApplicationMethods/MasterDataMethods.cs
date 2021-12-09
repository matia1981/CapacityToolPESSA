using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            
            var locations = _dbConnection.Locations.AsNoTracking().ToList();
            var dt = new DataTable();

            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("AppLocation", typeof(string));
            dt.Columns.Add("EurorunnerLocation", typeof(string));
            dt.Columns.Add("EnagasLocation", typeof(string));
            dt.Columns.Add("Network", typeof(string));
            dt.Columns.Add("Location_Type", typeof(string));
            dt.Columns.Add("Temperature", typeof(string));
            dt.Columns.Add("Timezone", typeof(string));
            dt.Columns.Add("EurorunnerFormat", typeof(string));
            dt.Columns.Add("Injection_Withdrawal", typeof(string));
            dt.Columns.Add("Direction", typeof(string));
            dt.Columns.Add("Service", typeof(string));

            //if (locations.Count == 0)
            //{
            //    var newRow = dt.NewRow();
            //    dt.Rows.Add(newRow);
            //}

            foreach (var item in locations)
            {
                var newRow = dt.NewRow();
                newRow["Id"] = item.Id;
                newRow["AppLocation"] = item.AppLocation;
                newRow["EurorunnerLocation"] = item.EurorunnerLocation;
                newRow["EnagasLocation"] = item.EnagasLocation;
                newRow["Network"] = item.Network;
                newRow["Location_Type"] = item.Location_Type;
                newRow["Temperature"] = item.Temperature;
                newRow["Timezone"] = item.Timezone;

                newRow["EurorunnerFormat"] = item.EurorunnerFormat;
                newRow["Injection_Withdrawal"] = item.Injection_Withdrawal;
                newRow["Direction"] = item.Direction;
                newRow["Service"] = item.Service;

                dt.Rows.Add(newRow);
            }            
            return dt;
        }

        public static void updateLocation(Location location)
        {
            
            _dbConnection.Update(location);
            _dbConnection.SaveChanges();
            _dbConnection.ChangeTracker.Clear();

            
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
                    Network = row["Network"].ToString(),
                    Location_Type = row["Location_Type"].ToString(),
                    Temperature = row["Temperature"].ToString(),
                    Timezone = row["Timezone"].ToString(),
                    EurorunnerFormat = row["EurorunnerFormat"].ToString(),
                    Injection_Withdrawal = row["Injection_Withdrawal"].ToString(),
                    Direction = row["Direction"].ToString(),
                    Service = row["Service"].ToString()
                };

                var existLocation = _dbConnection.Locations.Where(x => x.Id == Convert.ToInt32(row["Id"])).AsNoTracking().Any();

                if (existLocation && !row.Equals(location))
                {                    
                    row.AcceptChanges();         
                    row.SetModified();
                    updateLocation(location);
                    
                    
                }
                else if(existLocation && row.Equals(location))
                {
                    continue;
                }
                else
                {
                    _dbConnection.Locations.Add(location);
                    _dbConnection.SaveChanges();
                    _dbConnection.ChangeTracker.Clear();
                }

        

                
            }
            
            
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

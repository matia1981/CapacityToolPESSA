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
    public static class UserMethods
    {
        public static IEnumerable<User> getUsers()
        {
            DatabaseConnection.DbConnection db = new DatabaseConnection.DbConnection();
            DatabaseConnection.DbMethods dbMethods = new DatabaseConnection.DbMethods(db);

            return dbMethods.RetrieveUsers();
        }

        public static void UpdateUser(DataTable dInput)
        {
            foreach(DataRow row in dInput.Rows)
            {
                if (row.RowState == DataRowState.Unchanged)
                    continue;

                var updateUser = new User()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    UserName = row["UserName"].ToString(),
                    Password = row["Password"].ToString(),
                    Role = row["Role"].ToString()
                    
               };

                DbConnection dbConnection = new DbConnection();
                DbMethods db = new DbMethods(dbConnection);

                db.UpdateUsers(updateUser);                
            }    
        }

        public static DataTable RetrieveUsers()
        {
            DataTable dt = new DataTable();
            foreach(var dColumn in GetDbColumns())
            {
                dt.Columns.Add(dColumn);
            }


            DbConnection dbConnection = new DbConnection();
            DbMethods db = new DbMethods(dbConnection);

            var userList = db.RetrieveUsers();

            foreach(var userItem in userList)
            {
                var dNewRow = dt.NewRow();
                dNewRow["Id"] = userItem.Id;
                dNewRow["UserName"] = userItem.UserName;
                dNewRow["Password"] = userItem.Password;
                dNewRow["Role"] = userItem.Role;

                dt.Rows.Add(dNewRow);
            }

            dt.AcceptChanges();

            return dt;
        }

        public static IEnumerable<DataColumn> GetDbColumns()
        {
            List<DataColumn> dataColumns = new List<DataColumn>();

            dataColumns.Add(new DataColumn("Id", typeof(string)));
            dataColumns.Add(new DataColumn("UserName", typeof(string)));
            dataColumns.Add(new DataColumn("Password", typeof(string)));
            dataColumns.Add(new DataColumn("Role", typeof(string)));


            return dataColumns;
        }

        public static void DeleteUser(int id)
        {
            DbConnection dbConnection = new DbConnection();
            DbMethods db = new DbMethods(dbConnection);

            var userToDelete = dbConnection.Users.Where(x => x.Id.Equals(id)).FirstOrDefault();

            if(userToDelete != null)
            {
                dbConnection.Users.Remove(userToDelete);
                dbConnection.SaveChanges();
            }

            return;
        }


    }
}

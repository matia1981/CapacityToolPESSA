using PavilionKyrpton.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PavilionKyrpton.DatabaseConnection;
using System.Data;

namespace PavilionKyrpton.DatabaseConnection
{
    class DbMethods
    {
        private DbConnection _db;

        public DbMethods(DbConnection _connection)
        {
            _db = _connection;
        }

        public IEnumerable<User> RetrieveUsers()
        {
            return _db.Users.ToList<User>();
        }

        public void UpdateUsers(User userToUpdate)
        {
            var user = _db.Users.Find(userToUpdate.Id);

            if(user != null)
            {
                _db.Users.Update(userToUpdate);
            }
            else
            {
                _db.Users.Add(userToUpdate);
            }           
            _db.SaveChanges();
            return;
        }
    }
}

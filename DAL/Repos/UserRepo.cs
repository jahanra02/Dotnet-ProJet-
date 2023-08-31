using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo: Repo, IUserRepo<User,string ,User>, IUserAuth<bool>
    {
        public bool Authenticate(string username, string password)
        {
            var data = db.Users.FirstOrDefault(u => u.UserId.Equals(username) &&
            u.UserPassword.Equals(password));
            if (data != null) return true;
            return false;
        }

        public object Checkout(string userId)
        {
            throw new NotImplementedException();
        }

        public User Create(User obj)
        {
            db.Users.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
        public bool Delete(string id)
        {
            var ex = Read(id);
            if (ex != null)
            {
                db.Users.Remove(ex);
                return db.SaveChanges() > 0;
            }
            return false;
        }


        public List<User> Read()
        {
            return db.Users.ToList();
        }

        public User Read(string id)
        {
            return db.Users.Find(id);
        }

        public User Update(User obj)
        {
            var ex = Read(obj.UserId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}

using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal  class AdminRepo : Repo, IRepo<Admin, int, bool>,IAdminAuth
    {
        public bool Create(Admin obj)
        {
            db.Admins.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Admins.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Admin> Get()
        {
            return db.Admins.ToList();
        }

        public Admin Get(int id)
        {
            return db.Admins.Find(id);
        }

        public bool Update(Admin obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public Admin Authenticate(string uname, string pass)
        {
            var Admin = from u in db.Admins
                        where u.Username.Equals(uname)
                        && u.Password.Equals(pass)
                        select u;
            if (Admin != null) return Admin.SingleOrDefault();
            return null;

        }
    }
}

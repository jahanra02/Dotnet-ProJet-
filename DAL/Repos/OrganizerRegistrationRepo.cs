using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OrganizerRegistrationRepo : Repo, IRepo<OrganizerRegistration, int, bool>,IAuth
    {
        public OrganizerRegistration Authenticate(string name, string password)
        {
            var user = from u in db.OrganizerRegistrations
                       where u.Name.Equals(name)
                       && u.Password.Equals(password)
                       select u;
            return user.SingleOrDefault();
            
        }

        public bool Create(OrganizerRegistration obj)
        {
            db.OrganizerRegistrations.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.OrganizerRegistrations.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<OrganizerRegistration> Get()
        {
            return db.OrganizerRegistrations.ToList();
        }

        public OrganizerRegistration Get(int id)
        {
            return db.OrganizerRegistrations.Find(id);
        }

        public bool Update(OrganizerRegistration obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}

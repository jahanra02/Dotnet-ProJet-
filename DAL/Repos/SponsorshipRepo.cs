using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SponsorshipRepo :Repo, IRepo<Sponsorship, int, bool>
    {
        public bool Create(Sponsorship obj)
        {
            db.Sponsorships.Add(obj);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Sponsorships.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Sponsorship> Get()
        {
            return db.Sponsorships.ToList();
        }

       
        public Sponsorship Get(int id)
        {
            return db.Sponsorships.Find(id);
        }
        public bool Update(Sponsorship obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}

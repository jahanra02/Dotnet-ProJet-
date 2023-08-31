using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ConferenceRepo : Repo, IRepo<Conference, int, bool>
    {
        public bool Create(Conference obj)
        {
            db.Conferences.Add(obj);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Conferences.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Conference> Get()
        {
            return db.Conferences.ToList();
        }

        public Conference Get(DateTime date)
        {
            var data = (from i in db.Conferences
                        where i.Date == date
                        select i).SingleOrDefault();
            return data;
        }
        public Conference Get(int id)
        {
            return db.Conferences.Find(id);
        }
        public bool Update(Conference obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}

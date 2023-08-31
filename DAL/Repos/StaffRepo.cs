using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StaffRepo : Repo, IRepo<Staff, int, bool>
    {
        public bool Create(Staff obj)
        {
            db.Staffs.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Staffs.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Staff> Get()
        {
            return db.Staffs.ToList();
        }

        public Staff Get(int id)
        {
            return db.Staffs.Find(id);
        }

        public bool Update(Staff obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;

        }
    }
}

using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class NoticeRepo : Repo, IRepo<Notice, int, bool>
    {
        public bool Create(Notice obj)
        {
            db.Notices.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Notices.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Notice> Get()
        {
            return db.Notices.ToList();
        }

        public Notice Get(int id)
        {
            return db.Notices.Find(id);
        }

        public bool Update(Notice obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}

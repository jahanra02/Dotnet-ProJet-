using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminTokenRepo : Repo, IRepo<AdminToken, int , AdminToken >
    {
        public AdminToken Create(AdminToken obj)
        {
            db.AdminTokens.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<AdminToken> Get()
        {
            return db.AdminTokens.ToList();
        }

        public AdminToken Get(int id)
        {
            throw new NotImplementedException();
        }

        public AdminToken Update(AdminToken obj)
        {
            throw new NotImplementedException();
        }
    }
}
    

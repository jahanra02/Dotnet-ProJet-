using DAL.EF.Models;
using DAL.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<TokenOrganizer, int, TokenOrganizer>
    {
        public TokenOrganizer Create(TokenOrganizer obj)
        {
            db.TokenOrganizers.Add(obj);
            //db.SaveChanges();
           // return obj;
            try
            {
                db.SaveChanges();
                return obj;
            }
            catch (Exception ex)
            {
                // Log the exception details
                return null;
            }

        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TokenOrganizer> Get()
        {
            return db.TokenOrganizers.ToList();
        }

        public TokenOrganizer Get(int id)
        {
            return db.TokenOrganizers.Find(id);
            
        }

        public TokenOrganizer Update(TokenOrganizer obj)
        {
            throw new NotImplementedException();
        }
    }
}

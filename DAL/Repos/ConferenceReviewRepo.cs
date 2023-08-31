using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ConferenceReviewRepo : Repo, IUserRepo<ConferenceReview, string, ConferenceReview>
    {
        public object Checkout(string userId)
        {
            throw new NotImplementedException();
        }

        public ConferenceReview Create(ConferenceReview obj)
        {
            db.ConferenceReviews.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var ex = Read(id);
            db.ConferenceReviews.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<ConferenceReview> Read()
        {
            return db.ConferenceReviews.ToList();
        }

        public ConferenceReview Read(string id)
        {
            return db.ConferenceReviews.Find(id);
        }

        public ConferenceReview Update(ConferenceReview obj)
        {
            var ex = Read(obj.ReviewId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}


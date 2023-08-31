using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PaymentInfoRepo : Repo, IUserRepo<PaymentInfo, string, PaymentInfo>
    {
        public object Checkout(string userId)
        {
            var paymentInfo = db.PaymentInfos.Where(x => x.UserId == userId).FirstOrDefault();
            if (paymentInfo is null)
            {
                return null;
            }

            var PaymentInfo = new PaymentInfo();
            PaymentInfo.PaymentId = paymentInfo.PaymentId;
            PaymentInfo.CardNumber = paymentInfo.CardNumber;
            PaymentInfo.ExpireDate = paymentInfo.ExpireDate;
            PaymentInfo.Cvv = paymentInfo.Cvv;

            return PaymentInfo;
        }

        public PaymentInfo Create(PaymentInfo obj)
        {
            db.PaymentInfos.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var ex = Read(id);
            db.PaymentInfos.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<PaymentInfo> Read()
        {
            return db.PaymentInfos.ToList();
        }

        public PaymentInfo Read(string id)
        {
            return db.PaymentInfos.Find(id);
        }

        public PaymentInfo Update(PaymentInfo obj)
        {
            var ex = Read(obj.PaymentId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    
    }
}

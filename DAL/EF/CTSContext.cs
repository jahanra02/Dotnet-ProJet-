using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class CTSContext: DbContext

    {
        public DbSet<OrganizerRegistration> OrganizerRegistrations { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Venue> Venues { get; set;}
        public DbSet<Auditorium> Auditoriums { get; set; }
        public DbSet<Sponsorship> Sponsorships { get; set;}
        public DbSet<TokenOrganizer> TokenOrganizers { get; set; }
        //A
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<StaffLogin> Logins { get; set; }
        public DbSet<PassOTP> PassOTPs { get; set; }
        public DbSet<StaffToken> Tokens { get; set; }
        //H
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AdminToken> AdminTokens { get; set; }

        //S
        public DbSet<User> Users { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ConferenceReview> ConferenceReviews { get; set; }
        public DbSet<PaymentInfo> PaymentInfos { get; set; }

    }
}

using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccess
    {
        public static IRepo<Conference, int, bool> ConferenceData()
        {
            return new ConferenceRepo();
        }
        public static IRepo<OrganizerRegistration, int, bool> OrganizerRegistrationData()
        {
            return new OrganizerRegistrationRepo();
        }
        public static IRepo<Auditorium, int, bool> AuditoriumData()
        {
            return new AuditoriumRepo();
        }
        public static IRepo<Venue, int, bool> VenueData()
        {
            return new VenueRepo();
        }
        public static IRepo<Sponsorship, int , bool> SponsorshipData()
        {
            return new SponsorshipRepo();
        }
        public static IRepo<TokenOrganizer, int , TokenOrganizer>TokenOrganizerData()
        {
            return new TokenRepo();
        }
        public static IAuth AuthDataAccess()
        {
            return new OrganizerRegistrationRepo();
        }
        
        
        public static IRepo<Seat, int, bool> SeatData()
        {
            return new SeatRepo();
        }

        public static IRepo<Staff, int, bool> StaffData()
        {
            return new StaffRepo();
        }
        
        public static IStaffAuth AuthData()
        {
            return new StaffLoginRepo();
        }
        public static IRepo<StaffToken, int, StaffToken> TokensData()
        {
            return new StaffTokenRepo();
        }
        //S
        public static IUserRepo<User, string, User> UserData()
        {
            return new UserRepo();
        }
        public static IUserRepo<UserToken, string, UserToken> UserTokenData()
        {
            return new UserTokenRepo();
        }

        public static IUserAuth<bool> UserAuthData()
        {
            return new UserRepo();
        }
        public static IUserRepo<Ticket, string, Ticket> TicketData()
        {
            return new TicketRepo();

        }
        public static IUserRepo<ConferenceReview, string, ConferenceReview> ReviewData()
        {
            return new ConferenceReviewRepo();
        }
        public static IUserRepo<PaymentInfo, string, PaymentInfo> InfoData()
        {
            return new PaymentInfoRepo();
        }

        //H
        public static IRepo<Admin, int, bool> AdminData()
        {
            return new AdminRepo();
        }
        
        public static IRepo<Category, int, bool> CategoryData()
        {
            return new CategoryRepo();
        }
        public static IRepo<Notice, int, bool> NoticeData()
        {
            return new NoticeRepo();
        }
        public static IAdminAuth AdminAuthData()
        {
            return new AdminRepo();
        }
        public static IRepo<AdminToken, int, AdminToken> AdminTokensData()
        {
            return new AdminTokenRepo();
        }
    }
}

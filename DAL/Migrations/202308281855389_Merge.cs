namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Merge : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenses", "E_Id", "dbo.ExpenseCats");
            DropIndex("dbo.Expenses", new[] { "E_Id" });
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        AdminId = c.Int(nullable: false),
                        Venue_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .ForeignKey("dbo.Venues", t => t.Venue_id, cascadeDelete: true)
                .Index(t => t.AdminId)
                .Index(t => t.Venue_id);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Venue_Location = c.String(nullable: false),
                        Venue_Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Auditoriums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        A_Name = c.String(nullable: false),
                        A_Capacity = c.Int(nullable: false),
                        Venue_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Venues", t => t.Venue_id, cascadeDelete: true)
                .Index(t => t.Venue_id);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Row = c.String(nullable: false),
                        Type = c.Boolean(nullable: false),
                        Auditorium_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auditoriums", t => t.Auditorium_id, cascadeDelete: true)
                .Index(t => t.Auditorium_id);
            
            CreateTable(
                "dbo.Conferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Details = c.String(),
                        Topic = c.String(),
                        Date = c.DateTime(nullable: false),
                        OId = c.Int(nullable: false),
                        VId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrganizerRegistrations", t => t.OId, cascadeDelete: true)
                .ForeignKey("dbo.Venues", t => t.VId, cascadeDelete: true)
                .Index(t => t.OId)
                .Index(t => t.VId);
            
            CreateTable(
                "dbo.OrganizerRegistrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Gender = c.String(),
                        Phone = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sponsorships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SponsorCompanyName = c.String(nullable: false),
                        ContactEmail = c.String(nullable: false),
                        ContactPhone = c.String(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ConferenceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conferences", t => t.ConferenceId, cascadeDelete: true)
                .Index(t => t.ConferenceId);
            
            CreateTable(
                "dbo.StaffLogins",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.PassOTPs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        OTP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TokenOrganizers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TokenKey = c.String(),
                        Organizer_Id = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrganizerRegistrations", t => t.Organizer_Id, cascadeDelete: true)
                .Index(t => t.Organizer_Id);
            
            CreateTable(
                "dbo.StaffTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TokenKey = c.String(),
                        Email = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StaffLogins", t => t.Email)
                .Index(t => t.Email);
            
            DropTable("dbo.ExpenseCats");
            DropTable("dbo.Expenses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpenseName = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        E_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExpenseCats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.StaffTokens", "Email", "dbo.StaffLogins");
            DropForeignKey("dbo.TokenOrganizers", "Organizer_Id", "dbo.OrganizerRegistrations");
            DropForeignKey("dbo.Staffs", "Venue_id", "dbo.Venues");
            DropForeignKey("dbo.Conferences", "VId", "dbo.Venues");
            DropForeignKey("dbo.Sponsorships", "ConferenceId", "dbo.Conferences");
            DropForeignKey("dbo.Conferences", "OId", "dbo.OrganizerRegistrations");
            DropForeignKey("dbo.Auditoriums", "Venue_id", "dbo.Venues");
            DropForeignKey("dbo.Seats", "Auditorium_id", "dbo.Auditoriums");
            DropForeignKey("dbo.Staffs", "AdminId", "dbo.Admins");
            DropIndex("dbo.StaffTokens", new[] { "Email" });
            DropIndex("dbo.TokenOrganizers", new[] { "Organizer_Id" });
            DropIndex("dbo.Sponsorships", new[] { "ConferenceId" });
            DropIndex("dbo.Conferences", new[] { "VId" });
            DropIndex("dbo.Conferences", new[] { "OId" });
            DropIndex("dbo.Seats", new[] { "Auditorium_id" });
            DropIndex("dbo.Auditoriums", new[] { "Venue_id" });
            DropIndex("dbo.Staffs", new[] { "Venue_id" });
            DropIndex("dbo.Staffs", new[] { "AdminId" });
            DropTable("dbo.StaffTokens");
            DropTable("dbo.TokenOrganizers");
            DropTable("dbo.PassOTPs");
            DropTable("dbo.StaffLogins");
            DropTable("dbo.Sponsorships");
            DropTable("dbo.OrganizerRegistrations");
            DropTable("dbo.Conferences");
            DropTable("dbo.Seats");
            DropTable("dbo.Auditoriums");
            DropTable("dbo.Venues");
            DropTable("dbo.Staffs");
            DropTable("dbo.Admins");
            CreateIndex("dbo.Expenses", "E_Id");
            AddForeignKey("dbo.Expenses", "E_Id", "dbo.ExpenseCats", "Id", cascadeDelete: true);
        }
    }
}

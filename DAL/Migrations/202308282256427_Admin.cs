namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Admin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TokenKey = c.String(),
                        Username = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CId, cascadeDelete: true)
                .Index(t => t.CId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notices", "CId", "dbo.Categories");
            DropForeignKey("dbo.AdminTokens", "AdminId", "dbo.Admins");
            DropIndex("dbo.Notices", new[] { "CId" });
            DropIndex("dbo.AdminTokens", new[] { "AdminId" });
            DropTable("dbo.Notices");
            DropTable("dbo.Categories");
            DropTable("dbo.AdminTokens");
        }
    }
}

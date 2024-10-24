namespace MVC_MasterD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Suriya : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingEntries",
                c => new
                    {
                        BookingEntryId = c.Int(nullable: false, identity: true),
                        SpotId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingEntryId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Spots", t => t.SpotId, cascadeDelete: true)
                .Index(t => t.SpotId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        ClientName = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        Picture = c.String(),
                        MaritalStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Spots",
                c => new
                    {
                        SpotId = c.Int(nullable: false, identity: true),
                        SpotName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SpotId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingEntries", "SpotId", "dbo.Spots");
            DropForeignKey("dbo.BookingEntries", "ClientId", "dbo.Clients");
            DropIndex("dbo.BookingEntries", new[] { "ClientId" });
            DropIndex("dbo.BookingEntries", new[] { "SpotId" });
            DropTable("dbo.Spots");
            DropTable("dbo.Clients");
            DropTable("dbo.BookingEntries");
        }
    }
}

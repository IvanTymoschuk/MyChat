namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attaches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Content = c.String(),
                        Message_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Messages", t => t.Message_Id)
                .Index(t => t.Message_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        DateTimeSended = c.DateTime(nullable: false),
                        Room_Id = c.Int(),
                        Sender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .ForeignKey("dbo.Users", t => t.Sender_Id)
                .Index(t => t.Room_Id)
                .Index(t => t.Sender_Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsPublish = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                        User_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.User_Id1)
                .Index(t => t.User_Id)
                .Index(t => t.User_Id1);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        IsConfirmed = c.Boolean(nullable: false),
                        Email = c.String(),
                        User_Id = c.Int(),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.ConfirmCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        code = c.Int(nullable: false),
                        user_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.user_Id)
                .Index(t => t.user_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConfirmCodes", "user_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Sender_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "User_Id1", "dbo.Users");
            DropForeignKey("dbo.Rooms", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Attaches", "Message_Id", "dbo.Messages");
            DropIndex("dbo.ConfirmCodes", new[] { "user_Id" });
            DropIndex("dbo.Users", new[] { "Room_Id" });
            DropIndex("dbo.Users", new[] { "User_Id" });
            DropIndex("dbo.Rooms", new[] { "User_Id1" });
            DropIndex("dbo.Rooms", new[] { "User_Id" });
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            DropIndex("dbo.Messages", new[] { "Room_Id" });
            DropIndex("dbo.Attaches", new[] { "Message_Id" });
            DropTable("dbo.ConfirmCodes");
            DropTable("dbo.Users");
            DropTable("dbo.Rooms");
            DropTable("dbo.Messages");
            DropTable("dbo.Attaches");
        }
    }
}

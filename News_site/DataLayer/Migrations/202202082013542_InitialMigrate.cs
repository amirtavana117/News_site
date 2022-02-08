namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        NewsTitle = c.String(nullable: false, maxLength: 150),
                        ShortDescribtion = c.String(nullable: false, maxLength: 350),
                        NewsText = c.String(nullable: false),
                        visited = c.Int(nullable: false),
                        ImageName = c.String(),
                        ShoWInslider = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NewsId)
                .ForeignKey("dbo.NewsGroups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.NewsComments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        NewsId = c.Int(nullable: false),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 150),
                        Comment = c.String(nullable: false, maxLength: 350),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.News", t => t.NewsId, cascadeDelete: true)
                .Index(t => t.NewsId);
            
            CreateTable(
                "dbo.NewsGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupTitle = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "GroupId", "dbo.NewsGroups");
            DropForeignKey("dbo.NewsComments", "NewsId", "dbo.News");
            DropIndex("dbo.NewsComments", new[] { "NewsId" });
            DropIndex("dbo.News", new[] { "GroupId" });
            DropTable("dbo.NewsGroups");
            DropTable("dbo.NewsComments");
            DropTable("dbo.News");
        }
    }
}

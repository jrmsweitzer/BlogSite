namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        NumViews = c.Int(nullable: false),
                        NumShares = c.Int(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        BlogID = c.Int(nullable: false),
                        Content = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.BlogID);
            
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BlogID = c.Int(nullable: false),
                        CommentID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Blog", t => t.BlogID, cascadeDelete: true)
                .Index(t => t.BlogID)
                .Index(t => t.CommentID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserPermission = c.Int(nullable: false),
                        Username = c.String(),
                        PasswordHash = c.String(),
                        JoinDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TagBlog",
                c => new
                    {
                        Tag_ID = c.Int(nullable: false),
                        Blog_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_ID, t.Blog_ID })
                .ForeignKey("dbo.Tag", t => t.Tag_ID, cascadeDelete: true)
                .ForeignKey("dbo.Blog", t => t.Blog_ID, cascadeDelete: true)
                .Index(t => t.Tag_ID)
                .Index(t => t.Blog_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagBlog", "Blog_ID", "dbo.Blog");
            DropForeignKey("dbo.TagBlog", "Tag_ID", "dbo.Tag");
            DropForeignKey("dbo.Like", "UserID", "dbo.User");
            DropForeignKey("dbo.Comment", "UserID", "dbo.User");
            DropForeignKey("dbo.Blog", "UserID", "dbo.User");
            DropForeignKey("dbo.Like", "CommentID", "dbo.Comment");
            DropForeignKey("dbo.Like", "BlogID", "dbo.Blog");
            DropForeignKey("dbo.Comment", "BlogID", "dbo.Blog");
            DropIndex("dbo.TagBlog", new[] { "Blog_ID" });
            DropIndex("dbo.TagBlog", new[] { "Tag_ID" });
            DropIndex("dbo.Like", new[] { "UserID" });
            DropIndex("dbo.Like", new[] { "CommentID" });
            DropIndex("dbo.Like", new[] { "BlogID" });
            DropIndex("dbo.Comment", new[] { "BlogID" });
            DropIndex("dbo.Comment", new[] { "UserID" });
            DropIndex("dbo.Blog", new[] { "UserID" });
            DropTable("dbo.TagBlog");
            DropTable("dbo.Tag");
            DropTable("dbo.User");
            DropTable("dbo.Like");
            DropTable("dbo.Comment");
            DropTable("dbo.Blog");
        }
    }
}

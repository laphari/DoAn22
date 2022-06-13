namespace DATNwebtintuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        post_id = c.String(nullable: false, maxLength: 128),
                        post_title = c.String(),
                        post_slug = c.String(),
                        post_teaser = c.String(),
                        post_review = c.String(),
                        post_content = c.String(),
                        post_tag = c.String(),
                        create_date = c.DateTime(),
                        edit_date = c.DateTime(),
                        ViewCount = c.Int(nullable: false),
                        Rated = c.Int(nullable: false),
                        AvatarImage = c.String(),
                        status = c.Boolean(nullable: false),
                        IDcategory = c.String(maxLength: 128),
                        IDaccount = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.post_id)
                .ForeignKey("dbo.Accounts", t => t.IDaccount)
                .ForeignKey("dbo.Categories", t => t.IDcategory)
                .Index(t => t.IDaccount)
                .Index(t => t.IDcategory);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        IDaccount = c.String(nullable: false, maxLength: 128),
                        Username = c.String(),
                        Email = c.String(),
                        password = c.String(),
                        Image = c.String(),
                        userrole = c.String(),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IDaccount);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        IDcategory = c.String(nullable: false, maxLength: 128),
                        namecategory = c.String(),
                    })
                .PrimaryKey(t => t.IDcategory);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagID = c.String(nullable: false, maxLength: 128),
                        TagName = c.String(),
                        post_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TagID)
                .ForeignKey("dbo.Posts", t => t.post_id)
                .Index(t => t.post_id);
            
            CreateTable(
                "dbo.StickyPosts",
                c => new
                    {
                        idStickyPosts = c.String(nullable: false, maxLength: 128),
                        priority = c.Int(nullable: false),
                        post_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.idStickyPosts)
                .ForeignKey("dbo.Posts", t => t.post_id)
                .Index(t => t.post_id);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        seriesID = c.String(nullable: false, maxLength: 128),
                        seriesName = c.String(),
                        post_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.seriesID)
                .ForeignKey("dbo.Posts", t => t.post_id)
                .Index(t => t.post_id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Series", new[] { "post_id" });
            DropIndex("dbo.StickyPosts", new[] { "post_id" });
            DropIndex("dbo.Tags", new[] { "post_id" });
            DropIndex("dbo.Posts", new[] { "IDcategory" });
            DropIndex("dbo.Posts", new[] { "IDaccount" });
            DropForeignKey("dbo.Series", "post_id", "dbo.Posts");
            DropForeignKey("dbo.StickyPosts", "post_id", "dbo.Posts");
            DropForeignKey("dbo.Tags", "post_id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "IDcategory", "dbo.Categories");
            DropForeignKey("dbo.Posts", "IDaccount", "dbo.Accounts");
            DropTable("dbo.Series");
            DropTable("dbo.StickyPosts");
            DropTable("dbo.Tags");
            DropTable("dbo.Categories");
            DropTable("dbo.Accounts");
            DropTable("dbo.Posts");
        }
    }
}

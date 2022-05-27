namespace DATNwebtintuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "post_id", "dbo.Posts");
            DropForeignKey("dbo.Series", "post_id", "dbo.Posts");
            DropIndex("dbo.Tags", new[] { "post_id" });
            DropIndex("dbo.Series", new[] { "post_id" });
            RenameColumn(table: "dbo.StickyPosts", name: "post_id", newName: "Post_post_id");
            AlterColumn("dbo.Tags", "post_id", c => c.Int(nullable: false));
            AlterColumn("dbo.StickyPosts", "post_id", c => c.String());
            AlterColumn("dbo.Series", "post_id", c => c.Int(nullable: false));
            AddForeignKey("dbo.Tags", "post_id", "dbo.Posts", "post_id", cascadeDelete: true);
            AddForeignKey("dbo.Series", "post_id", "dbo.Posts", "post_id", cascadeDelete: true);
            CreateIndex("dbo.Tags", "post_id");
            CreateIndex("dbo.Series", "post_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Series", new[] { "post_id" });
            DropIndex("dbo.Tags", new[] { "post_id" });
            DropForeignKey("dbo.Series", "post_id", "dbo.Posts");
            DropForeignKey("dbo.Tags", "post_id", "dbo.Posts");
            AlterColumn("dbo.Series", "post_id", c => c.Int());
            AlterColumn("dbo.StickyPosts", "post_id", c => c.Int());
            AlterColumn("dbo.Tags", "post_id", c => c.Int());
            RenameColumn(table: "dbo.StickyPosts", name: "Post_post_id", newName: "post_id");
            CreateIndex("dbo.Series", "post_id");
            CreateIndex("dbo.Tags", "post_id");
            AddForeignKey("dbo.Series", "post_id", "dbo.Posts", "post_id");
            AddForeignKey("dbo.Tags", "post_id", "dbo.Posts", "post_id");
        }
    }
}

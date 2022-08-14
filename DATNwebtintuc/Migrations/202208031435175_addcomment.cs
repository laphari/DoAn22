namespace DATNwebtintuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcomment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        commentID = c.String(nullable: false, maxLength: 128),
                        commentName = c.String(),
                        post_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.commentID)
                .ForeignKey("dbo.Posts", t => t.post_id)
                .Index(t => t.post_id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "post_id" });
            DropForeignKey("dbo.Comments", "post_id", "dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}

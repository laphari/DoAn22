namespace DATNwebtintuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addauthor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "AuthorName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "AuthorName");
        }
    }
}

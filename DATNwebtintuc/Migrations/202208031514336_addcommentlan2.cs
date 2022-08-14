namespace DATNwebtintuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcommentlan2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "commentContent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "commentContent");
        }
    }
}

namespace DATNwebtintuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstickypost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "stickypost", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "stickypost");
        }
    }
}

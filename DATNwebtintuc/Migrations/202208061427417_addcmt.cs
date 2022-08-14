namespace DATNwebtintuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcmt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "dateComment", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "dateComment");
        }
    }
}

namespace DATNwebtintuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertisements", "urlAdvertisment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertisements", "urlAdvertisment");
        }
    }
}

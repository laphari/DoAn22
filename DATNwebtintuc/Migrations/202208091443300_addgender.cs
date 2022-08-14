namespace DATNwebtintuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addgender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "gender");
        }
    }
}

namespace DATNwebtintuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertisements",
                c => new
                    {
                        idAdvertisement = c.String(nullable: false, maxLength: 128),
                        linkAdvertisement = c.String(),
                        typeAdvertisement = c.String(),
                    })
                .PrimaryKey(t => t.idAdvertisement);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Advertisements");
        }
    }
}

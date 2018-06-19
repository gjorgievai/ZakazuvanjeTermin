namespace ZakazuvanjeTermin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pacients", "KrvnaGrupa", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pacients", "KrvnaGrupa");
        }
    }
}

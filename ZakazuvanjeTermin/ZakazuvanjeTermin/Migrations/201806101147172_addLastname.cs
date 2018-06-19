namespace ZakazuvanjeTermin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLastname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "LastName");
        }
    }
}

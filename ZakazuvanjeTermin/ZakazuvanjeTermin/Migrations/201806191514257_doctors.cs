namespace ZakazuvanjeTermin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doctors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receptas", "Pacient_Id", c => c.Int());
            CreateIndex("dbo.Receptas", "Pacient_Id");
            AddForeignKey("dbo.Receptas", "Pacient_Id", "dbo.Pacients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receptas", "Pacient_Id", "dbo.Pacients");
            DropIndex("dbo.Receptas", new[] { "Pacient_Id" });
            DropColumn("dbo.Receptas", "Pacient_Id");
        }
    }
}

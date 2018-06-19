namespace ZakazuvanjeTermin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "FirstName", c => c.String());
            AddColumn("dbo.Pacients", "FirstName", c => c.String());
            AddColumn("dbo.Pacients", "LastName", c => c.String());
            AddColumn("dbo.Pacients", "EMBG", c => c.String());
            AddColumn("dbo.Pacients", "Doctor_Id", c => c.Int());
            CreateIndex("dbo.Pacients", "Doctor_Id");
            AddForeignKey("dbo.Pacients", "Doctor_Id", "dbo.Doctors", "Id");
            DropColumn("dbo.Doctors", "Name");
            DropColumn("dbo.Pacients", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pacients", "Name", c => c.String());
            AddColumn("dbo.Doctors", "Name", c => c.String());
            DropForeignKey("dbo.Pacients", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Pacients", new[] { "Doctor_Id" });
            DropColumn("dbo.Pacients", "Doctor_Id");
            DropColumn("dbo.Pacients", "EMBG");
            DropColumn("dbo.Pacients", "LastName");
            DropColumn("dbo.Pacients", "FirstName");
            DropColumn("dbo.Doctors", "FirstName");
        }
    }
}

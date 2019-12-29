namespace LibraryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rent1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RentLivres", "IDUser", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RentLivres", "IDUser");
        }
    }
}

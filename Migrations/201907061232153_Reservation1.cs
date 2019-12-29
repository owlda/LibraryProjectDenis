namespace LibraryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reservation1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "IDUser", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "IDUser");
        }
    }
}

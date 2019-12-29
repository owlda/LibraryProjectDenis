namespace LibraryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditRentUserID : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RentLivres", "IDUser", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RentLivres", "IDUser", c => c.Int(nullable: false));
        }
    }
}

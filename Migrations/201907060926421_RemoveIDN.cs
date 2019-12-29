namespace LibraryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveIDN : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RentLivres", "IDP");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RentLivres", "IDP", c => c.Int(nullable: false));
        }
    }
}

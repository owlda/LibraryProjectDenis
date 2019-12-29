namespace LibraryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamneOfUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NameOfUser", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "NameOfUser");
        }
    }
}

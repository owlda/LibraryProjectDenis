namespace LibraryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Livres", "NumberAvalible", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Livres", "NumberAvalible", c => c.Byte(nullable: false));
        }
    }
}

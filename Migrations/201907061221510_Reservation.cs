namespace LibraryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reservation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Author = c.String(),
                        NumberAvalible = c.String(),
                        Category = c.String(),
                        DateTimeReservation = c.DateTime(nullable: false),
                        DateTimeRetour = c.DateTime(nullable: false),
                        NumberInCatalog = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reservations");
        }
    }
}

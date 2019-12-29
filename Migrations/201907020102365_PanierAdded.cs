namespace LibraryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PanierAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Paniers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateTimeReservation = c.DateTime(nullable: false),
                        DateTimeRetour = c.DateTime(nullable: false),
                        RentLivre_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RentLivres", t => t.RentLivre_Id)
                .Index(t => t.RentLivre_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paniers", "RentLivre_Id", "dbo.RentLivres");
            DropIndex("dbo.Paniers", new[] { "RentLivre_Id" });
            DropTable("dbo.Paniers");
        }
    }
}

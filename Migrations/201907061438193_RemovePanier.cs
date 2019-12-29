namespace LibraryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePanier : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RentLivres", "Livre_Id", "dbo.Livres");
            DropForeignKey("dbo.Livres", "RentLivre_Id", "dbo.RentLivres");
            DropForeignKey("dbo.Paniers", "RentLivre_Id", "dbo.RentLivres");
            DropIndex("dbo.Livres", new[] { "RentLivre_Id" });
            DropIndex("dbo.Paniers", new[] { "RentLivre_Id" });
            DropIndex("dbo.RentLivres", new[] { "Livre_Id" });
            DropColumn("dbo.Livres", "RentLivre_Id");
            DropTable("dbo.Paniers");
            DropTable("dbo.RentLivres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RentLivres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IDUser = c.String(),
                        Livre_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Paniers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateTimeReservation = c.DateTime(nullable: false),
                        DateTimeRetour = c.DateTime(nullable: false),
                        RentLivre_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Livres", "RentLivre_Id", c => c.Int());
            CreateIndex("dbo.RentLivres", "Livre_Id");
            CreateIndex("dbo.Paniers", "RentLivre_Id");
            CreateIndex("dbo.Livres", "RentLivre_Id");
            AddForeignKey("dbo.Paniers", "RentLivre_Id", "dbo.RentLivres", "Id");
            AddForeignKey("dbo.Livres", "RentLivre_Id", "dbo.RentLivres", "Id");
            AddForeignKey("dbo.RentLivres", "Livre_Id", "dbo.Livres", "Id");
        }
    }
}

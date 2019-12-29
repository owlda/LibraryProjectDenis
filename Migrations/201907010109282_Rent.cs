namespace LibraryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RentLivres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Livre_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Livres", t => t.Livre_Id)
                .Index(t => t.Livre_Id);
            
            AddColumn("dbo.Livres", "RentLivre_Id", c => c.Int());
            CreateIndex("dbo.Livres", "RentLivre_Id");
            AddForeignKey("dbo.Livres", "RentLivre_Id", "dbo.RentLivres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livres", "RentLivre_Id", "dbo.RentLivres");
            DropForeignKey("dbo.RentLivres", "Livre_Id", "dbo.Livres");
            DropIndex("dbo.RentLivres", new[] { "Livre_Id" });
            DropIndex("dbo.Livres", new[] { "RentLivre_Id" });
            DropColumn("dbo.Livres", "RentLivre_Id");
            DropTable("dbo.RentLivres");
        }
    }
}

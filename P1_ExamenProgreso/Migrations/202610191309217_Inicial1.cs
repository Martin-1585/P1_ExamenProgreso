namespace P1_ExamenProgreso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Caballeroes", "Armadura_id", "dbo.Armaduras");
            DropIndex("dbo.Caballeroes", new[] { "Armadura_id" });
            AddColumn("dbo.Armaduras", "caballeroId", c => c.Int(nullable: false));
            CreateIndex("dbo.Armaduras", "caballeroId");
            AddForeignKey("dbo.Armaduras", "caballeroId", "dbo.Caballeroes", "id", cascadeDelete: true);
            DropColumn("dbo.Caballeroes", "Armadura_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Caballeroes", "Armadura_id", c => c.Int());
            DropForeignKey("dbo.Armaduras", "caballeroId", "dbo.Caballeroes");
            DropIndex("dbo.Armaduras", new[] { "caballeroId" });
            DropColumn("dbo.Armaduras", "caballeroId");
            CreateIndex("dbo.Caballeroes", "Armadura_id");
            AddForeignKey("dbo.Caballeroes", "Armadura_id", "dbo.Armaduras", "id");
        }
    }
}

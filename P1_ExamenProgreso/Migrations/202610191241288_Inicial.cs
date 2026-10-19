namespace P1_ExamenProgreso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Armaduras",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombreArmadura = c.String(nullable: false),
                        tipo = c.String(nullable: false),
                        resistencia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Caballeroes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        constelacion = c.String(nullable: false),
                        nivelPoder = c.Int(nullable: false),
                        elemento = c.String(nullable: false),
                        Armadura_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Armaduras", t => t.Armadura_id)
                .Index(t => t.Armadura_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Caballeroes", "Armadura_id", "dbo.Armaduras");
            DropIndex("dbo.Caballeroes", new[] { "Armadura_id" });
            DropTable("dbo.Caballeroes");
            DropTable("dbo.Armaduras");
        }
    }
}

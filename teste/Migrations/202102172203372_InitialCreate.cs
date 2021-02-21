namespace teste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MarcaCarro = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Modelo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModeloCarro = c.String(),
                        IdCarro = c.Int(nullable: false),
                        Carro_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carro", t => t.Carro_Id)
                .Index(t => t.Carro_Id);
            
            CreateTable(
                "dbo.Peca",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomePeca = c.String(),
                        IdModelo = c.Int(nullable: false),
                        Modelos_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Modelo", t => t.Modelos_Id)
                .Index(t => t.Modelos_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Peca", "Modelos_Id", "dbo.Modelo");
            DropForeignKey("dbo.Modelo", "Carro_Id", "dbo.Carro");
            DropIndex("dbo.Peca", new[] { "Modelos_Id" });
            DropIndex("dbo.Modelo", new[] { "Carro_Id" });
            DropTable("dbo.Peca");
            DropTable("dbo.Modelo");
            DropTable("dbo.Carro");
        }
    }
}

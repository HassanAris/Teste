namespace teste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Menssageria : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mensageria", "Peca_Id", "dbo.Peca");
            DropIndex("dbo.Mensageria", new[] { "Peca_Id" });
            AddColumn("dbo.Mensageria", "IdPeca", c => c.Int(nullable: false));
            DropColumn("dbo.Mensageria", "Peca_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mensageria", "Peca_Id", c => c.Int());
            DropColumn("dbo.Mensageria", "IdPeca");
            CreateIndex("dbo.Mensageria", "Peca_Id");
            AddForeignKey("dbo.Mensageria", "Peca_Id", "dbo.Peca", "Id");
        }
    }
}

namespace teste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTabela : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Peca", name: "Modelos_Id", newName: "Modelo_Id");
            RenameIndex(table: "dbo.Peca", name: "IX_Modelos_Id", newName: "IX_Modelo_Id");
            DropColumn("dbo.Modelo", "IdCarro");
            DropColumn("dbo.Peca", "IdModelo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Peca", "IdModelo", c => c.Int(nullable: false));
            AddColumn("dbo.Modelo", "IdCarro", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Peca", name: "IX_Modelo_Id", newName: "IX_Modelos_Id");
            RenameColumn(table: "dbo.Peca", name: "Modelo_Id", newName: "Modelos_Id");
        }
    }
}

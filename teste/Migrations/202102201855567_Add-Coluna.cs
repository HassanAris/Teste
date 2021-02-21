namespace teste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColuna : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Peca", "QTD", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Peca", "QTD");
        }
    }
}

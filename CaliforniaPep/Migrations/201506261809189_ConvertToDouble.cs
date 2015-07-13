namespace CaliforniaPep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConvertToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "MolecularWeight", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "MolecularWeight", c => c.String());
        }
    }
}

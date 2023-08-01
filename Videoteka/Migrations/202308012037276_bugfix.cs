namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bugfix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TipClanstvas", "Naziv", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.TipKupcas", "Naziv", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TipKupcas", "Naziv", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.TipClanstvas", "Naziv", c => c.String(nullable: false, maxLength: 100));
        }
    }
}

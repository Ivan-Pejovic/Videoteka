namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Films", "Naziv", c => c.String(nullable: false));
            AlterColumn("dbo.Kupacs", "Ime", c => c.String(nullable: false));
            AlterColumn("dbo.Pozajmicas", "Napomena", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pozajmicas", "Napomena", c => c.String());
            AlterColumn("dbo.Kupacs", "Ime", c => c.String());
            AlterColumn("dbo.Films", "Naziv", c => c.String());
        }
    }
}

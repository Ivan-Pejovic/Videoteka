namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatumVracanjaNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pozajmicas", "DatumVracanja", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pozajmicas", "DatumVracanja", c => c.DateTime(nullable: false));
        }
    }
}

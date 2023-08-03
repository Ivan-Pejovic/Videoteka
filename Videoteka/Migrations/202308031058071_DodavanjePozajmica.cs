namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodavanjePozajmica : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pozajmicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KupacId = c.Int(nullable: false),
                        FilmId = c.Int(nullable: false),
                        DatumPozajmice = c.DateTime(nullable: false),
                        DatumVracanja = c.DateTime(nullable: false),
                        Napomena = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.FilmId, cascadeDelete: true)
                .ForeignKey("dbo.Kupacs", t => t.KupacId, cascadeDelete: true)
                .Index(t => t.KupacId)
                .Index(t => t.FilmId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pozajmicas", "KupacId", "dbo.Kupacs");
            DropForeignKey("dbo.Pozajmicas", "FilmId", "dbo.Films");
            DropIndex("dbo.Pozajmicas", new[] { "FilmId" });
            DropIndex("dbo.Pozajmicas", new[] { "KupacId" });
            DropTable("dbo.Pozajmicas");
        }
    }
}

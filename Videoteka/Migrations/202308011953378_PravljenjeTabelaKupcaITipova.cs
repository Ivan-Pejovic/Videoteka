namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PravljenjeTabelaKupcaITipova : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kupacs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        PrimaObavjestenja = c.Boolean(nullable: false),
                        DatumRodjenja = c.DateTime(nullable: false),
                        TipKupcaId = c.Int(nullable: false),
                        TipClanstvaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipClanstvas", t => t.TipClanstvaId, cascadeDelete: true)
                .ForeignKey("dbo.TipKupcas", t => t.TipKupcaId, cascadeDelete: true)
                .Index(t => t.TipKupcaId)
                .Index(t => t.TipClanstvaId);
            
            CreateTable(
                "dbo.TipClanstvas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Clanarina = c.Int(nullable: false),
                        TrajanjeMjeseci = c.Int(nullable: false),
                        ProcenatPopusta = c.Int(nullable: false),
                        Naziv = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipKupcas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kupacs", "TipKupcaId", "dbo.TipKupcas");
            DropForeignKey("dbo.Kupacs", "TipClanstvaId", "dbo.TipClanstvas");
            DropIndex("dbo.Kupacs", new[] { "TipClanstvaId" });
            DropIndex("dbo.Kupacs", new[] { "TipKupcaId" });
            DropTable("dbo.TipKupcas");
            DropTable("dbo.TipClanstvas");
            DropTable("dbo.Kupacs");
        }
    }
}

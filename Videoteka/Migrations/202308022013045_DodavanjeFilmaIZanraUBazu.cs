namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodavanjeFilmaIZanraUBazu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        ZanrId = c.Int(nullable: false),
                        DatumUnosa = c.DateTime(nullable: false),
                        DatumIzdanja = c.DateTime(nullable: false),
                        BrojNaStanju = c.Int(nullable: false),
                        BrojDostupnih = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zanrs", t => t.ZanrId, cascadeDelete: true)
                .Index(t => t.ZanrId);
            
            CreateTable(
                "dbo.Zanrs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "ZanrId", "dbo.Zanrs");
            DropIndex("dbo.Films", new[] { "ZanrId" });
            DropTable("dbo.Zanrs");
            DropTable("dbo.Films");
        }
    }
}

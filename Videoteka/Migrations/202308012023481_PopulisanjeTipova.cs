namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulisanjeTipova : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TipClanstvas (Clanarina, TrajanjeMjeseci, ProcenatPopusta, Naziv) VALUES (0, 0, 0, 'Po Vidjenju')");
            Sql("INSERT INTO TipClanstvas (Clanarina, TrajanjeMjeseci, ProcenatPopusta, Naziv) VALUES (30, 1, 10, 'Mjesecno')");
            Sql("INSERT INTO TipClanstvas (Clanarina, TrajanjeMjeseci, ProcenatPopusta, Naziv) VALUES (90, 3, 15, 'Kvartalno')");
            Sql("INSERT INTO TipClanstvas (Clanarina, TrajanjeMjeseci, ProcenatPopusta, Naziv) VALUES (165, 6, 20, 'Polugodisnje')");
            Sql("INSERT INTO TipClanstvas (Clanarina, TrajanjeMjeseci, ProcenatPopusta, Naziv) VALUES (300, 12, 30, 'Godisnje')");

            Sql("INSERT INTO TipKupcas (Naziv) VALUES ('Ucenik')");
            Sql("INSERT INTO TipKupcas (Naziv) VALUES ('Student')");
            Sql("INSERT INTO TipKupcas (Naziv) VALUES ('Nezaposlen')");
            Sql("INSERT INTO TipKupcas (Naziv) VALUES ('Zaposlen')");
            Sql("INSERT INTO TipKupcas (Naziv) VALUES ('Penzioner')");
        }
        
        public override void Down()
        {
        }
    }
}

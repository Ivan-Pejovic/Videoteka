namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulisanjeZanrova : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Zanrs (Naziv) VALUES ('Naucna fantastika')");
            Sql("INSERT INTO Zanrs (Naziv) VALUES ('Dokumentarni')");
            Sql("INSERT INTO Zanrs (Naziv) VALUES ('Avantura')");
            Sql("INSERT INTO Zanrs (Naziv) VALUES ('Animirani')");
            Sql("INSERT INTO Zanrs (Naziv) VALUES ('Akcija')");
            Sql("INSERT INTO Zanrs (Naziv) VALUES ('Djeciji')");
            Sql("INSERT INTO Zanrs (Naziv) VALUES ('Komedija')");
            Sql("INSERT INTO Zanrs (Naziv) VALUES ('Kriminalisticki')");
            Sql("INSERT INTO Zanrs (Naziv) VALUES ('Ljubavni')");
            Sql("INSERT INTO Zanrs (Naziv) VALUES ('Mjuzikl')");
        }
        
        public override void Down()
        {
        }
    }
}

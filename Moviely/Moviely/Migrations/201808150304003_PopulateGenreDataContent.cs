namespace Moviely.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreDataContent : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES(1,'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(2,'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(3,'Science Fiction')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(4,'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(5,'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}

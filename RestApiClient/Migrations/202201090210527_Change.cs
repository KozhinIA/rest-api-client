namespace RestApiClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "CurrencyTypeId", "dbo.CurrencyTypes");
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "CurrencyTypeId" });
            DropIndex("dbo.Books", new[] { "GenreId" });
            AddColumn("dbo.Authors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Isbn", c => c.String());
            AlterColumn("dbo.Books", "Year", c => c.Int());
            AlterColumn("dbo.Books", "Cost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Books", "CurrencyTypeId", c => c.Int());
            AlterColumn("dbo.Books", "GenreId", c => c.Int());
            AlterColumn("dbo.Books", "Annotation", c => c.String());
            CreateIndex("dbo.Books", "CurrencyTypeId");
            CreateIndex("dbo.Books", "GenreId");
            AddForeignKey("dbo.Books", "CurrencyTypeId", "dbo.CurrencyTypes", "Id");
            AddForeignKey("dbo.Books", "GenreId", "dbo.Genres", "Id");
            DropColumn("dbo.Authors", "FirestName");
            DropColumn("dbo.Authors", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Authors", "FirestName", c => c.String(nullable: false));
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Books", "CurrencyTypeId", "dbo.CurrencyTypes");
            DropIndex("dbo.Books", new[] { "GenreId" });
            DropIndex("dbo.Books", new[] { "CurrencyTypeId" });
            AlterColumn("dbo.Books", "Annotation", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "GenreId", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "CurrencyTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Books", "Year", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "Isbn", c => c.String(nullable: false));
            DropColumn("dbo.Authors", "Name");
            CreateIndex("dbo.Books", "GenreId");
            CreateIndex("dbo.Books", "CurrencyTypeId");
            AddForeignKey("dbo.Books", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Books", "CurrencyTypeId", "dbo.CurrencyTypes", "Id", cascadeDelete: true);
        }
    }
}

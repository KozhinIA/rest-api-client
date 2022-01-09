namespace RestApiClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAuthor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "BirthYear", c => c.Int());
            DropColumn("dbo.Authors", "Birthday");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "Birthday", c => c.DateTime());
            DropColumn("dbo.Authors", "BirthYear");
        }
    }
}

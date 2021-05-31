namespace Wiky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Requiredthem : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Theme", c => c.String(nullable: false));
            AlterColumn("dbo.Articles", "Auteur", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "Auteur", c => c.String());
            AlterColumn("dbo.Articles", "Theme", c => c.String());
        }
    }
}

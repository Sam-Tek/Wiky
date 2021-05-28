namespace Wiky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThemUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Commentaires", "Auteur", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Commentaires", "Auteur", c => c.String());
        }
    }
}

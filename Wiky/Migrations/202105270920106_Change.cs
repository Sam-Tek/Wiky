namespace Wiky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Commentaires", "Article_Id", "dbo.Articles");
            DropIndex("dbo.Commentaires", new[] { "Article_Id" });
            RenameColumn(table: "dbo.Commentaires", name: "Article_Id", newName: "ArticleId");
            AlterColumn("dbo.Commentaires", "ArticleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Commentaires", "ArticleId");
            AddForeignKey("dbo.Commentaires", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commentaires", "ArticleId", "dbo.Articles");
            DropIndex("dbo.Commentaires", new[] { "ArticleId" });
            AlterColumn("dbo.Commentaires", "ArticleId", c => c.Int());
            RenameColumn(table: "dbo.Commentaires", name: "ArticleId", newName: "Article_Id");
            CreateIndex("dbo.Commentaires", "Article_Id");
            AddForeignKey("dbo.Commentaires", "Article_Id", "dbo.Articles", "Id");
        }
    }
}

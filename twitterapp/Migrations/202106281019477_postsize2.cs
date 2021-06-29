namespace twitterapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postsize2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.posts", "Post", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.posts", "Post", c => c.String());
        }
    }
}

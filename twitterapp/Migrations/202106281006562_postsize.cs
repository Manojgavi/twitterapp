namespace twitterapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postsize : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE posts ALTER COLUMN  Post varchar(100); ");
        }
        
        public override void Down()
        {
        }
    }
}

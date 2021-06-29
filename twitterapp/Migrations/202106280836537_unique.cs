namespace twitterapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unique : DbMigration
    {
        public override void Up()
        {
           // Sql("ALTER TABLE users ADD constraint u_email UNIQUE(Email)");
        }
        
        public override void Down()
        {
        }
    }
}

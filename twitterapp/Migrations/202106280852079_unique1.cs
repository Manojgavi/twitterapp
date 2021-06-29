namespace twitterapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unique1 : DbMigration
    {
        public override void Up()
        {
            //Sql("Truncate table posts");
            //Sql("Truncate table users");
            Sql("ALTER TABLE users ALTER COLUMN  Email varchar(50); ");
            CreateIndex("dbo.users", "Email", unique: true, name: "IX_FirstAndSecond");
        }
        
        public override void Down()
        {
            DropIndex("dbo.users", "IX_FirstAndSecond");
        }
    }
}

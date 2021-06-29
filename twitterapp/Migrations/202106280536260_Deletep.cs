namespace twitterapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deletep : DbMigration
    {
        public override void Up()
        {
            Sql("Alter table posts drop column MyProperty");
        }
        
        public override void Down()
        {
        }
    }
}

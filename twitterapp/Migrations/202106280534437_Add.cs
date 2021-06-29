namespace twitterapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add : DbMigration
    {
        public override void Up()
        {
            Sql("Alter table posts add MyProperty int");
        }
        
        public override void Down()
        {
            
        }
    }
}

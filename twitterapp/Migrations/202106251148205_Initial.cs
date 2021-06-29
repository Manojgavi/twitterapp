namespace twitterapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MyProperty = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Post = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.posts", "UserId", "dbo.users");
            DropIndex("dbo.posts", new[] { "UserId" });
            DropTable("dbo.users");
            DropTable("dbo.posts");
        }
    }
}

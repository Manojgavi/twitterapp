namespace twitterapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newpost2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.newposts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Post = c.String(nullable: false, maxLength: 50),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.newposts", "UserId", "dbo.users");
            DropIndex("dbo.newposts", new[] { "UserId" });
            DropTable("dbo.newposts");
        }
    }
}

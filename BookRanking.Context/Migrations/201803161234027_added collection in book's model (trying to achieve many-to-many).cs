namespace BookRanking.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcollectioninbooksmodeltryingtoachievemanytomany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "User_Id", "dbo.Users");
            DropIndex("dbo.Books", new[] { "User_Id" });
            CreateTable(
                "dbo.UserBooks",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Book_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Book_Id);
            
            DropColumn("dbo.Books", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "User_Id", c => c.Int());
            DropForeignKey("dbo.UserBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.UserBooks", "User_Id", "dbo.Users");
            DropIndex("dbo.UserBooks", new[] { "Book_Id" });
            DropIndex("dbo.UserBooks", new[] { "User_Id" });
            DropTable("dbo.UserBooks");
            CreateIndex("dbo.Books", "User_Id");
            AddForeignKey("dbo.Books", "User_Id", "dbo.Users", "Id");
        }
    }
}

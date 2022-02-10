namespace CommonData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Users_Persons_Post : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        Name = c.String(),
                        MiddleName = c.String(),
                        DataBirth = c.DateTime(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .Index(t => t.Post_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsersBD",
                c => new
                    {
                        Login = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Description = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Login)
                .ForeignKey("dbo.Persons", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersBD", "Person_Id", "dbo.Persons");
            DropForeignKey("dbo.Persons", "Post_Id", "dbo.Posts");
            DropIndex("dbo.UsersBD", new[] { "Person_Id" });
            DropIndex("dbo.Persons", new[] { "Post_Id" });
            DropTable("dbo.UsersBD");
            DropTable("dbo.Posts");
            DropTable("dbo.Persons");
        }
    }
}

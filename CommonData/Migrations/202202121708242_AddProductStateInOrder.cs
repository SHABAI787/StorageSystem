namespace CommonData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductStateInOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "State_Id", c => c.Int());
            CreateIndex("dbo.Orders", "State_Id");
            AddForeignKey("dbo.Orders", "State_Id", "dbo.ProductStates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "State_Id", "dbo.ProductStates");
            DropIndex("dbo.Orders", new[] { "State_Id" });
            DropColumn("dbo.Orders", "State_Id");
        }
    }
}

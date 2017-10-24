namespace WebXe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSomething22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarImages", "CarModels_Id", c => c.Int());
            CreateIndex("dbo.CarImages", "CarModels_Id");
            AddForeignKey("dbo.CarImages", "CarModels_Id", "dbo.CarModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarImages", "CarModels_Id", "dbo.CarModels");
            DropIndex("dbo.CarImages", new[] { "CarModels_Id" });
            DropColumn("dbo.CarImages", "CarModels_Id");
        }
    }
}

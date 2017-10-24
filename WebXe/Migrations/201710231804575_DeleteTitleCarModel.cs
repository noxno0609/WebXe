namespace WebXe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTitleCarModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CarModels", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarModels", "Title", c => c.String(nullable: false));
        }
    }
}

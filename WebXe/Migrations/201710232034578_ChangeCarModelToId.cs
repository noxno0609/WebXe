namespace WebXe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCarModelToId : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(nullable: false),
                        CarModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CarImages");
        }
    }
}

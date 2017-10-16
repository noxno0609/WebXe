namespace WebXe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultCarTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CarTypes (Name) VALUES ('Xe Đạp')");
            Sql("INSERT INTO CarTypes (Name) VALUES ('Xe Máy')");
            Sql("INSERT INTO CarTypes (Name) VALUES ('Xe Oto')");
        }
        
        public override void Down()
        {
        }
    }
}

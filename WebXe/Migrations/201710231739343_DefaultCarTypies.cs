namespace WebXe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultCarTypies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CarTypies (Name) VALUES ('Xe Đap')");
            Sql("INSERT INTO CarTypies (Name) VALUES ('Xe Máy')");
            Sql("INSERT INTO CarTypies (Name) VALUES ('Xe Oto')");
        }
        
        public override void Down()
        {
        }
    }
}

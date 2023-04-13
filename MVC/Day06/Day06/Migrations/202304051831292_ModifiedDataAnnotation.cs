namespace Day06.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedDataAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "ClientName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Clients", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Email", c => c.String());
            AlterColumn("dbo.Clients", "Password", c => c.String());
            AlterColumn("dbo.Clients", "ClientName", c => c.String());
        }
    }
}

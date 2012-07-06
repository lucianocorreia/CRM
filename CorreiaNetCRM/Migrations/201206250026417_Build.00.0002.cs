namespace CorreiaNetCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Build000002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.crm_Usuarios", "SenhaProtegida", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.crm_Usuarios", "SenhaProtegida");
        }
    }
}

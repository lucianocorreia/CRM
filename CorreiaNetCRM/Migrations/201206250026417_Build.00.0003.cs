namespace CorreiaNetCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Build000003 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.crm_Usuarios", "SenhaProtegida");
        }
        
        public override void Down()
        {
            AddColumn("dbo.crm_Usuarios", "SenhaProtegida", c => c.String());
        }
    }
}

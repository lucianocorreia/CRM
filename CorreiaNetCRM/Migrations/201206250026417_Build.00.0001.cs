namespace CorreiaNetCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Build000001 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.crm_Usuarios", "Email", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.crm_Usuarios", "Email");
        }
    }
}

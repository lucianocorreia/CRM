namespace CorreiaNetCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.crm_Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 256),
                        Login = c.String(nullable: false, maxLength: 256),
                        Senha = c.String(maxLength: 256),
                        Ativo = c.Boolean(nullable: false),
                        UltimoAcesso = c.DateTime(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.crm_Usuarios");
        }
    }
}

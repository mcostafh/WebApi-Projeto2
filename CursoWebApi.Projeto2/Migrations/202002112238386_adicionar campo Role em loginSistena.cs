namespace CursoWebApi.Projeto2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionarcampoRoleemloginSistena : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoginsSistemas", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoginsSistemas", "Role");
        }
    }
}

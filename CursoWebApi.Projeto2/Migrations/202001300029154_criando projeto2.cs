namespace CursoWebApi.Projeto2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criandoprojeto2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        cod_cidade = c.Int(nullable: false, identity: true),
                        nome_cidade = c.String(nullable: false, maxLength: 100, unicode: false),
                        uf_cidade = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false),
                        cep_cidade = c.String(maxLength: 8, unicode: false),
                    })
                .PrimaryKey(t => t.cod_cidade);
            
            CreateTable(
                "dbo.LoginsSistemas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Nome = c.String(),
                        Email = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Cod_cliente = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        SobreNome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 14, unicode: false),
                        TelResidencial = c.String(nullable: false, maxLength: 14, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        cod_cidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Cod_cliente)
                .ForeignKey("dbo.Cidades", t => t.cod_cidade, cascadeDelete: true)
                .Index(t => t.cod_cidade);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "cod_cidade", "dbo.Cidades");
            DropIndex("dbo.Usuarios", new[] { "cod_cidade" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.LoginsSistemas");
            DropTable("dbo.Cidades");
        }
    }
}

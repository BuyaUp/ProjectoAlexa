namespace ProjectoAlexa.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrUpdateTables : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UsuarioPerfil", name: "Id", newName: "UsuarioPerfilId");
            RenameColumn(table: "dbo.Usuario", name: "Id", newName: "UsuarioId");
            DropPrimaryKey("dbo.Usuario");
            CreateTable(
                "dbo.Candidatura",
                c => new
                    {
                        CandidaturaId = c.String(nullable: false, maxLength: 200, unicode: false),
                        UsuarioId = c.String(nullable: false, maxLength: 200, unicode: false),
                        AreaCandidaturaId = c.Int(nullable: false),
                        DocumentosId = c.String(nullable: false, maxLength: 200, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CandidaturaId)
                .ForeignKey("dbo.AreaCandidatura", t => t.AreaCandidaturaId)
                .ForeignKey("dbo.Documento", t => t.DocumentosId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.AreaCandidaturaId)
                .Index(t => t.DocumentosId);
            
            CreateTable(
                "dbo.AreaCandidatura",
                c => new
                    {
                        AreaCandidaturaId = c.Int(nullable: false, identity: true),
                        AreaNome = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AreaCandidaturaId);
            
            CreateTable(
                "dbo.Pergunta",
                c => new
                    {
                        PerguntaId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        AreaCandidaturaId = c.Int(nullable: false),
                        UsuarioId = c.String(nullable: false, maxLength: 200, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PerguntaId)
                .ForeignKey("dbo.AreaCandidatura", t => t.AreaCandidaturaId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.AreaCandidaturaId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Resposta",
                c => new
                    {
                        RespostaId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Pergunta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.RespostaId)
                .ForeignKey("dbo.Pergunta", t => t.Pergunta_Id)
                .Index(t => t.Pergunta_Id);
            
            CreateTable(
                "dbo.Documento",
                c => new
                    {
                        DocumentoId = c.String(nullable: false, maxLength: 200, unicode: false),
                        BI = c.String(),
                        BIConfirma = c.Boolean(),
                        CertificadoHabilitacoes = c.String(),
                        CertificadoHabilitacoesConfirma = c.Boolean(),
                        CartaParaMinistro = c.String(),
                        CartaParaMinistroConfirma = c.Boolean(),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentoId);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        UsuarioId = c.String(nullable: false, maxLength: 200, unicode: false),
                        ProvinciaNome = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            AlterColumn("dbo.Usuario", "UsuarioId", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AddPrimaryKey("dbo.Usuario", "UsuarioId");
            DropColumn("dbo.Usuario", "MunicipioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "MunicipioId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Candidatura", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Candidatura", "DocumentosId", "dbo.Documento");
            DropForeignKey("dbo.Candidatura", "AreaCandidaturaId", "dbo.AreaCandidatura");
            DropForeignKey("dbo.Pergunta", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Resposta", "Pergunta_Id", "dbo.Pergunta");
            DropForeignKey("dbo.Pergunta", "AreaCandidaturaId", "dbo.AreaCandidatura");
            DropIndex("dbo.Resposta", new[] { "Pergunta_Id" });
            DropIndex("dbo.Pergunta", new[] { "UsuarioId" });
            DropIndex("dbo.Pergunta", new[] { "AreaCandidaturaId" });
            DropIndex("dbo.Candidatura", new[] { "DocumentosId" });
            DropIndex("dbo.Candidatura", new[] { "AreaCandidaturaId" });
            DropIndex("dbo.Candidatura", new[] { "UsuarioId" });
            DropPrimaryKey("dbo.Usuario");
            AlterColumn("dbo.Usuario", "UsuarioId", c => c.String(nullable: false, maxLength: 200, unicode: false));
            DropTable("dbo.Provincia");
            DropTable("dbo.Documento");
            DropTable("dbo.Resposta");
            DropTable("dbo.Pergunta");
            DropTable("dbo.AreaCandidatura");
            DropTable("dbo.Candidatura");
            AddPrimaryKey("dbo.Usuario", "Id");
            RenameColumn(table: "dbo.Usuario", name: "UsuarioId", newName: "Id");
            RenameColumn(table: "dbo.UsuarioPerfil", name: "UsuarioPerfilId", newName: "Id");
        }
    }
}

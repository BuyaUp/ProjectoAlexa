namespace ProjectoAlexa.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConcursoProvaTempoExame : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Concurso",
                c => new
                    {
                        ConcursoId = c.String(nullable: false, maxLength: 128, unicode: false),
                        DataInicio = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                        DataExames = c.DateTime(nullable: false),
                        DataResultados = c.DateTime(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ConcursoId);
            
            CreateTable(
                "dbo.Prova",
                c => new
                    {
                        ProvaId = c.String(nullable: false, maxLength: 128, unicode: false),
                        ExameId = c.String(nullable: false, maxLength: 200, unicode: false),
                        PerguntaId = c.Int(nullable: false),
                        RespostaSelecionadaId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProvaId)
                .ForeignKey("dbo.Exame", t => t.ExameId)
                .ForeignKey("dbo.Pergunta", t => t.PerguntaId)
                .ForeignKey("dbo.Resposta", t => t.RespostaSelecionadaId)
                .Index(t => t.ExameId)
                .Index(t => t.PerguntaId)
                .Index(t => t.RespostaSelecionadaId);
            
            CreateTable(
                "dbo.TempoExame",
                c => new
                    {
                        TempoExameId = c.String(nullable: false, maxLength: 128, unicode: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                        Valor = c.DateTime(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TempoExameId);
            
            AddColumn("dbo.Candidatura", "ConcursoId", c => c.String(maxLength: 128, unicode: false));
            AddColumn("dbo.Exame", "Resultado", c => c.Int(nullable: false));
            AddColumn("dbo.Exame", "TempoConclusao", c => c.DateTime());
            AddColumn("dbo.Questionario", "TempoExameId", c => c.String(maxLength: 128, unicode: false));
            CreateIndex("dbo.Candidatura", "ConcursoId");
            CreateIndex("dbo.Questionario", "TempoExameId");
            AddForeignKey("dbo.Candidatura", "ConcursoId", "dbo.Concurso", "ConcursoId");
            AddForeignKey("dbo.Questionario", "TempoExameId", "dbo.TempoExame", "TempoExameId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prova", "RespostaSelecionadaId", "dbo.Resposta");
            DropForeignKey("dbo.Prova", "PerguntaId", "dbo.Pergunta");
            DropForeignKey("dbo.Questionario", "TempoExameId", "dbo.TempoExame");
            DropForeignKey("dbo.Prova", "ExameId", "dbo.Exame");
            DropForeignKey("dbo.Candidatura", "ConcursoId", "dbo.Concurso");
            DropIndex("dbo.Questionario", new[] { "TempoExameId" });
            DropIndex("dbo.Prova", new[] { "RespostaSelecionadaId" });
            DropIndex("dbo.Prova", new[] { "PerguntaId" });
            DropIndex("dbo.Prova", new[] { "ExameId" });
            DropIndex("dbo.Candidatura", new[] { "ConcursoId" });
            DropColumn("dbo.Questionario", "TempoExameId");
            DropColumn("dbo.Exame", "TempoConclusao");
            DropColumn("dbo.Exame", "Resultado");
            DropColumn("dbo.Candidatura", "ConcursoId");
            DropTable("dbo.TempoExame");
            DropTable("dbo.Prova");
            DropTable("dbo.Concurso");
        }
    }
}

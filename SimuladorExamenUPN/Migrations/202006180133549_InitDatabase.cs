namespace SimuladorExamenUPN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alternativa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        EsCorrecto = c.Boolean(nullable: false),
                        PreguntaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pregunta", t => t.PreguntaId, cascadeDelete: true)
                .Index(t => t.PreguntaId);
            
            CreateTable(
                "dbo.Pregunta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                        TemaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tema", t => t.TemaId, cascadeDelete: true)
                .Index(t => t.TemaId);
            
            CreateTable(
                "dbo.Tema",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TemaCategoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TemaId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Tema", t => t.TemaId, cascadeDelete: true)
                .Index(t => t.TemaId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Examen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TemaId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        EstaActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tema", t => t.TemaId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.TemaId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.ExamenPregunta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamenId = c.Int(nullable: false),
                        PreguntaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pregunta", t => t.PreguntaId, cascadeDelete: true)
                .ForeignKey("dbo.Examen", t => t.ExamenId, cascadeDelete: false)
                .Index(t => t.ExamenId)
                .Index(t => t.PreguntaId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Nombres = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Examen", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Examen", "TemaId", "dbo.Tema");
            DropForeignKey("dbo.ExamenPregunta", "ExamenId", "dbo.Examen");
            DropForeignKey("dbo.ExamenPregunta", "PreguntaId", "dbo.Pregunta");
            DropForeignKey("dbo.Alternativa", "PreguntaId", "dbo.Pregunta");
            DropForeignKey("dbo.Pregunta", "TemaId", "dbo.Tema");
            DropForeignKey("dbo.TemaCategoria", "TemaId", "dbo.Tema");
            DropForeignKey("dbo.TemaCategoria", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.ExamenPregunta", new[] { "PreguntaId" });
            DropIndex("dbo.ExamenPregunta", new[] { "ExamenId" });
            DropIndex("dbo.Examen", new[] { "UsuarioId" });
            DropIndex("dbo.Examen", new[] { "TemaId" });
            DropIndex("dbo.TemaCategoria", new[] { "CategoriaId" });
            DropIndex("dbo.TemaCategoria", new[] { "TemaId" });
            DropIndex("dbo.Pregunta", new[] { "TemaId" });
            DropIndex("dbo.Alternativa", new[] { "PreguntaId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.ExamenPregunta");
            DropTable("dbo.Examen");
            DropTable("dbo.Categoria");
            DropTable("dbo.TemaCategoria");
            DropTable("dbo.Tema");
            DropTable("dbo.Pregunta");
            DropTable("dbo.Alternativa");
        }
    }
}
